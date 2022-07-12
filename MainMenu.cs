using System;
using static System.Console;
namespace AssignmentIFN664
{
    public class MainMenu
    {
    
      
        public static MemberCollection memberCollection = new();
        public static ToolCollection toolCollection = new();
        public static int key = 0;

        public void Main()
        {
            string menuanswer;

            Clear();

            WriteLine("Welcome to the Tool Library System ");
            WriteLine();
            WriteLine("=======Main Menu=======");
            WriteLine("1. Staff login");
            WriteLine("2. Member login");
            WriteLine("0. Exit");
            WriteLine("=======================");
            Write("Select option from menu (0 to exit): ");

            menuanswer = ReadLine();

            while (menuanswer != "1" || menuanswer != "2" || menuanswer != "0")
            {
                if (menuanswer == "0")
                {
                    Environment.Exit(0);
                }
                else if (menuanswer == "1")
                {
                    StaffLogin();
                    break;
                }
                else if (menuanswer == "2")
                {
                    MemberLogin();
                    break;
                }
                Write("Please enter a valid response: ");
                menuanswer = ReadLine();

            }

        }


        public void StaffLogin()
        {
            bool correct = false;
            string username;
            string password;

            Clear();
            Write("Enter you username: ");
            username = ReadLine();

            Clear();
            Write("Enter you password: ");
            password = ReadLine();

            while (!correct)
            {
                if (username == "staff" && password == "today123")
                {
                    correct = true;
                    Staff();
                }
                else
                {
                    WriteLine("Incorrect Username or Password.");
                    Write("Enter you username: ");
                    username = ReadLine();
                    Write("Enter you password: ");
                    password = ReadLine();
                }


            }
        }

        public void Staff()
        {
            Clear();
            WriteLine("=======Staff Menu=======");
            WriteLine("1. Add a tool");
            WriteLine("2. Remove a tool");
            WriteLine("3. Register a new member");
            WriteLine("4. Remove a member");
            WriteLine("5. Display all the members who are borrowing a tool");
            WriteLine("6. Find a member's phone number");
            WriteLine("0. Return to main menu");
            WriteLine("=========================");
            Write("Select option from menu (0 to exit): ");

            string menuanswer = ReadLine();

            while (menuanswer != "1" || menuanswer != "2" || menuanswer != "0" || menuanswer != "3" || menuanswer != "4" || menuanswer != "5" || menuanswer != "6")
            {
                if (menuanswer == "0")
                {
                    Main();
                    break;
                }
                else if (menuanswer == "1")
                {
                    toolCollection.AddCategory();
                    break;
                }
                else if (menuanswer == "2")
                {
                    toolCollection.DeleteCategory();
                    break;
                }
                else if (menuanswer == "3")
                {
                    memberCollection.CreateMember();
                    break;
                }
                else if (menuanswer == "4")
                {
                    memberCollection.RemoveMember();
                    break;
                }
                else if (menuanswer == "5")
                {
                    memberCollection.DisplayBorrwers();
                    break;
                }
                else if (menuanswer == "6")
                {
                    memberCollection.FindbyPhoneNumber();
                    break;
                }
                Write("Please enter a valid response from 0-6: ");
                menuanswer = ReadLine();
            }
        }




        public void Member()
        {

            bool check = false;
            string menuanswer;
            int result;

            Clear();

            WriteLine("=======Member Menu=======");
            WriteLine("1. Display tools of a type");
            WriteLine("2. Borrow a tool");
            WriteLine("3. Return a tool");
            WriteLine("4. List tools I'm borrowing");
            WriteLine("5. Display top three most frequently borrowed tools");
            WriteLine("0. Return to main menu");
            WriteLine("=========================");
            Write("Select option from menu (0 to exit): ");

            menuanswer = ReadLine();

            while (menuanswer != "1" || menuanswer != "2" || menuanswer != "0" || menuanswer != "3" || menuanswer != "4" || menuanswer != "5") {
                if (menuanswer == "0") {
                    Main();
                    break;

                } else if (menuanswer == "1")
                {
                    toolCollection.ToolsCategory();
                    break;
                } else if (menuanswer == "2") {
                    toolCollection.BorrowTool(key);
                    break;
                } else if (menuanswer == "3")
                {
                    toolCollection.ReturnTool(key);
                } else if (menuanswer == "4") {
                    memberCollection.BorrowedTools(key);
                } else if (menuanswer == "5") {
                    toolCollection.topThreeTools();
                }
                Write("Please enter a valid response: ");
                 menuanswer = ReadLine();

            }

        }

        public void MemberLogin()
        {
            string phonenumber;
            int result = 0;
            bool check = false;

            Clear();
            Write("Enter your first name: ");
            string firstname = ReadLine();

            Clear();
            Write("Enter your last name: ");
            string lastname = ReadLine();

            Clear();
            Write("Enter your phone number: ");
            phonenumber = ReadLine();

            while (!check)
            {

                bool success = int.TryParse(phonenumber, out result);
                if (success)
                {
                    check = true;

                }
                else
                {
                    Write("Please enter a valid phone number: ");
                    phonenumber = ReadLine();
                    success = int.TryParse(phonenumber, out result);
                }

            }

            bool correct = false;
            bool found;

            while (!correct)
            {

                found = memberCollection.SearchMember(firstname, lastname, result);

                if (found)
                {
                    key = result;
                    correct = true;
                    Member();
                }

                WriteLine("Wrong Username or Password.");

                Write("Enter your first name: ");
                firstname = ReadLine();

                Write("Enter your last name: ");
                lastname = ReadLine();

                Write("Enter your phone number: ");
                phonenumber = ReadLine();

            }




        }

    }
}

