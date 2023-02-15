using System.ComponentModel.DataAnnotations;

namespace DrugStore.Domain
{
    public class MedicinesWithPriceAndPlaceOfPurchase
    {
        public string MedicineName { get; set; }
        public decimal MedicinePrice { get; set; }
        public string MedicineCategory { get; set; }
        public string MedicineImage { get; set; }
        public string MedicineInstruction { get; set; }
        public int MedicineResidual { get; set; }
        public string PharmacyName { get; set; }
        public string PharmacyAddress { get; set; }
        public string PharmacyPhoneNumber { get; set; }
    }
}