using AutoMapper;
using TRAQ_Assessment_DLL.DTOs;
using TRAQ_Assessment_MVC.Models.Account;
using TRAQ_Assessment_MVC.Models.Person;
using TRAQ_Assessment_MVC.Models.Transaction;
using TRAQ_Assessment_MVC.Models.User;

namespace TRAQ_Assessment_MVC.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PersonDto, ViewPersonViewModel>()
            .ReverseMap();

        CreateMap<AccountDto, ViewAccountViewModel>()
            .ReverseMap();

        CreateMap<TransactionDto, ViewTransactionViewModel>()
            .ReverseMap();

        CreateMap<CreateUserViewModel, TraqUserDto>()
            .ReverseMap();
    }
}
