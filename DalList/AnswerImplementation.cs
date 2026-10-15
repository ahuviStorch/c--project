
using DalApi;
using DalFacade.DO;
using DO;
namespace Dal;

internal class AnswerImplementation : Ianswer
{
    //create func
    public int Create(Answer item)
    {
int id= DataSource.Config.NextAnswerId;
Answer answer= new Answer( id, item.QuestionId,item.Content);
        DataSource.Answers.Add(answer);
        return id;
    }

    //read funcs
    public Answer? Read(int id)
    {
        return DataSource.Answers.FirstOrDefault(s => s?.Id == id);

    }
    public List<Answer> ReadAll()
    {
        return new List<Answer>(DataSource.Answers!);
    }

    //update func
    public void Update(Answer item)
    {
        Answer? existingAnswer = Read(item.Id);
        if (existingAnswer is null)
            throw new Exception($"Answer with ID {item.Id} does not exist.");
        DataSource.Answers.Remove(existingAnswer);
        DataSource.Answers.Add(item);

    }

    //delete func
    public void Delete(int id)
    {
        Answer? existingAnswer = Read(id);
        if (existingAnswer is null)
            throw new Exception($"Answer with ID {id} does not exist.");
        DataSource.Answers.Remove(existingAnswer);
    }

}
