
using DalFacade.DO;
using DO;
namespace Dal;

static internal class DataSource
{
    static internal List<Answer?> Answers { get; } = new List<Answer?>();
    static internal List<Student?> Students { get; } = new List<Student?>();
    static internal List<AnsToStudent?> AnsToStudents { get; } = new List<AnsToStudent?>();

    static internal class Config
    {
        internal const int init = 1;
        private static int i = init;
        internal static int NextAnswerId => i++;
    }


}

