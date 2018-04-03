using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 根据购物车ID查询交易记录13207
        /// <summary>
        /// 根据购物车ID查询交易记录13207
        /// </summary>
        /// <param name="cartID">购物车ID</param>
        /// <param name="isSingle">是否只获取一条记录</param>
        /// <returns></returns>
        public static DataSet GetPaymentRecordList(params object[] para)
        {
            long cartID = (long)para[0];
            bool isSingle = (bool)para[1];
            DataSet _DS = null;
            if (cartID > 0L)
            {
                try
                {
                    IDALUsers _DALUsers = new DALUsers();
                    _DS = _DALUsers.GetPaymentRecordList(cartID, isSingle);
                    _DALUsers = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Users.GetPaymentRecordList抛出异常：" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
    }
}
