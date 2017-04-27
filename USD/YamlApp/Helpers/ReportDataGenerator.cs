using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using WpfApplication1.Models;
using WpfApplication1.ViewModels;
using WpfApplication1.Views.Templates;

namespace WpfApplication1.Helpers
{
    public class ReportDataGenerator
    {
        public static void GenerateReportData(string yamlFileName, List<object> controlsList)
        {
            ReportData report = new ReportData();
            Random rnd = new Random();

            report.TypeOfReport = Path.GetFileNameWithoutExtension(yamlFileName);
            report.ReportDate = DateTime.Now;
            report.GUID = report.ReportDate.Ticks;

            foreach (var control in controlsList)
            {
                switch (control.GetType().Name)
                {
                    case "TextBoxControlView":
                    {
                        var textBoxControl = control as TextBoxControlView;
                        var textBoxControlViewModel = textBoxControl.DataContext as TextBoxControlViewModel;

                        if (textBoxControl.LabelContent.Text == "ФИО")
                        {
                            if (textBoxControl.TextBox.Text != "")
                                report.FIO = textBoxControl.TextBox.Text;
                            else
                            {
                                MessageBox.Show("Поле ФИО обязательно для заполнения");
                                return;
                            }
                        }

                        report.USDData.Add(textBoxControlViewModel.Id, $"{textBoxControl.LabelContent.Text}: {textBoxControl.TextBox.Text}");

                        break;
                    }

                    case "CheckBoxControlView":
                    {
                        var checkBoxControl = control as CheckBoxControlView;
                        var checkBoxControlViewModel = checkBoxControl.DataContext as CheckBoxControlViewModel;

                        if(checkBoxControl.CheckBox.IsChecked == true)
                            report.USDData.Add(checkBoxControlViewModel.Id, $"{checkBoxControl.Label.Content}: да");
                        else
                            report.USDData.Add(checkBoxControlViewModel.Id, $"{checkBoxControl.Label.Content}: нет");

                        break;
                    }
                    case "RadioButtonGroupControlView":
                    {
                        var radioGroupControl = control as RadioButtonGroupControlView;
                        var radioGroupControlViewModel = radioGroupControl.DataContext as RadioButtonGroupControlViewModel;

                        report.USDData.Add(radioGroupControlViewModel.Id, $"{radioGroupControl.RadioLabelContent.Text}: {radioGroupControlViewModel.BindedData}");

                        break;
                    }
                }
            }
            LiteDBDriver.InsertReportIntoDb(report);
            MessageBox.Show("Отчет сохранен");
        }
    }
}
