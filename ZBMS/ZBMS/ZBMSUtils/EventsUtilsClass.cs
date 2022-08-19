﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBMS.ZBMSUtils
{
    public enum MenuOptions
    {
        Dashboard,SelfTransfer,OtherCustomerTransfer,OtherBankTransfer,ViewProfile,EditProfile,ViewAccount,ViewTransaction,Transactions
    }
    public delegate void PageChanged(MenuOptions name);
    public  class EventsUtilsClass
    {
       
        public static event PageChanged OnPageChanged;
        public static void InvokePageChanged(MenuOptions name)
        {
            OnPageChanged?.Invoke(name);
        }


    }
}
