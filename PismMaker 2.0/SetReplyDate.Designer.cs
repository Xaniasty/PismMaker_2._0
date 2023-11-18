namespace PismMaker_2._0
{
    partial class SetReplyDate
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
            labelDescription = new Label();
            buttonSendNewDate = new Button();
            labelNewReplyDate = new Label();
            textBoxDaysToAdd = new TextBox();
            labelDaysDescription = new Label();
            labelNewReplyDateDescryption = new Label();
            SuspendLayout();
            // 
            // labelDescription
            // 
            labelDescription.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelDescription.Location = new Point(51, 9);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(251, 54);
            labelDescription.TabIndex = 0;
            labelDescription.Text = "Wpisz ilość dni które chcesz dodać do aktualnej daty";
            labelDescription.TextAlign = ContentAlignment.TopCenter;
            // 
            // buttonSendNewDate
            // 
            buttonSendNewDate.Location = new Point(86, 162);
            buttonSendNewDate.Name = "buttonSendNewDate";
            buttonSendNewDate.Size = new Size(181, 58);
            buttonSendNewDate.TabIndex = 1;
            buttonSendNewDate.Text = "Wprowadź nową datę";
            buttonSendNewDate.UseVisualStyleBackColor = true;
            buttonSendNewDate.Click += buttonSendNewDate_Click;
            // 
            // labelNewReplyDate
            // 
            labelNewReplyDate.BackColor = SystemColors.InactiveCaption;
            labelNewReplyDate.BorderStyle = BorderStyle.Fixed3D;
            labelNewReplyDate.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelNewReplyDate.Location = new Point(86, 113);
            labelNewReplyDate.Name = "labelNewReplyDate";
            labelNewReplyDate.Size = new Size(181, 34);
            labelNewReplyDate.TabIndex = 2;
            labelNewReplyDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxDaysToAdd
            // 
            textBoxDaysToAdd.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxDaysToAdd.Location = new Point(86, 66);
            textBoxDaysToAdd.Name = "textBoxDaysToAdd";
            textBoxDaysToAdd.Size = new Size(181, 29);
            textBoxDaysToAdd.TabIndex = 3;
            textBoxDaysToAdd.TextAlign = HorizontalAlignment.Center;
            textBoxDaysToAdd.TextChanged += textBoxDaysToAdd_TextChanged;
            textBoxDaysToAdd.KeyPress += textBoxDaysToAdd_KeyPress;
            // 
            // labelDaysDescription
            // 
            labelDaysDescription.Location = new Point(12, 61);
            labelDaysDescription.Name = "labelDaysDescription";
            labelDaysDescription.Size = new Size(68, 41);
            labelDaysDescription.TabIndex = 4;
            labelDaysDescription.Text = "Wpisz ilość dni";
            labelDaysDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelNewReplyDateDescryption
            // 
            labelNewReplyDateDescryption.Location = new Point(12, 111);
            labelNewReplyDateDescryption.Name = "labelNewReplyDateDescryption";
            labelNewReplyDateDescryption.Size = new Size(68, 41);
            labelNewReplyDateDescryption.TabIndex = 5;
            labelNewReplyDateDescryption.Text = "Nowa data";
            labelNewReplyDateDescryption.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SetReplyDate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 232);
            Controls.Add(labelNewReplyDateDescryption);
            Controls.Add(labelDaysDescription);
            Controls.Add(textBoxDaysToAdd);
            Controls.Add(labelNewReplyDate);
            Controls.Add(buttonSendNewDate);
            Controls.Add(labelDescription);
            Name = "SetReplyDate";
            Text = "Wybór daty";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelDescription;
        private Button buttonSendNewDate;
        private Label labelNewReplyDate;
        private TextBox textBoxDaysToAdd;
        private Label labelDaysDescription;
        private Label labelNewReplyDateDescryption;
    }
}