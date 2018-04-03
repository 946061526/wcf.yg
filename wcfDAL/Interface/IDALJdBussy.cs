using System;
using System.Data;

namespace wcfNSYGShop
{
    public interface IDALJdBussy : IDisposable
    {
        #region 获取京东账号信息
        /// <summary>
        /// 获取京东账号信息
        /// </summary>
        /// <param name="yunUser">云购账号</param>
        /// <returns></returns>
        DataSet GetJdTokenByUser( string yunUser );
        #endregion
        #region 分布获取修改京东下单明细14314
        /// <summary>
        /// 分布获取修改京东下单明细14314
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        DataSet GetJdOrderDetailByONO( int orderNO );
        #endregion
    }
}
