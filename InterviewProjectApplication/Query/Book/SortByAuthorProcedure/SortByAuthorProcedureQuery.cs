using InterviewProjectApplication.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProjectApplication.Query.Book.SortByPublisher
{
    public class SortByAuthorProcedureQuery : IRequest<BaseResponse<List<BookDto>>>
    {

    }
}
