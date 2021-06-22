using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public class PageResponse<T> : Response<T>
    {
        public PageResponse(T data, int pageNumber, int pageSieze)
        {
            PageNumber = pageNumber;
            PageSieze = pageSieze;
            Data = data;
            Message = null;
            Successful = true;
            Errors = null;
        }

        public int PageNumber { get; set; }
        public int PageSieze { get; set; }


    }
}
