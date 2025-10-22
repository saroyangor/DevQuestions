namespace DevQuestions.Infrastructure.Postgres.Seeders;

public class QuestionsSeeder(QuestionsDbContext dbContext) : ISeeder
{
    private readonly QuestionsDbContext _dbContext = dbContext;

    public Task SeedAsync()
    {
        throw new NotImplementedException();
    }
}
