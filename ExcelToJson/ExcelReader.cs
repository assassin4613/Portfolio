using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json.Linq;

namespace ExcelToJson
{
    class ExcelReader
    {
        public Excel.Application Application;
        public Excel.Workbooks Workbooks;
        public Excel.Workbook Workbook;
        public Excel.Sheets Sheets;
        public Excel.Worksheet Sheet;
        public Excel.Range Cells;
        public Excel.Range Range;

        private const string TYPE_LIST = "[]";
        private const string TYPE_ENUM = "enum:";

        public ExcelReader()
        {
            this.Application = new Excel.Application();
            this.Workbooks = Application.Workbooks;
            this.Workbook = Application.Workbooks.Add(FileManager.FilePath);
            this.Sheets = this.Workbook.Worksheets;
            this.Sheet = Workbook.Worksheets.Item[1];
            this.Cells = (Excel.Range)Sheet.Cells;
            this.Range = this.Sheet.UsedRange;
        }

        public bool CheckHasType()
        {
            string[] typeArray = { "int", "float", "double", "string", "short", "long", "char", "bool", "uint", "byte"};

            foreach(string type in typeArray)
            {
                if (this.Range.Cells[2, 1].Value.ToString() == type)
                    return true;
            }

            return false;
        }

        public bool CheckHasStringType(int col)
        {
            string[] typeStrArray = { "string", "char" };

            foreach (string type in typeStrArray)
            {
                if (this.Range.Cells[2, col].Value.ToString() == type)
                    return true;
            }

            return false;
        }

        public string CheckHasSpecialType(int col)
        {
            string[] typeSpecialToken = { TYPE_LIST, TYPE_ENUM };

            foreach (string type in typeSpecialToken)
            {
                if (this.Range.Cells[2, col].Value.ToString().Contains(type))
                    return type;
            }

            return string.Empty;
        }

        public JArray GetJsonArray()
        {
            JArray jArray = new JArray();

            List<string> nameList = new List<string>();
            for (int i = 1; i <= Range.Columns.Count; i++)
            {
                nameList.Add(Range.Cells[3, i].Value.ToString());
            }

            int startRow = 4;

            if (this.CheckHasType())
            {
                for (int row = startRow; row <= Range.Rows.Count; row++)
                {
                    JObject jObject = new JObject();
                    for (int col = 1; col <= Range.Columns.Count; col++)
                    {
                        string name = nameList[col - 1];
                        string value = "";

                        string specialType = this.CheckHasSpecialType(col);

                        switch (specialType)
                        {
                            case TYPE_LIST:
                                var sValue = this.GetArrayTypefValue(Range.Cells[row, col].Value.ToString());
                                jObject.Add(name, sValue);
                                break;
                            default:
                                if (Range.Cells[row, col].Value != null)
                                {
                                    value = Range.Cells[row, col].Value.ToString();
                                }
                                else
                                {
                                    value = this.CheckHasStringType(col) ? string.Empty : "-1";
                                }

                                jObject.Add(name, value);
                                break;  
                        }
                    }
                    jArray.Add(jObject);
                }
                return jArray;
            }

            return null;
        }

        private JArray GetArrayTypefValue(string values)
        {
            JArray jArray = new JArray();

            string[] strings = values.Split(',');

            foreach(string str in strings)
            {
                jArray.Add(str);
            }

            return jArray;
        }

        public void Free()
        {
            this.Application.DisplayAlerts = false;
            this.Application.Quit();

            Marshal.ReleaseComObject(this.Range);
            Marshal.ReleaseComObject(this.Cells);
            Marshal.ReleaseComObject(this.Sheet);
            Marshal.ReleaseComObject(this.Sheets);
            Marshal.ReleaseComObject(this.Workbook);
            Marshal.ReleaseComObject(this.Workbooks);
            Marshal.ReleaseComObject(this.Application);
        }
    }
}
