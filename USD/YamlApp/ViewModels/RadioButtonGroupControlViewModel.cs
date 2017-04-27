using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using WpfApplication1.Helpers;
using WpfApplication1.Models;

namespace WpfApplication1.ViewModels
{
    public class RadioButtonGroupControlViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _id;
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private string _label;
        public string Label
        {
            get { return _label; }
            set
            {
                _label = value;
                OnPropertyChanged("Label");
            }
        }

        private string _orientation;
        public string Orientation
        {
            get { return _orientation; }
            set
            {
                _orientation = value;
                OnPropertyChanged("Orientation");
            }
        }

        private List<string> _optionList;
        public List<string> OptionList
        {
            get { return _optionList; }
            set
            {
                _optionList = value;
                OnPropertyChanged("OptionList");
            }
        }

        

        private string _bindedData;
        public string BindedData
        {
            get { return _bindedData; }
            set
            {
                _bindedData = value;
                OnPropertyChanged("BindedData");
            }
        }

        public RadioButtonGroupControlViewModel(RadioButtonGroupModel radioButtonGroupModel)
        {
            Id = radioButtonGroupModel.Id;
            Label = radioButtonGroupModel.Label;
            Orientation = radioButtonGroupModel.Orientation;
            OptionList = radioButtonGroupModel.OptionList;
            
            Messenger.Default.Register<RadioButtonMessage>(this,(action) => ReceiveRadioButtonMessage(action));
            //BindedData = "";
        }

        public void ReceiveRadioButtonMessage(RadioButtonMessage radioButtonMessage)
        {
            if(radioButtonMessage.GroupName== Label)
                BindedData = radioButtonMessage.IsCheckedRadioButtonName;
        }

    }
}
