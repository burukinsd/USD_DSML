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
        ////коллекция UI контролоов откуда в будущем будем брать введенную информацию
        public List<Object> UIControlsList;

        public void GenerateLayout()
        {
            var controls = YamlDriver.GetObjects(@"..\..\Resources\YamlConfig.yaml");

            var currentRow = 0;

            foreach (var control in controls)
            {

                switch (control.GetType().Name)
                {
                    case "TextBoxModel":
                        {
                            //создаем TextBoxControlView
                            var textBoxControlView = new TextBoxControlView();
                            var textBoxControlViewModel = new TextBoxControlViewModel(control as TextBoxModel);
                            textBoxControlView.DataContext = textBoxControlViewModel;

                            //пихаем TextBoxControlView в коллекцию
                            UIControlsList.Add(textBoxControlView);

                            //пихаем TextBoxControlView на форму
                            DataGrid.RowDefinitions.Add(new RowDefinition());
                            DataGrid.Children.Add(textBoxControlView);
                            Grid.SetRow(textBoxControlView, currentRow);

                            break;
                        }
                    case "CheckBoxModel":
                        {

                            var checkBoxControlView = new CheckBoxControlView();
                            var checkBoxControlViewModel = new CheckBoxControlViewModel(control as CheckBoxModel);
                            checkBoxControlView.DataContext = checkBoxControlViewModel;

                            UIControlsList.Add(checkBoxControlView);

                            DataGrid.RowDefinitions.Add(new RowDefinition());
                            DataGrid.Children.Add(checkBoxControlView);
                            Grid.SetRow(checkBoxControlView, currentRow);

                            break;
                        }
                    case "RadioButtonGroupModel":
                        {

                            var buttonGroupControlView = new RadioButtonGroupControlView();
                            var radioButtonGroupControlViewModel =
                                new RadioButtonGroupControlViewModel(control as RadioButtonGroupModel);
                            buttonGroupControlView.DataContext = radioButtonGroupControlViewModel;

                           

                            UIControlsList.Add(buttonGroupControlView);

                            DataGrid.RowDefinitions.Add(new RowDefinition());
                            DataGrid.Children.Add(buttonGroupControlView);
                            Grid.SetRow(buttonGroupControlView, currentRow);

                            break;

                        }
                }

                ++currentRow;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            UIControlsList = new List<object>();

            GenerateLayout();

            DataContext = new ViewModels.MainWindowViewModel();

        }


        private void GetData_OnClick(object sender, RoutedEventArgs e)
        {
           //просто для проверки того, что все данные забиндились
           //поставить BreakPoint
        }
    }
}
