using System;
using System.Data;

namespace wcfNSYGShop
{
    public interface IDALWeixin
    {
        /// <summary>
        /// 插入微信凭证记录
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="openID">微信用户唯一标识</param>
        /// <param name="unionID">同一开放平台微信用户唯一标识</param>
        /// <returns></returns>
        bool InsertWxAuth( int userID, string openID, string unionID );

        /// <summary>
        /// 获取微信用户id
        /// </summary>
        /// <param name="openID">微信用户唯一标识</param>
        /// <param name="unionID">同一开放平台下的用户唯一标识</param>
        /// <returns></returns>
        int GetUserIDByWxID( string openID, string unionID );

        /// <summary>
        /// 获取微信用户id
        /// </summary>
        /// <param name="openID">微信用户唯一标识</param>
        /// <param name="unionID">同一开放平台下的用户唯一标识</param>
        /// <returns></returns>
        int GetUserIDByWxID( string openID, string unionID, out int isAutoLogin );

        /// <summary>
        /// 删除微信凭证记录
        /// </summary>
        /// <param name="wxID">微信会员唯一标识</param>
        /// <returns></returns>
        bool DeleteWxAuth( string wxID );

        /// <summary>
        /// 获取需要通知的发货记录列表
        /// </summary>
        /// <returns></returns>
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
        bool UpdateWxPaymentState( long shopID, int state );

        /// <summary>
        /// 通过USERID获取用户微信ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        DataTable GetWxIDByUserID( int userID );

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
        int AddWxSendMessage( string wxID, string msgContent, int relationID, int msgType, int msgUserID, int delayTime );

        /// <summary>
        /// 修改微信推送信息的状态
        /// </summary>
        /// <param name="msgID">微信ID</param>
        /// <param name="state">消息状态：0.等待发送 1.正在发送 2.发送成功 3.发送失败</param>
        /// <param name="updateTime">更新时间</param>
        /// <returns></returns>
        int UpdateWXMsgSendState( int msgID, int state, DateTime updateTime );

        /// <summary>
        /// 获取待推送的微信消息
        /// </summary>
        /// <returns></returns>
        DataSet GetWxSendMsgList();


        #region 微信小程序
        /// <summary>
        /// 绑定微信小程序13115
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="wxSID"></param>
        /// <param name="unionID"></param>
        /// <returns></returns>
        int AddWXSmallAuth( int userID, string wxSID, string unionID );

        /// <summary>
        /// 获取微信小程序对应用户
        /// </summary>
        /// <param name="wxSID"></param>
        /// <param name="unionID"></param>
        /// <returns></returns>
        DataSet GetUserIDByWXSmallID( string wxSID, string unionID );
        #endregion

        #region 微信导航展板获取12231
        /// <summary>
        /// 微信导航展板获取12231
        /// </summary>
        /// <returns></returns>
        DataSet GetWeChatNvgtion();

        #endregion
    }
}
