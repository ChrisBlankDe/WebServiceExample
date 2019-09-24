using System.ServiceModel;
using NavWebServiceDemo.Console.NavJobListService;
using NavWebServiceDemo.Console.NavSystemService;

namespace NavWebServiceDemo.Console
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
                 }, new EndpointAddress("https://ws01.westeurope.cloudapp.azure.com:7047/NAV/WS/Page/Job_List"))
            {
                ClientCredentials =
                {
                    UserName = {UserName = _userName, Password = _password } //Credentials for Basic Auth or
                    //Windows = { ClientCredential = System.Net.CredentialCache.DefaultNetworkCredentials} //Or use the current network credentials for Windows Auth
                    //Windows = { ClientCredential = new System.Net.NetworkCredential("admin", "Start2018Start2018")} //Or use a specific User/Pass for Windows Auth
                }
            };
        }

        public static SystemService_PortClient SystemServicePortClient()
        {
            return new SystemService_PortClient(
                new BasicHttpsBinding
                {
                    Security =
                    {
                        Mode = BasicHttpsSecurityMode.Transport,
                        Transport = {ClientCredentialType = HttpClientCredentialType.Basic} //Use Basic Auth or
                        //Transport = {ClientCredentialType = HttpClientCredentialType.Windows} //Use Windows Auth
                    }
                }, new EndpointAddress("https://ws01.westeurope.cloudapp.azure.com:7047/NAV/WS/SystemService"))
            {
                ClientCredentials =
                {
                    UserName = {UserName = "admin", Password = "Start2018Start2018"} //Credentials for Basic Auth or
                    //Windows = { ClientCredential = System.Net.CredentialCache.DefaultNetworkCredentials} //Or use the current network credentials for Windows Auth
                    //Windows = { ClientCredential = new System.Net.NetworkCredential("admin", "Start2018Start2018")} //Or use a specific User/Pass for Windows Auth
                }
            };
        }
//         HTTP Example:
//         public static SystemService_PortClient SystemServicePortClient()
//         {
//             return new SystemService_PortClient(
//                 new BasicHttpBinding
//                 {
//                     Security =
//                     {
//                         Mode = BasicHttpSecurityMode.TransportCredentialOnly,
//                         Transport = {ClientCredentialType = HttpClientCredentialType.Basic} //Use Basic Auth or
//                         //Transport = {ClientCredentialType = HttpClientCredentialType.Windows} //Use Windows Auth
//                     }
//                 }, new EndpointAddress("https://ws01.westeurope.cloudapp.azure.com:7047/NAV/WS/SystemService"))
//             {
//                 ClientCredentials =
//                 {
//                     UserName = {UserName = "admin", Password = "Start2018Start2018"} //Credentials for Basic Auth or
//                     //Windows = { ClientCredential = System.Net.CredentialCache.DefaultNetworkCredentials} //Or use the current network credentials for Windows Auth
//                     //Windows = { ClientCredential = new System.Net.NetworkCredential("admin", "Start2018Start2018")} //Or use a specific User/Pass for Windows Auth
//                 }
//             };
//         }

    }
}
