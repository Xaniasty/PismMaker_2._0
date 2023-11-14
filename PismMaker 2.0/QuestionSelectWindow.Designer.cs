namespace PismMaker_2._0
{
    partial class QuestionSelectWindow
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
            comboBoxQuestionSelect = new ComboBox();
            textBoxSelectedQuestion = new TextBox();
            buttonQuestionAdd = new Button();
            buttonQuestionEdit = new Button();
            buttonClientDataAdd = new Button();
            SuspendLayout();
            // 
            // comboBoxQuestionSelect
            // 
            comboBoxQuestionSelect.BackColor = SystemColors.Window;
            comboBoxQuestionSelect.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxQuestionSelect.FormattingEnabled = true;
            comboBoxQuestionSelect.Location = new Point(319, 30);
            comboBoxQuestionSelect.Name = "comboBoxQuestionSelect";
            comboBoxQuestionSelect.Size = new Size(519, 33);
            comboBoxQuestionSelect.TabIndex = 2;
            comboBoxQuestionSelect.SelectedIndexChanged += comboBoxQuestionSearch_SelectedIndexChanged;
            // 
            // textBoxSelectedQuestion
            // 
            textBoxSelectedQuestion.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSelectedQuestion.Location = new Point(319, 97);
            textBoxSelectedQuestion.Multiline = true;
            textBoxSelectedQuestion.Name = "textBoxSelectedQuestion";
            textBoxSelectedQuestion.Size = new Size(519, 531);
            textBoxSelectedQuestion.TabIndex = 3;
            textBoxSelectedQuestion.TextChanged += textBoxSelectedQuestion_TextChanged;
            // 
            // buttonQuestionAdd
            // 
            buttonQuestionAdd.Location = new Point(81, 97);
            buttonQuestionAdd.Name = "buttonQuestionAdd";
            buttonQuestionAdd.Size = new Size(143, 53);
            buttonQuestionAdd.TabIndex = 4;
            buttonQuestionAdd.Text = "Dodaj pytanie do listy";
            buttonQuestionAdd.UseVisualStyleBackColor = true;
            buttonQuestionAdd.Click += buttonQuestionAdd_Click;
            // 
            // buttonQuestionEdit
            // 
            buttonQuestionEdit.Location = new Point(81, 180);
            buttonQuestionEdit.Name = "buttonQuestionEdit";
            buttonQuestionEdit.Size = new Size(143, 53);
            buttonQuestionEdit.TabIndex = 5;
            buttonQuestionEdit.Text = "Edytuj pytanie";
            buttonQuestionEdit.UseVisualStyleBackColor = true;
            buttonQuestionEdit.Click += buttonQuestionEdit_Click;
            // 
            // buttonClientDataAdd
            // 
            buttonClientDataAdd.Location = new Point(81, 268);
            buttonClientDataAdd.Name = "buttonClientDataAdd";
            buttonClientDataAdd.Size = new Size(143, 53);
            buttonClientDataAdd.TabIndex = 6;
            buttonClientDataAdd.Text = "Wstaw dane klienta";
            buttonClientDataAdd.UseVisualStyleBackColor = true;
            buttonClientDataAdd.Click += buttonClientDataAdd_Click;
            // 
            // QuestionSelectWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(873, 674);
            Controls.Add(buttonClientDataAdd);
            Controls.Add(buttonQuestionEdit);
            Controls.Add(buttonQuestionAdd);
            Controls.Add(comboBoxQuestionSelect);
            Controls.Add(textBoxSelectedQuestion);
            Name = "QuestionSelectWindow";
            Load += QuestionSelectWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxQuestionSelect;
        private TextBox textBoxSelectedQuestion;
        private Button buttonQuestionAdd;
        private Button buttonQuestionEdit;
        private Button buttonClientDataAdd;
    }
}