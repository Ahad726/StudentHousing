
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

        /// <summary>
        /// Select data from database. Reader reads data row by row, suitable for large data
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="sql"></param>
        private static List<Dictionary<string, object>> ExecuteQuery(string connectionString, string sql)
        {
            var allRow = new List<Dictionary<string, object>>();

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var row = new Dictionary<string, object>();

                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    var fieldName = reader.GetName(i);
                                    var fieldValue = reader.GetValue(i);

                                    row[fieldName] = fieldValue;
                                }
                                allRow.Add(row);
                            }
                            reader.Close();
                        }
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
            return allRow;
        }



        /// <summary>
        /// Another method to read data. Select data as a whole table
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        private static DataSet GetDataUsingAdapter(string connectionString, string sql)
        {
            var dataset = new DataSet();

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new SqlCommand(sql, connection))
                    {
                        var adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataset);
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
            return dataset;
        }


        /// <summary>
        /// Get count Using ExecuteScalar
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object? GetCount(string connectionString, string sql)
        {
            object? result = null;
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new SqlCommand(sql, connection))
                    {
                        result = command.ExecuteScalar();
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

            return result;
        }
    }
}