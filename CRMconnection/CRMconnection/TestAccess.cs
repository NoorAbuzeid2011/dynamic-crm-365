using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMConnection
{
   public class TestAccess
    {
       private IOrganizationService _orgService;

    public TestAccess()
       {
           _orgService = ConnectionHelper.connect();
       
       }


       public void Execute()
       {
         //  Guid result = CreateContact("noor1010101", "NoorAbuzaid@Abuzaid.com");

       //    List<Contact> listofresult = GetContactUsingLinqEarlyBound("Noor Abuzaid");
           List<Entity> listofresult2 = GetContactUsingLinqLateBound("Noor Abuzaid");
       }
       
       
       //public Guid CreateContact(string FirstName, string Email)
       //{
       //    Guid ContactGuid = Guid.Empty;

       //    Contact contact = new Contact()
       //    {
       //        FirstName = FirstName,
       //        EMailAddress1 = Email,

       //    };
           
       //        ContactGuid =  _orgService.Create(contact);
       //        //service.SaveChanges();
           
       //    return ContactGuid;
       //}

       //public List<Contact> GetContactUsingLinqEarlyBound(string firstname)
       //{
       //    try
       //    {
       //        using (XrmServiceContext svcContext = new XrmServiceContext (_orgService))
       //        {
       //            var results = (from a in svcContext.ContactSet
       //                           where a.FirstName == firstname
       //                           select a).ToList();

       //            return results;
       //        }

       //    }
       //    catch (Exception ex)
       //    {
       //        Console.WriteLine("The application terminated with an error.");
       //        Console.WriteLine("Timestamp: {0}", ex.Message);

       //        throw;
       //    }
         

       //}

       public List<Entity> GetContactUsingLinqLateBound(string firstname)
       {
           try
           {
               using (OrganizationServiceContext orgSvcContext = new OrganizationServiceContext(_orgService))
               {
                 var AllContact = (from c in orgSvcContext.CreateQuery("contact")
                                          where ((string)c["firstname"]) == firstname 
                                          select c).ToList();


                   return AllContact;
               }
           }

           catch (Exception ex)
           {
               Console.WriteLine("The application terminated with an error.");
               Console.WriteLine("Timestamp: {0}", ex.Message);
             
               throw;
           }
     
       }
   }
}
//Early bound
//Late bound
//Query data in Dynamics 365: There are three ways in which you can retrieve or query data from Dynamics 365 using the SDK assemblies: FeatchXML, QueryExpression, and .NET LINQ