using Dal;
using DalApi;
using DalFacade.DO;
using DalTest;
using DO;
using Tools;
namespace DalTest;

internal partial class Program
{
    private static readonly IDal s_dal = new Dal.DalList();

    public static void Main(string[] args)
    {
        LogManager.GetPathDir();
        try
        {
            // אתחול בסיס הנתונים
            Initialization.Initialize(s_dal);
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("hello and welcome to our platform.\nto student press 1\n" +
                    "to tests press 2\nto question press 3\nto answer press 4\nto answer per student press 5\n" +
                    "to reset logs press 6\nto exit press 0\n\n");

                int key = ReadInt();
                switch (key)
                {
                    case 1:
                        crudMenu(s_dal.Student, "Student", AskStudent); break;
                    case 2:
                        crudMenu(s_dal.Test, "Test", AskTest); break;
                    case 3:
                        crudMenu(s_dal.Question, "Question", AskQuestion); break;
                    case 4:
                        crudMenu(s_dal.Answer, "Answer", AskAnswer); break;
                    case 5:
                        crudMenu(s_dal.AnsToStudent, "AnsToStudent", AskAnsToStudent); break;
                    case 0:
                        exit = true;
                        break;
                    case 6:
                        LogManager.clear();
                        Console.WriteLine("reset logs successed");
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
            LogManager.write("DalTest", "Main", $"Error: {ex.Message}");
        }
    }

    private static void crudMenu<T>(ICrud<T> crud, string entityName, Func<T> askFunc) where T : class
    {
        bool flag = true;
        while (flag)
        {
            Console.WriteLine("\n\npress create, read, readAll, update or delete\n");
            string ans = ReadText();
            try
            {
                switch (ans)
                {
                    case "create":
                        {
                            T obj = askFunc();
                            int newId = crud.Create(obj);
                            Console.WriteLine($"created successed, id: {newId}\n");
                            flag = false;
                        }
                        break;

                    case "update":
                        {
                            T obj = askFunc();
                            crud.Update(obj);
                            Console.WriteLine("update successed\n");
                            flag = false;
                        }
                        break;

                    case "read":
                        {
                            Console.WriteLine("insert id");
                            int id = ReadInt();
                            Console.WriteLine(crud.Read(id));
                            flag = false;
                        }
                        break;

                    case "readAll":
                        {
                            foreach (var item in crud.ReadAll())
                                Console.WriteLine(item);
                            flag = false;
                        }
                        break;

                    case "delete":
                        {
                            Console.WriteLine("insert id");
                            int id = ReadInt();
                            crud.Delete(id);
                            Console.WriteLine("delete successed\n");
                            flag = false;
                        }
                        break;

                    default:
                        Console.WriteLine("no valid input, try again");
                        break;
                }
            }
            catch (Exception ex)
            {
                // כשל בפעולה (למשל מזהה לא קיים) - רושמים ללוג ומאפשרים לבחור פעולה אחרת
                Console.WriteLine($"Error: {ex.Message}");
                LogManager.write("DalTest", "crudMenu", $"Error in {entityName}: {ex.Message}");
            }
        }
    }

    // קורא מספר שלם מהמשתמש, עד שמתקבל קלט תקין
    private static int ReadInt()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int value))
                return value;
            Console.Write("no valid number, try again: ");
        }
    }

    // קורא תאריך מהמשתמש, עד שמתקבל קלט תקין
    private static DateTime ReadDate()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (DateTime.TryParse(input, out DateTime value))
                return value;
            Console.Write("no valid date, try again: ");
        }
    }

    // קורא תוכן enum מהמשתמש, עד שמתקבל קלט תקין
    private static Subject ReadSubject()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            // המרת הקלט הבטוח לתוך ה-enum
            if (Enum.TryParse(input, true, out Subject selectedEntity) && Enum.IsDefined(typeof(Subject), selectedEntity))
                return selectedEntity;
            Console.Write("no valid input, try again: ");
        }
    }

    // קורא טקסט מהמשתמש; מחזיר מחרוזת ריקה אם הקלט חסר
    private static string ReadText()
    {
        return Console.ReadLine() ?? string.Empty;
    }

    private static void PrintSubjects()
    {
        Console.WriteLine("subject: \n");
        foreach (Subject entity in Enum.GetValues(typeof(Subject)))
        {
            Console.WriteLine($"{(int)entity}. {entity}");
        }
        Console.Write("press the num of the subject ");
    }

    //פונקציות הקבלה של הפרטים
    public static Student AskStudent()
    {
        Console.WriteLine("insert id");
        int id = ReadInt();
        Console.WriteLine("insert name");
        string name = ReadText();
        Console.WriteLine("insert test id");
        int test_id = ReadInt();
        Console.WriteLine("insert mark");
        int mark = ReadInt();
        return new Student(id, name, test_id, mark);
    }

    public static Answer AskAnswer()
    {
        Console.WriteLine("insert question id");
        int question_id = ReadInt();
        Console.WriteLine("insert content");
        string content = ReadText();

        return new Answer(0, question_id, content);
    }

    public static Question AskQuestion()
    {
        Console.WriteLine("insert id");
        int id = ReadInt();

        PrintSubjects();
        Subject sub = ReadSubject();

        Console.WriteLine("insert content");
        string content = ReadText();

        Console.WriteLine("insert correct answer id");
        int correct = ReadInt();

        return new Question(id, sub, content, correct);
    }

    public static Test AskTest()
    {
        PrintSubjects();
        Subject sub = ReadSubject();

        Console.WriteLine("insert Date\n");
        DateTime date = ReadDate();

        Console.WriteLine("insert question number\n");
        int quest = ReadInt();

        return new Test(0, sub, date, quest);
    }

    public static AnsToStudent AskAnsToStudent()
    {
        Console.WriteLine("insert student id");
        int student_id = ReadInt();
        Console.WriteLine("insert test id");
        int test_id = ReadInt();
        Console.WriteLine("insert answer id");
        int answer_id = ReadInt();
        Console.WriteLine("insert selected answer id");
        int selected_answer_id = ReadInt();
        return new AnsToStudent(0, student_id, test_id, answer_id, selected_answer_id);
    }
}
