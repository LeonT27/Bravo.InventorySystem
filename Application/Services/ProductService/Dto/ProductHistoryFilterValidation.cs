using FluentValidation;

namespace Application.Services.ProductService.Dto
{
    public class ProductHistoryFilterValidation : AbstractValidator<ProductHistoryFilter>
    {
        public ProductHistoryFilterValidation()
        {
            RuleFor(r=>r.ProductName)
                .MaximumLength(100).WithMessage("El nombre no puede tener mas de 100 caracteres");
            RuleFor(r=>r.Purpose)
                .MaximumLength(100).WithMessage("La razon no puede tener mas de 100 caracteres");
            RuleFor(r => r.TransactionType)
                .MaximumLength(50).WithMessage("El tipo de transaccion no puede tener mas de 50 caracteres");
            RuleFor(r=>r.Unit)
                .MaximumLength(50).WithMessage("La unidad no puede tener mas de 50 caracteres");
        }
    }
}
