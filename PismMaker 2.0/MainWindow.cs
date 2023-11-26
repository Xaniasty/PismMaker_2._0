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

        public static string filePathENT = @"C:\Users\Patryk\Desktop\PismMaker 2.0\Excel_pytania\Pytania_ENT.xlsx"; //b�dzie ustalane na postawie klasy User
        public static string filePathCorp = @"C:\Users\Patryk\Desktop\PismMaker 2.0\Excel_pytania\Pytania_CORP.xlsx"; //b�dzie ustalne na podstawie klasy User
        private Dictionary<string, string> excelQuestionsENT;
        private Dictionary<string, string> excelQuestionsCORP;
        private List<string> teamsNames = new List<string>() { "ENT", "CORPO" };
        private Dictionary<string, Dictionary<string, string>> templates;
        private Dictionary<string, Dictionary<string, string>> attachments;
        private List<string> templatesKeys;
        private Dictionary<int, string> questions = new Dictionary<int, string>();
        private int consoleLineNumber = 0;
        private string questionsFieldVariable;
        private DateTime today = DateTime.Today;
        private DateTime replyDate;
        private string temaplatePath;



        Client client;
        PismmakerUser pismmakerUser;

        #endregion


        #region Methods


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

                            // Utw�rz StringBuilder do ��czenia tekstu
                            StringBuilder replacementText = new StringBuilder(property.Value.ToString());

                            // Ustaw maksymaln� d�ugo�� fragmentu tekstu
                            const int maxChunkSize = 32000;

                            // Podziel tekst na mniejsze fragmenty
                            for (int i = 0; i < replacementText.Length; i += maxChunkSize)
                            {
                                int chunkSize = Math.Min(maxChunkSize, replacementText.Length - i);
                                string chunk = replacementText.ToString(i, chunkSize);

                                contentRange.Text = chunk;
                            }
                        }
                    }

                    if (!textFound)
                    {
                        ConsoleWindowWriteLine($"Nie znaleziono tekstu do zast�pienia: {property.Key}");
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

        private void LoadDataIntoComboboxChooseTemplates(Dictionary<string, Dictionary<string, string>> someDictionary)
        {
            comboBoxChooseTemplate.Items.Clear();
            string selectedTeam = comboBoxChooseTeam.Text;


            switch (selectedTeam)
            {
                case "ENT":
                    if (someDictionary.ContainsKey("ENT"))
                    {
                        templatesKeys = new List<string>(someDictionary["ENT"].Keys);
                        comboBoxChooseTemplate.Items.AddRange(templatesKeys.ToArray());
                        comboBoxChooseTemplate.Refresh();
                    }
                    break;

                case "CORPO":
                    if (someDictionary.ContainsKey("CORPO"))
                    {
                        templatesKeys = new List<string>(someDictionary["CORPO"].Keys);
                        comboBoxChooseTemplate.Items.AddRange(templatesKeys.ToArray());
                        comboBoxChooseTemplate.Refresh();
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

        public void EditQuestion(int key, string value)
        {
            questions[key] = value; //aby edytowac dobre pytanie do okna questionSelect musz� przesy�a� odpowiedni klucz
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


        #endregion


        public MainWindow()
        {
            InitializeComponent();
            this.Paint += MainForm_Paint;
            replyDate = today;
            this.textBoxReplyDateDay.Text = replyDate.Day.ToString();
            this.textBoxReplyDateMonth.Text = replyDate.Month.ToString();
            this.textBoxReplyDateYear.Text = replyDate.Year.ToString();
            pismmakerUser = new PismmakerUser("dm52cn", "Bandura, P. (Patryk)", "C7");
            client = new Client();
            templates = pismmakerUser.GetDocxFilesInFolder(pismmakerUser.DesktopTemplatesPath);
            attachments = pismmakerUser.GetDocxFilesInFolder(pismmakerUser.DesktopAttachemntsPath);
            ConsoleWindowWriteLine($"Dzisiejszy dzie�: {today.ToString("dd-MM-yyyy")}");
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LoadDataIntoComboBoxTeamChoose();
            #region odczyt excel pytania
            try
            {
                try
                {
                    ConsoleWindowWriteLine("Tworz� list� pyta� ENT");

                    excelQuestionsENT = ExcelReader.CreateDictFromExcel($@"{pismmakerUser.DesktopQuestionsPath}");
                    ConsoleWindowWriteLine("Zako�czy�em tworzenie listy dla ENT");
                }
                catch (Exception ex)
                {
                    ConsoleWindowWriteLine($"B��d przy odczycie EXCEL ENT {ex}");
                }

                try
                {
                    ConsoleWindowWriteLine("Tworz� list� pyta� CORPO");
                    excelQuestionsCORP = ExcelReader.CreateDictFromExcel(filePathCorp);
                    ConsoleWindowWriteLine("Zako�czy�em tworzenie listy dla CORPO");
                }
                catch (Exception ex)
                {
                    ConsoleWindowWriteLine($"B��d przy odczycie EXCEL CORPO {ex}");
                }


            }
            catch (Exception ex)
            {
                ConsoleWindowWriteLine($"B��d przy odczycie EXCEL {ex}");
            }
            #endregion
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Color darkBlue = Color.FromArgb(0, 0, 128); // Ciemny niebieski
            Color lightBlue = Color.FromArgb(135, 206, 235); // Jasny niebieski
            Color orange = Color.FromArgb(255, 165, 0); //pomara�czowy
            Color deepBlue = Color.FromArgb(70, 130, 180); //b��kitny
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
            for (int i = 0; i < 10; i++)
            {
                ConsoleWindowWriteLine("Wykonanie tekstu konsoli");
            }
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
                    ConsoleWindowWriteLine("Nie ma takiego zespo�u - wybierz inny");
                    MessageBox.Show("Nie ma takiego zespo�u, co� posz�o nie tak");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("B��d przy wybieraniu zespo�u z listy - nie wybrano zespo�u");
                ConsoleWindowWriteLine($"B��d przy wybieraniu zespo�u z listy - nie wybrano zespo�u");
            }
        }

        private void buttonChangeReplyDate_Click(object sender, EventArgs e)
        {
            ConsoleWindowWriteLine("Rozpoczynam zmian� daty");
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
                        ConsoleWindowWriteLine("Nie ma takiego zespo�u - wybierz inny");
                        MessageBox.Show("Nie ma takiego zespo�u, co� posz�o nie tak");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("B��d przy wybieraniu zespo�u z listy - nie wybrano zespo�u");
                ConsoleWindowWriteLine($"B��d przy wybieraniu zespo�u z listy - nie wybrano zespo�u");
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

            ConsoleWindowWriteLine("Usuni�to wybrane pytanie");
        }

        private void buttonDeleteAllQuestions_Click(object sender, EventArgs e)
        {
            questions.Clear();
            RefreshChoosedQuestionsList();
            ConsoleWindowWriteLine("Usuni�to wszystkie pytania");
        }

        private void buttonClientDataMaker_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(textboxClientNumber.Text)) && textboxClientNumber.Text.Length == 10)
            {

                MessageBox.Show($"Pobieram dane klienta {textboxClientNumber.Text}");
                //tutaj kod odpowiedzialny za przypisanie danych klienta z odpowiedniej bazy danych/scrapingu
                //pogl�dowo wymy�lone dane klienta
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
                ConsoleWindowWriteLine("Nieprawid�owy numer klienta - mniej lub wi�cej ni� 10 cyfr");
                MessageBox.Show($"Nieprawid�owy numer klienta - mniej lub wi�cej ni� 10 cyfr");
            }
        }

        private void textBoxConsole_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxChooseTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataIntoComboboxChooseTemplates(templates);

        }



        private void buttonCreateMessange_Click(object sender, EventArgs e)
        {
            //temaplatePath
            string selectedTeam = comboBoxChooseTeam.Text;
            string selectedTemplate = comboBoxChooseTemplate.Text;


            if (templates.ContainsKey(selectedTeam))
            {
                Dictionary<string, string> teamDictionary = templates[selectedTeam];

                if (teamDictionary.ContainsKey(selectedTemplate))
                {

                    ConsoleWindowWriteLine($"Tworz� pismo {selectedTemplate}");
                    client.ConnectedString = QuestionVariableCreator(questions);
                    ReplaceTextAndCreateMessage(pismmakerUser, client, teamDictionary, selectedTemplate);

                }
                else
                {
                    MessageBox.Show($"Pusty klucz.");
                    ConsoleWindowWriteLine("Pusty klucz.");
                }
            }
            else
            {
                MessageBox.Show($"Nie wybrano zespo�u.");
                ConsoleWindowWriteLine("Nie wybrano zespo�u.");
            }

        }

        private void comboBoxChooseTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}