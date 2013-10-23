using System;
using System.Windows.Forms;
using SignatureReportExample.Domain.RequestObjects;
using SignatureReportExample.Domain.ResponseObjects;
using SignatureReportExample.Infrastructure;
using SignatureReportExample.Infrastructure.REST;

namespace SignatureReportExample
{
    public partial class LoginForm : Form
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public LoginForm()
        {
            InitializeComponent();

            username_textbox.Select();
            password_textbox.UseSystemPasswordChar = true;
        }

        private void login_button_clicked(object sender, EventArgs e)
        {
            if (error_label.Visible)
                error_label.Visible = false;

            var user_name = username_textbox.Text;
            var password = password_textbox.Text;

            var login_poster = new DoRESTPost<LoginResponse>();
            var result = login_poster.run("authenticate/user", new LoginRequest
                {
                    password = password,
                    userName = user_name
                });

            if (result.Data.authentication)
            {
                ClientContext.client_id = result.Data.admin.clientId;
                this.Close();
            }
            else
                error_label.Visible = true;
        }

        private void password_textbox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                login_button.PerformClick();
        }

    }
}
