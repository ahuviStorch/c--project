using DalApi;
using DO;

namespace Dal;

internal class QuestionImplementation : IQuestion
{
    // delete
    public void Delete(int id)
    {
        LogManager.write("DalList", "Delete", $"Deleting Question record with ID {id}.");
        Question? existingQuestion = Read(id);
        if (existingQuestion is null)
            throw new Exception($"Question with ID {id} does not exist.");

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
        LogManager.write("DalList", "Create", $"Successfully created Question record with ID {item.Id}.");
                return id;
    }

    // read
    public Question? Read(int id)
    {
        LogManager.write("DalList", "Read", $"Reading Question record with ID {id}.");
        LogManager.write("DalList", "Read", $"Successfully read Question record with ID {id}.");
          return DataSource.Questions.FirstOrDefault(q => q?.Id == id);

    }

    // read all
    public List<Question> ReadAll()
    {
        LogManager.write("DalList", "ReadAll", "Reading all Question records.");
        LogManager.write("DalList", "ReadAll", "Successfully read all Question records.");
                return new List<Question>(DataSource.Questions!);
    }

    // update
    public void Update(Question item)
    {
        LogManager.write("DalList", "Update", $"Updating Question record with ID {item.Id}.");
        Question? existingQuestion = Read(item.Id);
        if (existingQuestion is null)
            throw new Exception($"Question with ID {item.Id} does not exist.");

        DataSource.Questions.Remove(existingQuestion);
        DataSource.Questions.Add(item);
        LogManager.write("DalList", "Update", $"Successfully updated Question record with ID {item.Id}.");
    }
}