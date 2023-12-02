using Excel = Microsoft.Office.Interop.Excel;

namespace PismMaker_2._0.Classes
{
    internal class ExcelReader: IDisposable
    {
        private Excel.Application excelApp;
        private Excel.Workbook excelWorkbook;
        private Excel._Worksheet excelWorksheet;
        private Excel.Range excelRange;

        public ExcelReader(string filePath, int sheetNumber)
        {
            excelApp = new Excel.Application();
            excelWorkbook = excelApp.Workbooks.Open(filePath);
            excelWorksheet = excelWorkbook.Worksheets[sheetNumber];
            excelRange = excelWorksheet.UsedRange;
        }

        public Dictionary<string, string> CreateDictFromExcel()
        {
            Dictionary<string, string> dataDict = new Dictionary<string, string>();

            int rowCount = excelRange.Rows.Count;

            for (int i = 1; i <= rowCount; i++)
            {
                try
                {
                    string key = Convert.ToString(excelRange.Cells[i, 1].Value2);
                    string value = Convert.ToString(excelRange.Cells[i, 2].Value2);
                    dataDict.Add(key, value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception Occurred: " + ex.ToString());
                }
            }

            return dataDict;
        }


        public void saveClientDateIntoExcelFile(Dictionary<int, string> messangeData)
        {
            try
            {
                // Znajdź następny dostępny wiersz
                int lastRow = excelWorksheet.Cells[excelWorksheet.Rows.Count, 1].End[Excel.XlDirection.xlUp].Row;
                int newRow = lastRow + 1;

                // Wprowadź dane do określonych kolumn na podstawie kluczy słownika
                foreach (var item in messangeData)
                {
                    int columnNumber = item.Key;
                    string dataValue = item.Value;

                    excelRange.Cells[newRow, columnNumber].Value2 = dataValue;
                }

                excelWorksheet.Cells.WrapText = false;
                excelWorkbook.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił wyjątek podczas wprowadzania danych do arkusza: " + ex.ToString());
            }
        }

        public void Dispose()
        {
            excelWorkbook?.Close();
            excelApp?.Quit();

            ReleaseObject(excelRange);
            ReleaseObject(excelWorksheet);
            ReleaseObject(excelWorkbook);
            ReleaseObject(excelApp);
        }

        private static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred while releasing object: " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }


    }

}
