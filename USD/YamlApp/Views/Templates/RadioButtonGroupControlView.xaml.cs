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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using WpfApplication1.Helpers;

namespace WpfApplication1.Views.Templates
{
    /// <summary>
    /// Interaction logic for RadioButtonGroupControlView.xaml
    /// </summary>
    public partial class RadioButtonGroupControlView : UserControl
    {
        public RadioButtonGroupControlView()
        {
            InitializeComponent();
        }
        private void RadioButton_IsChecked(object sender, RoutedEventArgs e)
        {
            var CurrentRadioButton_IsChecked = sender as RadioButton;

            var msg = new RadioButtonMessage()
            {
                IsCheckedRadioButtonName = CurrentRadioButton_IsChecked.Content.ToString(),
                GroupName = CurrentRadioButton_IsChecked.GroupName

            };
            Messenger.Default.Send<RadioButtonMessage>(msg);
        }
    }
}
