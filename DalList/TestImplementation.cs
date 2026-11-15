using DalApi;
using DO;
using Tools;

namespace Dal;

internal class TestImplementation : ITest
{
    // delete
    public void Delete(int id)
    {
        LogManager.write("DalList", "Delete", $"Deleting Test record with ID {id}.");
        Test? existingTest = (from t in DataSource.Tests
                               where t?.Id == id
                               select t).FirstOrDefault();
        if (existingTest is null){
            LogManager.write("DalList", "Delete", "\t\terror!!: delete test failed\n");
            throw new DalIdNotFound($"Test with ID {id} does not exist.");
        }
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
        LogManager.write("DalList", "Create", $"Successfully created Test record with ID {id}.");
        return id;
    }

    // read
    public Test? Read(Func<Test, bool> filter)
    {
        LogManager.write("DalList", "Read", "Reading Test record.");
        Test? test = (from t in DataSource.Tests
                      where filter(t)
                      select t).FirstOrDefault();
        if (test is null)
            LogManager.write("DalList", "Read", $"\t\terror!!: read test failed\n");
        else
            LogManager.write("DalList", "Read", $"Successfully read Test record.");
        return test;
    }

    public Test? Read(int id)
    {
        LogManager.write("DalList", "Read", "Reading Test record.");
        Test? test = (from t in DataSource.Tests
                      where t?.Id == id
                      select t).FirstOrDefault();
        if (test is null){
            LogManager.write("DalList", "Read", $"\t\terror!!: read test failed\n");
            throw new DalIdNotFound($"Test with ID {id} does not exist.");
        }
        else
            LogManager.write("DalList", "Read", $"Successfully read Test record.");
        return test;
    }

    // read all
    public List<Test?> ReadAll(Func<Test, bool>? filter = null)
    {
        LogManager.write("DalList", "ReadAll", "Reading all Test records.");
        List<Test?> tests = (from t in DataSource.Tests
                            where t is not null && (filter == null || filter(t))
                            select t).ToList();
        LogManager.write("DalList", "ReadAll", "Successfully read all Test records.");
        return tests;
    }

    // update
    public void Update(Test item)
    {
        LogManager.write("DalList", "Update", $"Updating Test record with ID {item.Id}.");
        Test? existingTest = (from t in DataSource.Tests
                               where t?.Id == item.Id
                               select t).FirstOrDefault();
        if (existingTest is null){
            LogManager.write("DalList", "Update", "\t\terror!!: update test failed\n");
            throw new DalIdNotFound($"Test with ID {item.Id} does not exist.");
        }
        DataSource.Tests.Remove(existingTest);
        DataSource.Tests.Add(item);
        LogManager.write("DalList", "Update", $"Successfully updated Test record with ID {item.Id}.");
    }
}