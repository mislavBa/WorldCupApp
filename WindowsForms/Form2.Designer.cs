namespace WindowsForms
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            lblSelectLang = new Label();
            lblSelectGender = new Label();
            cbTeams = new ComboBox();
            btnSelectTeam = new Button();
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            changeSettingsToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblSelectLang
            // 
            resources.ApplyResources(lblSelectLang, "lblSelectLang");
            lblSelectLang.Name = "lblSelectLang";
            // 
            // lblSelectGender
            // 
            resources.ApplyResources(lblSelectGender, "lblSelectGender");
            lblSelectGender.Name = "lblSelectGender";
            // 
            // cbTeams
            // 
            resources.ApplyResources(cbTeams, "cbTeams");
            cbTeams.FormattingEnabled = true;
            cbTeams.Name = "cbTeams";
            // 
            // btnSelectTeam
            // 
            resources.ApplyResources(btnSelectTeam, "btnSelectTeam");
            btnSelectTeam.Name = "btnSelectTeam";
            btnSelectTeam.UseVisualStyleBackColor = true;
            btnSelectTeam.Click += btnSelectTeam_Click;
            // 
            // menuStrip1
            // 
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            menuStrip1.Name = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            resources.ApplyResources(settingsToolStripMenuItem, "settingsToolStripMenuItem");
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { changeSettingsToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            // 
            // changeSettingsToolStripMenuItem
            // 
            resources.ApplyResources(changeSettingsToolStripMenuItem, "changeSettingsToolStripMenuItem");
            changeSettingsToolStripMenuItem.Name = "changeSettingsToolStripMenuItem";
            changeSettingsToolStripMenuItem.Click += changeSettingsToolStripMenuItem_Click;
            // 
            // Form2
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnSelectTeam);
            Controls.Add(cbTeams);
            Controls.Add(lblSelectGender);
            Controls.Add(lblSelectLang);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form2";
            FormClosing += Form2_FormClosing;
            Load += Form2_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSelectLang;
        private Label lblSelectGender;
        private ComboBox cbTeams;
        private Button btnSelectTeam;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem changeSettingsToolStripMenuItem;
    }
}