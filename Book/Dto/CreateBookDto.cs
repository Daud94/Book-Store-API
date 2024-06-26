﻿using System.ComponentModel.DataAnnotations;
using BookStore.Book.Enums;

namespace BookStore.Book.Dto;

public class CreateBookDto
{
    [Required] public string Title { get; set; }
    [Required] public string Isbn { get; set; }

    [Required] public string Description { get; set; }

    [Required] public Genre Genre { get; set; }

    [Required] public int AuthorId { get; set; }
}