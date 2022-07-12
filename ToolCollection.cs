
using System.Collections;
using static System.Console;
using static AssignmentIFN664.MemberCollection;
namespace AssignmentIFN664;
public class ToolCollection
{
    public static object[,,] toolCollection = new object[9,6,3];

    public static MemberCollection memberCollection = new MemberCollection();
    public static MainMenu mainMenu = new();
    public static int key = 0;

    readonly string[,] categories = {
  {
    "Line Trimmers",
    "Lawn Mowers",
    "Hand Tools",
    "Wheelbarrows",
    "Garden Power Tools",
    "Electric Tools"
  },
  {
    "Scrapers",
    "Floor Lasers",
    "Floor Levelling Tools",
    "Floor Levelling Materials",
    "Floor Hand Tools",
    "Tiling Tools"
  },
  {
    "Hand Tools",
    "Electric Fencing",
    "Steel Fencing Tools",
    "Power Tools",
    "Fencing Accessories",
    "Metal Fencing Tools"
  },
  {
    "Distance Tools",
    "Laser Measurer",
    "Measuring Jugs",
    "Temperature & Humidity Tools",
    "Levelling Tools",
    "Markers"
  },
  {
    "Draining",
    "Car Cleaning",
    "Vacuum",
    "Pressure Cleaners",
    "Pool Cleaning",
    "Floor Cleaning"
  },
  {
    "Sanding Tools",
    "Brushes",
    "Rollers",
    "Paint Removal Tools",
    "Paint Scrapers",
    "Sprayers"
  },
  {
    "Voltage Tester",
    "Oscilloscopes",
    "Thermal Imaging",
    "Data Test Tool",
    "Insulation Testers",
    "Other Voltage Testers"
  },
  {
    "Test Equipment",
    "Safety Equipment",
    "Basic Hand tools",
    "Circuit Protection",
    "Cable Tools",
    "First Aid Tools"
  },
  {
    "Jacks",
    "Air Compressors",
    "Battery Chargers",
    "Socket Tools",
    "Braking",
    "Drivetrain"
  },
};

    public void AddCategory()
    {
        Clear();

        Write("Enter a Tool Category: ");
        WriteLine();
        WriteLine("========================");
        WriteLine("1. Gardening tools");
        WriteLine("2. Flooring tools");
        WriteLine("3. Fencing tools");
        WriteLine("4. Measuring tools");
        WriteLine("5. Cleaning tools");
        WriteLine("6. Painting tools");
        WriteLine("7. Electronic tools");
        WriteLine("8. Electricity tools");
        WriteLine("9. Automotive tools");
        WriteLine("0. Return to main menu");
        WriteLine("=========================");
        Write("Select option from menu (0 to exit): ");
        string menuanswer = ReadLine();

        while (menuanswer != "1" || menuanswer != "0" || menuanswer != "2" || menuanswer != "0" || menuanswer != "3" ||
            menuanswer != "4" || menuanswer != "5" || menuanswer != "6" || menuanswer != "7" || menuanswer != "8" || menuanswer != "9")
        {
            if (menuanswer == "0")
            {
                mainMenu.Staff();
                break;
            }
            else if (menuanswer == "1" || menuanswer == "2" || menuanswer == "0" || menuanswer == "3" ||
          menuanswer == "4" || menuanswer == "5" || menuanswer == "6" || menuanswer == "7" || menuanswer == "8" || menuanswer == "9") {
                AddType(Convert.ToInt32(menuanswer));
                break;
            }
            Write("Please enter a valid Tool Category from 1-9 or press 0 to exit: ");
            menuanswer = ReadLine();
        }


    }

