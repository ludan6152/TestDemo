using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestDemo.Models;
using TestDemo.Repositories;

namespace TestDemo.Services
{
    public class ItemService: IItemService
    {
        private readonly IItemDAO _itemDAO;

        public ItemService(IItemDAO itemDAO)
        {
            _itemDAO = itemDAO;
        }

        #region 資料

        #region 取得項目清單
        public IEnumerable<ItemModel> Get_Item_List()
        {
            return _itemDAO.Get_Item_List();
        }
        #endregion

        #region 取得項目資料
        public ItemModel Get_Item_Data(string itemid)
        {
            return _itemDAO.Get_Item_Data(itemid);
        }
        #endregion

        #endregion

        #region 動作

        #region 修改項目
        public bool Update_Item(ItemModel data)
        {
            return _itemDAO.Update_Item(data);
        }
        #endregion

        #region 刪除項目
        public bool Delete_Item(string itemid)
        {
            return _itemDAO.Delete_Item(itemid);
        }
        #endregion

        #region 新增項目
        public string Insert_Item(ItemModel data)
        {
            if (String.IsNullOrEmpty(_itemDAO.Get_Item_Data(data.itemid).itemid))
            {
                if (_itemDAO.Insert_Item(data))
                {
                    return "true";
                }
            }
            else
            {
                return "項目編號" + data.itemid + "已存在！";
            }

            return "";
        }
        #endregion

        #endregion
    }
}