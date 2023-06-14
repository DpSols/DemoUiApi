namespace QaseServices.Project.Models;

public record TestDefect(string DefectTitle, string DefectActualResult, Severity SeverityLvl);

public enum Severity
{
    Blocker,
    Critical,
    Major,
    Normal,
    Minor,
    Trivial
}