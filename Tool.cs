using System;
namespace AssignmentIFN664
{
	public class Tool
	{
		public string Name { get; set; }
		public int Quantity { get; set; }
		public int borrowCount = 0;
		public int AvalibleQuantity { get; set; }

		public string GetName()
		{
			return Name;
		}

		public void BorrowCount()
		{
			borrowCount++;
			AvalibleQuantity--;

		}
		public int GetborrowCount()
		{
			return borrowCount;
		}
		public void ReturnTool()
		{
			AvalibleQuantity++;
		}

		public bool ToolInUse() {
			if (AvalibleQuantity != Quantity)
			{
				return true;
			}
			return false;
		}

		public bool CheckavailableQuantity() {
		if (AvalibleQuantity != 0 )
        {
			return true;
        }
		return false;
		}

		public override string ToString()
		{
			return ($"Tool Name: {Name} Quantity: {Quantity}");
		}


	}
}

