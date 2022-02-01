using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CRM365_Connect_App.Infrastructure.Models
{
    [EntityLogicalName("contact")]
    [DataContract]
    public class Contact : Entity
    {
        public Contact() : base("contact") { }
        public Contact(Guid id) : base("contact", id) { }

        [DataMember]
        public OptionSetValue statecode
        {
            get => GetAttributeValue<OptionSetValue>("statecode");
            set => this["statecode"] = value;
        }

        [DataMember]
        public string firstaname
        {
            get => GetAttributeValue<string>("firstname");
            set => this["firstname"] = value;
        }

        [DataMember]
        public int? customertypecode
        {
            get => GetAttributeValue<int>("customertypecode");
            set => this["customertypecode"] = value;
        }

        [DataMember]
        public DateTime? createdon
        {
            get => GetAttributeValue<DateTime>("createdon");
            set => this["createdon"] = value;
        }

        [DataMember]
        public string middlename
        {
            get => GetAttributeValue<string>("middlename");
            set => this["middlename"] = value;
        }

        [DataMember]
        public string lastname
        {
            get => GetAttributeValue<string>("lastname");
            set => this["lastname"] = value;
        }

        [DataMember]
        public int max_issueyear
        {
            get => GetAttributeValue<int>("max_issueyear");
            set => this["max_issueyear"] = value;
        }
    }
}