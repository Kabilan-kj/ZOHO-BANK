﻿#pragma checksum "C:\Users\kabilan-13333\Desktop\ZohoBank\ZBMS\ZBMS\View\OtherCustomerTransferPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "98AADF9DF549E393541118319FCE844922D3A8BF26760C089C26B7B1C6A938BC"
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
    partial class OtherCustomerTransferPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class OtherCustomerTransferPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IOtherCustomerTransferPage_Bindings
        {
            private global::ZBMS.OtherCustomerTransferPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.ComboBox obj14;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj14ItemsSourceDisabled = false;

            public OtherCustomerTransferPage_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 75 && columnNumber == 27)
                {
                    isobj14ItemsSourceDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 14: // View\OtherCustomerTransferPage.xaml line 71
                        this.obj14 = (global::Windows.UI.Xaml.Controls.ComboBox)target;
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

            // IOtherCustomerTransferPage_Bindings

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
                    this.dataRoot = (global::ZBMS.OtherCustomerTransferPage)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::ZBMS.OtherCustomerTransferPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_FromUserAccounts(obj.FromUserAccounts, phase);
                    }
                }
            }
            private void Update_FromUserAccounts(global::System.Collections.Generic.List<global::System.String> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // View\OtherCustomerTransferPage.xaml line 71
                    if (!isobj14ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj14, obj, null);
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
            case 2: // View\OtherCustomerTransferPage.xaml line 44
                {
                    this.ContentGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // View\OtherCustomerTransferPage.xaml line 56
                {
                    this.TitleTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // View\OtherCustomerTransferPage.xaml line 125
                {
                    this.ErrorBox = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // View\OtherCustomerTransferPage.xaml line 140
                {
                    this.TransferButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.TransferButton).Click += this.TransferButton_Click;
                }
                break;
            case 6: // View\OtherCustomerTransferPage.xaml line 145
                {
                    this.CancelButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.CancelButton).Click += this.CancelButton_Click;
                }
                break;
            case 7: // View\OtherCustomerTransferPage.xaml line 112
                {
                    this.RemarksTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // View\OtherCustomerTransferPage.xaml line 119
                {
                    this.RemarksTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9: // View\OtherCustomerTransferPage.xaml line 98
                {
                    this.AmountTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10: // View\OtherCustomerTransferPage.xaml line 104
                {
                    this.AmountTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 11: // View\OtherCustomerTransferPage.xaml line 83
                {
                    this.ToTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12: // View\OtherCustomerTransferPage.xaml line 90
                {
                    this.ToTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 13: // View\OtherCustomerTransferPage.xaml line 67
                {
                    this.FromTextBox = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14: // View\OtherCustomerTransferPage.xaml line 71
                {
                    this.FromComboBox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
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
            case 1: // View\OtherCustomerTransferPage.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    OtherCustomerTransferPage_obj1_Bindings bindings = new OtherCustomerTransferPage_obj1_Bindings();
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

