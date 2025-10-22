using DevQuestions.Contracts.Questions;
using FluentValidation;

namespace DevQuestions.Application.Questions;

public class CreateQuestionValidator : AbstractValidator<CreateQuestionDto>
{
    public CreateQuestionValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title can't be empty.")
            .MaximumLength(500).WithMessage("Title is invalid.");

        RuleFor(x => x.Text)
            .NotEmpty().WithMessage("Text can't be empty.")
            .MaximumLength(5000).WithMessage("Text is invalid.");

        RuleFor(x => x.UserId).NotEmpty();
    }
}
