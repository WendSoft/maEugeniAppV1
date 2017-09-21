using maEugeniAppV1.Data;
using maEugeniAppV1.UWP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

[assembly: Xamarin.Forms.Dependency(typeof(NetworkConnection))]

namespace maEugeniAppV1.UWP.Data
{
    public class NetworkConnection : INetworkConnection
    {
        public bool IsConnected { get; set; }

        public void CheckNetworkConnection()
        {
            ConnectionProfile connections = NetworkInformation.GetInternetConnectionProfile();
            if (connections != null && connections.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess)
            {
                IsConnected = true;
            }
            else
            {
                IsConnected = true;
            }

        }
    }
}
