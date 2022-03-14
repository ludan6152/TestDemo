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

        #region 取得項目清單
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

        #region 取得項目資料
        public ItemViewModel Get_Item_Data(string itemid)
        {
            ItemViewModel mRet = new ItemViewModel();

            try
            {
                string sql = $@"
                SELECT ITEM_ID, ITEM_NAME, AMOUNT 
                FROM ITEM_TABLE 
                WHERE ITEM_ID = @ITEM_ID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("ITEM_ID", itemid);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        ItemViewModel Data = new ItemViewModel()
                        {
                            itemid = Convert.ToString(reader["ITEM_ID"]).Trim(),
                            itemname = Convert.ToString(reader["ITEM_NAME"]).Trim(),
                            amount = Convert.ToString(reader["AMOUNT"]).Trim(),
                        };

                        mRet = Data;
                    }
                }
            }
            catch
            {

            }

            return mRet;
        }
        #endregion

        #endregion

        #region 動作

        #region 修改項目
        public string Update_Item(ItemViewModel data)
        {
            string mRet = "";

            try
            {
                string sql = $@"
                UPDATE ITEM_TABLE 
                SET ITEM_NAME = @ITEM_NAME, AMOUNT = @AMOUNT 
                WHERE ITEM_ID = @ITEM_ID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("ITEM_ID", data.itemid);
                    cmd.Parameters.AddWithValue("ITEM_NAME", data.itemname);
                    cmd.Parameters.AddWithValue("AMOUNT", data.amount);

                    cmd.ExecuteNonQuery();

                    mRet = "true";
                }
            }
            catch (Exception ex)
            {
                mRet = ex.Message;
            }

            return mRet;
        }
        #endregion

        #region 刪除項目
        public string Delete_Item(string itemid)
        {
            string mRet = "";

            try
            {
                string sql = $@"
                DELETE FROM ITEM_TABLE 
                WHERE ITEM_ID = @ITEM_ID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("ITEM_ID", itemid);

                    cmd.ExecuteNonQuery();

                    mRet = "true";
                }
            }
            catch (Exception ex)
            {
                mRet = ex.Message;
            }

            return mRet;
        }
        #endregion

        #region 新增項目
        public string Insert_Item(ItemViewModel data)
        {
            string mRet = "";

            try
            {

            }
            catch (Exception ex)
            {
                mRet = ex.Message;
            }

            return mRet;
        }
        #endregion

        #endregion
    }
}