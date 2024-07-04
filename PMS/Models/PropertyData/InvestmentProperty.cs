using System;
using PMS.Entities;
using System.ComponentModel.DataAnnotations;
using PMS.Models.User;

namespace PMS.Models.PropertyData
{
	public class InvestmentProperty
	{

        public int Id { get; set; }
        public required string PropertyType { get; set; } // Land, House, Flat, Duplex
        public double Size { get; set; }
        public decimal Price { get; set; }
        public required string Location { get; set; }
        public  required string Description { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal OfferingPrice { get; set; }
        public bool AllowInstallments { get; set; }
        public List<UserProperty>? LikedByUsers { get; set; }


        //public int? Id { get; set; }
        //[Required]
        //[MaxLength(1)]
        //public int? Instock { get; set; }
        //[Required]
        //[MaxLength(200)]
        //public string? Address { get; set; }
        //[Required]
        //[MaxLength(1000)]
        //public string? Description { get; set; }
        //[Required]
        //public int? SqaureFeet { get; set; }
        //public string? Lga { get; set; }
        //[Required]
        //public string? LandMark { get; set; }
        //public double? Longitude { get; set; }
        //public double? Latitude { get; set; }
        //[Required]
        //public double? Price { get; set; }
        //[Required]
        //[EnumDataType(typeof(PropertyType))]
        //public string? PropertyType { get; set; }
    }
}

