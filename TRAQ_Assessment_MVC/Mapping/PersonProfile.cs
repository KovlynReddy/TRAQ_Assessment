using AutoMapper;
using TRAQ_Assessment_DLL.DTOs;
using TRAQ_Assessment_MVC.Models.Person;
using TRAQ_Assessment_MVC.Models.User;

namespace TRAQ_Assessment_MVC.Mapping;

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<PersonDto, ViewPersonViewModel>()
            .ReverseMap();

        CreateMap<CreateUserViewModel, TraqUserDto>()
            .ReverseMap();
    }
}
