using System.Threading.Tasks;
using FitnessDiary.BusinessLogic.Dtos;

namespace FitnessDiary.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        UserDto AutheticateUser(string email, string password);
        Task RegisterUser(UserDto userDto);
        UserDto GetUser(string email);
        UserDto GetById(int id);
    }
}