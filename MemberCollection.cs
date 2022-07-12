using System;
using System.Collections;
using System.Collections.Generic;
using System;
using static System.Console;

namespace AssignmentIFN664
{
    public class MemberCollection
    {

        public static Hashtable memberCollection = new();
        public static MainMenu mainMenu = new();

        public void CreateMember()
        {
            bool check = false;
            bool exitcheck = false;

            string phonenumber;
            int result;
            int exitresult;

            //adding a new member
            Member newMember = new Member();

            Clear();
            Write("Enter members first name: ");
            string firstname = ReadLine();
            newMember.firstname = firstname;
            Clear();
            Write("Enter members last name: ");
            string lastname = ReadLine();
            newMember.lastname = lastname;
            Clear();

            Write("Enter members phone number: ");
            phonenumber = ReadLine();

            while (!check)
            {

                bool success = int.TryParse(phonenumber, out result);
                if (success)
                {
                    newMember.phonenumber = result;
                    check = true;

                }
                else
                {
                    Write("Please enter a valid response: ");
                    phonenumber = ReadLine();
                    success = int.TryParse(phonenumber, out result);
                }

            }

            try
            {
                memberCollection.Add(phonenumber, newMember);
                WriteLine("Member Added.");
            }
            catch (ArgumentException)
            {
                Clear();
                WriteLine("Phone number in use.\nPress 0 to go back: ");
                string input1 = ReadLine();

                while (input1 != "0")
                {
                    if (input1 == "0")
                    {
                        mainMenu.Staff();
                        break;
                    }
                    Write("Press 0 to go back: ");
                    input1 = ReadLine();
                }

            }

            //Listing all memebers
            Display();

            Write("Press any key to exit: ");
            string input = ReadLine();
            mainMenu.Staff();
           
        }

        public void Display() {
            int count = 0;
            foreach (DictionaryEntry de in memberCollection)
            {
                count++;
                Member temp = (Member)de.Value;
                WriteLine($"{count}: {temp.firstname} {temp.lastname}, Ph:{temp.phonenumber}");
            }
        }

        public  void RemoveMember()
        {
            Clear();
 
            // Chaing to see if all enteries are null 
            if (memberCollection.Count == 0)
            {
                WriteLine("Nobody members exist!");
            }
            else
            {

                Write("Enter members phone number: ");
                string phonenumber = ReadLine();
               
                if (memberCollection.ContainsKey(phonenumber))
                {
                    WriteLine("Member Removed.");
                    memberCollection.Remove(phonenumber);
                    Display();
                }
                else
                {
                    WriteLine("Nobody with this phone number can be found!");
                }

            }
            Write("Press any key to exit: ");
            string input = ReadLine();
            mainMenu.Staff();
        }

        public void FindbyPhoneNumber()
        {
            Clear();
            int count = 0;
            int exitresult;
            bool exitcheck = false;

            Clear();
            Write("Enter members first name: ");
            string firstname = ReadLine();
            Clear();
            Write("Enter members last name: ");
            string lastname = ReadLine();
            Clear();

            foreach (DictionaryEntry de in memberCollection)
            {
                Member temp = (Member)de.Value;
                if (temp.firstname == firstname && temp.lastname == lastname)
                {
                    count++;
                    WriteLine($"Member's Name: {temp.firstname} {temp.lastname}, Phone Number: {temp.phonenumber} ");
                    WriteLine();
                }
            }

            //Adding this sentence if nobody is borrowing a tool to prevent blankness.
            if (count == 0)
            {
                WriteLine("Nobody with this phone number can be found!");
            }

            Write("Press any key to exit: ");
            string input = ReadLine();
            mainMenu.Staff();

        }

        public void DisplayBorrwers()
        {
            Clear();
            int count = 0;

            WriteLine("Members who are borrowing a tool");

            foreach (DictionaryEntry de in memberCollection)
            {
                Member temp = (Member)de.Value;
                if (temp.borrowcount > 0)
                {
                    count++;
                    WriteLine($"{count}: { temp.firstname}");
                }
            }

            //Adding this sentence if nobody is borrowing a tool to prevent blankness. 
            if (count == 0)
            {
                WriteLine("Nobody is borrowing a tool");
            }
           
            Write("Press any key to exit: ");
            string input = ReadLine();
            mainMenu.Staff();

        }
        public void BorrowedTools(int key)
        {
            Clear();
            int count = 0;

            foreach (DictionaryEntry de in memberCollection)
            {
                Member temp = (Member)de.Value;
                if (temp.phonenumber == key)
                {
                    WriteLine("Tools borrowed");
                    count++;
                    temp.showToolsBorrowed();
              
                }
            }

            ////Adding this sentence if nobody is borrowing a tool to prevent blankness. 
            //if (count == 0) {
            //    Clear();
            //    WriteLine("You are not borrowing a tool!");
            //    Write("Press any key to exit: ");
            //    string answer = ReadLine();
            //    mainMenu.Member();
            //}

            Write("Press any key to exit: ");
            string input = ReadLine();
            mainMenu.Member();

        }
        public bool SearchMember(string firstname, string lastname, int phonenumber)
        {
            foreach (DictionaryEntry de in memberCollection)
            {
                try
                {
                    Member temp = (Member)de.Value;
                    if (temp.firstname == firstname && temp.lastname == lastname && temp.phonenumber == phonenumber)
                    {
                        return true;
                    }
                }
                catch (NullReferenceException)
                {
                    continue;
                }


            }
            return false;
        }

        public Member SearchMemberbyKey(int key)
        {
            foreach (DictionaryEntry de in memberCollection)
            {
                try
                {
                    Member temp = (Member)de.Value;
                    if (temp.phonenumber == key)
                    {
                        return temp;
                    }
                }
                catch (NullReferenceException)
                {
                    continue;
                }


            }
            return null;
        }
    }
}



    





