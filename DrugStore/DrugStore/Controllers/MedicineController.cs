using DrugStore.Domain;
using DrugStore.Dto;
using DrugStore.Repositories.MedicineRepository;
using DrugStore.Services.MedicineService;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody] MedicineDto medicineDto)
        {
            try
            {
                return Ok(_medicineService.Add(medicineDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("add-medicine-price-for-brand")]
        public IActionResult AddMedicinePriceForBrand([FromBody] BrandMedicinePriceDto brandMedicinePriceDto)
        {
            try
            {
                return Ok(_medicineService.AddMedicinePriceForBrand(brandMedicinePriceDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get-all-medicine-price-for-brand")]
        public IActionResult GetAllBrandMedicinePrice()
        {
            try
            {
                return Ok(_medicineService.GetAllBrandMedicinePrice()
                    .ConvertAll(t => t.ConvertToBrandMedicinePriceDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("add-residual-medicine-in-pharmacy")]
        public IActionResult AddResidualMedicineInPharmacy([FromBody] PharmacyMedicineDto pharmacyMedicineDto)
        {
            try
            {
                return Ok(_medicineService.AddResidualMedicineInPharmacy(pharmacyMedicineDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get-all-residual-medicine-in-pharmacy")]
        public IActionResult GetAllPharmacyMedicine()
        {
            try
            {
                return Ok(_medicineService.GetAllPharmacyMedicine()
                    .ConvertAll(t => t.ConvertToPharmacyMedicineDto()));
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
                return Ok(_medicineService.GetAll()
                    .ConvertAll(t => t.ConvertToMedicineDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] MedicineDto medicineDto)
        {
            try
            {
                return Ok(_medicineService.Update(medicineDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update-brand-medicine-price")]
        public IActionResult UpdateBrandMedicinePrice([FromBody] BrandMedicinePriceDto brandMedicinePriceDto)
        {
            try
            {
                return Ok(_medicineService.UpdateBrandMedicinePrice(brandMedicinePriceDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update-count-of-medicine-in-pharmacy")]
        public IActionResult UpdateCountOfMedicineInPharmacy([FromBody] PharmacyMedicineDto pharmacyMedicineDto)
        {
            try
            {
                return Ok(_medicineService.UpdateCountOfMedicineInPharmacy(pharmacyMedicineDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{medicineId}/delete")]
        public IActionResult Delete(int medicineId)
        {
            try
            {
                _medicineService.Delete(medicineId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete-brand-medicine-price")]
        public IActionResult DeleteBrandMedicinePrice([FromQuery] int medicineId, [FromQuery] int brandId)
        {
            try
            {
                _medicineService.DeleteBrandMedicinePrice(medicineId, brandId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete-medicine-from-pharmacy")]
        public IActionResult DeleteMedicineFromPharmacy([FromQuery] int medicineId, [FromQuery] int pharmacyId)
        {
            try
            {
                _medicineService.DeleteMedicineFromPharmacy(medicineId, pharmacyId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get-medicine-with-price-and-place-of-purchase-by-id")]
        public IActionResult GetQuantityMedicineInPharmacyById([FromQuery] int medicineId)
        {
            try
            {
                var result = _medicineService.GetMedicineWithPriceAndPlaceOfPurchaseById(medicineId)
                    .ConvertAll(t => t.ConvertToMedicinesWithPriceAndPlaceOfPurchaseDto());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get-pharmacy-medicines-by-id")]
        public IActionResult GetPharmacyMedicinesById([FromQuery] int pharmacyId)
        {
            try
            {
                var result = _medicineService.GetPharmacyMedicinesById(pharmacyId)
                    .ConvertAll(t => t.ConvertToMedicineCountDto());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get-medicine-by-name")]
        public IActionResult GetMedicineByName([FromQuery] string medicineName)
        {
            try
            {
                var result = _medicineService.GetMedicineByName(medicineName)
                    .ConvertAll(t => t.ConvertToMedicineDto());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get-medicine-by-category")]
        public IActionResult GetMedicineByCategory([FromQuery] string medicineCategory)
        {
            try
            {
                var result = _medicineService.GetMedicineByCategory(medicineCategory)
                    .ConvertAll(t => t.ConvertToMedicineDto());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get-medicine-by-name-with-category")]
        public IActionResult GetMedicineByNameWithCategory([FromQuery] string medicineCategory,[FromQuery] string medicineName)
        {
            try
            {
                var result = _medicineService.GetMedicineByNameWithCategory(medicineCategory, medicineName)
                    .ConvertAll(t => t.ConvertToMedicineDto());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get-medicine-by-id")]
        public IActionResult GetMedicineById([FromQuery] int medicineId)
        {
            try
            {
                var result = _medicineService.GetMedicineById(medicineId).ConvertToMedicineDto();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get-medicine-with-price-by-brandId")]
        public IActionResult GetMedicineWithPriceByBrandId([FromQuery] int brandId)
        {
            try
            {
                var result = _medicineService.GetMedicineWithPriceByBrandId(brandId)
                    .ConvertAll(t => t.ConvertToMedicinePriceDto());

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get-popular-medicine")]
        public IActionResult GetPopularMedicine()
        {
            try
            {
                var result = _medicineService.GetPopularMedicine()
                    .ConvertAll(t => t.ConvertToMedicineDto());

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
