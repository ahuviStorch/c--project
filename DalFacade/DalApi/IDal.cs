
using DO;
namespace DalApi;

public interface IDal
{
    Ianswer Answer { get; }
    Istudent Student { get; }
    IAnsToStudent AnsToStudent { get; }
}
