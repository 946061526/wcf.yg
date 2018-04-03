using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class WCFServiceFun
    {
        #region 获取订单信息
        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public DataSet GetOrderInfoByNO( int orderNO )
        {
            DataSet _DS = null;
            if ( orderNO > 0 )
            {
                try
                {
                    IDALOrders _DAL = new DALOrders();
                    _DS = _DAL.GetOrderInfoByNO( orderNO );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Orders.GetOrderInfoByNO抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 获取非删除状态的订单处理步骤
        /// <summary>
        /// 获取非删除状态的订单处理步骤
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public DataSet GetOrderDoStepListByNO( int orderNO )
        {
            DataSet _DS = null;
            if ( orderNO > 0 )
            {
                try
                {
                    IDALOrders _DAL = new DALOrders();
                    _DS = _DAL.GetOrderDoStepListByNO( orderNO );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Orders.GetOrderDoStepListByNO抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 启用事务更新订单配送信息--状态置为2
        /// <summary>
        /// 启用事务
        /// 更新订单配送信息、添加订单处理步骤、添加订单日志
        /// </summary>
        /// <param name="orderNo">订单编号</param>
        /// <param name="userName">收货人姓名</param>
        /// <param name="tel">联系电话</param>
        /// <param name="mobile">手机号</param>
        /// <param name="areaID">所在区ID</param>
        /// <param name="areaID">所在街道ID</param>
        /// <param name="address">收货地址</param>
        /// <param name="zip">邮编</param>
        /// <param name="shipTime">送货时间</param>
        /// <param name="shipRemark">备注</param>
        /// <param name="invoiceT">发票抬头</param>
        /// <param name="invoiceC">发票条目</param>
        /// <param name="loginUserName">登录者姓名</param>
        /// <returns></returns>
        public bool UpdateOrderShipInfoTran( int orderNo, string userName, string tel, string mobile, int areaID, int streetID, string address, string zip, string shipTime, string shipRemark, string invoiceT, string invoiceC, string loginUserName )
        {
            bool _Result = false;
            if ( orderNo > 0 )
            {
                try
                {
                    IDALOrders _DAL = new DALOrders();
                    _Result = _DAL.UpdateOrderShipInfoTran( orderNo, userName, tel, mobile, areaID, streetID, address, zip, shipTime, shipRemark, invoiceT, invoiceC, "", "", 0, loginUserName, 0 ) > 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Orders.UpdateOrderShipInfoTran抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion

        #region 启用事务更新订单完成状态及备注信息--状态置为10
        /// <summary>
        /// 启用事务
        /// 更新订单完成状态及备注信息、添加订单处理步骤、添加订单日志
        /// </summary>
        /// <param name="orderNo">订单编号</param>
        /// <param name="orderRemark">订单备注</param>
        /// <param name="logDescription">配送评价</param>
        /// <param name="loginUserName">登录者姓名</param>
        /// <returns></returns>
        public bool UpdateOrderForEndTran( int orderNo, string orderRemark, string logDescription, string loginUserName )
        {
            bool _Result = false;
            if ( orderNo > 0 )
            {
                try
                {
                    IDALOrders _DAL = new DALOrders();
                    _Result = _DAL.UpdateOrderForEndTran( orderNo, orderRemark, logDescription, loginUserName ) > 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Orders.UpdateOrderForEndTran抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion

        #region 获取订单配送信息列表
        /// <summary>
        /// 获取订单配送信息列表
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public DataSet GetOrderDeliveryListByNO( int orderNO )
        {
            DataSet _DS = null;
            if ( orderNO > 0 )
            {
                try
                {
                    IDALOrders _DAL = new DALOrders();
                    _DS = _DAL.GetOrderDeliveryListByNO( orderNO );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Orders.UpdateOrderForEndTran抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 更新订单状态及备注信息
        /// <summary>
        /// 更新订单状态及备注信息
        /// </summary>
        /// <param name="orderNO"></param>
        /// <param name="orderRemark"></param>
        /// <param name="orderState"></param>
        /// <param name="orderUpdateTime"></param>
        /// <returns></returns>
        public bool UpdateOrders( int orderNO, string orderRemark, int orderState, DateTime orderUpdateTime )
        {
            bool _Result = false;
            if ( orderNO > 0 )
            {
                try
                {
                    IDALOrders _DAL = new DALOrders();
                    _Result = _DAL.UpdateOrders( orderNO, orderRemark, orderState, orderUpdateTime ) > 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Orders.UpdateOrders抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion

        #region 更新订单配送信息
        /// <summary>
        /// 更新订单配送信息
        /// </summary>
        /// <param name="model">订单实例</param>
        /// <returns></returns>
        public bool UpdateOrderShipInfo( int orderNO, string buyer, string tel, string mobile, int areaID, int streetID, string address,
            string zip, DateTime shipTime, string remark, string invoiceT, string invoiceC, int dyTypeID )
        {
            bool _Flag = false;
            try
            {
                IDALOrders _DAL = new DALOrders();
                _Flag = _DAL.UpdateOrderShipInfo( orderNO, buyer, tel, mobile, areaID, streetID, address, zip,
                    shipTime, remark, invoiceT, invoiceC, dyTypeID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Orders.UpdateOrderShipInfo抛出异常：" + ex.Message );
            }
            return _Flag;
        }
        #endregion

        #region 返回揭晓结果
        /// <summary>
        /// 返回揭晓结果
        /// </summary>
        /// <param name="codeID">条码</param>
        /// <param name="rnoNum">幸运云购码</param>
        /// <param name="rTime">揭晓时间</param>
        /// <param name="rCheckSum">揭晓的基数</param>
        /// <returns></returns>
        public DataSet GetStartRaffleResult( int codeID, int rnoNum, DateTime rTime, long rCheckSum )
        {
            DataSet _DS = null;
            if ( codeID > 0 )
            {
                try
                {
                    IDALOrders _DAL = new DALOrders();
                    _DS = _DAL.GetStartRaffleResult( codeID, rnoNum, rTime, rCheckSum );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Orders.GetStartRaffleResult Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 根据订单号获取订单信息用于打印
        /// <summary>
        /// 根据订单号获取订单信息用于打印
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public DataSet GetOrdersInfoForPrint( int orderNO )
        {
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

        #region 会员中心-获取会员活动订单
        /// <summary>
        /// 会员中心-获取会员活动订单
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="beginTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="FIdx">起始索引</param>
        /// <param name="EIdx">结束索引</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总数</param>
        /// <returns></returns>
        public DataSet GetActOrderByUserid( int userID, DateTime beginTime, DateTime endTime, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALOrders _DAL = new DALOrders();
                _DS = _DAL.GetActOrderByUserid( userID, beginTime, endTime, FIdx, EIdx, isCount, out totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Orders.GetActOrderByUserid Ex:" + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region 会员中心-获取会员活动订单详情
        /// <summary>
        /// 会员中心-获取会员活动订单详情
        /// </summary>
        /// <param name="orderNO">活动订单号</param>
        /// <returns></returns>
        public DataSet GetActOrdersInfoByOrderNO( int orderNO )
        {
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

        #region 根据订单号查询换货订单详细信息
        /// <summary>
        /// 根据订单号查询换货订单详细信息
        /// </summary>
        /// <param name="orderNO"></param>
        /// <returns></returns>
        public DataSet GetOrderInfoByOrderNO( int orderNO )
        {
            DataSet _DS = null;
            try
            {
                IDALOrders _DAL = new DALOrders();
                _DS = _DAL.GetOrderInfoByOrderNO( orderNO );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Orders.GetOrderInfoByOrderNO Ex:" + ex.Message );
            }
            return _DS;
        }
        #endregion

    }
}
