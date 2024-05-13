using FluentValidation;
using RestaurantDB.Entities;

namespace Restaurant_Project.Validators
{
    public class MenuValidator:AbstractValidator<Menu>
    {
        public MenuValidator()
        {
            RuleFor(x=>x.Title)
                .NotEmpty()
                .MaximumLength(15);

            RuleFor(x => x.Price)
                .NotEmpty().
                WithMessage("Price can't be emtpy!");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Can't be empty!");
        }
    }
}
