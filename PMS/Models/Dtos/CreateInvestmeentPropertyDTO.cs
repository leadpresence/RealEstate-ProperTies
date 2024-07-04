using System;
namespace PMS.Dtos
{
	public class CreateInvestmeentPropertyDTO
	{
	 
		
        public string Type { get; set; }
        public double Size { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal OfferingPrice { get; set; }
        public bool AllowInstallments { get; set; }
    }
}

