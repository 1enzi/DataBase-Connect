using CRM365_Connect_App.Infrastructure.Models;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM365_Connect_App.Infrastructure
{
    public static class CrmRepository
    {
        public static DataCollection<Entity> TopTenActiveContacts(this IOrganizationService _service)
        {
            var qx = new QueryExpression("contact")
            {
                TopCount = 10,
                ColumnSet = new ColumnSet("statecode", "firstname")
            };

            qx.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);

            return _service.RetrieveMultiple(qx).Entities;
        }

        public static DataCollection<Entity> TopFifeteenLeads(this IOrganizationService _service)
        {
            var qx = new QueryExpression("lead")
            {
                ColumnSet = new ColumnSet("fullname", "createdon", "firstname"),
                TopCount = 10
            };

            qx.Criteria.AddCondition("createdon", ConditionOperator.GreaterThan, "10.09.2019");
            qx.Criteria.AddCondition("firstname", ConditionOperator.Like, "%Ир%");

            return _service.RetrieveMultiple(qx).Entities;
        }

        public static DataCollection<Entity> ActiveUsersCreatedOnLastMounth(this IOrganizationService _service)
        {
            var qx = new QueryExpression("systemuser")
            {
                ColumnSet = new ColumnSet("createdon", "lastname", "fullname")
            };

            qx.Criteria.AddCondition("createdon", ConditionOperator.LastMonth);

            return _service.RetrieveMultiple(qx).Entities;
        }

        public static DataCollection<Entity> StudentsWithMiddlenameCreatedOnLastMounth(this IOrganizationService _service)
        {
            var qx = new QueryExpression("contact")
            {
                ColumnSet = new ColumnSet("customertypecode", "createdon", "middlename", "fullname"),
                TopCount = 10
            };

            qx.AddOrder("createdon", OrderType.Ascending);
            qx.Criteria.AddCondition("middlename", ConditionOperator.NotNull);
            qx.Criteria.AddCondition("customertypecode", ConditionOperator.Equal, 1);
            qx.Criteria.AddCondition("createdon", ConditionOperator.LastMonth);

            return _service.RetrieveMultiple(qx).Entities;
        }

        public static DataCollection<Entity> CountOfContactsWithCustomIssueYear(this IOrganizationService _service)
        {
            var qx = new QueryExpression("contact")
            {
                ColumnSet = new ColumnSet("customertypecode", "createdon", "middlename", "lastname",
                "max_issueyear"),
                TopCount = 10
            };

            var criteriaOne = new FilterExpression();
            var criteriaTwo = new FilterExpression();
            qx.Criteria.AddFilter(criteriaOne);
            qx.Criteria.AddFilter(criteriaTwo);
            criteriaOne.FilterOperator = LogicalOperator.Or;
            criteriaOne.AddCondition("customertypecode", ConditionOperator.Equal, 1);
            criteriaOne.AddCondition("customertypecode", ConditionOperator.Equal, 809720000);
            criteriaTwo.AddCondition("max_issueyear", ConditionOperator.Between, 2019, 2021);

            return _service.RetrieveMultiple(qx).Entities;
        }

        public static DataCollection<Entity> AgreementsWithNullStatecode(this IOrganizationService _service)
        {
            var qx = new QueryExpression("max_agreement")
            {
                ColumnSet = new ColumnSet("max_name", "createdon"),
                TopCount = 10
            };

            var territoryLink = qx.AddLink("territory", "max_territoryid", "territoryid");
            territoryLink.LinkCriteria.AddCondition("max_territorycode", ConditionOperator.Equal, "0");

            var systemuserLink = territoryLink.AddLink("systemuser", "max_headofterritory", "systemuserid");

            var systemuserCriteria = new FilterExpression();
            systemuserLink.LinkCriteria.AddFilter(systemuserCriteria);
            systemuserCriteria.FilterOperator = LogicalOperator.And;
            systemuserCriteria.AddCondition("firstname", ConditionOperator.Equal, "Мария");
            systemuserCriteria.AddCondition("lastname", ConditionOperator.Equal, "Розанова");

            return _service.RetrieveMultiple(qx).Entities;
        }

        public static DataCollection<Entity> AgreementsWithCRMAdminManager(this IOrganizationService _service)
        {
            var qx = new QueryExpression("max_agreement")
            {
                ColumnSet = new ColumnSet("max_name", "createdon"),
                TopCount = 10
            };

            qx.Criteria.AddCondition("statuscode", ConditionOperator.Equal, 809720006);
            var systemuserLink = qx.AddLink("systemuser", "max_manager_systemuserid", "systemuserid");
            systemuserLink.LinkCriteria.AddCondition("systemuserid", ConditionOperator.Equal, "DBEAF0FC-657B-EB11-B1AB-000D3ABAAA7D");

            var courceLink = qx.AddLink("max_course", "max_courseid", "max_courseid");
            courceLink.LinkCriteria.AddCondition("max_coursecurrentcost", ConditionOperator.GreaterThan, 1000);

            var productLink = courceLink.AddLink("max_product", "max_maxproductid", "max_productid");
            productLink.LinkCriteria.AddCondition("max_productcode", ConditionOperator.Equal, "DY");

            var groupLink = qx.AddLink("max_group", "max_groupid", "max_groupid");
            var bookableresourceLink = groupLink.AddLink("bookableresource", "max_tutor_bookableresourceid", "bookableresourceid");
            var territoryLink = bookableresourceLink.AddLink("territory", "max_territoryid", "territoryid");
            territoryLink.LinkCriteria.AddCondition("name", ConditionOperator.Equal, "Москва");

            return _service.RetrieveMultiple(qx).Entities;
        }

        public static Guid GetMoscowTerritoryId(this IOrganizationService _service)
        {
            var qx = new QueryExpression("territory")
            {
                ColumnSet = new ColumnSet("name", "territoryid")
            };

            qx.Criteria.AddCondition("territoryid", ConditionOperator.Equal, "B0CFCFAE-D795-E811-A964-000D3AB5CCB7");


            var entity = _service.RetrieveMultiple(qx).Entities.FirstOrDefault();
            return entity.GetAttributeValue<Guid>("territoryid");
        }

        public static Guid GetOnlineTerritoryId(this IOrganizationService _service)
        {
            var qx = new QueryExpression("territory")
            {
                ColumnSet = new ColumnSet("name", "territoryid")
            };

            qx.Criteria.AddCondition("territoryid", ConditionOperator.Equal, "4BD73EB0-39C2-E811-A987-000D3AB4CCCD");

            var entity = _service.RetrieveMultiple(qx).Entities.FirstOrDefault();
            return entity.GetAttributeValue<Guid>("territoryid");
        }

        public static Guid GetMoscowRegionId(this IOrganizationService _service)
        {
            var qx = new QueryExpression("max_region")
            {
                ColumnSet = new ColumnSet("max_name", "max_regionid")
            };

            qx.Criteria.AddCondition("max_regionid", ConditionOperator.Equal, "EEDDAF33-27EF-E811-A982-000D3AB20EDC");

            var entity = _service.RetrieveMultiple(qx).Entities.FirstOrDefault();
            return entity.GetAttributeValue<Guid>("max_regionid");
        }

        public static Guid GetAccountId(this IOrganizationService _service)
        {
            var qx = new QueryExpression("account")
            {
                ColumnSet = new ColumnSet("accountid")
            };

            var entity = _service.RetrieveMultiple(qx).Entities.FirstOrDefault();
            return entity.GetAttributeValue<Guid>("accountid");
        }
    }
}