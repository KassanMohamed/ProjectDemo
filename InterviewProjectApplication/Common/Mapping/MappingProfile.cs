using AutoMapper;
using InterviewProjectApplication.Request;
using InterviewProjectApplication.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProjectApplication.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookRequestModel, InterviewProjectDomain.Model.Book>().
            ForMember(x => x.Price, a => a.MapFrom(s => s.Price))
           .ForMember(x => x.Publisher, a => a.MapFrom(s => s.Publisher))
           .ForMember(x => x.AuthorFirstName, a => a.MapFrom(s => s.AuthorFirstName))
           .ForMember(x => x.AuthorLastName, a => a.MapFrom(s => s.AuthorLastName))
           .ForMember(x => x.Title, a => a.MapFrom(s => s.Title))
           .ForMember(x => x.Year, a => a.MapFrom(s => s.Year))
           .ForMember(x => x.PlaceOfPublication, a => a.MapFrom(s => s.PlaceOfPublication))
           .ReverseMap();


            CreateMap<InterviewProjectDomain.Model.Book, BookDto>().
            ForMember(x => x.Price, a => a.MapFrom(s => s.Price)).
            ForMember(x => x.Id, a => a.MapFrom(s => s.Id))
           .ForMember(x => x.Publisher, a => a.MapFrom(s => s.Publisher))
           .ForMember(x => x.AuthorFirstName, a => a.MapFrom(s => s.AuthorFirstName))
           .ForMember(x => x.AuthorLastName, a => a.MapFrom(s => s.AuthorLastName))
           .ForMember(x => x.Title, a => a.MapFrom(s => s.Title))
           .ForMember(x => x.Year, a => a.MapFrom(s => s.Year))
           .ForMember(x => x.MlaCitation, a => a.MapFrom(s => s.MlaCitation))
           .ForMember(x => x.ChicagoCitation, a => a.MapFrom(s => s.ChicagoCitation))
           .ReverseMap();



        }
    }
}
