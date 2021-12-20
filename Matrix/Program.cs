using System;
using System.IO;


namespace Matrix
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Кол - во вершин - 7
            string ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\andre\source\repos\Matrix\Matrix\MatrixDatabase.mdf;Integrated Security=True";
            Text_File text_File = new Text_File(@"C:\Users\andre\source\repos\Matrix\Matrix\file_matrix.txt");
            Matrix_Calculate matrix_Calculate = new Matrix_Calculate(text_File);
            Console.WriteLine(matrix_Calculate.FindWay(2, 7, 7));

            Excel_File excel_File = new Excel_File(@"C:\Users\andre\source\repos\Matrix\Matrix\work2.xlsx");
            Matrix_Calculate matrix_Calculate1 = new Matrix_Calculate(excel_File);
            Console.WriteLine(matrix_Calculate1.FindWay(2, 7, 7));

            Database_File database_File = new Database_File(ConStr);
            Matrix_Calculate matrix_Calculate2 = new Matrix_Calculate(database_File);
            Console.WriteLine(matrix_Calculate2.FindWay(2, 7, 7));



        }
    }
}
