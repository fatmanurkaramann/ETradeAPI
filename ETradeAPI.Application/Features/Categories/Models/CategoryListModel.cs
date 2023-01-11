using ETradeAPI.Core.Wrappers.Paging;
using ETradeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Categories.Models
{
    public class CategoryListModel : BasePageableModel
    {
        public IList<Category> Items { get; set; }
    }
}
