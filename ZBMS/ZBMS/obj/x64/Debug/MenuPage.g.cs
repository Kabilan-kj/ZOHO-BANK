﻿#pragma checksum "C:\Users\kabilan-13333\Desktop\ZohoBank\ZBMS\ZBMS\MenuPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9BA51400EB10614C1B9968316C776FCA0199D310733FDEEDE3B15C9353108EBE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZBMS
{
    partial class MenuPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class MenuPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMenuPage_Bindings
        {
            private global::ZBMS.MenuPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.TextBlock obj7;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj7TextDisabled = false;

            public MenuPage_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 332 && columnNumber == 75)
                {
                    isobj7TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 7: // MenuPage.xaml line 332
                        this.obj7 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IMenuPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::ZBMS.MenuPage)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::ZBMS.MenuPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_customer(obj.customer, phase);
                    }
                }
            }
            private void Update_customer(global::DataModule.CustomerData obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_customer_Name(obj.Name, phase);
                    }
                }
            }
            private void Update_customer_Name(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MenuPage.xaml line 332
                    if (!isobj7TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj7, obj, null);
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MenuPage.xaml line 75
                {
                    this.MenuGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // MenuPage.xaml line 341
                {
                    this.ContentFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            case 4: // MenuPage.xaml line 335
                {
                    this.LastLoginTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // MenuPage.xaml line 336
                {
                    this.LastLoginContentTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // MenuPage.xaml line 331
                {
                    this.WelcomeTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // MenuPage.xaml line 332
                {
                    this.UserNameTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // MenuPage.xaml line 81
                {
                    this.LogoImage = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 9: // MenuPage.xaml line 243
                {
                    this.SettingsButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.SettingsButton).Click += this.SettingsButton_Click;
                }
                break;
            case 10: // MenuPage.xaml line 250
                {
                    this.InfoButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.InfoButton).Click += this.InfoButton_Click;
                }
                break;
            case 11: // MenuPage.xaml line 256
                {
                    this.LogoutButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.LogoutButton).Click += this.LogoutButton_Click;
                }
                break;
            case 12: // MenuPage.xaml line 262
                {
                    this.ThemeButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ThemeButton).Click += this.ThemeButton_Click;
                }
                break;
            case 13: // MenuPage.xaml line 103
                {
                    this.DashboardButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.DashboardButton).Click += this.DashboardButton_Click;
                }
                break;
            case 14: // MenuPage.xaml line 112
                {
                    this.MoneyTransferButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.MoneyTransferButton).Click += this.MoneyTransferButton_Click;
                }
                break;
            case 15: // MenuPage.xaml line 131
                {
                    this.MoneyTransferList = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.MoneyTransferList).SelectionChanged += this.MoneyTransferList_SelectionChanged;
                }
                break;
            case 16: // MenuPage.xaml line 156
                {
                    this.AccountsButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.AccountsButton).Click += this.AccountsButton_Click;
                }
                break;
            case 17: // MenuPage.xaml line 171
                {
                    this.AccountsList = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.AccountsList).SelectionChanged += this.AccountsList_SelectionChanged;
                }
                break;
            case 18: // MenuPage.xaml line 190
                {
                    this.ProfileButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ProfileButton).Click += this.ProfileButton_Click;
                }
                break;
            case 19: // MenuPage.xaml line 209
                {
                    this.ProfileList = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ProfileList).SelectionChanged += this.ProfileList_SelectionChanged;
                }
                break;
            case 20: // MenuPage.xaml line 228
                {
                    this.TransactionsButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.TransactionsButton).Click += this.TransactionsButton_Click;
                }
                break;
            case 21: // MenuPage.xaml line 211
                {
                    this.ViewProfile = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                }
                break;
            case 22: // MenuPage.xaml line 218
                {
                    this.EditProfile = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                }
                break;
            case 23: // MenuPage.xaml line 219
                {
                    this.EditProfileTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 24: // MenuPage.xaml line 212
                {
                    this.ViewProfileTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 25: // MenuPage.xaml line 203
                {
                    this.Downarrow3 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 26: // MenuPage.xaml line 173
                {
                    this.ViewAccount = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                }
                break;
            case 27: // MenuPage.xaml line 180
                {
                    this.ViewTransaction = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                }
                break;
            case 28: // MenuPage.xaml line 181
                {
                    this.ViewTransactionTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 29: // MenuPage.xaml line 174
                {
                    this.ViewAccountTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 30: // MenuPage.xaml line 167
                {
                    this.Downarrow2 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 31: // MenuPage.xaml line 133
                {
                    this.SelfTransfer = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                }
                break;
            case 32: // MenuPage.xaml line 140
                {
                    this.OtherCustomer  = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                }
                break;
            case 33: // MenuPage.xaml line 147
                {
                    this.OtherBank = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                }
                break;
            case 34: // MenuPage.xaml line 148
                {
                    this.OtherBankTransferTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 35: // MenuPage.xaml line 141
                {
                    this.OtherCustomerTransferTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 36: // MenuPage.xaml line 134
                {
                    this.SelfTransferTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 37: // MenuPage.xaml line 124
                {
                    this.Downarrow1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // MenuPage.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    MenuPage_obj1_Bindings bindings = new MenuPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}
