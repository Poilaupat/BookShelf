using BookShelfApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace BookShelfApi.Data
{
    public class BookTools
    {
        private static readonly string _connectionString = "server=SRVVM166.integration\\DEV4;database=TestCoreWebApi;uid=sa;pwd=Oronesql;Connect Timeout = 30 ;Max Pool Size=100;";


        public static IEnumerable<Book> GetBooks()
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Select * from T_BOOK";

                    var table = new DataTable(_connectionString);
                    cnx.Open();
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }

                    foreach (DataRow row in table.Rows)
                    {
                        yield return Book.FromRow(row);
                    }    
                }
            }
        }

        public static void AddBook(string bookName)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"insert into T_BOOK(BookName) values({bookName})";
                    
                    cnx.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
