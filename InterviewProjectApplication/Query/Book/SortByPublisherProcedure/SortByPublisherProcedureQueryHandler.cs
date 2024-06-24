using AutoMapper;
using InterviewProjectApplication.Abstractions.Repositories;
using InterviewProjectApplication.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProjectApplication.Query.Book.SortByPublisher
{
    public class SortByPublisherProcedureQueryHandler : IRequestHandler<SortByPublisherProcedureQuery, BaseResponse<List<BookDto>>>
    {

        public IUnitOfWork _uow;
        public IMapper _map;

        //Constructor Injection
        public SortByPublisherProcedureQueryHandler(IUnitOfWork _uow, IMapper _map)
        {
            this._uow = _uow;
            this._map = _map;
        }
        public async Task<BaseResponse<List<BookDto>>> Handle(SortByPublisherProcedureQuery request, CancellationToken cancellationToken)
        {
            //Get  Publisher, Author (last, first), then title By Sorted List

            BaseResponse<List<BookDto>> baseResponse = new ResponseModel.BaseResponse<List<BookDto>>();

            List<BookDto> books = new List<BookDto>();

            try
            {

                string query = "Exec SortByPublisher";

                var sorted = await _uow.GetReposiotory<InterviewProjectDomain.Model.Book>().GetSPResult(query);

                if (sorted == null || sorted.Count() <= 0)
                {
                    baseResponse= new BaseResponse<List<BookDto>>()
                    {
                        Datas = books,
                        Error = "Data is Empty"

                    };
                }       
                else
                {
                    baseResponse = new BaseResponse<List<BookDto>>()
                    {
                        Datas = _map.Map<List<BookDto>>(sorted),
                        Status = "Valid Data "

                    };
                }
                    
            }
            catch (Exception ex)
            {
                baseResponse= new BaseResponse<List<BookDto>>()
                {
                    Datas = books,
                    Error = ex.Message

                };

            }

            return baseResponse;
        }
    }
}
