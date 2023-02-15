using DrugStore.Dto;
using DrugStore.Services.AdminAccountService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAccountController : ControllerBase
    {
        private readonly IAdminAccountService _adminAccountService;

        public AdminAccountController(IAdminAccountService adminAccountService)
        {
            _adminAccountService = adminAccountService;
        }

        [HttpGet]
        [Route("get-admin-account-password-by-login")]
        public IActionResult GetAdminAccountPasswordByLogin([FromQuery] string login)
        {
            try
            {
                var result = _adminAccountService.GetAdminAccountPasswordByLogin(login)
                    .ConvertToAdminAccountDto();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody] AdminAccountDto adminAccountDto)
        {
            try
            {
                return Ok(_adminAccountService.Add(adminAccountDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
