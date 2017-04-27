using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
using WpfApplication1.Helpers;
using WpfApplication1.Models;
using WpfApplication1.ViewModels;
using WpfApplication1.Views.Templates;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace WpfApplication1
{
  
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            //Dictionary<string, string> sj = new Dictionary<string, string>();
            //ReportData report = new ReportData();

            //Random rnd = new Random();
           
            //report.FIO = "Рахманинов Сергей Васильевич";
            //report.TypeOfReport = "type"+rnd.Next(0,99);
            //report.ReportDate = DateTime.Now;
            //report.USDData.Add("FIO", "Petrov Ivan Ivanovich");
            //report.USDData.Add("Prostuda", "Da");

            //LiteDBDriver.InsertReportIntoDb(report);

            



            InitializeComponent();
            DataContext = new ViewModels.MainWindowViewModel(this);
            

        }


        //private void GetData_OnClick(object sender, RoutedEventArgs e)
        //{
        //   //просто для проверки того, что все данные забиндились
        //   //поставить BreakPoint
        //}
    }
}
