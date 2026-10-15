using DalApi;
using DalFacade.DO;
using DO;

namespace Dal;

internal class AnsToStudentImplementation : IAnsToStudent
{
    // delete
    public void Delete(int id)
    {
        AnsToStudent? existingAns = Read(id);
        if (existingAns is null)
            throw new Exception($"AnsToStudent record with ID {id} does not exist.");

        DataSource.AnsToStudents.Remove(existingAns);
    }

    // create
    public int Create(AnsToStudent item)
    {
        AnsToStudent? existingAns = Read(item.id);
        if (existingAns is not null)
            throw new Exception($"AnsToStudent record with ID {item.id} already exists.");

        DataSource.AnsToStudents.Add(item);
        return item.id;
    }

    // read
    public AnsToStudent? Read(int id)
    {
        return DataSource.AnsToStudents.FirstOrDefault(a => a?.id == id);
    }

    // read all
    public List<AnsToStudent> ReadAll()
    {
        return new List<AnsToStudent>(DataSource.AnsToStudents!);
    }

    // update
    public void Update(AnsToStudent item)
    {
        AnsToStudent? existingAns = Read(item.id);
        if (existingAns is null)
            throw new Exception($"AnsToStudent record with ID {item.id} does not exist.");

        DataSource.AnsToStudents.Remove(existingAns);
        DataSource.AnsToStudents.Add(item);
    }
}