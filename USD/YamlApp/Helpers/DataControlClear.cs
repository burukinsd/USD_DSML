using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfApplication1.ViewModels;
using WpfApplication1.Views.Templates;

namespace WpfApplication1.Helpers
{
    public class DataControlClear
    {
        public static void Clear(Grid grid)
        {
            foreach (Control ctl in grid.Children)
            {
                if (ctl.GetType() == typeof(TextBoxControlView))
                    ((TextBoxControlView) ctl).TextBox.Text = String.Empty;
                if (ctl.GetType() == typeof(CheckBoxControlView))
                    ((CheckBoxControlView) ctl).CheckBox.IsChecked = false;

                if (ctl.GetType() == typeof(RadioButtonGroupControlView))
                {
                    foreach (var item in ((RadioButtonGroupControlView) ctl).ListBox.Items)
                    {
                        ListBoxItem listBoxItem =
                            (ListBoxItem)
                            (((RadioButtonGroupControlView) ctl).ListBox.ItemContainerGenerator.ContainerFromItem(item));
                        ContentPresenter contentPresenter = FindVisualChild<ContentPresenter>(listBoxItem);

                        // Finding textBlock from the DataTemplate that is set on that ContentPresenter
                        DataTemplate dataTemplate = contentPresenter.ContentTemplate;
                        RadioButton radioButton = (RadioButton) dataTemplate.FindName("RadioButton", contentPresenter);
                        radioButton.IsChecked = false;
                    }
                    
                }

            }
        }

        private static childItem FindVisualChild<childItem>(DependencyObject obj)
            where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                    return (childItem) child;
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
        
    }



}
