using System;

namespace Matrix
{
    public class Program
    {
        static void Main(string[] args)
        {          
            Text_File text_File = new Text_File(@"C:\Users\andre\source\repos\Matrix\Matrix\file_matrix.txt");
            Matrix_Calculate matrix_Calculate = new Matrix_Calculate(text_File);
            Console.WriteLine("Текстовый файл:");
            Console.WriteLine($"Расстояние между v1 и v7 = {matrix_Calculate.FindWay(1, 7)}"); //Нахождение растояние между вершинами v1 и v7
            Console.WriteLine($"Кол-во путей длины(3) между v4 и v6 = {matrix_Calculate.FindCount(4, 6, 3)}\n"); //Нахождение кол-ва путей длины(3) между вершинами v4 и v6

            Console.WriteLine("Excel файл:");
            Excel_File excel_File = new Excel_File(@"C:\Users\andre\source\repos\Matrix\Matrix\work2.xlsx");
            Matrix_Calculate matrix_Calculate1 = new Matrix_Calculate(excel_File);
            Console.WriteLine($"Расстояние между v1 и v7 = {matrix_Calculate1.FindWay(1, 7)}");
            Console.WriteLine($"Кол-во путей длины(3) между v4 и v6 = {matrix_Calculate1.FindCount(4, 6, 3)}\n");

            Console.WriteLine("База данных:");
            Database_File database_File = new Database_File(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\andre\source\repos\Matrix\Matrix\MatrixDatabase.mdf;Integrated Security=True");
            Matrix_Calculate matrix_Calculate2 = new Matrix_Calculate(database_File);
            Console.WriteLine($"Расстояние между v1 и v7 = {matrix_Calculate2.FindWay(1, 7)}");
            Console.WriteLine($"Кол-во путей длины(3) между v4 и v6 = {matrix_Calculate2.FindCount(4, 6, 3)}\n");

        }
    }
}
