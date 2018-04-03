using System;
using System.Data;

namespace wcfNSYGShop
{
    public class DALOrders : DALBase, IDALOrders
    {
        #region 获取订单信息
        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public DataSet GetOrderInfoByNO( int orderNO )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12010" );
            Para.AddOrcNewInParameter( "i_Orderno", orderNO );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_Order.sp_getOrderInfoByOrderno" );//pro_OrdersGetInfoByNO
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12006" );
            Para.AddOrcNewInParameter( "i_Orderno", orderNO );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_Order.sp_getNoDelOrderStepByOrderno" );//pro_OrderDoStepGetListByNO
        }
        #endregion

        #region 更新订单配送信息--状态置为2
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
        /// <param name="isCommit">是否由程序提交：0否，1是</param>
        /// <returns></returns>
        public int UpdateOrderShipInfoTran( int orderNo, string userName, string tel, string mobile, int areaID, int streetID, string address, string zip, string shipTime, string shipRemark, string invoiceT, string invoiceC, string orderSpec, string deltaNumber, int isNoDelivery, string loginUserName, int isCommit )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12014" );
            Para.AddOrcNewInParameter( "i_orderNO", orderNo );
            Para.AddOrcNewInParameter( "i_orderBuyer", userName );
            Para.AddOrcNewInParameter( "i_orderTel", tel );
            Para.AddOrcNewInParameter( "i_orderMobile", mobile );
            Para.AddOrcNewInParameter( "i_orderAreaID", areaID );
            Para.AddOrcNewInParameter( "i_orderStreetID", streetID );
            Para.AddOrcNewInParameter( "i_orderAddress", address );
            Para.AddOrcNewInParameter( "i_orderZip", zip );
            Para.AddOrcNewInParameter( "i_orderShipTime", shipTime );
            Para.AddOrcNewInParameter( "i_orderShipRemark", shipRemark );
            Para.AddOrcNewInParameter( "i_orderInvoiceT", invoiceT );
            Para.AddOrcNewInParameter( "i_orderInvoiceC", invoiceC );

            Para.AddOrcNewInParameter( "i_orderSpec", orderSpec );
            Para.AddOrcNewInParameter( "i_deltaNumber", deltaNumber );
            Para.AddOrcNewInParameter( "i_DontDelivery", isNoDelivery );

