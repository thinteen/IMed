using DrugStore.Domain;

namespace DrugStore.Repositories.PharmacyRepository
{
    public interface IPharmacyRepository
    {
        public int Add(Pharmacy pharmacy);
        public List<Pharmacy> GetAll();
        public Pharmacy GetById(int pharmacyId);
        public List<BrandPharmacy> GetPharmaciesByBrandId(int brandId);
        public int Update(Pharmacy pharmacy);
        public void Delete(Pharmacy pharmacy);
        public Pharmacy GetPharmacyById(int pharmacyId);
    }
}
