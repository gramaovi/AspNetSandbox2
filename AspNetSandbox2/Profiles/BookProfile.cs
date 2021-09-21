﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox2.DTOs;
using AspNetSandbox2.Models;
using AutoMapper;

namespace AspNetSandbox2.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, ReadBookDto>();

            CreateMap<CreateBookDto, Book>();
        }
    }
}
