using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArabianCo.Migrations
{
    /// <inheritdoc />
    public partial class MakeUserRoleDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"
-- 0) Ensure existing roles have NormalizedName
UPDATE AbpRoles SET NormalizedName = UPPER(Name) WHERE NormalizedName IS NULL;

-- 1) Tenants: insert 'User' if missing (static + default)
INSERT INTO AbpRoles (TenantId, Name, NormalizedName, DisplayName, IsStatic, IsDefault, IsDeleted, CreationTime)
SELECT r.TenantId, 'User', 'USER', 'User', 1, 1, 0, GETUTCDATE()
FROM (SELECT DISTINCT TenantId FROM AbpRoles) r
WHERE NOT EXISTS (
    SELECT 1 FROM AbpRoles ar
    WHERE ar.TenantId = r.TenantId AND ar.Name = 'User'
);

-- 2) Host: insert 'User' if missing (TenantId NULL)
IF NOT EXISTS (SELECT 1 FROM AbpRoles WHERE TenantId IS NULL AND Name = 'User')
BEGIN
    INSERT INTO AbpRoles (TenantId, Name, NormalizedName, DisplayName, IsStatic, IsDefault, IsDeleted, CreationTime)
    VALUES (NULL, 'User', 'USER', 'User', 1, 1, 0, GETUTCDATE());
END

-- 3) Flip defaults
UPDATE AbpRoles SET IsDefault = 0 WHERE Name = 'Admin';
UPDATE AbpRoles SET IsDefault = 1 WHERE Name = 'User';
");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"
UPDATE AbpRoles SET IsDefault = 1 WHERE Name = 'Admin';
UPDATE AbpRoles SET IsDefault = 0 WHERE Name = 'User';
");
		}
    }
}
