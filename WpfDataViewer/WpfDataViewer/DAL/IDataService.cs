using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDataViewer.Models;


namespace WpfDataViewer.DAL
{
    public interface IDataService
    {
        List<City> ReadAll();
        //void WriteAll(List<WeatherData> cities);
    }
}
