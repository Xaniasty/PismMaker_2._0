namespace PismMaker_2._0
{
    partial class ChooseClientData
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
            buttonInjectClientData = new Button();
            textBoxClientPropertyValue = new TextBox();
            comboBoxClientProperty = new ComboBox();
            SuspendLayout();
            // 
            // buttonInjectClientData
            // 
            buttonInjectClientData.Location = new Point(74, 344);
            buttonInjectClientData.Margin = new Padding(4, 3, 4, 3);
            buttonInjectClientData.Name = "buttonInjectClientData";
            buttonInjectClientData.Size = new Size(416, 117);
            buttonInjectClientData.TabIndex = 0;
            buttonInjectClientData.Text = "Wstaw dane klienta";
            buttonInjectClientData.UseVisualStyleBackColor = true;
            buttonInjectClientData.Click += buttonInjectKlientData_Click;
            // 
            // textBoxClientPropertyValue
            // 
            textBoxClientPropertyValue.BackColor = SystemColors.InactiveCaption;
            textBoxClientPropertyValue.Location = new Point(74, 80);
            textBoxClientPropertyValue.Margin = new Padding(4, 3, 4, 3);
            textBoxClientPropertyValue.Multiline = true;
            textBoxClientPropertyValue.Name = "textBoxClientPropertyValue";
            textBoxClientPropertyValue.Size = new Size(416, 204);
            textBoxClientPropertyValue.TabIndex = 1;
            // 
            // comboBoxClientProperty
            // 
            comboBoxClientProperty.FormattingEnabled = true;
            comboBoxClientProperty.Location = new Point(74, 48);
            comboBoxClientProperty.Margin = new Padding(4, 3, 4, 3);
            comboBoxClientProperty.Name = "comboBoxClientProperty";
            comboBoxClientProperty.Size = new Size(416, 23);
            comboBoxClientProperty.TabIndex = 2;
            comboBoxClientProperty.SelectedIndexChanged += comboBoxKlientProperty_SelectedIndexChanged;
            // 
            // ChooseClientData
            // 
            AcceptButton = buttonInjectClientData;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OrangeRed;
            ClientSize = new Size(564, 519);
            Controls.Add(comboBoxClientProperty);
            Controls.Add(textBoxClientPropertyValue);
            Controls.Add(buttonInjectClientData);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ChooseClientData";
            Text = "Wstaw dane klienta";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonInjectClientData;
        private TextBox textBoxClientPropertyValue;
        private ComboBox comboBoxClientProperty;
    }
}