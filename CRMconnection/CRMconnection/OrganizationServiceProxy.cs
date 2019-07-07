using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;


using System.Threading.Tasks;
using Microsoft.Xrm.Tooling.Connector;


namespace CRMConnection
{
    public class OrganizationServiceProxy : OrganizationServiceContext, IOrganizationService
    {
        private bool ProxyTypesBehaviorIsAdded = false;
        CrmServiceClient connection;
        IOrganizationService IOService;
        public OrganizationServiceProxy(CrmServiceClient connection)
            : base(connection)
        {
            this.connection = connection;
            this.IOService = connection;
        }

        public new Guid Create(Entity entity)
        {
            if (!ProxyTypesBehaviorIsAdded)
            {
                ProxyTypesBehaviorIsAdded = true;
            }

            return IOService.Create(entity);

        }
        public new OrganizationResponse Execute(OrganizationRequest request)
        {
            if (ProxyTypesBehaviorIsAdded)
            {
                ProxyTypesBehaviorIsAdded = false;
            }
            return IOService.Execute(request);
        }
        public new void Update(Entity entity)
        {
            if (!ProxyTypesBehaviorIsAdded)
            {
                ProxyTypesBehaviorIsAdded = true;
            }

            IOService.Update(entity);

        }
        public new void Delete(string entityName, Guid id)
        {
            if (!ProxyTypesBehaviorIsAdded)
            {
                ProxyTypesBehaviorIsAdded = true;
            }

            IOService.Delete(entityName, id);

        }
        public new void Disassociate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            if (!ProxyTypesBehaviorIsAdded)
            {
                ProxyTypesBehaviorIsAdded = true;
            }

            IOService.Disassociate(entityName, entityId, relationship, relatedEntities);

        }
        public new void Associate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            if (!ProxyTypesBehaviorIsAdded)
            {
                ProxyTypesBehaviorIsAdded = true;
            }

            IOService.Associate(entityName, entityId, relationship, relatedEntities);
        }
        public new Entity Retrieve(string entityName, Guid id, ColumnSet columnSet)
        {
            if (!ProxyTypesBehaviorIsAdded)
            {
                ProxyTypesBehaviorIsAdded = true;
            }

            return IOService.Retrieve(entityName, id, columnSet);
        }
        public new EntityCollection RetrieveMultiple(QueryBase query)
        {
            if (!ProxyTypesBehaviorIsAdded)
            {
                ProxyTypesBehaviorIsAdded = true;
            }

            return IOService.RetrieveMultiple(query);
        }

    }
}