    public void AddType(int category)
    {

        Clear();

        //Printing the types and categories
        for (int i = 0; i < categories.GetLength(1); i++)
        {
            WriteLine($"{i + 1}: { categories[category - 1, i]}");
        }

        Write("Please enter a type number or 0 to go back: ");
        string menuanswer = ReadLine();

        while (menuanswer != "1" || menuanswer != "2" || menuanswer != "0" || menuanswer != "3" ||
            menuanswer != "4" || menuanswer != "5" || menuanswer != "6")
        {
            if (menuanswer == "0")
            {
                AddCategory();

            }
            else if (menuanswer == "1" || menuanswer == "2" || menuanswer == "0" || menuanswer == "3" ||
            menuanswer == "4" || menuanswer == "5" || menuanswer == "6")
            {
                AddTool(category, Convert.ToInt32(menuanswer));
                break;
            }
            Write("Please enter a valid Tool Category from 1-6 or press 0 to exit: ");
            menuanswer = ReadLine();
        }

    }
    public void AddTool(int category, int type)
    {
        int result = 0;
        bool check = false;

        Clear();
        Write("Please enter tool name: ");
        string toolName = ReadLine();
        bool toolfound = ToolNameExist(toolName);
        if (toolfound)
        {
            WriteLine("Tool already exist!");
        }
        else { 
        Clear();

        Write("Please enter tool quantity: ");
        string toolQuantity = ReadLine();

        //Checking if the quantity added is in fact a number	
        while (!check)
        {

            bool working = int.TryParse(toolQuantity, out result);
            if (working)
            {
                check = true;
            }
            else
            {
                Write("Please enter a valid number: ");
                toolQuantity = ReadLine();
                working = int.TryParse(toolQuantity, out result);
            }

        }

        //Creating the new tool 
        Tool newTool = new();
        newTool.Name = toolName;
        
        newTool.Quantity = result;
        newTool.AvalibleQuantity = result;

            int spacesLeft = 3;
         

            //Adding tool to tool collection 
            for (int i = 0; i < toolCollection.GetLength(2); i++)
        {

                if (toolCollection[category - 1, type - 1, i] == null)
                {
                    toolCollection[category - 1, type - 1, i] = newTool;
                    WriteLine("Tool Added.");

                    //exiting the loop 
                    i = toolCollection.GetLength(2);
                }
                else {
                    spacesLeft--;
                }
         }

            if (spacesLeft < 1)
            {
                WriteLine("Can't add more tools to this type!");
            }
            else {
                //Display all tools
                Display();
            }
        }

        Write("Press any key to exit: ");
        string input = ReadLine();
        mainMenu.Staff();
    }

    public static void Display() {
        //displaying all tools
        int count = 0;
        for (int i = 0; i < toolCollection.GetLength(0); i++)
        {
            for (int j = 0; j < toolCollection.GetLength(1); j++)
            {
                for (int k = 0; k < toolCollection.GetLength(2); k++)
                {
                    count++;
                    WriteLine($"{count}: {toolCollection[i, j, k]}");
                }
            }
        }
    }

    public void BorrowTool(int key)
    {
        Clear();

        int count = 0;

        Write("Enter tool name: ");
        string toolName = ReadLine();
        //display all tools
      
        foreach (Tool tool in toolCollection)
        {
            try
            {
                if (tool.Name == toolName)
                {
                    bool check = tool.CheckavailableQuantity();
                    if (check)
                    {
                        //Adding the borrow to the member
                        Member temp1 = memberCollection.SearchMemberbyKey(key);
                        if (temp1 != null)
                        {
                            //Checking borrowcount 
                            bool checkborrowcount = temp1.BorrowLengthExceeded();
                            if (checkborrowcount == true)
                            {
                                WriteLine("You have borrowed more than 5 tools! Return tools to borrow!");
                                count++;
                                break;
                             }
                            else
                            {
                                count++;
                                tool.BorrowCount();
                                temp1.BorrowCount();
                                int borrowcount = temp1.GetBorrowCount();
                                WriteLine($"Tool borrowed! You have borrowed {borrowcount} tools!");
                                temp1.borrwedTools.Add(toolName);
                                break;
                            }
                        }
                      }
                        count++;
                        WriteLine("All tools in use. Find another tool. ");
                        break;
                    }
            }
            catch (NullReferenceException)
            {
                continue;
            }
        }

        if (count == 0)
        {
            WriteLine("Tool does not exist!");
        }

        Write("Press any key to exit: ");
        string input = ReadLine();
        mainMenu.Member();
    }


