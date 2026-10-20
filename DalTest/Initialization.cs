namespace DalTest;

using DalApi;
using DalFacade.DO;
using DO;

public static class Initialization
{
    private static IDal? s_dal;

    private static void CreateStudents()
    {
        s_dal!.Student.Create(new Student(123456789, "ישראל ישראלי", 101, 85));
        s_dal.Student.Create(new Student(234567890, "משה כהן", 101, 90));
        s_dal.Student.Create(new Student(345678901, "דוד לוי", 102, 78));
        s_dal.Student.Create(new Student(456789012, "אברהם אברהמי", 102, 95));
        s_dal.Student.Create(new Student(567890123, "יעקב יעקבי", 103, 88));
    }

    private static void CreateTest()
    {
        s_dal!.Test.Create(new Test(0, Subject.Math, DateTime.Now.AddDays(7), 5));
        s_dal.Test.Create(new Test(0, Subject.Science, DateTime.Now.AddDays(14), 5));
        s_dal.Test.Create(new Test(0, Subject.English, DateTime.Now.AddDays(21), 5));
        s_dal.Test.Create(new Test(0, Subject.Math, DateTime.Now.AddDays(28), 5));
        s_dal.Test.Create(new Test(0, Subject.Science, DateTime.Now.AddDays(35), 5));
    }

    private static void CreateQuestions()
    {
        // מתמטיקה
        s_dal!.Question.Create(new Question(0, Subject.Math, "כמה זה 2 + 2?", 1));
        s_dal.Question.Create(new Question(0, Subject.Math, "כמה זה 100 לחלק ל-4?", 7));
        s_dal.Question.Create(new Question(0, Subject.Math, "מה נגזרת של X^2?", 2));

        // מדעים
        s_dal.Question.Create(new Question(0, Subject.Science, "מה נקודת הקיפאון של המים במעלות צלזיוס?", 8));
        s_dal.Question.Create(new Question(0, Subject.Science, "מהו הסימון הכימי של מים?", 9));
    }

    private static void CreateAnswers()
    {
        // תשובות לשאלה הראשונה (מזהה שאלה 1000 - "כמה זה 2 + 2?")
        s_dal!.Answer.Create(new Answer(0, 1000, "4"));
        s_dal.Answer.Create(new Answer(0, 1000, "3"));
        s_dal.Answer.Create(new Answer(0, 1000, "5"));
        s_dal.Answer.Create(new Answer(0, 1000, "22"));

        // תשובות לשאלה 1001 ("מה נגזרת של X^2?")
        s_dal.Answer.Create(new Answer(0, 1001, "2x"));
        s_dal.Answer.Create(new Answer(0, 1001, "x"));
        s_dal.Answer.Create(new Answer(0, 1001, "x^2"));
        s_dal.Answer.Create(new Answer(0, 1001, "2"));

        // תשובות לשאלה 1006 ("כמה זה 100 לחלק ל-4?")
        s_dal.Answer.Create(new Answer(0, 1006, "25"));
        s_dal.Answer.Create(new Answer(0, 1006, "100"));
        s_dal.Answer.Create(new Answer(0, 1006, "1"));
        s_dal.Answer.Create(new Answer(0, 1006, "22"));

        // תשובות לשאלה 1007 ("מה נקודת הקיפאון של המים?")
        s_dal.Answer.Create(new Answer(0, 1007, "0"));
        s_dal.Answer.Create(new Answer(0, 1007, "100"));
        s_dal.Answer.Create(new Answer(0, 1007, "-10"));
        s_dal.Answer.Create(new Answer(0, 1007, "25"));

        // תשובות לשאלה 1008 ("מהו הסימון הכימי של מים?")
        s_dal.Answer.Create(new Answer(0, 1008, "H2O"));
        s_dal.Answer.Create(new Answer(0, 1008, "CO2"));
        s_dal.Answer.Create(new Answer(0, 1008, "O2"));
        s_dal.Answer.Create(new Answer(0, 1008, "NaCl"));
    }

    private static void CreateStudentQuestions()
    {
        // התשובות שנבחרו ע"י תלמידים במבחנים שונים
        s_dal!.AnsToStudent.Create(new AnsToStudent(0, 123456789, 100, 1000, 1));
        s_dal.AnsToStudent.Create(new AnsToStudent(1, 123456789, 100, 1001, 5));
        s_dal.AnsToStudent.Create(new AnsToStudent(2, 234567890, 100, 1000, 1));
        s_dal.AnsToStudent.Create(new AnsToStudent(3, 345678901, 101, 1007, 9));
        s_dal.AnsToStudent.Create(new AnsToStudent(4, 456789012, 101, 1007, 9));
    }

    public static void Initialize(IDal dal)
    {
        s_dal = dal ?? throw new ArgumentNullException(nameof(dal));

        CreateStudents();
        CreateTest();
        CreateQuestions();
        CreateAnswers();
        CreateStudentQuestions();
    }
}