using C6XSDH_HFT_2021222.Models.Entities;
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
using System.Windows.Shapes;

namespace C6XSDH_HFT_2021222.WPFClient.EditorWindows
{
    /// <summary>
    /// Interaction logic for ScooterEditorWindow.xaml
    /// </summary>
    public partial class ScooterEditorWindow : Window
    {
        public ScooterEditorWindow(Scooter s)
        {
            InitializeComponent();
            this.DataContext= s;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in stackpanel.Children)
            {
                if (item is TextBox t)
                {
                    t.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
            }
            this.DialogResult = true;
        }
    }
}
