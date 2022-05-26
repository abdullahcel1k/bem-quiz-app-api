using AutoMapper;
using QuizApp.Api.Resources;
using QuizApp.Core.Models;

namespace QuizApp.Api.Mapping
{
	public class MappingProfile : Profile
	{
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<User, UserResource>();
            CreateMap<User, SaveUserResource>();


            // Resource to Domain
            CreateMap<UserResource, User>();
            CreateMap<SaveUserResource, User>();

        }
    }
}

