
using FitnessDiary.DataAccess.Enums;

namespace FitnessDiary.BusinessLogic.Dtos
{
    public class UserDto : BaseDto
    {
        public string FullName { get; set; }
        //public Sex Sex { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
