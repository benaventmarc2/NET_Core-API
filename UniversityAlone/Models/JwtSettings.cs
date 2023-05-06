namespace UniversityDB.Models
{
    public class JwtSettings
    {
        public bool ValidateIsUserSignIngKey { get; set; }
        public string? IsUserSignInKey { get; set; }

        public bool ValidateIsUser { get; set; } = true;
        public string? ValidIsUser { get; set; }

        public bool ValidateAudioence { get; set; } = true;
        public string? ValidAudioence { get; set; }

        public bool RequireExpirationTime { get; set; }
        public bool ValidateLifeTime { get; set; } = true;
    }
}
