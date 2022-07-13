﻿using AutoMapper;
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
            //CreateMap<BookDTO, Book>()
            //    .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
            //    .ForMember(x => x.Autor, opt => opt.MapFrom(src => src.Autor))
            //    .ForMember(x => x.Publisher, opt => opt.MapFrom(src => src.Publisher))
            //    .ForMember(x => x.Age, opt => opt.MapFrom(src => src.Age))
            //    .ForMember(x => x.Pages, opt => opt.MapFrom(src => src.Pages))
            //    .ForMember(x => x.Genre, opt => opt.MapFrom(src => ToGenre(src.Genre)))
            //    .ForMember(x => x.Id, opt => opt.Ignore());
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
