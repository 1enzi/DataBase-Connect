using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System.ServiceModel.Description;
using System;
using CRM365_Connect_App.Infrastructure;
using System.Linq;
using CRM365_Connect_App.Infrastructure.Models;
using Console_App.Infrastructure;

namespace CRM365_Connect_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IOrganizationService organizationService = null;

            try
            {
                ClientCredentials clientCredentials = new ClientCredentials();
                clientCredentials.UserName.UserName = Config.Username();
                clientCredentials.UserName.Password = Config.Password();

                organizationService = (IOrganizationService)new OrganizationServiceProxy(new Uri(Config.CRMLink()),
                    null, clientCredentials, null);

                var contact1 = new Contact();
                contact1.firstaname = "name";
                contact1.lastname = "test";

                var contactId = organizationService.Create(contact1.ToEntity<Entity>());

                if (organizationService != null)
                {
                    /*Entity contact = CreateEntity.CreateNewContact(organizationService);
                    Entity registration = CreateEntity.CreateNewregistration(organizationService, contact);
                    CreateEntity.UpdateContact(organizationService, contact);
                    CreateEntity.UpdateRegistration(organizationService, registration);*/

                    /*Console.WriteLine("Запросы из тестовой БД, выведенные в консоль.\n");

                    var entities = organizationService.TopTenActiveContacts();
                    Console.WriteLine("\nЗапрос 1.\n");
                    foreach (var entity in entities.Select(e => e.ToEntity<Contact>()))
                    {
                        Console.WriteLine($"Имя контакта: {entity.firstaname} \t\t" +
                            $"Код: {entity.statecode?.Value}");
                        var one = entity.customertypecode;
                        Console.WriteLine(one);
                    }

                    entities = organizationService.TopFifeteenLeads();
                    Console.WriteLine("\nЗапрос 2.\n");
                    foreach (var entity in entities)
                    {
                        Console.WriteLine($"Имя: {entity.GetAttributeValue<string>("fullname")} \t\t" +
                            $"Дата создания: {entity.GetAttributeValue<DateTime>("createdon")}");
                    }

                    entities = organizationService.ActiveUsersCreatedOnLastMounth();
                    Console.WriteLine("\nЗапрос 3.\n");
                    foreach (var entity in entities)
                    {
                        Console.WriteLine($"Дата создания: {entity.GetAttributeValue<DateTime>("createdon")} \t\t" +
                            $"ФИО: {entity.GetAttributeValue<string>("fullname")}");
                    }

                    entities = organizationService.StudentsWithMiddlenameCreatedOnLastMounth();
                    Console.WriteLine("\nЗапрос 4.\n");
                    foreach (var entity in entities)
                    {
                        Console.WriteLine($"Дата создания: {entity.GetAttributeValue<DateTime>("createdon")} \t\t" +
                            $"ФИО: {entity.GetAttributeValue<string>("firstname")}");
                    }

                    entities = organizationService.CountOfContactsWithCustomIssueYear();
                    Console.WriteLine("\nЗапрос 5.\n");
                    foreach (var entity in entities)
                    {
                        Console.WriteLine($"Дата закрытия: {entity.GetAttributeValue<int>("max_issueyear")} \t\t" +
                            $"Фамилия: {entity.GetAttributeValue<string>("lastname")}");
                    }

                    entities = organizationService.AgreementsWithNullStatecode();
                    Console.WriteLine("\nЗапрос 6.\n");
                    foreach (var entity in entities)
                    {
                        Console.WriteLine($"Имя: {entity.GetAttributeValue<string>("max_name")} \t\t" +
                            $"Дата создания: {entity.GetAttributeValue<DateTime>("createdon")}");
                    }

                    entities = organizationService.AgreementsWithCRMAdminManager();
                    Console.WriteLine("\nЗапрос 7.\n");
                    foreach (var entity in entities)
                    {
                        Console.WriteLine($"Имя: {entity.GetAttributeValue<string>("max_name")} \t\t" +
                            $"Дата создания: {entity.GetAttributeValue<DateTime>("createdon")}");
                    }*/
                }

                else
                {
                    Console.WriteLine("Ошибка при подключении.");
                }
                organizationService.TopTenActiveContacts();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}