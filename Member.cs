using System;
using static System.Console;
namespace AssignmentIFN664
{
	public class Member
	{

		public string firstname { get; set; }
		public string lastname { get; set; }
		public int phonenumber { get; set; }
        public int borrowcount = 0;
        public List<string> borrwedTools  = new ();

        public void BorrowCount()
		{
			borrowcount++;
		}
        public void ReturnTool()
        {
            borrowcount--;
        }
        public int GetBorrowCount()
		{
            return borrowcount;
        }
        public void showToolsBorrowed() {

            if (borrwedTools.Count == 0) {
                Clear();
                WriteLine("You are not borrowing a tool!");
            }
            for (int i = 0; i < borrwedTools.Count; i++) {
                WriteLine($"{i + 1}: {borrwedTools[i]}");
            }
        }

        public bool BorrowLengthExceeded()
        {
            if (borrowcount >= 5)
            {
                return true;
            }
            else {
                return false;
            }
        }

        public override string ToString()
        {

            return $"{firstname} {lastname}";

        }
    }
}

