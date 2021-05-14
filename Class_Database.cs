using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicArchive
{
    public class Class_Database
    {
        public void ConnectToDB()
        {
            if (PicArchive.Properties.Settings.Default.DatabasePath != "" && File.Exists(Properties.Settings.Default.DatabasePath))
            {
                // Database exists

                Form_Main.appSettings.programDataSource = "Data Source=" + Properties.Settings.Default["DatabasePath"].ToString() + ";Version=3";

                using (SQLiteConnection db = new SQLiteConnection(Form_Main.appSettings.programDataSource))
                {
                    db.Open();

                    using (SQLiteCommand selectCommand = new SQLiteCommand(db))
                    {
                        selectCommand.CommandText = "SELECT * FROM settings";

                        using (SQLiteDataReader reader = selectCommand.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                reader.Read();

                                //AppSettings.tempFolder = !reader.IsDBNull(reader.GetOrdinal("temp_folder")) ? reader.GetString(reader.GetOrdinal("temp_folder")) : "";
                                //if (AppSettings.tempFolder == "")
                                //{
                                //    AppSettings.tempFolder = Path.Combine(Application.StartupPath, "Temp");
                                //}

                                //if (!Directory.Exists(AppSettings.tempFolder))
                                //    Directory.CreateDirectory(AppSettings.tempFolder);

                                //AppSettings.jobsFolder = !reader.IsDBNull(reader.GetOrdinal("jobs_folder")) ? reader.GetString(reader.GetOrdinal("jobs_folder")) : "";
                                //AppSettings.assetsFolder = !reader.IsDBNull(reader.GetOrdinal("assets_folder")) ? reader.GetString(reader.GetOrdinal("assets_folder")) : "";
                                //AppSettings.outputFolder = !reader.IsDBNull(reader.GetOrdinal("output_folder")) ? reader.GetString(reader.GetOrdinal("output_folder")) : "";
                                //AppSettings.emptyTempFolder = !reader.IsDBNull(reader.GetOrdinal("empty_temp_folder")) ? (reader.GetInt16(reader.GetOrdinal("empty_temp_folder")) == 1 ? true : false) : false;
                                //AppSettings.refreshRate = !reader.IsDBNull(reader.GetOrdinal("refreshrate")) ? reader.GetInt16(reader.GetOrdinal("refreshrate")) : 10;
                                //AppSettings.archiveTimespan = !reader.IsDBNull(reader.GetOrdinal("archive_timespan")) ? reader.GetInt16(reader.GetOrdinal("archive_timespan")) : 30;
                                //AppSettings.importDatabasePath = !reader.IsDBNull(reader.GetOrdinal("import_database_path")) ? reader.GetString(reader.GetOrdinal("import_database_path")) : Path.Combine(Application.StartupPath, "pdfmailer_create_imports.sqlite");
                                //AppSettings.importDataSource = "Data Source=" + AppSettings.importDatabasePath + ";Version=3";
                            }
                        }

                    }
                }
            }
            else
            {
                // Database does not exist

                MessageBox.Show("Die Programmdatenbank wurde nicht gefunden.\r\n\r\nGeben Sie diese im nachfolgenden Dialog an und starten Sie das Programm neu.", "ACHTUNG", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Form_SelectDatabase dialogDatabase = new Form_SelectDatabase();
                dialogDatabase.ShowDialog();

                MessageBox.Show("Bitte Programm neu starten.", "ACHTUNG", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Force application to close
                Environment.Exit(0);
            }
        }

        public List<GetProjectsResult> GetProjects()
        {
            try
            {
                List<GetProjectsResult> result = new List<GetProjectsResult>();

                using (SQLiteConnection db = new SQLiteConnection(Form_Main.appSettings.programDataSource))
                {

                    db.Open();

                    SQLiteCommand selectCommand = new SQLiteCommand("SELECT * FROM Projects", db);
                    SQLiteDataReader query = selectCommand.ExecuteReader();

                    while (query.Read())
                    {
                        GetProjectsResult gpResult = new GetProjectsResult
                        {
                            id = query.GetInt32(query.GetOrdinal("id")),
                            value = query.GetString(query.GetOrdinal("label"))
                        };

                        result.Add(gpResult);
                    }

                    db.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void SaveImageToDatabase(List<DBPicture> pictureList, bool batchInsert = true)
        {
            if (pictureList != null)
            {
                using (SQLiteConnection db = new SQLiteConnection(Form_Main.appSettings.programDataSource))
                {

                    db.Open();

                    using (SQLiteTransaction transaction = db.BeginTransaction())
                    {
                        try
                        {
                            foreach (DBPicture picture in pictureList)
                            {
                                string updateString = "INSERT INTO Pictures";
                                updateString += "(path, filename, label, categories, project_id, thumbnail)";
                                updateString += "VALUES ";
                                updateString += "(";
                                updateString += picture.path + ", ";
                                updateString += picture.filename + ", ";
                                updateString += picture.label + ", ";
                                updateString += picture.categories + ", ";
                                updateString += picture.project_id.ToString() + ", ";
                                updateString += picture.thumbnail + ", ";
                                updateString += ")";

                                SQLiteCommand updateCommand = new SQLiteCommand(updateString, db);
                            }

                            transaction.Commit();

                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                        }
                    }

                    db.Close();

                }
            }
        }

    }
}
