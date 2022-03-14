using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestDemo.Models;

namespace TestDemo.Repositories
{
    public interface IItemDAO
    {
        #region 取得項目清單
        IEnumerable<ItemModel> Get_Item_List();
        #endregion

        #region 修改項目
        bool Update_Item(ItemModel data);
        #endregion

        #region 取得項目資料
        ItemModel Get_Item_Data(string itemid);
        #endregion

        #region 刪除項目
        bool Delete_Item(string itemid);
        #endregion

        #region 新增項目
        bool Insert_Item(ItemModel data);
        #endregion
    }
}