using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class ExecuteFun
    {
        #region 出库回扫单－根据快递单号更新状态11284
        /// <summary>
        /// <param name="shipNO">快递单号</param>
        /// <param name="dyTypeID">快递商编号</param>
        /// <param name="shipState"></param>
        /// <returns></returns>
        public static int UpdateShipStateByShipNO( params object[] para )
        {
            int _Result = 0;
            try
            {
                string shipNO = (string)para[0];
                int dyTypeID = (int)para[1];
                int shipState = (int)para[2];
                IDALOrders _DAL = new DALOrders();
                _Result = _DAL.UpdateShipStateByShipNO( shipNO, dyTypeID, shipState );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Orders.UpdateShipStateByShipNO Ex:" + ex.Message );
            }
            return _Result;
        }
        #endregion
    }
}
