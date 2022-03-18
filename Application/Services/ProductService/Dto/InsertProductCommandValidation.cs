using FluentValidation;

namespace Application.Services.ProductService.Dto
{
    public class InsertProductCommandValidation : AbstractValidator<InsertProductCommand>
    {
        public InsertProductCommandValidation()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("El nombre del producto es requerido")
                .MaximumLength(100).WithMessage("El nombre no puede tener mas de 100 caracteres");
            RuleFor(r => r.UnitId)
                .NotEmpty().WithMessage("La unidad es requerida");
        }
    }
}
