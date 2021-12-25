using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Data.Base
{
    public abstract class Data_File
    {
        protected string _file;

        protected int[,] _data;

        public Data_File(string file)
        {
            _file = file;
            _data = new int[7, 7];
        }
    }
}
