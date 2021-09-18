using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfXamlReadAndWrite
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnWrite_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            string xamlString = XamlWriter.Save(btn);
            tbXaml.Text = xamlString;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("test.Xaml", tbXaml.Text);
        }

        private void BtnRead_Click(object sender, RoutedEventArgs e)
        {
            var str = File.ReadAllText("test.Xaml");
            tbXamlRead.Text = str;
        }

        private void BtnShowParse_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty( tbXamlRead.Text))
            {
                var btn = XamlReader.Parse(tbXamlRead.Text) as Button;
                spCon.Children.Add(btn);
            } 
        }

        private void BtnShowLoad_Click(object sender, RoutedEventArgs e)
        { 
            var stream = File.OpenRead("test.Xaml");
            var btn = XamlReader.Load(stream) as Button;
            spCon.Children.Add(btn);

        }
    }
}
