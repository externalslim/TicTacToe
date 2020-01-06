using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Data.Models;
using TicTacToe.Repository.UserRepository;

namespace TicTacToe.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
        }

        public List<Users> GetUserList()
        {
            return _userRepository.GetUserList();
        }

        public Users GetUserById(Users input)
        {
            return _userRepository.GetUserById(input);
        }

        public Users GetUserByNicknameAndPassword(Users input)
        {
            return _userRepository.GetUserByNicknameAndPassword(input);
        }

        public Users Insert(Users input)
        {
            var scopeId = _userRepository.Insert(input);
            if (scopeId > 0)
            {
                input.Id = scopeId;
            }
            else
            {
                input = new Users();
            }
            return input;
        }

        public Users Update(Users input)
        {
            var Users = _userRepository.Update(input);
            return Users;
        }

        public bool Delete(int id)
        {
            return _userRepository.Delete(id);
        }
    }
}
