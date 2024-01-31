namespace ExcelToJson
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.FilePathLabel = new System.Windows.Forms.Label();
            this.NewFilePathLabel = new System.Windows.Forms.Label();
            this.FilePathTextBox = new System.Windows.Forms.TextBox();
            this.NewFileTexBox = new System.Windows.Forms.TextBox();
            this.FindPathButton = new System.Windows.Forms.Button();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.ButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.OpenFindButton = new System.Windows.Forms.Button();
            this.OpenJsonButton = new System.Windows.Forms.Button();
            this.DirectOpenButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.ButtonLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.86644F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.09182F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.04174F));
            this.tableLayoutPanel1.Controls.Add(this.ConvertButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.FilePathLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.NewFilePathLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.FilePathTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.NewFileTexBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.FindPathButton, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 14);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(604, 83);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // FilePathLabel
            // 
            this.FilePathLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.FilePathLabel.AutoSize = true;
            this.FilePathLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.FilePathLabel.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FilePathLabel.Location = new System.Drawing.Point(37, 15);
            this.FilePathLabel.Name = "FilePathLabel";
            this.FilePathLabel.Size = new System.Drawing.Size(81, 12);
            this.FilePathLabel.TabIndex = 0;
            this.FilePathLabel.Text = "변환할 파일 : ";
            this.FilePathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NewFilePathLabel
            // 
            this.NewFilePathLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NewFilePathLabel.AutoSize = true;
            this.NewFilePathLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.NewFilePathLabel.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.NewFilePathLabel.Location = new System.Drawing.Point(37, 55);
            this.NewFilePathLabel.Name = "NewFilePathLabel";
            this.NewFilePathLabel.Size = new System.Drawing.Size(81, 12);
            this.NewFilePathLabel.TabIndex = 1;
            this.NewFilePathLabel.Text = "새 파일 이름 :";
            this.NewFilePathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FilePathTextBox
            // 
            this.FilePathTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FilePathTextBox.Enabled = false;
            this.FilePathTextBox.Location = new System.Drawing.Point(124, 11);
            this.FilePathTextBox.Name = "FilePathTextBox";
            this.FilePathTextBox.Size = new System.Drawing.Size(324, 21);
            this.FilePathTextBox.TabIndex = 2;
            // 
            // NewFileTexBox
            // 
            this.NewFileTexBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NewFileTexBox.Location = new System.Drawing.Point(124, 50);
            this.NewFileTexBox.Name = "NewFileTexBox";
            this.NewFileTexBox.Size = new System.Drawing.Size(324, 21);
            this.NewFileTexBox.TabIndex = 2;
            // 
            // FindPathButton
            // 
            this.FindPathButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FindPathButton.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FindPathButton.Location = new System.Drawing.Point(454, 5);
            this.FindPathButton.Name = "FindPathButton";
            this.FindPathButton.Size = new System.Drawing.Size(145, 33);
            this.FindPathButton.TabIndex = 3;
            this.FindPathButton.Text = "찾아보기";
            this.FindPathButton.UseVisualStyleBackColor = true;
            this.FindPathButton.Click += new System.EventHandler(this.FindPathButtonClick);
            // 
            // ConvertButton
            // 
            this.ConvertButton.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ConvertButton.Location = new System.Drawing.Point(454, 44);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(145, 33);
            this.ConvertButton.TabIndex = 3;
            this.ConvertButton.Text = "변환";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButtonClick);
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(14, 103);
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ReadOnly = true;
            this.ResultTextBox.Size = new System.Drawing.Size(604, 273);
            this.ResultTextBox.TabIndex = 2;
            // 
            // ButtonLayout
            // 
            this.ButtonLayout.ColumnCount = 4;
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ButtonLayout.Controls.Add(this.OpenJsonButton, 1, 0);
            this.ButtonLayout.Controls.Add(this.OpenFindButton, 0, 0);
            this.ButtonLayout.Controls.Add(this.DirectOpenButton, 2, 0);
            this.ButtonLayout.Controls.Add(this.ExitButton, 3, 0);
            this.ButtonLayout.Location = new System.Drawing.Point(14, 382);
            this.ButtonLayout.Name = "ButtonLayout";
            this.ButtonLayout.RowCount = 1;
            this.ButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonLayout.Size = new System.Drawing.Size(604, 48);
            this.ButtonLayout.TabIndex = 1;
            // 
            // OpenFindButton
            // 
            this.OpenFindButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OpenFindButton.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.OpenFindButton.Location = new System.Drawing.Point(5, 5);
            this.OpenFindButton.Name = "OpenFindButton";
            this.OpenFindButton.Size = new System.Drawing.Size(144, 38);
            this.OpenFindButton.TabIndex = 1;
            this.OpenFindButton.Text = "엑셀 파일 열기";
            this.OpenFindButton.UseVisualStyleBackColor = true;
            this.OpenFindButton.Click += new System.EventHandler(this.OpenFindButtonClick);
            // 
            // OpenJsonButton
            // 
            this.OpenJsonButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OpenJsonButton.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.OpenJsonButton.Location = new System.Drawing.Point(155, 5);
            this.OpenJsonButton.Name = "OpenJsonButton";
            this.OpenJsonButton.Size = new System.Drawing.Size(144, 38);
            this.OpenJsonButton.TabIndex = 2;
            this.OpenJsonButton.Text = "변환 파일 열기";
            this.OpenJsonButton.UseVisualStyleBackColor = true;
            this.OpenJsonButton.Click += new System.EventHandler(this.OpenJsonButtonClick);
            // 
            // DirectOpenButton
            // 
            this.DirectOpenButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DirectOpenButton.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DirectOpenButton.Location = new System.Drawing.Point(305, 5);
            this.DirectOpenButton.Name = "DirectOpenButton";
            this.DirectOpenButton.Size = new System.Drawing.Size(144, 38);
            this.DirectOpenButton.TabIndex = 3;
            this.DirectOpenButton.Text = "파일 위치 열기";
            this.DirectOpenButton.UseVisualStyleBackColor = true;
            this.DirectOpenButton.Click += new System.EventHandler(this.DirectoryOpenButtonClick);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ExitButton.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ExitButton.Location = new System.Drawing.Point(455, 5);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(144, 38);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "종료";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 435);
            this.Controls.Add(this.ButtonLayout);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ResultTextBox);
            this.Name = "MainForm";
            this.Text = "Excel2JsonConverter";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ButtonLayout.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label FilePathLabel;
        private System.Windows.Forms.Label NewFilePathLabel;
        private System.Windows.Forms.TextBox FilePathTextBox;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.TextBox NewFileTexBox;
        private System.Windows.Forms.Button FindPathButton;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.TableLayoutPanel ButtonLayout;
        private System.Windows.Forms.Button OpenFindButton;
        private System.Windows.Forms.Button OpenJsonButton;
        private System.Windows.Forms.Button DirectOpenButton;
        private System.Windows.Forms.Button ExitButton;
    }
}

