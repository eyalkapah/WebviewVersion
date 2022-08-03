using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core;

namespace WebviewVersion
{
    public class WebView2Manager
    {
        private const string _downloadWebViewUrl =
            "https://go.microsoft.com/fwlink/?linkid=2198254";

        private static readonly object SyncRoot = new object();
        private static WebView2InstallInfo _installInfo;

        public static WebView2InstallInfo InstallInfo
        {
            get
            {
                lock (SyncRoot)
                {
                    if (_installInfo != null)
                        return _installInfo;

                    string version;

                    try
                    {
                        version = CoreWebView2Environment.GetAvailableBrowserVersionString();
                    }
                    catch (Exception)
                    {
                        version = "";
                    }

                    _installInfo = new WebView2InstallInfo(version);

                    return _installInfo;
                }
            }
        }

        public string DownloadUrl => _downloadWebViewUrl;

        public bool IsExists => !InstallInfo.Version.IsNullOrEmpty();

        public WebView2InstallInfo GetInfo() => InstallInfo;
    }
}
