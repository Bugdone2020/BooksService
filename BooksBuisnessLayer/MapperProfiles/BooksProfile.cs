using AutoMapper;
using BooksBuisnessLayer.DTOs;
using BooksDataAccesLayer.Models;
using System;
namespace BooksBuisnessLayer.MapperProfiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<BookDTO, Book>()
                .ForMember(x => x.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(x => x.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
        private Genre ToGenre(string genre)
        {
            if (Enum.TryParse(typeof(Genre), genre, out var result))
            {
                return (Genre)result;
            }
            return Genre.Other;
        }
    }
}
