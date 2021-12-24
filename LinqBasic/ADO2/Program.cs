using System;
using System.Data;
using System.Data.SqlClient;


namespace ADO2
{
    class Program
    {
        static void ShowDataTable(DataTable table)
        {
            Console.WriteLine($"NameofTable: {table.TableName}");
            Console.Write($"Index",10);

            foreach (DataColumn c in table.Columns)
            {
                Console.Write($"{c.ColumnName,20}");

            }
            Console.WriteLine();
            int index = 0;
            int numberColumns = table.Columns.Count;
            foreach (DataRow r in table.Rows)
            {
                Console.Write($"{index}",10);
                for (int i = 0; i < numberColumns; i++)
                {

                    Console.Write($"{r[i],20}");
                }
                Console.WriteLine();
                index++;
             

            }

        }
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
            #region ExcuteNonQuery
            //using var command = new SqlCommand();
            //command.Connection = connection;
            //command.CommandText = " insert into  Skills (Title) values(@value)";
            //var value = command.Parameters.AddWithValue("@value","");
            //for (int i = 0; i < 4; i++)
            //{
            //    value.Value = "C#";
            //}
            //var result = command.ExecuteNonQuery();
            //Console.WriteLine(result);
            #endregion
            #region StoredProcedure
            //using var command = new SqlCommand();
            //command.Connection = connection;
            //command.CommandText = "getinfo";
            //command.CommandType = CommandType.StoredProcedure;
            //var id = new SqlParameter("@id", 0);
            //command.Parameters.Add(id);
            //id.Value = 2;
            //var reader = command.ExecuteReader();
            //if (reader.HasRows)
            //{
            //    reader.Read();
            //    var ID = reader[0];
            //    var Name = reader[1];
            //    var Title = reader[2];
            //    Console.WriteLine($"  {ID}  :  {Name} : {Title} ");

            //}
            #endregion

            #region Create Table = Dataset;
            //var dataset = new DataSet();
            //using var table = new DataTable("My Table");
            //dataset.Tables.Add(table);

            //table.Columns.Add("Id");
            //table.Columns.Add("Name");
            //table.Columns.Add("Age");

            //table.Rows.Add(1, "Peter Cech", 38);
            //table.Rows.Add(2, "Mason Mount", 22);
            //table.Rows.Add(3, "N'Golo Kante", 30);

            //ShowDataTable(table);
            #endregion
            var adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table", "Employees");
            // Select Command 
            adapter.SelectCommand = new SqlCommand("Select EmployeeID,EmployeeName,PhoneNumber from Employees;", connection);
            // Insert Command
            adapter.InsertCommand = new SqlCommand("insert into Employees (EmployeeName,PhoneNumber) values (@EmployeeName,@PhoneNumber)", connection);
            adapter.InsertCommand.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 50, "EmployeeName");
            adapter.InsertCommand.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 50, "PhoneNumber");
            // Delete Command
            adapter.DeleteCommand = new SqlCommand("delete from Employees where EmployeeID = @EmployeeID",connection);
            var pr1 = adapter.DeleteCommand.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int));
            pr1.SourceColumn = "EmployeeID";
            pr1.SourceVersion = DataRowVersion.Original;
            adapter.UpdateCommand = new SqlCommand("update  Employees set EmployeeName = @EmployeeName where EmployeeID = @EmployeeID", connection);
            var pr2 = adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int));
            pr2.SourceColumn = "EmployeeID";
            pr2.SourceVersion = DataRowVersion.Original;
            adapter.UpdateCommand.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 50, "EmployeeName");
         

            var dataSet = new DataSet();
            adapter.Fill(dataSet);
            DataTable table = dataSet.Tables["Employees"];
            ShowDataTable(table);


            //var row = table.Rows.Add();

            //row["EmployeeName"] = "Didia Drogba";
            //row["PhoneNumber"] = "9961166012";
            //var row6 = table.Rows[6];
            //row6.Delete();
            //var r = table.Rows[5];
            //r["EmployeeName"] = "Mason Mount";


            adapter.Update(dataSet);
            connection.Close();
        }
    }
}
