﻿#pragma checksum "..\..\..\BookingWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7FF2E1257C5E90E0E2A65CFE067791F9EF0D7EA7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BadmintonWPFApp;
using FontAwesome.Sharp;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace BadmintonWPFApp {
    
    
    /// <summary>
    /// BookingWindow
    /// </summary>
    public partial class BookingWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 127 "..\..\..\BookingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TypeComboBox;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\BookingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker BookingDatePicker;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\BookingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TimeSlotComboBox;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\..\BookingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Dynamic;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\BookingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl DynamicInputControl;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\..\BookingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PriceLabel;
        
        #line default
        #line hidden
        
        
        #line 183 "..\..\..\BookingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox BookingsListBox;
        
        #line default
        #line hidden
        
        
        #line 186 "..\..\..\BookingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelButton;
        
        #line default
        #line hidden
        
        
        #line 205 "..\..\..\BookingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackBtn;
        
        #line default
        #line hidden
        
        
        #line 224 "..\..\..\BookingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ConfirmButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BadmintonWPFApp;component/bookingwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\BookingWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TypeComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 127 "..\..\..\BookingWindow.xaml"
            this.TypeComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TypeComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BookingDatePicker = ((System.Windows.Controls.DatePicker)(target));
            
            #line 137 "..\..\..\BookingWindow.xaml"
            this.BookingDatePicker.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.BookingDatePicker_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TimeSlotComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.Dynamic = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.DynamicInputControl = ((System.Windows.Controls.ContentControl)(target));
            return;
            case 6:
            
            #line 153 "..\..\..\BookingWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BookButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.PriceLabel = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.BookingsListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 9:
            this.CancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 186 "..\..\..\BookingWindow.xaml"
            this.CancelButton.Click += new System.Windows.RoutedEventHandler(this.CancelButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.BackBtn = ((System.Windows.Controls.Button)(target));
            
            #line 205 "..\..\..\BookingWindow.xaml"
            this.BackBtn.Click += new System.Windows.RoutedEventHandler(this.BackBtn_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.ConfirmButton = ((System.Windows.Controls.Button)(target));
            
            #line 224 "..\..\..\BookingWindow.xaml"
            this.ConfirmButton.Click += new System.Windows.RoutedEventHandler(this.ConfirmButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

