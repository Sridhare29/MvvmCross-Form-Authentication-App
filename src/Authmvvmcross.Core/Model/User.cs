using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace AuthenticationApp.Model
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public byte[] ImageData { get; set; }

        public User user { get; set; }
    }
}
