using Shared;

namespace DevQuestions.Application.Questions.Fails;

public partial class Errors
{
    public static class Questions
    {
        public static Error TooManyQuestions() =>
            Error.Failure("question.too.many", "User can't have more than 3 open questions at the same time.");
    }
}
