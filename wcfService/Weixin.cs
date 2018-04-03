using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class WCFServiceFun
    {
        #region 插入微信凭证记录
        /// <summary>
        /// 插入微信凭证记录
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="openID">微信用户唯一标识</param>
        /// <param name="unionID">同一开放平台微信用户唯一标识</param>
        /// <returns></returns>
        public bool InsertWxAuth( int userID, string openID, string unionID )
        {
            bool _IsSuccess = false;
            if ( userID > 0 && unionID != "" )
            {
                try
                {
                    IDALWeixin _DAL = new DALWeixin();
                    _IsSuccess = _DAL.InsertWxAuth( userID, openID, unionID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Weixin.InsertWxAuth Exception:" + ex.Message );
                }
            }
            return _IsSuccess;
        }
        #endregion

        #region 获取微信用户id
        /// <summary>
        /// 获取微信用户id
        /// </summary>
        /// <param name="openID">微信用户唯一标识</param>
        /// <param name="unionID">同一开放平台下的用户唯一标识</param>
        /// <returns></returns>
        public int GetUserIDByWxID( string openID, string unionID )
        {
            int _UserID = -1;
            if ( unionID != "" )
            {
                try
                {
                    IDALWeixin _DAL = new DALWeixin();
                    _UserID = _DAL.GetUserIDByWxID( openID, unionID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Weixin.GetUserIDByWxID Exception:" + ex.Message );
                }
            }
            return _UserID;
        }
        #endregion

        #region 删除微信凭证记录
        /// <summary>
        /// 删除微信凭证记录
        /// </summary>
        /// <param name="wxID">微信会员唯一标识</param>
        /// <returns></returns>
        public bool DeleteWxAuth( string wxID )
        {
            bool _IsSuccess = false;
            if ( wxID != "" )
            {
                try
                {
                    IDALWeixin _DAL = new DALWeixin();
                    _IsSuccess = _DAL.DeleteWxAuth( wxID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Weixin.DeleteWxAuth Exception:" + ex.Message );
                }
            }
            return _IsSuccess;
        }
        #endregion

        /// <summary>
        /// 获取需要通知的发货记录列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetSendShipList()
        {
            DataSet _DS = null;
            try
            {
                IDALWeixin _DAL = new DALWeixin();
                _DS = _DAL.GetSendShipList();
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.GetSendShipList抛出异常：" + ex.Message );
            }
            return _DS;
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
            bool _IsSuccess = false;
            if ( shopID > 0 )
            {
                try
                {
                    IDALWeixin _DAL = new DALWeixin();
                    _IsSuccess = _DAL.UpdateWxPaymentState( shopID, state );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Weixin.UpdateWxPaymentState Exception:" + ex.Message );
                }
            }
            return _IsSuccess;
        }

        /// <summary>
        /// 通过USERID获取用户微信ID
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="idType">获取ID类型：0 openID, 1 unionID</param>
        /// <returns></returns>
        public string GetWxIDByUserID( int userID, int idType )
        {
            string _WxID = "";
            if ( userID > 0 )
            {
                try
                {
                    IDALWeixin _DAL = new DALWeixin();
                    DataTable _DT = _DAL.GetWxIDByUserID( userID );
                    _DAL = null;
                    if ( _DT != null && _DT.Rows.Count > 0 )
                    {
                        if ( idType == 0 )
                        {
                            _WxID = _DT.Rows[0]["WXID"].ToString();
                        }
                        else
                        {
                            _WxID = _DT.Rows[0]["unionid"].ToString();
                        }
                    }
                    _DT = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Weixin.GetWxIDByUserID Exceptipn:" + ex.Message );
                }
            }
            return _WxID;
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
        /// <returns></returns>
        public int AddWxSendMessage( string wxID, string msgContent, int relationID, int msgType, int msgUserID, int delayTime )
        {
            int _Result = 0;
            try
            {
                IDALWeixin _DAL = new DALWeixin();
                _Result = _DAL.AddWxSendMessage( wxID, msgContent, relationID, msgType, msgUserID, delayTime );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Weixin.AddWxSendMessage Exceptipn:" + ex.Message );
            }
            return _Result;
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
            int _Result = 0;
            try
            {
                IDALWeixin _DAL = new DALWeixin();
                _Result = _DAL.UpdateWXMsgSendState( msgID, state, updateTime );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Weixin.UpdateWXMsgSendState Exceptipn:" + ex.Message );
            }
            return _Result;
        }

        /// <summary>
        /// 获取待推送的微信消息
        /// </summary>
        /// <returns></returns>
        public DataSet GetWxSendMsgList()
        {
            DataSet _DS = null;
            try
            {
                IDALWeixin _DAL = new DALWeixin();
                _DS = _DAL.GetWxSendMsgList();
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Weixin.GetWxSendMsgList Exceptipn:" + ex.Message );
            }
            return _DS;
        }
    }
}
