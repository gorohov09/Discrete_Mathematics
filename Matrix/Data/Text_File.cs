using Matrix.Data.Base;
using System;
using System.IO;

namespace Matrix
{
    public class Text_File : Data_File, IReadMatrix
    {
        public Text_File(string file) :
            base(file)
        {
        }

        public int[,] Read()
        {
            using (StreamReader sr = new StreamReader(_file))
            {
                int j = 0;
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < line.Length; i++)
                    {
                        _data[i, j] = Convert.ToInt32(line[i]);
                    }
                    j++;
                }
            }

            return _data;
        }
    }
}
