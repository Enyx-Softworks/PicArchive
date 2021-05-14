using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicArchive
{
    public class AppSettings
    {
        public string programDataSource = "";
    }

    public class GetProjectsResult
    {
        public int id = -1;
        public string value = "";
    }

    public class ProjectSettings
    {
        public string currentPath = "";
        public int currentProjectId = -1;
    }

    public class DBPicture
    {
        public string path = "";
        public string filename = "";
        public string label = "";
        public string categories = "";
        public int project_id = -1;
        public string thumbnail = "";
    }
}
