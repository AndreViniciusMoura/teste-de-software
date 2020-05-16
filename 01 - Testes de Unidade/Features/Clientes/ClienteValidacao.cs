using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Features.Clientes
{
    public class ClienteValidacao : AbstractValidator<Cliente>
    {
        #region Propriedades

        #endregion

        #region Construtor

        public ClienteValidacao()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o nome")
                .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres");

            RuleFor(c => c.Sobrenome)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o sobrenome")
                .Length(2, 150).WithMessage("O Sobrenome deve ter entre 2 e 150 caracteres");

            RuleFor(c => c.DataNascimento)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("O cliente deve ter 18 anos ou mais");

            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        #endregion

        #region Metodos

        public static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }

        #endregion
    }
}
