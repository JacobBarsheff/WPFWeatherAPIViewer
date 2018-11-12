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
using WpfDataViewer.Models;

namespace WpfDataViewer
{
    /// <summary>
    /// Interaction logic for Detail.xaml
    /// </summary>
    public partial class Detail : Window
    {
        City _city = new City();

        public Detail(City city)
        {
            InitializeComponent();
            _city = city;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            lbl_City.Content = _city.Name;
            lbl_Country.Content = "Country: " + _city.Country;
            lbl_Long.Content = "Longitude: " + _city.Lon.ToString();
            lbl_lat.Content = "Latitude: " + _city.Lat.ToString();
            lbl_weatherDesc.Content = "Conditions: " + _city.WeatherDesc;
            lbl_Cloud.Content = "Cloud Coverage: " + _city.CloudCoverage.ToString() + "%";
            lbl_Temp.Content = "Temperature: " + _city.Temp.ToString();
            lbl_WindSpeed.Content = "Wind Speed: " + _city.Speed.ToString() + " mph";
            lbl_Pressure.Content = "Pressure: " + _city.Pressure.ToString() + " hPa";
            lbl_Humidity.Content = "Humidity: " + _city.Humidity.ToString() + "%";
            lbl_WindDeg.Content = "Wind Direction (Degrees): " + _city.Deg.ToString();

            picture_weatherIcon.Source = new BitmapImage(new Uri($"http://openweathermap.org/img/w/{_city.Icon}.png"));
        }

        private void ButtonAdv_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
