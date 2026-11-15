using DO;
using DalApi;
namespace Dal;
using Tools;


internal class AnswerImplementation : IAnswer
{
    //create func
    public int Create(Answer item)
    {
        LogManager.write("DalList", "Create", $"Creating Answer record with ID {item.Id}.");
        int id = DataSource.Config.NextAnswerId;
        Answer answer = new Answer(id, item.QuestionId, item.Content);
        DataSource.Answers.Add(answer);
        LogManager.write("DalList", "Create", $"Successfully created Answer record with ID {id}.");
        return id;
    }

    //read funcs
    public Answer? Read(Func<Answer, bool> filter)
    {
        LogManager.write("DalList", "Read", "Reading Answer record.");
        Answer? answer = (from a in DataSource.Answers
                           where filter(a)
                           select a).FirstOrDefault();
        if (answer is null)
            LogManager.write("DalList", "Read", $"\t\terror!!: read answer failed\n"); 
        else
            LogManager.write("DalList", "Read", $"Successfully read Answer record.");
        return answer;
    }

    public Answer? Read(int id)
    {
        LogManager.write("DalList", "Read", "Reading Answer record.");
        Answer? answer = (from a in DataSource.Answers
                           where a?.Id == id
                           select a).FirstOrDefault();
        if (answer is null){
            LogManager.write("DalList", "Read", $"\t\terror!!: read answer failed\n"); 
            throw new DalIdNotFound($"Answer with ID {id} does not exist.");
        }
        else
            LogManager.write("DalList", "Read", $"Successfully read Answer record.");
        return answer;
    }
    public List<Answer?> ReadAll(Func<Answer, bool>? filter = null)
    {
        LogManager.write("DalList", "ReadAll", "Reading all Answer records.");
        List<Answer?> answers = (from a in DataSource.Answers
                                 where a is not null && (filter == null || filter(a))
                                 select a).ToList();
        LogManager.write("DalList", "ReadAll", "Successfully read all Answer records.");
        return answers;
    }

    //update func
    public void Update(Answer item)
    {
        LogManager.write("DalList", "Update", $"Updating Answer record with ID {item.Id}.");
        Answer? existingAnswer = (from a in DataSource.Answers
                                   where a?.Id == item.Id
                                   select a).FirstOrDefault();
        if (existingAnswer is null){
            LogManager.write("DalList", "Update", "\t\terror!!: update answer failed\n");   
            throw new DalIdNotFound($"Answer with ID {item.Id} does not exist.");
        }
        DataSource.Answers.Remove(existingAnswer);
        DataSource.Answers.Add(item);
        LogManager.write("DalList", "Update", $"Successfully updated Answer record with ID {item.Id}.");

    }

    //delete func
    public void Delete(int id)
    {
        LogManager.write("DalList", "Delete", $"Deleting Answer record with ID {id}.");
        Answer? existingAnswer = (from a in DataSource.Answers
                                   where a?.Id == id
                                   select a).FirstOrDefault();
        if (existingAnswer is null){
            LogManager.write("DalList", "Delete", "\t\terror!!: delete answer failed\n");
            throw new DalIdNotFound($"Answer with ID {id} does not exist.");
        }
        DataSource.Answers.Remove(existingAnswer);
        LogManager.write("DalList", "Delete", $"Successfully deleted Answer record with ID {id}.");
    }

}
