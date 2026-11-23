

using DalApi;
using DalFacade.DO;
using System.ComponentModel;

namespace Dal;

internal sealed class DalList : IDal
{
    public IStudent Student => new StudentImplementation();
    public ITest Test => new TestImplementation();
    public IQuestion Question => new QuestionImplementation();
    public IAnswer Answer => new AnswerImplementation();
    public IAnsToStudent AnsToStudent => new AnsToStudentImplementation();
    private DalList() { }
    private static readonly DalList instance = new DalList();
    public static DalList Instance { get; } = instance;


}
