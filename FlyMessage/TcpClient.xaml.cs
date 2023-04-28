using MaterialDesignThemes.Wpf.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlyMessage
{
    /// <summary>
    /// Client
    /// </summary>
    public partial class TcpClient : Window
    {
        private Socket socket;
        private MainWindow main = new MainWindow();
        private CancellationTokenSource token;
        public TcpClient(IPAddress ip)
        {
            InitializeComponent();

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string name = MainWindow.userName;
            socket.Connect(ip, 8888);

            token = new CancellationTokenSource();
            Task.Run(() => RecieveMessage());
            Task.Run(() => SendName());
            Task.Run(() => RecieveName());
        }
        private async Task SendName()
        {
            string name = MainWindow.userName;
            byte[] bytes = Encoding.UTF8.GetBytes(name);
            await socket.SendAsync(bytes, SocketFlags.None);

            Dispatcher.Invoke(() => Users.Items.Add(name));
        }
        private async Task RecieveName()
        {
            while (!token.IsCancellationRequested)
            {
                byte[] bytes = new byte[1024];
                await socket.ReceiveAsync(new ArraySegment<byte>(bytes), SocketFlags.None);
                string name = Encoding.UTF8.GetString(bytes);

                Dispatcher.Invoke(() => Users.Items.Add(name));
            }
        }
        private async Task SendMessage(string message)
        {
            if (message == "/disconnect")
            {
                token.Cancel();
                main.Show();
                Close();
            }
            else
            {
                message = $"{DateTime.Now} Сообщение от {MainWindow.userName}: {message}";
                byte[] bytes = Encoding.UTF8.GetBytes(message);
                await socket.SendAsync(bytes, SocketFlags.None);

                Dispatcher.Invoke(() => first.Items.Add(message));
                box.Clear();
            }
        }
        private async Task RecieveMessage()
        {
            while (!token.IsCancellationRequested)
            {
                DateTime dateTime = DateTime.Now;
                byte[] bytes = new byte[1024];
                await socket.ReceiveAsync(new ArraySegment<byte>(bytes), SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);

                Dispatcher.Invoke(() => first.Items.Add(message));
            }
        }
        private void but_Click(object sender, RoutedEventArgs e)
        {
            string message = box.Text;
            SendMessage(message);
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            token.Cancel();
            main.Show();
            Close();
        }
        private void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                but_Click(sender, e);
            }
        }
        private void CloseWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            token.Cancel();
            main.Show();
        }
    }
}
