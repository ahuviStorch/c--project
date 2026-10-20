
using DO;
namespace DalApi;

public interface IDal
{
    IAnswer Answer { get; }
    IStudent Student { get; }
    IAnsToStudent AnsToStudent { get; }
IQuestion Question { get; }
    ITest Test { get; }
}
