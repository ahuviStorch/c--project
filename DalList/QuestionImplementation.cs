using DalApi;
using DO;
using Tools;

namespace Dal;

internal class QuestionImplementation : IQuestion
{
    // delete
    public void Delete(int id)
    {
        LogManager.write("DalList", "Delete", $"Deleting Question record with ID {id}.");
        Question? existingQuestion = (from q in DataSource.Questions
                                     where q?.Id == id
                                     select q).FirstOrDefault();
        if (existingQuestion is null){
            LogManager.write("DalList", "Delete", "\t\terror!!: delete question failed\n");
            throw new DalIdNotFound($"Question with ID {id} does not exist.");}
        DataSource.Questions.Remove(existingQuestion);
        LogManager.write("DalList", "Delete", $"Successfully deleted Question record with ID {id}.");
    }

    // create
    public int Create(Question item)
    {
        LogManager.write("DalList", "Create", $"Creating Question record with ID {item.Id}.");
        int id = DataSource.Config.NextQuestionId;
        Question question = item with { Id = id };
        DataSource.Questions.Add(question);
        LogManager.write("DalList", "Create", $"Successfully created Question record with ID {id}.");
        return id;
    }

    // read
    public Question? Read(Func<Question, bool> filter)
    {
        LogManager.write("DalList", "Read", "Reading Question record.");
        Question? question = (from q in DataSource.Questions
                                     where filter(q)
                                     select q).FirstOrDefault();
        if (question is null)
        {
            LogManager.write("DalList", "Read", $"\t\terror!!: read question failed\n");
        }
        else
            LogManager.write("DalList", "Read", $"Successfully read Question record.");
        return question;
    }
    public Question? Read(int id)
    {
        LogManager.write("DalList", "Read", "Reading Question record.");
        Question? question = (from q in DataSource.Questions
                                     where q?.Id == id
                                     select q).FirstOrDefault();
        if (question is null)
        {
            LogManager.write("DalList", "Read", $"\t\terror!!: read question failed\n");
            throw new DalIdNotFound($"Question with ID {id} does not exist.");
        }
        else
            LogManager.write("DalList", "Read", $"Successfully read Question record.");
        return question;
    }

    // read all
    public List<Question?> ReadAll(Func<Question, bool>? filter = null)
    {
        LogManager.write("DalList", "ReadAll", "Reading all Question records.");

        List<Question?> questions = (from q in DataSource.Questions
                                     where q is not null && (filter == null || filter(q))
                                     select q).ToList();
        LogManager.write("DalList", "ReadAll", "Successfully read all Question records.");
         return questions;
    }

    // update
    public void Update(Question item)
    {
        LogManager.write("DalList", "Update", $"Updating Question record with ID {item.Id}.");
        Question? existingQuestion = (from q in DataSource.Questions
                                     where q?.Id == item.Id
                                     select q).FirstOrDefault();
        if (existingQuestion is null){
            LogManager.write("DalList", "Update", "\t\terror!!: update question failed\n");
            throw new DalIdNotFound($"Question with ID {item.Id} does not exist.");
        }

        DataSource.Questions.Remove(existingQuestion);
        DataSource.Questions.Add(item);
        LogManager.write("DalList", "Update", $"Successfully updated Question record with ID {item.Id}.");
    }
}