

namespace DalFacade.DO
{
    public record Student
    (
        int Id,
        string Name,
        int Test_Id,
        int Mark
    )
    {
        // Empty constructor (no parameters) - required according to the instructions
        public Student() : this(0, string.Empty, 0, 0) { }

    }
}
