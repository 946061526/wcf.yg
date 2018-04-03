using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 获取云购结果的信息13304
        /// <summary>
        /// 获取云购结果的信息13304
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="shopID">购物车ID</param>
        /// <param name="state">返回状态</param>
        /// <returns></returns>
        public static DataSet GetUserShopInfo(out int state, params object[] para)
        {
            int userID = (int)para[0];
            long shopID = (long)para[1];
            DataSet _DS = null;
            state = -1;
            if (userID > 0 && shopID > 0L)
            {
                try
                {
                    IDALUsers _DALUsers = new DALUsers();
                    _DS = _DALUsers.GetUserShopInfo(userID, shopID, out state);
                    _DALUsers = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Users.GetUserShopInfo抛出异常：" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
    }
}
