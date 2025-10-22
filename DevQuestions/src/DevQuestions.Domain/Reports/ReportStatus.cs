namespace DevQuestions.Domain.Reports;

public enum ReportStatus
{
    /// <summary>
    /// ReportStatus Open
    /// </summary>
    OPEN,

    /// <summary>
    /// ReportStatus In Progress
    /// </summary>
    IN_PROGRESS,

    /// <summary>
    /// ReportStatus Resolved
    /// </summary>
    RESOLVED,

    /// <summary>
    /// ReportStatus Dismissed
    /// </summary>
    DISMISSED,
}
