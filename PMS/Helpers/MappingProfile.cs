using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PMS.Dtos;
using PMS.Models.Dtos;
using PMS.Models.PropertyData;
using PMS.Models.User;

namespace PMS.Helpers
{
	public class MappingProfile: Profile
    {
		public MappingProfile()
        {
            CreateMap<InvestmentProperty, InvestmentPropertyDTO>().ReverseMap();
            CreateMap<CreateInvestmeentPropertyDTO, InvestmentProperty>();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<CreateUserDTO, User>();
        }

   
	}
}

