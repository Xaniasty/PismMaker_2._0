using Excel = Microsoft.Office.Interop.Excel;

namespace PismMaker_2._0.Classes
{
    internal class ExcelReader
    {

        public static Dictionary<string, string> CreateDictFromExcel(string filePath)
        {
            Dictionary<string, string> dataDict = new Dictionary<string, string>();
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(filePath);
            Excel._Worksheet excelWorksheet = excelWorkbook.Worksheets[1];
            Excel.Range excelRange = excelWorksheet.UsedRange;

            int rowCount = excelRange.Rows.Count;
            int colCOunt = excelRange.Columns.Count;


            for (int i = 1; i <= rowCount; i++)
            {
                try
                {
                    string key = excelRange.Cells[i, 1].Value2.ToString();
                    string value = excelRange.Cells[i, 2].Value2.ToString();
                    dataDict.Add(key, value);
                }
                catch
                {
                    string key = excelRange.Cells[i, 1].Value2;
                    string value = excelRange.Cells[i, 2].Value2;
                    dataDict.Add(key, value);
                }


            }

            excelWorkbook.Close();
            excelApp.Quit();

            ReleaseObject(excelRange);
            ReleaseObject(excelWorksheet);
            ReleaseObject(excelWorkbook);
            ReleaseObject(excelApp);

            return dataDict;
        }

        private static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }


    }
}
