using DrugStore.Domain;
using DrugStore.Dto;

namespace DrugStore.Services.AdminAccountService
{
    public interface IAdminAccountService
    {
        public AdminAccount GetAdminAccountPasswordByLogin(string login);
        public int Add(AdminAccountDto adminAccountDto);
    }
}
