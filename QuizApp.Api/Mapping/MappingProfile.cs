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
            CreateMap<Exam, SaveExamResource>();
            CreateMap<Question, SaveQuestionResource>();
            CreateMap<Answer, AnswerResource>();


            // Resource to Domain
            CreateMap<UserResource, User>();
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveExamResource, Exam>();
            CreateMap<SaveQuestionResource, Question>();
            CreateMap<AnswerResource, Answer>();

        }
    }
}

