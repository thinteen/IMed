using DrugStore.Domain;

namespace DrugStore.Repositories.BrandRepository
{
    public interface IBrandRepository
    {
        public int Add(Brand brand);
        public List<Brand> GetAll();
        public Brand GetById(int brandId);
        public int Update(Brand brand);
        public void Delete(Brand brand);
        public List<Brand> GetBrandByName(string brandName);
    }
}