            Para.AddOrcNewInParameter( "i_loginUserName", loginUserName );
            Para.AddOrcNewInParameter( "i_isCommit", isCommit );
            Dal.ExecuteNonQuery( "yun_Order.f_modOrderDisStepByOrderNO" );//pro_OrdersUpdateStateShip
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;//成功返回影响行数，失败返回-1
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
        public int UpdateOrderForEndTran( int orderNo, string orderRemark, string logDescription, string loginUserName )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12013" );
            Para.AddOrcNewInParameter( "i_orderNO", orderNo );
            Para.AddOrcNewInParameter( "i_orderRemark", orderRemark );
            Para.AddOrcNewInParameter( "i_logDescription", logDescription );
            Para.AddOrcNewInParameter( "i_loginUserName", loginUserName );
            Dal.ExecuteNonQuery( "yun_Order.f_modOrderStepLogByOrderNO" );//pro_OrdersUpdateStateEnd
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12003" );
            Para.AddOrcNewInParameter( "i_Orderno", orderNO );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_Order.sp_getOrderDispatchByOrderno" );//pro_OrderDeliveryListByNO
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
        public int UpdateOrders( int orderNO, string orderRemark, int orderState, DateTime orderUpdateTime )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12011" );
            Para.AddOrcNewInParameter( "i_orderNO", orderNO );
            Para.AddOrcNewInParameter( "i_orderRemark", orderRemark );
            Para.AddOrcNewInParameter( "i_orderState", orderState );
            Para.AddOrcNewInParameter( "i_orderUpdateTime", orderUpdateTime );
            Dal.ExecuteNonQuery( "yun_Order.f_modOrderStateByOrderNO" );//pro_OrdersUpdate
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal; //>0 影响行数
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
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12012" );
            Para.AddOrcNewInParameter( "i_orderNO", orderNO );
            Para.AddOrcNewInParameter( "i_orderBuyer", buyer );
            Para.AddOrcNewInParameter( "i_orderTel", tel );
            Para.AddOrcNewInParameter( "i_orderMobile", mobile );
            Para.AddOrcNewInParameter( "i_orderAreaID", areaID );
            Para.AddOrcNewInParameter( "i_orderStreetID", streetID );
            Para.AddOrcNewInParameter( "i_orderAddress", address );
            Para.AddOrcNewInParameter( "i_orderZip", zip );
            Para.AddOrcNewInParameter( "i_orderShipTime", shipTime );
            Para.AddOrcNewInParameter( "i_orderShipRemark", remark );
            Para.AddOrcNewInParameter( "i_orderInvoiceT", invoiceT );
            Para.AddOrcNewInParameter( "i_orderInvoiceC", invoiceC );
            Para.AddOrcNewInParameter( "i_orderDyTypeID", dyTypeID );
            Dal.ExecuteNonQuery( "yun_Order.f_modOrderDispatchByOrderNO" );//pro_OrdersUpdateShipInfo
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal > 0; //>0 影响行数
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12605" );
            Para.AddOrcNewInParameter( "i_codeID", codeID );
            Para.AddOrcNewInParameter( "i_rnonum", rnoNum );
            Para.AddOrcNewInParameter( "i_rtime", rTime );
            Para.AddOrcNewInParameter( "i_rcheckSum", rCheckSum );
            Para.AddOrcNewCursorParameter( "o_result1" );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_RaffleForAny.sp_getLotteryByCodeID" );//pro_StartRaffle
        }
        #endregion

        #region 计算条码的揭晓结果
        /// <summary>
        /// 计算条码的揭晓结果
        /// </summary>
        /// <param name="codeID">条码</param>
        /// <param name="rnoNum">幸运云购码</param>
        /// <param name="rTime">揭晓时间</param>
        /// <param name="rCheckSum">揭晓的基数</param>
        /// <returns></returns>
        public DataSet GetStartRaffleResultNew( int codeID, int rnoNum, DateTime rTime, long rCheckSum )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12605" );
            Para.AddOrcNewInParameter( "i_codeID", codeID );
            Para.AddOrcNewInParameter( "i_rnonum", rnoNum );
            Para.AddOrcNewInParameter( "i_rtime", rTime );
            Para.AddOrcNewInParameter( "i_rcheckSum", rCheckSum );
            Para.AddOrcNewCursorParameter( "o_result1" );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_RaffleForAny.sp_getNewLotteryByCodeID" );//pro_StartRaffle
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13603" );
            Para.AddOrcNewInParameter( "i_orderNO", orderNO );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_ZSys_Order.sp_getOrdersInfoForPrin" );//prosys_OrdersGetInfoForPrint
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11743" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_startTime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getActOrderByUserid" );
            totalCount = GetOrcTotalCount( isCount, _DS );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13609" );
            Para.AddOrcNewInParameter( "i_orderNO", orderNO );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_ZSys_Order.sp_getActOrdersInfoByOrderNO" );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11761" );
            Para.AddOrcNewInParameter( "i_OrderNO", orderNO );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getOrderDetlByOrderNo" );
        }
        #endregion

        #region 根据订单号查其换货后的订单信息
        /// <summary>
        /// 根据订单号查其换货后的订单信息
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public DataSet GetChangeOrderListByUserID( int userID, int orderNO )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11759" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_orderNO", orderNO );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getChgOrderListByUserid" );
        }
        #endregion

        #region 根据用户ID获取未填写收货地址的订单
        /// <summary>
        /// 根据用户ID获取未填写收货地址的订单
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public DataSet GetNewOrderByUserID( int userID, int lastOrderNO )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13113" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_orderNO", lastOrderNO );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_WXAuto.sp_getNewOrdersByUserid" );
        }
        #endregion

        #region 添加订单的快递信息
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
        public int AddOrderShipLog( long packageNO, string city, string shipNO, string shipDesc, DateTime acceptTime, string remark, int dyTypeID, int dyCheck )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11124" );
            Para.AddOrcNewInParameter( "i_packageNO", packageNO );
            Para.AddOrcNewInParameter( "i_city", city );
            Para.AddOrcNewInParameter( "i_shipno", shipNO );
            Para.AddOrcNewInParameter( "i_shipdesc", shipDesc );
            Para.AddOrcNewInParameter( "i_acceptTime", acceptTime );
            Para.AddOrcNewInParameter( "i_remark", remark );
            Para.AddOrcNewInParameter( "i_dytypeid", dyTypeID );
            Para.AddOrcNewInParameter( "i_dyCheck", dyCheck );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_ErpPackage.f_addShipLog" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        #endregion

        #region 获取订单配送信息
        /// <summary>
        /// 获取订单配送信息
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public DataSet GetOrderDischInfoByOrderNO( int orderNO )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12020" );
            Para.AddOrcNewInParameter( "i_Orderno", orderNO );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_Order.sp_getOrderDischInfoByOrderno" );
        }
        #endregion

        #region 添加订单证件信息
        /// <summary>
        /// 添加订单证件信息
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="addriSortID">证件类型ID</param>
        /// <param name="identification">证件内容</param>
        /// <param name="idenRank">证件排序值</param>
        /// <param name="isCommit">是由程序提交：0否，1是</param>
        /// <returns></returns>
        public int InsertOrderIdentification( int orderNO, int addriSortID, string identification, int idenRank, int isCommit )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12021" );
            Para.AddOrcNewInParameter( "i_orderNO", orderNO );
            Para.AddOrcNewInParameter( "i_addrisortid", addriSortID );
            Para.AddOrcNewInParameter( "i_identitycontent", identification );
            Para.AddOrcNewInParameter( "i_idenRank", idenRank );
            Para.AddOrcNewInParameter( "i_isCommit", isCommit );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_Order.f_addOrderIdentity" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 修改订单证件信息
        /// <summary>
        /// 修改订单证件信息
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="addriSortID">证件类型ID</param>
        /// <param name="identification">证件内容</param>
        /// <param name="isCommit">是由程序提交：0否，1是</param>
        /// <returns></returns>
        public int UpdateOrderIdentification( int orderNO, int addriSortID, string identification, int isCommit )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12022" );
            Para.AddOrcNewInParameter( "i_orderNO", orderNO );
            Para.AddOrcNewInParameter( "i_addrisortid", addriSortID );
            Para.AddOrcNewInParameter( "i_identitycontent", identification );
            Para.AddOrcNewInParameter( "i_isCommit", isCommit );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_Order.f_modOrderIdentity" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 根据商品ID获取相关证件列表
        /// <summary>
        /// 根据商品ID获取相关证件列表
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        public DataSet GetIdentificationByOrderNO( int goodsID, int orderNO )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12023" );
            Para.AddOrcNewInParameter( "i_goodsID", goodsID );
            Para.AddOrcNewInParameter( "i_orderno", orderNO );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_Order.sp_getNeedIdentityByGoodsID" );
        }
        #endregion

        #region 添加证件信息绑定到地址信息里面
        /// <summary>
        /// 添加证件信息绑定到地址信息里面
        /// </summary>
        /// <param name="contactID"></param>
        /// <param name="orderNO"></param>
        /// <param name="isCommit">是由程序提交：0否，1是</param>
        /// <returns></returns>
        public int InsertAddressIdentification( int contactID, int orderNO, int isCommit )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12024" );
            Para.AddOrcNewInParameter( "i_addrContactID", contactID );
            Para.AddOrcNewInParameter( "i_orderNO", orderNO );
            Para.AddOrcNewInParameter( "i_isCommit", isCommit );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_Order.f_addaddressIdentity" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 获取绑定到地址信息里面的证件信息
        /// <summary>
        /// 获取绑定到地址信息里面的证件信息
        /// </summary>
        /// <param name="contactID"></param>
        /// <returns></returns>
        public DataSet GetAddressIdentification( int contactID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12025" );
            Para.AddOrcNewInParameter( "i_addrContactID", contactID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_Order.sp_getIdentityByAddrID" );
        }
        #endregion

        #region 添加订单所选择的商品规格
        /// <summary>
        /// 添加订单所选择的商品规格
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="labelSortID">规格ID</param>
        /// <param name="rank">排序值</param>
        /// <param name="isCommit">是由程序提交：0否，1是</param>
        /// <returns></returns>
        public int InsertOrderSpec( int orderNO, int labelSortID, int rank, int isCommit )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12026" );
            Para.AddOrcNewInParameter( "i_orderno", orderNO );
            Para.AddOrcNewInParameter( "i_lablesortID", labelSortID );
            Para.AddOrcNewInParameter( "i_rank", rank );
            Para.AddOrcNewInParameter( "i_isCommit", isCommit );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_Order.f_addOrderSpec" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 根据订单号修改其对应的SKU码
        /// <summary>
        /// 根据订单号修改其对应的SKU码
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="selfSku">自己的SKU</param>
        /// <param name="attrValueStr">属性描述串</param>
        /// <param name="isNeedUpdateSku">是否需要再次修改sku，0.不需要 1.需要</param>
        /// <param name="isCommit">是由程序提交：0否，1是</param>
        /// <returns></returns>
        public int UpdateOrderSkuByOrderNO( int orderNO, string selfSku, string attrValueStr, int isNeedUpdateSku, int isCommit )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12026" );
            Para.AddOrcNewInParameter( "i_orderno", orderNO );
            Para.AddOrcNewInParameter( "i_SelfSku", selfSku );
            Para.AddOrcNewInParameter( "i_attrValuesStr", attrValueStr );
            Para.AddOrcNewInParameter( "i_isNeedModSku", isNeedUpdateSku );
            Para.AddOrcNewInParameter( "i_isCommit", isCommit );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_Order.f_modOrderSkuByOrderNo" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 根据订单号获取相关规格列表
        /// <summary>
        /// 根据订单号获取相关规格列表
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public DataSet GetSpecListByOrderNO( int goodsID, int orderNO )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12027" );
            Para.AddOrcNewInParameter( "i_goodsID", goodsID );
            Para.AddOrcNewInParameter( "i_orderno", orderNO );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_Order.sp_getSpecListByOrderNO" );
        }
        #endregion

        #region 根据时间抓取数据（跨境电商）
        /// <summary>
        /// 根据时间抓取数据（跨境电商）
        /// </summary>
        /// <param name="fetchTime">抓取时间</param>
        /// <param name="FIdx">起始索引</param>
        /// <param name="EIdx">线束索引</param>
        /// <param name="totalCount">输出总行数</param>
        /// <returns></returns>
        public DataSet GetOrderListByTime( DateTime fetchTime, int orderNO, int FIdx, int EIdx, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12028" );
            Para.AddOrcNewInParameter( "i_fetchTime", fetchTime );
            Para.AddOrcNewInParameter( "i_orderNO", orderNO );//
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_Order.sp_getOrderNOListByTime" );
            totalCount = GetOrcTotalCount( FIdx == 1 ? 1 : 0, _DS );
            return _DS;
        }
        #endregion

        #region 跨境电商订单发货回写并出库
        /// <summary>
        /// 跨境电商订单发货回写并出库
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="shipName">快递商名字</param>
        /// <param name="shipNO">快递单号</param>
        /// <returns></returns>
        public int UpdateKJDSorderFinish( int orderNO, string shipName, string shipNO )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12029" );
            Para.AddOrcNewInParameter( "i_orderNO", orderNO );
            Para.AddOrcNewInParameter( "i_shipName", shipName );
            Para.AddOrcNewInParameter( "i_shipNO", shipNO );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_Order.f_modKJDSOrderFinish" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        #endregion

        #region 根据订单号查询扩展信息
        /// <summary>
        /// 根据订单号查询扩展信息
        /// 目前仅返回ContactID
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public DataTable GetOrderExtendInfoByOrderNO( int orderNO )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12030" );
            Para.AddOrcNewInParameter( "i_orderNO", orderNO );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataTable( "yun_Order.sp_getContactIDByOrderNO" );
        }
        #endregion

        #region 出库回扫单－根据快递单号更新状态
        /// <summary>
        /// 出库回扫单－根据快递单号更新状态
        /// </summary>
        /// <param name="shipNO">快递单号</param>
        /// <param name="dyTypeID">快递商编号</param>
        /// <param name="shipState"></param>
        /// <returns></returns>
        public int UpdateShipStateByShipNO( string shipNO, int dyTypeID, int shipState )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11284" );
            Para.AddOrcNewInParameter( "i_shipno", shipNO );
            Para.AddOrcNewInParameter( "i_dyTypeID", dyTypeID );
            Para.AddOrcNewInParameter( "i_shipstate", shipState );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_ErpStock.f_modShipStateByShipNO" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        #endregion

        #region 根据商品ID及订单号获取相关SKU和属性列表
        /// <summary>
        /// 根据商品ID及订单号获取相关SKU和属性列表
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public DataSet GetSkuAttrByOrderNo( int goodsID, int orderNO )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12031" );
            Para.AddOrcNewInParameter( "i_goodsID", goodsID );
            Para.AddOrcNewInParameter( "i_orderno", orderNO );
            Para.AddOrcNewCursorParameter( "o_result" );
            Para.AddOrcNewCursorParameter( "o_result_attr" );
            return Dal.ExecuteFillDataSet( "yun_order.sp_getSkuAtrrByOrderNO" );
        }
        #endregion
    }
}
