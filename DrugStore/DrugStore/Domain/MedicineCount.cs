namespace DrugStore.Domain;

public class MedicineCount
{
    public int PharmacyId { get; set; }
    public int MedicineId { get; set; }
    public int Residual { get; set; }
    public string Name { get; set; }
}
