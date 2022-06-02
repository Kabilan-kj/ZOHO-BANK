using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBMS
{
    public class ShortcutMenuItemManager
    {
        static List<ShortcutMenuItems> ShortCutMenuItems = new List<ShortcutMenuItems>();
        static List<ShortcutMenuItems> MoneyTransferMenuItems = new List<ShortcutMenuItems>();


        public static List<ShortcutMenuItems> GetShortcutMenuItems()
        {
            if(ShortCutMenuItems.Count()==0)
            {
                PopulateShortcutMenuItems();
            }
            return ShortCutMenuItems;   
        }

        private static void PopulateShortcutMenuItems()
        {

            ShortCutMenuItems.Add(new ShortcutMenuItems { ImageLocation = "Assets/CreateNewAccount1.png", ItemName = "Create New Account" , ItemId = 1 });
            ShortCutMenuItems.Add(new ShortcutMenuItems { ImageLocation = "Assets/ViewTransactions1.png", ItemName = "View Transaction", ItemId = 2 });
            ShortCutMenuItems.Add(new ShortcutMenuItems { ImageLocation = "Assets/Loan1.png", ItemName = "Loan Payment", ItemId = 3 });
        }

        public static List<ShortcutMenuItems> GetMoneyTransferMenuItems()
        {
            if (MoneyTransferMenuItems.Count() == 0)
            {
                PopulateMoneyTransferMenuItems();
            }
            return MoneyTransferMenuItems;
        }

        private static void PopulateMoneyTransferMenuItems()
        {
            MoneyTransferMenuItems.Add(new ShortcutMenuItems { ImageLocation = "Assets/MoneyTransfer1.jpg", ItemName = "Self", ItemId = 1 });
            MoneyTransferMenuItems.Add(new ShortcutMenuItems { ImageLocation = "Assets/MoneyTransfer3.png", ItemName = "Other Customer", ItemId = 2 });
            MoneyTransferMenuItems.Add(new ShortcutMenuItems { ImageLocation = "Assets/MoneyTransfer2.jpg", ItemName = "Other Bank", ItemId = 3 });
            MoneyTransferMenuItems.Add(new ShortcutMenuItems { ImageLocation = "Assets/Deposit1.png", ItemName = "Deposit", ItemId = 4 });
        }

    }
}
