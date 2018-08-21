/* 
 Project #3 by Meir Yeheskel

 The program uses an open database to store the required variables.
 The relational Database was built through the query file "searchdb.txt" which is included.
 For simplicity - when no search folder is selected - the "c:\" folder will be the default.
 Although an error catching system was introduced, a try & catch syntax was added 
 for reasons of "UnauthorizedAccessException" errors from the BLL section.
 
*/

using BLL;
using BOL;
using System;
using System.IO;


namespace UIL
{
    class Program
    {
        static void Main(string[] args)
        {
            string UserOption = null;
            SearchModel CurrentSearch = new SearchModel();  // create a new instance of the SearchModel class 

            do
            {
                try
                {
                    Console.WriteLine("1. Enter file name to search.");
                    Console.WriteLine("2. Enter file name to search + parent directory to search in.");
                    Console.WriteLine("3. Exit");

                    UserOption = Console.ReadLine();
                    switch (UserOption)
                    {
                        case "1":
                            Console.WriteLine("Enter file name to search");
                            if (Isvalid(CurrentSearch.SearchString = Console.ReadLine())) //check user input validity
                            {
                                CurrentSearch.SearchFolder = "c:\\";
                                // the following function will be executed whenever an event will be raised in the BLL section
                                SearchManager.SearchHandler += (filename) => { Console.WriteLine($"{filename}"); };
                                SearchManager.StartSearching(CurrentSearch);
                            }

                            break;

                        case "2":
                            Console.WriteLine("Enter file name to search");
                            if (Isvalid(CurrentSearch.SearchString = Console.ReadLine()))
                            {
                                Console.WriteLine("Enter root directory to search");
                                if (Isvalid(CurrentSearch.SearchFolder = Console.ReadLine()))
                                    if (Directory.Exists(CurrentSearch.SearchFolder))
                                    {
                                        SearchManager.SearchHandler += (filename) => { Console.WriteLine($"{filename}"); };
                                        SearchManager.StartSearching(CurrentSearch);
                                    }
                                    else Console.WriteLine($"{CurrentSearch.SearchFolder} folder does not exist!");
                            }
                            break;

                        case "3": break;  

                        default:
                            Console.WriteLine("Please enter only the following numbers: 1,2 or 3");
                            break;
                    }
                    if (UserOption == "3") break; //exit the while loop
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); 
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to start a new search...");
                Console.ReadKey();
                Console.Clear();
            } while (true);
        }

        static bool Isvalid(string str)  // check the validity of the user input
        {
            if (str.Length > 0 && str.Length < 50) return true;
            Console.WriteLine("Please enter a filename with minimum 1 character and maximum 50 characters...");
            return false;

        }
    }
}




