using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDemo.Models;
using TestDemo.Repositories;
using TestDemo.Services;

namespace TestDemo.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
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
            var List = _itemService.Get_Item_List();

            return Json(new { List }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 取得項目資料
        public JsonResult Get_Item_Data(string itemid)
        {
            var Data = _itemService.Get_Item_Data(itemid);

            return Json(new { Data }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #endregion

        #region 動作

        #region 修改項目
        public bool Update_Item(ItemModel data)
        {
            return _itemService.Update_Item(data);
        }
        #endregion

        #region 刪除項目
        public bool Delete_Item(string itemid)
        {
            return _itemService.Delete_Item(itemid);
        }
        #endregion

        #region 新增項目
        public string Insert_Item(ItemModel data)
        {
            return _itemService.Insert_Item(data);
        }
        #endregion

        #endregion
    }
}