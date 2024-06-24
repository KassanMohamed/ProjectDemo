using InterviewProjectApplication.Abstractions.Repositories;
using InterviewProjectApplication.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProjectApplication.Query.Book.SumPrice
{
    public class SumPriceQueryHandler : IRequestHandler<SumPriceQuery, SumPriceDto>
    {
        public IUnitOfWork _uow;

        //Constructor Injection
        public SumPriceQueryHandler(IUnitOfWork _uow)
        {
            this._uow = _uow;
        }
        public async Task<SumPriceDto> Handle(SumPriceQuery request, CancellationToken cancellationToken)
        {
            try
            {

                //Get the All Book Data Then Sum the Total Price

                var totalprice = _uow.GetReposiotory<InterviewProjectDomain.Model.Book>().GetListAsync().Result.Sum(x => x.Price);
                if (totalprice == null || totalprice.Value<=0)
                    return new SumPriceDto() { Error = "Price is Empty" ,TotalPrice=null };
                else
                    return new SumPriceDto() { Error = null, TotalPrice = totalprice };
            }
            catch(Exception ex)
            {
                return new SumPriceDto() { Error = ex.Message, TotalPrice = null };
            }
        }
    }
}
