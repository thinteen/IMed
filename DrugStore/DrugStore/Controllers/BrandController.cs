using DrugStore.Dto;
using DrugStore.Services.BrandService;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody] BrandDto brandDto)
        {
            try
            {
                return Ok(_brandService.Add(brandDto));
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
                return Ok(_brandService.GetAll()
                    .ConvertAll(t => t.ConvertToBrandDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] BrandDto brandDto)
        {
            try
            {
                return Ok(_brandService.Update(brandDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete]
        [Route("{brandId}/delete")]
        public IActionResult Delete(int brandId)
        {
            try
            {
                _brandService.Delete(brandId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get-brand-by-name")]
        public IActionResult GetBrandByName([FromQuery] string brandName)
        {
            try
            {
                var result = _brandService.GetBrandByName(brandName)
                    .ConvertAll(t => t.ConvertToBrandDto());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get-brand-by-brandId")]
        public IActionResult GetBrandById([FromQuery] int brandId)
        {
            try
            {
                var result = _brandService.GetBrandById(brandId).ConvertToBrandDto();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
