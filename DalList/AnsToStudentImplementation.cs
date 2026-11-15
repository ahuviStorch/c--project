using DalApi;
using DalFacade.DO;
using DO;
using Tools;
using System.Linq;

namespace Dal;

internal class AnsToStudentImplementation : IAnsToStudent
{
    // delete
    public void Delete(int id)
    {

        LogManager.write("DalList", "Delete", $"Deleting AnsToStudent record with ID {id}.");

        AnsToStudent? existingAns = (from item in DataSource.AnsToStudents
                                     where item?.id == id
                                     select item).FirstOrDefault();
                if (existingAns is null)
        {
            LogManager.write("DalList", "Delete", "\t\terror!!: delete ans to student failed\n");
            throw new DalIdNotFound($"AnsToStudent record with ID {id} does not exist.");
        }

        DataSource.AnsToStudents.Remove(existingAns);
        LogManager.write("DalList", "Delete", $"Successfully deleted AnsToStudent record with ID {id}.");
    }

    // create
    public int Create(AnsToStudent item)
    {
        LogManager.write("DalList", "Create", $"Creating AnsToStudent record with ID {item.id}.");
        AnsToStudent? existingAns = (from ans in DataSource.AnsToStudents
                                     where ans?.id == item.id
                                     select ans).FirstOrDefault();
        if (existingAns is not null)
        {
            LogManager.write("DalList", "Create", "\t\terror!!: create ans to student failed\n");
            throw new DalIdAlreadyExist($"AnsToStudent record with ID {item.id} already exists.");
        }
        DataSource.AnsToStudents.Add(item);
        LogManager.write("DalList", "Create", $"Successfully created AnsToStudent record with ID {item.id}.");
                return item.id; 

    }

    // read
    public AnsToStudent? Read(Func<AnsToStudent, bool> filter)
    {
        LogManager.write("DalList", "Read", "Reading AnsToStudent record.");
        AnsToStudent? ans = (from item in DataSource.AnsToStudents
                                     where filter(item)
                                     select item).FirstOrDefault();
        if (ans is null)
            LogManager.write("DalList", "Read", $"\t\terror!!: read ans to student failed\n");
        
        else
            LogManager.write("DalList", "Read", $"Successfully read AnsToStudent record.");
        return ans;
    }

    public AnsToStudent? Read(int id)
    {
        LogManager.write("DalList", "Read", "Reading AnsToStudent record.");
        AnsToStudent? ans = (from item in DataSource.AnsToStudents
                                     where item?.id == id
                                     select item).FirstOrDefault();
        if (ans is null){
            LogManager.write("DalList", "Read", $"\t\terror!!: read ans to student failed\n");
            throw new DalIdNotFound($"AnsToStudent record with ID {id} does not exist.");
        }
        else
            LogManager.write("DalList", "Read", $"Successfully read AnsToStudent record.");
        return ans;
    }

    // read all
    public List<AnsToStudent?> ReadAll(Func<AnsToStudent, bool>? filter = null)
    {
        LogManager.write("DalList", "ReadAll", "Reading all AnsToStudent records.");

        List<AnsToStudent?> ansList = (from item in DataSource.AnsToStudents
                                       where item is not null && (filter == null || filter(item))
                                       select item).ToList();
        LogManager.write("DalList", "ReadAll", "Successfully read all AnsToStudent records.");
        return ansList;
    }

    // update
    public void Update(AnsToStudent item)
    {
        LogManager.write("DalList", "Update", $"Updating AnsToStudent record with ID {item.id}.");
        AnsToStudent? existingAns = (from ans in DataSource.AnsToStudents
                                     where ans?.id == item.id
                                     select ans).FirstOrDefault();
        if (existingAns is null){
            LogManager.write("DalList", "Update", "\t\terror!!: update ans to student failed\n");
            throw new DalIdNotFound($"AnsToStudent record with ID {item.id} does not exist.");
        }
        DataSource.AnsToStudents.Remove(existingAns);
        DataSource.AnsToStudents.Add(item);
        LogManager.write("DalList", "Update", $"Successfully updated AnsToStudent record with ID {item.id}.");
    }
}