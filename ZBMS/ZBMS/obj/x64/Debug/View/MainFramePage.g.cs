﻿#pragma checksum "C:\Users\kabilan-13333\Desktop\ZohoBank\ZBMS\ZBMS\View\MainFramePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7DC1B9AAF30C5D0A1D0DBEB21558F059FCF849B2DB35D4627EEDE2B0029F0DAD"
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
    partial class MainFramePage : 
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
        private class MainFramePage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMainFramePage_Bindings
        {
            private global::ZBMS.MainFramePage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.TextBlock obj14;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj14TextDisabled = false;

            public MainFramePage_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 604 && columnNumber == 61)
                {
                    isobj14TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 14: // View\MainFramePage.xaml line 604
                        this.obj14 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
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

            // IMainFramePage_Bindings

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
                    this.dataRoot = (global::ZBMS.MainFramePage)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::ZBMS.MainFramePage obj, int phase)
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
                    // View\MainFramePage.xaml line 604
                    if (!isobj14TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj14, obj, null);
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
            case 2: // View\MainFramePage.xaml line 12
                {
                    this.WideCharacter = (global::Windows.UI.Xaml.Style)(target);
                }
                break;
            case 3: // View\MainFramePage.xaml line 20
                {
                    this.NarrowCharacter = (global::Windows.UI.Xaml.Style)(target);
                }
                break;
            case 4: // View\MainFramePage.xaml line 28
                {
                    this.WideExpandCharacter = (global::Windows.UI.Xaml.Style)(target);
                }
                break;
            case 5: // View\MainFramePage.xaml line 36
                {
                    this.NarrowExpandCharacter = (global::Windows.UI.Xaml.Style)(target);
                }
                break;
            case 6: // View\MainFramePage.xaml line 679
                {
                    this.FullFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            case 7: // View\MainFramePage.xaml line 675
                {
                    this.HomePageFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            case 8: // View\MainFramePage.xaml line 588
                {
                    this.LogoImage = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 9: // View\MainFramePage.xaml line 613
                {
                    this.ForwardButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ForwardButton).Click += this.ForwardButton_Click;
                }
                break;
            case 10: // View\MainFramePage.xaml line 644
                {
                    this.BackwardButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.BackwardButton).Click += this.BackWordButton_Click;
                }
                break;
            case 11: // View\MainFramePage.xaml line 607
                {
                    this.LastLoginTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12: // View\MainFramePage.xaml line 608
                {
                    this.LastLoginContentTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13: // View\MainFramePage.xaml line 603
                {
                    this.WelcomeTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14: // View\MainFramePage.xaml line 604
                {
                    this.UserNameTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15: // View\MainFramePage.xaml line 273
                {
                    this.HomeButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.HomeButton).Click += this.HomeButton_Click;
                }
                break;
            case 16: // View\MainFramePage.xaml line 309
                {
                    this.MoneyTransferButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.MoneyTransferButton).Click += this.MoneyTransferButton_Click;
                }
                break;
            case 17: // View\MainFramePage.xaml line 354
                {
                    this.MoneyTransferList = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.MoneyTransferList).ItemClick += this.MoneyTransferList_ItemClick;
                    ((global::Windows.UI.Xaml.Controls.ListView)this.MoneyTransferList).SelectionChanged += this.MoneyTransferList_SelectionChanged;
                }
                break;
            case 18: // View\MainFramePage.xaml line 379
                {
                    this.ProfileSettingsButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ProfileSettingsButton).Click += this.ProfileSettings_Click;
                }
                break;
            case 19: // View\MainFramePage.xaml line 423
                {
                    this.ProfileSettingsList = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ProfileSettingsList).SelectionChanged += this.ProfileSettingsList_SelectionChanged;
                }
                break;
            case 20: // View\MainFramePage.xaml line 441
                {
                    this.AccountSettingsButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.AccountSettingsButton).Click += this.AccountSettings_Click;
                }
                break;
            case 21: // View\MainFramePage.xaml line 484
                {
                    this.AccountSettingsList = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.AccountSettingsList).SelectionChanged += this.AccountSettingsList_SelectionChanged;
                }
                break;
            case 22: // View\MainFramePage.xaml line 502
                {
                    this.AboutUsButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.AboutUsButton).Click += this.AboutUsButton_Click;
                }
                break;
            case 23: // View\MainFramePage.xaml line 538
                {
                    this.SignOutButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.SignOutButton).Click += this.SignOut_Click;
                }
                break;
            case 24: // View\MainFramePage.xaml line 540
                {
                    this.SignOutCharacter = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 25: // View\MainFramePage.xaml line 546
                {
                    this.SignOutTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 26: // View\MainFramePage.xaml line 507
                {
                    this.AboutUsCharacter = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 27: // View\MainFramePage.xaml line 513
                {
                    this.AboutUsTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 28: // View\MainFramePage.xaml line 486
                {
                    this.ViewAccount = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                }
                break;
            case 29: // View\MainFramePage.xaml line 493
                {
                    this.ViewTransaction = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                }
                break;
            case 30: // View\MainFramePage.xaml line 494
                {
                    this.ViewTransactionTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 31: // View\MainFramePage.xaml line 487
                {
                    this.ViewAccountTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 32: // View\MainFramePage.xaml line 446
                {
                    this.AccountSettingsCharacter = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 33: // View\MainFramePage.xaml line 453
                {
                    this.AccountSettingsTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 34: // View\MainFramePage.xaml line 458
                {
                    this.ExpandCharacter3 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 35: // View\MainFramePage.xaml line 425
                {
                    this.ViewProfile = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                }
                break;
            case 36: // View\MainFramePage.xaml line 432
                {
                    this.EditProfile = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                }
                break;
            case 37: // View\MainFramePage.xaml line 433
                {
                    this.EditProfileTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 38: // View\MainFramePage.xaml line 426
                {
                    this.ViewProfileTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 39: // View\MainFramePage.xaml line 385
                {
                    this.ProfileSettingsCharacter = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 40: // View\MainFramePage.xaml line 391
                {
                    this.ProfileSettingsTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 41: // View\MainFramePage.xaml line 396
                {
                    this.ExpandCharacter2 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 42: // View\MainFramePage.xaml line 356
                {
                    this.SelfTransfer = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                }
                break;
            case 43: // View\MainFramePage.xaml line 363
                {
                    this.OtherCustomer  = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                }
                break;
            case 44: // View\MainFramePage.xaml line 370
                {
                    this.OtherBank = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                }
                break;
            case 45: // View\MainFramePage.xaml line 371
                {
                    this.OtherBankTransferTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 46: // View\MainFramePage.xaml line 364
                {
                    this.OtherCustomerTransferTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 47: // View\MainFramePage.xaml line 357
                {
                    this.SelfTransferTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 48: // View\MainFramePage.xaml line 319
                {
                    this.MoneyTransferCharacter = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 49: // View\MainFramePage.xaml line 325
                {
                    this.MoneyTransferTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 50: // View\MainFramePage.xaml line 330
                {
                    this.ExpandCharacter1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 51: // View\MainFramePage.xaml line 280
                {
                    this.HomeCharacter = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 52: // View\MainFramePage.xaml line 286
                {
                    this.HomeTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 53: // View\MainFramePage.xaml line 185
                {
                    this.ProfileButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 54: // View\MainFramePage.xaml line 195
                {
                    this.ProfileImage = (global::Windows.UI.Xaml.Shapes.Ellipse)(target);
                }
                break;
            case 55: // View\MainFramePage.xaml line 203
                {
                    this.MoreOptions = (global::Windows.UI.Xaml.Controls.Flyout)(target);
                }
                break;
            case 56: // View\MainFramePage.xaml line 208
                {
                    this.ViewProfileButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ViewProfileButton).Click += this.ViewProfileButton_Click;
                }
                break;
            case 57: // View\MainFramePage.xaml line 225
                {
                    this.EditProfileButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.EditProfileButton).Click += this.EditProfileButton_Click;
                }
                break;
            case 58: // View\MainFramePage.xaml line 242
                {
                    global::Windows.UI.Xaml.Controls.HyperlinkButton element58 = (global::Windows.UI.Xaml.Controls.HyperlinkButton)(target);
                    ((global::Windows.UI.Xaml.Controls.HyperlinkButton)element58).Click += this.HyperlinkButton_Click;
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
            case 1: // View\MainFramePage.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    MainFramePage_obj1_Bindings bindings = new MainFramePage_obj1_Bindings();
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
