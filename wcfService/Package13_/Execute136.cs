using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 根据订单号获取订单信息用于打印13603
        /// <summary>
        /// 根据订单号获取订单信息用于打印13603
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public static DataSet GetOrdersInfoForPrint( params object[] para )
        {
            int orderNO = (int)para[0];
            DataSet _DS = null;
            if ( orderNO > 0 )
            {
                try
                {
                    IDALOrders _DAL = new DALOrders();
                    _DS = _DAL.GetOrdersInfoForPrint( orderNO );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Orders.GetOrdersInfoForPrint Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
        #region 会员中心-获取会员活动订单详情13609
        /// <summary>
        /// 会员中心-获取会员活动订单详情13609
        /// </summary>
        /// <param name="orderNO">活动订单号</param>
        /// <returns></returns>
        public static DataSet GetActOrdersInfoByOrderNO( params object[] para )
        {
            int orderNO = (int)para[0];
            DataSet _DS = null;
            try
            {
                IDALOrders _DAL = new DALOrders();
                _DS = _DAL.GetActOrdersInfoByOrderNO( orderNO );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Orders.GetActOrdersInfoByOrderNO Ex:" + ex.Message );
            }
            return _DS;
        }
        #endregion
    }
}
