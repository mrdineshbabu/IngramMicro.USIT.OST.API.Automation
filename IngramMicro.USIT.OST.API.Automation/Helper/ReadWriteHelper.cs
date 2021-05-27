//-----------------------------------------------------------------------
// <copyright file="ReadWriteHelper.cs" company="Microsoft Services">
//     Copyright (c) Microsoft Services. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace IngramMicro.USIT.OST.API.Automation
{
    using System;
    using Bytescout.Spreadsheet;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Reflection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Microsoft.Office.Interop.Excel;
    using Worksheet = Microsoft.Office.Interop.Excel.Worksheet;
    using Workbook = Microsoft.Office.Interop.Excel.Workbook;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    using Cell = DocumentFormat.OpenXml.Spreadsheet.Cell;
    using DataTable = System.Data.DataTable;

    public class ReadWriteHelper
    {
        public static object ReadJson(string fileName)
        {
            //JObject o1 = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\"+ fileName));

            // read JSON directly from a file
            using (StreamReader file = File.OpenText(Constants.FilePath + @"\TestData\" + fileName))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject Body = (JObject)JToken.ReadFrom(reader);
                return Body;
            }            
        }

        public static void WriteToJSON(JObject output, string  path)
        {
            //// delete output file if exists already
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (StreamWriter file = File.CreateText(path))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                output.WriteTo(writer);
            }
        }   
        
        public static void ReadFromExcel(string path, string row, string column)
        {
            //string path = "C:\\Users\\usuvad00\\Desktop\\OrderDetailsTestData.xlsx ";

            Application excel = new Application();
            Workbook wb = excel.Workbooks.Open(path);
            Worksheet excelSheet = wb.ActiveSheet;

            //Read the first cell
            string test = excelSheet.Cells[row, column].Value.ToString();

            wb.Close();
        }

        public static string GetCellValue(string fileName, string sheetName, string addressName)
        {
            string value = null;

            // Open the spreadsheet document for read-only access.
            using (SpreadsheetDocument document =
                SpreadsheetDocument.Open(fileName, false))
            {
                // Retrieve a reference to the workbook part.
                WorkbookPart wbPart = document.WorkbookPart;

                // Find the sheet with the supplied name, and then use that 
                // Sheet object to retrieve a reference to the first worksheet.
                Sheet theSheet = wbPart.Workbook.Descendants<Sheet>().
                  Where(s => s.Name == sheetName).FirstOrDefault();

                // Throw an exception if there is no sheet.
                if (theSheet == null)
                {
                    throw new ArgumentException("sheetName");
                }

                // Retrieve a reference to the worksheet part.
                WorksheetPart wsPart =
                    (WorksheetPart)(wbPart.GetPartById(theSheet.Id));

                // Use its Worksheet property to get a reference to the cell 
                // whose address matches the address you supplied.
                Cell theCell = wsPart.Worksheet.Descendants<Cell>().
                  Where(c => c.CellReference == addressName).FirstOrDefault();

                // If the cell does not exist, return an empty string.
                if (theCell.InnerText.Length > 0)
                {
                    value = theCell.InnerText;

                    // If the cell represents an integer number, you are done. 
                    // For dates, this code returns the serialized value that 
                    // represents the date. The code handles strings and 
                    // Booleans individually. For shared strings, the code 
                    // looks up the corresponding value in the shared string 
                    // table. For Booleans, the code converts the value into 
                    // the words TRUE or FALSE.
                    if (theCell.DataType != null)
                    {
                        switch (theCell.DataType.Value)
                        {
                            case CellValues.SharedString:

                                // For shared strings, look up the value in the
                                // shared strings table.
                                var stringTable =
                                    wbPart.GetPartsOfType<SharedStringTablePart>()
                                    .FirstOrDefault();

                                // If the shared string table is missing, something 
                                // is wrong. Return the index that is in
                                // the cell. Otherwise, look up the correct text in 
                                // the table.
                                if (stringTable != null)
                                {
                                    value =
                                        stringTable.SharedStringTable
                                        .ElementAt(int.Parse(value)).InnerText;
                                }
                                break;

                            case CellValues.Boolean:
                                switch (value)
                                {
                                    case "0":
                                        value = "FALSE";
                                        break;
                                    default:
                                        value = "TRUE";
                                        break;
                                }
                                break;
                        }
                    }
                }
            }
            return value;
        }

        /// <summary>
        /// Read Excel Sheets
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <param name="sheetName">sheet name</param>
        /// <param name="hasHeaders">sheet has headers</param>
        /// <returns>data table</returns>
        public static DataTable ReadExcel(string filePath, string sheetName, bool hasHeaders = true)
        {
            // Create new Spreadsheet
            Spreadsheet document = new Spreadsheet();
            document.LoadFromFile(filePath);
            DataTable dataTable = document.ExportToDataTable(sheetName, hasHeaders);
            // Close document
            document.Close();
            return dataTable;
        }

        public static void UpdateTestDataExcel(string path, string sheetName, int row, int col, string data)
        {
            Microsoft.Office.Interop.Excel.Application oXL = null;
            Microsoft.Office.Interop.Excel._Workbook oWB = null;
            Microsoft.Office.Interop.Excel._Worksheet oSheet = null;

            try
            {
                oXL = new Microsoft.Office.Interop.Excel.Application();
                oWB = oXL.Workbooks.Open(path);
                oSheet = String.IsNullOrEmpty(sheetName) ? (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet : (Microsoft.Office.Interop.Excel._Worksheet)oWB.Worksheets[sheetName];

                oSheet.Cells[row, col] = data;

                oWB.Save();

                //MessageBox.Show("Done!");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (oWB != null)
                    oWB.Close();
            }
        }
    }
}