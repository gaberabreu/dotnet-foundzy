using FluentValidation;

namespace Foundzy.Sample.Layers.UseCases.Skus.Create;

public class CreateSkuCommandValidator : AbstractValidator<CreateSkuCommand>
{
    public CreateSkuCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty();
    }
}
