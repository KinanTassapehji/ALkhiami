using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Users;
using Abp.Extensions;

namespace ArabianCo.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress, string phoneNumber)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                PhoneNumber = phoneNumber,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            return user;
        }

        [Required]
        [StringLength(AbpUserBase.MaxPhoneNumberLength)]
        public override string PhoneNumber { get; set; }

        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public override string EmailAddress { get; set; }
    }
}
