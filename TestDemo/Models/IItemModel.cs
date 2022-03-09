using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestDemo.ViewModels;

namespace TestDemo.Models
{
    public interface IItemModel
    {
        #region 取得項目清單
        IEnumerable<ItemViewModel> Get_Item_List();
        #endregion

        #region 修改項目
        string Update_Item(ItemViewModel data);
        #endregion
    }
}