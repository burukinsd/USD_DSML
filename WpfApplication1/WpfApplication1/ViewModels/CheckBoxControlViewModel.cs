using System;
using System.ComponentModel;
using WpfApplication1.Models;

namespace WpfApplication1.ViewModels
{
    public class CheckBoxControlViewModel
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

        //private int _size;
        //public int Size
        //{
        //    get { return _size; }
        //    set
        //    {
        //        if (value > 0 && value <= 12)
        //        {
        //            _size = value;
        //        }
        //        else
        //        {
        //            _size = 1;
        //        }

        //        OnPropertyChanged("Size");
        //    }
        //}

        private string _state;

        public string State
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
            //не тру, доработать
            //Size = Convert.ToInt32(textBoxModel.Size);

            //BindedData = "";
        }
    }
}