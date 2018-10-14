namespace VsPostman
{
    using System;
    using System.Collections.Generic;
    using System.Data;
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

        private DataRowView rowBeingEdited = null;

        private void dataGrid_CellEditEnding(object sender,
                                          DataGridCellEditEndingEventArgs e)
        {
            DataRowView rowView = e.Row.Item as DataRowView;
            rowBeingEdited = rowView;
        }

        private void dataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            if (rowBeingEdited != null)
            {
                rowBeingEdited.EndEdit();
            }
        }
    }
}