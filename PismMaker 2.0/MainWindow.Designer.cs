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
            comboBoxChooseTeam = new ComboBox();
            comboBoxChooseTemplate = new ComboBox();
            checkBoxMEMO = new CheckBox();
            checkBoxIWA = new CheckBox();
            checkBoxMAIL = new CheckBox();
            listBoxQuestions = new ListBox();
            pictureBox1 = new PictureBox();
            listBoxAttachments = new ListBox();
            buttonClientDataMaker = new Button();
            progressBarClientData = new ProgressBar();
            tableLayoutPanel1 = new TableLayoutPanel();
            textboxClientNumber = new TextBox();
            labelAddress = new Label();
            labelCaseNumber = new Label();
            labelClientName = new Label();
            textBoxClientAddres = new TextBox();
            textBoxCaseNumber = new TextBox();
            textBoxClientName = new TextBox();
            labelClientNumber = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            textBoxReplyDateYear = new TextBox();
            textBoxReplyDateMonth = new TextBox();
            textBoxReplyDateDay = new TextBox();
            labelReplyDate = new Label();
            buttonChangeReplyDate = new Button();
            buttonChooseQuestion = new Button();
            buttonDeleteChoosedQuestion = new Button();
            buttonDeleteAllQuestions = new Button();
            buttonChooseAttachment = new Button();
            buttonDeleteChoosedAttachemnt = new Button();
            buttonDeleteAllAttachments = new Button();
            buttonCreateMessange = new Button();
            buttonPrelookMessange = new Button();
            textBoxConsole = new TextBox();
            buttonChoosedQuestionEdit = new Button();
            comboBoxAttachments = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // labelAppName
            // 
            labelAppName.BackColor = SystemColors.Menu;
            labelAppName.BorderStyle = BorderStyle.Fixed3D;
            labelAppName.FlatStyle = FlatStyle.Popup;
            labelAppName.Font = new Font("Rockwell Extra Bold", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelAppName.ForeColor = Color.OrangeRed;
            labelAppName.Location = new Point(864, 9);
            labelAppName.Name = "labelAppName";
            labelAppName.Size = new Size(223, 88);
            labelAppName.TabIndex = 0;
            labelAppName.Text = "PismMaker v. 2.0";
            labelAppName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelChooseTeam
            // 
            labelChooseTeam.BackColor = SystemColors.AppWorkspace;
            labelChooseTeam.BorderStyle = BorderStyle.Fixed3D;
            labelChooseTeam.Font = new Font("Calibri", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelChooseTeam.Location = new Point(310, 9);
            labelChooseTeam.Name = "labelChooseTeam";
            labelChooseTeam.Size = new Size(550, 40);
            labelChooseTeam.TabIndex = 1;
            labelChooseTeam.Text = "Wybierz zespół:";
            // 
            // labelChooseTemplate
            // 
            labelChooseTemplate.BackColor = SystemColors.ActiveBorder;
            labelChooseTemplate.BorderStyle = BorderStyle.Fixed3D;
            labelChooseTemplate.Font = new Font("Calibri", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelChooseTemplate.Location = new Point(310, 57);
            labelChooseTemplate.Name = "labelChooseTemplate";
            labelChooseTemplate.Size = new Size(550, 40);
            labelChooseTemplate.TabIndex = 2;
            labelChooseTemplate.Text = "Wybór Szablonu:";
            // 
            // labelOptions
            // 
            labelOptions.BackColor = SystemColors.AppWorkspace;
            labelOptions.BorderStyle = BorderStyle.Fixed3D;
            labelOptions.Font = new Font("Calibri", 18F, FontStyle.Bold, GraphicsUnit.Point);
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
            labelClientPanel.Font = new Font("Calibri", 18F, FontStyle.Bold, GraphicsUnit.Point);
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
            labelQuestions.Font = new Font("Calibri", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelQuestions.Location = new Point(310, 312);
            labelQuestions.Name = "labelQuestions";
            labelQuestions.Size = new Size(777, 280);
            labelQuestions.TabIndex = 5;
            labelQuestions.Text = "Wybierz pytania";
            // 
            // labelControlPanel
            // 
            labelControlPanel.BackColor = SystemColors.AppWorkspace;
            labelControlPanel.BorderStyle = BorderStyle.Fixed3D;
            labelControlPanel.Font = new Font("Calibri", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelControlPanel.Location = new Point(12, 312);
            labelControlPanel.Name = "labelControlPanel";
            labelControlPanel.Size = new Size(280, 280);
            labelControlPanel.TabIndex = 6;
            labelControlPanel.Text = "Panel Sterowania";
            // 
            // labelAttachments
            // 
            labelAttachments.BackColor = SystemColors.ActiveBorder;
            labelAttachments.BorderStyle = BorderStyle.Fixed3D;
            labelAttachments.Font = new Font("Calibri", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelAttachments.Location = new Point(310, 603);
            labelAttachments.Name = "labelAttachments";
            labelAttachments.Size = new Size(777, 214);
            labelAttachments.TabIndex = 7;
            labelAttachments.Text = "Załączniki";
            // 
            // comboBoxChooseTeam
            // 
            comboBoxChooseTeam.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxChooseTeam.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxChooseTeam.FormattingEnabled = true;
            comboBoxChooseTeam.Location = new Point(517, 12);
            comboBoxChooseTeam.Name = "comboBoxChooseTeam";
            comboBoxChooseTeam.Size = new Size(333, 29);
            comboBoxChooseTeam.TabIndex = 8;
            comboBoxChooseTeam.SelectedIndexChanged += comboBoxChooseTeam_SelectedIndexChanged;
            // 
            // comboBoxChooseTemplate
            // 
            comboBoxChooseTemplate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxChooseTemplate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxChooseTemplate.FormattingEnabled = true;
            comboBoxChooseTemplate.Location = new Point(517, 61);
            comboBoxChooseTemplate.Name = "comboBoxChooseTemplate";
            comboBoxChooseTemplate.Size = new Size(333, 29);
            comboBoxChooseTemplate.TabIndex = 9;
            comboBoxChooseTemplate.SelectedIndexChanged += comboBoxChooseTemplate_SelectedIndexChanged;
            // 
            // checkBoxMEMO
            // 
            checkBoxMEMO.BackColor = SystemColors.Menu;
            checkBoxMEMO.FlatAppearance.BorderColor = Color.White;
            checkBoxMEMO.FlatStyle = FlatStyle.Popup;
            checkBoxMEMO.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxMEMO.Location = new Point(34, 48);
            checkBoxMEMO.Name = "checkBoxMEMO";
            checkBoxMEMO.Size = new Size(211, 49);
            checkBoxMEMO.TabIndex = 10;
            checkBoxMEMO.Text = "Stwórz memo";
            checkBoxMEMO.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxMEMO.UseVisualStyleBackColor = false;
            checkBoxMEMO.CheckedChanged += checkBoxMEMO_CheckedChanged;
            // 
            // checkBoxIWA
            // 
            checkBoxIWA.BackColor = SystemColors.Menu;
            checkBoxIWA.FlatStyle = FlatStyle.Popup;
            checkBoxIWA.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxIWA.Location = new Point(34, 103);
            checkBoxIWA.Name = "checkBoxIWA";
            checkBoxIWA.Size = new Size(211, 49);
            checkBoxIWA.TabIndex = 11;
            checkBoxIWA.Text = "Komentarz IWA";
            checkBoxIWA.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxIWA.UseVisualStyleBackColor = false;
            // 
            // checkBoxMAIL
            // 
            checkBoxMAIL.BackColor = SystemColors.Menu;
            checkBoxMAIL.FlatStyle = FlatStyle.Popup;
            checkBoxMAIL.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxMAIL.Location = new Point(34, 158);
            checkBoxMAIL.Name = "checkBoxMAIL";
            checkBoxMAIL.Size = new Size(211, 49);
            checkBoxMAIL.TabIndex = 12;
            checkBoxMAIL.Text = "Wyślij e-mail";
            checkBoxMAIL.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxMAIL.UseVisualStyleBackColor = false;
            // 
            // listBoxQuestions
            // 
            listBoxQuestions.FormattingEnabled = true;
            listBoxQuestions.ItemHeight = 15;
            listBoxQuestions.Location = new Point(517, 321);
            listBoxQuestions.Name = "listBoxQuestions";
            listBoxQuestions.Size = new Size(559, 259);
            listBoxQuestions.TabIndex = 14;
            listBoxQuestions.SelectedIndexChanged += listBoxQuestions_SelectedIndexChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 603);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(280, 211);
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // listBoxAttachments
            // 
            listBoxAttachments.FormattingEnabled = true;
            listBoxAttachments.ItemHeight = 15;
            listBoxAttachments.Location = new Point(517, 645);
            listBoxAttachments.Name = "listBoxAttachments";
            listBoxAttachments.Size = new Size(559, 154);
            listBoxAttachments.TabIndex = 16;
            // 
            // buttonClientDataMaker
            // 
            buttonClientDataMaker.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonClientDataMaker.Location = new Point(320, 145);
            buttonClientDataMaker.Name = "buttonClientDataMaker";
            buttonClientDataMaker.Size = new Size(143, 41);
            buttonClientDataMaker.TabIndex = 17;
            buttonClientDataMaker.Text = "Pobierz dane klienta";
            buttonClientDataMaker.UseVisualStyleBackColor = true;
            buttonClientDataMaker.Click += buttonClientDataMaker_Click;
            // 
            // progressBarClientData
            // 
            progressBarClientData.ForeColor = Color.Lime;
            progressBarClientData.Location = new Point(320, 192);
            progressBarClientData.Name = "progressBarClientData";
            progressBarClientData.Size = new Size(143, 23);
            progressBarClientData.TabIndex = 18;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.Controls.Add(textboxClientNumber, 1, 0);
            tableLayoutPanel1.Controls.Add(labelAddress, 0, 3);
            tableLayoutPanel1.Controls.Add(labelCaseNumber, 0, 1);
            tableLayoutPanel1.Controls.Add(labelClientName, 0, 2);
            tableLayoutPanel1.Controls.Add(textBoxClientAddres, 1, 3);
            tableLayoutPanel1.Controls.Add(textBoxCaseNumber, 1, 1);
            tableLayoutPanel1.Controls.Add(textBoxClientName, 1, 2);
            tableLayoutPanel1.Controls.Add(labelClientNumber, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 4);
            tableLayoutPanel1.Controls.Add(labelReplyDate, 0, 4);
            tableLayoutPanel1.Location = new Point(487, 118);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(589, 179);
            tableLayoutPanel1.TabIndex = 19;
            // 
            // textboxClientNumber
            // 
            textboxClientNumber.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            textboxClientNumber.Location = new Point(120, 3);
            textboxClientNumber.Multiline = true;
            textboxClientNumber.Name = "textboxClientNumber";
            textboxClientNumber.Size = new Size(466, 27);
            textboxClientNumber.TabIndex = 5;
            // 
            // labelAddress
            // 
            labelAddress.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelAddress.Location = new Point(3, 105);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(111, 33);
            labelAddress.TabIndex = 2;
            labelAddress.Text = "Adres klienta";
            labelAddress.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelCaseNumber
            // 
            labelCaseNumber.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelCaseNumber.Location = new Point(3, 35);
            labelCaseNumber.Name = "labelCaseNumber";
            labelCaseNumber.Size = new Size(111, 33);
            labelCaseNumber.TabIndex = 3;
            labelCaseNumber.Text = "Nr Sprawy";
            labelCaseNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelClientName
            // 
            labelClientName.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelClientName.Location = new Point(3, 70);
            labelClientName.Name = "labelClientName";
            labelClientName.Size = new Size(111, 33);
            labelClientName.TabIndex = 1;
            labelClientName.Text = "Nazwa klienta";
            labelClientName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxClientAddres
            // 
            textBoxClientAddres.BackColor = SystemColors.InactiveCaption;
            textBoxClientAddres.Enabled = false;
            textBoxClientAddres.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxClientAddres.Location = new Point(120, 108);
            textBoxClientAddres.Multiline = true;
            textBoxClientAddres.Name = "textBoxClientAddres";
            textBoxClientAddres.Size = new Size(466, 27);
            textBoxClientAddres.TabIndex = 7;
            // 
            // textBoxCaseNumber
            // 
            textBoxCaseNumber.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxCaseNumber.Location = new Point(120, 38);
            textBoxCaseNumber.Multiline = true;
            textBoxCaseNumber.Name = "textBoxCaseNumber";
            textBoxCaseNumber.Size = new Size(466, 27);
            textBoxCaseNumber.TabIndex = 8;
            // 
            // textBoxClientName
            // 
            textBoxClientName.BackColor = SystemColors.InactiveCaption;
            textBoxClientName.Enabled = false;
            textBoxClientName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxClientName.Location = new Point(120, 73);
            textBoxClientName.Multiline = true;
            textBoxClientName.Name = "textBoxClientName";
            textBoxClientName.Size = new Size(466, 27);
            textBoxClientName.TabIndex = 6;
            // 
            // labelClientNumber
            // 
            labelClientNumber.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelClientNumber.Location = new Point(3, 0);
            labelClientNumber.Name = "labelClientNumber";
            labelClientNumber.Size = new Size(111, 30);
            labelClientNumber.TabIndex = 0;
            labelClientNumber.Text = "Numer klienta";
            labelClientNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(textBoxReplyDateYear, 2, 0);
            tableLayoutPanel2.Controls.Add(textBoxReplyDateMonth, 1, 0);
            tableLayoutPanel2.Controls.Add(textBoxReplyDateDay, 0, 0);
            tableLayoutPanel2.Location = new Point(120, 143);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(466, 29);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // textBoxReplyDateYear
            // 
            textBoxReplyDateYear.BackColor = SystemColors.InactiveCaption;
            textBoxReplyDateYear.Enabled = false;
            textBoxReplyDateYear.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxReplyDateYear.Location = new Point(235, 3);
            textBoxReplyDateYear.Name = "textBoxReplyDateYear";
            textBoxReplyDateYear.Size = new Size(228, 25);
            textBoxReplyDateYear.TabIndex = 2;
            textBoxReplyDateYear.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxReplyDateMonth
            // 
            textBoxReplyDateMonth.BackColor = SystemColors.InactiveCaption;
            textBoxReplyDateMonth.Enabled = false;
            textBoxReplyDateMonth.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxReplyDateMonth.Location = new Point(119, 3);
            textBoxReplyDateMonth.Name = "textBoxReplyDateMonth";
            textBoxReplyDateMonth.Size = new Size(110, 25);
            textBoxReplyDateMonth.TabIndex = 1;
            textBoxReplyDateMonth.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxReplyDateDay
            // 
            textBoxReplyDateDay.BackColor = SystemColors.InactiveCaption;
            textBoxReplyDateDay.Enabled = false;
            textBoxReplyDateDay.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxReplyDateDay.Location = new Point(3, 3);
            textBoxReplyDateDay.Name = "textBoxReplyDateDay";
            textBoxReplyDateDay.Size = new Size(110, 25);
            textBoxReplyDateDay.TabIndex = 0;
            textBoxReplyDateDay.TextAlign = HorizontalAlignment.Center;
            // 
            // labelReplyDate
            // 
            labelReplyDate.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelReplyDate.Location = new Point(3, 140);
            labelReplyDate.Name = "labelReplyDate";
            labelReplyDate.Size = new Size(111, 39);
            labelReplyDate.TabIndex = 4;
            labelReplyDate.Text = "Data odpowiedzi\r\n(dd-MM-rrrr)";
            labelReplyDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonChangeReplyDate
            // 
            buttonChangeReplyDate.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonChangeReplyDate.Location = new Point(320, 244);
            buttonChangeReplyDate.Name = "buttonChangeReplyDate";
            buttonChangeReplyDate.Size = new Size(143, 41);
            buttonChangeReplyDate.TabIndex = 20;
            buttonChangeReplyDate.Text = "Zmień datę odpowiedzi";
            buttonChangeReplyDate.UseVisualStyleBackColor = true;
            buttonChangeReplyDate.Click += buttonChangeReplyDate_Click;
            // 
            // buttonChooseQuestion
            // 
            buttonChooseQuestion.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonChooseQuestion.Location = new Point(320, 348);
            buttonChooseQuestion.Name = "buttonChooseQuestion";
            buttonChooseQuestion.Size = new Size(143, 41);
            buttonChooseQuestion.TabIndex = 21;
            buttonChooseQuestion.Text = "Wybierz pytanie";
            buttonChooseQuestion.UseVisualStyleBackColor = true;
            buttonChooseQuestion.Click += buttonChooseQuestion_Click;
            // 
            // buttonDeleteChoosedQuestion
            // 
            buttonDeleteChoosedQuestion.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonDeleteChoosedQuestion.Location = new Point(320, 442);
            buttonDeleteChoosedQuestion.Name = "buttonDeleteChoosedQuestion";
            buttonDeleteChoosedQuestion.Size = new Size(143, 41);
            buttonDeleteChoosedQuestion.TabIndex = 22;
            buttonDeleteChoosedQuestion.Text = "Usuń pytanie";
            buttonDeleteChoosedQuestion.UseVisualStyleBackColor = true;
            buttonDeleteChoosedQuestion.Click += buttonDeleteChoosedQuestion_Click;
            // 
            // buttonDeleteAllQuestions
            // 
            buttonDeleteAllQuestions.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonDeleteAllQuestions.Location = new Point(320, 489);
            buttonDeleteAllQuestions.Name = "buttonDeleteAllQuestions";
            buttonDeleteAllQuestions.Size = new Size(143, 41);
            buttonDeleteAllQuestions.TabIndex = 23;
            buttonDeleteAllQuestions.Text = "Usuń wszystkie pytania";
            buttonDeleteAllQuestions.UseVisualStyleBackColor = true;
            buttonDeleteAllQuestions.Click += buttonDeleteAllQuestions_Click;
            // 
            // buttonChooseAttachment
            // 
            buttonChooseAttachment.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonChooseAttachment.Location = new Point(320, 642);
            buttonChooseAttachment.Name = "buttonChooseAttachment";
            buttonChooseAttachment.Size = new Size(143, 41);
            buttonChooseAttachment.TabIndex = 24;
            buttonChooseAttachment.Text = "Dodaj Załącznik";
            buttonChooseAttachment.UseVisualStyleBackColor = true;
            buttonChooseAttachment.Click += buttonChooseAttachment_Click;
            // 
            // buttonDeleteChoosedAttachemnt
            // 
            buttonDeleteChoosedAttachemnt.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonDeleteChoosedAttachemnt.Location = new Point(320, 689);
            buttonDeleteChoosedAttachemnt.Name = "buttonDeleteChoosedAttachemnt";
            buttonDeleteChoosedAttachemnt.Size = new Size(143, 41);
            buttonDeleteChoosedAttachemnt.TabIndex = 25;
            buttonDeleteChoosedAttachemnt.Text = "Usuń załącznik";
            buttonDeleteChoosedAttachemnt.UseVisualStyleBackColor = true;
            buttonDeleteChoosedAttachemnt.Click += buttonDeleteChoosedAttachemnt_Click;
            // 
            // buttonDeleteAllAttachments
            // 
            buttonDeleteAllAttachments.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonDeleteAllAttachments.Location = new Point(320, 736);
            buttonDeleteAllAttachments.Name = "buttonDeleteAllAttachments";
            buttonDeleteAllAttachments.Size = new Size(143, 41);
            buttonDeleteAllAttachments.TabIndex = 26;
            buttonDeleteAllAttachments.Text = "Usuń wszystkie załączniki";
            buttonDeleteAllAttachments.UseVisualStyleBackColor = true;
            buttonDeleteAllAttachments.Click += buttonDeleteAllAttachments_Click;
            // 
            // buttonCreateMessange
            // 
            buttonCreateMessange.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCreateMessange.Location = new Point(82, 348);
            buttonCreateMessange.Name = "buttonCreateMessange";
            buttonCreateMessange.Size = new Size(143, 41);
            buttonCreateMessange.TabIndex = 27;
            buttonCreateMessange.Text = "Stwórz pismo";
            buttonCreateMessange.UseVisualStyleBackColor = true;
            buttonCreateMessange.Click += buttonCreateMessange_Click;
            // 
            // buttonPrelookMessange
            // 
            buttonPrelookMessange.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonPrelookMessange.Location = new Point(82, 395);
            buttonPrelookMessange.Name = "buttonPrelookMessange";
            buttonPrelookMessange.Size = new Size(143, 41);
            buttonPrelookMessange.TabIndex = 28;
            buttonPrelookMessange.Text = "Podglad pisma";
            buttonPrelookMessange.UseVisualStyleBackColor = true;
            buttonPrelookMessange.Click += buttonPrelookMessange_Click;
            // 
            // textBoxConsole
            // 
            textBoxConsole.BackColor = SystemColors.ControlLight;
            textBoxConsole.Location = new Point(21, 442);
            textBoxConsole.Multiline = true;
            textBoxConsole.Name = "textBoxConsole";
            textBoxConsole.ReadOnly = true;
            textBoxConsole.ScrollBars = ScrollBars.Vertical;
            textBoxConsole.Size = new Size(262, 138);
            textBoxConsole.TabIndex = 29;
            textBoxConsole.TextChanged += textBoxConsole_TextChanged;
            // 
            // buttonChoosedQuestionEdit
            // 
            buttonChoosedQuestionEdit.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonChoosedQuestionEdit.Location = new Point(320, 395);
            buttonChoosedQuestionEdit.Name = "buttonChoosedQuestionEdit";
            buttonChoosedQuestionEdit.Size = new Size(143, 41);
            buttonChoosedQuestionEdit.TabIndex = 30;
            buttonChoosedQuestionEdit.Text = "Edytuj pytanie";
            buttonChoosedQuestionEdit.UseVisualStyleBackColor = true;
            buttonChoosedQuestionEdit.Click += buttonChoosedQuestionEdit_Click;
            // 
            // comboBoxAttachments
            // 
            comboBoxAttachments.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAttachments.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxAttachments.FormattingEnabled = true;
            comboBoxAttachments.Location = new Point(517, 610);
            comboBoxAttachments.Name = "comboBoxAttachments";
            comboBoxAttachments.Size = new Size(559, 29);
            comboBoxAttachments.TabIndex = 31;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(1099, 826);
            Controls.Add(comboBoxAttachments);
            Controls.Add(buttonChoosedQuestionEdit);
            Controls.Add(textBoxConsole);
            Controls.Add(buttonPrelookMessange);
            Controls.Add(buttonCreateMessange);
            Controls.Add(buttonDeleteAllAttachments);
            Controls.Add(buttonDeleteChoosedAttachemnt);
            Controls.Add(buttonChooseAttachment);
            Controls.Add(buttonDeleteAllQuestions);
            Controls.Add(buttonDeleteChoosedQuestion);
            Controls.Add(buttonChooseQuestion);
            Controls.Add(buttonChangeReplyDate);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(progressBarClientData);
            Controls.Add(buttonClientDataMaker);
            Controls.Add(listBoxAttachments);
            Controls.Add(pictureBox1);
            Controls.Add(listBoxQuestions);
            Controls.Add(checkBoxMAIL);
            Controls.Add(checkBoxIWA);
            Controls.Add(checkBoxMEMO);
            Controls.Add(comboBoxChooseTemplate);
            Controls.Add(comboBoxChooseTeam);
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private ComboBox comboBoxChooseTeam;
        private ComboBox comboBoxChooseTemplate;
        private CheckBox checkBoxMEMO;
        private CheckBox checkBoxIWA;
        private CheckBox checkBoxMAIL;
        private ListBox listBoxQuestions;
        private PictureBox pictureBox1;
        private ListBox listBoxAttachments;
        private Button buttonClientDataMaker;
        private ProgressBar progressBarClientData;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelClientNumber;
        private Label labelClientName;
        private Label labelAddress;
        private Label labelCaseNumber;
        private Label labelReplyDate;
        private TextBox textboxClientNumber;
        private TextBox textBoxClientAddres;
        private TextBox textBoxCaseNumber;
        private TextBox textBoxClientName;
        private Button buttonChangeReplyDate;
        private Button buttonChooseQuestion;
        private Button buttonDeleteChoosedQuestion;
        private Button buttonDeleteAllQuestions;
        private Button buttonChooseAttachment;
        private Button buttonDeleteChoosedAttachemnt;
        private Button buttonDeleteAllAttachments;
        private Button buttonCreateMessange;
        private Button buttonPrelookMessange;
        private TextBox textBoxConsole;
        private Button buttonChoosedQuestionEdit;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox textBoxReplyDateYear;
        private TextBox textBoxReplyDateMonth;
        private TextBox textBoxReplyDateDay;
        private ComboBox comboBoxAttachments;
    }
}