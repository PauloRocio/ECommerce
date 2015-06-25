using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Minutrade.ECommerce.Dto
{
    [DataContract()]
    public partial class StateDto
    {
        [DataMember()]
        public Int64 id { get; set; }

        [DataMember()]
        public String StatesName { get; set; }

        [DataMember()]
        public List<Int64> Clients_Id { get; set; }
    }
}
