namespace PismMaker_2._0.Classes
{
    internal class PismmakerUser
    {
        #region Properties

        static string excels_path = @"C:\Users\Patryk\Desktop\Pliki Excel i Word";
        static string templates_path = $@"\Pliki Excel i Word\Word\Templatki"; //corpo path to folders
        static string attachents_path = $@"\Pliki Excel i Word\Word\Załączniki"; 
        static string savePath = $@"Pliki Excel i Word\Output";

        public string CK { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public string ExcelPath { get; set; }
        public string DesktopPath { get; set; }
        public string FolderSavePath { get; private set; }
        public string DesktopTemplatesPath { get; private set; }
        public string DesktopAttachemntsPath { get; private set; }
        public string DesktopQuestionsPath { get; private set; }

        public PismmakerUser(string ck = null, string name = null, string team = null)
        {
            CK = string.IsNullOrEmpty(ck) ? "<<ck>>" : ck;
            Name = string.IsNullOrEmpty(name) ? "<<name>>" : name;
            Team = string.IsNullOrEmpty(team) ? "<<team>>" : team;
            DesktopPath = GetDesktopPath();
            DesktopTemplatesPath = $"{DesktopPath}{templates_path}";
            DesktopAttachemntsPath = $"{DesktopPath}{attachents_path}";
            FolderSavePath = $@"{DesktopPath}\{savePath}\{Team}\{CK}\";
            ExcelPath = $@"{excels_path}\{CK}\dm52cn.xlsx";
            DesktopQuestionsPath = $@"{excels_path}\Excel\Pytania_ENT.xlsx";

        }

        #endregion

        public Dictionary<string, Dictionary<string, string>> GetDocxFilesInFolder(string folderPath)
        {
            Dictionary<string, Dictionary<string, string>> groupedFilesDictionary = new Dictionary<string, Dictionary<string, string>>();

            try
            {
                if (Directory.Exists(folderPath))
                {
                    string[] subDirectories = Directory.GetDirectories(folderPath);

                    foreach (var subDirectory in subDirectories)
                    {
                        // Użyj tylko nazwy folderu jako klucza
                        string folderName = Path.GetFileName(subDirectory);

                        Dictionary<string, string> tempFilesDictionary = new Dictionary<string, string>();

                        string[] docxFiles = Directory.GetFiles(subDirectory, "*.docx");
                        foreach (var filePath in docxFiles)
                        {
                            string fileName = Path.GetFileName(filePath);
                            tempFilesDictionary.Add(fileName, filePath);
                        }

                        groupedFilesDictionary.Add(folderName, tempFilesDictionary);
                    }
                }
                else
                {
                    MessageBox.Show("Podana lokalizacja nie istnieje.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}");
            }

            return groupedFilesDictionary;
        }

        private static string GetDesktopPath()
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                return desktopPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
                return null;
            }

        }
    }

}
