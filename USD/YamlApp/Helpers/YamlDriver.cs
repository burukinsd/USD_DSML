using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Models;
using YamlDotNet.RepresentationModel;

namespace WpfApplication1.Helpers
{
    public static class YamlDriver
    {

        public static List<object> GetObjects(string configFileName)
        {
           
            var controls = new List<object>();

            //@"..\..\Resources\YamlConfig.yaml"
            StreamReader sr = new StreamReader(configFileName);
            string text = sr.ReadToEnd();
            var input = new StringReader(text);

            // Load the stream
            var yaml = new YamlStream();
            yaml.Load(input);

            // Examine the stream
            var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;

            var items = (YamlSequenceNode)mapping.Children[new YamlScalarNode("form-elements")];

            foreach (YamlMappingNode item in items)
            {

                var type = item.Children[new YamlScalarNode("type")];

                switch (type.ToString())
                {
                    case "textbox":
                    {

                            var textboxItem = new TextBoxModel()
                            {
                                Id = item.Children[new YamlScalarNode("id")].ToString(),
                                Caption = item.Children[new YamlScalarNode("caption")].ToString(),
                                Size = item.Children[new YamlScalarNode("size")].ToString()
                            };


                            controls.Add(textboxItem);

                            break;

                    }
                    case "checkbox":
                    {
                            var checkboxItem = new CheckBoxModel()
                            {
                                Id = item.Children[new YamlScalarNode("id")].ToString(),
                                Label = item.Children[new YamlScalarNode("label")].ToString(),
                                Size = item.Children[new YamlScalarNode("size")].ToString()
                            };

                            controls.Add(checkboxItem);

                            break;

                    }
                    case "radiobuttons":
                    {
                            var optionListItems = (YamlSequenceNode)item.Children[new YamlScalarNode("optionList")];

                            var list = new List<string>();

                            foreach (YamlScalarNode x in optionListItems)
                            {
                                list.Add(x.ToString());
                            }

                            var radiobuttonsItem = new RadioButtonGroupModel()
                            {
                                Id = item.Children[new YamlScalarNode("id")].ToString(),
                                Label = item.Children[new YamlScalarNode("label")].ToString(),
                                Orientation = item.Children[new YamlScalarNode("orientation")].ToString(),
                                OptionList = list
                            };

                            controls.Add(radiobuttonsItem);

                            break;

                    }
                }
            }

            return controls;
        }

    }
}
