using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace TaskManager.Application.Students.Delete
{
    internal class StudentDeleteHandler : IRequestHandler<StudentDeleteRequest>
    {
        public Task Handle(StudentDeleteRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}