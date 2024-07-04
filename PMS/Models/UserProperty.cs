using System;
using PMS.Models.PropertyData;
namespace PMS.Models.User


{
	public class UserProperty
	{
        public int ID { get; set; }
        public int UserId { get; set; }
        public int PropertyId { get; set; }
        public required User User { get; set; }
        public required InvestmentProperty Property { get; set; }
    }
}

