using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Minutrade.ECommerce.Dto
{
    [DataContract()]
    public partial class PhoneDto
    {
        [DataMember()]
        public Int64 Id { get; set; }

        [DataMember()]
        public String Cpf { get; set; }

        [DataMember()]
        [Required]
        public Nullable<Int64> ClientId { get; set; }

        [DataMember()]
        [Required]
        public Int16 CodArea { get; set; }

        [DataMember()]
        [Required]
        public String Number { get; set; }
    }
}
