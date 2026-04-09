using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static Dictionary<string, Dictionary<string, int>> data =
        new Dictionary<string, Dictionary<string, int>>()
    {
        {"SetA", new Dictionary<string,int>{{"One",1},{"Two",2}}},
        {"SetB", new Dictionary<string,int>{{"Three",3},{"Four",4}}},
        {"SetC", new Dictionary<string,int>{{"Five",5},{"Six",6}}},
        {"SetD", new Dictionary<string,int>{{"Seven",7},{"Eight",8}}},
        {"SetE", new Dictionary<string,int>{{"Nine",9},{"Ten",10}}}
    };

    static void Main()
    {
        TcpListener server = new TcpListener(IPAddress.Any, 5000);
        server.Start();
        Console.WriteLine("Server started on port 5000...");

        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Client connected");

            Thread t = new Thread(() => HandleClient(client));
            t.Start();
        }
    }

    static void HandleClient(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];

        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string encryptedMsg = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        string message = Decrypt(encryptedMsg);
        Console.WriteLine("Received: " + message);

        string[] parts = message.Split('-');

        if (parts.Length == 2 &&
            data.ContainsKey(parts[0]) &&
            data[parts[0]].ContainsKey(parts[1]))
        {
            int count = data[parts[0]][parts[1]];

            for (int i = 0; i < count; i++)
            {
                string time = DateTime.Now.ToString();
                string encrypted = Encrypt(time);

                byte[] response = Encoding.UTF8.GetBytes(encrypted);
                stream.Write(response, 0, response.Length);

                Thread.Sleep(1000);
            }
        }
        else
        {
            string encrypted = Encrypt("EMPTY");
            byte[] response = Encoding.UTF8.GetBytes(encrypted);
            stream.Write(response, 0, response.Length);
        }

        client.Close();
    }

    static string Encrypt(string text)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
    }

    static string Decrypt(string text)
    {
        return Encoding.UTF8.GetString(Convert.FromBase64String(text));
    }
}