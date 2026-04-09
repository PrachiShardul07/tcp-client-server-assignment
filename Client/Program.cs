using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {
        TcpClient client = new TcpClient("127.0.0.1", 5000);
        NetworkStream stream = client.GetStream();

        Console.Write("Enter message (e.g. SetA-Two): ");
        string input = Console.ReadLine();

        string encrypted = Encrypt(input);
        byte[] data = Encoding.UTF8.GetBytes(encrypted);

        stream.Write(data, 0, data.Length);

        byte[] buffer = new byte[1024];

        while (true)
        {
            int bytes = stream.Read(buffer, 0, buffer.Length);
            if (bytes == 0) break;

            string encryptedResponse = Encoding.UTF8.GetString(buffer, 0, bytes);
            string response = Decrypt(encryptedResponse);

            Console.WriteLine("Server: " + response);
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