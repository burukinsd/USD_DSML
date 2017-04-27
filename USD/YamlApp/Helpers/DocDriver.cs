using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Novacode;
using WpfApplication1.Models;

namespace WpfApplication1.Helpers
{
    public static class DocDriver
    {

        public static void GenerateDocument(ReportData reportData)
        {
            var templateType = $"{reportData.TypeOfReport.Split('_').First()}_template.docx";

            var fullTemplatePath = $@"..\..\Resources\DocumentTemplates\{templateType}";

            if (File.Exists(fullTemplatePath))
            {
                var date = reportData.ReportDate.ToShortDateString();
                var time = $"{reportData.ReportDate.Hour}_{reportData.ReportDate.Minute}_{reportData.ReportDate.Second}";
                var name = reportData.FIO.Replace(" ","_");

                var docName = $"{name}_{reportData.TypeOfReport.Split('_').First()}_{date}_({time}).docx";

                var fullDocPath = $@"..\..\Resources\Documents\{docName}";

                if (!File.Exists(fullDocPath))
                {
                    using (var document = DocX.Load(fullTemplatePath))
                    {
                        FillingDocument(document, reportData.USDData);
                        document.SaveAs(fullDocPath);
                    }
                }

                Process.Start("WINWORD.EXE", fullDocPath);

            }
            else
            {
                MessageBox.Show("Не существует шаблона для создания документа с заданными данными", "Oooppps =(((", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public static void FillingDocument(DocX document, Dictionary<string,string> usdData)
        {

            foreach (var field in usdData)
            {
                document.ReplaceText($"%{field.Key}%", field.Value);
            }
        }
    }
}
