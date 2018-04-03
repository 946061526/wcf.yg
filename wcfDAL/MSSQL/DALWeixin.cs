using System;
using System.Data;

namespace wcfNSYGShop
{
    public class DALWeixin : DALBase, IDALWeixin
    {
        /// <summary>
        /// 插入微信凭证记录
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="openID">微信用户唯一标识</param>
        /// <param name="unionID">同一开放平台微信用户唯一标识</param>
        /// <returns></returns>
        public bool InsertWxAuth( int userID, string openID, string unionID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "13103" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_wxID", openID );
            Para.AddOrcNewInParameter( "i_UnionID", unionID );
            Dal.ExecuteNonQuery( "yun_WXAuto.f_addWXAuth" );//pro_WXAuthInsert
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal > 0;
        }

        /// <summary>
        /// 获取微信用户id
        /// </summary>
        /// <param name="openID">微信用户唯一标识</param>
        /// <param name="unionID">同一开放平台下的用户唯一标识</param>
        /// <returns></returns>
        public int GetUserIDByWxID( string openID, string unionID )
        {
            int _IsAutoLogin = 0;
            return GetUserIDByWxID( openID, unionID, out _IsAutoLogin );
        }

        /// <summary>
        /// 获取微信用户id
        /// </summary>
        /// <param name="openID">微信用户唯一标识</param>
        /// <param name="unionID">同一开放平台下的用户唯一标识</param>
        /// <returns></returns>
        public int GetUserIDByWxID( string openID, string unionID, out int isAutoLogin )
        {
            isAutoLogin = 0;
            int _UserID = 0;

            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13102" );
            Para.AddOrcNewInParameter( "i_wxid", openID );
            Para.AddOrcNewInParameter( "i_unionID", unionID );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataTable _DT = Dal.ExecuteFillDataTable( "yun_WXAuto.sp_getWXUserIDByWXID" );//pro_WXAuthGetUserID
            if ( _DT != null && _DT.Rows.Count > 0 )
            {
                _UserID = ToInt32( _DT.Rows[0]["userID"] );
                isAutoLogin = ToInt32( _DT.Rows[0]["isAutoLogin"] );
            }
            _DT = null;
            return _UserID;
        }

        /// <summary>
        /// 删除微信凭证记录
        /// </summary>
        /// <param name="wxID">微信会员唯一标识</param>
        /// <returns></returns>
        public bool DeleteWxAuth( string wxID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "13101" );
            Para.AddOrcNewInParameter( "i_wxID", wxID );
            Dal.ExecuteNonQuery( "yun_WXAuto.f_delWXAuth" );//pro_WXAuthDelete
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal > 0;
        }

        /// <summary>
        /// 获取需要通知的发货记录列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetSendShipList()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13104" );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_WXAuto.sp_getWXPaymentSendShip" );//pro_WXPaymentGetSendShipList
        }
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
        public bool UpdateWxPaymentState( long shopID, int state )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "13105" );
            Para.AddOrcNewInParameter( "i_shopid", shopID );
            Para.AddOrcNewInParameter( "i_state", state );
            Dal.ExecuteNonQuery( "yun_WXAuto.f_modWXPaymentState" );//pro_WXPaymentUpdate
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal == 1;
        }

        /// <summary>
        /// 通过USERID获取用户微信ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataTable GetWxIDByUserID( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13107" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataTable( "yun_WXAuto.sp_getWXIDByUserID" );
        }

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
        /// <returns>1成功，0失败</returns>
        public int AddWxSendMessage( string wxID, string msgContent, int relationID, int msgType, int msgUserID, int delayTime )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13108" );
            Para.AddOrcNewInParameter( "i_MsgWXID", wxID );
            Para.AddOrcNewInParameter( "i_MsgContent", msgContent );
            Para.AddOrcNewInParameter( "i_MsgrelationID", relationID );
            Para.AddOrcNewInParameter( "i_MsgType", msgType );
            Para.AddOrcNewInParameter( "i_MsgUserID", msgUserID );
            Para.AddOrcNewInParameter( "i_DelayTime", delayTime );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_WXAuto.f_addWXMsgSend" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }

        /// <summary>
        /// 修改微信推送信息的状态
        /// </summary>
        /// <param name="msgID">微信ID</param>
        /// <param name="state">消息状态：0.等待发送 1.正在发送 2.发送成功 3.发送失败</param>
        /// <param name="updateTime">更新时间</param>
        /// <returns></returns>
        public int UpdateWXMsgSendState( int msgID, int state, DateTime updateTime )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13109" );
            Para.AddOrcNewInParameter( "i_MsgID", msgID );
            Para.AddOrcNewInParameter( "i_State", state );
            Para.AddOrcNewInParameter( "i_updateTime", updateTime );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_WXAuto.f_modWXMsgSendState" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }

        /// <summary>
        /// 获取待推送的微信消息
        /// </summary>
        /// <returns></returns>
        public DataSet GetWxSendMsgList()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13110" );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_WXAuto.sp_getWXMsgSend" );
        }

        #region 微信小程序
       /// <summary>
        /// 绑定微信小程序13115
       /// </summary>
       /// <param name="userID"></param>
       /// <param name="wxSID"></param>
       /// <param name="unionID"></param>
       /// <returns></returns>
        public int AddWXSmallAuth( int userID, string wxSID, string unionID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13115" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_WXSmallID", wxSID );
            Para.AddOrcNewInParameter( "i_UnionID", unionID );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_WXAuto.f_addWXSmallAuth" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        /// <summary>
        /// 获取微信小程序对应用户
        /// </summary>
        /// <param name="wxSID"></param>
        /// <param name="unionID"></param>
        /// <returns></returns>
        public DataSet GetUserIDByWXSmallID( string wxSID, string unionID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13116" );
            Para.AddOrcNewInParameter( "i_WXSmallID", wxSID );
            Para.AddOrcNewInParameter( "i_UnionID", unionID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_WXAuto.sp_getUserIDByWXSmallID" );
        }
        #endregion
        #region 微信导航展板获取12231
        /// <summary>
        /// 微信导航展板获取12231
        /// </summary>
        /// <returns></returns>
        public DataSet GetWeChatNvgtion()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12231" );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getWeChatNvgtion" );
        }
        #endregion
    }
}
