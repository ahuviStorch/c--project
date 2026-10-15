using DalApi;
using DO;

namespace Dal;

internal class QuestionImplementation : Iquestion
{
    // delete
    public void Delete(int id)
    {
        Question? existingQuestion = Read(id);
        if (existingQuestion is null)
            throw new Exception($"Question with ID {id} does not exist.");

        DataSource.Questions.Remove(existingQuestion);
    }

    // create
    public int Create(Question item)
    {
        int id = DataSource.Config.NextQuestionId;
        Question question = item with { Id = id };
        DataSource.Questions.Add(question);
        return id;
    }

    // read
    public Question? Read(int id)
    {
        return DataSource.Questions.FirstOrDefault(q => q?.Id == id);
    }

    // read all
    public List<Question> ReadAll()
    {
        return new List<Question>(DataSource.Questions!);
    }

    // update
    public void Update(Question item)
    {
        Question? existingQuestion = Read(item.Id);
        if (existingQuestion is null)
            throw new Exception($"Question with ID {item.Id} does not exist.");

        DataSource.Questions.Remove(existingQuestion);
        DataSource.Questions.Add(item);
    }
}