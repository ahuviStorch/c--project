
namespace DalFacade.DO
{
    public record AnsToStudent
    (
        int id,
        int StudentId,
        int TestId,
        int AnswerId,
        int SelectedAnswerId
    )
    {
        // Empty constructor (no parameters) - required according to the instructions
        public AnsToStudent() : this(0, 0, 0, 0, 0) { }
    }
}
