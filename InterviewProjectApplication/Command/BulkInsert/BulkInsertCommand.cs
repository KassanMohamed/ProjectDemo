using InterviewProjectApplication.Request;
using InterviewProjectApplication.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProjectApplication.Command.BulkInsert
{
    public class BulkInsertCommand:IRequest<string>
    {
        public List<BookRequestModel> BookDtos { get; set; }
    }
}
