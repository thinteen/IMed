using DrugStore.Domain;
using DrugStore.Dto;
using DrugStore.Repositories.PharmacyRepository;

namespace DrugStore.Services.PharmacyService
{
    public class PharmacyService : IPharmacyService
    {
        private readonly IPharmacyRepository _pharmacyRepository;

        public PharmacyService(IPharmacyRepository pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
        }
        public int Add(PharmacyDto pharmacyDto)
        {
            if (pharmacyDto == null)
            {
                throw new Exception($"{nameof(Pharmacy)} not found");
            }
        
            Pharmacy pharmacyEntity = pharmacyDto.ConvertToPharmacy();
        
            return _pharmacyRepository.Add(pharmacyEntity);
        }
        public List<Pharmacy> GetAll()
        {
            return _pharmacyRepository.GetAll();
        }
        public List<BrandPharmacy> GetPharmaciesByBrandId(int brandId)
        {
            return _pharmacyRepository.GetPharmaciesByBrandId(brandId);
        }
        public int Update(PharmacyDto pharmacyDto)
        {
            if (pharmacyDto == null)
            {
                throw new Exception($"{nameof(pharmacyDto)} not found");
            }
        
            if (_pharmacyRepository.GetById(pharmacyDto.PharmacyId) != null)
            {
                return _pharmacyRepository.Update(pharmacyDto.ConvertToPharmacy());
            }
            else
            {
                throw new Exception($"{nameof(pharmacyDto)} not found with id {pharmacyDto.PharmacyId}");
            }
        }
        public void Delete(int pharmacyId)
        {
            Pharmacy pharmacy = _pharmacyRepository.GetById(pharmacyId);
        
            if (pharmacy == null)
            {
                throw new Exception($"{nameof(Pharmacy)} not found, Id - {pharmacyId}");
            }
        
            _pharmacyRepository.Delete(pharmacy);
        }

        public Pharmacy GetPharmacyById(int pharmacyId)
        {
            if (pharmacyId == null)
            {
                throw new Exception($"{nameof(Pharmacy)} not found, Id - {pharmacyId}");
            }

            return _pharmacyRepository.GetPharmacyById(pharmacyId);
        }
    }
}
