

using DalApi;
using DalFacade.DO;

namespace Dal;

public class DalList:IDal
{
    public IStudent Student => new StudentImplementation();
    public ITest Test => new TestImplementation();
    public IQuestion Question => new QuestionImplementation();
    public IAnswer Answer => new AnswerImplementation();
    public IAnsToStudent AnsToStudent => new AnsToStudentImplementation();
}
