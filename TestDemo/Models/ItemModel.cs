using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestDemo.ViewModels;

namespace TestDemo.Models
{
    public class ItemModel: IItemModel
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["TestDBContext"].ConnectionString;

        #region 資料

        public IEnumerable<ItemViewModel> Get_Item_List()
        {
            IEnumerable<ItemViewModel> mRet = Enumerable.Empty<ItemViewModel>();

            try
            {
                string sql = $@"
                SELECT ITEM_ID, ITEM_NAME, AMOUNT 
                FROM ITEM_TABLE";

                using (DataTable dt = new DataTable())
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }

                    var query = dt.AsEnumerable().Select(t =>
                    new ItemViewModel()
                    {
                        itemid = Convert.ToString(t["ITEM_ID"]).ToString(),
                        itemname = Convert.ToString(t["ITEM_NAME"]).ToString(),
                        amount = Convert.ToString(t["AMOUNT"]).ToString(),
                    });

                    mRet = query;
                }
            }
            catch
            {

            }

            return mRet;
        }

        #endregion

        #region 動作



        #endregion
    }
}