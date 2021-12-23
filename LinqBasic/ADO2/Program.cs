using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace ADO2
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringSqlConnection = "Server=ADMIN;Database=Employees;Trusted_Connection=True";
                             
            var connection = new SqlConnection(stringSqlConnection);
            Console.WriteLine(connection.State);
            connection.Open();
            Console.WriteLine(connection.State);
            using DbCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select top(5) *from Employees";
            var datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                Console.WriteLine($"{datareader["EmployeeName"],5} + {datareader["PhoneNumber"],5}");
            }
            connection.Close();
        }
    }
}
