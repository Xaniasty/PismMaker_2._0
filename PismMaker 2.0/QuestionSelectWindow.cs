using PismMaker_2._0.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PismMaker_2._0
{
    public partial class QuestionSelectWindow : Form
    {
        #region Variables and methods

        private MainWindow mainForm;
        private Dictionary<string, string> questionsDictionary;
        Dictionary<string, string> klientInfoDict;
        private Dictionary<int, string> questions;
        private Boolean questionToEdit;
        private int selectedQuestionKey;

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

        public QuestionSelectWindow(MainWindow form, Dictionary<string, string> excelQuestions, Dictionary<int, string> questions, ref Client client, int selectedQuestionKey, string selectedQuestionValue, Boolean editQuestion = false)
        {
            InitializeComponent();
            this.Paint += QuestionSelectWindow_Paint;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.mainForm = form;
            this.questions = questions;
            this.questionToEdit = editQuestion;
            this.selectedQuestionKey = selectedQuestionKey;
            this.textBoxSelectedQuestion.Text = selectedQuestionValue;
            this.buttonQuestionAdd.Text = editQuestion ? "Wstaw poprawione pytanie" : "Dodaj pytanie do listy";
            loadDataIntoComboBox(excelQuestions);
            textBoxSelectedQuestion.ReadOnly = true;
            klientInfoDict = ObjectToDictionary(client);

        }


        private void QuestionSelectWindow_Paint(object sender, PaintEventArgs e)
        {
            Color darkBlue = Color.FromArgb(0, 0, 128); // Ciemny niebieski
            Color lightBlue = Color.FromArgb(135, 206, 235); // Jasny niebieski
            Color orange = Color.FromArgb(255, 165, 0); //pomarańczowy
            Color deepBlue = Color.FromArgb(70, 130, 180); //błękitny
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

        private void QuestionSelectWindow_Load(object sender, EventArgs e)
        {

        }

        private void loadDataIntoComboBox(Dictionary<string, string> excelQuestions)
        {
            questionsDictionary = excelQuestions;
            try
            {
                foreach (var item in questionsDictionary.Keys)
                {
                    comboBoxQuestionSelect.Items.Add(item);
                }
            }
            catch (Exception e)
            {
                this.mainForm.ConsoleWindowWriteLine($"Wystąpił błąd przy załadowaniu danych do listy wyboru {e.ToString()}");
            }
        }

        private void comboBoxQuestionSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxQuestionSelect.SelectedItem != null)
                {
                    string selectedKey = comboBoxQuestionSelect.SelectedItem.ToString();
                    if (questionsDictionary.ContainsKey(selectedKey))
                    {
                        string selectedValue = questionsDictionary[selectedKey];
                        textBoxSelectedQuestion.Text = selectedValue;
                        textBoxSelectedQuestion.Focus();
                        textBoxSelectedQuestion.SelectionStart = textBoxSelectedQuestion.Text.Length;
                        comboBoxQuestionSelect.DroppedDown = false;
                    }
                }
                else
                {
                    MessageBox.Show("SelectedItem is null.");
                }
            }
            catch (KeyNotFoundException)
            {
                MessageBox.Show("Nie odnaleziono wyszukanego pytania");
                textBoxSelectedQuestion.Text = "Nie znaleziono pytania";
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion


        private void textBoxSelectedQuestion_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonClientDataAdd_Click(object sender, EventArgs e)
        {
            if (textBoxSelectedQuestion.ReadOnly == true)
            {
                MessageBox.Show("Włącz możliwość edycji pytania, następnie dodaj dane klienta.");
            }
            else if (textBoxSelectedQuestion.ReadOnly == false)
            {

                ChooseClientData chooseClientData = new ChooseClientData(mainForm, klientInfoDict);
                chooseClientData.DataSelected += ChooseClientData_DataSelected;
                chooseClientData.Show();
            }
        }

        private void ChooseClientData_DataSelected(object sender, string selectedData)
        {
            int selectionStart = textBoxSelectedQuestion.SelectionStart;
            string currentText = textBoxSelectedQuestion.Text;
            textBoxSelectedQuestion.Text = currentText.Insert(selectionStart, $" {selectedData}");
            textBoxSelectedQuestion.SelectionStart = textBoxSelectedQuestion.Text.Length;
            this.mainForm.ConsoleWindowWriteLine($"Dodałem dane klienta do pytania: {selectedData}");
        }

        private void buttonQuestionEdit_Click(object sender, EventArgs e)
        {
            if (textBoxSelectedQuestion.ReadOnly == true)
            {
                textBoxSelectedQuestion.ReadOnly = false;
                textBoxSelectedQuestion.BackColor = SystemColors.Window;
                buttonQuestionEdit.Text = "Zablokuj pytanie";
                this.mainForm.ConsoleWindowWriteLine($"Zablokowałem pytanie do edycji");
            }
            else if (textBoxSelectedQuestion.ReadOnly == false)
            {
                textBoxSelectedQuestion.ReadOnly = true;
                buttonQuestionEdit.Text = "Edytuj pytanie";
                textBoxSelectedQuestion.BackColor = SystemColors.ScrollBar;
                this.mainForm.ConsoleWindowWriteLine($"Odblokowałem pytanie do edycji");
            }
        }

        private void buttonQuestionAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (questionToEdit == true) //jeżeli ktoś kliknie edytuj pytanie
                {
                    if (!string.IsNullOrEmpty(textBoxSelectedQuestion.Text))
                    {
                        mainForm.EditQuestion(selectedQuestionKey, textBoxSelectedQuestion.Text);
                        this.mainForm.ConsoleWindowWriteLine($"Edytuje {selectedQuestionKey} pytanie na liście");
                        this.Close();
                    }
                    else
                    {
                        this.mainForm.ConsoleWindowWriteLine($"Nie wprowadzono lub wybrano pytania. Nie dodano pustego ciągu znaków.");
                        MessageBox.Show("Wybierz lub wprowadź treść pytania.");
                    }
                }
                else if (questionToEdit == false) //jeżeli ktoś kliknie dodaj pytanie
                {
                    if (!string.IsNullOrEmpty(textBoxSelectedQuestion.Text))
                    {
                        int newKey = questions.Count + 1;
                        mainForm.AddQuestion(newKey, textBoxSelectedQuestion.Text);
                        this.mainForm.ConsoleWindowWriteLine($"Dodaje {newKey} pytanie do listy");
                        this.Close();
                    }
                    else
                    {
                        this.mainForm.ConsoleWindowWriteLine($"Nie wprowadzono lub wybrano pytania. Nie dodano pustego ciągu znaków.");
                        MessageBox.Show("Wybierz lub wprowadź treść pytania.");
                    }
                }
            }
            catch (Exception ex)
            {
                this.mainForm.ConsoleWindowWriteLine($"Wystąpił błąd: {ex.Message}");
                this.Close();
            }
        }


    }
}
