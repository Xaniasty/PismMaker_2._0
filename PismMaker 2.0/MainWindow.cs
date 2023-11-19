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


namespace PismMaker_2._0
{
    public partial class MainWindow : Form
    {

        #region Variables & classes

        public static string filePathENT = @"C:\Users\Patryk\Desktop\PismMaker 2.0\Excel_pytania\Pytania_ENT.xlsx"; //bêdzie ustalane na postawie klasy User
        public static string filePathCorp = @"C:\Users\Patryk\Desktop\PismMaker 2.0\Excel_pytania\Pytania_CORP.xlsx"; //bêdzie ustalne na podstawie klasy User
        private Dictionary<string, string> excelQuestionsENT;
        private Dictionary<string, string> excelQuestionsCORP;
        private List<string> teamsNames = new List<string>() { "ENT", "CORPO" };
        private Dictionary<string, Dictionary<string, string>> templates;
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

        public void SetReplyDateValue(DateTime newReplyDate)
        {
            replyDate = newReplyDate;
            this.textBoxReplyDateDay.Text = newReplyDate.Day.ToString();
            this.textBoxReplyDateMonth.Text = newReplyDate.Month.ToString();
            this.textBoxReplyDateYear.Text = newReplyDate.Year.ToString();
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
        #endregion


        public MainWindow()
        {
            InitializeComponent();
            this.Paint += MainForm_Paint;
            replyDate = today;
            this.textBoxReplyDateDay.Text = replyDate.Day.ToString();
            this.textBoxReplyDateMonth.Text = replyDate.Month.ToString();
            this.textBoxReplyDateYear.Text = replyDate.Year.ToString();
            pismmakerUser = new PismmakerUser();
            client = new Client();
            templates = pismmakerUser.GetDocxFilesInFolder(pismmakerUser.DesktopTemplatesPath);
            foreach (var template in templates)
            {
                ConsoleWindowWriteLine($"{template.Key}");

                foreach (var item in template.Value)
                {
                    Console.WriteLine(item);
                }
            }
            ConsoleWindowWriteLine($"Dzisiejszy dzieñ: {today.ToString("dd-MM-yyyy")}");
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
                    excelQuestionsENT = ExcelReader.CreateDictFromExcel(filePathENT);
                    ConsoleWindowWriteLine("Zakoñczy³em tworzenie listy dla ENT");
                }
                catch (Exception ex)
                {
                    ConsoleWindowWriteLine($"B³¹d przy odczycie EXCEL ENT {ex}");
                }

                try
                {
                    ConsoleWindowWriteLine("Tworzê listê pytañ CORPO");
                    excelQuestionsCORP = ExcelReader.CreateDictFromExcel(filePathCorp);
                    ConsoleWindowWriteLine("Zakoñczy³em tworzenie listy dla CORPO");
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
                else if (comboBoxChooseTeam.SelectedItem.ToString() == "CORP")
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
                    else if (comboBoxChooseTeam.SelectedItem.ToString() == "CORP")
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
                textBoxClientAddres.Text = client.Address.ToString();
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
                    string templateValue = teamDictionary[selectedTemplate];
                    MessageBox.Show(templateValue);
                    dynamic wordApp = Activator.CreateInstance(Type.GetTypeFromProgID("Word.Application"));
                    dynamic wordDoc = wordApp.Documents.Open(templateValue);
                    wordApp.Visible = true;

                }
                else
                {
                    MessageBox.Show($"Nie istnieje klucz {selectedTemplate} dla {selectedTeam}.");
                }
            }
            else
            {
                MessageBox.Show($"Nie istnieje klucz {selectedTeam} w s³owniku g³ównym.");
            }

        }
    }
}