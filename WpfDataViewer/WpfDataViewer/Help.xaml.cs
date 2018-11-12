using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfDataViewer
{
    /// <summary>
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : Window
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            lbl_Instructions.Content = "1) The Search By City Function Allows users to find a city within" +
            " the populated list\nby simply typing in a desired city.\n" +
            "2) Use the slider to filter cities with temperatures at or below the displayed value. \n" +
            "3) Click the Sort By Temperature button to sort cites by temperature descending.";
        }

        private void ButtonAdv_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
