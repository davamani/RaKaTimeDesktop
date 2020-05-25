using GlobalLowLevelHooks;
using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web;
using System.Windows.Automation;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using System.Threading;
using System.IO;
using XyzTime.Properties;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.Office.Interop.Word;
using System.Web.UI;

namespace XyzTime
{
    public partial class Form1 : Form
    {
        DateTime dt_InActiveSince;
        int int_TotalSeconds = 0;

        int int_KeyPressCount = 0;
        int int_MouseClickCount = 0;
        int int_MouseMoveCount = 0;
        int int_TimeSec = 0;

        int int_SecondsToLog = 10;
        int int_SecondsToUpload = 60;

        int int_SecondsToScreenRandomFrom = 20;
        int int_SecondsToScreenRandomTo = 60;
        int int_SecondsToScreen = 10;

        int int_StopTimeWhenIdleSeconds = 0;

        bool bln_Started = false;
        bool bln_PictureCapture = false;
        bool bln_ShowStartReminder = false;
        bool bln_StartTimerWhenFormOpens1stTime = false;

        DateTime dt_LastUserAction = DateTime.Now;
        DataTable dt_Account = null;

        KeyboardHook keyboardHook;
        MouseHook mouseHook;
        SqlLiteDb SDB;
        BackBlaze BB;
        public Form1()
        {
            InitializeComponent();

            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            DataTable dt_User = Properties.Settings.Default.UserTable;
            lbl_UserName.Text = dt_User.Rows[0]["FullName"].ToString();
            this.bln_PictureCapture = Convert.ToBoolean(dt_User.Rows[0]["PictureCapture"]);
            this.int_SecondsToLog = Convert.ToInt32(dt_User.Rows[0]["SecondsToLogInfo"]);
            this.int_SecondsToUpload = Convert.ToInt32(dt_User.Rows[0]["SecondsToUploadLog"]);
            this.int_SecondsToScreenRandomFrom = Convert.ToInt32(dt_User.Rows[0]["PictureCaptureRandomSecondsFrom"]);
            this.int_SecondsToScreenRandomTo = Convert.ToInt32(dt_User.Rows[0]["PictureCaptureRandomSecondsTo"]);
            this.int_StopTimeWhenIdleSeconds = Convert.ToInt32(dt_User.Rows[0]["StopTimeWhenIdleSeconds"]);

            this.DisplayTimerLabel();

            lbl_Copyright.Text = " | " + System.Windows.Forms.Application.ProductName + " v" +
                                 System.Windows.Forms.Application.ProductVersion + ". " +
                                 System.Windows.Forms.Application.CompanyName;
            System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
            lbl.Text = "Disabled";
      
            if (!this.bln_PictureCapture) pictureBox1.Controls.Add(lbl);

            this.dt_Account = (System.Data.DataTable)Properties.Settings.Default.StorageAccountTable;

            pb_CompanyLogo.ImageLocation = dt_Account.Rows[0]["CompanyLogo"].ToString();
            this.Text = dt_Account.Rows[0]["CompanyName"].ToString() + " | User: " + Properties.Settings.Default.UserName;


            this.SDB = new SqlLiteDb();
            this.BB = new BackBlaze();
           

            this.StoreCredentialToLocalDb();
            this.LoadTaskTree();
            this.AssignLogCount();

            // Create the Mouse Hook
            mouseHook = new MouseHook();

            // Create the Keyboard Hook
            this.keyboardHook = new KeyboardHook();

            // Capture the events
            //mouseHook.MouseMove += new MouseHook.MouseHookCallback(mouseHook_MouseMove);
            mouseHook.LeftButtonDown += new MouseHook.MouseHookCallback(mouseHook_Click);

            //Installing the Mouse Hooks
            mouseHook.Install();
            //Using the Keyboard Hook:

            // Capture the events
            keyboardHook.KeyDown += new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyDown);
            keyboardHook.KeyUp += new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyUp);

            //Installing the Keyboard Hooks
            keyboardHook.Install();

