using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PMS.Data;
using PMS.Models.Dtos;
using PMS.Models.User;

namespace PMS.Services
{
	public class UserService:IUserService
    {
		  

        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;



        public UserService(IMapper mapper, ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<ResponseModel<IEnumerable<UserDTO>>> GetAllUsers()
        {

            try
            {
                var users = await _dbContext.Users.ToListAsync();
                //return ;

                return new ResponseModel<IEnumerable<UserDTO>> { Message = "Fetch successful",
                    Data = _mapper.Map<IEnumerable<UserDTO>>(users), Success = true };


            }
            catch (Exception ex)
            {

                return new ResponseModel<IEnumerable<UserDTO>> { Data = new List<UserDTO>(), Message = "Error occured ${ex.Message}", Success = false, Ex = ex };

            }
           
        }

        public async Task<ResponseModel<UserDTO>> GetUserById(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return new ResponseModel<UserDTO> { Data = new UserDTO {
                    Title="",FirstName="",LastName="",PasswordHash="",Email=""
                }, Message = "User not found", Success = false, };

            }
            return new ResponseModel<UserDTO> { Data = _mapper.Map<UserDTO>(user), Message = "", Success = true };

        }

        public async Task<ResponseModel<long>> AddUser(CreateUserDTO userDto)
        {

            try
            {
                var user = _mapper.Map<User>(userDto);
                await _dbContext.AddAsync(user);
                _dbContext.SaveChanges();
                return new ResponseModel<long> { Data = user.Id, Message = "Property added", Success = true };

            }
            catch (Exception ex)
            {

                return new ResponseModel<long> { Data = -1, Message = "Error occured", Success = false };
            }
         
     
        }

        public async Task <ResponseModel<object>> UpdateUser(int id, CreateUserDTO userDto)
        {
           

            try
            {

                 var user = await _dbContext.Users.FindAsync(id);
                if (user == null) throw new ArgumentException("User not found");
                _mapper.Map(userDto, user);
                  _dbContext.Update(user);
                _dbContext.SaveChanges();

                return new ResponseModel<object> { Data = new string("User updated successsfully"), Message = "", Success = true };

            }
            catch (Exception ex)
            {

                return new ResponseModel<object> { Data = new string("Error occured updating user"), Message = "Error occured ${ex.Message}", Success = false, Ex = ex };
            }



        }




        public async Task<ResponseModel<object>> DeleteUser(int id)
        {
            //_dbContext.Users.Delete(id);


            try
            {

                var user = await _dbContext.Users.FindAsync(id);
                if (user == null) throw new ArgumentException("User not found");

                 _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();


                return new ResponseModel<object> { Data = new string("User updated successsfully"), Message = "", Success = true };

            }
            catch (Exception ex)
            {

                return new ResponseModel<object> { Data = new string("Error occured deeleting user"), Message = "Error occured ${ex.Message}", Success = false, Ex = ex };
            }
        }
    }
}

