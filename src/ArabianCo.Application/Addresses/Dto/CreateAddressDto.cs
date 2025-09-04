using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using ArabianCo.Domain.Addresses;

namespace ArabianCo.Addresses.Dto
{
    [AutoMapTo(typeof(Address))]
    public class CreateAddressDto
    {
        [Required]
        public int CityId { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string Area { get; set; }

        public string OtherNotes { get; set; }

        public long? UserId { get; set; }
    }
}
