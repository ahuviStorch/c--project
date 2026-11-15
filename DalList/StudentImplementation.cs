using DalApi;
using DO;
using Tools;

namespace Dal;


internal class StudentImplementation : IStudent
{

    //create func
    public int Create(Student item)
    {
        LogManager.write("DalList", "Create", $"Creating Student record with ID {item.Id}.");
        Student? existingStudent = (from s in DataSource.Students
                                    where s?.Id == item.Id
                                    select s).FirstOrDefault();
        if (existingStudent is not null){
            LogManager.write("DalList", "Create", "\t\terror!!: create student failed\n");
            throw new DalIdAlreadyExist($"Student with ID {item.Id} already exists.");
        }

        DataSource.Students.Add(item);
        LogManager.write("DalList", "Create", $"Successfully created Student record with ID {item.Id}.");
        return item.Id;
    }

    //read funcs
    public Student? Read(Func<Student, bool> filter)
    {
        LogManager.write("DalList", "Read", "Reading Student record.");
        Student? student = (from s in DataSource.Students
                             where filter(s)
                             select s).FirstOrDefault();
        if (student is null)
            LogManager.write("DalList", "Read", $"\t\terror!!: read student failed\n");
        else
            LogManager.write("DalList", "Read", $"Successfully read Student record.");
        return student;
    }

    public Student? Read(int id)
    {
        LogManager.write("DalList", "Read", "Reading Student record.");
        Student? student = (from s in DataSource.Students
                             where s?.Id == id
                             select s).FirstOrDefault();
        if (student is null){
            LogManager.write("DalList", "Read", $"\t\terror!!: read student failed\n");
            throw new DalIdNotFound($"Student with ID {id} does not exist.");
        }
        else
            LogManager.write("DalList", "Read", $"Successfully read Student record.");
        return student;
    }

    public List<Student?> ReadAll(Func<Student, bool>? filter = null)
    {
        LogManager.write("DalList", "ReadAll", "Reading all Student records.");
        List<Student?> students = (from s in DataSource.Students
                                     where s is not null && (filter == null || filter(s))
                                     select s).ToList();
        LogManager.write("DalList", "ReadAll", "Successfully read all Student records.");
        return students;
    }

    //update func
    public void Update(Student item)
    {
        LogManager.write("DalList", "Update", $"Updating Student record with ID {item.Id}.");
        Student? existingStudent = (from s in DataSource.Students
                                     where s?.Id == item.Id
                                     select s).FirstOrDefault();
        if (existingStudent is null){
            LogManager.write("DalList", "Update", "\t\terror!!: update student failed\n");
            throw new DalIdNotFound($"Student with ID {item.Id} does not exist.");
        }
        DataSource.Students.Remove(existingStudent);
        DataSource.Students.Add(item);
        LogManager.write("DalList", "Update", $"Successfully updated Student record with ID {item.Id}.");
    }

    //delete func
    public void Delete(int id)
    {
        LogManager.write("DalList", "Delete", $"Deleting Student record with ID {id}.");
        Student? existingStudent = (from s in DataSource.Students
                                     where s?.Id == id
                                     select s).FirstOrDefault();
        if (existingStudent is null){
            LogManager.write("DalList", "Delete", "\t\terror!!: delete student failed\n");
            throw new DalIdNotFound($"Student with ID {id} does not exist.");
        }

        DataSource.Students.Remove(existingStudent);
        LogManager.write("DalList", "Delete", $"Successfully deleted Student record with ID {id}.");
    }
}