using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeTrailer
{
    static class Trailer
    {
        private static Random random = new Random();

        public static string Get(string nameA, string nameB, string nameC)
        {
            string content;

            List<string> contentList = ContentsFileIO.Read();

            if (contentList == null)
            {
                return "予告ファイルがありません。";
            }

            if (contentList.Count <= 0)
            {
                return "予告ファイルに予告がありません。";
            }

            int index = random.Next(contentList.Count);
            content = contentList[index];

            content = content.Replace(",", Environment.NewLine);
            content = content.Replace("[人物A]", nameA);
            content = content.Replace("[人物B]", nameB);
            content = content.Replace("[人物C]", nameC);

            return content;
        }
    }
}
