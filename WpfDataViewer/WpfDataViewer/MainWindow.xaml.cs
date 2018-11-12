using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfDataViewer.DAL;
using WpfDataViewer.Models;

namespace WpfDataViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<City> _cities;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            try
            {
                ReadWeatherAPIAndBindToDataGrid();
            }
            catch (Exception message)
            {

                MessageBox.Show(message.Message);
                this.Close();
            }
        }
        private void ReadWeatherAPIAndBindToDataGrid()
        {

            //
            // read data file
            //
            IDataService dataService = new APIDataService();
            _cities = dataService.ReadAll();

            //
            // bind list to DataGridView control
            //
            var bindingList = new BindingList<City>(_cities);
            dataGridViewCities.ItemsSource = bindingList;

            dataGridViewCities.Columns["Pressure"].Width = 0;
            this.dataGridViewCities.Columns["Humidity"].Width = 0;
            this.dataGridViewCities.Columns["Deg"].Width = 0;
            this.dataGridViewCities.Columns["Icon"].Width = 0;

            lbl_results.Content = $"Records Returned({bindingList.Count})";

        }

        private void ButtonAdv_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchTerm = txtBox_search.Text;
            var searchedList = _cities.Where(c => c.Name.ToUpper().Contains(searchTerm.ToUpper())).ToList();
            if (searchedList.Count == 0)
            {
                lbl_results.Content = $"Records Returned({searchedList.Count}). Try to broaden your search!";
            }
            else
            {
                lbl_results.Content = $"Records Returned({searchedList.Count})";
            }
            BindDataToGrid(searchedList);
        }

        private void RangeSliderControl_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbl_FilterByTemp.Content = $"Filter By Temperature: ({(int)ctrl_rangeSlider.Value})";
            if (_cities != null)
            {
                var searchedList = _cities.Where(c => c.Temp <= ctrl_rangeSlider.Value).ToList();
                if (_chexBoxTemp.IsChecked == true)
                {
                    var searchedList2 = _cities.Where(c => c.Temp <= ctrl_rangeSlider.Value).OrderBy(c => c.Temp).ToList();
                    BindDataToGrid(searchedList2);

                }
                else
                {
                BindDataToGrid(searchedList);
                }
                if (searchedList.Count == 0)
                {
                    lbl_results.Content = $"Records Returned({searchedList.Count}). Try to broaden your search!";
                }
                else
                {
                    lbl_results.Content = $"Records Returned({searchedList.Count})";
                }
            }





        }
        private void BindDataToGrid(List<City> cities)
        {
            dataGridViewCities.ItemsSource = cities;
            dataGridViewCities.Columns["Pressure"].Width = 0;
            this.dataGridViewCities.Columns["Humidity"].Width = 0;
            this.dataGridViewCities.Columns["Deg"].Width = 0;
            this.dataGridViewCities.Columns["Icon"].Width = 0;
        }

        private void _chexBoxTemp_Checked(object sender, RoutedEventArgs e)
        {
            if (_chexBoxTemp.IsChecked == true)
            {
                var searchedList = _cities.Where(c => c.Temp <= ctrl_rangeSlider.Value).OrderBy(c => c.Temp).ToList();
                BindDataToGrid(searchedList);

            }
        }

        private void ButtonAdv_Click_1(object sender, RoutedEventArgs e)
        {
            if (dataGridViewCities.SelectedItems.Count == 1)
            {
                City city = new City();
                city = (City)dataGridViewCities.SelectedItem;

                Detail detailForm = new Detail(city);
                detailForm.ShowDialog();
            }
        }

        private void ButtonAdv_Click_2(object sender, RoutedEventArgs e)
        {
            Help help = new Help();
            help.ShowDialog();
        }
    }
}
