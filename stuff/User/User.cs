using System;
using System.Linq;

namespace stuff.User
{
    public class User
    {
        public string Name { get; set; }
        public string EMailAddress { get; protected set; }
        
        private string password;
        public string Password => new string('*', password.Length);

        public User(string name, string email, string password)
        {
            Name = name;
            EMailAddress = email;
            this.password = password;
        }
        public bool ValidatePassword(string password)
        {
            return password == this.password;
        }

        public void ChangePassword(string currentPassword, string newPassword)
        {
            if (ValidatePassword(currentPassword))
            {
                Console.WriteLine("New password was set");
                password = newPassword;
            }
            else
            {
                Console.WriteLine("Incorrect password, could not change");
            }
        }
    }
}