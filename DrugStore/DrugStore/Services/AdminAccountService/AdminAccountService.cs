using DrugStore.Domain;
using DrugStore.Dto;
using DrugStore.Repositories.AdminAccountRepository;
using DrugStore.Repositories.BrandRepository;
using DrugStore.Services.AdminAccountService;

namespace DrugStore.Services.BrandService
{
    public class AdminAccountService : IAdminAccountService
    {
        private readonly IAdminAccountRepository _adminAccountRepository;

        public AdminAccountService(IAdminAccountRepository adminAccountRepository)
        {
            _adminAccountRepository = adminAccountRepository;
        }

        public AdminAccount GetAdminAccountPasswordByLogin(string login)
        {
            return _adminAccountRepository.GetAdminAccountPasswordByLogin(login);
        }

        public int Add(AdminAccountDto adminAccountDto)
        {
            if (adminAccountDto == null)
            {
                throw new Exception($"{nameof(AdminAccount)} not found");
            }

            AdminAccount adminAccount = adminAccountDto.ConvertToAdminAccount();

            return _adminAccountRepository.Add(adminAccount);
        }
    }
}
