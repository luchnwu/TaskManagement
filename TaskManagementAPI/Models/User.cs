using Microsoft.AspNetCore.Identity;

namespace TaskManagementAPI.Models
{
    public class User: IdentityUser
    {
        public override string? Id { get; set; }

        public override string UserName { get; set; } = null!;

        public override string PasswordHash { get; set; } = null!;
    }
}
