using Product.Core.Entities;
using Product.Core.Interface;
using Product.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Repository
{
    public class CategoryRespository : GenericRepository<Category>, IcategoryRespository
    {
        public CategoryRespository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
