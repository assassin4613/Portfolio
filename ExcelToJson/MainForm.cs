using System;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace ExcelToJson
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void FindPathButtonClick(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();

            string pathName = dialog.FileName;
            string fileName = dialog.SafeFileName;

            if(!string.IsNullOrEmpty(pathName))
            {
                FileManager.FilePath = pathName;
                FileManager.FileName = fileName;
                this.FilePathTextBox.Text = pathName;
                this.ResultTextBox.Text += ("변환할 파일 : " + pathName);
                this.ResultTextBox.Text += Environment.NewLine;
            }
        }

        private void ConvertButtonClick(object sender, EventArgs e) 
        {
            if(string.IsNullOrEmpty(FileManager.FilePath))
            {
                ResultTextBox.Text += ("파일을 선택해야 합니다." + Environment.NewLine);
                return;
            }
            else
            {
                FileManager.NewFileName = this.NewFileTexBox.Text;
                FileManager.SetNewFileName();
            }

            this.ResultTextBox.Text += ("저장될 파일 : " + FileManager.NewFileName);

            if(FileManager.IsExist())
            {
                if(MessageBox.Show("파일이 이미 존재합니다 덮어쓸까요?", "미리 백업 부탁드려요!!", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                {
                    this.ResultTextBox.Clear();
                    this.ResultTextBox.Text += ("파일명을 다시 입력해 주세요." + Environment.NewLine);
                    return;
                }
            }

            this.ResultTextBox.Text += Environment.NewLine;
            this.ResultTextBox.Text += ("변환을 시작합니다================" + Environment.NewLine);

            ExcelReader excelReader = new ExcelReader();
            this.ResultTextBox.Text = (string.Format("변수 갯수 : {0}", excelReader.Range.Columns.Count) + Environment.NewLine);

            JArray dataJArray = excelReader.GetJsonArray();

            if (dataJArray == null)
            {
                if (MessageBox.Show("변환 실패 : 테이블 자료형 형식이 잘못되었습니다.", "툴을 종료합니다!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    excelReader.Free();
                    Application.Exit();
                }
            }
            else
            {
                this.ResultTextBox.Text += (string.Format("객체 갯수 : {0}", dataJArray.Count) + Environment.NewLine);
                this.ResultTextBox.Text += ("변환 종료 저장합니다============" + Environment.NewLine);
                FileManager.SaveJsonFile(dataJArray);

                excelReader.Free();
            }
        }

        private void DirectoryOpenButtonClick(Object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(FileManager.FileName))
            {
                MessageBox.Show("먼저 파일을 찾아주세요.", "파일이 없어요!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                string filePath = FileManager.FileName;
                string dirPath = filePath.Substring(0, filePath.LastIndexOf('\\'));
                Process.Start(dirPath);
            }
        }

        private void ExitButtonClick(Object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OpenFindButtonClick(Object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(FileManager.FileName))
            {
                MessageBox.Show("먼저 파일을 찾아주세요.", "파일이 없어요!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                Process.Start(FileManager.FilePath);
            }
        }

        private void OpenJsonButtonClick(Object sender, EventArgs e) 
        {
            if (string.IsNullOrEmpty(FileManager.NewFileName))
            {
                MessageBox.Show("먼저 변환을 해야합니다.", "파일이 없어요!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                Process.Start(FileManager.NewFileName);
            }
        }
    }
}
