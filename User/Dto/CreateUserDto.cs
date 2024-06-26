﻿using System.ComponentModel.DataAnnotations;

namespace BookStore.User.Dto;

public class CreateUserDto
{
    [Required] public string FirstName { get; set; }

    [Required] public string LastName { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required] public string Password { get; set; }
}