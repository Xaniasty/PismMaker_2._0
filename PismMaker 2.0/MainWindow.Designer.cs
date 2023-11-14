namespace PismMaker_2._0
{
    partial class MainWindow
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
            labelAppName = new Label();
            labelChooseTeam = new Label();
            labelChooseTemplate = new Label();
            labelOptions = new Label();
            labelClientPanel = new Label();
            labelQuestions = new Label();
            labelControlPanel = new Label();
            labelAttachments = new Label();
            SuspendLayout();
            // 
            // labelAppName
            // 
            labelAppName.BackColor = SystemColors.Menu;
            labelAppName.BorderStyle = BorderStyle.Fixed3D;
            labelAppName.FlatStyle = FlatStyle.Popup;
            labelAppName.Font = new Font("Rockwell Extra Bold", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelAppName.ForeColor = Color.OrangeRed;
            labelAppName.Location = new Point(864, 10);
            labelAppName.Name = "labelAppName";
            labelAppName.Size = new Size(223, 85);
            labelAppName.TabIndex = 0;
            labelAppName.Text = "PismMaker 2.0";
            labelAppName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelChooseTeam
            // 
            labelChooseTeam.BackColor = SystemColors.AppWorkspace;
            labelChooseTeam.BorderStyle = BorderStyle.Fixed3D;
            labelChooseTeam.Font = new Font("Calibri", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelChooseTeam.Location = new Point(310, 9);
            labelChooseTeam.Name = "labelChooseTeam";
            labelChooseTeam.Size = new Size(548, 38);
            labelChooseTeam.TabIndex = 1;
            labelChooseTeam.Text = "Wybierz zespół:";
            // 
            // labelChooseTemplate
            // 
            labelChooseTemplate.BackColor = SystemColors.ActiveBorder;
            labelChooseTemplate.BorderStyle = BorderStyle.Fixed3D;
            labelChooseTemplate.Font = new Font("Calibri", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelChooseTemplate.Location = new Point(310, 57);
            labelChooseTemplate.Name = "labelChooseTemplate";
            labelChooseTemplate.Size = new Size(548, 38);
            labelChooseTemplate.TabIndex = 2;
            labelChooseTemplate.Text = "Wybór Szablonu:";
            // 
            // labelOptions
            // 
            labelOptions.BackColor = SystemColors.AppWorkspace;
            labelOptions.BorderStyle = BorderStyle.Fixed3D;
            labelOptions.Font = new Font("Calibri", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelOptions.Location = new Point(12, 10);
            labelOptions.Name = "labelOptions";
            labelOptions.Size = new Size(280, 288);
            labelOptions.TabIndex = 3;
            labelOptions.Text = "Opcje:";
            // 
            // labelClientPanel
            // 
            labelClientPanel.BackColor = SystemColors.ActiveBorder;
            labelClientPanel.BorderStyle = BorderStyle.Fixed3D;
            labelClientPanel.Font = new Font("Calibri", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelClientPanel.Location = new Point(310, 111);
            labelClientPanel.Name = "labelClientPanel";
            labelClientPanel.Size = new Size(777, 187);
            labelClientPanel.TabIndex = 4;
            labelClientPanel.Text = "Dane do pisma";
            // 
            // labelQuestions
            // 
            labelQuestions.BackColor = SystemColors.ActiveBorder;
            labelQuestions.BorderStyle = BorderStyle.Fixed3D;
            labelQuestions.Font = new Font("Calibri", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelQuestions.Location = new Point(310, 312);
            labelQuestions.Name = "labelQuestions";
            labelQuestions.Size = new Size(777, 272);
            labelQuestions.TabIndex = 5;
            labelQuestions.Text = "Wybierz pytania";
            // 
            // labelControlPanel
            // 
            labelControlPanel.BackColor = SystemColors.AppWorkspace;
            labelControlPanel.BorderStyle = BorderStyle.Fixed3D;
            labelControlPanel.Font = new Font("Calibri", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelControlPanel.Location = new Point(12, 312);
            labelControlPanel.Name = "labelControlPanel";
            labelControlPanel.Size = new Size(280, 272);
            labelControlPanel.TabIndex = 6;
            labelControlPanel.Text = "Panel Sterowania";
            // 
            // labelAttachments
            // 
            labelAttachments.BackColor = SystemColors.ActiveBorder;
            labelAttachments.BorderStyle = BorderStyle.Fixed3D;
            labelAttachments.Font = new Font("Calibri", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelAttachments.Location = new Point(310, 603);
            labelAttachments.Name = "labelAttachments";
            labelAttachments.Size = new Size(777, 214);
            labelAttachments.TabIndex = 7;
            labelAttachments.Text = "Załączniki";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(1099, 826);
            Controls.Add(labelAttachments);
            Controls.Add(labelControlPanel);
            Controls.Add(labelQuestions);
            Controls.Add(labelClientPanel);
            Controls.Add(labelOptions);
            Controls.Add(labelChooseTemplate);
            Controls.Add(labelChooseTeam);
            Controls.Add(labelAppName);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainWindow";
            Text = "Okno Główne";
            Load += MainWindow_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label labelAppName;
        private Label labelChooseTeam;
        private Label labelChooseTemplate;
        private Label labelOptions;
        private Label labelClientPanel;
        private Label labelQuestions;
        private Label labelControlPanel;
        private Label labelAttachments;
    }
}