﻿#pragma checksum "..\..\..\..\..\Games\Tetris\Views\ScoresView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C303098968AE5E2A8EBF3FEE6DA5B8AB0847EF4B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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
using Tetris.Controls;
using Tetris.Model.UI;


namespace Tetris.Views {
    
    
    /// <summary>
    /// ScoresView
    /// </summary>
    public partial class ScoresView : Tetris.Model.UI.OverlayUserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\..\Games\Tetris\Views\ScoresView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Tetris.Views.ScoresView scores;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\..\Games\Tetris\Views\ScoresView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgrHighscores;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\..\Games\Tetris\Views\ScoresView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdBack;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Diplom;component/games/tetris/views/scoresview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Games\Tetris\Views\ScoresView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.scores = ((Tetris.Views.ScoresView)(target));
            return;
            case 2:
            this.dgrHighscores = ((System.Windows.Controls.DataGrid)(target));
            
            #line 30 "..\..\..\..\..\Games\Tetris\Views\ScoresView.xaml"
            this.dgrHighscores.SizeChanged += new System.Windows.SizeChangedEventHandler(this.dgrHighscores_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cmdBack = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\..\..\Games\Tetris\Views\ScoresView.xaml"
            this.cmdBack.Click += new System.Windows.RoutedEventHandler(this.cmdBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
