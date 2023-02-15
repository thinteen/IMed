using DrugStore.Domain;
using DrugStore.Inftrastructure;
using Microsoft.EntityFrameworkCore;

namespace DrugStore.Repositories.BrandRepository
{
    public class BrandRepository : IBrandRepository
    {
        private DrugStoreDbContext _context;
        public BrandRepository(DrugStoreDbContext context)
        {
            _context = context;
        }

        public int Add(Brand brand) 
        {
            _context.Brand.Add(brand);
            _context.SaveChanges();

            return brand.BrandId;
        }
        public List<Brand> GetAll() 
        {
            return _context.Brand.ToList();
        }
        public Brand GetById(int brandId)
        {
            return _context.Brand.Find(brandId);
        }

        public List<Brand> GetBrandByName(string brandName)
        {
            return _context.Brand
                .Where(m => EF.Functions.Like(m.Name, $"%{brandName}%")).ToList();
        }

        public int Update(Brand brand) 
        {
            Brand brandEntity = GetById(brand.BrandId);

            brandEntity.Name = brand.Name;
            brandEntity.Logo = brand.Logo;

            _context.SaveChanges();

            return brand.BrandId;
        }
        public void Delete(Brand brand) 
        {
            _context.Brand.Remove(brand);
            _context.SaveChanges();
        }
    }
}
