namespace DO;

public record Test(int Id, Subject Sub, DateTime Date, int QuestNum)
{
    public Test() : this(0, Subject.Math, DateTime.Now, 0) { }
}