    public void ReturnTool(int key)
    {
        Clear();

        int count = 0;

        Write("Enter tool name: ");
        string toolName = ReadLine();
        //display all tools
        foreach (Tool tool in toolCollection)
        {
            try
            {
                if (tool.Name == toolName)
                {
                 
                    Member temp1 = memberCollection.SearchMemberbyKey(key);
                    if (temp1 != null) {
                        //Checking name of the tool is in the users borrow list 
                        if (temp1.borrwedTools.Contains(toolName))
                        {
                            tool.ReturnTool();
                            WriteLine("Tool returned!");
                            count++;
                            temp1.ReturnTool();
                            temp1.borrwedTools.Remove(toolName);
                        }
                        else {
                            count++;
                            WriteLine("You have not borrowed that tool!");
                        }


                    }
                }
            }
            catch (NullReferenceException)
            {
                continue;
            }
        }
        if (count == 0)
        {
            WriteLine("Tool does not exist!");
        }

        Write("Press any key to exit: ");
        string input = ReadLine();
        mainMenu.Member();

    }

    public void ToolsCategory()
    {
        Clear();

        Write("Enter a Tool Category: ");
        WriteLine();
        WriteLine("========================");
        WriteLine("1. Gardening tools");
        WriteLine("2. Flooring tools");
        WriteLine("3. Fencing tools");
        WriteLine("4. Measuring tools");
        WriteLine("5. Cleaning tools");
        WriteLine("6. Painting tools");
        WriteLine("7. Electronic tools");
        WriteLine("8. Electricity tools");
        WriteLine("9. Automotive tools");
        WriteLine("0. Return to main menu");
        WriteLine("=========================");
        Write("Select option from menu (0 to exit): ");
        string menuanswer = ReadLine();

        while (menuanswer != "1" || menuanswer != "0" || menuanswer != "2" || menuanswer != "0" || menuanswer != "3" ||
            menuanswer != "4" || menuanswer != "5" || menuanswer != "6" || menuanswer != "7" || menuanswer != "8" || menuanswer != "9")
        {
            if (menuanswer == "0")
            {
                mainMenu.Member();
                break;
            }
            else if (menuanswer == "1" || menuanswer == "2" || menuanswer == "0" || menuanswer == "3" ||
            menuanswer == "4" || menuanswer == "5" || menuanswer == "6" || menuanswer == "7" || menuanswer == "8" || menuanswer == "9")
            {
                ToolsType(Convert.ToInt32(menuanswer));
                break;
            }
            Write("Please enter a valid Tool Category from 1-9 or press 0 to exit: ");
            menuanswer = ReadLine();
        }




    }

    public void ToolsType(int category)
    {

        Clear();

        //Printing the types and categories
        for (int i = 0; i < categories.GetLength(1); i++)
        {
            WriteLine($"{i + 1}: { categories[category - 1, i]}");
        }

        Write("Please enter a type number or 0 to go back: ");
        string menuanswer = ReadLine();

        while (menuanswer != "1" || menuanswer != "2" || menuanswer != "0" || menuanswer != "3" ||
            menuanswer != "4" || menuanswer != "5" || menuanswer != "6")
        {
            if (menuanswer == "0")
            {
                AddCategory();

            }
            else if (menuanswer == "1" || menuanswer == "2" || menuanswer == "0" || menuanswer == "3" ||
            menuanswer == "4" || menuanswer == "5" || menuanswer == "6")
            {
                ToolsofaType(category, Convert.ToInt32(menuanswer));
                break;
            }
            Write("Please enter a valid Tool Category from 1-6 or press 0 to exit: ");
            menuanswer = ReadLine();
        }

    }

