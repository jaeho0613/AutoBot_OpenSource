namespace AutoBot2
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PanelMainMenu = new System.Windows.Forms.Panel();
            this.LabelClientConnect = new System.Windows.Forms.Label();
            this.BtnHomePage = new FontAwesome.Sharp.IconButton();
            this.PanelOptionSubMenu = new System.Windows.Forms.Panel();
            this.BtnOptionMultiSearch = new FontAwesome.Sharp.IconButton();
            this.BtnOptionAutoRune = new FontAwesome.Sharp.IconButton();
            this.BtnOptionPickTurn = new FontAwesome.Sharp.IconButton();
            this.BtnOptionAcceptDelay = new FontAwesome.Sharp.IconButton();
            this.BtnOption = new FontAwesome.Sharp.IconButton();
            this.PanelKakaoSubMenu = new System.Windows.Forms.Panel();
            this.BtnKakaoSendMessage = new FontAwesome.Sharp.IconButton();
            this.BtnKakaoLogout = new FontAwesome.Sharp.IconButton();
            this.BtnKakaoLogin = new FontAwesome.Sharp.IconButton();
            this.BtnKakao = new FontAwesome.Sharp.IconButton();
            this.BtnAutoClick = new FontAwesome.Sharp.IconButton();
            this.PanelBottomLayer = new System.Windows.Forms.Panel();
            this.PanelStateLayer = new System.Windows.Forms.Panel();
            this.BtnMinimize = new FontAwesome.Sharp.IconPictureBox();
            this.LabelState = new System.Windows.Forms.Label();
            this.PictureState = new FontAwesome.Sharp.IconPictureBox();
            this.PictureUserImg = new System.Windows.Forms.PictureBox();
            this.LabelUserName = new System.Windows.Forms.Label();
            this.BtnExit = new FontAwesome.Sharp.IconPictureBox();
            this.PanelTopLayer = new System.Windows.Forms.Panel();
            this.TimerAutoClick = new System.Windows.Forms.Timer(this.components);
            this.TimerFormRect = new System.Windows.Forms.Timer(this.components);
            this.TimerClientInit = new System.Windows.Forms.Timer(this.components);
            this.PanelMainMenu.SuspendLayout();
            this.PanelOptionSubMenu.SuspendLayout();
            this.PanelKakaoSubMenu.SuspendLayout();
            this.PanelStateLayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureUserImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnExit)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelMainMenu
            // 
            this.PanelMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(11)))), ((int)(((byte)(20)))));
            this.PanelMainMenu.Controls.Add(this.LabelClientConnect);
            this.PanelMainMenu.Controls.Add(this.BtnHomePage);
            this.PanelMainMenu.Controls.Add(this.PanelOptionSubMenu);
            this.PanelMainMenu.Controls.Add(this.BtnOption);
            this.PanelMainMenu.Controls.Add(this.PanelKakaoSubMenu);
            this.PanelMainMenu.Controls.Add(this.BtnKakao);
            this.PanelMainMenu.Controls.Add(this.BtnAutoClick);
            this.PanelMainMenu.Controls.Add(this.PanelBottomLayer);
            this.PanelMainMenu.Controls.Add(this.PanelStateLayer);
            this.PanelMainMenu.Controls.Add(this.PanelTopLayer);
            this.PanelMainMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMainMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMainMenu.Name = "PanelMainMenu";
            this.PanelMainMenu.Size = new System.Drawing.Size(160, 593);
            this.PanelMainMenu.TabIndex = 0;
            // 
            // LabelClientConnect
            // 
            this.LabelClientConnect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LabelClientConnect.ForeColor = System.Drawing.Color.DarkRed;
            this.LabelClientConnect.Location = new System.Drawing.Point(0, 515);
            this.LabelClientConnect.Name = "LabelClientConnect";
            this.LabelClientConnect.Size = new System.Drawing.Size(160, 23);
            this.LabelClientConnect.TabIndex = 57;
            this.LabelClientConnect.Text = "클라이언트 연결 끊김";
            this.LabelClientConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnHomePage
            // 
            this.BtnHomePage.BackColor = System.Drawing.Color.Transparent;
            this.BtnHomePage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnHomePage.FlatAppearance.BorderSize = 0;
            this.BtnHomePage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.BtnHomePage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.BtnHomePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnHomePage.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnHomePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHomePage.ForeColor = System.Drawing.Color.White;
            this.BtnHomePage.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.BtnHomePage.IconColor = System.Drawing.Color.White;
            this.BtnHomePage.IconSize = 40;
            this.BtnHomePage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnHomePage.Location = new System.Drawing.Point(0, 538);
            this.BtnHomePage.Name = "BtnHomePage";
            this.BtnHomePage.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnHomePage.Rotation = 0D;
            this.BtnHomePage.Size = new System.Drawing.Size(160, 55);
            this.BtnHomePage.TabIndex = 56;
            this.BtnHomePage.TabStop = false;
            this.BtnHomePage.Text = "HomePage";
            this.BtnHomePage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnHomePage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnHomePage.UseVisualStyleBackColor = false;
            this.BtnHomePage.Click += new System.EventHandler(this.BtnHomePage_Click);
            // 
            // PanelOptionSubMenu
            // 
            this.PanelOptionSubMenu.AutoSize = true;
            this.PanelOptionSubMenu.Controls.Add(this.BtnOptionMultiSearch);
            this.PanelOptionSubMenu.Controls.Add(this.BtnOptionAutoRune);
            this.PanelOptionSubMenu.Controls.Add(this.BtnOptionPickTurn);
            this.PanelOptionSubMenu.Controls.Add(this.BtnOptionAcceptDelay);
            this.PanelOptionSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelOptionSubMenu.Location = new System.Drawing.Point(0, 334);
            this.PanelOptionSubMenu.Name = "PanelOptionSubMenu";
            this.PanelOptionSubMenu.Size = new System.Drawing.Size(160, 140);
            this.PanelOptionSubMenu.TabIndex = 0;
            // 
            // BtnOptionMultiSearch
            // 
            this.BtnOptionMultiSearch.BackColor = System.Drawing.Color.Transparent;
            this.BtnOptionMultiSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnOptionMultiSearch.FlatAppearance.BorderSize = 0;
            this.BtnOptionMultiSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.BtnOptionMultiSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.BtnOptionMultiSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOptionMultiSearch.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnOptionMultiSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnOptionMultiSearch.ForeColor = System.Drawing.Color.White;
            this.BtnOptionMultiSearch.IconChar = FontAwesome.Sharp.IconChar.Square;
            this.BtnOptionMultiSearch.IconColor = System.Drawing.Color.White;
            this.BtnOptionMultiSearch.IconSize = 20;
            this.BtnOptionMultiSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOptionMultiSearch.Location = new System.Drawing.Point(0, 105);
            this.BtnOptionMultiSearch.Name = "BtnOptionMultiSearch";
            this.BtnOptionMultiSearch.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BtnOptionMultiSearch.Rotation = 0D;
            this.BtnOptionMultiSearch.Size = new System.Drawing.Size(160, 35);
            this.BtnOptionMultiSearch.TabIndex = 48;
            this.BtnOptionMultiSearch.TabStop = false;
            this.BtnOptionMultiSearch.Text = "자동 멀티 서치";
            this.BtnOptionMultiSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOptionMultiSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnOptionMultiSearch.UseVisualStyleBackColor = false;
            this.BtnOptionMultiSearch.Click += new System.EventHandler(this.BtnOptionMultiSearch_Click);
            // 
            // BtnOptionAutoRune
            // 
            this.BtnOptionAutoRune.BackColor = System.Drawing.Color.Transparent;
            this.BtnOptionAutoRune.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnOptionAutoRune.FlatAppearance.BorderSize = 0;
            this.BtnOptionAutoRune.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.BtnOptionAutoRune.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.BtnOptionAutoRune.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOptionAutoRune.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnOptionAutoRune.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnOptionAutoRune.ForeColor = System.Drawing.Color.White;
            this.BtnOptionAutoRune.IconChar = FontAwesome.Sharp.IconChar.Square;
            this.BtnOptionAutoRune.IconColor = System.Drawing.Color.White;
            this.BtnOptionAutoRune.IconSize = 20;
            this.BtnOptionAutoRune.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOptionAutoRune.Location = new System.Drawing.Point(0, 70);
            this.BtnOptionAutoRune.Name = "BtnOptionAutoRune";
            this.BtnOptionAutoRune.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BtnOptionAutoRune.Rotation = 0D;
            this.BtnOptionAutoRune.Size = new System.Drawing.Size(160, 35);
            this.BtnOptionAutoRune.TabIndex = 47;
            this.BtnOptionAutoRune.TabStop = false;
            this.BtnOptionAutoRune.Text = "자동 룬 선택";
            this.BtnOptionAutoRune.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOptionAutoRune.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnOptionAutoRune.UseVisualStyleBackColor = false;
            this.BtnOptionAutoRune.Click += new System.EventHandler(this.BtnOptionAutoRune_Click);
            // 
            // BtnOptionPickTurn
            // 
            this.BtnOptionPickTurn.BackColor = System.Drawing.Color.Transparent;
            this.BtnOptionPickTurn.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnOptionPickTurn.FlatAppearance.BorderSize = 0;
            this.BtnOptionPickTurn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.BtnOptionPickTurn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.BtnOptionPickTurn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOptionPickTurn.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnOptionPickTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnOptionPickTurn.ForeColor = System.Drawing.Color.White;
            this.BtnOptionPickTurn.IconChar = FontAwesome.Sharp.IconChar.Square;
            this.BtnOptionPickTurn.IconColor = System.Drawing.Color.White;
            this.BtnOptionPickTurn.IconSize = 20;
            this.BtnOptionPickTurn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOptionPickTurn.Location = new System.Drawing.Point(0, 35);
            this.BtnOptionPickTurn.Name = "BtnOptionPickTurn";
            this.BtnOptionPickTurn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BtnOptionPickTurn.Rotation = 0D;
            this.BtnOptionPickTurn.Size = new System.Drawing.Size(160, 35);
            this.BtnOptionPickTurn.TabIndex = 46;
            this.BtnOptionPickTurn.TabStop = false;
            this.BtnOptionPickTurn.Text = "픽 차례 메시지";
            this.BtnOptionPickTurn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOptionPickTurn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnOptionPickTurn.UseVisualStyleBackColor = false;
            this.BtnOptionPickTurn.Click += new System.EventHandler(this.BtnOptionPickTurn_Click);
            // 
            // BtnOptionAcceptDelay
            // 
            this.BtnOptionAcceptDelay.BackColor = System.Drawing.Color.Transparent;
            this.BtnOptionAcceptDelay.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnOptionAcceptDelay.FlatAppearance.BorderSize = 0;
            this.BtnOptionAcceptDelay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.BtnOptionAcceptDelay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.BtnOptionAcceptDelay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOptionAcceptDelay.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnOptionAcceptDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnOptionAcceptDelay.ForeColor = System.Drawing.Color.White;
            this.BtnOptionAcceptDelay.IconChar = FontAwesome.Sharp.IconChar.Square;
            this.BtnOptionAcceptDelay.IconColor = System.Drawing.Color.White;
            this.BtnOptionAcceptDelay.IconSize = 20;
            this.BtnOptionAcceptDelay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOptionAcceptDelay.Location = new System.Drawing.Point(0, 0);
            this.BtnOptionAcceptDelay.Name = "BtnOptionAcceptDelay";
            this.BtnOptionAcceptDelay.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BtnOptionAcceptDelay.Rotation = 0D;
            this.BtnOptionAcceptDelay.Size = new System.Drawing.Size(160, 35);
            this.BtnOptionAcceptDelay.TabIndex = 30;
            this.BtnOptionAcceptDelay.TabStop = false;
            this.BtnOptionAcceptDelay.Text = "매칭 수락 딜레이";
            this.BtnOptionAcceptDelay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOptionAcceptDelay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnOptionAcceptDelay.UseVisualStyleBackColor = false;
            this.BtnOptionAcceptDelay.Click += new System.EventHandler(this.BtnOptionAcceptDelay_Click);
            // 
            // BtnOption
            // 
            this.BtnOption.BackColor = System.Drawing.Color.Transparent;
            this.BtnOption.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnOption.FlatAppearance.BorderSize = 0;
            this.BtnOption.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.BtnOption.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.BtnOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOption.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnOption.ForeColor = System.Drawing.Color.White;
            this.BtnOption.IconChar = FontAwesome.Sharp.IconChar.UserCog;
            this.BtnOption.IconColor = System.Drawing.Color.White;
            this.BtnOption.IconSize = 40;
            this.BtnOption.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOption.Location = new System.Drawing.Point(0, 285);
            this.BtnOption.Name = "BtnOption";
            this.BtnOption.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnOption.Rotation = 0D;
            this.BtnOption.Size = new System.Drawing.Size(160, 49);
            this.BtnOption.TabIndex = 54;
            this.BtnOption.TabStop = false;
            this.BtnOption.Text = "Option";
            this.BtnOption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOption.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnOption.UseVisualStyleBackColor = false;
            this.BtnOption.Click += new System.EventHandler(this.BtnOption_Click);
            // 
            // PanelKakaoSubMenu
            // 
            this.PanelKakaoSubMenu.AutoSize = true;
            this.PanelKakaoSubMenu.Controls.Add(this.BtnKakaoSendMessage);
            this.PanelKakaoSubMenu.Controls.Add(this.BtnKakaoLogout);
            this.PanelKakaoSubMenu.Controls.Add(this.BtnKakaoLogin);
            this.PanelKakaoSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelKakaoSubMenu.Location = new System.Drawing.Point(0, 180);
            this.PanelKakaoSubMenu.Name = "PanelKakaoSubMenu";
            this.PanelKakaoSubMenu.Size = new System.Drawing.Size(160, 105);
            this.PanelKakaoSubMenu.TabIndex = 52;
            // 
            // BtnKakaoSendMessage
            // 
            this.BtnKakaoSendMessage.BackColor = System.Drawing.Color.Transparent;
            this.BtnKakaoSendMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnKakaoSendMessage.FlatAppearance.BorderSize = 0;
            this.BtnKakaoSendMessage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.BtnKakaoSendMessage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.BtnKakaoSendMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnKakaoSendMessage.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnKakaoSendMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnKakaoSendMessage.ForeColor = System.Drawing.Color.White;
            this.BtnKakaoSendMessage.IconChar = FontAwesome.Sharp.IconChar.PaperPlane;
            this.BtnKakaoSendMessage.IconColor = System.Drawing.Color.White;
            this.BtnKakaoSendMessage.IconSize = 20;
            this.BtnKakaoSendMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnKakaoSendMessage.Location = new System.Drawing.Point(0, 70);
            this.BtnKakaoSendMessage.Name = "BtnKakaoSendMessage";
            this.BtnKakaoSendMessage.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BtnKakaoSendMessage.Rotation = 0D;
            this.BtnKakaoSendMessage.Size = new System.Drawing.Size(160, 35);
            this.BtnKakaoSendMessage.TabIndex = 30;
            this.BtnKakaoSendMessage.TabStop = false;
            this.BtnKakaoSendMessage.Text = "SendMessage";
            this.BtnKakaoSendMessage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnKakaoSendMessage.UseVisualStyleBackColor = false;
            this.BtnKakaoSendMessage.Click += new System.EventHandler(this.BtnKakaoSendMessage_Click);
            // 
            // BtnKakaoLogout
            // 
            this.BtnKakaoLogout.BackColor = System.Drawing.Color.Transparent;
            this.BtnKakaoLogout.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnKakaoLogout.FlatAppearance.BorderSize = 0;
            this.BtnKakaoLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.BtnKakaoLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.BtnKakaoLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnKakaoLogout.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnKakaoLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnKakaoLogout.ForeColor = System.Drawing.Color.White;
            this.BtnKakaoLogout.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.BtnKakaoLogout.IconColor = System.Drawing.Color.White;
            this.BtnKakaoLogout.IconSize = 20;
            this.BtnKakaoLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnKakaoLogout.Location = new System.Drawing.Point(0, 35);
            this.BtnKakaoLogout.Name = "BtnKakaoLogout";
            this.BtnKakaoLogout.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BtnKakaoLogout.Rotation = 0D;
            this.BtnKakaoLogout.Size = new System.Drawing.Size(160, 35);
            this.BtnKakaoLogout.TabIndex = 29;
            this.BtnKakaoLogout.TabStop = false;
            this.BtnKakaoLogout.Text = "Logout";
            this.BtnKakaoLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnKakaoLogout.UseVisualStyleBackColor = false;
            this.BtnKakaoLogout.Click += new System.EventHandler(this.BtnKakaoLogout_Click);
            // 
            // BtnKakaoLogin
            // 
            this.BtnKakaoLogin.BackColor = System.Drawing.Color.Transparent;
            this.BtnKakaoLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnKakaoLogin.FlatAppearance.BorderSize = 0;
            this.BtnKakaoLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.BtnKakaoLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.BtnKakaoLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnKakaoLogin.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnKakaoLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnKakaoLogin.ForeColor = System.Drawing.Color.White;
            this.BtnKakaoLogin.IconChar = FontAwesome.Sharp.IconChar.SignInAlt;
            this.BtnKakaoLogin.IconColor = System.Drawing.Color.White;
            this.BtnKakaoLogin.IconSize = 20;
            this.BtnKakaoLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnKakaoLogin.Location = new System.Drawing.Point(0, 0);
            this.BtnKakaoLogin.Name = "BtnKakaoLogin";
            this.BtnKakaoLogin.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BtnKakaoLogin.Rotation = 0D;
            this.BtnKakaoLogin.Size = new System.Drawing.Size(160, 35);
            this.BtnKakaoLogin.TabIndex = 22;
            this.BtnKakaoLogin.TabStop = false;
            this.BtnKakaoLogin.Text = "Login";
            this.BtnKakaoLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnKakaoLogin.UseVisualStyleBackColor = false;
            this.BtnKakaoLogin.Click += new System.EventHandler(this.BtnKakaoLogin_Click);
            // 
            // BtnKakao
            // 
            this.BtnKakao.BackColor = System.Drawing.Color.Transparent;
            this.BtnKakao.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnKakao.FlatAppearance.BorderSize = 0;
            this.BtnKakao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.BtnKakao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.BtnKakao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnKakao.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnKakao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnKakao.ForeColor = System.Drawing.Color.White;
            this.BtnKakao.IconChar = FontAwesome.Sharp.IconChar.CommentDots;
            this.BtnKakao.IconColor = System.Drawing.Color.White;
            this.BtnKakao.IconSize = 40;
            this.BtnKakao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnKakao.Location = new System.Drawing.Point(0, 131);
            this.BtnKakao.MinimumSize = new System.Drawing.Size(0, 49);
            this.BtnKakao.Name = "BtnKakao";
            this.BtnKakao.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnKakao.Rotation = 0D;
            this.BtnKakao.Size = new System.Drawing.Size(160, 49);
            this.BtnKakao.TabIndex = 51;
            this.BtnKakao.TabStop = false;
            this.BtnKakao.Text = "Kakao";
            this.BtnKakao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnKakao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnKakao.UseVisualStyleBackColor = false;
            this.BtnKakao.Click += new System.EventHandler(this.BtnKakao_Click);
            // 
            // BtnAutoClick
            // 
            this.BtnAutoClick.BackColor = System.Drawing.Color.Transparent;
            this.BtnAutoClick.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnAutoClick.FlatAppearance.BorderSize = 0;
            this.BtnAutoClick.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.BtnAutoClick.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.BtnAutoClick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAutoClick.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnAutoClick.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnAutoClick.ForeColor = System.Drawing.Color.White;
            this.BtnAutoClick.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.BtnAutoClick.IconColor = System.Drawing.Color.White;
            this.BtnAutoClick.IconSize = 40;
            this.BtnAutoClick.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAutoClick.Location = new System.Drawing.Point(0, 82);
            this.BtnAutoClick.MaximumSize = new System.Drawing.Size(0, 69);
            this.BtnAutoClick.MinimumSize = new System.Drawing.Size(0, 49);
            this.BtnAutoClick.Name = "BtnAutoClick";
            this.BtnAutoClick.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnAutoClick.Rotation = 0D;
            this.BtnAutoClick.Size = new System.Drawing.Size(160, 49);
            this.BtnAutoClick.TabIndex = 50;
            this.BtnAutoClick.TabStop = false;
            this.BtnAutoClick.Text = "AutoClick";
            this.BtnAutoClick.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAutoClick.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnAutoClick.UseVisualStyleBackColor = false;
            this.BtnAutoClick.Click += new System.EventHandler(this.BtnAutoClick_Click);
            // 
            // PanelBottomLayer
            // 
            this.PanelBottomLayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(63)))));
            this.PanelBottomLayer.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelBottomLayer.Location = new System.Drawing.Point(0, 81);
            this.PanelBottomLayer.Name = "PanelBottomLayer";
            this.PanelBottomLayer.Size = new System.Drawing.Size(160, 1);
            this.PanelBottomLayer.TabIndex = 9;
            // 
            // PanelStateLayer
            // 
            this.PanelStateLayer.Controls.Add(this.BtnMinimize);
            this.PanelStateLayer.Controls.Add(this.LabelState);
            this.PanelStateLayer.Controls.Add(this.PictureState);
            this.PanelStateLayer.Controls.Add(this.PictureUserImg);
            this.PanelStateLayer.Controls.Add(this.LabelUserName);
            this.PanelStateLayer.Controls.Add(this.BtnExit);
            this.PanelStateLayer.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelStateLayer.Location = new System.Drawing.Point(0, 2);
            this.PanelStateLayer.Name = "PanelStateLayer";
            this.PanelStateLayer.Padding = new System.Windows.Forms.Padding(10);
            this.PanelStateLayer.Size = new System.Drawing.Size(160, 79);
            this.PanelStateLayer.TabIndex = 1;
            
            // 
            // BtnMinimize
            // 
            this.BtnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BtnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.BtnMinimize.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.BtnMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.BtnMinimize.IconColor = System.Drawing.SystemColors.ButtonShadow;
            this.BtnMinimize.IconSize = 20;
            this.BtnMinimize.Location = new System.Drawing.Point(112, 2);
            this.BtnMinimize.Name = "BtnMinimize";
            this.BtnMinimize.Size = new System.Drawing.Size(20, 20);
            this.BtnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.BtnMinimize.TabIndex = 11;
            this.BtnMinimize.TabStop = false;
            this.BtnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // LabelState
            // 
            this.LabelState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelState.AutoSize = true;
            this.LabelState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LabelState.ForeColor = System.Drawing.Color.DarkRed;
            this.LabelState.Location = new System.Drawing.Point(100, 59);
            this.LabelState.Name = "LabelState";
            this.LabelState.Size = new System.Drawing.Size(55, 15);
            this.LabelState.TabIndex = 10;
            this.LabelState.Text = "로그아웃";
            // 
            // PictureState
            // 
            this.PictureState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PictureState.BackColor = System.Drawing.Color.Transparent;
            this.PictureState.ForeColor = System.Drawing.Color.DarkRed;
            this.PictureState.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.PictureState.IconColor = System.Drawing.Color.DarkRed;
            this.PictureState.IconSize = 20;
            this.PictureState.Location = new System.Drawing.Point(79, 57);
            this.PictureState.Name = "PictureState";
            this.PictureState.Size = new System.Drawing.Size(20, 20);
            this.PictureState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureState.TabIndex = 9;
            this.PictureState.TabStop = false;
            // 
            // PictureUserImg
            // 
            this.PictureUserImg.Dock = System.Windows.Forms.DockStyle.Left;
            this.PictureUserImg.Location = new System.Drawing.Point(10, 10);
            this.PictureUserImg.Name = "PictureUserImg";
            this.PictureUserImg.Size = new System.Drawing.Size(59, 59);
            this.PictureUserImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureUserImg.TabIndex = 8;
            this.PictureUserImg.TabStop = false;
            // 
            // LabelUserName
            // 
            this.LabelUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelUserName.AutoSize = true;
            this.LabelUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelUserName.ForeColor = System.Drawing.Color.LemonChiffon;
            this.LabelUserName.Location = new System.Drawing.Point(79, 37);
            this.LabelUserName.Name = "LabelUserName";
            this.LabelUserName.Size = new System.Drawing.Size(75, 18);
            this.LabelUserName.TabIndex = 5;
            this.LabelUserName.Text = "unknown";
            // 
            // BtnExit
            // 
            this.BtnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExit.BackColor = System.Drawing.Color.Transparent;
            this.BtnExit.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.BtnExit.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.BtnExit.IconColor = System.Drawing.SystemColors.ButtonShadow;
            this.BtnExit.IconSize = 20;
            this.BtnExit.Location = new System.Drawing.Point(138, 2);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(20, 20);
            this.BtnExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.BtnExit.TabIndex = 3;
            this.BtnExit.TabStop = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // PanelTopLayer
            // 
            this.PanelTopLayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(90)))), ((int)(((byte)(40)))));
            this.PanelTopLayer.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTopLayer.Location = new System.Drawing.Point(0, 0);
            this.PanelTopLayer.Name = "PanelTopLayer";
            this.PanelTopLayer.Size = new System.Drawing.Size(160, 2);
            this.PanelTopLayer.TabIndex = 0;
            // 
            // TimerAutoClick
            // 
            this.TimerAutoClick.Tick += new System.EventHandler(this.TimerAutoClick_Tick);
            // 
            // TimerFormRect
            // 
            this.TimerFormRect.Tick += new System.EventHandler(this.TimerFormRect_Tick);
            // 
            // TimerClientInit
            // 
            this.TimerClientInit.Tick += new System.EventHandler(this.TimerClientInit_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(160, 593);
            this.Controls.Add(this.PanelMainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoClick2";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.PanelMainMenu.ResumeLayout(false);
            this.PanelMainMenu.PerformLayout();
            this.PanelOptionSubMenu.ResumeLayout(false);
            this.PanelKakaoSubMenu.ResumeLayout(false);
            this.PanelStateLayer.ResumeLayout(false);
            this.PanelStateLayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureUserImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMainMenu;
        private System.Windows.Forms.Panel PanelStateLayer;
        private System.Windows.Forms.Panel PanelTopLayer;
        private System.Windows.Forms.Panel PanelBottomLayer;
        private System.Windows.Forms.Panel PanelKakaoSubMenu;
        private FontAwesome.Sharp.IconButton BtnKakaoLogout;
        private FontAwesome.Sharp.IconButton BtnKakaoLogin;
        private FontAwesome.Sharp.IconButton BtnKakao;
        private FontAwesome.Sharp.IconButton BtnAutoClick;
        private System.Windows.Forms.PictureBox PictureUserImg;
        private System.Windows.Forms.Label LabelUserName;
        private FontAwesome.Sharp.IconPictureBox BtnExit;
        private FontAwesome.Sharp.IconButton BtnKakaoSendMessage;
        private System.Windows.Forms.Panel PanelOptionSubMenu;
        private FontAwesome.Sharp.IconButton BtnOptionPickTurn;
        private FontAwesome.Sharp.IconButton BtnOptionAcceptDelay;
        private FontAwesome.Sharp.IconButton BtnOption;
        private System.Windows.Forms.Label LabelState;
        private FontAwesome.Sharp.IconPictureBox PictureState;
        private System.Windows.Forms.Timer TimerAutoClick;
        private System.Windows.Forms.Timer TimerFormRect;
        private FontAwesome.Sharp.IconButton BtnOptionAutoRune;
        private FontAwesome.Sharp.IconPictureBox BtnMinimize;
        private FontAwesome.Sharp.IconButton BtnOptionMultiSearch;
        private FontAwesome.Sharp.IconButton BtnHomePage;
        private System.Windows.Forms.Label LabelClientConnect;
        private System.Windows.Forms.Timer TimerClientInit;
    }
}