using CRM365_Connect_App.Infrastructure;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace Console_App.Infrastructure
{
    public static class CreateEntity
    {
        public static Entity CreateNewContact(IOrganizationService _service)
        {
            var contact = new Entity("contact");

            contact["firstname"] = "Ирина";
            contact["lastname"] = "Карпенко";
            contact["middlename"] = "Михайловна";
            contact["customertypecode"] = new OptionSetValue(809720000);
            contact["max_territoryid"] = new EntityReference("territory", _service.GetMoscowTerritoryId());
            contact["parentcustomerid"] = new EntityReference("account", _service.GetAccountId());
            contact["max_regionid"] = new EntityReference("max_region", _service.GetMoscowRegionId());
            contact["telephone1"] = "89990100010";
            contact["emailaddress1"] = "someEmail@mail.ru";
            contact["adx_timezone"] = 145;

            contact.Id = _service.Create(contact);
            return contact;
        }

        public static void UpdateContact(IOrganizationService _service, Entity contact)
        {
            var cols = new ColumnSet("customertypecode", "max_territoryid");

            contact = _service.Retrieve(contact.LogicalName, contact.Id, cols);
            contact["customertypecode"] = new OptionSetValue(1);
            contact["max_territoryid"] = new EntityReference("territory", _service.GetOnlineTerritoryId());

            _service.Update(contact);
        }

        public static Entity CreateNewregistration(IOrganizationService _service, Entity contact)
        {
            var registration = new Entity("max_registration");

            registration["max_parent1lastname"] = "Карпенко";
            registration["max_parent1firstname"] = "Ирина";
            registration["max_parent1middlename"] = "Михайловна";
            registration["max_gendercode_r1"] = new OptionSetValue(809720001);
            registration["max_parent1telephone"] = "89990100010";
            registration["max_parent1email"] = "someEmail@mail.ru";
            registration["max_parent1contactid"] = contact.ToEntityReference();

            registration.Id = _service.Create(registration);
            return registration;
        }

        public static void UpdateRegistration(IOrganizationService _service, Entity registration)
        {
            var cols = new ColumnSet(
                new String[] { "max_parent1lastname", "max_parent1firstname", "max_parent1middlename",
                "max_gendercode_r1", "max_parent1telephone", "max_parent1email", "max_parent1contactid",
                "max_studentlastname", "max_studentfirstname", "max_studentmiddlename", "max_gendercode_sh",
                "max_studenttelephone", "max_studentemail", "max_studentcontactid"});

            registration = _service.Retrieve(registration.LogicalName, registration.Id, cols);

            registration["max_studentlastname"] = registration["max_parent1lastname"];
            registration["max_studentfirstname"] = registration["max_parent1firstname"];
            registration["max_studentmiddlename"] = registration["max_parent1middlename"];
            registration["max_gendercode_sh"] = registration["max_gendercode_r1"];
            registration["max_studenttelephone"] = registration["max_parent1telephone"];
            registration["max_studentemail"] = registration["max_parent1email"];
            registration["max_studentcontactid"] = registration["max_parent1contactid"];

            registration["max_parent1lastname"] = null;
            registration["max_parent1firstname"] = null;
            registration["max_parent1middlename"] = null;
            registration["max_gendercode_r1"] = null;
            registration["max_parent1telephone"] = null;
            registration["max_parent1email"] = null;
            registration["max_parent1contactid"] = null;

            _service.Update(registration);
        }
    }
}