            ////start the timer by default
            //this.StartTimer();
            //MessageBox.Show("Task activity started. Please make sure you select the right task from left side task view.");
        }

        

        private void LoadTaskTree()
        {
            DataTable dt_Tasks = (DataTable)Properties.Settings.Default.TaskTable;
            DataTable dt_Project = new DataView(dt_Tasks).ToTable(true, new string[] { "ProjectKey", "ProjectName" });

            int i = 0;
            foreach (DataRow dr_Project in dt_Project.Rows)
            {
                treeView1.Nodes.Add(dr_Project["ProjectKey"].ToString(), dr_Project["ProjectName"].ToString());
                foreach (DataRow dr_Task in dt_Tasks.Select("ProjectKey='" + dr_Project["ProjectKey"].ToString() + "'"))
                {
                    treeView1.Nodes[i].Nodes.Add(dr_Task["TaskKey"].ToString(), dr_Task["TaskName"].ToString());
                }
                i++;
            }
            treeView1.ExpandAll();

            //select default task
            lbl_TaskSelect.Text = treeView1.Nodes[0].Nodes[0].Text;
        }


        private void StoreCredentialToLocalDb()
        {
            DataTable dt_User = Properties.Settings.Default.UserTable;
            string str_Sql = @"delete from UserLogin;
                insert into UserLogin (UEmail, UPassword) values (@UEmail, @UPassword);";
            SQLiteCommand sc = new SQLiteCommand(str_Sql);
            sc.Parameters.AddWithValue("@UEmail", dt_User.Rows[0]["LoginEmail"].ToString());
            sc.Parameters.AddWithValue("@UPassword", dt_User.Rows[0]["UserPassword"].ToString());
            try
            {
                this.SDB.ExecuteQuery(sc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("in-build storage failed: " + ex.Message);
                Console.WriteLine("StoreCredentialToLocalDb failed: " + ex.ToString());
            }
        }

        private void mouseHook_MouseMove(MouseHook.MSLLHOOKSTRUCT mstruck)
        {
            if (bln_Started == true)
            {
                this.int_MouseMoveCount++;
            }
        }

        private void mouseHook_Click(MouseHook.MSLLHOOKSTRUCT mstruck)
        {
            this.dt_LastUserAction = DateTime.Now;
            if (bln_Started == true)
            {
                this.int_MouseClickCount++;
            }
            
        }

        private void keyboardHook_KeyUp(KeyboardHook.VKeys key)
        {
            this.dt_LastUserAction = DateTime.Now;
            if (bln_Started == true) this.int_KeyPressCount++;
   
        }

        private void keyboardHook_KeyDown(KeyboardHook.VKeys key)
        {
            //Console.WriteLine("[" + DateTime.Now.ToLongTimeString() + "] KeyDown Event {" + key.ToString() + "}");
            //this.dataGridView1.Rows.Add(DateTime.Now.ToString(), "keyboardHook_KeyDown", "KeyDown Event", key.ToString());
        }

        private void StartTimer()
        {
            button1.BackColor = System.Drawing.Color.YellowGreen;

            timer1.Start();
            bln_Started = true;
            button1.Text = "Stop Timer";
            this.DisplayTimerLabel();
        }

        private void StopTimer()
        {
            button1.BackColor = System.Drawing.Color.OrangeRed;

            timer1.Stop();
            bln_Started = false;
            button1.Text = "Start Timer";

            dt_InActiveSince = DateTime.Now;
            this.bln_ShowStartReminder = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bln_Started == false)
            {
                StartTimer();
            }
            else
            {
                StopTimer();
            }
        }

        private void DisplayTimerLabel()
        {
            int int_Hours = this.int_TotalSeconds / 60 / 60;
            int int_Minutes = (this.int_TotalSeconds / 60) % 60;
            int int_Seconds = this.int_TotalSeconds % 60;
            lbl_Timer.Text = int_Hours.ToString() + "h:" + int_Minutes.ToString() + "m:" + int_Seconds.ToString() + "s";

            lbl_KeyStroke.Text = "KeyStroke: " + this.int_KeyPressCount.ToString();
            lbl_MouseClick.Text = "MouseClick: " + this.int_MouseClickCount.ToString();
        }

        private string CaptureMyScreen()
        {
            try
            {
                //Creating a new Bitmap object
                Bitmap captureBitmap = new Bitmap(1024, 768, PixelFormat.Format32bppArgb);
                //Bitmap captureBitmap = new Bitmap(int width, int height, PixelFormat);
                //Creating a Rectangle object which will  
                //capture our Current Screen
                System.Drawing.Rectangle captureRectangle = Screen.AllScreens[0].Bounds;

                //Creating a New Graphics Object
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);

                //Copying Image from The Screen
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

                //Saving the Image File (I am here Saving it in My E drive).
                string str_guid = Guid.NewGuid().ToString();
                string str_FileName = @"U" + Properties.Settings.Default.UserId + "_" +
                    DateTime.Now.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_") + "_" + str_guid + ".jpg";
                string str_FileNameFull = Properties.Settings.Default.StoragePath + @"\" + str_FileName;
                captureBitmap.Save(str_FileNameFull, ImageFormat.Jpeg);

                pictureBox1.ImageLocation = str_FileNameFull;
                

                lbl_ScreenCapture.Text = "last screen: " + DateTime.Now.ToLongTimeString();

                try
                {
                    Console.WriteLine("screen captured: " + str_FileName);
                    BackBlaze BB = new BackBlaze();
                    BB.UploadFileToCloud(str_FileName, str_FileNameFull);
            
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception in BackBlaze upload : " + ex.Message);
                }
                

                return str_FileName;

            }

            catch (Exception ex)
            {

                Console.WriteLine("Exception in capture picture: " + ex.Message);
                throw ex;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.int_TotalSeconds++;
                this.int_TimeSec++;

                this.DisplayTimerLabel();
                if (this.int_TotalSeconds % this.int_SecondsToLog == 0)
                {
                    //  listView1.Items.Add(new ListViewItem("Picture captured at " + DateTime.Now.ToString()));
                    IntPtr hWnd = GetForegroundWindow();
                    uint procId = 0;
                    GetWindowThreadProcessId(hWnd, out procId);
                    var proc = System.Diagnostics.Process.GetProcessById((int)procId);
                    if (proc == null) return;
                    //Console.WriteLine(proc.MainModule);

                    string str_AppName = proc.ProcessName;
                    string str_AppTitle = lbl_TaskSelect.Text;
                    string str_Url = "";

                    if (str_AppName == "chrome") str_Url = GetChromeUrl(proc);
                    else if (str_AppName == "iexplore") str_Url = GetInternetExplorerUrl(proc);
                    else if (str_AppName == "firefox") str_Url = GetFirefoxUrl(proc);

                    if (str_Url == null) str_Url = "";

                    try
                    {
                        this.SDB.InsertTimeLog(str_AppName + ":" + proc.MainWindowTitle, str_AppTitle, str_Url, this.int_KeyPressCount, this.int_MouseClickCount, this.int_MouseMoveCount, this.int_TimeSec);
                        this.AssignLogCount();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("InsertTimeLog failed: " + ex.ToString());
                    }

                    //after every insert reset the seconds to 0
                    this.int_TimeSec = 0;
                    this.int_KeyPressCount = 0;
                    this.int_MouseClickCount = 0;
                    this.int_MouseMoveCount = 0;

                    this.dataGridView1.Rows.Add(DateTime.Now.ToString(), str_AppName, str_AppTitle, str_Url);

                    if (str_AppName.ToLower() == "idle")
                    {
                        this.StopTimer();
                        timer2.Stop();
                        this.TopMost = true;
                        DialogResult result = MessageBox.Show("It seems you are idle, Are you on break?",
                            Properties.Settings.Default.AlertTitle, MessageBoxButtons.YesNo);
                        if (result == DialogResult.No)
                        {
                            this.StartTimer();
                        }
                        this.TopMost = false;
                        timer2.Start();
                    }
            
                }

                //upload to web server
                if (this.int_TotalSeconds % this.int_SecondsToUpload == 0)
                {
                    this.UploadToServer();
                }

                //screen capture randomly
                if (this.bln_PictureCapture)
                {
                    if (this.int_TotalSeconds % this.int_SecondsToScreen == 0)
                    {
                        string str_CaptureScreenFileName = this.CaptureMyScreen();

                        Console.WriteLine("capture picture completed: " + str_CaptureScreenFileName);
                        this.int_SecondsToScreen = new Random().Next(this.int_SecondsToScreenRandomFrom, this.int_SecondsToScreenRandomTo);

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in timer tick event: " + ex.Message);
                timer1.Stop();
                timer1.Start();
            }
        }



        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lbl_TaskSelect.Text = treeView1.SelectedNode.Text;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public static string GetChromeUrl(Process process)
        {

            if (process.MainWindowHandle == IntPtr.Zero)
                return null;

            AutomationElement element = AutomationElement.FromHandle(process.MainWindowHandle);
            if (element == null)
                return null;
            // to find the tabs we first need to locate something reliable - the 'New Tab' button 
            AutomationElement root = AutomationElement.FromHandle(process.MainWindowHandle);
            var SearchBar = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "Address and search bar"));
            if (SearchBar != null)
                return (string)SearchBar.GetCurrentPropertyValue(ValuePatternIdentifiers.ValueProperty);

            return null;
        }

        public static string GetInternetExplorerUrl(Process process)
        {

            if (process.MainWindowHandle == IntPtr.Zero)
                return null;

            AutomationElement element = AutomationElement.FromHandle(process.MainWindowHandle);
            if (element == null)
                return null;

            AutomationElement rebar = element.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "ReBarWindow32"));
            if (rebar == null)
                return null;

            AutomationElement edit = rebar.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));

            return ((ValuePattern)edit.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
        }

        public static string GetFirefoxUrl(Process process)
        {

            if (process.MainWindowHandle == IntPtr.Zero)
                return null;

            AutomationElement element = AutomationElement.FromHandle(process.MainWindowHandle);
            if (element == null)
                return null;

            AutomationElement doc = element.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document));
            if (doc == null)
                return null;

            return ((ValuePattern)doc.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
        }

        public void OnApplicationExit(object sender, EventArgs e)
        {
            keyboardHook.KeyDown -= new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyDown);
            keyboardHook.KeyUp -= new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyUp);
            keyboardHook.Uninstall();
            mouseHook.MouseMove -= new MouseHook.MouseHookCallback(mouseHook_MouseMove);
            mouseHook.Uninstall();
        }

        private async void UploadToServer()
        {
            int int_TotalRows = Convert.ToInt32(this.SDB.GetDataSet("select count(*) from TimeLog").Tables[0].Rows[0][0]);
            while (int_TotalRows > 0)
            {
                HttpClient client = new HttpClient();

                //time log & picturelog
                string str_Sql = @"Select LogOn, substr(appname,1,254) AppName, substr(AppData,1,999) AppData, substr(AppTitle,1,999) AppTitle,
                         KeyStroke,MouseClick,MouseMove, TimeSec from TimeLog order by LogOn  LIMIT 20;
                        Select FileName, FileCreatedOn from CaptureScreen;";
                DataSet ds = SDB.GetDataSet(str_Sql);
                ds.Tables[0].TableName = "timelog";
                ds.Tables[1].TableName = "picturelog";
                DataTable dt_Token = new DataTable("auth");
                dt_Token.Columns.Add("timetoken");
                dt_Token.Rows.Add(dt_Account.NewRow()["timetoken"] = Properties.Settings.Default.TimeToken);
                ds.Tables.Add(dt_Token);

                //string str_BaseUrl = "https://localhost:44364/activitylogp.ashx";
                string str_BaseUrl = "http://webtime20200503112752.azurewebsites.net/activitylogp.ashx";
                string str_JsonLog = JsonConvert.SerializeObject(ds, Formatting.Indented);
                str_JsonLog = HttpUtility.HtmlEncode(str_JsonLog);

                ToolTip tt = new ToolTip();
                tt.SetToolTip(lbl_SyncOn, "");

                var content = new StringContent(str_JsonLog, System.Text.Encoding.UTF8, "application/json");
                try
                {
                    var response = await client.PostAsync(str_BaseUrl, content);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        if (responseContent.ToString() == "Inserted")
                        {
                            this.SDB.GetDataSet("delete from TimeLog where LogSeq in (select LogSeq from TimeLog order by Logon LIMIT 20)");
                            SDB.ExecuteQuery("delete from CaptureScreen");
                            int_TotalRows = Convert.ToInt32(this.SDB.GetDataSet("select count(*) from TimeLog").Tables[0].Rows[0][0]);
                            lbl_SyncOn.Text = "last sync: " + DateTime.Now.ToLongTimeString();
                            tt.SetToolTip(lbl_SyncOn, responseContent.ToString());
                        }
                        else if (responseContent.ToString() == "Invalid Token")
                        {
                            this.StopTimer();
                            MessageBox.Show("Invalid Application Call." + Environment.NewLine 
                                + "Another Session running. " + Environment.NewLine
                                + "Closing Application." + Environment.NewLine
                                , Properties.Settings.Default.AlertTitle);
                            this.SDB.ExecuteQuery("delete from TimeLog");
                            this.SDB.ExecuteQuery("delete from CaptureScreen");

                            System.Windows.Forms.Application.Exit();
                        }
                        else
                        {

                            lbl_SyncOn.Text = "Error Response";
                            tt.SetToolTip(lbl_SyncOn, responseContent.ToString());
                            break;
                        }
                    }
                    else
                    {
                        var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        lbl_SyncOn.Text = "Post URL failure";
                        tt.SetToolTip(lbl_SyncOn, response.StatusCode.ToString());
                        break;
                    }
                }
                catch (Exception ex)
                {
                    lbl_SyncOn.Text = "ERROR!";
                    tt.SetToolTip(lbl_SyncOn, ex.ToString());
                    this.dataGridView1.Rows.Add(DateTime.Now.ToString(), ex.Message, ex.InnerException, str_BaseUrl);
                    break;
                }


            }  // end of while
     
            //clear datagrid after sync to server
            dataGridView1.Rows.Clear();
        }

        private void materialLabel3_Click(object sender, EventArgs e)
        {

        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            SDB.ExecuteQuery("delete from UserLogin");
            this.Close();
            System.Windows.Forms.Application.Exit();
        }

        private void btn_SyncTask_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sync Task was not ready", Properties.Settings.Default.AlertTitle);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            TimeSpan diff = DateTime.Now - dt_LastUserAction;
            double diff_Seconds = diff.TotalSeconds;
            Console.WriteLine("No Action for Last: " + diff_Seconds.ToString() + " seconds");

           // this.int_StopTimeWhenIdleSeconds = 25;
            if (this.bln_Started==true && diff_Seconds > this.int_StopTimeWhenIdleSeconds)
            {
                this.StopTimer();
                timer2.Stop();
                this.TopMost = true;
                DialogResult result =  MessageBox.Show("Are you on break?",
                    Properties.Settings.Default.AlertTitle, MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    this.StartTimer();
                }
                this.TopMost = false;
                timer2.Start();

            }

            if (bln_ShowStartReminder == true)
            {
                diff = DateTime.Now - dt_InActiveSince;
                diff_Seconds = diff.TotalSeconds;
                if (this.bln_Started == false && diff_Seconds > int_StopTimeWhenIdleSeconds)
                {
                    timer2.Stop();
                    this.TopMost = true;
                    bln_ShowStartReminder = false;
                     MessageBox.Show("It appears that  you are not running TimeLog. Please check, otherwise you may lose your productivity.",
                        Properties.Settings.Default.AlertTitle);
                    timer2.Start();
                    this.TopMost = false;
                }
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            string str_DashXml = new WebConnect().GetDashboardToken(dt_Account.Rows[0]["TimeToken"].ToString());
            string str_Portal = dt_Account.Rows[0]["TimeUrl"].ToString() + str_DashXml;
            Process.Start(str_Portal);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (bln_StartTimerWhenFormOpens1stTime == false)
            {
                this.StartTimer();
                bln_StartTimerWhenFormOpens1stTime = true;
            }
        }

        private void lbl_Reset_DoubleClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This will delete the local data and start a fresh. Do you want to continue?",
                   Properties.Settings.Default.AlertTitle, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //time log & picturelog
                string str_Sql = @"delete from TimeLog;
                        delete from CaptureScreen;";
                this.SDB.ExecuteQuery(str_Sql);
                this.AssignLogCount();
            }
        }

        protected void AssignLogCount()
        {
            lbl_LogCount.Text = "Logs: " + this.SDB.GetDataSet("select count(*) from TimeLog").Tables[0].Rows[0][0].ToString();
        }

    }



}
