﻿using System.ComponentModel.DataAnnotations;

namespace CZTrails.Models.DTO
{
    public class RegisterRequestDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        [DataType (DataType.Password)]
        public string Password { get; set; }
        public string[] Roles { get; set; }
    }
}
