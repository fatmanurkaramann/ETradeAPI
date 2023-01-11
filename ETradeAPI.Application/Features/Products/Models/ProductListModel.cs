using ETradeAPI.Core.Wrappers.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Products.Models
{
    public class ProductListModel : BasePageableModel
    {
        public IList<ViewProductModel> Items { get; set; }
    }
}
