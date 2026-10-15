using DalApi;
using DalFacade.DO;
using DO;

namespace Dal;


internal class StudentImplementation : Istudent
{

    //create func
    public int Create(Student item)
    {
        Student? existingStudent = Read(item.Id);
        if (existingStudent is not null)
            throw new Exception($"Student with ID {item.Id} already exists.");

        DataSource.Students.Add(item);
        return item.Id;
    }

 //read funcs
    public Student? Read(int id)
    {
        return DataSource.Students.FirstOrDefault(s => s?.Id == id);
    }


    public List<Student> ReadAll()
    {
        return new List<Student>(DataSource.Students!);
    }

//update func
    public void Update(Student item)
    {
        Student? existingStudent = Read(item.Id);
        if (existingStudent is null)
            throw new Exception($"Student with ID {item.Id} does not exist.");

        DataSource.Students.Remove(existingStudent);
        DataSource.Students.Add(item);
    }

//delete func
    public void Delete(int id)
    {
        Student? existingStudent = Read(id);
        if (existingStudent is null)
            throw new Exception($"Student with ID {id} does not exist.");

        DataSource.Students.Remove(existingStudent);
    }
}