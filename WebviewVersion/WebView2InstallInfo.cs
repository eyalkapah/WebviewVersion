using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebviewVersion
{
    public class WebView2InstallInfo
    {
        public string Version { get; }

        public WebView2InstallType InstallType
        {
            get
            {
                //https://docs.microsoft.com/en-us/microsoft-edge/webview2/how-to/set-preview-channel
                switch (Version)
                {
                    case var version when version.Contains("dev"):
                        return WebView2InstallType.EdgeChromiumDev;
                    case var version when version.Contains("beta"):
                        return WebView2InstallType.EdgeChromiumBeta;
                    case var version when version.Contains("canary"):
                        return WebView2InstallType.EdgeChromiumCanary;
                    case var version when !string.IsNullOrEmpty(version):
                        return WebView2InstallType.WebView2;
                    default:
                        return WebView2InstallType.NotInstalled;
                }
            }
        }

        // C'tor
        //
        public WebView2InstallInfo(string version)
        {
            Version = version;
        }
    }
}
