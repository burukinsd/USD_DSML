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
using WpfApplication1.Helpers;
using WpfApplication1.Models;
using WpfApplication1.Views.Templates;

namespace WpfApplication1.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyChanged

        //пример textBoxControl'a в который биндятся данные из yaml
        public TextBoxControlViewModel TextBoxEx { get; set; }
        public ObservableCollection<TextBoxControlViewModel> ControlsList { get; set; }

        public MainWindowViewModel()
        {
            //список моделей с данными, получаемых из yaml
            var controls = YamlDriver.GetObjects(@"..\..\Resources\YamlConfig.yaml");

            ControlsList = new ObservableCollection<TextBoxControlViewModel>();

            //только текстбоксы в коллекции
            foreach (var control in controls)
            {
                TextBoxEx = new TextBoxControlViewModel(control as TextBoxModel);
                ControlsList.Add(TextBoxEx);
            }

        }

    }
}