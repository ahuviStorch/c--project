namespace DO;

public record Question(int Id, Subject Sub, string content, int correcctAns)
{
=    public Question() : this(0, Subject.Math,"", 0) { }
}