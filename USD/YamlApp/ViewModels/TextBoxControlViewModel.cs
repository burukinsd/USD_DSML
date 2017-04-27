using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Models;

namespace WpfApplication1.ViewModels
{
    public class TextBoxControlViewModel : INotifyPropertyChanged
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

        private string _caption;
        public string Caption
        {
            get { return _caption; }
            set
            {
                _caption = value;
                OnPropertyChanged("Caption");
            }
        }

        private int _size;
        public int Size
        {
            get { return _size; }
            set
            {
                _size = value;
                OnPropertyChanged("Size");
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

        public TextBoxControlViewModel(TextBoxModel textBoxModel)
        {
            Id = textBoxModel.Id;
            Caption = textBoxModel.Caption;

            switch (textBoxModel.Size)
            {
                case "small":
                    Size = 1;
                    break;
                case "medium":
                    Size = 2;
                    break;
                case "large":
                    Size = 3;
                    break;
                default:
                    Size = 1;
                    break;
            }
            //BindedData = "";
        }
    }
}
