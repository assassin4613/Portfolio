using System.IO;
using Newtonsoft.Json.Linq;

namespace ExcelToJson
{
    public class FileManager
    {
        public static string FilePath { get; set; }
        public static string NewFileName { get; set;}
        public static string FileName { get; set; }

        public static void SetNewFileName()
        {
            if (!string.IsNullOrEmpty(FileManager.FilePath))
            {
                string path = FileManager.FilePath.Substring(0, FilePath.LastIndexOf('\\') + 1);

                if (string.IsNullOrEmpty(FileManager.NewFileName))
                {
                    string newName = FilePath.Substring(FilePath.LastIndexOf('\\') + 1, FileName.Split('.')[0].Length) + @".json";
                    NewFileName = path + newName;
                }

                //입력 했을 때.
                else
                {
                    if (NewFileName.Contains(".json"))
                    {
                        NewFileName = path + NewFileName;
                    }
                    else
                    {
                        NewFileName = path + NewFileName + @".json";
                    }
                }
            }
        }

        public static bool IsExist()
        {
            return File.Exists(NewFileName);
        }

        public static void SaveJsonFile(JObject jsonDatas)
        {
            File.WriteAllText(NewFileName, jsonDatas.ToString());
        }
    }
}
