using Abp;
using Abp.Authorization.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static ArabianCo.Enums.Enum;

namespace ArabianCo.MaintenanceRequests.Dto;

public class CreateMaintenanceRequestDto : IValidatableObject, IShouldInitialize
{
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string Email { get; set; }
    [Required]
    [StringLength(AbpUserBase.MaxNameLength)]
    public string FullName { get; set; }
    [Required]
    [MaxLength(10)]
    [MinLength(10)]
    public string PhoneNumber { get; set; }
    public string SerialNumber { get; set; }
    public string ModelNumber { get; set; }
    public string Problem { get; set; }
    public MaintenanceRequestsStatus Status { get; set; }
    [Required]
    public bool IsInWarrantyPeriod { get; set; }

    public int CityId { get; set; }
    public string Street { get; set; }
    public string Area { get; set; }
    public string OtherNotes { get; set; }

    [Required]
    public int BrandId { get; set; }
    [Required]
    public int CategoryId { get; set; }
    public int? AttachmentId { get; set; }

    public void Initialize()
    {
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (CityId <= 0)
        {
            yield return new ValidationResult("CityId is required", new[] { nameof(CityId) });
        }
        if (string.IsNullOrWhiteSpace(Street))
        {
            yield return new ValidationResult("Street is required", new[] { nameof(Street) });
        }
        if (string.IsNullOrWhiteSpace(Area))
        {
            yield return new ValidationResult("Area is required", new[] { nameof(Area) });
        }
        yield break;
    }
}
