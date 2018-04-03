using System;
using System.Data;
using System.ServiceModel;

namespace wcfNSYGShop
{
    public partial interface IWCFContract
    {
        #region 插入微信凭证记录
        /// <summary>
        /// 插入微信凭证记录
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="openID">微信用户唯一标识</param>
        /// <param name="unionID">同一开放平台微信用户唯一标识</param>
        /// <returns></returns>
        [OperationContract]
        bool InsertWxAuth( int userID, string openID, string unionID );
        #endregion

        #region 获取微信用户id
        /// <summary>
        /// 获取微信用户id
        /// </summary>
        /// <param name="openID">微信用户唯一标识</param>
        /// <param name="unionID">同一开放平台下的用户唯一标识</param>
        /// <returns></returns>
        [OperationContract]
        int GetUserIDByWxID( string openID, string unionID );
        #endregion

        #region 删除微信凭证记录
        /// <summary>
        /// 删除微信凭证记录
        /// </summary>
        /// <param name="wxID">微信会员唯一标识</param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteWxAuth( string wxID );
        #endregion

        /// <summary>
        /// 获取需要通知的发货记录列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        DataSet GetSendShipList();

        /// <summary>
        /// 更新微信支付记录状态
        /// </summary>
        /// <param name="shopID">支付订单号</param>
        /// <param name="state">
        /// 状态：
        /// -1 通知发货中
        ///  0 等待通知发货
        ///  1 已通知发货
        /// </param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateWxPaymentState( long shopID, int state );

        /// <summary>
        /// 通过USERID获取用户wxID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [OperationContract]
        string GetWxIDByUserID( int userID, int idType );

        /// <summary>
        /// 插入微信推送信息
        /// </summary>
        /// <param name="wxID">用户微信ID</param>
        /// <param name="msgContent">推送内容</param>
        /// <param name="relationID">关联ID</param>
        /// <param name="msgType">关联类型：
        ///     1.订单步骤表OrderDoStep
        ///     2.登录消息，不关联表
        ///     3.等待定义</param>
        /// <param name="msgUserID">用户ID</param>
        /// <param name="delayTime">延时时间(秒)</param>
        /// <returns></returns>
        [OperationContract]
        int AddWxSendMessage( string wxID, string msgContent, int relationID, int msgType, int msgUserID, int delayTime );

        /// <summary>
        /// 修改微信推送信息的状态
        /// </summary>
        /// <param name="msgID">微信ID</param>
        /// <param name="state">消息状态：0.等待发送 1.正在发送 2.发送成功 3.发送失败</param>
        /// <param name="updateTime">更新时间</param>
        /// <returns></returns>
        [OperationContract]
        int UpdateWXMsgSendState( int msgID, int state, DateTime updateTime );

        /// <summary>
        /// 获取待推送的微信消息
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        DataSet GetWxSendMsgList();
    }
}
