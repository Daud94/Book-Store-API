using AutoMapper;
using BookStore.Book.Dto;

namespace BookStore.Mappings;

public class AutoMapperProfiles: Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Book.Book, CreateBookDto>()
            .ReverseMap();
    }
}