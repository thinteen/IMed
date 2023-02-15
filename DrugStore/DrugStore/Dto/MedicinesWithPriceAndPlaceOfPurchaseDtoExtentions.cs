using DrugStore.Domain;

namespace DrugStore.Dto;

public static class MedicinesWithPriceAndPlaceOfPurchaseDtoExtentions
{
    public static MedicinesWithPriceAndPlaceOfPurchase ConvertToMedicinesWithPriceAndPlaceOfPurchase(this MedicinesWithPriceAndPlaceOfPurchaseDto medicinesWithPriceAndPlaceOfPurchaseDto)
    {
        return new MedicinesWithPriceAndPlaceOfPurchase
        {
            MedicineName = medicinesWithPriceAndPlaceOfPurchaseDto.MedicineName,
            MedicinePrice = medicinesWithPriceAndPlaceOfPurchaseDto.MedicinePrice,
        };
    }

    public static MedicinesWithPriceAndPlaceOfPurchaseDto ConvertToMedicinesWithPriceAndPlaceOfPurchaseDto(this MedicinesWithPriceAndPlaceOfPurchase medicinesWithPriceAndPlaceOfPurchase)
    {
        return new MedicinesWithPriceAndPlaceOfPurchaseDto
        {
            MedicineName = medicinesWithPriceAndPlaceOfPurchase.MedicineName,
            MedicinePrice = medicinesWithPriceAndPlaceOfPurchase.MedicinePrice,
            MedicineCategory = medicinesWithPriceAndPlaceOfPurchase.MedicineCategory,
            MedicineImage = medicinesWithPriceAndPlaceOfPurchase.MedicineImage,
            MedicineInstruction = medicinesWithPriceAndPlaceOfPurchase.MedicineInstruction,
            PharmacyAddress = medicinesWithPriceAndPlaceOfPurchase.PharmacyAddress,
            PharmacyName = medicinesWithPriceAndPlaceOfPurchase.PharmacyName,
            MedicineResidual = medicinesWithPriceAndPlaceOfPurchase.MedicineResidual,
            PharmacyPhoneNumber = medicinesWithPriceAndPlaceOfPurchase.PharmacyPhoneNumber
        };
    }
}
