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

        //коллекция UI контролоов откуда в будущем будем брать введенную информацию
        //private List<Object> _uiControlsList = new List<object>();

        //public List<Object> UIControlsList
        //{
        //    get { return _uiControlsList; }
        //    set
        //    {
        //        _uiControlsList = value;
        //        OnPropertyChanged(nameof(UIControlsList));
        //    }
        //}
        

        //public MainWindowViewModel()
        //{

        //    var controls = YamlDriver.GetObjects(@"..\..\Resources\YamlConfig.yaml");

        //    var currentRow = 0;

        //    foreach (var control in controls)
        //    {

        //        switch (control.GetType().Name)
        //        {
        //            case "TextBoxModel":
        //                {
        //                    //создаем TextBoxControl
        //                    var textBoxControl = new TextBoxControl();
        //                    var textBoxControlViewModel = new TextBoxControlViewModel(control as TextBoxModel);
        //                    textBoxControl.DataContext = textBoxControlViewModel;

        //                    //пихаем TextBoxControl в коллекцию
        //                    _uiControlsList.Add(textBoxControl);

        //                    //пихаем TextBoxControl на форму
        //                    //DataGrid.RowDefinitions.Add(new RowDefinition());
        //                    //DataGrid.Children.Add(textBoxControl);
        //                    //Grid.SetRow(textBoxControl, currentRow);

        //                    break;
        //                }
        //            case "CheckBoxModel":
        //                {

        //                    var checkBoxControl = new CheckBoxControl();
        //                    var checkBoxControlViewModel = new CheckBoxControlViewModel(control as CheckBoxModel);
        //                    checkBoxControl.DataContext = checkBoxControlViewModel;

        //                    _uiControlsList.Add(checkBoxControl);

        //                    //DataGrid.RowDefinitions.Add(new RowDefinition());
        //                    //DataGrid.Children.Add(checkBoxControl);
        //                    //Grid.SetRow(checkBoxControl, currentRow);

        //                    break;
        //                }
        //            case "RadioButtonGroupModel":
        //                {

        //                    var radioButtonGroupControl = new RadioButtonGroupControl();
        //                    var radioButtonGroupControlViewModel =
        //                        new RadioButtonGroupControlViewModel(control as RadioButtonGroupModel);
        //                    radioButtonGroupControl.DataContext = radioButtonGroupControlViewModel;

        //                    _uiControlsList.Add(radioButtonGroupControl);

        //                    //DataGrid.RowDefinitions.Add(new RowDefinition());
        //                    //DataGrid.Children.Add(radioButtonGroupControl);
        //                    //Grid.SetRow(radioButtonGroupControl, currentRow);
        //                    break;

        //                }
        //        }

            //    ++currentRow;
            //}

        //}

      
    }
}
