using DevQuestions.Application.Exceptions;

namespace DevQuestions.Application.Questions.Fails.Exceptions;

public class ToManyQuestionsException() : BadRequestException([Errors.Questions.TooManyQuestions()]);
