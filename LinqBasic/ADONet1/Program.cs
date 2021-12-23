using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace ADONet1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sqlstringBuilder = new SqlConnectionStringBuilder();
            sqlstringBuilder["Server"] = "ADMIN";
            sqlstringBuilder["Database"] = "Employees";
            sqlstringBuilder["Trusted_Connection"] = "true";
            var sqlStringConection = sqlstringBuilder.ToString();
            Console.WriteLine(sqlStringConection);
            // chuỗi để kết nối 
            //string sqlStringConection = "Server= ADMIN;Database=Employees;Trusted_Connection=True;";
            var conection = new SqlConnection(sqlStringConection); // vào SQL để lấy data
            Console.WriteLine(conection.State); // thông báo trạng thái kết nối 
            conection.Open();
            Console.WriteLine(conection.State);
            using DbCommand command = new SqlCommand();
            command.Connection = conection;
            command.CommandText = "select top(5) *from Employees";
            var datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                Console.WriteLine($"{datareader["EmployeeName"],5} and PhoneNumber:{datareader["PhoneNumber"],5}");
            }

            conection.Close();
        }
    }
}
