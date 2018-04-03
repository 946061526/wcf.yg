using System;
using System.Data;

namespace wcfNSYGShop
{
    public interface IDALOrders
    {
        #region void DisposeConn() 关闭并释放连接对象资源  Edit:2010.02.08
        /// <summary>
        /// 关闭并释放连接资源
        /// </summary>
        void DisposeConn();
        #endregion
        #region void TranBegin() 事务开始  Edit:2010.12.24
        /// <summary>
        /// 启用事务
        /// </summary>
        void TranBegin();
        #endregion
        #region void TranCommit() 提交事务  Edit:2010.12.24
        /// <summary>
        /// 提交事务
        /// </summary>
        void TranCommit();
        #endregion
        #region void TranRollBack() 回滚事务  Edit:2010.12.24
        /// <summary>
        /// 回滚事务
        /// </summary>
        void TranRollBack();
        #endregion
        #region bool IsUseTrans 获取事务状态  Edit:2010.12.24
        /// <summary>
        /// 获取事务状态,true:表顺利执行
        /// </summary>
        bool IsUseTrans
        {
            get;
        }
        #endregion

        #region 获取订单信息
        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        DataSet GetOrderInfoByNO( int orderNO );
        #endregion

        #region 获取非删除状态的订单处理步骤
        /// <summary>
        /// 获取非删除状态的订单处理步骤
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        DataSet GetOrderDoStepListByNO( int orderNO );
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
        /// <param name="isCommit">是否由程序提交：0否，1是</param>
        /// <returns></returns>
        int UpdateOrderShipInfoTran( int orderNo, string userName, string tel, string mobile, int areaID, int streetID, string address, string zip, string shipTime, string shipRemark, string invoiceT, string invoiceC, string orderSpec, string deltaNumber, int isNoDelivery, string loginUserName, int isCommit );
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
        int UpdateOrderForEndTran( int orderNo, string orderRemark, string logDescription, string loginUserName );
        #endregion

        #region 获取订单配送信息列表
        /// <summary>
        /// 获取订单配送信息列表
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        DataSet GetOrderDeliveryListByNO( int orderNO );
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
        int UpdateOrders( int orderNO, string orderRemark, int orderState, DateTime orderUpdateTime );
        #endregion

        #region 更新订单配送信息
        /// <summary>
        /// 更新订单配送信息
        /// </summary>
        /// <param name="model">订单实例</param>
        /// <returns></returns>
        bool UpdateOrderShipInfo( int orderNO, string buyer, string tel, string mobile, int areaID, int streetID, string address,
            string zip, DateTime shipTime, string remark, string invoiceT, string invoiceC, int dyTypeID );
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
        DataSet GetStartRaffleResult( int codeID, int rnoNum, DateTime rTime, long rCheckSum );
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
        DataSet GetStartRaffleResultNew( int codeID, int rnoNum, DateTime rTime, long rCheckSum );
        #endregion

        #region 根据订单号获取订单信息用于打印
        /// <summary>
        /// 根据订单号获取订单信息用于打印
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        DataSet GetOrdersInfoForPrint( int orderNO );
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
        DataSet GetActOrderByUserid( int userID, DateTime beginTime, DateTime endTime, int FIdx, int EIdx, int isCount, out int totalCount );
        #endregion

        #region 会员中心-获取会员活动订单详情
        /// <summary>
        /// 会员中心-获取会员活动订单详情
        /// </summary>
        /// <param name="orderNO">活动订单号</param>
        /// <returns></returns>
        DataSet GetActOrdersInfoByOrderNO( int orderNO );
        #endregion

        #region 根据订单号查询换货订单详细信息
        /// <summary>
        /// 根据订单号查询换货订单详细信息
        /// </summary>
        /// <param name="orderNO"></param>
        /// <returns></returns>
        DataSet GetOrderInfoByOrderNO( int orderNO );
        #endregion

