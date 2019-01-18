using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using NavWebServiceDemo.Forms.NavJobListService;

namespace NavWebServiceDemo.Forms
{
    public static class NavService
    {
        private static string _userName = string.Empty;
        private static string _password = string.Empty;

        public static string UserName { set => _userName = value; }
        public static string Password { set => _password = value; }

        public static Job_List_PortClient JobListPortClient()

        {

            return new Job_List_PortClient(
                new BasicHttpsBinding
                {
                    Security =
                    {
                        Mode = BasicHttpsSecurityMode.Transport,
                        Transport = {ClientCredentialType = HttpClientCredentialType.Basic} //Use Basic Auth or
                        //Transport = {ClientCredentialType = HttpClientCredentialType.Windows} //Use Windows Auth
                    }
                }, new EndpointAddress("https://kvscblws01.westeurope.cloudapp.azure.com:7047/NAV/WS/Page/Job_List"))
            {
                ClientCredentials =
                {
                    UserName = {UserName = _userName, Password = _password } //Credentials for Basic Auth or
                    //Windows = { ClientCredential = System.Net.CredentialCache.DefaultNetworkCredentials} //Or use the current network credentials for Windows Auth
                }
            };
        }
    }
}
