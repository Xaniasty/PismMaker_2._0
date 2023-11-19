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
            panelEditorTools = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            buttonToolDotPunkter = new Button();
            labelToolsDescription = new Label();
            panelEditorTools.SuspendLayout();
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
            textBoxSelectedQuestion.BackColor = SystemColors.ScrollBar;
            textBoxSelectedQuestion.Font = new Font("Calibri", 11.25F, FontStyle.Italic, GraphicsUnit.Point);
            textBoxSelectedQuestion.Location = new Point(319, 119);
            textBoxSelectedQuestion.Multiline = true;
            textBoxSelectedQuestion.Name = "textBoxSelectedQuestion";
            textBoxSelectedQuestion.Size = new Size(519, 521);
            textBoxSelectedQuestion.TabIndex = 3;
            textBoxSelectedQuestion.TextChanged += textBoxSelectedQuestion_TextChanged;
            // 
            // buttonQuestionAdd
            // 
            buttonQuestionAdd.Location = new Point(41, 97);
            buttonQuestionAdd.Name = "buttonQuestionAdd";
            buttonQuestionAdd.Size = new Size(143, 53);
            buttonQuestionAdd.TabIndex = 4;
            buttonQuestionAdd.Text = "Dodaj pytanie do listy";
            buttonQuestionAdd.UseVisualStyleBackColor = true;
            buttonQuestionAdd.Click += buttonQuestionAdd_Click;
            // 
            // buttonQuestionEdit
            // 
            buttonQuestionEdit.Location = new Point(41, 174);
            buttonQuestionEdit.Name = "buttonQuestionEdit";
            buttonQuestionEdit.Size = new Size(143, 53);
            buttonQuestionEdit.TabIndex = 5;
            buttonQuestionEdit.Text = "Edytuj pytanie";
            buttonQuestionEdit.UseVisualStyleBackColor = true;
            buttonQuestionEdit.Click += buttonQuestionEdit_Click;
            // 
            // buttonClientDataAdd
            // 
            buttonClientDataAdd.Location = new Point(41, 249);
            buttonClientDataAdd.Name = "buttonClientDataAdd";
            buttonClientDataAdd.Size = new Size(143, 53);
            buttonClientDataAdd.TabIndex = 6;
            buttonClientDataAdd.Text = "Wstaw dane klienta";
            buttonClientDataAdd.UseVisualStyleBackColor = true;
            buttonClientDataAdd.Click += buttonClientDataAdd_Click;
            // 
            // panelEditorTools
            // 
            panelEditorTools.BackColor = Color.Transparent;
            panelEditorTools.Controls.Add(button3);
            panelEditorTools.Controls.Add(button2);
            panelEditorTools.Controls.Add(button1);
            panelEditorTools.Controls.Add(buttonToolDotPunkter);
            panelEditorTools.ImeMode = ImeMode.NoControl;
            panelEditorTools.Location = new Point(322, 69);
            panelEditorTools.Name = "panelEditorTools";
            panelEditorTools.Size = new Size(516, 44);
            panelEditorTools.TabIndex = 7;
            // 
            // button3
            // 
            button3.AutoSize = true;
            button3.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(135, 3);
            button3.Name = "button3";
            button3.Size = new Size(38, 35);
            button3.TabIndex = 10;
            button3.TextAlign = ContentAlignment.TopCenter;
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.AutoSize = true;
            button2.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(91, 3);
            button2.Name = "button2";
            button2.Size = new Size(38, 35);
            button2.TabIndex = 9;
            button2.TextAlign = ContentAlignment.TopCenter;
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(47, 3);
            button1.Name = "button1";
            button1.Size = new Size(38, 35);
            button1.TabIndex = 8;
            button1.TextAlign = ContentAlignment.TopCenter;
            button1.UseVisualStyleBackColor = true;
            // 
            // buttonToolDotPunkter
            // 
            buttonToolDotPunkter.AutoSize = true;
            buttonToolDotPunkter.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonToolDotPunkter.Location = new Point(3, 3);
            buttonToolDotPunkter.Name = "buttonToolDotPunkter";
            buttonToolDotPunkter.Size = new Size(38, 35);
            buttonToolDotPunkter.TabIndex = 0;
            buttonToolDotPunkter.Text = "•";
            buttonToolDotPunkter.TextAlign = ContentAlignment.TopCenter;
            buttonToolDotPunkter.UseVisualStyleBackColor = true;
            buttonToolDotPunkter.Click += buttonToolDotPunkter_Click;
            // 
            // labelToolsDescription
            // 
            labelToolsDescription.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelToolsDescription.Location = new Point(239, 84);
            labelToolsDescription.Name = "labelToolsDescription";
            labelToolsDescription.Size = new Size(80, 23);
            labelToolsDescription.TabIndex = 8;
            labelToolsDescription.Text = "Narzędzia";
            // 
            // QuestionSelectWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(873, 674);
            Controls.Add(labelToolsDescription);
            Controls.Add(panelEditorTools);
            Controls.Add(buttonClientDataAdd);
            Controls.Add(buttonQuestionEdit);
            Controls.Add(buttonQuestionAdd);
            Controls.Add(comboBoxQuestionSelect);
            Controls.Add(textBoxSelectedQuestion);
            Name = "QuestionSelectWindow";
            Load += QuestionSelectWindow_Load;
            panelEditorTools.ResumeLayout(false);
            panelEditorTools.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxQuestionSelect;
        private TextBox textBoxSelectedQuestion;
        private Button buttonQuestionAdd;
        private Button buttonQuestionEdit;
        private Button buttonClientDataAdd;
        private Panel panelEditorTools;
        private Button buttonToolDotPunkter;
        private Button button1;
        private Button button3;
        private Button button2;
        private Label labelToolsDescription;
    }
}