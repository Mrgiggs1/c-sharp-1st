using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer
{
    public class DataAccess
    {
        // Function(method) used to display string information
        public static string GetConnectionInformation(SqlConnection con)
        {
            StringBuilder sb = new StringBuilder(1024);
            sb.AppendLine("Connection String: " + con.ConnectionString);
            sb.AppendLine("State: " + con.State.ToString());
            sb.AppendLine("Connection Timeout: " + con.ConnectionTimeout.ToString());
            sb.AppendLine("Database: " + con.Database);
            sb.AppendLine("Data Source: " + con.DataSource);
            sb.AppendLine("Server Version: " + con.ServerVersion);
            sb.AppendLine("Workstation ID: " + con.WorkstationId);

            return sb.ToString();

        }

        public static void Connect(string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            var feedBack = GetConnectionInformation(con);
            Console.WriteLine(feedBack);
            con.Close();




            string sql = "Insert Into Beer(itemName, itemPrice) values ('c-sharp', 20.10)";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();

            con.Open();
            string sql2 = "SELECT * FROM Beer";
            SqlCommand cmd2 = new SqlCommand(sql2, con);
            SqlDataReader dataReader = cmd2.ExecuteReader();

            while (dataReader.Read())
            {
                var id = dataReader.GetInt32(0);
                var itemName = dataReader.GetString(1);
                decimal itemPrice = dataReader.GetDecimal(2);
                Console.WriteLine(id + " " + itemName + " " + itemPrice);


            }

            con.Close();
            con.Dispose();
        }
    }
}
