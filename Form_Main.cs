using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicArchive
{
    public partial class Form_Main : Form
    {
        public static AppSettings appSettings = new AppSettings();
        public static Class_Database database = new Class_Database();
        public ProjectSettings projectSettings = new ProjectSettings();

        public Form_Main()
        {
            InitializeComponent();

            Text = Text + " - v" + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            notifyIcon1.Text = notifyIcon1.Text + " - v" + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;

            database.ConnectToDB();

            GetProjects();
        }

        private void GetProjects()
        {
            List<GetProjectsResult> getProjectsResult = database.GetProjects();

            comboBox_Projects.DataSource = null;
            comboBox_Projects.Items.Clear();
            List<Object> items = new List<Object>();
            comboBox_Projects.DisplayMember = "Text";
            comboBox_Projects.ValueMember = "Value";

            items.Add(new { Text = "- nichts ausgewählt -", Value = "0" });

            if (getProjectsResult != null)
            {
                foreach (GetProjectsResult result in getProjectsResult)
                {
                    items.Add(new { Text = result.value, Value = result.id.ToString() });
                }
            }

            comboBox_Projects.DataSource = items;
        }

        private void button_PathButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                projectSettings.currentPath = folderBrowserDialog1.SelectedPath;
                textBox_Path.Text = projectSettings.currentPath;
            }
        }

        private void comboBox_Projects_SelectedIndexChanged(object sender, EventArgs e)
        {
            projectSettings.currentProjectId = (int)comboBox_Projects.SelectedValue;
        }

        private void button_SearchPath_Click(object sender, EventArgs e)
        {
            IEnumerable<string> fileList = Directory.EnumerateFiles(textBox_Path.Text, "*.jpg", SearchOption.AllDirectories);

            List<DBPicture> picList = new List<DBPicture>();

            foreach (string file in fileList)
            {
                DBPicture pic = new DBPicture
                {
                    path = Path.GetDirectoryName(file),
                    filename = Path.GetFileName(file),
                    label = "",
                    categories = "",
                    project_id = projectSettings.currentProjectId,
                    thumbnail = ""
                };

                picList.Add(pic);
            }
        }

    }
}
