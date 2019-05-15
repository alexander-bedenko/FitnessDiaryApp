using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using FitnessDiary.BusinessLogic.Dtos;
using FitnessDiary.BusinessLogic.Interfaces;
using FitnessDiary.BusinessLogic.Providers;
using FitnessDiary.DataAccess.Entities;
using FitnessDiary.DataAccess.Interfaces;

namespace FitnessDiary.BusinessLogic.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork uow)
            : base(uow)
        {
        }

        public UserDto AutheticateUser(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = _uow.Repository<User>().Get(e => e.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return Mapper.Map<UserDto>(user);
        }

        public UserDto GetUser(string email)
        {
            var user = _uow.Repository<User>().Get(u => u.Email == email);
            return Mapper.Map<User, UserDto>(user);
        }

        public async Task RegisterUser(UserDto userDto)
        {
            // validation
            if (string.IsNullOrWhiteSpace(userDto.Password))
                throw new ValidationException("Password is required");

            if (_uow.Repository<User>().Get(e => e.Email.Equals(userDto.Email, StringComparison.OrdinalIgnoreCase)) != null)
                throw new ValidationException("Username \"" + userDto.FullName + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(userDto.Password, out passwordHash, out passwordSalt);

            var user = Mapper.Map<User>(userDto);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _uow.Repository<User>().Create(user);
            await _uow.Commit();
        }

        public UserDto GetById(int id)
        {
            return Mapper.Map<User, UserDto>(_uow.Repository<User>().Get(i => i.Id == id));
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
