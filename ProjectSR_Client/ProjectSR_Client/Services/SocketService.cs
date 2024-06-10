using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProjectSR_Client.Classes;
using ProjectSR_Client.Views;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectSR_Client.Services
{
    internal class SocketService
    {
        private string id;
        private string username;

        private Socket clientSocket;
        private Thread receiveThread;

        private HomeWindow homeWindow;
        private GameXO xoGameWindow;


        private static SocketService _instance = new SocketService();
        private static readonly object _lock = new object();

        private SocketService()
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public static SocketService Instance
        {
            get
            {
                lock (_lock)
                {
                    return _instance;
                }
            }
        }

        public string Id
        {
            get => id;
            set => id = value;
        }

        public string Username
        {
            get => username;
            set => username = value;
        }

        public HomeWindow MainWindow
        {
            get => homeWindow;
            set => homeWindow = value;
        }



        public bool doConnect(string ipAddress, int port)
        {
            try
            {
                // Set the server endpoint
                IPAddress ip = IPAddress.Parse(ipAddress);
                IPEndPoint endPoint = new IPEndPoint(ip, port);
                clientSocket.Connect(endPoint);

                receiveThread = new Thread(new ThreadStart(ReceiveData));
                receiveThread.IsBackground = true;
                receiveThread.Start();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to connect: {ex.Message}");
                return false;
            }
        }

        private void ProcessMessage(SocketMessage socketMessage)
        {
            Console.WriteLine($"Received: {socketMessage.SenderId} {socketMessage.Type}");

            if (socketMessage.Type == "setId")
            {
                this.id = socketMessage.Payload.ToString();
                Console.WriteLine("Recieved ID from server: " + socketMessage.Payload.ToString());

                SocketMessage sm = new SocketMessage();
                sm.SenderId = this.id;
                sm.Type = "setUsername";
                sm.Payload = this.username;

                SendData(sm);
            }

            if (socketMessage.Type == "usersList")
            {
                Dictionary<string, string> clients = JsonConvert.DeserializeObject<Dictionary<string, string>>(socketMessage.Payload.ToString());
                this.homeWindow.Invoke(new Action(() =>
                {
                    this.homeWindow.panel_usersList.Controls.Clear();
                }));

                foreach (KeyValuePair<string, string> client in clients)
                {
                    this.homeWindow.Invoke(new Action(() =>
                    {
                        UserListItem uli = new UserListItem(client.Key, client.Value);
                        this.homeWindow.panel_usersList.Controls.Add(uli);
                        uli.Dock = DockStyle.Top;
                        uli.Show();
                    }));
                }
                Console.WriteLine(socketMessage.Payload);
            }

            if (socketMessage.Type == "chat")
            {
                string username = socketMessage.SenderUsername;
                string message = socketMessage.Payload.ToString();
                string formattedMessage = $"{username}: {message}\n";


                this.homeWindow.Invoke(new Action(() =>
                {
                    this.homeWindow.richTextBox1.AppendText(formattedMessage);

                    int start = homeWindow.richTextBox1.Text.LastIndexOf(formattedMessage);
                    int usernameLength = username.Length;

                    // Select the username text
                    homeWindow.richTextBox1.Select(start, usernameLength);

                    // Set the selected text to bold
                    homeWindow.richTextBox1.SelectionFont = new Font(homeWindow.richTextBox1.Font, FontStyle.Bold);

                    // Reset the selection to the end for further typing or appending
                    homeWindow.richTextBox1.Select(homeWindow.richTextBox1.TextLength, 0);
                    homeWindow.richTextBox1.SelectionFont = new Font(homeWindow.richTextBox1.Font, FontStyle.Regular);

                }));
            }

            if (socketMessage.Type == "gameInvite")
            {
                Console.WriteLine("recieved a game invite!");
                this.homeWindow.Invoke(new Action(() =>
                {
                    GameInviteRequest request = new GameInviteRequest(socketMessage);
                    request.Show();
                }));
            }

            if (socketMessage.Type == "gameStart")
            {
                XO game = jsonToObject<XO>(socketMessage.Payload.ToString());

                this.homeWindow.Invoke(new Action(() =>
                {
                    xoGameWindow = new GameXO(game);
                    xoGameWindow.Show();
                }));
            }

            if (socketMessage.Type == "gameUpdate")
            {
                XO game = jsonToObject<XO>(socketMessage.Payload.ToString());
                Console.WriteLine(game.Data);
                //game.Matrice = jsonToObject<String[]>(game.Data);
                this.xoGameWindow.Invoke(new Action(() =>
                {
                    this.xoGameWindow.updateGame(game);
                }));
            }


        }

        public void SendData(SocketMessage message)
        {
            try
            {
                message.SenderId = this.id;
                message.SenderUsername = this.username;

                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                string json = JsonConvert.SerializeObject(message, settings) + "\n";
                byte[] buffer = Encoding.UTF8.GetBytes(json);
                clientSocket.Send(buffer);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in sending data: {ex.Message}");
            }
        }

        private void ReceiveData()
        {
            //try
            //{
            byte[] buffer = new byte[1024];
            StringBuilder jsonBuilder = new StringBuilder();

            int bytesReceived;
            while ((bytesReceived = clientSocket.Receive(buffer)) > 0)
            {
                string jsonFragment = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                Console.WriteLine("Recieved json: ", jsonFragment);
                // Check for a complete message ending delimiter
                if (jsonFragment.Contains("\n")) // Assuming newline is a delimiter
                {
                    jsonBuilder.Append(jsonFragment);
                    string json = jsonBuilder.ToString().TrimEnd('\0');
                    SocketMessage receivedMessage = JsonConvert.DeserializeObject<SocketMessage>(json);
                    ProcessMessage(receivedMessage);
                    jsonBuilder.Clear();  // Clear after processing
                }
                else
                {
                    jsonBuilder.Append(jsonFragment);  // Append more data
                }
            }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Receive Thread Exception: {ex.Message}");
            //}
        }

        private T jsonToObject<T>(string json)
        {
            if (string.IsNullOrEmpty(json))
                throw new ArgumentException("Input json string cannot be null or empty.");

            string processedJson = json.Trim();
            T resultObject = JsonConvert.DeserializeObject<T>(processedJson);
            return resultObject;
        }

    }
}
