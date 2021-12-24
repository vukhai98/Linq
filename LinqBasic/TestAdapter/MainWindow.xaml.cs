using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestAdapter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable table = new DataTable("Employees");
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataSet dataSet = new DataSet();
        public MainWindow()
        {
            InitAdapter();
            InitializeComponent();
        }
        void InitAdapter()
        {
            string stringSqlConnection = "Server=ADMIN;Database=Employees;Trusted_Connection=True";

            connection = new SqlConnection(stringSqlConnection);
            adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table", "Employees");
            // Select Command 
            adapter.SelectCommand = new SqlCommand("Select EmployeeID,EmployeeName,PhoneNumber from Employees;", connection);
            // Insert Command
            adapter.InsertCommand = new SqlCommand("insert into Employees (EmployeeName,PhoneNumber) values (@EmployeeName,@PhoneNumber)", connection);
            adapter.InsertCommand.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 50, "EmployeeName");
            adapter.InsertCommand.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 50, "PhoneNumber");
            // Delete Command
            adapter.DeleteCommand = new SqlCommand("delete from Employees where EmployeeID = @EmployeeID", connection);
            var pr1 = adapter.DeleteCommand.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int));
            pr1.SourceColumn = "EmployeeID";
            pr1.SourceVersion = DataRowVersion.Original;
            adapter.UpdateCommand = new SqlCommand("update  Employees set EmployeeName = @EmployeeName where EmployeeID = @EmployeeID", connection);
            var pr2 = adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int));
            pr2.SourceColumn = "EmployeeID";
            pr2.SourceVersion = DataRowVersion.Original;
            adapter.UpdateCommand.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 50, "EmployeeName");

            dataSet.Tables.Add(table);
            //var dataSet = new DataSet();
            //adapter.Fill(dataSet);
            //DataTable table = dataSet.Tables["Employees"];
            ////ShowDataTable(table);


            ////var row = table.Rows.Add();

            ////row["EmployeeName"] = "Didia Drogba";
            ////row["PhoneNumber"] = "9961166012";
            ////var row6 = table.Rows[6];
            ////row6.Delete();
            ////var r = table.Rows[5];
            ////r["EmployeeName"] = "Mason Mount";


            //adapter.Update(dataSet);
            //connection.Close();


        }
        void LoadDataTable()
        {
            table.Rows.Clear();
            adapter.Fill(table);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataTable();
            datagrid.DataContext = table.DefaultView;
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadDataTable();
            datagrid.DataContext = table.DefaultView;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            adapter.Update(dataSet);
            table.Rows.Clear();
            adapter.Fill(dataSet);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedItem = (DataRowView)datagrid.SelectedItem;
            if (selectedItem != null)
            {
                selectedItem.Delete();
            }
        }
    }
    
}
