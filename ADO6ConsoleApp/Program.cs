using System;
using AccessLayer;
using System.Data.SqlClient;
namespace AD06ConsoleApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //this is a connection string which is used to store the details.
            string connect = "Server= LAPTOP-ICUOINHF; Database = AFCentral;Trusted_Connection=true;";
            var con = new SqlConnection(connect);
            con.Open();
            //create query that writes to database
            string dep,opt;
            Console.WriteLine("Press The Following Options \n1: Read Data or 2: Insert Data");
            opt = Console.ReadLine();

            switch (Convert.ToInt32(opt))
            {
                case 1:
                    // code block
                    Console.WriteLine("\nWhich Department you Looking for:");
                    dep = Console.ReadLine();
                    Access.readData(dep, con);
                    break;
                case 2:
                    // code block
                    Console.WriteLine("Enter FirstName");
                    string fName = Console.ReadLine();

                    Console.WriteLine("Enter Surname");
                    string lName = Console.ReadLine();

                    Console.WriteLine("Enter Full Name");
                    string fullName = Console.ReadLine();

                    Console.WriteLine("Enter your SA ID");
                    string ID = Console.ReadLine();

                    Console.WriteLine("Enter your Parking Spot No.");
                    string parkNo = Console.ReadLine();

                    Console.WriteLine("Do you celebrate Birthdays?");
                    string isBirthday = Console.ReadLine();

                    Console.WriteLine("Write down Name of the department");
                    dep = Console.ReadLine();

                    Console.WriteLine("Write down your Positon Name");
                    string positionName = Console.ReadLine();

                    Access.insertData(fName, lName, fullName, ID, parkNo,isBirthday, positionName,dep , con);
                    break;
                default:
                    // code block
                    Console.WriteLine("Again:  \nPress 1: Read Data or 2: Insert Data");
                    opt = Console.ReadLine();
                    break;
            }
        }

       
    }
}

