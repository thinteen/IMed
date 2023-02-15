using DrugStore.Domain;

namespace DrugStore.Repositories.AdminAccountRepository
{
    public interface IAdminAccountRepository
    {
        public AdminAccount GetAdminAccountPasswordByLogin(string login);
        public int Add(AdminAccount adminAccount);
    }
}