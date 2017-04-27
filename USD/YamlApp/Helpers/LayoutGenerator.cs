using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfApplication1.Models;
using WpfApplication1.ViewModels;
using WpfApplication1.Views.Templates;

namespace WpfApplication1.Helpers
{
    public class LayoutGenerator
    {

        public static List<Object> GenerateLayout(MainWindow owner, string pathToYamlFile)
        {
            //очистить форму
            owner.DataGrid.Children.Clear();

            List<Object> UIControlsList = new List<object>();
            //var controls = YamlDriver.GetObjects(@"..\..\Resources\YamlConfig.yaml");
            var controls = YamlDriver.GetObjects(pathToYamlFile);
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
                        owner.DataGrid.RowDefinitions.Add(new RowDefinition());
                        owner.DataGrid.Children.Add(textBoxControlView);
                        Grid.SetRow(textBoxControlView, currentRow);

                        break;
                    }
                    case "CheckBoxModel":
                    {

                        var checkBoxControlView = new CheckBoxControlView();
                        var checkBoxControlViewModel = new CheckBoxControlViewModel(control as CheckBoxModel);
                        checkBoxControlView.DataContext = checkBoxControlViewModel;

                        UIControlsList.Add(checkBoxControlView);

                        owner.DataGrid.RowDefinitions.Add(new RowDefinition());
                        owner.DataGrid.Children.Add(checkBoxControlView);
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

                        owner.DataGrid.RowDefinitions.Add(new RowDefinition());
                        owner.DataGrid.Children.Add(buttonGroupControlView);
                        Grid.SetRow(buttonGroupControlView, currentRow);

                        break;

                    }
                }

                ++currentRow;
            }
            return UIControlsList;
        }

    }
}
