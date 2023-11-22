using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PismMaker_2._0
{
    public partial class ChooseClientData : Form
    {
        private MainWindow mainForm;
        Dictionary<string, string> newKlientProperty;
        public event EventHandler<string> DataSelected;

        public ChooseClientData(MainWindow form, Dictionary<string, string> klientProperty) : base()
        {
            InitializeComponent();
            loadDataIntoComboBox(klientProperty);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.mainForm = form;

        }


        private void loadDataIntoComboBox(Dictionary<string, string> klientProperty)
        {
            newKlientProperty = klientProperty;
            try
            {
                foreach (var item in klientProperty.Keys)
                {
                    comboBoxClientProperty.Items.Add(item);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        private void comboBoxKlientProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxClientProperty.SelectedItem != null)
                {
                    string selectedKey = comboBoxClientProperty.SelectedItem.ToString();
                    if (newKlientProperty.ContainsKey(selectedKey))
                    {
                        string selectedValue = newKlientProperty[selectedKey];
                        textBoxClientPropertyValue.Text = selectedValue;
                        textBoxClientPropertyValue.Focus();
                        textBoxClientPropertyValue.SelectionStart = textBoxClientPropertyValue.Text.Length;
                        comboBoxClientProperty.DroppedDown = false;
                    }
                }
                else
                {
                    MessageBox.Show("SelectedItem is null.");
                }
            }
            catch (KeyNotFoundException)
            {
                MessageBox.Show("Nie odnaleziono wyszukiwanej wartości");
                textBoxClientPropertyValue.Text = "Nie znaleziono pytania";
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void buttonInjectKlientData_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxClientProperty.SelectedItem != null)
                {
                    string selectedKey = comboBoxClientProperty.SelectedItem.ToString();
                    if (newKlientProperty.ContainsKey(selectedKey))
                    {
                        string selectedKeyValue = newKlientProperty[selectedKey];
                        DataSelected?.Invoke(this, selectedKeyValue);
                        this.mainForm.ConsoleWindowWriteLine($"Dodaję do pytania dane klienta o nazwie: {selectedKey}");
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("wybrane dane sa puste");
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                MessageBox.Show("Nie odnaleziono wyszukiwanej wartości");
                textBoxClientPropertyValue.Text = "Nie znaleziono pytania";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
