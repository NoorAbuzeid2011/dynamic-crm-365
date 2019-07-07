using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;


namespace CRMConnection
{
  public  class Program
    {
        static void Main(string[] args)
        {


            TestAccess test = new TestAccess();
            test.Execute();
        }

       
    }
}
