using AutoMapper;
using InterviewProjectApplication.Abstractions.Repositories;
using InterviewProjectApplication.Request;
using InterviewProjectDomain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProjectApplication.Command.BulkInsert
{
    public class BulkInsertCommandHandler : IRequestHandler<BulkInsertCommand, string>
    {
        public IUnitOfWork _uow;
        public IMapper _map;


        //Constructor Injection
        public BulkInsertCommandHandler(IUnitOfWork _uow, IMapper _map)
        {
            this._uow = _uow;
            this._map = _map;
        }

        public async Task<string> Handle(BulkInsertCommand request, CancellationToken cancellationToken)
        {
            //Initial Validation 
            try
            {
                if (request.BookDtos == null || request.BookDtos.Count <= 0)
                    return "Please provide a atleast one book";
               
               var books = await GetExistCheck(request.BookDtos);

                if (books == null || books.Count <= 0)
                    return "No New Mapping Data";

                books.ForEach(x => x.CreatedOn = DateTime.Now);

                await _uow.GetReposiotory<Book>().BulkInsertAsync(books);
                await _uow.CompleteAsync();



            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Bulk Insert SuccessFully";

        }

        private async Task<List<Book>> GetExistCheck(List<BookRequestModel> bookDtos)
        {
            List<Book> books = new List<Book>();
            foreach (var bookDto in bookDtos)
            {
                try
                {
                    var exist = await _uow.GetReposiotory<Book>().GetByAsync(x=>x.Title.ToLower().Trim()== bookDto.Title.ToLower().Trim());
                    if (exist == null)
                        books.Add(_map.Map<Book>(bookDto));
                    else
                        continue;
                }
                catch(Exception ex)
                {
                    continue;
                }
            }

            return books;



        }
    }
}
