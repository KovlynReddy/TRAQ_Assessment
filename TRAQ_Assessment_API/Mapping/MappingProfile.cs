using static System.Runtime.InteropServices.JavaScript.JSType;
using TRAQ_Assessment_DLL.DTOs;
using AutoMapper;
using TRAQ_Assessment_DLL.Entities;

namespace TRAQ_Assessment_API.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PersonDto, Person>()
            .ReverseMap();

        CreateMap<AccountDto, Account>()
            .ReverseMap();

        CreateMap<TransactionDto, Transaction>()
            .ReverseMap();

        CreateMap<TraqUserDto, TraqUser>()
            .ReverseMap();
    }
}