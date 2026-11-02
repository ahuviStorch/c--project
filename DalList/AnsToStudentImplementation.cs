using DalApi;
using DalFacade.DO;
using DO;

namespace Dal;

internal class AnsToStudentImplementation : IAnsToStudent
{
    // delete
    public void Delete(int id)
    {
        LogManager.write("DalList", "Delete", $"Deleting AnsToStudent record with ID {id}.");
        AnsToStudent? existingAns = Read(id);
        if (existingAns is null)
            throw new Exception($"AnsToStudent record with ID {id} does not exist.");

        DataSource.AnsToStudents.Remove(existingAns);
        LogManager.write("DalList", "Delete", $"Successfully deleted AnsToStudent record with ID {id}.");
    }

    // create
    public int Create(AnsToStudent item)
    {
        LogManager.write("DalList", "Create", $"Creating AnsToStudent record with ID {item.id}.");
        AnsToStudent? existingAns = Read(item.id);
        if (existingAns is not null)
            throw new Exception($"AnsToStudent record with ID {item.id} already exists.");

        DataSource.AnsToStudents.Add(item);
        LogManager.write("DalList", "Create", $"Successfully created AnsToStudent record with ID {item.id}.");
                return item.id; 

    }

    // read
    public AnsToStudent? Read(int id)
    {
        LogManager.write("DalList", "Read", $"Reading AnsToStudent record with ID {id}.");
        LogManager.write("DalList", "Read", $"Successfully read AnsToStudent record with ID {id}.");
        return DataSource.AnsToStudents.FirstOrDefault(a => a?.id == id);
    }   

    // read all
    public List<AnsToStudent> ReadAll()
    {
        LogManager.write("DalList", "ReadAll", "Reading all AnsToStudent records.");
        LogManager.write("DalList", "ReadAll", "Successfully read all AnsToStudent records.");
        return new List<AnsToStudent>(DataSource.AnsToStudents!);
    }

    // update
    public void Update(AnsToStudent item)
    {
        LogManager.write("DalList", "Update", $"Updating AnsToStudent record with ID {item.id}.");
        AnsToStudent? existingAns = Read(item.id);
        if (existingAns is null)
            throw new Exception($"AnsToStudent record with ID {item.id} does not exist.");

        DataSource.AnsToStudents.Remove(existingAns);
        DataSource.AnsToStudents.Add(item);
        LogManager.write("DalList", "Update", $"Successfully updated AnsToStudent record with ID {item.id}.");
    }
}