using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CoREMobile.Helpers
{
    /// <summary>
    /// Class that contains utility funcitons for Xamarin Forms controls
    /// </summary>
    public class ControlsUtil
    {
        /// <summary>
        /// Builds a standard grid using 1* for each column width and row height
        /// </summary>
        /// <param name="rows">Number of standardized rows</param>
        /// <param name="columns">Number of standardized columns</param>
        /// <param name="gridControl">Grid to be created (can be empty)</param>
        /// <returns></returns>
        public static Grid GridBuilder(int rows, int columns, Grid gridControl)
        {
            gridControl = new Grid()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(0, 0, 10, 0)
            };

            ColumnDefinition standardColumn;

            RowDefinition standardRow;

            for (int i = 0; i < columns; i++)
            {
                standardColumn = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };
                gridControl.ColumnDefinitions.Add(standardColumn);
            }

            for (int i = 0; i < rows; i++)
            {
                standardRow = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
                gridControl.RowDefinitions.Add(standardRow);
            }

            return gridControl;
        }

    }
}
