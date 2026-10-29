namespace SrpLab.NewClasses;

public class CsvExportation
{
    public string ExportStudentsGradeCsv(GradeBook gradeBook)
    {
        var rows = new List<string> { "studentId,average,letter,honor" };

        foreach (var id in gradeBook.Scores.Keys.OrderBy(x => x))
        {
            decimal average = gradeBook.Average(id);
            string letter = AcademicPolicy.Letter(id, average);
            bool isMeetHonorRoll = AcademicPolicy.MeetsHonorRoll(id, letter, average);
            rows.Add($"{id},{average},{letter},{(isMeetHonorRoll ? 1 : 0)}");
        }
        return string.Join('\n', rows);
    }

    public string ExportCensusCsv(Dictionary<int, string> bedPatient, Dictionary<int, int> vitalsScore)
    {
        // Persistence/export shape mixed into the same type as acuity + paging.
        var lines = new List<string> { "bed,patient,acuity" };
        foreach (var bed in bedPatient.Keys.OrderBy(x => x))
            lines.Add($"{bed},{bedPatient[bed]},{vitalsScore[bed]}");
        return string.Join('\n', lines);
    }
}
