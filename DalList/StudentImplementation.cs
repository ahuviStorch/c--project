
using DalApi;
using DalFacade.DO;
namespace Dal;

internal class StudentImplementation:Istudent
{
    public int Create(Student item)
    {
        if (Read(item.Id) != null)
            throw new Exception($"Student with ID {item.Id} already exists.");

        DataSource.Students.Add(item);
        return item.Id;


    }
    public Student? Read(int id)
    {
        return DataSource.Students.FirstOrDefault(s => s?.Id == id);
            
    }
    public List<Student> ReadAll()
    {
        return new List<Student>(DataSource.Students!);
    }
    public void Update(Student item)
    {
        Student? existingStudent = Read(item.Id);
        if (existingStudent is null)
            throw new Exception($"Student with ID {item.Id} does not exist.");
        DataSource.Students.Remove(item);
        DataSource.Students.Add(item);

    }
    public void Delete(int id)
    { 
        Student?  existingStudent = Read(id);
        if (existingStudent is null)
            throw new Exception($"Student with ID {id} does not exist.");
        DataSource.Students.Remove(existingStudent);
    }

}
