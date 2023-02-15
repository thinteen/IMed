using DrugStore.Domain;
using DrugStore.Dto;

namespace DrugStore.Services.BrandService
{
    public interface IBrandService
    {
        public int Add(BrandDto brandDto);
        public List<Brand> GetAll();
        public int Update(BrandDto brandDto);
        public void Delete(int brandId);
        public List<Brand> GetBrandByName(string brandName);
        public Brand GetBrandById(int brandId);
    }
}
