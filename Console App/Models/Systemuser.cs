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
    [EntityLogicalName("systemuser")]
    [DataContract]
    public class Sustemuser : Entity
    {
        public Sustemuser() : base("max_agreement") { }
        public Sustemuser(Guid id) : base("max_agreement", id) { }

        [DataMember]
        public DateTime? createdon
        {
            get => GetAttributeValue<DateTime?>("createdon");
            set => this["createdon"] = value;
        }

        [DataMember]
        public string lastname
        {
            get => GetAttributeValue<string>("lastname");
            set => this["lastname"] = value;
        }

        [DataMember]
        public string firstname
        {
            get => GetAttributeValue<string>("firstname");
            set => this["firstname"] = value;
        }
    }
}