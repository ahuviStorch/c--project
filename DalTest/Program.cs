using Dal;
using DalApi;
using DalFacade.DO;
using DalTest;
using DO;
namespace DalTest;

internal partial class Program
{
    private static readonly IDal s_dal = new Dal.DalList();

    public static void Main(string[] args)
    {
        try
        {
            // אתחול בסיס הנתונים
            Initialization.Initialize(s_dal);
            bool exit = false;
            while (!exit)
            {
               
                Console.WriteLine("hello and welcome to our platform.\nto student press 1\n" +
                    "to tests press 2\nto question press 3\nto answer press 4\nto answer per student press 5" +
                    "\nto exit press 0\n\n");

                int key = int.Parse(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        crudMenu(s_dal.Student, "Student", AskStudent); break;
                    case 2:
                        crudMenu(s_dal.Test, "Test",AskTest); break;
                    case 3:
                        crudMenu(s_dal.Question, "Question",AskQuestion); break;
                    case 4:
                        crudMenu(s_dal.Answer, "Answer",AskAnswer); break;
                    case 5:
                        crudMenu(s_dal.AnsToStudent, "AnsToStudent",AskAnsToStudent); break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("no valid input, try again");
                        break;

                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void crudMenu<T>(ICrud<T> crud, string entityName, Func<T> askFunc) where T : class
    {
        Console.WriteLine("\n\npress create, read, readAll, update or delete\n");
        string ans = Console.ReadLine();
        switch (ans)
        {
            case "create":
                {
                   T obj = askFunc();
                   crud.Create(obj);
                    Console.WriteLine("created successed\n");
                    break;

                }
            case "update":
                {
                    T obj = askFunc();
                    crud.Update(obj); 
                    Console.WriteLine("update successed\n"); break;
                    Console.WriteLine("update successed\n"); break;
                    Console.WriteLine("update successed\n"); break;
                }
              
                
            case "read":
                {
                    Console.WriteLine("insert id");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine(crud.Read(id));
                }
                break;
            case "readAll":
                {
                    foreach (var item in crud.ReadAll())
                        Console.WriteLine(item);
                }
                break;
        
                case "delete":
                {
                    Console.WriteLine("insert id");
                    int id = int.Parse(Console.ReadLine());
                    crud.Delete(id);
                    Console.WriteLine("delete successed\n");
                }
                break;
            default:
                throw new Exception("\nnot valid input, try again\n");

                }
        }







    //פונקציות הקבלה של הפרטים 
    public static Student AskStudent()
    {
        Console.WriteLine("insert id");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("insert name");
        string name = Console.ReadLine();
        Console.WriteLine("insert test id");
        int test_id = int.Parse(Console.ReadLine());
        Console.WriteLine("insert mark");
        int mark = int.Parse(Console.ReadLine());
        Student student = new Student(id, name, test_id, mark);
        return student;
    }
    public static Answer AskAnswer()
    {
        Console.WriteLine("insert question id");
        int question_id = int.Parse(Console.ReadLine());
        Console.WriteLine("insert content");
        string content = Console.ReadLine();

        Answer ans = new Answer(0, question_id,content);
        return ans;
    }
    public static Question AskQuestion()
    {
        Console.WriteLine("insert id");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("subject: \n");
        foreach (Subject entity in Enum.GetValues(typeof(Subject)))
        {
            Console.WriteLine($"{(int)entity}. {entity}");
        }
        Console.Write("press the num of the subject ");
        bool valid = false;
        Subject sub= default;
        while (!valid)
        {
            string input = Console.ReadLine();
            sub = new Subject();
            // המרת הקלט הבטוח לתוך ה-enum
            if (Enum.TryParse(input, true, out Subject selectedEntity) && Enum.IsDefined(typeof(Subject), selectedEntity))
            {
                sub = selectedEntity;
                valid = true;
            }
            else Console.Write("no valid input");
        }

        Console.WriteLine("insert content");
        string content = Console.ReadLine();
        
        Console.WriteLine("insert correct answer id");
        int correct = int.Parse(Console.ReadLine());
        Question question = new Question(id, sub,content,correct);
        return question;
    }

    public static Test AskTest()
    {

        Console.WriteLine("subject: \n");
        foreach (Subject entity in Enum.GetValues(typeof(Subject)))
        {
            Console.WriteLine($"{(int)entity}. {entity}");
        }
        Console.Write("press the num of the subject ");
        bool valid = false;
        Subject sub = default;
        while (!valid)
        {
            string input = Console.ReadLine();
            sub = new Subject();
            // המרת הקלט הבטוח לתוך ה-enum
            if (Enum.TryParse(input, true, out Subject selectedEntity) && Enum.IsDefined(typeof(Subject), selectedEntity))
            {
                sub = selectedEntity;
                valid = true;
            }
            else Console.Write("no valid input\n");
        }

        Console.WriteLine("insert Date\n");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("insert question number\n");
        int quest = int.Parse(Console.ReadLine());

        Test test = new Test(0, sub, date, quest);
       return test;
    }

    public static AnsToStudent AskAnsToStudent()
    {
        Console.WriteLine("insert student id");
        int student_id = int.Parse(Console.ReadLine());
        Console.WriteLine("insert test id");
        int test_id = int.Parse(Console.ReadLine());
        Console.WriteLine("insert answer id");
        int answer_id = int.Parse(Console.ReadLine());
        Console.WriteLine("insert selected answer id");
        int selected_answer_id = int.Parse(Console.ReadLine());
        AnsToStudent ans = new AnsToStudent(0,student_id,test_id,answer_id,selected_answer_id);
  return ans;
    }


}
