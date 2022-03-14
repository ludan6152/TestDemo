using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestDemo.Models;
using TestDemo.Services;

namespace TestDemo.Repositories
{
    public class ItemDAO: IItemDAO
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["TestDBContext"].ConnectionString;

        #region 資料

        #region 取得項目清單
        public IEnumerable<ItemModel> Get_Item_List()
        {
            IEnumerable<ItemModel> mRet = Enumerable.Empty<ItemModel>();

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
                    new ItemModel()
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
        public ItemModel Get_Item_Data(string itemid)
        {
            ItemModel mRet = new ItemModel();

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
                        ItemModel Data = new ItemModel()
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
        public bool Update_Item(ItemModel data)
        {
            bool mRet = false;

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

                    mRet = true;
                }
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }

            return mRet;
        }
        #endregion

        #region 刪除項目
        public bool Delete_Item(string itemid)
        {
            bool mRet = false;

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

                    mRet = true;
                }
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }

            return mRet;
        }
        #endregion

        #region 新增項目
        public bool Insert_Item(ItemModel data)
        {
            bool mRet = false;

            try
            {
                string sql = $@"
                INSERT INTO ITEM_TABLE 
                (ITEM_ID, ITEM_NAME, AMOUNT) 
                VALUES 
                (@ITEM_ID, @ITEM_NAME, @AMOUNT)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("ITEM_ID", data.itemid);
                    cmd.Parameters.AddWithValue("ITEM_NAME", data.itemname);
                    cmd.Parameters.AddWithValue("AMOUNT", data.amount);

                    cmd.ExecuteNonQuery();

                    mRet = true;
                }
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }

            return mRet;
        }
        #endregion

        #endregion
    }
}