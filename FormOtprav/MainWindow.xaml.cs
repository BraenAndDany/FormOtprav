using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
using System.Xml.Linq;

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
        public void Otprav()
        {
            string path = "C:\\Users\\User\\Downloads\\Otprav.txt";
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress(ADRSpoluchat.Text, "Me");
            // кому отправляем
            MailAddress to = new MailAddress(ADRSpoluchat.Text);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            m.Attachments.Add(new Attachment(path));
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
            // логин и пароль
            smtp.Credentials = new NetworkCredential(ADRSpoluchat.Text, "dWxZks4tnrEGDq3XWqQh");
            smtp.EnableSsl = true;
            smtp.Send(m);
            //npl1u1pc@mail.ru
        }
        public void Filecreate()
        {
            string path = "C:\\Users\\User\\Downloads\\Otprav.txt";
            //System.IO.File.Create(path);

            StreamWriter file = new StreamWriter(path);
            //записать в него
            file.Write(fioOtprav.Text+"\n");
            file.Write(fioPoluchat1.Text + "\n");
            file.Write(ADRSotprav.Text + "\n");
            file.Write(ADRSpoluchat.Text + "\n");
            file.Write(Vid_posilki.Text + "\n");
            file.Write(Tip_posilki.Text + "\n");
            if (RF.IsChecked == true)
            {
                file.Write(RF.Content + "\n");
            }
            else
            {
                file.Write(zagran.Content + "\n");
            }
            file.Write(sum.Content + "\n");
            //закрыть для сохранения данных
            file.Close();
        }
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
            if(RF.IsChecked == true)
            {
                 
                zagr = 400;
            }
            else
            {
                zagr = 3400;
            }
            sum.Content = zagr + tip + vid;
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
                Raschet();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Filecreate();
            Otprav();
        }
    }
}
