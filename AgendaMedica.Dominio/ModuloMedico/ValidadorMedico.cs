using AgendaMedica.Dominio.Compartilhado;
using FluentValidation;

namespace AgendaMedica.Dominio.ModuloMedico
{
    public class ValidadorMedico : AbstractValidator<Medico>
    {
        public ValidadorMedico()
        {
            RuleFor(x => x.Nome)
               .NotNull().NotEmpty().MinimumLength(3).Matches("^[A-Za-zÀ-ÿ ]+$");

            RuleFor(x => x.Crm)
               .CrmMedico()
               .NotNull().NotEmpty();

            RuleFor(x => x.Telefone)
               .Telefone()
               .NotNull().NotEmpty();

        }
    }
}