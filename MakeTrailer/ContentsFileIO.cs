using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace MakeTrailer
{
    static class ContentsFileIO
    {
        private const string DirName = "Data";
        private const string FileName = DirName + "\\contents.csv";

        public static List<string> Read()
        {
            List<string> list = new List<string>();

            if (File.Exists(FileName) == false)
            {
                return null;
            }

            try
            {
                using (StreamReader reader = new StreamReader(FileName, Encoding.Default))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        list.Add(line);
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return list;
            }
        }

        public static void Write(List<string> list)
        {
            if (Directory.Exists(DirName) == false)
            {
                Directory.CreateDirectory(DirName);
            }

            try
            {
                using (StreamWriter writer = new StreamWriter(FileName, false, Encoding.Default))
                {
                    foreach (string s in list)
                    {
                        writer.Write(s);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
