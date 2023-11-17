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
using Microsoft.Office.Interop.Word;

namespace PismMaker_2._0
{
    public partial class MainWindow : Form
    {
        #region Variables & classes

        public static string filePathENT = @"C:\Users\Patryk\Desktop\PismMaker 2.0\Excel_pytania\Pytania_ENT.xlsx"; //bêdzie ustalane na postawie klasy User
        public static string filePathCorp = @"C:\Users\Patryk\Desktop\PismMaker 2.0\Excel_pytania\Pytania_CORP.xlsx"; //bêdzie ustalne na podstawie klasy User
        private Dictionary<string, string> excelQuestionsENT;
        private Dictionary<string, string> excelQuestionsCORP;
        private List<string> teamsNames = new List<string>() { "ENT", "CORP" };
        private string questionsFieldVariable;
        private Dictionary<int, string> questions = new Dictionary<int, string>();
        private int consoleLineNumber = 0;

        Client client;

        #endregion


        #region Methods


        public void ConsoleWindowWriteLine(string text)
        {
            consoleLineNumber++;
            textBoxConsole.AppendText($"krok {consoleLineNumber}: {text} {Environment.NewLine}");
        }

        private void LoadDataIntoComboBoxTeamChoose()
        {
            comboBoxChooseTeam.Items.AddRange(teamsNames.ToArray());
        }


        public void AddQuestion(int key, string value)
        {
            questions.Add(key, value);
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
            client = new Client();
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
                    QuestionSelectWindow questionSelectWindow = new QuestionSelectWindow(this, excelQuestionsENT, questions, ref client);
                    questionSelectWindow.Show();

                }
                else if (comboBoxChooseTeam.SelectedItem.ToString() == "CORP")
                {
                    QuestionSelectWindow questionSelectWindow = new QuestionSelectWindow(this, excelQuestionsCORP, questions, ref client);
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
                client.ClientNumber = textboxClientNumber.Text; //powinien braæ pod uwagê 10 cyfowe numeery trzeba to zaimplementowaæ
                client.PhoneNumber = "123123123";
                client.CaseNumber = textboxClientNumber.Text;


                //wprwoadzenie danych do tabeli
                textBoxClientAddres.Text = client.Address.ToString();
                textBoxClientName.Text = client.Name.ToString();

            }
            else if (string.IsNullOrEmpty(textboxClientNumber.Text))
            {
                MessageBox.Show($"Numer klienta jest pusty!");

            }
            else if (textboxClientNumber.Text.Length < 10 || textboxClientNumber.Text.Length > 10)
            {
                MessageBox.Show($"Nieprawid³owy numer klienta - mniej lub wiêcej ni¿ 10 cyfr");
            }
        }

        private void textBoxConsole_TextChanged(object sender, EventArgs e)
        {

        }
    }
}