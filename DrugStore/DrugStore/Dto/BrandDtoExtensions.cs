using DrugStore.Domain;

namespace DrugStore.Dto;

public static class BrandDtoExtensions
{
    public static Brand ConvertToBrand(this BrandDto brandDto)
    {
        return new Brand
        {
            BrandId = brandDto.BrandId,
            Name = brandDto.Name,
            Logo = brandDto.Logo,
        };
    }
    
    public static BrandDto ConvertToBrandDto(this Brand brand)
    {
        return new BrandDto
        {
            BrandId = brand.BrandId,
            Name = brand.Name,
            Logo = brand.Logo,
        };
    }
}
