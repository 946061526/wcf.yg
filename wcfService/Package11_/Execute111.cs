using System;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 添加订单的快递信息11124
        /// <summary>
        /// 添加订单的快递信息
        /// </summary>
        /// <param name="packageNO">包裹号</param>
        /// <param name="city">寄往城市</param>
        /// <param name="shipNO">快递单号</param>
        /// <param name="shipDesc">快递信息描述</param>
        /// <param name="acceptTime">快递商家操作时间</param>
        /// <param name="remark">快递商家备注</param>
        /// <param name="dyTypeID">快递商ID</param>
        /// <param name="dyCheck"></param>
        /// <returns>成功返回1，失败为0</returns>
        public static int AddOrderShipLog( params object[] para )
        {
            int _Result = 0;
            try
            {
                long packageNO = (long)para[0];
                string city = (string)para[1];
                string shipNO = (string)para[2];
                string shipDesc = (string)para[3];
                DateTime acceptTime = (DateTime)para[4];
                string remark = (string)para[5];
                int dyTypeID = (int)para[6];
                int dyCheck = (int)para[7];
                IDALOrders _DAL = new DALOrders();
                _Result = _DAL.AddOrderShipLog( packageNO, city, shipNO, shipDesc, acceptTime, remark, dyTypeID, dyCheck );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Orders.AddOrderShipLog Ex:" + ex.Message );
            }
            return _Result;
        }
        #endregion
    }
}
