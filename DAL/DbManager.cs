using System;
using System.Data.SqlClient;

namespace DAL
{
    // open connection to the database and insert data
    public class DbManager
    {
        private static string GetSqlConnection()
        {
            string connectionString = @"Data Source=MEIR-THINK\SQLEXPRESS;Initial Catalog=SearchDB;Integrated Security=True";

            return connectionString;
        }

        public static int ExecDb(string command)
        {
            int searchID = 0;
            try
            {
                using (SqlConnection sql = new SqlConnection(GetSqlConnection()))
                {
                    sql.Open();

                    SqlCommand query = new SqlCommand(command, sql);

                    query.ExecuteNonQuery();
                    //get last SearchID from the SearchData table
                    query = new SqlCommand($"SELECT TOP 1 SearchId FROM dbo.SearchData ORDER BY SearchID DESC", sql);

                    object res = query.ExecuteScalar();

                    searchID = (int)res;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return searchID;

        }
    }
}

