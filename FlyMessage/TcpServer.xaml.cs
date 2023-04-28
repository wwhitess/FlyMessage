using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
using System.Windows.Shapes;
using System.Diagnostics;
using System.Threading;

namespace FlyMessage
{
    public partial class TcpServer : Window
    {
        private Socket socket;
        private List<Socket> sockets = new List<Socket>();
        private MainWindow main = new MainWindow();
        private CancellationTokenSource token;
        public TcpServer()
        {
            InitializeComponent();
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 8888);
            Dispatcher.Invoke(() => Users.Items.Add(MainWindow.serverClientName));
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Bind(ipPoint);
            Log("bind");
            socket.Listen(1000);
            Log("listen");

            token = new CancellationTokenSource();
            Task.Run(() => ListenToClients());
        }
        private async Task ListenToClients()
        {
            while (!token.IsCancellationRequested)
            {
            //Добавление пользователей работает только если у человека
            //тоже добавлены пользователи. В противном случае -  закомментируйте код
            //с string name, до Log("accepted")...
                Log("accepting");
                var client = await socket.AcceptAsync();

                string name = MainWindow.serverClientName;
                byte[] bytes = Encoding.UTF8.GetBytes(name);
                client.Send(bytes, SocketFlags.None);

                Dispatcher.Invoke(() => Users.Items.Add(name));

                byte[] bytesRe = new byte[1024];
                client.Receive(new ArraySegment<byte>(bytesRe), SocketFlags.None);
                string nameRe = Encoding.UTF8.GetString(bytesRe);

                Dispatcher.Invoke(() => Users.Items.Add(nameRe));

                Log("accepted " + ((IPEndPoint)client.RemoteEndPoint).Address);
                sockets.Add(client);

                RecieveMessage(client);
            }
        }
        private async Task RecieveMessage(Socket client)
        {
            while (!token.IsCancellationRequested)
            {
                byte[] bytes = new byte[1024];
                Log("receiving");
                client.Receive(new ArraySegment<byte>(bytes), SocketFlags.None);
                Log("received");
                string message = Encoding.UTF8.GetString(bytes);

               Dispatcher.Invoke(() => first.Items.Add(message));
            }
        }
        private async Task SendMessage(Socket client, string message)
        {
            if (message == "/disconnect")
            {
                token.Cancel();
                main.Show();
                Close();
            }
            else
            {
                message = $"{DateTime.Now} Сообщение от {MainWindow.serverClientName}: {message}";
                byte[] bytes = Encoding.UTF8.GetBytes(message);
                Log("sending");
                client.Send(bytes, SocketFlags.None);
                Log("sent");
                Dispatcher.Invoke(() => first.Items.Add(message));
                box.Clear();
            }
        }
        private void but_Click(object sender, EventArgs e)
        {
            string message = box.Text;
            foreach (var item in sockets)
            {
                SendMessage(item, message);
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            token.Cancel();
            main.Show();
            Close();
        }
        private void Log(string message)
        {
            Dispatcher.Invoke(() => Logs.Items.Add(message));
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
