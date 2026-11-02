
using DalApi;
using DalFacade.DO;
using DO;
namespace Dal;

internal class AnswerImplementation : IAnswer
{
    //create func
    public int Create(Answer item)
    {
        LogManager.write("DalList", "Create", $"Creating Answer record with ID {item.Id}.");
        int id = DataSource.Config.NextAnswerId;
        Answer answer = new Answer(id, item.QuestionId, item.Content);
        DataSource.Answers.Add(answer);
        LogManager.write("DalList", "Create", $"Successfully created Answer record with ID {item.Id}.");
        return id;
    }

    //read funcs
    public Answer? Read(int id)
    {
        LogManager.write("DalList", "Read", $"Reading Answer record with ID {id}.");
        LogManager.write("DalList", "Read", $"Successfully read Answer record with ID {id}.");
        return DataSource.Answers.FirstOrDefault(a => a?.Id == id);
    }
    public List<Answer> ReadAll()
    {
        LogManager.write("DalList", "ReadAll", "Reading all Answer records.");
        LogManager.write("DalList", "ReadAll", "Successfully read all Answer records.");
        return new List<Answer>(DataSource.Answers!);
    }

    //update func
    public void Update(Answer item)
    {
        LogManager.write("DalList", "Update", $"Updating Answer record with ID {item.Id}.");
        Answer? existingAnswer = Read(item.Id);
        if (existingAnswer is null)
            throw new Exception($"Answer with ID {item.Id} does not exist.");
        DataSource.Answers.Remove(existingAnswer);
        DataSource.Answers.Add(item);
        LogManager.write("DalList", "Update", $"Successfully updated Answer record with ID {item.Id}.");

    }

    //delete func
    public void Delete(int id)
    {
        LogManager.write("DalList", "Delete", $"Deleting Answer record with ID {id}.");
        Answer? existingAnswer = Read(id);
        if (existingAnswer is null)
            throw new Exception($"Answer with ID {id} does not exist.");
        DataSource.Answers.Remove(existingAnswer);
        LogManager.write("DalList", "Delete", $"Successfully deleted Answer record with ID {id}.");
    }

}
