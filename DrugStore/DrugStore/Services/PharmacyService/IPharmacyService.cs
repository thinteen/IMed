using DrugStore.Domain;
using DrugStore.Dto;

namespace DrugStore.Services.PharmacyService
{
    public interface IPharmacyService
    {
        public int Add(PharmacyDto pharmacyDto);
        public List<Pharmacy> GetAll();
        public List<BrandPharmacy> GetPharmaciesByBrandId(int brandId);
        public int Update(PharmacyDto pharmacyDto);
        public void Delete(int pharmacyId);
        public Pharmacy GetPharmacyById(int pharmacyId);
    }
}
