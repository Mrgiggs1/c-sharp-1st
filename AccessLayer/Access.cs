using System.Data.SqlClient;
namespace AccessLayer
{
    public class Access
    {

        public static void readData(string opt,string connectionString)
        {
            var con = new SqlConnection(connectionString);
            //open connection
            con.Open();
            //create query that reads from database
            string sql2 = "SELECT * FROM Department where DepartmentName = @dep";
            //create a sql command referencing the connection
            SqlCommand cmd2 = new SqlCommand(sql2, con);

            con.Close();
            cmd2.Parameters.Add(new SqlParameter("@dep", opt));
            cmd2.CommandType = System.Data.CommandType.Text;

            con.Open();
            //create sql data reader
            SqlDataReader dataReader = cmd2.ExecuteReader();

            int counting = 0;
            //while its reading
            while (dataReader.Read())
            {
                //store the columns in variables
                var id = dataReader["Id"];
                var depName = dataReader["DepartmentName"].ToString();

                if (dataReader.FieldCount <= 0)
                {
                    Console.WriteLine("Data not Found ## ");
                }
                else
                {
                    counting++;
                    Console.WriteLine("No. \t ID No. \t Department Name");
                    Console.WriteLine(counting +"\t "+id + "\t " + depName+"\n");
                 
                }
            }
            Console.WriteLine("=================================" +
                "==================\n"+counting + " Rows Found" +
                "\n=================================" +
                "==================");
            //close connection
            con.Close();
            //dispose of connection
            con.Dispose();

        }

        public static void insertData(string opt, string connectionString)
        {
            var con = new SqlConnection(connectionString);
            string sql = "Insert Into Department(DepartmentName) values (@dep)";


            //open connection
            con.Open();

            //create a sql command referencing the connection
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Close();
            cmd.Parameters.Add(new SqlParameter("@dep", opt));
            cmd.CommandType = System.Data
                .CommandType.Text;
            con.Open();

            cmd.ExecuteScalar();

            //close connection
            con.Close();

            readData(opt, connectionString);
        }
    }
}