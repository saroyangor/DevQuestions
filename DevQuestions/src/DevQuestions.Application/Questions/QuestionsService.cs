using DevQuestions.Contracts.Questions;
using DevQuestions.Domain.Questions;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DevQuestions.Application.Questions;

public class QuestionsService(
    IQuestionsRepository questionsRepository,
    ILogger<QuestionsService> logger,
    IValidator<CreateQuestionDto> validator) : IQuestionsService
{
    public async Task<Guid> Create(CreateQuestionDto questionDto, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(questionDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        int openQuestionsCount =
            await questionsRepository.GetOpenQuestionsCountAsync(questionDto.UserId, cancellationToken);
        if (openQuestionsCount > 3)
        {
            throw new Exception("User cannot have more than 3 open questions.");
        }

        var questionId = Guid.NewGuid();

        var question = new Question(
            questionId,
            questionDto.Title,
            questionDto.Text,
            questionDto.UserId,
            null,
            questionDto.TagIds);

        await questionsRepository.AddAsync(question, cancellationToken);

        logger.LogInformation("Created question with id {QuestionId}", questionId);

        return questionId;
    }
}
