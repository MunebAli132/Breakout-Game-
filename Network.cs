using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Breakout
{
    internal class Network
    {
        public static Network Instance { get; } = new Network();
        Network() { }
        const int port = 9123;
        Socket? socket;
        IPEndPoint? address;
        readonly IPEndPoint broadcastAddress = new(IPAddress.Broadcast, port);
        readonly IPEndPoint broadcastAddress2 = new(IPAddress.Broadcast, port + 1);
        readonly List<Session> Sessions = new();

        public void Start()
        {
            var ip = GetDefaultGatewayInterface()!.UnicastAddresses
                .First(x => x.Address.AddressFamily == AddressFamily.InterNetwork)
                .Address;
            var processName = Path.GetFileNameWithoutExtension(
                Assembly.GetExecutingAssembly().Location);
            var onlyProcess = Process.GetProcessesByName(processName).Length == 1;
            address = new IPEndPoint(ip, onlyProcess ? port : port + 1);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Bind(address);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);

        }
        public void Stop()
        {
            socket?.Close();
            socket = null;
        }

        public void Send(GameState state)
        {
            var json = JsonSerializer.Serialize(state);
            var buffer = Encoding.UTF8.GetBytes(json);
            socket!.SendTo(buffer, broadcastAddress);
            socket.SendTo(buffer, broadcastAddress2);
        }
        byte[] buffer = new byte[64 * 1024];
        public GameState? Receive(out Session? session)
        {
            if (socket!.Available == 0)
            {
                session = null;
                return null;
            }
            EndPoint ep = new IPEndPoint(IPAddress.Any, 0);
            int bytesReceived = socket.ReceiveFrom(buffer, ref ep);
            if (address!.Equals(ep))
                return Receive(out session);
            session = Sessions.Find(x => x.Address.Equals(ep));
            if (session == null)
                Sessions.Add(session = new Session { Address = (IPEndPoint)ep });
            return JsonSerializer.Deserialize<GameState>(
                Encoding.UTF8.GetString(buffer, 0, bytesReceived));
        }
        static IPInterfaceProperties? GetDefaultGatewayInterface()
        {
            return NetworkInterface.GetAllNetworkInterfaces()
            .Where(n => n.OperationalStatus == OperationalStatus.Up &&
           n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
            .Select(x => x.GetIPProperties())
            .FirstOrDefault(x => x.GatewayAddresses.Any(y => y.Address != null));
        }
    }
}
