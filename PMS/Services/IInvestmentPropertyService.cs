using System;
using PMS.Dtos;
using PMS.Models.Dtos;

namespace PMS.Services

{
	public interface IInvestmentPropertyService
	{

        Task<ResponseModel<IEnumerable<InvestmentPropertyDTO>>> GetAllProperties();
        Task<ResponseModel<InvestmentPropertyDTO>> GetPropertyById(int id);
        Task<ResponseModel<long>> AddProperty(CreateInvestmeentPropertyDTO propertyDto);
        Task<ResponseModel<object>> UpdateProperty(int id, CreateInvestmeentPropertyDTO propertyDto);
        Task<ResponseModel<object>> DeleteProperty(int id);
        Task<ResponseModel<object>> LikeProperty(int userId, int propertyId);
        Task<ResponseModel<object>> UnlikeProperty(int userId, int propertyId);
        Task<ResponseModel<IEnumerable<InvestmentPropertyDTO>>> GetLikedProperties(int userId);
        Task<ResponseModel<IEnumerable<InvestmentPropertyDTO>>> FilterProperties(decimal minPrice, decimal maxPrice, string type);

    }
}

