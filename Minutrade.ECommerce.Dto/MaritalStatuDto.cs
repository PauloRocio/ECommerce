using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Minutrade.ECommerce.Dto
{
    [DataContract()]
    public partial class MaritalStatuDto
    {
        [DataMember()]
        public Int64 Id { get; set; }

        [DataMember()]
        public String MaritalStatus { get; set; }

        [DataMember()]
        public List<Int64> Clients_Id { get; set; }
    }
}
