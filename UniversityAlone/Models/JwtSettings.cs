namespace UniversityDB.Models
{
    public class JwtSettings
    {
        public bool ValidateIsUserSignIngKey { get; set; }
        public string IsUserSignInKey { get; set; } = string.Empty;

        public bool ValidateIsUser { get; set; } = true;
        public string? ValidIsUser { get; set; }

        public bool ValidateAudience { get; set; } = true;
        public string? ValidAudience { get; set; }

        public bool RequireExpirationTime { get; set; }
        public bool ValidateLifeTime { get; set; } = true;
    }
}
