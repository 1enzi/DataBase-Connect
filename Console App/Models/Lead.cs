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
    [EntityLogicalName("lead")]
    [DataContract]
    public class Lead : Entity
    {
        public Lead() : base("lead") { }
        public Lead(Guid id) : base("lead", id) { }

        [DataMember]
        public DateTime? createdon
        {
            get => GetAttributeValue<DateTime?>("createdon");
            set => this["createdon"] = value;
        }

        [DataMember]
        public string fullname
        {
            get => GetAttributeValue<string>("fullname");
            set => this["fullname"] = value;
        }

        [DataMember]
        public string firstname
        {
            get => GetAttributeValue<string>("firstname");
            set => this["forstname"] = value;
        }
    }
}