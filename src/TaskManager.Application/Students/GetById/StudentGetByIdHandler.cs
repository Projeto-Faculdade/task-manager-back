using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace TaskManager.Application.Students.GetById
{
    public class StudentGetByIdHandler : IRequestHandler<StudentGetByIdRequest>
    {
         public Task Handle(StudentGetByIdRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }        
    }
}