using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SignatureReportExample.Domain.Models;
using SignatureReportExample.Domain.ParameterObjects;
using SignatureReportExample.Domain.ResponseObjects;
using SignatureReportExample.Infrastructure.REST;

namespace SignatureReportExample
{
    public partial class MainForm : Form
    {
        int selected_location_id;

        public MainForm()
        {
            InitializeComponent();

            initialize_controls();

            using (var modal = new LoginForm())
            {
                modal.Closed += modal_closed;
                modal.ShowDialog(this);
            }
        }

        void initialize_controls()
        {
            programs_combo.Text = "Select location to populate this list.";
            programs_combo.Enabled = false;

            button1.Enabled = false;
            start_date_picker.Enabled = false;
            end_date_picker.Enabled = false;

            result_label.Visible = false;
        }

        void modal_closed(object sender, EventArgs e)
        {
            var location_getter = new MakeRestRequest<LocationsResponse>();
            var parameters = build_location_parameters();

            var location_result = location_getter.run("childcare/locations", parameters);
            locations_combo.DataSource = location_result.Data.locations;
            locations_combo.DisplayMember = "locationName";
        }

        IEnumerable<QueryParameter> build_location_parameters()
        {
            yield return new QueryParameter{name = "active", value = "1"};
        }

        private void locations_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected_location_id = ((Location)((ComboBox)sender).SelectedItem).locationId;

            var programs_parameters = build_program_parameters(selected_location_id);
            var program_getter = new MakeRestRequest<ProgramResponse>();
            var program_result = program_getter.run("childcare/programswithlocation", programs_parameters);

            if (program_result.Data.programs.Count > 0)
            {
                programs_combo.DataSource = program_result.Data.programs;
                programs_combo.DisplayMember = "name";
                programs_combo.Enabled = true;
            }
        }

        private void programs_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            start_date_picker.Enabled = true;
            end_date_picker.Enabled = true;
            button1.Enabled = true;
        }

        IEnumerable<QueryParameter> build_program_parameters(int location_id)
        {
            yield return new QueryParameter {name = "location_id", value = location_id.ToString()};
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result_label.Visible = false;
            button1.Enabled = false;

            var report_creator = new SignatureReportCreator();
            var file_name = report_creator.run(new SignatureReportParameters
                {
                    program_id = ((ChildCareProgram)programs_combo.SelectedItem).id,
                    location_id = ((Location)locations_combo.SelectedItem).locationId,
                    end_date = end_date_picker.Value.Date,
                    start_date = start_date_picker.Value.Date
                });

            if (file_name.Length > 0)
            {
                result_label.ForeColor = Color.Green;
                result_label.Text = string.Format("Created {0}", file_name);
            }
            else
            {
                result_label.ForeColor = Color.DarkRed;
                result_label.Text = "Error creating report";
            }

            result_label.Visible = true;
            button1.Enabled = true;
        }
    }
}
