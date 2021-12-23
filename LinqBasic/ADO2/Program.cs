using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ADO2
{
    class Program
    {
        static void Main(string[] args)
        {
            // kết nối với SQL Server 
            string stringSqlConnection = "Server=ADMIN;Database=Employees;Trusted_Connection=True";
                             
            var connection = new SqlConnection(stringSqlConnection);
            //Console.WriteLine(connection.State);
            connection.Open();
            //Console.WriteLine(connection.State);
            #region Command
            //using DbCommand command = new SqlCommand();
            //command.Connection = connection;
            //command.CommandText = "select top(5) *from Employees";
            //var datareader = command.ExecuteReader();
            //while (datareader.Read())
            //{
            //    Console.WriteLine($"{datareader["EmployeeName"],5} + {datareader["PhoneNumber"],5}");
            //}
            //connection.Close();
            #endregion
            //using var command = new SqlCommand();
            //command.Connection = connection;
            //command.CommandText= "select EmployeeID,EmployeeName,PhoneNumber,SkillID from Employees where EmployeeID >= @EmployeeID";
            //var employeeID = command.Parameters.AddWithValue("@EmployeeID", 2);

            // command.EXcuteReader(); - when the returned result has multiple lines
            #region ExcuteReader();
            //employeeID.Value = 3;
            //using var sqlReader = command.ExecuteReader();
            //if (sqlReader.HasRows)
            //{
            //    while (sqlReader.Read())
            //    {
            //        var id = sqlReader.GetInt32(0);
            //        var name = sqlReader[1];
            //        var phoneNumber = sqlReader[2];
            //        Console.WriteLine($"{id} -{name}-{phoneNumber}" );
            //}
            //else
            //{
            //    Console.WriteLine("No data returned");
            //}
            #endregion
            // command.ExcuteScalar(); - dùng khi return 1 giá trị  (row 1 , column 1)
            #region ExcuteScalar()
            //using var command = new SqlCommand();
            //command.Connection = connection;
            //command.CommandText = " select COUNT(1) from Employees where EmployeeID >= @EmployeeID";
            //var employeeID = command.Parameters.AddWithValue("@EmployeeID", 2);
            //employeeID.Value =3;
            //var returnValue = command.ExecuteScalar(); 
            //Console.WriteLine(returnValue);
            #endregion
            //command.NonQuery(); - khi Update,Insert,Delete thì nó sẽ trả ra số dòng bị tác động bởi câu lệnh
            using var command = new SqlCommand();
            command.Connection = connection;
            //command.CommandText = " insert into  Skills (Title) values(@value)";
            //var value = command.Parameters.AddWithValue("@value","");
            //for (int i = 0; i < 4; i++)
            //{
            //    value.Value = "C#";
            //}
            //var result = command.ExecuteNonQuery();
            //Console.WriteLine(result);
            command.CommandText = "getinfo";
            command.CommandType = CommandType.StoredProcedure;
            var id = new SqlParameter("@id", 0);
            command.Parameters.Add(id);
            id.Value = 2;
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                var ID = reader[0];
                var Name = reader[1];
                var Title = reader[2];
                Console.WriteLine($"  {ID}  :  {Name} : {Title} ");
                    
            }

        }
    }
}
