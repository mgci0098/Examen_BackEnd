﻿using Lab3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.ViewModels
{
    public class RegisterPostModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        //[EmailAddress]    //am facut clasa de validari
        public string Email { get; set; }
        //[StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }

        public DateTime DataRegistered { get; set; }




        private static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            //TODO: Also use salt

            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }


        public static User ToUser(RegisterPostModel userModel)
        {
            return new User
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Username = userModel.UserName,
                Email = userModel.Email,
                Password = ComputeSha256Hash(userModel.Password),
                DataRegistered = DateTime.Now
            };
        }

    }
}
