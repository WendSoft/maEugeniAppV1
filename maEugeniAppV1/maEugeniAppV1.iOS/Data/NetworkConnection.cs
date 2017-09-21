using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using maEugeniAppV1.Data;
using SystemConfiguration;
using CoreFoundation;
using Xamarin.Forms;
using maEugeniAppV1.iOS.Data;

[assembly: Dependency(typeof(NetworkConnection))]

namespace maEugeniAppV1.iOS.Data
{
    public class NetworkConnection : INetworkConnection
    {
        public bool IsConnected { get; set; }

        public void CheckNetworkConnection()
        {
            InternetStatus();
        }

        public bool InternetStatus()
        {
            NetworkReachabilityFlags flags;
            bool defaultNetworkAvailable = IsNetworkAvailable(out flags);
            if (defaultNetworkAvailable && ((flags & NetworkReachabilityFlags.IsDirect) != 0))
            {
                return false;
            }
            else if ((flags & NetworkReachabilityFlags.IsWWAN) != 0)
            {
                return false;
            }
            return true;
        }

        private event EventHandler ReachabilityChanged;
        private void OnChange(NetworkReachabilityFlags flags)
        {
            var h = ReachabilityChanged;
            if (h != null)
            {
                h(null, EventArgs.Empty);
            }
        }

        private NetworkReachability defaultReachhability;
        public bool IsNetworkAvailable(out NetworkReachabilityFlags flags)
        {
            if (defaultReachhability == null)
            {
                defaultReachhability = new NetworkReachability(new System.Net.IPAddress(0));
                defaultReachhability.SetNotification(OnChange);
                defaultReachhability.Schedule(CFRunLoop.Current, CFRunLoop.ModeDefault);
            }
            if (!defaultReachhability.TryGetFlags(out flags)){
                return false;
            }
            return IsReachablewithoutRequiringConnection(flags);
        }

        private bool IsReachablewithoutRequiringConnection(NetworkReachabilityFlags flags)
        {
            bool isReachable = (flags & NetworkReachabilityFlags.Reachable) != 0;
            bool notConnectionRequired = (flags & NetworkReachabilityFlags.ConnectionRequired) == 0;

            if ((flags & NetworkReachabilityFlags.IsWWAN) != 0)
                notConnectionRequired = true;
            return isReachable && notConnectionRequired;

        }
    }
}