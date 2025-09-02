// File: Authorization/Users/User.cs
using System;
using System.Collections.Generic;
using Abp.Authorization.Users;
using Abp.Extensions;
using ArabianCo.Domain.Orders;

namespace ArabianCo.Authorization.Users
{
	public class User : AbpUser<User>
	{
		public const string DefaultPassword = "123qwe";

		public static string CreateRandomPassword()
			=> Guid.NewGuid().ToString("N").Truncate(16);

		public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

		// (Optional, existing template method – safe to keep even if not using tenants)
		public static User CreateTenantAdminUser(int tenantId, string emailAddress)
		{
			var user = new User
			{
				TenantId = tenantId,
				UserName = AdminUserName,
				Name = AdminUserName,
				Surname = AdminUserName,
				EmailAddress = emailAddress,
				Roles = new List<UserRole>()
			};

			user.SetNormalizedNames();
			return user;
		}
	}
}
