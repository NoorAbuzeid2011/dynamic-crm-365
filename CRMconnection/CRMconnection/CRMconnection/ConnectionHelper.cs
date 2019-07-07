
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMConnection
{
    public class ConnectionHelper
    {
       // OrganizationServiceProxy _orgServiceProxy = null;

        public static IOrganizationService connect()
        {
            //Connecting to Dynamics 365 using Xrm.Sdk.Tooling.Connector
            CrmServiceClient connection;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["CRM"].ConnectionString;
                connection = new Microsoft.Xrm.Tooling.Connector.CrmServiceClient(connectionString);

                connection.OrganizationServiceProxy.Timeout = new TimeSpan(0, 10, 0);
                
                // This statement is required to enable early-bound type support.
               connection.OrganizationServiceProxy.EnableProxyTypes();


                // Connect to the Organization service.
                IOrganizationService orgService = (IOrganizationService)connection.OrganizationWebProxyClient != null ? (IOrganizationService)connection.OrganizationWebProxyClient : (IOrganizationService)connection.OrganizationServiceProxy;

                //_orgServiceProxy = new OrganizationServiceProxy(connection);


                //OrganizationWebProxyClient Implements IOrganizationService and provides an authenticated connection to the Organization.svc/web endpoint. This /web endpoint is also used by web resources.
                //OrganizationServiceProxy  class implements the IOrganizationService and provides an authenticated WCF channel to the organization service
                
                if (!connection.IsReady)
                {
                    Console.WriteLine("Connection failed");

                    Console.WriteLine(connection.LastCrmError);
                    Console.WriteLine(connection.LastCrmException);
                }
                return orgService;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection failed Error while create connection to crm ");

                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //public OrganizationServiceProxy getService()
        //{
        //    return _orgServiceProxy;
        //}
    }
}

//AD and IFD are permitted for Dynamics 365 on-premises instances only.(Active Directory) (Internet-facing deployment)

//OAuth is permitted for Dynamics 365 (online) and on-premises instances.

//Office365 is permitted for Dynamics 365 (online) instances only.