using System;
using System.Windows.Forms;

namespace LoginProject
{

    public partial class Form1 : Form
    {

        private int falseLogin = 3;
        struct stUser
        {
            public string userName;
            public string password;

        }

        stUser user = new stUser();



        public Form1()
        {
            InitializeComponent();

            user.userName = "admin";
            user.password = "admin123";
        }

        private void txUserName_TextChanged(object sender, EventArgs e)
        {
            txUserName.Tag = txUserName.Text;
        }

        private void txPassword_TextChanged(object sender, EventArgs e)
        {
            txPassword.Tag = txPassword.Text;
        }
        private bool TextBoxEmpty()
        {
            if (string.IsNullOrEmpty(txUserName.Text.ToString()))
            {
                errorProvider1.SetError(txUserName, "Please enter your username.");
                return true;
            }
            if (string.IsNullOrEmpty(txPassword.Text.ToString()))
            {
                errorProvider1.SetError(txPassword, "Please Enter Your Password");
                return true;
            }
            return false;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!TextBoxEmpty())
            {
                if (falseLogin > 0)
                {
                    if (txUserName.Tag.ToString() == user.userName && txPassword.Tag.ToString() == user.password)
                    {
                        falseLogin--;
                        pictureBox1.Image = Properties.Resources.Person;
                        MessageBox.Show("Login Successful");

                    }
                    else
                    {
                        falseLogin--;
                        if (falseLogin == 0)
                        {
                            btnLogin.Enabled = false;
                        }
                        pictureBox1.Image = Properties.Resources.Faild;
                        MessageBox.Show("Login Failed. You have " + falseLogin + 1 + " attempts left.");
                    }
                }

            }

        }


    }
}