    public void ToolsofaType(int category, int type) {
        int count = 0;

        Clear();

        for (int i = 0; i < toolCollection.GetLength(2); i++)
        {
            if (toolCollection[category - 1, type - 1, i] != null) {
                count++;
                WriteLine(toolCollection[category - 1, type - 1, i]);
            }
        }

        if (count == 0)
        {
            WriteLine("There are no tools in this type!");
        }

        Write("Press any key to exit : ");
        string input = ReadLine();
         mainMenu.Member();
        

    }

    public void DeleteCategory()
    {
        Clear();

        Write("Enter a Tool Category: ");
        WriteLine();
        WriteLine("========================");
        WriteLine("1. Gardening tools");
        WriteLine("2. Flooring tools");
        WriteLine("3. Fencing tools");
        WriteLine("4. Measuring tools");
        WriteLine("5. Cleaning tools");
        WriteLine("6. Painting tools");
        WriteLine("7. Electronic tools");
        WriteLine("8. Electricity tools");
        WriteLine("9. Automotive tools");
        WriteLine("0. Return to main menu");
        WriteLine("=========================");
        Write("Select option from menu (0 to exit): ");
        string menuanswer = ReadLine();

        while (menuanswer != "1" || menuanswer != "0" || menuanswer != "2" || menuanswer != "0" || menuanswer != "3" ||
            menuanswer != "4" || menuanswer != "5" || menuanswer != "6" || menuanswer != "7" || menuanswer != "8" || menuanswer != "9")
        {
            if (menuanswer == "0")
            {
                mainMenu.Staff();
                break;
            }
            else if (menuanswer == "1" || menuanswer == "2" || menuanswer == "0" || menuanswer == "3" ||
          menuanswer == "4" || menuanswer == "5" || menuanswer == "6" || menuanswer == "7" || menuanswer == "8" || menuanswer == "9")
            {
                DeleteType(Convert.ToInt32(menuanswer));
                break;
            }
            Write("Please enter a valid Tool Category from 1-9 or press 0 to exit: ");
            menuanswer = ReadLine();
        }


    }

    void DeleteType(int category)
    {

        Clear();

        //Printing the types and categories
        for (int i = 0; i < categories.GetLength(1); i++)
        {
            WriteLine($"{i + 1}: { categories[category - 1, i]}");
        }

        Write("Please enter a type number or 0 to go back: ");
        string menuanswer = ReadLine();

        while (menuanswer != "1" || menuanswer != "2" || menuanswer != "0" || menuanswer != "3" ||
            menuanswer != "4" || menuanswer != "5" || menuanswer != "6")
        {
            if (menuanswer == "0")
            {
                AddCategory();

            }
            else if (menuanswer == "1" || menuanswer == "2" || menuanswer == "0" || menuanswer == "3" ||
            menuanswer == "4" || menuanswer == "5" || menuanswer == "6")
            {
                DeleteTool(category, Convert.ToInt32(menuanswer));
                break;
            }
            Write("Please enter a valid Tool Category from 1-6 or press 0 to exit: ");
            menuanswer = ReadLine();
        }



    }


    void DeleteTool(int category, int type)
    {
        int position = 0;

        List<object> arr = new List<object>();
        Clear();

        Write("Enter tool name: ");
        string toolName = ReadLine();


        //Checking if tool is in use
        foreach (Tool tool in toolCollection)
        {
            try
            {
                if (tool.Name == toolName)
                {
                    if (tool.ToolInUse() == true)
                    {
                        WriteLine("Cannot delete tool. Tool in use!");
                        WriteLine();
                        Write("Press any key to exit : ");
                        string input = ReadLine();
                        mainMenu.Staff();
                    }
                    else
                    {
                        //putting all of the objects in a seperate list
                        for (int i = 0; i < toolCollection.GetLength(2); i++)
                        {
                            arr.Add(toolCollection[category - 1, type - 1, i]);
                        }

                        //This loop get the position of the tool for deletion 
                        foreach (Tool temp in arr)
                        {
                            try
                            {
                                if (temp.Name == toolName)
                                {
                                    break;
                                }

                            }
                            catch (NullReferenceException)
                            {
                                continue;
                            }

                            position++;
                        }

                        //Deleting the tool from the tool collection
                        toolCollection[category - 1, type - 1, position] = null;
                        WriteLine("Tool Deleted!");

                        //Display all tools
                        Display();

                        Write("Press any key to exit : ");
                        string input = ReadLine();
                        mainMenu.Staff();
                    }

                }
            }
            catch (NullReferenceException)
            {
                continue;
            }

        }
        WriteLine("Tool doesn't exist!");
        Write("Press any key to exit : ");
        string answer = ReadLine();
        mainMenu.Staff();

    }

