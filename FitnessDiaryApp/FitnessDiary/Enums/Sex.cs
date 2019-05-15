using System.ComponentModel;

namespace FitnessDiary.Enums
{
    public enum Sex
    {
        [DisplayName(displayName: "Мужской")]
        Male,
        [DisplayName(displayName: "Женский")]
        Female
    }
}