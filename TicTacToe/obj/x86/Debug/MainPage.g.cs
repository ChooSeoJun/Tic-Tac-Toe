﻿#pragma checksum "C:\Users\chu10\source\repos\Games\TicTacToe\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "61E0B68C86B0FA7198B03E9EA5ED68BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TicTacToe
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 68
                {
                    this.txtResult = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3: // MainPage.xaml line 70
                {
                    this.btnRestart = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnRestart).Click += this.NewGame_Click;
                }
                break;
            case 4: // MainPage.xaml line 55
                {
                    this.ButtonGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 5: // MainPage.xaml line 56
                {
                    this.A1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.A1).Click += this.Button_Click;
                }
                break;
            case 6: // MainPage.xaml line 57
                {
                    this.A2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.A2).Click += this.Button_Click;
                }
                break;
            case 7: // MainPage.xaml line 58
                {
                    this.A3 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.A3).Click += this.Button_Click;
                }
                break;
            case 8: // MainPage.xaml line 59
                {
                    this.B1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.B1).Click += this.Button_Click;
                }
                break;
            case 9: // MainPage.xaml line 60
                {
                    this.B2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.B2).Click += this.Button_Click;
                }
                break;
            case 10: // MainPage.xaml line 61
                {
                    this.B3 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.B3).Click += this.Button_Click;
                }
                break;
            case 11: // MainPage.xaml line 62
                {
                    this.C1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.C1).Click += this.Button_Click;
                }
                break;
            case 12: // MainPage.xaml line 63
                {
                    this.C2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.C2).Click += this.Button_Click;
                }
                break;
            case 13: // MainPage.xaml line 64
                {
                    this.C3 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.C3).Click += this.Button_Click;
                }
                break;
            case 14: // MainPage.xaml line 38
                {
                    this.scoreA = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15: // MainPage.xaml line 40
                {
                    this.scoreB = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16: // MainPage.xaml line 42
                {
                    this.tsAIMode = (global::Windows.UI.Xaml.Controls.ToggleSwitch)(target);
                    ((global::Windows.UI.Xaml.Controls.ToggleSwitch)this.tsAIMode).Toggled += this.ToggleSwitch_Toggled;
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
