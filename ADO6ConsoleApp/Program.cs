﻿using System;
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
            string opt;
            Console.WriteLine("Press The Following Options \n1: Search Data,  2: Insert Data,  3: Delete Data,   4: Update Data" +
                ", : Any Num to search all data");
            opt = Console.ReadLine();

            try
            {
                switch (Convert.ToInt32(opt))
                {
                    case 1:
                        // function for reading values
                        search(con);
                        break;
                    case 2:
                        // function for entering values
                        enterValues(con);
                        break;
                    case 3:
                        deleteValue(con);
                        break;
                    case 4:
                        update(con);
                        break;
                    default:
                        // code block
                        Console.WriteLine("Default to Searching All Data");
                        Access.readData("all", con);
                        break;
                }
            }
            catch(Exception err)
            {
                
                Console.WriteLine("======================\n" +
                                    "Provide correct Data");
                Console.WriteLine("==========================================================\n"+err
                    + "\n==========================================================");
            }

            
        }


        //enter what you need to search on the database
        public static void search(SqlConnection con)
        {
            string search;
            Console.WriteLine("Search by First Name, Surname, ID no# or All");
            search = Console.ReadLine();
            Access.readData(search, con);
        }


        //delete data value
        public static void deleteValue(SqlConnection con)
        {
            string del;
            Console.WriteLine("Delete by Surname or Firstname");
            del = Console.ReadLine();
            Access.deleteData(del, con);
        }

        //entering data values to insert 
        public static void enterValues(SqlConnection con)
        {
                string dep;
                Console.WriteLine("Enter FirstName");
                string fName = Console.ReadLine();

                Console.WriteLine("Enter Surname");
                string lName = Console.ReadLine();

                string fullName = fName + " " + lName;

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

          
                Access.insertData(fName, lName, fullName, ID, parkNo, isBirthday, positionName, dep, con);
            
        }


        public static void update(SqlConnection con)
        {
            Console.WriteLine("Enter First Name to update data @!!");
            string name = Console.ReadLine();

            Access.updateData(name,con);


        }

       
       
    }
}

