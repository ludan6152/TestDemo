using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDemo.Models;

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

        #endregion
    }
}