using Manager.Core.Exceptions;
using Manager.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Domain.Entities
{
    public class User : Base
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            _errors = new List<string>();

            Validate();
        }

        public User() { }

        public void ChangeName(string name)
        {
            this.Name = name;
            Validate();
        }

        public void ChangeEmail(string email)
        {
            this.Email = email;
            Validate();
        }

        public void ChangePassword(string password)
        {
            this.Password = password;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    _errors.Add(error.ErrorMessage);
                }
                throw new DomainException($"Alguns campos estão invalidos, por favor corrija-os", _errors);
            }
            return true;
        }
    }
}
