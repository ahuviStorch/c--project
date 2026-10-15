using DalApi;
using DO;

namespace Dal;

internal class TestImplementation : Itest
{
    // delete
    public void Delete(int id)
    {
        Test? existingTest = Read(id);
        if (existingTest is null)
            throw new Exception($"Test with ID {id} does not exist.");

        DataSource.Tests.Remove(existingTest);
    }

    // create
    public int Create(Test item)
    {
        int id = DataSource.Config.NextTestId;
        Test test = item with { Id = id };
        DataSource.Tests.Add(test);
        return id;
    }

    // read
    public Test? Read(int id)
    {
        return DataSource.Tests.FirstOrDefault(t => t?.Id == id);
    }

    // read all
    public List<Test> ReadAll()
    {
        return new List<Test>(DataSource.Tests!);
    }

    // update
    public void Update(Test item)
    {
        Test? existingTest = Read(item.Id);
        if (existingTest is null)
            throw new Exception($"Test with ID {item.Id} does not exist.");

        DataSource.Tests.Remove(existingTest);
        DataSource.Tests.Add(item);
    }
}