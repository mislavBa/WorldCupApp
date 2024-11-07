namespace WindowsForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cbLang = new ComboBox();
            cbGender = new ComboBox();
            lblLanguage = new Label();
            lblGender = new Label();
            btnSelect = new Button();
            SuspendLayout();
            // 
            // cbLang
            // 
            cbLang.FormattingEnabled = true;
            cbLang.Items.AddRange(new object[] { "Croatian", "English" });
            cbLang.Location = new Point(210, 170);
            cbLang.Name = "cbLang";
            cbLang.Size = new Size(151, 28);
            cbLang.TabIndex = 0;
            // 
            // cbGender
            // 
            cbGender.FormattingEnabled = true;
            cbGender.Items.AddRange(new object[] { "Men", "Women" });
            cbGender.Location = new Point(210, 259);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(151, 28);
            cbGender.TabIndex = 1;
            // 
            // lblLanguage
            // 
            lblLanguage.AutoSize = true;
            lblLanguage.Location = new Point(97, 173);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.Size = new Size(74, 20);
            lblLanguage.TabIndex = 2;
            lblLanguage.Text = "Language";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(97, 262);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(111, 20);
            lblGender.TabIndex = 3;
            lblGender.Text = "Men or Women";
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(210, 352);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(151, 29);
            btnSelect.TabIndex = 4;
            btnSelect.Text = "Select";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(459, 456);
            Controls.Add(btnSelect);
            Controls.Add(lblGender);
            Controls.Add(lblLanguage);
            Controls.Add(cbGender);
            Controls.Add(cbLang);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Start Screen";
            KeyDown += Form1_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbLang;
        private ComboBox cbGender;
        private Label lblLanguage;
        private Label lblGender;
        private Button btnSelect;
    }
}
