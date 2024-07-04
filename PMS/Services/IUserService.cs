using System;
using PMS.Models.Dtos;

namespace PMS.Services
{
	public interface IUserService
	{

        Task<ResponseModel<IEnumerable<UserDTO>>> GetAllUsers();
        Task<ResponseModel<UserDTO>> GetUserById(int id);
        Task<ResponseModel<long>> AddUser(CreateUserDTO userDto);
        Task<ResponseModel<object>> UpdateUser(int id, CreateUserDTO userDto);
        Task<ResponseModel<object>> DeleteUser(int id);

    }
}

