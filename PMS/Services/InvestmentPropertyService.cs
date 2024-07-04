using System;
//using System.Collections;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PMS.Data;
using PMS.Dtos;
using PMS.Models.Dtos;
using PMS.Models.PropertyData;
using PMS.Models.User;

namespace PMS.Services
{
    public class InvestmentPropertyService : IInvestmentPropertyService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        //private readonly UserRepository _userRepository;

        public InvestmentPropertyService(IMapper mapper,  ApplicationDbContext dbContext)
        {
            /// initialize the auto mapper, repository in  the service constructor
            _mapper = mapper;
           _dbContext = dbContext;
            //_userRepository = userRepository;
        }
        /// <summary>
        ///  implement service methods
        /// </summary>
        /// <param name="propertyDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<ResponseModel<long>> AddProperty(CreateInvestmeentPropertyDTO propertyDto)
        {
            try {
                var property = _mapper.Map<InvestmentProperty>(propertyDto);
                await _dbContext.AddAsync(property);
                _dbContext.SaveChanges();
                await _dbContext.SaveChangesAsync();
                return new ResponseModel<long> { Data = property.Id, Message = "Property added", Success = true };

            } catch (Exception ex) {

                return new ResponseModel<long> { Data = -1, Message="Error occured", Success =false};
            }
            
        }

        public async Task<ResponseModel<object>> DeleteProperty(int id)
        {

            try {

                var investmentProperty = await _dbContext.Properties.FirstOrDefaultAsync(x => x.Id == id);
                if (investmentProperty == null)
                {
                    return new ResponseModel<object> { Data = -1, Message = "Delete successful", Success = true };

                }
                else
                {
                    _dbContext.Remove(investmentProperty);
                    return new ResponseModel<object> { Data = -1, Message = "Error  occured property does not exist", Success = false };
                }
            }
            catch (Exception ex) {

                return new ResponseModel<object> { Data = -1, Message = "Error occured ${ex.Message}", Success = false , Ex=ex};
            }

             
        }


        public async Task<ResponseModel<IEnumerable<InvestmentPropertyDTO>>> FilterProperties(decimal minPrice, decimal maxPrice, string type)
        {

            try
            {
                var properties = await _dbContext.Properties.ToListAsync();
                var filteredProperties = properties.Where(p => p.Price >= minPrice && p.Price <= maxPrice && p.PropertyType == type);
                return new ResponseModel<IEnumerable<InvestmentPropertyDTO>> { Message="Fetch successful", Data= _mapper.Map<IEnumerable<InvestmentPropertyDTO>>(filteredProperties) , Success=true};

            }
            catch (Exception ex)
            {

                return new ResponseModel<IEnumerable<InvestmentPropertyDTO>> { Data = new List<InvestmentPropertyDTO>(), Message = "Error occured ${ex.Message}", Success = false, Ex = ex };
            }


            
        }

        public async Task<ResponseModel<IEnumerable<InvestmentPropertyDTO>>> GetAllProperties()
        {
            try
            {
                var properties = await _dbContext.Properties.ToListAsync();

                return new ResponseModel<IEnumerable<InvestmentPropertyDTO>> { Message = "Fetch successful", Data = _mapper.Map<IEnumerable<InvestmentPropertyDTO>>(properties), Success = true };


            }
            catch (Exception ex)
            {

                return new ResponseModel<IEnumerable<InvestmentPropertyDTO>> { Data = new List<InvestmentPropertyDTO>(), Message = "Error occured ${ex.Message}", Success = false, Ex = ex };

            }

        }

