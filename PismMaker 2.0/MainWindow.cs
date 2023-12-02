using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;
using System.IO;
using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using PismMaker_2._0.Classes;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection.Emit;
using Microsoft.VisualBasic.ApplicationServices;
using System.DirectoryServices;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.Net.Mail;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using static System.Net.Mime.MediaTypeNames;
using Color = System.Drawing.Color;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace PismMaker_2._0
{
    public partial class MainWindow : Form
    {

        #region Variables & classes

        //public static string filePathENT = @"C:\Users\Patryk\Desktop\PismMaker 2.0\Excel_pytania\Pytania_ENT.xlsx"; //bêdzie ustalane na postawie klasy User
        //public static string filePathCorp = @"C:\Users\Patryk\Desktop\PismMaker 2.0\Excel_pytania\Pytania_CORP.xlsx"; //bêdzie ustalne na podstawie klasy User
        private Dictionary<string, string> excelQuestionsENT;
        private Dictionary<string, string> excelQuestionsCORP;
        private Dictionary<string, Dictionary<string, string>> templates;
        private Dictionary<string, Dictionary<string, string>> attachments;
        private Dictionary<int, string> questions = new Dictionary<int, string>();
        private Dictionary<int, string> questionsStatistic = new Dictionary<int, string>();
        private List<string> teamsNames = new List<string>() { "ENT", "CORPO" };
        private List<string> attachmentsNames = new List<string>();
        private List<string> templatesKeys;
        private int consoleLineNumber = 0;
        private string questionsFieldVariable;
        private string temaplatePath;
        private DateTime today = DateTime.Today;
        private DateTime replyDate;
        private DateTime todayFullTime = DateTime.Now;


        //varables for save data in user excel folders
        private string saveUser;
        private string saveClientNumber;
        private string saveReplyDate;
        private string saveQuestions;
        private string saveStatisticQuestions;
        private int saveNumberOfQuestions;
        private string saveAttatchents;
        private string templateName;
        private string teamName;



        Client client;
        PismmakerUser pismmakerUser;

        #endregion


        #region Methods

        private void CreateDataSaveToExcel()
        {
            saveUser = pismmakerUser.CK;
            saveClientNumber = client.ClientNumber;
            saveReplyDate = client.ReplyDate ;
            saveQuestions = QuestionVariableSaveCreator(questions);
            saveStatisticQuestions = teamName == "ENT" ? GetQuestionStatistic(excelQuestionsENT, questions) : GetQuestionStatistic(excelQuestionsCORP, questions); ;
            saveNumberOfQuestions = questions.Count();
            saveAttatchents = string.Join(";",attachmentsNames);

            Dictionary <int, string> messangeData = new Dictionary<int, string>();

            messangeData.Add(1, saveUser);
            messangeData.Add(2, todayFullTime.ToString("yyyy.MM.dd HH:mm:ss"));
            messangeData.Add(3, saveClientNumber);
            messangeData.Add(4, saveReplyDate);
            messangeData.Add(5, saveQuestions);
            messangeData.Add(6, saveStatisticQuestions);
            messangeData.Add(7, saveNumberOfQuestions.ToString());
            messangeData.Add(8, saveAttatchents);
            messangeData.Add(9, templateName);

            try
            {
                ConsoleWindowWriteLine("Dodajê rekord do Twojej bazy pism");
                using (var excelReader = new ExcelReader(pismmakerUser.excelSaveMessnagesPathCK, 1))
                {
                    excelReader.saveClientDateIntoExcelFile(messangeData);
                    
                    ConsoleWindowWriteLine("Doda³em rekord do Twojej bazy pism");
                }
            }
            catch (Exception ex)
            {
                ConsoleWindowWriteLine($"B³¹d przy odczycie EXCEL ENT {ex}");
            }
        } 

        static string GetQuestionStatistic(Dictionary<string, string> pytania, Dictionary<int, string> pytaniaID)
        {
            List<string> questionStatistic = new List<string>();

            foreach (var kvp in pytaniaID)
            {
                if (pytania.ContainsValue(kvp.Value))
                {
                    string klucz = pytania.FirstOrDefault(x => x.Value == kvp.Value).Key;
                    questionStatistic.Add(klucz);
                }
            }
            return string.Join(";", questionStatistic);
        }



        static Dictionary<string, string> ObjectToDictionary(object obj)
        {

            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            foreach (PropertyInfo property in properties)
            {
                dictionary.Add(property.Name, property.GetValue(obj)?.ToString());
            }

            return dictionary;
        }

        private void CopyAttachemntsToAnotherFolder(PismmakerUser user, List<string> attachemntList)
        {
            try
            {
                if (attachemntList.Count > 0)
                {

                    string fileTargetPath = $"{user.FolderSavePath}";
                    foreach (string attachmentName in attachemntList)
                    {
                        if (this.comboBoxChooseTeam.Text != null)
                        {
                            try
                            {
                                string fileSourcePath = $@"{user.DesktopAttachemntsPath}\{this.comboBoxChooseTeam.Text}\{attachmentName}";
                                string newfileTargetPath = $@"{fileTargetPath}{attachmentName}";
                                File.Copy(fileSourcePath, newfileTargetPath, true);
                                ConsoleWindowWriteLine($"Dodano za³¹cznik {attachmentName} do folderu");
                            }
                            catch (Exception ex)
                            {
                                ConsoleWindowWriteLine($"Wyst¹pi³ b³¹d przy przenoszeniu za³¹czników: {ex.ToString()}");
                            }
                        }
                        else
                        {
                            ConsoleWindowWriteLine($"Nie wybrano zespo³u");
                            MessageBox.Show("Nie wybrano zespo³u");
                        }
                    }
                }
                else
                {
                    ConsoleWindowWriteLine($"Brak wybranych za³¹czników do dodania");
                }
            }
            catch (Exception e)
            {
                ConsoleWindowWriteLine($"B³¹d przy kopiowaniu za³¹cznika nazwa: {e.ToString()}");
            }
        }


        public void SetReplyDateValue(DateTime newReplyDate)
        {
            replyDate = newReplyDate;
            this.textBoxReplyDateDay.Text = newReplyDate.Day.ToString();
            this.textBoxReplyDateMonth.Text = newReplyDate.Month.ToString();
            this.textBoxReplyDateYear.Text = newReplyDate.Year.ToString();
        }


        private void ReplaceTextAndCreateMessage(PismmakerUser user, Client client, Dictionary<string, string> templates, string choosedTemplate)
        {
            var wordApp = new Word.Application();
            wordApp.Visible = false;
            wordApp.ScreenUpdating = false;
            Dictionary<string, string> klientInfoDict;
            string filePath = templates[choosedTemplate];

            klientInfoDict = ObjectToDictionary(client);

            try
            {
                var doc = wordApp.Documents.Open(filePath);

                foreach (var property in klientInfoDict)
                {
                    bool textFound = false;

                    foreach (Word.Range storyRange in doc.StoryRanges)
                    {
                        var contentRange = storyRange.Duplicate;
                        contentRange.Find.ClearFormatting();
                        contentRange.Find.Text = $"<<{property.Key}>>";

                        while (contentRange.Find.Execute())
                        {
                            textFound = true;

                            // Utwórz StringBuilder do ³¹czenia tekstu
                            StringBuilder replacementText = new StringBuilder(property.Value.ToString());

                            // Ustaw maksymaln¹ d³ugoœæ fragmentu tekstu
                            const int maxChunkSize = 32000;

                            // Podziel tekst na mniejsze fragmenty
                            for (int i = 0; i < replacementText.Length; i += maxChunkSize)
                            {
                                int chunkSize = Math.Min(maxChunkSize, replacementText.Length - i);
                                string chunk = replacementText.ToString(i,
                                    chunkSize);

                                contentRange.Text = chunk;
                            }
                        }
                    }

                    if (!textFound)
                    {
                        ConsoleWindowWriteLine($"Nie znaleziono tekstu do zast¹pienia: {property.Key}");
                    }
                }

                // Zapis do pliku
                string newFolderPath = user.FolderSavePath;
                string newFilePathWord = Path.Combine(newFolderPath, "NowyDokument.docx");

                doc.SaveAs2(newFilePathWord, Word.WdSaveFormat.wdFormatDocumentDefault);
                doc.Close();
            }
            finally
            {
                wordApp.ScreenUpdating = true;
                wordApp.Quit();
            }
        }


        public void ConsoleWindowWriteLine(string text)
        {
            consoleLineNumber++;
            textBoxConsole.AppendText($"krok {consoleLineNumber}: {text} {Environment.NewLine}");
        }

        private void LoadDataIntoComboBoxTeamChoose()
        {
            comboBoxChooseTeam.Items.AddRange(teamsNames.ToArray());
        }

        private void LoadDataIntoCombobox(string selectedTeam, System.Windows.Forms.ComboBox comboBox, Dictionary<string, Dictionary<string, string>> someDictionary)
        {
            comboBox.Items.Clear();

            switch (selectedTeam)
            {
                case "ENT":
                    if (someDictionary.ContainsKey("ENT"))
                    {
                        templatesKeys = new List<string>(someDictionary["ENT"].Keys);
                        comboBox.Items.AddRange(templatesKeys.ToArray());
                        comboBox.Refresh();
                    }
                    break;

                case "CORPO":
                    if (someDictionary.ContainsKey("CORPO"))
                    {
                        templatesKeys = new List<string>(someDictionary["CORPO"].Keys);
                        comboBox.Items.AddRange(templatesKeys.ToArray());
                        comboBox.Refresh();
                    }
                    break;

                default:
                    MessageBox.Show("BRAK WYBRANEGO TEAMU");
                    break;
            }
        }


        public void AddQuestion(int key, string value)
        {
            questions.Add(key, value);
            RefreshChoosedQuestionsList();
        }



        public void AddAttachment(string value)
        {
            try
            {
                if (value != null)
                {
                    attachmentsNames.Add(value);
                    ConsoleWindowWriteLine($"Dodaje za³¹cznik o nazwie {value} do listy");
                }
                else
                {
                    ConsoleWindowWriteLine("Nie wybrano za³¹cznika z lity");
                }
            }
            catch (Exception e)
            {
                ConsoleWindowWriteLine($"Wystapi³ b³¹d przy dodawaniu {value} do listy nazwa b³êdu: {e.ToString()}");
            }
            finally
            {
                RefreshAttachmentList();
            }
        }

        public void EditQuestion(int key, string value)
        {
            questions[key] = value; //aby edytowac dobre pytanie do okna questionSelect muszê przesy³aæ odpowiedni klucz
            RefreshChoosedQuestionsList();
        }

        private void RefreshChoosedQuestionsList()
        {
            listBoxQuestions.Items.Clear();

            foreach (var question in questions)
            {
                listBoxQuestions.Items.Add(question.Value);
            }
        }

        private void RefreshAttachmentList()
        {
            listBoxAttachments.Items.Clear();

            foreach (var attachment in attachmentsNames)
            {
                listBoxAttachments.Items.Add(attachment);
            }
        }

        private string QuestionVariableCreator(Dictionary<int, string> someDictionary)
        {

            StringBuilder questionFieldVariable = new StringBuilder();

            foreach (var question in someDictionary)
            {
                questionFieldVariable.AppendLine($"{question.Key}) {question.Value.Trim()}");
                questionFieldVariable.AppendLine();
            }

            return questionFieldVariable.ToString();
        }

        private string QuestionVariableSaveCreator(Dictionary<int, string> someDictionary)
        {
            StringBuilder questionFieldVariable = new StringBuilder();

            foreach (var question in someDictionary)
            {
                questionFieldVariable.AppendLine($"{question.Value.Trim()};");
            }
            return questionFieldVariable.ToString();
        }




        #endregion


        public MainWindow()
        {
            InitializeComponent();
            this.Paint += MainForm_Paint;
            replyDate = today;
            this.textBoxReplyDateDay.Text = replyDate.Day.ToString();
            this.textBoxReplyDateMonth.Text = replyDate.Month.ToString();
            this.textBoxReplyDateYear.Text = replyDate.Year.ToString();
            pismmakerUser = new PismmakerUser("dm52cn", "Bandura, P. (Patryk)", "C7"); //to zamienic na konkretnego usera
            client = new Client();
            templates = pismmakerUser.GetDocxFilesInFolder(pismmakerUser.DesktopTemplatesPath);
            attachments = pismmakerUser.GetDocxFilesInFolder(pismmakerUser.DesktopAttachemntsPath);
            ConsoleWindowWriteLine($"Dzisiejszy dzieñ: {today.ToString("dd.MM.yyyy")}");
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LoadDataIntoComboBoxTeamChoose();

            #region odczyt excel pytania
            try
            {
                try
                {
                    ConsoleWindowWriteLine("Tworzê listê pytañ ENT");
                    using (var excelReader = new ExcelReader(pismmakerUser.DesktopQuestionsPath, 1))
                    {
                        excelQuestionsENT = excelReader.CreateDictFromExcel();
                        ConsoleWindowWriteLine("Zakoñczy³em tworzenie listy dla ENT");
                    }
                }
                catch (Exception ex)
                {
                    ConsoleWindowWriteLine($"B³¹d przy odczycie EXCEL ENT {ex}");
                }

                try
                {
                    ConsoleWindowWriteLine("Tworzê listê pytañ CORPO");
                    using (var excelReader = new ExcelReader(pismmakerUser.DesktopQuestionsPath, 2))
                    {
                        excelQuestionsCORP = excelReader.CreateDictFromExcel();
                        ConsoleWindowWriteLine("Zakoñczy³em tworzenie listy dla CORPO");
                    }
                }
                catch (Exception ex)
                {
                    ConsoleWindowWriteLine($"B³¹d przy odczycie EXCEL CORPO {ex}");
                }


            }
            catch (Exception ex)
            {
                ConsoleWindowWriteLine($"B³¹d przy odczycie EXCEL {ex}");
            }
            #endregion
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Color darkBlue = Color.FromArgb(0, 0, 128); // Ciemny niebieski
            Color lightBlue = Color.FromArgb(135, 206, 235); // Jasny niebieski
            Color orange = Color.FromArgb(255, 165, 0); //pomarañczowy
            Color deepBlue = Color.FromArgb(70, 130, 180); //b³êkitny
            Color black = Color.FromArgb(0, 0, 0); //czarny


            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                darkBlue,
                black,
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }



        #region WindowsForms_Methods

        private void buttonPrelookMessange_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W trakcie prac :)");
        }

        #endregion

        private void buttonChooseQuestion_Click(object sender, EventArgs e)
        {
            ConsoleWindowWriteLine("Rozpoczynam wybieranie pytania");
            try
            {
                if (comboBoxChooseTeam.SelectedItem.ToString() == "ENT")
                {
                    QuestionSelectWindow questionSelectWindow = new QuestionSelectWindow(this, excelQuestionsENT, questions, ref client, 0, string.Empty);
                    questionSelectWindow.Show();

                }
                else if (comboBoxChooseTeam.SelectedItem.ToString() == "CORPO")
                {
                    QuestionSelectWindow questionSelectWindow = new QuestionSelectWindow(this, excelQuestionsCORP, questions, ref client, 0, string.Empty);
                    questionSelectWindow.Show();
                }
                else
                {
                    ConsoleWindowWriteLine("Nie ma takiego zespo³u - wybierz inny");
                    MessageBox.Show("Nie ma takiego zespo³u, coœ posz³o nie tak");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d przy wybieraniu zespo³u z listy - nie wybrano zespo³u");
                ConsoleWindowWriteLine($"B³¹d przy wybieraniu zespo³u z listy - nie wybrano zespo³u");
            }
        }

        private void buttonChangeReplyDate_Click(object sender, EventArgs e)
        {
            ConsoleWindowWriteLine("Rozpoczynam zmianê daty");
            SetReplyDate setReplyDateWindow = new SetReplyDate(this, ref client, replyDate);
            setReplyDateWindow.Show();
        }



        private void buttonChoosedQuestionEdit_Click(object sender, EventArgs e)
        {
            ConsoleWindowWriteLine("Rozpoczynam edytowanie wybranego pytania z listy");
            try
            {
                bool editQuestionFlag = true;

                if (listBoxQuestions.SelectedIndex != -1)
                {

                    int selectedIndex = listBoxQuestions.SelectedIndex;
                    int keyInDict = selectedIndex + 1;
                    string valueInDict = questions[keyInDict];

                    if (comboBoxChooseTeam.SelectedItem.ToString() == "ENT")
                    {
                        QuestionSelectWindow questionSelectWindow = new QuestionSelectWindow(this, excelQuestionsENT, questions, ref client, keyInDict, valueInDict, editQuestionFlag);
                        questionSelectWindow.Show();
                    }
                    else if (comboBoxChooseTeam.SelectedItem.ToString() == "CORPO")
                    {
                        QuestionSelectWindow questionSelectWindow = new QuestionSelectWindow(this, excelQuestionsCORP, questions, ref client, keyInDict, valueInDict, editQuestionFlag);
                        questionSelectWindow.Show();
                    }
                    else
                    {
                        ConsoleWindowWriteLine("Nie ma takiego zespo³u - wybierz inny");
                        MessageBox.Show("Nie ma takiego zespo³u, coœ posz³o nie tak");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d przy wybieraniu zespo³u z listy - nie wybrano zespo³u");
                ConsoleWindowWriteLine($"B³¹d przy wybieraniu zespo³u z listy - nie wybrano zespo³u");
            }

        }

        private void buttonDeleteChoosedQuestion_Click(object sender, EventArgs e)
        {
            if (listBoxQuestions.SelectedIndex != -1)
            {
                int selectedIndex = listBoxQuestions.SelectedIndex;
                int keyToRemove = selectedIndex + 1;
                listBoxQuestions.Items.RemoveAt(selectedIndex);

                if (questions.ContainsKey(keyToRemove))
                {
                    questions.Remove(keyToRemove);
                    Dictionary<int, string> newQuestions = new Dictionary<int, string>();
                    int newKey = 1;

                    foreach (var question in questions)
                    {
                        newQuestions[newKey++] = question.Value;
                    }

                    questions = newQuestions;
                }
            }

            ConsoleWindowWriteLine("Usuniêto wybrane pytanie");
        }

        private void buttonDeleteAllQuestions_Click(object sender, EventArgs e)
        {
            questions.Clear();
            RefreshChoosedQuestionsList();
            ConsoleWindowWriteLine("Usuniêto wszystkie pytania");
        }

        private void buttonDeleteChoosedAttachemnt_Click(object sender, EventArgs e)
        {
            if (listBoxAttachments.SelectedIndex != -1)
            {
                int selectedIndex = listBoxAttachments.SelectedIndex;
                listBoxAttachments.Items.RemoveAt(selectedIndex);
                attachmentsNames.RemoveAt(selectedIndex);


            }
            ConsoleWindowWriteLine("Usuniêto wybrany za³¹cznik");
        }

        private void buttonDeleteAllAttachments_Click(object sender, EventArgs e)
        {
            attachmentsNames.Clear();
            RefreshAttachmentList();
            ConsoleWindowWriteLine("Usuniêto wszystkie za³¹czniki");
        }

        private void buttonClientDataMaker_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(textboxClientNumber.Text)) && textboxClientNumber.Text.Length == 10)
            {

                MessageBox.Show($"Pobieram dane klienta {textboxClientNumber.Text}");
                //tutaj kod odpowiedzialny za przypisanie danych klienta z odpowiedniej bazy danych/scrapingu
                //pogl¹dowo wymyœlone dane klienta
                client.Name = "Jan Kowalski";
                client.ClientNumber = textboxClientNumber.Text;
                client.PhoneNumber = "123123123";
                client.CaseNumber = textboxClientNumber.Text;


                //wprwoadzenie danych do tabeli
                if (string.IsNullOrEmpty(client.Address2ndPage))
                {
                    textBoxClientAddres.Text = client.Address1stPage.ToString();
                }
                else
                {
                    textBoxClientAddres.Text = client.Address2ndPage.ToString();
                }

                textBoxClientName.Text = client.Name.ToString();

            }
            else if (string.IsNullOrEmpty(textboxClientNumber.Text))
            {
                ConsoleWindowWriteLine("Numer klienta pusty - wpisz numer w odpowiednie pole");
                MessageBox.Show($"Numer klienta jest pusty!");

            }
            else if (textboxClientNumber.Text.Length < 10 || textboxClientNumber.Text.Length > 10)
            {
                ConsoleWindowWriteLine("Nieprawid³owy numer klienta - mniej lub wiêcej ni¿ 10 cyfr");
                MessageBox.Show($"Nieprawid³owy numer klienta - mniej lub wiêcej ni¿ 10 cyfr");
            }
        }

        private void textBoxConsole_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxChooseTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataIntoCombobox(this.comboBoxChooseTeam.Text, this.comboBoxChooseTemplate, templates);
            LoadDataIntoCombobox(this.comboBoxChooseTeam.Text, this.comboBoxAttachments, attachments);
            teamName = comboBoxChooseTeam.Text;

        }



        private void buttonCreateMessange_Click(object sender, EventArgs e)
        {
            //temaplatePath
            string selectedTeam = comboBoxChooseTeam.Text;
            string selectedTemplate = comboBoxChooseTemplate.Text;
            if (listBoxQuestions.Items.Count > 0)
            {
                if (templates.ContainsKey(selectedTeam))
                {
                    Dictionary<string, string> teamDictionary = templates[selectedTeam];

                    if (teamDictionary.ContainsKey(selectedTemplate))
                    {
                        if (attachmentsNames.Count <= 0)
                        {
                            DialogResult result = MessageBox.Show("Nie doda³eœ za³¹czników" +
                                " czy napewno chcesz kontynuowaæ?", "Wybierz opcje", MessageBoxButtons.OKCancel);

                            if (result == DialogResult.OK)
                            {
                                ConsoleWindowWriteLine($"Tworzê pismo {selectedTemplate}");
                                client.ConnectedString = QuestionVariableCreator(questions);
                                ReplaceTextAndCreateMessage(pismmakerUser, client, teamDictionary, selectedTemplate);
                                CopyAttachemntsToAnotherFolder(pismmakerUser, attachmentsNames);
                                CreateDataSaveToExcel();

                                ConsoleWindowWriteLine("Zakoñczono pozytywnie tworzenie pisma");
                                MessageBox.Show("Koniec - pismo jest w folderze klienta");
                            }
                            else if (result == DialogResult.Cancel)
                            {
                                ConsoleWindowWriteLine("Przerwano akcje tworzenia pisma.");
                                MessageBox.Show("Przerwano akcje.");
                            }
                        }
                        else
                        {
                            try
                            {
                                ConsoleWindowWriteLine($"Tworzê pismo {selectedTemplate}");
                                client.ConnectedString = QuestionVariableCreator(questions);
                                ReplaceTextAndCreateMessage(pismmakerUser, client, teamDictionary, selectedTemplate);
                                CopyAttachemntsToAnotherFolder(pismmakerUser, attachmentsNames);
                                CreateDataSaveToExcel();

                                ConsoleWindowWriteLine("Zakoñczono pozytywnie tworzenie pisma");
                                MessageBox.Show("Koniec - pismo jest w folderze klienta");
                            }
                            catch (Exception ex)
                            {
                                ConsoleWindowWriteLine($"B³¹d przy tworzeniu pisma lub kopiowaniu za³¹cznika: {ex.ToString}");
                                MessageBox.Show("Przerwano akcje.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Nie wybrano szablonu.");
                        ConsoleWindowWriteLine("Nie wybrano szablonu - klucz pusty.");
                    }
                }
                else
                {
                    MessageBox.Show($"Nie wybrano zespo³u.");
                    ConsoleWindowWriteLine("Nie wybrano zespo³u.");
                }
            }
            else
            {
                MessageBox.Show("Nie mo¿na stworzyæ pisma bez pytañ.");
                ConsoleWindowWriteLine("B³¹d - nie wybrano pytañ");
            }
        }

        private void comboBoxChooseTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            templateName = comboBoxChooseTemplate.Text;
        }

        private void buttonChooseAttachment_Click(object sender, EventArgs e)
        {
            AddAttachment(comboBoxAttachments.Text);
        }


        private void listBoxQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxMEMO_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}