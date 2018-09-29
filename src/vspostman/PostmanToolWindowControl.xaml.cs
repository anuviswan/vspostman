namespace VsPostman
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using VsPostman.HttpRequest;

    /// <summary>
    /// Interaction logic for PostmanToolWindowControl.
    /// </summary>
    public partial class PostmanToolWindowControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostmanToolWindowControl"/> class.
        /// </summary>
        public PostmanToolWindowControl()
        {
            this.InitializeComponent();
            this.DataContext = new PostmanToolWindowControlViewModel();
        }

        
    }
}