using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PismMaker_2._0.Classes
{
    internal class User
    {

        private string corpo_path = ""; //corpo path to folders
        private string ent_path = ""; //ent path to folders

        #region Properties

        public string CK { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public string ExcelPath { get; set; }
        public string FolderPath { get; set; }

        public User(string ck = null, string name = null, string team = null, string excelPath = null, string folderPath = null) 
        {
            CK = string.IsNullOrEmpty(ck) ? "<<ck>>" : ck;
            Name = string.IsNullOrEmpty(name) ? "<<name>>" : name;
            Team = string.IsNullOrEmpty(team) ? "<<team>>" : team;
            ExcelPath = string.IsNullOrEmpty(excelPath) ? "<<excelPath>>" : excelPath;
            FolderPath = string.IsNullOrEmpty(folderPath) ? "<<folderPath>>" : folderPath;

        }
         
        #endregion

    }


}
