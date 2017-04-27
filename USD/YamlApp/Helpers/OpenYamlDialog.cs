using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;

namespace WpfApplication1.Helpers
{
    public class OpenYamlDialog
    {
     
        public static string Open(MainWindow owner)
        {

            string combinedPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"..\Resources");
            OpenFileDialog dlg = new OpenFileDialog
            {
                DefaultExt = ".yaml",
                Filter = "YAML Files|*.yaml",
                InitialDirectory = System.IO.Path.GetFullPath(combinedPath),
                CheckFileExists = true,
                Title = "Выбор шаблона формы"
            };


            if (dlg.ShowDialog() == true)
            {
                return dlg.FileName;
            }
            else
            {
                MessageBox.Show("Не удалось открыть файл");
                return null;
            }
        }
    }
}
