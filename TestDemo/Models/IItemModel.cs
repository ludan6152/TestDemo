using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestDemo.ViewModels;

namespace TestDemo.Models
{
    public interface IItemModel
    {
        IEnumerable<ItemViewModel> Get_Item_List();
    }
}