        public async Task<ResponseModel<IEnumerable<InvestmentPropertyDTO>>> GetLikedProperties(int userId)
        {
            try
            {
                var user = await _dbContext.UserProperties.FindAsync(userId);
                if (user == null) throw new ArgumentException("User not found");

                var properties = await _dbContext.UserProperties.ToListAsync();// user.LikedProperties.Select(up => up.Property);
                return new ResponseModel<IEnumerable<InvestmentPropertyDTO>> { Data= _mapper.Map<IEnumerable<InvestmentPropertyDTO>>(properties) ,Message="",Success=true};

            }
            catch (Exception ex)
            {

                return new ResponseModel<IEnumerable<InvestmentPropertyDTO>> { Data = new List<InvestmentPropertyDTO> (), Message = "Error occured ${ex.Message}", Success = false, Ex = ex };
            }
       
        }

        public async Task<ResponseModel<InvestmentPropertyDTO>> GetPropertyById(int id)
        {
            try
            {
                var property = await _dbContext.Properties.FindAsync(id);
                if (property == null) {
                  return new  ResponseModel<InvestmentPropertyDTO> { Data = new InvestmentPropertyDTO { }, Message = "Property not found", Success = false,  };

                }


                return new ResponseModel<InvestmentPropertyDTO> { Data = _mapper.Map<InvestmentPropertyDTO>(property), Message = "", Success = true };

                 
            }
            catch (Exception ex)
            {

                return new ResponseModel<InvestmentPropertyDTO> { Data =new  InvestmentPropertyDTO{ }, Message = "Error occured", Success = false, Ex=ex};
            }
           
        }

        public async Task<ResponseModel<object>> LikeProperty(int userId, int propertyId)
        {

            try
            {
                var user = await _dbContext.Users.FindAsync(userId);
                // user  is not  found
                if (user == null) {
                    return new ResponseModel<object> { Data = new string("User not found"), Message = "User not found", Success = false, };
                };

                var property = await _dbContext.Properties.FindAsync(propertyId);
                // property  is not  found
                if (property == null) {
                    return new ResponseModel<object> { Data = new string("Property not found"), Message = "Property not found", Success = false, };
                };
                if (user.LikedProperties.Any(up => up.PropertyId == propertyId)) {
                    return new ResponseModel<object> { Data = new string("User not found"), Message = "Property alredy  liked", Success = false, };
                };
                
                    user.LikedProperties.Add(new UserProperty { User = user, Property = property, UserId = userId, PropertyId = propertyId });
                  _dbContext.Users.Update(user);

                return new ResponseModel<object> { Data = new string("Liked property"), Message = "Liked property", Success = true };
 
   }
            catch (Exception ex)
            {

                return new ResponseModel<object> { Data = new string("Liked property"), Message = "Error occured", Success = false, Ex=ex };
            }
           
        }

        public async Task<ResponseModel<object>> UnlikeProperty(int userId, int propertyId)
        {

            try
            {
                var user = await _dbContext.Users.FindAsync(userId);
                if (user == null) throw new ArgumentException("User not found");

                var userProperty = user.LikedProperties.FirstOrDefault(up => up.PropertyId == propertyId);
                if (userProperty == null) { };

                user.LikedProperties.Remove(userProperty);
                  _dbContext.Users.Update(user);
                _dbContext.SaveChanges();
                return new ResponseModel<object> { Data = new string("Unliked property"), Message = "Liked property", Success = true };


            }
            catch (Exception ex)
            {

                return new ResponseModel<object> { Data = -1, Message = "Error occured ${ex.Message}", Success = false, Ex = ex };
            }
           
        }

        public async Task<ResponseModel<object>> UpdateProperty(int id, CreateInvestmeentPropertyDTO propertyDto)
        {

            try
            {
                var property = await _dbContext.Properties.FindAsync(id);
                if (property == null) throw new ArgumentException("Property not found");
                _mapper.Map(propertyDto, property);
                _dbContext.Update(property);
                _dbContext.SaveChanges();
                return new ResponseModel<object> { Data = new string("Property updated successsfully"), Message = "", Success = true };

            }
            catch (Exception ex)
            {

                return new ResponseModel<object> { Data = new string("Error occured updating property"), Message = "Error occured ", Success = false, Ex = ex };
            }

        }
    }


		
	
}

