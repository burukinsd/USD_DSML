using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using WpfApplication1.Helpers;
using WpfApplication1.Models;
using WpfApplication1.Views.Templates;

namespace WpfApplication1.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        //экземпляр главного окна
        private MainWindow _owner;
        private List<Object> _controlsList;
        private string _yamlFileName;

        public MainWindowViewModel(MainWindow owner)
        {
            _reportsCollection=new ObservableCollection<ReportData>( LiteDBDriver.SearchAllReportsInDB());
           // _yamlFileName= OpenYamlDialog.Open(owner);
           // _controlsList = LayoutGenerator.GenerateLayout(owner, _yamlFileName); 
            _isEnabled = false;
            _owner = owner;
        }

        //текущий отчет (новый)
        private ReportData _currentReport;
        public ReportData CurrentReport
        {
            get { return _currentReport; }
            set
            {
                _currentReport = value;
                OnPropertyChanged("CurrentReport");
            }
        }

        //коллекция всех отчетов
        private ObservableCollection<ReportData> _reportsCollection;
        public ObservableCollection<ReportData> ReportsCollection
        {
            get { return _reportsCollection; }
            set
            {
                _reportsCollection = value;
                OnPropertyChanged("ReportsCollection");
            }
        }


        private bool _isEnabled;

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                OnPropertyChanged("IsEnabled");
            }
        }

        private ICommand _selectYamlDocCommand;
        public ICommand SelectYamlDocCommand
        {
            get
            {
                return _selectYamlDocCommand ?? (_selectYamlDocCommand = new RelayCommand(() =>
                {
                    _yamlFileName = OpenYamlDialog.Open(_owner);
                    if (_yamlFileName != null)
                    {
                        _controlsList = LayoutGenerator.GenerateLayout(_owner, _yamlFileName);
                        IsEnabled = true;
                    }
                }));
            }
        }


        private ICommand _deleteReportCommand;
        public ICommand DeleteReportCommand
        {
            get
            {
                return _deleteReportCommand ?? (_deleteReportCommand = new RelayCommand(() =>
                       {
                           LiteDBDriver.DeleteReportFromDB(_owner.reportsDataGrid.SelectedItem as ReportData);
                           ReportsCollection = new ObservableCollection<ReportData>(LiteDBDriver.SearchAllReportsInDB());
                       }));
            }
        }

        //Добавить команду получения данных в currentReport,
        //в конце ее функции сделать InsertReportIntoDb( CurrentReport) и обновить ReportsCollection, как делалось ранее или добавлением в коллекцию CurrentReport
        private ICommand _addReportCommand;
        public ICommand AddReportCommand
        {
            get {
                return _addReportCommand ?? (_addReportCommand = new RelayCommand(() =>
                {
                    ReportDataGenerator.GenerateReportData(_yamlFileName,_controlsList);
                    ReportsCollection = new ObservableCollection<ReportData>(LiteDBDriver.SearchAllReportsInDB());
                }));
            }
        }

        //очистить все поля на форме для нового пациента
        private ICommand _clearDataCommand;
        public ICommand ClearDataCommand
        {
            get
            {
                return _clearDataCommand ?? (_clearDataCommand = new RelayCommand(() =>
                {
                    DataControlClear.Clear(_owner.DataGrid);
                }));
            }
        }

        private ICommand _exportReportCommand;
        public ICommand ExportReportCommand
        {
            get
            {
                return _exportReportCommand ?? (_exportReportCommand = new RelayCommand(() =>
                {
                   
                    var selectedItem = (_owner.reportsDataGrid.SelectedItem as ReportData);
                    DocDriver.GenerateDocument(selectedItem);
                }));
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyChanged

      
    }
}
