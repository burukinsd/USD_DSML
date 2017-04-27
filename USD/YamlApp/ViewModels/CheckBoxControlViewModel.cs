using System;
using System.ComponentModel;
using WpfApplication1.Models;

namespace WpfApplication1.ViewModels
{
    public class CheckBoxControlViewModel : INotifyPropertyChanged
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

        
        private bool _state = false;

        public bool State
        {
            get { return _state; }
            set
            {
                _state = value;
                OnPropertyChanged("State");
            }
        }

        public CheckBoxControlViewModel(CheckBoxModel checkBoxModel)
        {
            Id = checkBoxModel.Id;
            Label = checkBoxModel.Label;
        }
    }
}