    public static bool ToolNameExist(string toolName) {

        bool found = false; 
        foreach (Tool tool in toolCollection) {
            try { 
            if (tool.Name == toolName) {
                    found = true;
                    break;
 
            }
            }
            catch (NullReferenceException)
            {
                continue;
            }
        }
        return found; 
    }

    public void topThreeTools()
    {
        Clear();

        List<Tool> tools = new();
        List<Tool> listOne = new();
        List<Tool> listTwo = new();

        //Copies items in 3D into list to sort 
        foreach (Tool tool in toolCollection)
        {
            //Skipping over all the null values and adding tools that have been borrowed 
            if (tool != null && tool.borrowCount > 0)
            {
                tools.Add(tool);
            }
        }

        //Checking if the tool count is less than 3, if so prinnts a statement saying there are less then 3 tools have been borrowed 
        if (tools.Count < 3)
        {
            WriteLine("Less then 3 tools have been borrowed! Borrow 3 or more tools to get the top 3!");
        }
        else
        {
            //Adding the tools to the first list    
            for (int i = 0; i < (tools.Count / 2); i++)
            {

                listOne.Add(tools[i]);
            }


            //Adding the tools to the second list    
            for (int i = (tools.Count / 2); i < tools.Count; i++)
            {
                listTwo.Add(tools[i]);
            }

            //Sorting the lists 
            listOne.Sort(delegate (Tool x, Tool y)
            {
                return x.borrowCount.CompareTo(y.borrowCount);
            });

            listTwo.Sort(delegate (Tool x, Tool y)
            {
                return x.borrowCount.CompareTo(y.borrowCount);
            });

            // Merge the list 
            merge(listOne, listTwo);
        }
        Write("Press any key to exit: ");
        string input = ReadLine();
        mainMenu.Member();

    }


    void merge(List<Tool> listOne, List<Tool> listTwo)
    {

        List<Tool> tempList = new();
        List<Tool> top3 = new();

        while (listOne.Count != 0 && listTwo.Count != 0)
        {
            // Copy item from first subarray
            if (listOne[0].borrowCount > listTwo[0].borrowCount)
            {
                tempList.Add(listTwo[0]);
                listTwo.Remove(listTwo[0]);
            }
            // Copy item from first subarray
            else
            {
                tempList.Add(listOne[0]);
                listOne.Remove(listOne[0]);
            }

        }

        // Copy remainder of first subarray, if any
        while (listOne.Count != 0)
        {
            tempList.Add(listOne[0]);
            listOne.Remove(listOne[0]);
        }

        // Copy remainder of second subarray, if any
        while (listTwo.Count != 0)
        {
            tempList.Add(listTwo[0]);
            listTwo.Remove(listTwo[0]);
        }

        // returning the merged array
        int count = 0;
        for (int i = tempList.Count - 1; i >= 0; i--)
        {
            if (count < 3)
            {
                top3.Add(tempList[i]);
            }
            count++;
        }

        //Returning the top 3 Tools 
        WriteLine("Top 3 borrowed tools are: ");

        foreach (Tool tool in top3)
        {
            WriteLine($"Tool: {tool.Name}, Borrow Count: {tool.borrowCount}");
        }
    }

}


