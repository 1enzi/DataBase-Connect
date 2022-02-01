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
    [EntityLogicalName("max_agreement")]
    [DataContract]
    public class Agreement : Entity
    {
        public Agreement() : base("max_agreement") { }
        public Agreement(Guid id) : base("max_agreement", id) { }

        [DataMember]
        public string max_name
        {
            get => GetAttributeValue<string>("max_name");
            set => this["max_name"] = value;
        }

        [DataMember]
        public DateTime? createdon
        {
            get => GetAttributeValue<DateTime?>("createdon");
            set => this["createdon"] = value;
        }
    }
}