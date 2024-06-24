using InterviewProjectApplication.Command.BulkInsert;
using InterviewProjectApplication.Query.Book.SortByPublisher;
using InterviewProjectApplication.Query.Book.SumPrice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : BaseController
    {
        [HttpGet("SortByPublisher")]
        public async Task<IActionResult> SortByPublisher()  
         => Ok(await Mediator.Send(new SortByPublisherProcedureQuery() { }));

        [HttpGet("SortByPublisher/Procedure")]
        public async Task<IActionResult> SortByPublisherProcedure()
         => Ok(await Mediator.Send(new SortByPublisherProcedureQuery() { }));


        [HttpGet("SortByAuthor")]
        public async Task<IActionResult> SortByAuthor()
         => Ok(await Mediator.Send(new SortByAuthorQuery() { }));

        [HttpGet("SortByAuthor/Procedure")]
        public async Task<IActionResult> SortByAuthorProcedure()
        => Ok(await Mediator.Send(new SortByAuthorProcedureQuery() { }));

        [HttpGet("Total/Price")]
        public async Task<IActionResult> SumPrice()
         => Ok(await Mediator.Send(new SumPriceQuery() { }));


        [HttpPost("BulkInsert")]
        public async Task<IActionResult> BulkInsert(BulkInsertCommand request)
        => Ok(await Mediator.Send(request));
    }
}
