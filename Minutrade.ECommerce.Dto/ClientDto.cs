using System;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Minutrade.ECommerce.Dto
{
    [DataContract()]
    public partial class ClientDto
    {
        [DataMember()]
        public Int64 Id { get; set; }

        [DataMember()]
        [Required]
        public Nullable<Int64> MaritalStatusId { get; set; }

        [DataMember()]
        public string MaritalStatusName { get; set; }

        [DataMember()]
        [Required]
        public Int64 StateId { get; set; }

        [DataMember()]
        public string StateName { get; set; }

        [DataMember()]
        [Required]
        public String Cpf { get; set; }

        [DataMember()]
        [Required]
        public String Name { get; set; }

        [DataMember()]
        [Required]
        public String Email { get; set; }

        [DataMember()]
        [Required]
        public String Street { get; set; }

        [DataMember()]
        [Required]
        public String Neighborhood { get; set; }

        [DataMember()]
        [Required]
        public Int32 Number { get; set; }

        [DataMember()]
        [Required]
        public String CEP { get; set; }

        [DataMember()]
        public String Complement { get; set; }

        [DataMember()]
        public String ReferenceInformation { get; set; }
    }
}
