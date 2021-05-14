using System;
using System.Windows.Forms;

namespace PicArchive
{
    public partial class Form_SelectDatabase : Form
    {
        /// <summary>
        /// Form initialization
        /// </summary>
        public Form_SelectDatabase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Click event on selecting the application database path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_SelectDatabasePath_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.StartupPath;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_DatabasePath.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Click event on saving the selected application database path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Ok_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DatabasePath = textBox_DatabasePath.Text;
            Properties.Settings.Default.Save();
        }
    }
}
