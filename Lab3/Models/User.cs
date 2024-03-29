﻿using CentruMultimedia.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.Models
{

    //public enum UserRole
    //{
    //    Regular,
    //    UserManager,
    //    Admin
    //}
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public DateTime DataRegistered { get; set; }

        public List<Comentariu> Comentarii { get; set; }

        public List<Film> Filme { get; set; }

        //pentru clasa de legatura
        public IEnumerable<UserUserRole> UserUserRoles { get; set; }

    }
}
