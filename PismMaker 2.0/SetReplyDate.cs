using PismMaker_2._0.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace PismMaker_2._0
{
    public partial class SetReplyDate : Form
    {

        private MainWindow mainForm;
        private DateTime replyDate;
        


        public SetReplyDate(MainWindow mainForm, ref Client client, DateTime date)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            replyDate = date;


        }

        private void textBoxDaysToAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;

            if (textBox.Text.Length >= 2 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxDaysToAdd_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxDaysToAdd.Text, out int numberOfDays))
            {
                DateTime tempReplyDate = replyDate.AddDays(numberOfDays);
                UpdateLabel(tempReplyDate);
            }
        }

        private void UpdateLabel(DateTime date)
        {
            labelNewReplyDate.Text = date.ToString("dd-MM-yyyy");
        }

        private void buttonSendNewDate_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(labelNewReplyDate.Text, out DateTime newReplyDate))
            {
                mainForm.SetReplyDateValue(newReplyDate);
            }

            this.Close();
        }
    }
}
