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

namespace FormOtprav
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool stop = false;
        int tip;
        int vid;
        int zagr;


        public MainWindow()
        {
            InitializeComponent();
        }
        public void Raschet()
        {
            if(Vid_posilki.Text== "Посылка")
            {
                vid = 1567;
            }
            else
            {
                vid = 409;
            }
            if (Tip_posilki.Text == "Хрупкое")
            {
                tip = 2318;
            }
            else
            {
                tip = 970;
            }
            if(RF.ClickMode==ClickMode.Hover)
            {
                zagr = 400;
            }
            if (zagran.ClickMode == ClickMode.Hover)
            {
                zagr = 3400;
            }
           
        }

            
        public void CheckBox()
        {
            if (Vid_posilki.Text == "Посылка")
            {
                Tip_posilki.IsEnabled = true;
            }
            else
            {
                Tip_posilki.IsEnabled = false;
                Tip_posilki.Text = "";
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void Load(object sender, RoutedEventArgs e)
        {
            
            while (stop==false)
            {
                await Task.Delay(100);
                CheckBox();
            }
        }
    }
}
