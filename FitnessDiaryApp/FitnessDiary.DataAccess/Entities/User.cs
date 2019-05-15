using System.ComponentModel.DataAnnotations;
using FitnessDiary.DataAccess.Enums;

namespace FitnessDiary.DataAccess.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        //public Sex Sex { get; set; }
    }
}
