﻿#pragma checksum "C:\Users\kabilan-13333\Desktop\ZohoBank\ZBMS\ZBMS\ViewTransactionsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4802B105E8605C62B3F62D9E79EEF03D7390B21D6703B5646EF160700D0F5A2B"
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
    partial class ViewTransactionsPage : 
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
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_Controls_Image_Source(global::Windows.UI.Xaml.Controls.Image obj, global::Windows.UI.Xaml.Media.ImageSource value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), targetNullValue);
                }
                obj.Source = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class ViewTransactionsPage_obj19_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IViewTransactionsPage_Bindings
        {
            private global::ZBMS.Models.ExtendedTransactionDetails dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj19;
            private global::Windows.UI.Xaml.Controls.TextBlock obj20;
            private global::Windows.UI.Xaml.Controls.TextBlock obj22;
            private global::Windows.UI.Xaml.Controls.TextBlock obj24;
            private global::Windows.UI.Xaml.Controls.TextBlock obj26;
            private global::Windows.UI.Xaml.Controls.TextBlock obj29;
            private global::Windows.UI.Xaml.Controls.Image obj30;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj20TextDisabled = false;
            private static bool isobj22TextDisabled = false;
            private static bool isobj24TextDisabled = false;
            private static bool isobj26TextDisabled = false;
            private static bool isobj29TextDisabled = false;
            private static bool isobj30SourceDisabled = false;

            public ViewTransactionsPage_obj19_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 59 && columnNumber == 59)
                {
                    isobj20TextDisabled = true;
                }
                else if (lineNumber == 92 && columnNumber == 97)
                {
                    isobj22TextDisabled = true;
                }
                else if (lineNumber == 88 && columnNumber == 76)
                {
                    isobj24TextDisabled = true;
                }
                else if (lineNumber == 83 && columnNumber == 75)
                {
                    isobj26TextDisabled = true;
                }
                else if (lineNumber == 67 && columnNumber == 72)
                {
                    isobj29TextDisabled = true;
                }
                else if (lineNumber == 70 && columnNumber == 85)
                {
                    isobj30SourceDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 19: // ViewTransactionsPage.xaml line 49
                        this.obj19 = new global::System.WeakReference((global::Windows.UI.Xaml.Controls.Grid)target);
                        break;
                    case 20: // ViewTransactionsPage.xaml line 59
                        this.obj20 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 22: // ViewTransactionsPage.xaml line 92
                        this.obj22 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 24: // ViewTransactionsPage.xaml line 88
                        this.obj24 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 26: // ViewTransactionsPage.xaml line 83
                        this.obj26 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 29: // ViewTransactionsPage.xaml line 67
                        this.obj29 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 30: // ViewTransactionsPage.xaml line 70
                        this.obj30 = (global::Windows.UI.Xaml.Controls.Image)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Recycle();
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
                switch(phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            (this.obj19.Target as global::Windows.UI.Xaml.Controls.Grid).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::ZBMS.Models.ExtendedTransactionDetails) item, 1 << phase);
            }

            public void Recycle()
            {
            }

            // IViewTransactionsPage_Bindings

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
                    this.dataRoot = (global::ZBMS.Models.ExtendedTransactionDetails)newDataRoot;
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::ZBMS.Models.ExtendedTransactionDetails obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Time(obj.Time, phase);
                        this.Update_TransactionId(obj.TransactionId, phase);
                        this.Update_ReceiverId(obj.ReceiverId, phase);
                        this.Update_SenderId(obj.SenderId, phase);
                        this.Update_AmountString(obj.AmountString, phase);
                        this.Update_TypeImage(obj.TypeImage, phase);
                    }
                }
            }
            private void Update_Time(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // ViewTransactionsPage.xaml line 59
                    if (!isobj20TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj20, obj, null);
                    }
                }
            }
            private void Update_TransactionId(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // ViewTransactionsPage.xaml line 92
                    if (!isobj22TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj22, obj, null);
                    }
                }
            }
            private void Update_ReceiverId(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // ViewTransactionsPage.xaml line 88
                    if (!isobj24TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj24, obj, null);
                    }
                }
            }
            private void Update_SenderId(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // ViewTransactionsPage.xaml line 83
                    if (!isobj26TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj26, obj, null);
                    }
                }
            }
            private void Update_AmountString(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // ViewTransactionsPage.xaml line 67
                    if (!isobj29TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj29, obj, null);
                    }
                }
            }
            private void Update_TypeImage(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // ViewTransactionsPage.xaml line 70
                    if (!isobj30SourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Image_Source(this.obj30, (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), obj), null);
                    }
                }
            }
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class ViewTransactionsPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IViewTransactionsPage_Bindings
        {
            private global::ZBMS.ViewTransactionsPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.GridView obj3;
            private global::Windows.UI.Xaml.Controls.TextBlock obj6;
            private global::Windows.UI.Xaml.Controls.TextBlock obj8;
            private global::Windows.UI.Xaml.Controls.TextBlock obj10;
            private global::Windows.UI.Xaml.Controls.TextBlock obj13;
            private global::Windows.UI.Xaml.Controls.TextBlock obj17;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj3ItemsSourceDisabled = false;
            private static bool isobj6TextDisabled = false;
            private static bool isobj8TextDisabled = false;
            private static bool isobj10TextDisabled = false;
            private static bool isobj13TextDisabled = false;
            private static bool isobj17TextDisabled = false;

            private ViewTransactionsPage_obj1_BindingsTracking bindingsTracking;

            public ViewTransactionsPage_obj1_Bindings()
            {
                this.bindingsTracking = new ViewTransactionsPage_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 45 && columnNumber == 19)
                {
                    isobj3ItemsSourceDisabled = true;
                }
                else if (lineNumber == 150 && columnNumber == 86)
                {
                    isobj6TextDisabled = true;
                }
                else if (lineNumber == 146 && columnNumber == 65)
                {
                    isobj8TextDisabled = true;
                }
                else if (lineNumber == 141 && columnNumber == 64)
                {
                    isobj10TextDisabled = true;
                }
                else if (lineNumber == 125 && columnNumber == 61)
                {
                    isobj13TextDisabled = true;
                }
                else if (lineNumber == 117 && columnNumber == 52)
                {
                    isobj17TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 3: // ViewTransactionsPage.xaml line 45
                        this.obj3 = (global::Windows.UI.Xaml.Controls.GridView)target;
                        break;
                    case 6: // ViewTransactionsPage.xaml line 150
                        this.obj6 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 8: // ViewTransactionsPage.xaml line 146
                        this.obj8 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 10: // ViewTransactionsPage.xaml line 141
                        this.obj10 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 13: // ViewTransactionsPage.xaml line 125
                        this.obj13 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 17: // ViewTransactionsPage.xaml line 117
                        this.obj17 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
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

            // IViewTransactionsPage_Bindings

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
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::ZBMS.ViewTransactionsPage)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::ZBMS.ViewTransactionsPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_viewModel(obj.viewModel, phase);
                    }
                }
            }
            private void Update_viewModel(global::ZBMS.PresentationLayer.GetTransactionsViewModel obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_viewModel_TransactionsList(obj.TransactionsList, phase);
                    }
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_viewModel_SelectedTransaction(obj.SelectedTransaction, phase);
                    }
                }
            }
            private void Update_viewModel_TransactionsList(global::System.Collections.ObjectModel.ObservableCollection<global::ZBMS.Models.ExtendedTransactionDetails> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // ViewTransactionsPage.xaml line 45
                    if (!isobj3ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj3, obj, null);
                    }
                }
            }
            private void Update_viewModel_SelectedTransaction(global::ZBMS.Models.ExtendedTransactionDetails obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_viewModel_SelectedTransaction_TransactionId(obj.TransactionId, phase);
                        this.Update_viewModel_SelectedTransaction_ReceiverId(obj.ReceiverId, phase);
                        this.Update_viewModel_SelectedTransaction_SenderId(obj.SenderId, phase);
                        this.Update_viewModel_SelectedTransaction_AmountString(obj.AmountString, phase);
                        this.Update_viewModel_SelectedTransaction_Time(obj.Time, phase);
                    }
                }
            }
            private void Update_viewModel_SelectedTransaction_TransactionId(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // ViewTransactionsPage.xaml line 150
                    if (!isobj6TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj6, obj, null);
                    }
                }
            }
            private void Update_viewModel_SelectedTransaction_ReceiverId(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // ViewTransactionsPage.xaml line 146
                    if (!isobj8TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj8, obj, null);
                    }
                }
            }
            private void Update_viewModel_SelectedTransaction_SenderId(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // ViewTransactionsPage.xaml line 141
                    if (!isobj10TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj10, obj, null);
                    }
                }
            }
            private void Update_viewModel_SelectedTransaction_AmountString(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // ViewTransactionsPage.xaml line 125
                    if (!isobj13TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj13, obj, null);
                    }
                }
            }
            private void Update_viewModel_SelectedTransaction_Time(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // ViewTransactionsPage.xaml line 117
                    if (!isobj17TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj17, obj, null);
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class ViewTransactionsPage_obj1_BindingsTracking
            {
                private global::System.WeakReference<ViewTransactionsPage_obj1_Bindings> weakRefToBindingObj; 

                public ViewTransactionsPage_obj1_BindingsTracking(ViewTransactionsPage_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<ViewTransactionsPage_obj1_Bindings>(obj);
                }

                public ViewTransactionsPage_obj1_Bindings TryGetBindingObject()
                {
                    ViewTransactionsPage_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
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
            case 2: // ViewTransactionsPage.xaml line 43
                {
                    this.ErrorMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3: // ViewTransactionsPage.xaml line 45
                {
                    this.TransactionGrids = (global::Windows.UI.Xaml.Controls.GridView)(target);
                    ((global::Windows.UI.Xaml.Controls.GridView)this.TransactionGrids).SelectionChanged += this.TransactionGrids_SelectionChanged;
                }
                break;
            case 4: // ViewTransactionsPage.xaml line 105
                {
                    this.ExpandedGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 5: // ViewTransactionsPage.xaml line 149
                {
                    this.TransactionIdTextBlock1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // ViewTransactionsPage.xaml line 150
                {
                    this.TransactionIdValueTextBlock1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // ViewTransactionsPage.xaml line 145
                {
                    this.ReceiverIdTextBlock1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // ViewTransactionsPage.xaml line 146
                {
                    this.ReceiverIdValueTextBlock1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9: // ViewTransactionsPage.xaml line 140
                {
                    this.SenderIdTextBlock1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10: // ViewTransactionsPage.xaml line 141
                {
                    this.SenderIdValueTextBlock1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11: // ViewTransactionsPage.xaml line 131
                {
                    this.RemarksTextBlock1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12: // ViewTransactionsPage.xaml line 132
                {
                    this.RemarksValueTextBlock1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13: // ViewTransactionsPage.xaml line 125
                {
                    this.AmountValueTextBlock1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14: // ViewTransactionsPage.xaml line 120
                {
                    this.BalanceTextBlock1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15: // ViewTransactionsPage.xaml line 121
                {
                    this.BalanceValueTextBlock1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16: // ViewTransactionsPage.xaml line 116
                {
                    this.CloseButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.CloseButton).Click += this.CloseButton_Click;
                }
                break;
            case 17: // ViewTransactionsPage.xaml line 117
                {
                    this.TransactionDate1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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
            case 1: // ViewTransactionsPage.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    ViewTransactionsPage_obj1_Bindings bindings = new ViewTransactionsPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            case 19: // ViewTransactionsPage.xaml line 49
                {                    
                    global::Windows.UI.Xaml.Controls.Grid element19 = (global::Windows.UI.Xaml.Controls.Grid)target;
                    ViewTransactionsPage_obj19_Bindings bindings = new ViewTransactionsPage_obj19_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element19.DataContext);
                    element19.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element19, bindings);
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element19, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

