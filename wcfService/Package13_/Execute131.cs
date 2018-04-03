using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 删除微信凭证记录13101
        /// <summary>
        /// 删除微信凭证记录13101
        /// </summary>
        /// <param name="wxID">微信会员唯一标识</param>
        /// <returns></returns>
        public static int DeleteWxAuth( params object[] para )
        {
            string wxID = (string)para[0];
            int _IsSuccess = 0;
            if ( wxID != "" )
            {
                try
                {
                    IDALWeixin _DAL = new DALWeixin();
                    _IsSuccess = _DAL.DeleteWxAuth( wxID ) ? 1 : 0;
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
        #region 获取微信用户id 13102
        /// <summary>
        /// 获取微信用户id 13102
        /// </summary>
        /// <param name="openID">微信用户唯一标识</param>
        /// <param name="unionID">同一开放平台下的用户唯一标识</param>
        /// <returns></returns>
        public static int GetUserIDByWxID( params object[] para )
        {
            string openID = (string)para[0];
            string unionID = (string)para[1];
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
                    UtilityFile.AddLogErrMsg( "Weixin.GetUserIDByWxID1 Exception:" + ex.Message );
                }
            }
            return _UserID;
        }
        #endregion
        #region 获取微信用户id 13102
        /// <summary>
        /// 获取微信用户id 13102
        /// </summary>
        /// <param name="openID">微信用户唯一标识</param>
        /// <param name="unionID">同一开放平台下的用户唯一标识</param>
        /// <returns></returns>
        public static int GetUserIDByWxID( out int isAutoLogin, params object[] para )
        {
            isAutoLogin = 0;

            string openID = (string)para[0];
            string unionID = (string)para[1];
            int _UserID = -1;
            if ( unionID != "" )
            {
                try
                {
                    IDALWeixin _DAL = new DALWeixin();
                    _UserID = _DAL.GetUserIDByWxID( openID, unionID, out isAutoLogin );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Weixin.GetUserIDByWxID2 Exception:" + ex.Message );
                }
            }
            return _UserID;
        }
        #endregion
        #region 插入微信凭证记录13103
        /// <summary>
        /// 插入微信凭证记录13103
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="openID">微信用户唯一标识</param>
        /// <param name="unionID">同一开放平台微信用户唯一标识</param>
        /// <returns></returns>
        public static int InsertWxAuth( params object[] para )
        {
            int userID = (int)para[0];
            string openID = (string)para[1];
            string unionID = (string)para[2];
            int _IsSuccess = 0;
            if ( userID > 0 && unionID != "" )
            {
                try
                {
                    IDALWeixin _DAL = new DALWeixin();
                    _IsSuccess = _DAL.InsertWxAuth( userID, openID, unionID ) ? 1 : 0;
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
        #region 获取需要通知的发货记录列表13104
        /// <summary>
        /// 获取需要通知的发货记录列表13104
        /// </summary>
        /// <returns></returns>
        public static DataSet GetSendShipList()
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
        #endregion
        #region 更新微信支付记录状态13105
        /// <summary>
        /// 更新微信支付记录状态13105
        /// </summary>
        /// <param name="shopID">支付订单号</param>
        /// <param name="state">
        /// 状态：
        /// -1 通知发货中
        ///  0 等待通知发货
        ///  1 已通知发货
        /// </param>
        /// <returns></returns>
        public static int UpdateWxPaymentState( params object[] para )
        {
            long shopID = (long)para[0];
            int state = (int)para[1];
            int _IsSuccess = 0;
            if ( shopID > 0 )
            {
                try
                {
                    IDALWeixin _DAL = new DALWeixin();
                    _IsSuccess = _DAL.UpdateWxPaymentState( shopID, state ) ? 1 : 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Weixin.UpdateWxPaymentState Exception:" + ex.Message );
                }
            }
            return _IsSuccess;
        }
        #endregion
        #region 通过USERID获取用户微信ID 13107
        /// <summary>
        /// 通过USERID获取用户微信ID 13107
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="idType">获取ID类型：0 openID, 1 unionID</param>
        /// <returns></returns>
        public static string GetWxIDByUserID( params object[] para )
        {
            int userID = (int)para[0];
            int idType = (int)para[1];
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
        #endregion
        #region 插入微信推送信息13108
        /// <summary>
        /// 插入微信推送信息13108
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
        public static int AddWxSendMessage( params object[] para )
        {
            string wxID = (string)para[0];
            string msgContent = (string)para[1];
            int relationID = (int)para[2];
            int msgType = (int)para[3];
            int msgUserID = (int)para[4];
            int delayTime = (int)para[5];
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
        #endregion
        #region 修改微信推送信息的状态13109
        /// <summary>
        /// 修改微信推送信息的状态13109
        /// </summary>
        /// <param name="msgID">微信ID</param>
        /// <param name="state">消息状态：0.等待发送 1.正在发送 2.发送成功 3.发送失败</param>
        /// <param name="updateTime">更新时间</param>
        /// <returns></returns>
        public static int UpdateWXMsgSendState( params object[] para )
        {
            int msgID = (int)para[0];
            int state = (int)para[1];
            DateTime updateTime = (DateTime)para[2];
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
        #endregion
        #region 获取待推送的微信消息13110
        /// <summary>
        /// 获取待推送的微信消息13110
        /// </summary>
        /// <returns></returns>
        public static DataSet GetWxSendMsgList()
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
        #endregion

        #region 获取某商品的所有期数获得者信息13112
        /// <summary>
        /// 获取某商品的所有期数获得者信息
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="period">当前页最小的期数</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总记录数</param>
        /// <returns></returns>
        public static DataSet GetBarcodeRaffListByGoodsID( out int count, params object[] para )
        {
            DataSet _DS = null;
            count = 0;
            try
            {
                int _GoodsID = (int)para[0];
                int _Period = (int)para[1];
                int _FIdx = (int)para[2];
                int _EIdx = (int)para[3];
                int _IsCount = (int)para[4];

                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetBarcodeRaffListByGoodsID( _GoodsID, _Period, _FIdx, _EIdx, _IsCount, out count );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Weixin.GetBarcodeRaffListByGoodsID Ex:" + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region 根据用户ID获取未填写收货地址的订单13113
        /// <summary>
        /// 根据用户ID获取未填写收货地址的订单
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static DataSet GetNewOrderByUserID( params object[] para )
        {
            DataSet _DS = null;
            try
            {
                int _UserID = (int)para[0];
                int _OrderNO = (int)para[1];

                IDALOrders _DAL = new DALOrders();
                _DS = _DAL.GetNewOrderByUserID( _UserID, _OrderNO );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Weixin.GetNewOrderByUserID Ex:" + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region 根据申请ID获取某条佣金提现记录
        /// <summary>
        /// 根据申请ID获取某条佣金提现记录
        /// </summary>
        /// <param name="applyID">申请ID</param>
        /// <returns></returns>
        public static DataSet GetBrokerInfoByApplyID( params object[] para )
        {
            DataSet _DS = null;
            try
            {
                int _ApplyID = (int)para[0];
                if ( _ApplyID > 0 )
                {
                    IDALUserPoints _DAL = new DALUserPoints();
                    _DS = _DAL.GetBrokerInfoByApplyID( _ApplyID );
                    _DAL = null;
                }
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Weixin.GetBrokerInfoByApplyID Ex:" + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region 微信小程序
        /// <summary>
        /// 绑定微信小程序13115
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="wxSID"></param>
        /// <param name="unionID"></param>
        /// <returns></returns>
        public static int AddWXSmallAuth( params object[] para )
        {
            int _UserID = (int)para[0];
            string _WxSID = (string)para[1];
            string _UnionID = (string)para[2];
            int _Result = 0;
            try
            {
                IDALWeixin _DAL = new DALWeixin();
                _Result = _DAL.AddWXSmallAuth( _UserID, _WxSID, _UnionID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Weixin.AddWXSmallAuth Exceptipn:" + ex.Message );
            }
            return _Result;
        }
        /// <summary>
        /// 获取微信小程序对应用户13116
        /// </summary>
        /// <param name="wxSID"></param>
        /// <param name="unionID"></param>
        /// <returns></returns>
        public static DataSet GetUserIDByWXSmallID( params object[] para )
        {
            DataSet _DS = null;
            try
            {
                string _WxSID = (string)para[0];
                string _UnionID = (string)para[1];

                IDALWeixin _DAL = new DALWeixin();
                _DS = _DAL.GetUserIDByWXSmallID( _WxSID, _UnionID );
                _DAL = null;

            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Weixin.GetUserIDByWXSmallID Ex:" + ex.Message );
            }
            return _DS;
        }
        #endregion
    }
}
