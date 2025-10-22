using DevQuestions.Contracts.Questions;
using FluentValidation;

namespace DevQuestions.Application.Questions;

public class CreateQuestionValidator : AbstractValidator<CreateQuestionDto>
{
    public CreateQuestionValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(500)
            .WithMessage("Title is required and must not exceed 500 characters.");

        RuleFor(x => x.Text).NotEmpty().MaximumLength(5000)
            .WithMessage("Text is required and must not exceed 5000 characters.");

        RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
    }
}
