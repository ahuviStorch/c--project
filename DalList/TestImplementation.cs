using DalApi;
using DO;

namespace Dal;

internal class TestImplementation : ITest
{
    // delete
    public void Delete(int id)
    {
        LogManager.write("DalList", "Delete", $"Deleting Test record with ID {id}.");
        Test? existingTest = Read(id);
        if (existingTest is null)
            throw new Exception($"Test with ID {id} does not exist.");

        DataSource.Tests.Remove(existingTest);
        LogManager.write("DalList", "Delete", $"Successfully deleted Test record with ID {id}.");
    }

    // create
    public int Create(Test item)
    {
        LogManager.write("DalList", "Create", $"Creating Test record with ID {item.Id}.");
        int id = DataSource.Config.NextTestId;
        Test test = item with { Id = id };
        DataSource.Tests.Add(test);
        LogManager.write("DalList", "Create", $"Successfully created Test record with ID {item.Id}.");
        return id;
    }

    // read
    public Test? Read(int id)
    {
        LogManager.write("DalList", "Read", $"Reading Test record with ID {id}.");
        LogManager.write("DalList", "Read", $"Successfully read Test record with ID {id}.");
        return DataSource.Tests.FirstOrDefault(t => t?.Id == id);
        
    }

    // read all
    public List<Test> ReadAll()
    {
        LogManager.write("DalList", "ReadAll", "Reading all Test records.");
        LogManager.write("DalList", "ReadAll", "Successfully read all Test records.");
        return new List<Test>(DataSource.Tests!);
    }

    // update
    public void Update(Test item)
    {
        LogManager.write("DalList", "Update", $"Updating Test record with ID {item.Id}.");
        Test? existingTest = Read(item.Id);
        if (existingTest is null)
            throw new Exception($"Test with ID {item.Id} does not exist.");

        DataSource.Tests.Remove(existingTest);
        DataSource.Tests.Add(item);
        LogManager.write("DalList", "Update", $"Successfully updated Test record with ID {item.Id}.");
    }
}