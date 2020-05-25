namespace XyzTime
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.pb_CompanyLogo = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_Timer = new System.Windows.Forms.Label();
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.flowlayout_left = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_SyncTask = new MaterialSkin.Controls.MaterialRaisedButton();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btn_Dashboard = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_Logout = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_TaskSelect = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_Copyright = new MaterialSkin.Controls.MaterialLabel();
            this.lbl_SyncOn = new MaterialSkin.Controls.MaterialLabel();
            this.lbl_ScreenCapture = new MaterialSkin.Controls.MaterialLabel();
            this.lbl_KeyStroke = new System.Windows.Forms.Label();
            this.lbl_MouseClick = new System.Windows.Forms.Label();
            this.lbl_LogCount = new System.Windows.Forms.Label();
            this.lbl_Reset = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Application = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_TaskName = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_CompanyLogo)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.flowlayout_left.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 53F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(558, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 111);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1006, 499);
            this.splitContainer1.SplitterDistance = 116;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.materialLabel1);
            this.splitContainer3.Panel1.Controls.Add(this.pb_CompanyLogo);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer3.Size = new System.Drawing.Size(1006, 116);
            this.splitContainer3.SplitterDistance = 216;
            this.splitContainer3.TabIndex = 0;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(680, 117);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(108, 19);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "materialLabel1";
            // 
            // pb_CompanyLogo
            // 
            this.pb_CompanyLogo.BackColor = System.Drawing.Color.White;
            this.pb_CompanyLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_CompanyLogo.ImageLocation = "http://rakatech.com/logo.png";
            this.pb_CompanyLogo.Location = new System.Drawing.Point(0, 0);
            this.pb_CompanyLogo.Name = "pb_CompanyLogo";
            this.pb_CompanyLogo.Size = new System.Drawing.Size(216, 116);
            this.pb_CompanyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_CompanyLogo.TabIndex = 0;
            this.pb_CompanyLogo.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.lbl_Timer);
            this.flowLayoutPanel1.Controls.Add(this.lbl_UserName);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(786, 116);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lbl_Timer
            // 
            this.lbl_Timer.AutoSize = true;
            this.lbl_Timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Timer.ForeColor = System.Drawing.Color.Black;
            this.lbl_Timer.Location = new System.Drawing.Point(178, 0);
            this.lbl_Timer.Name = "lbl_Timer";
            this.lbl_Timer.Size = new System.Drawing.Size(374, 91);
            this.lbl_Timer.TabIndex = 8;
            this.lbl_Timer.Text = "lbl_Timer";
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.AutoSize = true;
            this.lbl_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UserName.ForeColor = System.Drawing.Color.Black;
            this.lbl_UserName.Location = new System.Drawing.Point(72, 0);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(100, 24);
            this.lbl_UserName.TabIndex = 6;
            this.lbl_UserName.Text = "UserName";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.flowlayout_left);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel2.Controls.Add(this.materialLabel3);
            this.splitContainer2.Panel2.Controls.Add(this.materialLabel2);
            this.splitContainer2.Panel2.Controls.Add(this.flowLayoutPanel3);
            this.splitContainer2.Panel2.Controls.Add(this.flowLayoutPanel2);
            this.splitContainer2.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer2.Size = new System.Drawing.Size(1006, 379);
            this.splitContainer2.SplitterDistance = 216;
            this.splitContainer2.TabIndex = 1;
            // 
            // flowlayout_left
            // 
            this.flowlayout_left.BackColor = System.Drawing.Color.White;
            this.flowlayout_left.Controls.Add(this.btn_SyncTask);
            this.flowlayout_left.Controls.Add(this.treeView1);
            this.flowlayout_left.Controls.Add(this.btn_Dashboard);
            this.flowlayout_left.Controls.Add(this.btn_Logout);
            this.flowlayout_left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowlayout_left.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowlayout_left.Location = new System.Drawing.Point(0, 0);
            this.flowlayout_left.Name = "flowlayout_left";
            this.flowlayout_left.Size = new System.Drawing.Size(216, 379);
            this.flowlayout_left.TabIndex = 0;
            // 
            // btn_SyncTask
            // 
            this.btn_SyncTask.Depth = 0;
            this.btn_SyncTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SyncTask.Location = new System.Drawing.Point(3, 3);
            this.btn_SyncTask.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_SyncTask.Name = "btn_SyncTask";
            this.btn_SyncTask.Primary = true;
            this.btn_SyncTask.Size = new System.Drawing.Size(210, 23);
            this.btn_SyncTask.TabIndex = 2;
            this.btn_SyncTask.Text = "Sync Tasks";
            this.btn_SyncTask.UseVisualStyleBackColor = true;
            this.btn_SyncTask.Click += new System.EventHandler(this.btn_SyncTask_Click);
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(3, 32);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(210, 273);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // btn_Dashboard
            // 
            this.btn_Dashboard.Depth = 0;
            this.btn_Dashboard.Location = new System.Drawing.Point(3, 311);
            this.btn_Dashboard.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_Dashboard.Name = "btn_Dashboard";
            this.btn_Dashboard.Primary = true;
            this.btn_Dashboard.Size = new System.Drawing.Size(210, 23);
            this.btn_Dashboard.TabIndex = 3;
            this.btn_Dashboard.Text = "Dashboard";
            this.btn_Dashboard.UseVisualStyleBackColor = true;
            this.btn_Dashboard.Click += new System.EventHandler(this.btn_Dashboard_Click);
            // 
            // btn_Logout
            // 
            this.btn_Logout.Depth = 0;
            this.btn_Logout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Logout.Location = new System.Drawing.Point(3, 340);
            this.btn_Logout.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_Logout.Name = "btn_Logout";
            this.btn_Logout.Primary = true;
            this.btn_Logout.Size = new System.Drawing.Size(210, 23);
            this.btn_Logout.TabIndex = 1;
            this.btn_Logout.Text = "Sign Out";
            this.btn_Logout.UseVisualStyleBackColor = true;
            this.btn_Logout.Click += new System.EventHandler(this.btn_Logout_Click);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(3, 85);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(69, 19);
            this.materialLabel3.TabIndex = 7;
            this.materialLabel3.Text = "Work log";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(429, 85);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(134, 19);
            this.materialLabel2.TabIndex = 6;
            this.materialLabel2.Text = "Recent screenshot";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.flowLayoutPanel3.Controls.Add(this.lbl_TaskSelect);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(786, 51);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // lbl_TaskSelect
            // 
            this.lbl_TaskSelect.AutoSize = true;
            this.lbl_TaskSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TaskSelect.ForeColor = System.Drawing.Color.Black;
            this.lbl_TaskSelect.Location = new System.Drawing.Point(489, 0);
            this.lbl_TaskSelect.Name = "lbl_TaskSelect";
            this.lbl_TaskSelect.Size = new System.Drawing.Size(294, 46);
            this.lbl_TaskSelect.TabIndex = 11;
            this.lbl_TaskSelect.Text = "lbl_TaskSelect";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lbl_Copyright);
            this.flowLayoutPanel2.Controls.Add(this.lbl_SyncOn);
            this.flowLayoutPanel2.Controls.Add(this.lbl_ScreenCapture);
            this.flowLayoutPanel2.Controls.Add(this.lbl_KeyStroke);
            this.flowLayoutPanel2.Controls.Add(this.lbl_MouseClick);
            this.flowLayoutPanel2.Controls.Add(this.lbl_LogCount);
            this.flowLayoutPanel2.Controls.Add(this.lbl_Reset);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 343);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(786, 36);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // lbl_Copyright
            // 
            this.lbl_Copyright.AutoSize = true;
            this.lbl_Copyright.Depth = 0;
            this.lbl_Copyright.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_Copyright.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_Copyright.Location = new System.Drawing.Point(626, 0);
            this.lbl_Copyright.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_Copyright.Name = "lbl_Copyright";
            this.lbl_Copyright.Size = new System.Drawing.Size(157, 19);
            this.lbl_Copyright.TabIndex = 0;
            this.lbl_Copyright.Text = "Copyright and Version";
            // 
            // lbl_SyncOn
            // 
            this.lbl_SyncOn.AutoSize = true;
            this.lbl_SyncOn.Depth = 0;
            this.lbl_SyncOn.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_SyncOn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_SyncOn.Location = new System.Drawing.Point(507, 0);
            this.lbl_SyncOn.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_SyncOn.Name = "lbl_SyncOn";
            this.lbl_SyncOn.Size = new System.Drawing.Size(113, 19);
            this.lbl_SyncOn.TabIndex = 3;
            this.lbl_SyncOn.Text = "last sync: 00:00";
            // 
            // lbl_ScreenCapture
            // 
            this.lbl_ScreenCapture.AutoSize = true;
            this.lbl_ScreenCapture.Depth = 0;
            this.lbl_ScreenCapture.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_ScreenCapture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_ScreenCapture.Location = new System.Drawing.Point(374, 0);
            this.lbl_ScreenCapture.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_ScreenCapture.Name = "lbl_ScreenCapture";
            this.lbl_ScreenCapture.Size = new System.Drawing.Size(127, 19);
            this.lbl_ScreenCapture.TabIndex = 4;
            this.lbl_ScreenCapture.Text = "last screen: 00:00";
            // 
            // lbl_KeyStroke
            // 
            this.lbl_KeyStroke.AutoSize = true;
            this.lbl_KeyStroke.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_KeyStroke.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_KeyStroke.Location = new System.Drawing.Point(273, 0);
            this.lbl_KeyStroke.Name = "lbl_KeyStroke";
            this.lbl_KeyStroke.Size = new System.Drawing.Size(95, 17);
            this.lbl_KeyStroke.TabIndex = 9;
            this.lbl_KeyStroke.Text = "lbl_KeyStroke";
            // 
            // lbl_MouseClick
            // 
            this.lbl_MouseClick.AutoSize = true;
            this.lbl_MouseClick.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MouseClick.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_MouseClick.Location = new System.Drawing.Point(166, 0);
            this.lbl_MouseClick.Name = "lbl_MouseClick";
            this.lbl_MouseClick.Size = new System.Drawing.Size(101, 17);
            this.lbl_MouseClick.TabIndex = 10;
            this.lbl_MouseClick.Text = "lbl_MouseClick";
            // 
            // lbl_LogCount
            // 
            this.lbl_LogCount.AutoSize = true;
            this.lbl_LogCount.Location = new System.Drawing.Point(126, 0);
            this.lbl_LogCount.Name = "lbl_LogCount";
            this.lbl_LogCount.Size = new System.Drawing.Size(34, 13);
            this.lbl_LogCount.TabIndex = 11;
            this.lbl_LogCount.Text = "Log:0";
            // 
            // lbl_Reset
            // 
            this.lbl_Reset.AutoSize = true;
            this.lbl_Reset.Location = new System.Drawing.Point(85, 0);
            this.lbl_Reset.Name = "lbl_Reset";
            this.lbl_Reset.Size = new System.Drawing.Size(35, 13);
            this.lbl_Reset.TabIndex = 12;
            this.lbl_Reset.Text = "Reset";
            this.lbl_Reset.DoubleClick += new System.EventHandler(this.lbl_Reset_DoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(401, 107);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(382, 233);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StartTime,
            this.Application,
            this.Title,
            this.Url});
            this.dataGridView1.Location = new System.Drawing.Point(-1, 107);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(403, 233);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "StartTime";
            this.StartTime.Name = "StartTime";
            this.StartTime.Width = 77;
            // 
            // Application
            // 
            this.Application.HeaderText = "Application";
            this.Application.Name = "Application";
            this.Application.Width = 84;
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.Width = 52;
            // 
            // Url
            // 
            this.Url.HeaderText = "Url";
            this.Url.Name = "Url";
            this.Url.Width = 45;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_TaskName
            // 
            this.lbl_TaskName.AutoSize = true;
            this.lbl_TaskName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TaskName.ForeColor = System.Drawing.Color.Blue;
            this.lbl_TaskName.Location = new System.Drawing.Point(647, 0);
            this.lbl_TaskName.Name = "lbl_TaskName";
            this.lbl_TaskName.Size = new System.Drawing.Size(66, 24);
            this.lbl_TaskName.TabIndex = 11;
            this.lbl_TaskName.Text = "lbl_TaskName";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 20000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumOrchid;
            this.ClientSize = new System.Drawing.Size(1006, 499);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RaKa Employee Time Log";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_CompanyLogo)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.flowlayout_left.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Application;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url;
        //private MaterialSkin.Controls.MaterialLabel test;
        private System.Windows.Forms.FlowLayoutPanel flowlayout_left;
        private MaterialSkin.Controls.MaterialRaisedButton btn_Logout;
        private System.Windows.Forms.Label lbl_Timer;
        private System.Windows.Forms.Label lbl_KeyStroke;
        private System.Windows.Forms.Label lbl_MouseClick;
        //private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_TaskName;
        private System.Windows.Forms.Label lbl_TaskSelect;
        private MaterialSkin.Controls.MaterialRaisedButton btn_SyncTask;
        private MaterialSkin.Controls.MaterialLabel lbl_SyncOn;
        private MaterialSkin.Controls.MaterialLabel lbl_ScreenCapture;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private MaterialSkin.Controls.MaterialLabel lbl_Copyright;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.PictureBox pb_CompanyLogo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialRaisedButton btn_Dashboard;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.Label lbl_LogCount;
        private System.Windows.Forms.Label lbl_Reset;
    }
}

