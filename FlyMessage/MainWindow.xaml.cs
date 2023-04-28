using System;
using System.Collections.Generic;
using System.Linq;
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

namespace FlyMessage
{
    public partial class MainWindow : Window
    {
        public static string userName;
        public static string serverClientName;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AddChat_Click(object Sender, RoutedEventArgs e)
        {
            if (Name.Text == "")
            {
                MessageBox.Show("ОШИБКА. Заполните имя!");
            }
            else
            {
                TcpServer server = new TcpServer();
                serverClientName = Name.Text;
                server.Show();
                Close();
            }
        }
        private void ToChatClick(object Sender, RoutedEventArgs e)
        {
            if (Name.Text == "")
            {
                MessageBox.Show("ОШИБКА. Заполните имя!");
            }
            else if (IP.Text == "")
            {
                MessageBox.Show("ОШИБКА. Заполните IP адрес!");
            }
            else
            {
                if (IP.Text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).Length == 4)
                {
                    IPAddress ip;
                    if (IPAddress.TryParse(IP.Text, out ip))
                    {
                        TcpClient client = new TcpClient(ip);
                        userName = Name.Text;
                        client.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Неккоректный IP адрес");
                    }
                }
                else
                {
                    MessageBox.Show("Неверный формат IP");
                }
            }
        }
    }
}
