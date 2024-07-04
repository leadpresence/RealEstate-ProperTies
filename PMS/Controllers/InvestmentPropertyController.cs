using System;
using Microsoft.AspNetCore.Mvc;
using PMS.Dtos;
using PMS.Services;

namespace PMS.Controllers
{
	 
      

        [ApiController]
        [Route("api/[controller]")]
        public class PropertiesController : ControllerBase
        {
            private readonly IInvestmentPropertyService _propertyService;

            public PropertiesController(IInvestmentPropertyService propertyService)
            {
                _propertyService = propertyService;
            }

            [HttpGet]
            public async Task<IActionResult> GetAllProperties()
            {
                var properties = await _propertyService.GetAllProperties();
                return Ok(properties);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetPropertyById(int id)
            {
                var property = await _propertyService.GetPropertyById(id);
                if (property == null) return NotFound();
                return Ok(property);
            }

            [HttpPost]
            public async Task<IActionResult> AddProperty([FromBody] CreateInvestmeentPropertyDTO propertyDto)
            {
                
            var createdUser = await _propertyService.AddProperty(propertyDto);
            return CreatedAtAction(nameof(GetPropertyById), new { id = createdUser }, propertyDto);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateProperty(int id, [FromBody] CreateInvestmeentPropertyDTO propertyDto)
            {
                await _propertyService.UpdateProperty(id, propertyDto);
                return NoContent();
            }

            

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id) {
            await _propertyService.DeleteProperty(id);
            return NoContent();

        }

        ///todo get  liked/ saved properties
        


    }
    }

