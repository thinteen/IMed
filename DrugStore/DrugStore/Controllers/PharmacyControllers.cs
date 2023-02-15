using DrugStore.Dto;
using DrugStore.Services.PharmacyService;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyService _pharmacyService;

        public PharmacyController(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody] PharmacyDto pharmacyDto)
        {
            try
            {
                return Ok(_pharmacyService.Add(pharmacyDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_pharmacyService.GetAll()
                    .ConvertAll(t => t.ConvertToPharmacyDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("{brandId}/get-pharmacies-by-brandId")]
        public IActionResult GetPharmaciesByBrandId(int brandId)
        {
            try
            {
                return Ok(_pharmacyService.GetPharmaciesByBrandId(brandId)
                    .ConvertAll(t => t.ConvertToBrandPharmacyDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] PharmacyDto pharmacyDto)
        {
            try
            {
                return Ok(_pharmacyService.Update(pharmacyDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete]
        [Route("{pharmacyId}/delete")]
        public IActionResult Delete(int pharmacyId)
        {
            try
            {
                _pharmacyService.Delete(pharmacyId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get-pharmacy-by-id")]
        public IActionResult GetPharmacyById([FromQuery] int pharmacyId)
        {
            try
            {
                return Ok(_pharmacyService.GetPharmacyById(pharmacyId).ConvertToPharmacyDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
