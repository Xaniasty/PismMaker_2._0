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

namespace PismMaker_2._0
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Paint += MainForm_Paint;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

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


        #region Methods

        public void ConsoleWindowWriteLine(string text)
        {
            textBoxConsole.AppendText(text + Environment.NewLine);
        }


        #endregion


        private void buttonPrelookMessange_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                ConsoleWindowWriteLine("Wykonanie tekstu konsoli");
            }
        }
    }
}