
using DalFacade.DO;
using DO;
using Tools;

namespace Dal;

internal static class DataSource
{
    internal static List<Answer?> Answers { get; } = new List<Answer?>();
    internal static List<Student?> Students { get; } = new List<Student?>();
    internal static List<AnsToStudent?> AnsToStudents { get; } = new List<AnsToStudent?>();
    internal static List<Question?> Questions { get; } = new List<Question?>();
    internal static List<Test?> Tests { get; } = new List<Test?>();

    internal static class Config
    {
        //question
        internal const int QuestionInit = 1000;
        private static int Question_i = QuestionInit;
        public static int NextQuestionId => Question_i++;
        //answer
        internal const int AnswerInit = 1000;
        private static int Answer_i = AnswerInit;
        public static int NextAnswerId => Answer_i++;
        //Test
        internal const int TestInit = 1000;
        private static int Test_i = TestInit;
        public static int NextTestId => Test_i++;
        public static int TestAnswerId => Test_i++;
        //Student
        internal const int StudentInit = 1000;
        private static int Student_i = StudentInit;
        public static int NextStudentId => Student_i++;
        //AnsToStudent
        internal const int AnsToStudentInit = 1000;
        private static int AnsToStudent_i = AnsToStudentInit;
        public static int NextAnsToStudentId => AnsToStudent_i++;
    }


}

