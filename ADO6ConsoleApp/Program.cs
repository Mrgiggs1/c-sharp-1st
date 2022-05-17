using System;
using AccessLayer;
namespace AD06ConsoleApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //this is a connection string which is used to store the details.
            string connect = "Server= LAPTOP-ICUOINHF; Database = AFCentral;Trusted_Connection=true;";

            
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
                    Access.readData(dep, connect);
                    break;
                case 2:
                    // code block
                    Console.WriteLine("Write down Name of the department");
                    dep = Console.ReadLine();
                    Access.insertData(dep, connect);
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

