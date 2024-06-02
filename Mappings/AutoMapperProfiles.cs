﻿using AutoMapper;
using BookStore.Book.Dto;
using BookStore.User.Dto;

namespace BookStore.Mappings;

public class AutoMapperProfiles: Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Book.Book, CreateBookDto>()
            .ReverseMap();

        CreateMap<User.User, CreateUserDto>()
            .ReverseMap();
    }
}