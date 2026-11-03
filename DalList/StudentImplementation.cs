using DalApi;
using DalFacade.DO;
using DO;
using Tools;

namespace Dal;


internal class StudentImplementation : IStudent
{

    //create func
    public int Create(Student item)
    {
        LogManager.write("DalList", "Create", $"Creating Student record with ID {item.Id}.");
        Student? existingStudent = Read(item.Id);
        if (existingStudent is not null)
            throw new Exception($"Student with ID {item.Id} already exists.");

        DataSource.Students.Add(item);
        LogManager.write("DalList", "Create", $"Successfully created Student record with ID {item.Id}.");
        return item.Id;
    }

    //read funcs
    public Student? Read(int id)
    {
        LogManager.write("DalList", "Read", $"Reading Student record with ID {id}.");
        LogManager.write("DalList", "Read", $"Successfully read Student record with ID {id}.");
        return DataSource.Students.FirstOrDefault(s => s?.Id == id);
    }


    public List<Student> ReadAll()
    {
        LogManager.write("DalList", "ReadAll", "Reading all Student records.");
        LogManager.write("DalList", "ReadAll", "Successfully read all Student records.");
        return new List<Student>(DataSource.Students!);
    }

    //update func
    public void Update(Student item)
    {
        LogManager.write("DalList", "Update", $"Updating Student record with ID {item.Id}.");
        Student? existingStudent = Read(item.Id);
        if (existingStudent is null)
            throw new Exception($"Student with ID {item.Id} does not exist.");

        DataSource.Students.Remove(existingStudent);
        DataSource.Students.Add(item);
        LogManager.write("DalList", "Update", $"Successfully updated Student record with ID {item.Id}.");
    }

    //delete func
    public void Delete(int id)
    {
        LogManager.write("DalList", "Delete", $"Deleting Student record with ID {id}.");
        Student? existingStudent = Read(id);
        if (existingStudent is null)
            throw new Exception($"Student with ID {id} does not exist.");

        DataSource.Students.Remove(existingStudent);
        LogManager.write("DalList", "Delete", $"Successfully deleted Student record with ID {id}.");
    }
}