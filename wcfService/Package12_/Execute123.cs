using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class ExecuteFun
    {
        #region 查询需要回查的支付记录列表12301
        /// <summary>
        /// 查询需要回查的支付记录列表12301 shopID,orderTime
        /// </summary>
        /// <param name="payTypeNO">支付方式编号</param>
        /// <returns></returns>
        public static DataSet GetPaymentRecordCheckList( params object[] para )
        {
            int payTypeNO = (int)para[0];
            DataSet _DS = null;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _DS = _DAL.GetPaymentRecordCheckList( payTypeNO );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.GetPaymentRecordCheckList Exception:" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 添加转账申请12305
        /// <summary>
        /// 添加转账申请12305
        /// </summary>
        /// <param name="outUserID">转出账号ID</param>
        /// <param name="inUserID">转入账号ID</param>
        /// <param name="money">转出金额</param>
        /// <param name="inAccount">转入账号</param>
        /// <param name="transMemo">转账备注</param>
        /// <returns></returns>
        public static int InsertTransferAccount( params object[] para )
        {
            int _Result = 0;
            int _OutUserID = (int)para[0];
            int _InUserID = (int)para[1];
            int _Money = (int)para[2];
            string _InAccount = (string)para[3];
            string _TransMemo = (string)para[4];
            IDALUsers _DAL = new DALUsers();
            _Result = _DAL.InsertTransferAccount( _OutUserID, _InUserID, _Money, _InAccount, _TransMemo );
            _DAL = null;
            return _Result;
        }
        #endregion
        #region 执行余额转账12306
        /// <summary>
        /// 执行余额转账12306
        /// </summary>
        /// <param name="transID">转账申请ID</param>
        /// <param name="outUserID">转出账号ID</param>
        /// <returns></returns>
        public static int ExecuteTransferAccount( params object[] para )
        {
            int _Result = 0;
            int _TransID = (int)para[0];
            int _OutUserID = (int)para[1];
            IDALUsers _DAL = new DALUsers();
            _Result = _DAL.ExecuteTransferAccount( _TransID, _OutUserID );
            _DAL = null;
            return _Result;
        }
        #endregion
        #region 删除转账申请12307
        /// <summary>
        /// 删除转账申请12307
        /// </summary>
        /// <param name="transID">转账申请ID</param>
        /// <param name="outUserID">转出账号ID</param>
        /// <returns></returns>
        public static int DeleteTransferAccount( params object[] para )
        {
            int _Result = 0;
            int _TransID = (int)para[0];
            int _OutUserID = (int)para[1];
            IDALUsers _DAL = new DALUsers();
            _Result = _DAL.DeleteTransferAccount( _TransID, _OutUserID );
            _DAL = null;
            return _Result;
        }
        #endregion
        #region 获取用户转帐列表12308
        /// <summary>
        /// 获取用户转帐列表12308
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="state">转账状态</param>
        /// <param name="transferWay">转账方式[0所有，1转出，2转入]</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">输出总数</param>
        /// <returns></returns>
        public static DataSet GetTransferAccountList( out int totalCount, params object[] para )
        {
            DataSet _DS = null;
            totalCount = 0;
            int _UserID = (int)para[0];
            DateTime _BeginTime = (DateTime)para[1];
            DateTime _EndTime = (DateTime)para[2];
            int _State = (int)para[3];
            int _TransferWay = (int)para[4];
            int _FIdx = (int)para[5];
            int _EIdx = (int)para[6];
            int _IsCount = (int)para[7];
            IDALUsers _DAL = new DALUsers();
            _DS = _DAL.GetTransferAccountList( _UserID, _BeginTime, _EndTime, _State, _TransferWay, _FIdx, _EIdx, _IsCount, out totalCount );
            _DAL = null;
            return _DS;
        }
        #endregion
        #region 根据转帐申请ID获取详细信息12309
        /// <summary>
        /// 根据转帐申请ID获取详细信息12309
        /// </summary>
        /// <param name="transID">转账申请ID</param>
        /// <returns></returns>
        public static DataSet GetTransferByTransID( params object[] para )
        {
            DataSet _DS = null;
            int _TransID = (int)para[0];
            IDALUsers _DAL = new DALUsers();
            _DS = _DAL.GetTransferByTransID( _TransID );
            _DAL = null;
            return _DS;
        }
        #endregion
        #region 购买充值卡时更新卡状态12312
        /// <summary>
        /// 购买充值卡时更新卡状态12312
        /// </summary>
        /// <param name="cardAccount">充值卡账号</param>
        /// <param name="buyPlat">1：淘宝</param>
        /// <returns></returns>
        public static int UpdateCardStateByAccount( params object[] para )
        {
            int _Result = 0;
            long _CardAccount = (long)para[0];
            int _BuyPlat = (int)para[1];
            IDALUsers _DAL = new DALUsers();
            _Result = _DAL.UpdateCardStateByAccount( _CardAccount, _BuyPlat );
            _DAL = null;
            return _Result;
        }
        #endregion
        #region 用户使用充值卡进行充值12313
        /// <summary>
        /// 用户使用充值卡进行充值12313
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="cardAccount">充值卡账号</param>
        /// <param name="cardPwd">充值卡密码</param>
        /// <param name="userIP">用户IP地址</param>
        /// <returns></returns>
        public static int UpdateCardWasteByUserID( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            long _CardAccount = (long)para[1];
            int _CardPwd = (int)para[2];
            string _UserIP = (string)para[3];
            IDALUsers _DAL = new DALUsers();
            _Result = _DAL.UpdateCardWasteByUserID( _UserID, _CardAccount, _CardPwd, _UserIP );
            _DAL = null;
            return _Result;
        }
        #endregion
        #region 获取充值卡信息12316
        /// <summary>
        /// 获取充值卡信息12316
        /// </summary>
        /// <param name="cardAccount">充值卡账号</param>
        /// <returns></returns>
        public static DataSet GetCardInfoByAccount( params object[] para )
        {
            DataSet _DS = null;
            long _CardAccount = (long)para[0];
            IDALUsers _DAL = new DALUsers();
            _DS = _DAL.GetCardInfoByAccount( _CardAccount );
            _DAL = null;
            return _DS;
        }
        #endregion

        #region 会员中心换货补扣差价12321
        /// <summary>
        /// 会员中心换货补扣差价
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="applyID">申请ID</param>
        /// <returns></returns>
        public static int UpdateMinusPriceByUserID( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            int _ApplyID = (int)para[1];
            IDALUsers _DAL = new DALUsers();
            _Result = _DAL.UpdateMinusPriceByUserID( _UserID, _ApplyID );
            _DAL = null;
            return _Result;
        }
        #endregion

        #region 获取支付订单号12322
        /// <summary>
        /// 获取支付订单号 shopType: 0--18位 1--16位
        /// </summary>
        /// <returns></returns>
        public static long GetPayShopID( params object[] para )
        {
            long _ShopID = 0L;
            int _ShopType = (int)para[0];
            DALCart _DAL = new DALCart();
            DataTable _DT = _DAL.GetPayShopID();
            if ( _DT != null && _DT.Rows.Count > 0 )
            {
                _ShopID = _ShopType == 0 ? UtilityFun.ToInt64( _DT.Rows[0]["PayShopID"] ) : UtilityFun.ToInt64( _DT.Rows[0]["PayShopID2"] );
            }
            _DT = null;
            return _ShopID;
        }
        #endregion

        #region 退补会员运费或差价操作12323
        /// <summary>
        /// 退补会员运费或差价操作
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="orderNO">订单号</param>
        /// <param name="logType">操作类型</param>
        /// <param name="money">金额</param>
        /// <param name="loginName">登录账号</param>
        /// <returns></returns>
        public static int FillUserBalance( params object[] param )
        {
            int userID = (int)param[0];
            int orderNO = (int)param[1];
            int logType = (int)param[2];
            int money = (int)param[3];
            string loginName = (string)param[4];

            IDALUsers _DalUser = new DALUsers();
            int _Result = _DalUser.FillUserBalance( userID, orderNO, logType, money, loginName );
            _DalUser = null;

            return _Result;
        }
        #endregion

        #region 校验用户转账次数,返回1表示未超过5次,-1表示已大于等于5次12345
        /// <summary>
        /// 校验用户转账次数,返回1表示未超过5次,-1表示已大于等于5次12345
        /// </summary>
        /// <param name="outUserID"></param>
        /// <returns></returns>
        public static int ChkTransferTimes( params object[] para )
        {
            int _Result = 0;
            try
            {
                int _OutUserID = (int)para[0];
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.ChkTransferTimes( _OutUserID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.ChkTransferTimes Exception:" + ex.Message );
            }
            return _Result;
        }
        #endregion
        #region 根据卡号获取对应的银行名称12328
        /// <summary>
        /// 根据卡号获取对应的银行名称12328
        /// </summary>
        /// <param name="cardNO">卡号</param>
        /// <param name="cardLength">卡长度</param>
        /// <returns></returns>
        public static DataSet GetBankNameByCardNO( params object[] para )
        {
            string cardNO = (string)para[0];
            int cardLength = (int)para[1];
            DataSet _DS = null;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _DS = _DAL.GetBankNameByCardNO( cardNO, cardLength );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.GetBankNameByCardNO Exception:" + ex.Message );
            }
            return _DS;
        }
        #endregion
    }
}
