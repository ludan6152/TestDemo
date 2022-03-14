using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDemo.Models;
using TestDemo.ViewModels;

namespace TestDemo.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemModel _itemModel;

        public ItemController(IItemModel itemModel)
        {
            this._itemModel = itemModel;
        }

        #region 畫面

        #region 主頁
        public ActionResult Item_Index()
        {
            return View();
        }
        #endregion

        #endregion

        #region 資料

        #region 取得項目清單
        public JsonResult Get_Item_List()
        {
            var List = _itemModel.Get_Item_List();

            return Json(new { List }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 取得項目資料
        public JsonResult Get_Item_Data(string itemid)
        {
            var Data = _itemModel.Get_Item_Data(itemid);

            return Json(new { Data }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #endregion

        #region 動作

        #region 修改項目
        public string Update_Item(ItemViewModel data)
        {
            string result = _itemModel.Update_Item(data);

            return result;
        }
        #endregion

        #region 刪除項目
        public string Delete_Item(string itemid)
        {
            string result = _itemModel.Delete_Item(itemid);

            return result;
        }
        #endregion

        #endregion
    }
}