using DrugStore.Domain;
using DrugStore.Inftrastructure;
using Microsoft.EntityFrameworkCore;

namespace DrugStore.Repositories.AdminAccountRepository
{
    public class AdminAccountRepository : IAdminAccountRepository
    {
        private DrugStoreDbContext _context;
        public AdminAccountRepository(DrugStoreDbContext context)
        {
            _context = context;
        }

        public AdminAccount GetAdminAccountPasswordByLogin(string login)
        {
            return _context.AdminAccount.FirstOrDefault(item => item.Login == login);
        }

        public int Add(AdminAccount adminAccount)
        {
            _context.AdminAccount.Add(adminAccount);
            _context.SaveChanges();

            return adminAccount.AdminAccountId;
        }
    }
}
