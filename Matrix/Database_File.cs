using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Database_File : IReadMatrix
    {
        private string _file;
        private int[,] _data;

        public Database_File(string file)
        {
            _file = file;
            _data = new int[7, 7];
        }

        public int[,] Read() 
        {
            using (SqlConnection connection = new SqlConnection(_file))
            {
                connection.Open();

                var sql = "SELECT * FROM Matrix";

                SqlCommand cmd = new SqlCommand(sql, connection);

                SqlDataReader r = cmd.ExecuteReader();

                int j = 0;
                while (r.Read())
                {
                    _data[0, j] = (int)r[2];
                    _data[1, j] = (int)r[3];
                    _data[2, j] = (int)r[4];
                    _data[3, j] = (int)r[5];
                    _data[4, j] = (int)r[6];
                    _data[5, j] = (int)r[7];
                    _data[6, j] = (int)r[8];
                    j++;
                }
            }

            return _data;
        }
    }
}
