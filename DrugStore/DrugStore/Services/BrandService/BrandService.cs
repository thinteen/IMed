using DrugStore.Domain;
using DrugStore.Dto;
using DrugStore.Repositories.BrandRepository;

namespace DrugStore.Services.BrandService
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public int Add(BrandDto brandDto)
        {
            if (brandDto == null)
            {
                throw new Exception($"{nameof(Brand)} not found");
            }
        
            Brand pharmacyEntity = brandDto.ConvertToBrand();
        
            return _brandRepository.Add(pharmacyEntity);
        }
        public List<Brand> GetAll()
        {
            return _brandRepository.GetAll();
        }

        public List<Brand> GetBrandByName(string brandName)
        {
            if (brandName == null)
            {
                throw new Exception("Brand name not writen");
            }

            return _brandRepository.GetBrandByName(brandName);
        }

        public Brand GetBrandById(int brandId)
        {
            if (brandId == null)
            {
                throw new Exception("Brand id not writen");
            }

            return _brandRepository.GetById(brandId);
        }

        public int Update(BrandDto brandDto)
        {
            if (brandDto == null)
            {
                throw new Exception($"{nameof(brandDto)} not found");
            }
        
            if (_brandRepository.GetById(brandDto.BrandId) != null)
            {
                return _brandRepository.Update(brandDto.ConvertToBrand());
            }
            else
            {
                throw new Exception($"{nameof(brandDto)} not found with id {brandDto.BrandId}");
            }
        }
        public void Delete(int brandId)
        {
            Brand brand = _brandRepository.GetById(brandId);
        
            if (brand == null)
            {
                throw new Exception($"{nameof(Brand)} not found, Id - {brandId}");
            }
        
            _brandRepository.Delete(brand);
        }
    }
}
