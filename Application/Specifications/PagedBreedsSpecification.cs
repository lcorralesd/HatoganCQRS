using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Specifications
{
    public class PagedBreedsSpecification : Specification<Breed>
    {
        public PagedBreedsSpecification(int pageNumber, int pageSize, string name)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            if(!string.IsNullOrEmpty(name))
            {
                Query.Search(x => x.Name, "%" + name + "%");
            }
        }
    }
}
