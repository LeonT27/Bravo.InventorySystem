using FluentValidation;

namespace Application.Services.ProductService.Dto
{
    public class InsertProductTransactionCommandValidation : AbstractValidator<InsertProductTransactionCommand>
    {
        public InsertProductTransactionCommandValidation()
        {
            RuleFor(r => r.ProductId)
                .NotEmpty().WithMessage("El producto es requerido");
            RuleFor(r => r.Purpose)
                .NotEmpty().WithMessage("La razon es requerida")
                .MaximumLength(100).WithMessage("La razon no puede tener mas de 100 caracteres");
            RuleFor(r => r.Quantity)
                .NotEmpty().WithMessage("La cantidad es requerida")
                .LessThan(0).WithMessage("La cantidad no puede ser negativa");
            RuleFor(r => r.TransactionTypeId)
                .NotEmpty().WithMessage("El tipo de transaccion es requerida");
        }
    }
}
