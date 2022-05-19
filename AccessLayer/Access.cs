using System.Data.SqlClient;
namespace AccessLayer
{
    public class Access
    {

        public static void readData(string searching, SqlConnection con)
        {
            //create query that reads from database
            string sql2 = "select * " +
                "from member " +
                "where FirstName like @search " +
                "OR Surname like @search " +
                "OR SAIdentityNo like @search ";
            //create a sql command referencing the connection
            var cmd2 = new SqlCommand(sql2, con);


            cmd2.Parameters.Add(new SqlParameter("@search", searching));
            //cmd2.CommandType = System.Data.CommandType.Text;


            //create sql data reader
            SqlDataReader dataReader = cmd2.ExecuteReader();

            

            int counting = 0;
            //while its reading
            Console.WriteLine("\nNo. \t|Fist Name \t |Surname \t| SA ID#");
            while (dataReader.Read())
            {
                //store the columns in variables
                var id = dataReader["Id"];
                var name = dataReader["FirstName"];
                var Surname = dataReader["Surname"];
                var idno = dataReader["SAIdentityNo"];

                if (dataReader.FieldCount <= 0)
                {
                    Console.WriteLine("Data not Found ## ");
                }
                else
                {
                    counting++;                    
                    Console.WriteLine(counting+" \t| "+name+" \t|"+Surname+" \t| "+ idno);
                 
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

        public static void insertData(string fName, string lName,string fullName, string ID, string parkNo, string
            isBirthday, string positionName, string dep, SqlConnection con)
        {
           
                //insert into department
                string sql = "Insert Into Department(DepartmentName) values (@dep)";
            //create a sql command referencing the connection
            SqlCommand cmd = new SqlCommand(sql, con);


            cmd.Parameters.Add(new SqlParameter("@dep", dep));
            cmd.CommandType = System.Data
                .CommandType.Text;


            cmd.ExecuteScalar();

            //----------------------------------------------------------------------------
            //insert into Position

            string sql2 = "Insert Into Position(Description) values (@pos)";
            //create a sql command referencing the connection
            SqlCommand posCommand = new SqlCommand(sql2, con);


            posCommand.Parameters.Add(new SqlParameter("@pos", positionName));
            posCommand.CommandType = System.Data
                .CommandType.Text;


            posCommand.ExecuteScalar();
            //----------------------------------------------------------------------------
           

            //execute stored procedure for id save in keyA
            string link = "exec getDepId";
            SqlCommand cmd1 = new SqlCommand(link, con);
            var keyA = cmd1.ExecuteScalar();
            //insert into Position

            keyA = Int32.Parse(keyA.ToString());

            //----------------------------------------------------------------------------
            //execute stored procedure for id save in keyB
            string link2 = "exec getPositionId";
            SqlCommand cmd2 = new SqlCommand(link2, con);
            var keyB = cmd2.ExecuteScalar();

            keyB = Int32.Parse(keyB.ToString());



            //----------------------------------------------------------------------------

            //insert into member using keyA and keyB

            //fName, lName, ID, parkNo,isBirthday, positionName,dep , con
            string memberSql = "Insert Into Member(FirstName,Surname,FullName,SAIdentityNo," +
                "ParkingSpotNo,DepartmentId,PositionId,CelebratesBirthday) " +
                "values (@fName,@lName,@fullName,@identity,@parkNo,@depID,@posID,@isBirthDay)";
            //create a sql command referencing the connection
            SqlCommand memCommand = new SqlCommand(memberSql, con);

            /*
             * tring fName, string lName, string ID, string parkNo, string isBirthday, string positionName, string dep, SqlConnection con
             * */
            int result = 0;

            if (isBirthday.ToLower() == "yes")
            {
                 result = 1;
            }

            memCommand.Parameters.Add(new SqlParameter("@fName", fName));
            memCommand.Parameters.Add(new SqlParameter("@lName", lName));
            memCommand.Parameters.Add(new SqlParameter("@fullName", fullName));
            memCommand.Parameters.Add(new SqlParameter("@identity", ID));
            memCommand.Parameters.Add(new SqlParameter("@parkNo", Int32.Parse(parkNo)));
            memCommand.Parameters.Add(new SqlParameter("@depID", keyA));
            memCommand.Parameters.Add(new SqlParameter("@posID", keyB));
            memCommand.Parameters.Add(new SqlParameter("@isBirthDay", result));


            memCommand.ExecuteScalar();


            //----------------------------------------------------------------------------

            //close connection
            con.Close();
            Console.WriteLine(keyA+" "+keyB);
            //readData(dep, con);
        }
    }
}