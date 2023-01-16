
using System.Data;
using System.Data.SqlClient;

namespace StudentHousing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            const string connectionString = "Server=DESKTOP-6U3O5E7; Database=MyMess; User Id=talha; Password=1998;";

            var insertQuery = "insert into Member ( [Name], Email, Phone, Address) values ('ATM','atm@gmail.com','01762383412','Gazipur');";
            var updateQuert = "Update Member Set Email = 'atm2@gmail.com' where id = 3;";
            var deleteQuery = "Delete from Member where id = 3;";
            var countQuery = "Select count(*) from Member;";

            // Insert
            //ExecuteNonQuery(connectionString, sqlInsert);

            // Update
            //ExecuteNonQuery(connectionString, sqlUpdate);

            // Delete 
            //ExecuteNonQuery(connectionString, sqlDelete);

            // Select
            var sqlSelect = "Select * from Member;";
            //var data = ExecuteQuery(connectionString, sqlSelect);

            //var data = GetDataUsingAdapter(connectionString, sqlSelect);

            Console.WriteLine(GetCount(connectionString, countQuery));

            

        }

        private static void ExecuteNonQuery(string connectionString, string sql)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection?.Close();
                }
            }
        }

       
    }
}