        #region 根据订单号查其换货后的订单信息
        /// <summary>
        /// 根据订单号查其换货后的订单信息
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        DataSet GetChangeOrderListByUserID( int userID, int orderNO );
        #endregion

        #region 根据用户ID获取未填写收货地址的订单
        /// <summary>
        /// 根据用户ID获取未填写收货地址的订单
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        DataSet GetNewOrderByUserID( int userID, int lastOrderNO );
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
        /// <param name="dyCheck">快递商ID</param>
        /// <returns>成功返回1，失败为0</returns>
        int AddOrderShipLog( long packageNO, string city, string shipNO, string shipDesc, DateTime acceptTime, string remark, int dyTypeID, int dyCheck );
        #endregion

        #region 获取订单配送信息
        /// <summary>
        /// 获取订单配送信息
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        DataSet GetOrderDischInfoByOrderNO( int orderNO );
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
        int InsertOrderIdentification( int orderNO, int addriSortID, string identification, int idenRank, int isCommit );
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
        int UpdateOrderIdentification( int orderNO, int addriSortID, string identification, int isCommit );
        #endregion

        #region 根据商品ID获取相关证件列表
        /// <summary>
        /// 根据商品ID获取相关证件列表
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        DataSet GetIdentificationByOrderNO( int goodsID, int orderNO );
        #endregion

        #region 添加证件信息绑定到地址信息里面
        /// <summary>
        /// 添加证件信息绑定到地址信息里面
        /// </summary>
        /// <param name="contactID"></param>
        /// <param name="orderNO"></param>
        /// <param name="isCommit">是由程序提交：0否，1是</param>
        /// <returns></returns>
        int InsertAddressIdentification( int contactID, int orderNO, int isCommit );
        #endregion

        #region 获取绑定到地址信息里面的证件信息
        /// <summary>
        /// 获取绑定到地址信息里面的证件信息
        /// </summary>
        /// <param name="contactID"></param>
        /// <returns></returns>
        DataSet GetAddressIdentification( int contactID );
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
        int InsertOrderSpec( int orderNO, int labelSortID, int rank, int isCommit );
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
        int UpdateOrderSkuByOrderNO( int orderNO, string selfSku, string attrValueStr, int isNeedUpdateSku, int isCommit );
        #endregion

        #region 根据订单号获取相关规格列表
        /// <summary>
        /// 根据订单号获取相关规格列表
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        DataSet GetSpecListByOrderNO( int goodsID, int orderNO );
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
        DataSet GetOrderListByTime( DateTime fetchTime, int orderNO, int FIdx, int EIdx, out int totalCount );
        #endregion

        #region 跨境电商订单发货回写并出库
        /// <summary>
        /// 跨境电商订单发货回写并出库
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="shipName">快递商名字</param>
        /// <param name="shipNO">快递单号</param>
        /// <returns></returns>
        int UpdateKJDSorderFinish( int orderNO, string shipName, string shipNO );
        #endregion

        #region 根据订单号查询扩展信息
        /// <summary>
        /// 根据订单号查询扩展信息
        /// 目前仅返回ContactID
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        DataTable GetOrderExtendInfoByOrderNO( int orderNO );
        #endregion

        #region 出库回扫单－根据快递单号更新状态
        /// <summary>
        /// 出库回扫单－根据快递单号更新状态
        /// </summary>
        /// <param name="shipNO">快递单号</param>
        /// <param name="dyTypeID">快递商编号</param>
        /// <param name="shipState"></param>
        /// <returns></returns>
        int UpdateShipStateByShipNO( string shipNO, int dyTypeID, int shipState );
        #endregion

        #region 根据商品ID及订单号获取相关SKU和属性列表
        /// <summary>
        /// 根据商品ID及订单号获取相关SKU和属性列表
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        DataSet GetSkuAttrByOrderNo( int goodsID, int orderNO );
        #endregion
    }
}
