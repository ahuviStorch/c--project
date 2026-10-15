

using DalApi;
using DalFacade.DO;

namespace Dal;

public class DalList:IDal
{
    public Istudent Student => new StudentImplementation();
    public Itest Test => new TestImplementation();
    public Iquestion Question => new QuestionImplementation();
    public Ianswer Answer => new AnswerImplementation();
    public IAnsToStudent AnsToStudent => new AnsToStudentImplementation();
}
