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

        #region 取得項目資料
        ItemViewModel Get_Item_Data(string itemid);
        #endregion

        #region 刪除項目
        string Delete_Item(string itemid);
        #endregion

        #region 新增項目
        string Insert_Item(ItemViewModel data);
        #endregion
    }
}