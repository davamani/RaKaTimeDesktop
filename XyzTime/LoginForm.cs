using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;





namespace XyzTime
{
    public partial class LoginForm : Form
    {
        bool bln_LoginClick = false;
        public LoginForm()
        {
            InitializeComponent();

          this.Text = System.Windows.Forms.Application.ProductName + " v" +
                                 System.Windows.Forms.Application.ProductVersion;



            try
            {
                DataTable dt_User = new SqlLiteDb().RetrieveUserInfo().Tables[0];
                if (dt_User.Rows.Count > 0)
                {
                    tb_LoginEmail.Text = dt_User.Rows[0]["UEmail"].ToString();
                    tb_LoginPassword.Text = dt_User.Rows[0]["UPassword"].ToString();
                    //this.LoadMainForm(dt_User.Rows[0]["UEmail"].ToString(), dt_User.Rows[0]["UPassword"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoginForm: " + ex.Message);
            }
        }

        

       

        private void LoadMainForm(string str_Email, string str_Password)
        {
            DataSet ds=null;

            try
            {
                ds = new WebConnect().GetUserData(str_Email, str_Password);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
                return;
            }


            if (ds.Tables.Count > 1)
            {
                Properties.Settings.Default.UserTable = ds.Tables[0];
                Properties.Settings.Default.UserId = ds.Tables[0].Rows[0]["UserId"].ToString();
                Properties.Settings.Default.UserName = ds.Tables[0].Rows[0]["FullName"].ToString();
                Properties.Settings.Default.TaskTable = ds.Tables[1];
                Properties.Settings.Default.StorageAccountTable = ds.Tables[2];
                Properties.Settings.Default.TimeToken = ds.Tables[2].Rows[0]["TimeToken"].ToString();

                ////check app version 
                //if (ds.Tables[2].Rows[0]["AppVersion"].ToString()!= System.Windows.Forms.Application.ProductVersion)
                //{
                //    MessageBox.Show("Installed Version:"+ System.Windows.Forms.Application.ProductVersion + ". You must upgrade to New Version "+ ds.Tables[2].Rows[0]["AppVersion"].ToString() + ".  Please uninstall and install a new verion", Properties.Settings.Default.AlertTitle);
                //    Application.Exit();
                //}

                //create authtoken from backblaze
                new BackBlaze().GenerateAuthorizationToken();

                this.Hide();
                Form1 frmMain = new Form1();
                frmMain.Show();

                // Handle the ApplicationExit event to know when the application is exiting.
                  Application.ApplicationExit += new EventHandler(frmMain.OnApplicationExit);
            }
            else
            {
                if (this.bln_LoginClick) MessageBox.Show("Incorrect Email/Password");
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            bool createdNew;
            Mutex singleton = new Mutex(true, "RaKaTimeLog", out createdNew);

            if (!createdNew)
            {
                //app is already running! Exiting the application  
                MessageBox.Show("Application already running, if you want to restart, close the existing application and try",
                    Properties.Settings.Default.AlertTitle);
                Application.Exit();
                return;
            }


            this.bln_LoginClick = true;

            if (tb_LoginEmail.Text=="" || tb_LoginPassword.Text == "")
            {
                MessageBox.Show("Please provide username/password");
                return;
            }

            this.LoadMainForm(tb_LoginEmail.Text, tb_LoginPassword.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
