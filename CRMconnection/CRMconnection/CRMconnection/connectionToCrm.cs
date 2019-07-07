using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using Microsoft.Xrm.Sdk.Client;
using System.Configuration;
using System.Net;
using CrmConnection;
namespace CRMconnection
{
    class connectionToCrm
    {
        public string connectionString;
        public static CrmServiceClient CrmService;

        public connectionToCrm()
        {
            this.connection();
            
        }


        public void connection()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            connectionString = ConfigurationManager.ConnectionStrings["MyCRMServer"].ConnectionString;
            if (connectionString != null)
            {

                CrmService = new CrmServiceClient(connectionString);

                try
                {
                    if (CrmService != null && CrmService.IsReady)
                    {
                        Console.WriteLine("Connected to CRM! (Version: {0}; Org: {1})", CrmService.ConnectedOrgVersion, CrmService.ConnectedOrgUniqueName);
                        
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }

            }
        
        }


        public static OrganizationServiceProxy GetContext()
        {
            OrganizationServiceProxy serviceProxy = (CrmService.OrganizationServiceProxy);
            return serviceProxy;
        }
        public static ServiceContext getserviceProvider()
        {
            OrganizationServiceProxy serviceProxy = (CrmService.OrganizationServiceProxy);
            IOrganizationService service = (IOrganizationService)serviceProxy;
            serviceProxy.EnableProxyTypes();
            ServiceContext svcContext = new ServiceContext(service);
            return svcContext;
        }


    }
}
