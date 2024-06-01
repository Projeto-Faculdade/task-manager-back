using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace TaskManager.Application.Students.GetAll
{
    public class StudentGetAllHandler : IRequestHandler<StudentGetAllRequest>
    {
         public Task Handle(StudentGetAllRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}