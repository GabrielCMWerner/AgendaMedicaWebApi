using FluentValidation;

namespace AgendaMedica.Dominio.ModuloMedico
{
    public class ValidadorMedico : AbstractValidator<Medico>
    {
        public ValidadorMedico()
        {
            RuleFor(x => x.Nome)
                    .NotNull().NotEmpty();

            RuleFor(x => x.Telefone)
                .NotEmpty();

            RuleFor(x => x.Crm)
                    .NotNull().NotEmpty();

        }
    }
}