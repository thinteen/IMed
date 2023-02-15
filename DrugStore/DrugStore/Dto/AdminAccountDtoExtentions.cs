using DrugStore.Domain;
using DrugStore.Dto;

public static class AdminAccountDtoExtentions
{
    public static AdminAccount ConvertToAdminAccount(this AdminAccountDto adminAccountDto)
    {
        return new AdminAccount
        {
            AdminAccountId = adminAccountDto.AdminAccountId,
            Login = adminAccountDto.Login,
            Password = adminAccountDto.Password,
        };
    }

    public static AdminAccountDto ConvertToAdminAccountDto(this AdminAccount adminAccount)
    {
        return new AdminAccountDto
        {
            AdminAccountId = adminAccount.AdminAccountId,
            Login = adminAccount.Login,
            Password = adminAccount.Password,
        };
    }
}
