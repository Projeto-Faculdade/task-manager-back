using TaskManager.Application.Students.GetById;

namespace TaskManager.Application.Students.GetAll;

public class StudentGetAllResponse : List<StudentGetByIdResponse>
{
    public StudentGetAllResponse()
    {
    }

    public StudentGetAllResponse(IEnumerable<StudentGetByIdResponse> collection) : base(collection)
    {
    }
}