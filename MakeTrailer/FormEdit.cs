using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeTrailer
{
    public partial class FormEdit : Form
    {
        public FormEdit()
        {
            InitializeComponent();
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {
            List<string> contentList = ContentsFileIO.Read();

            if (contentList == null)
            {
                MessageBox.Show("予告ファイルが存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            foreach (string s in contentList)
            {
                if (s.IndexOf(",") != -1)
                {
                    string[] c = s.Split(',');
                    dataGridViewContents.Rows.Add("削除", c[0], c[1], c[2]);
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int count = dataGridViewContents.Rows.Count;

            List<string> contentList = ContentsFileIO.Read();
            for (int i = 0; i < count - 1; i++)
            {
                string c1 = (string)dataGridViewContents[1, i].Value;
                string c2 = (string)dataGridViewContents[2, i].Value;
                string c3 = (string)dataGridViewContents[3, i].Value;
                contentList.Add(c1 + ',' + c2 + ',' + c3 + Environment.NewLine);
            }

            ContentsFileIO.Write(contentList);
        }

        private void dataGridViewContents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewContents.Columns["DeleteButton"].Index)
            {
                if (DialogResult.Yes == MessageBox.Show("本当に削除しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    try
                    {
                        dataGridViewContents.Rows.RemoveAt(e.RowIndex);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
