using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia")

                .NotNull()
                .WithMessage("A entidade não pode ser nula");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O nome não pode ser nulo");


            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome não pode ser vazio");

            RuleFor(x => x.Name)
                .Length(3,80)
                .WithMessage("O nome deve ter no minimo 3 caracteres e no maximo 80 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O email não pode ser vazio");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("O email não pode ser nulo");

            RuleFor(x => x.Email)
                .Length(10, 100)
                .WithMessage("O email deve ter no minimo 10 caracteres e no maximo 100 caracteres")

            .Matches("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$")
            .WithMessage("O email informado não é valido");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("A senha não pode ser vazia");

            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("A senha não pode ser nula");

            RuleFor(x => x.Password)
                .Length(6, 30)
                .WithMessage("A senha deve ter no minimo 6 caracteres e no maximo 30 caracteres");

            RuleFor(x => x.Password)
                .NotEqual(x => x.Name)
                .WithMessage("A senha não pode ser o nome");
        }
    }
}
