using System.ComponentModel.DataAnnotations;
using FitnessDiary.Enums;

namespace FitnessDiary.Models
{
    public class UserViewModel : BaseViewModel
    {
        public string FullName { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Повторите пароль")]
        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "Пароли не совпадают")]
        //public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Введите адрес электронной почты")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Неверный формат электронной почты")]
        public string Email { get; set; }

        //public Sex Sex { get; set; }
    }
}
