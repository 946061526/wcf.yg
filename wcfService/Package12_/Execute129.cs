using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 插入用户反馈信息12901
        /// <summary>
        /// 插入用户反馈信息12901
        /// </summary>
        /// <param name="title"></param>
        /// <param name="userName"></param>
        /// <param name="userTel"></param>
        /// <param name="userEmail"></param>
        /// <param name="codeID"></param>
        /// <param name="content"></param>
        /// <param name="IP"></param>
        /// <returns></returns>
        public static int InsertSuggestMessage( params object[] para )
        {
            string title = (string)para[0];
            string userName = (string)para[1];
            string userTel = (string)para[2];
            string userEmail = (string)para[3];
            string codeID = (string)para[4];
            string content = (string)para[5];
            string IP = (string)para[6];

            string suggestType = "";
            string suggestSubType = "";
            string terminalInfo = "";
            string uploadPictures = "";
            if ( para.Length > 10 )
            {
                suggestType = (string)para[7];
                suggestSubType = (string)para[8];
                terminalInfo = (string)para[9];
                uploadPictures = (string)para[10];
            }
            int _RetVal = -1;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _RetVal = _DAL.InsertSuggestMessage( title, userName, userTel, userEmail, codeID, content, IP, suggestType, suggestSubType, terminalInfo, uploadPictures );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.InsertSuggestMessage Exception:" + ex.Message );
            }
            return _RetVal;
        }
        #endregion
        #region 获取会员相关资料的验证信息12902
        /// <summary>
        /// 获取会员相关资料的验证信息12902
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public static DataSet GetUserBaseInfoForUserVerify( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _DS = _DAL.GetUserBaseInfoForUserVerify( _UserID );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 获取某用户所有绑定类型12903
        /// <summary>
        /// 获取某用户所有绑定类型12903
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns>返回格式：1,2,3</returns>
        public static string GetUserBindTypeList( params object[] para )
        {
            int userID = (int)para[0];
            string _Result = "";
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    DataTable _DT = _DAL.GetUserBindTypeList( userID );
                    _DAL = null;
                    if ( _DT != null && _DT.Rows.Count > 0 )
                    {
                        foreach ( DataRow _DR in _DT.Rows )
                        {
                            _Result += _DR["bindType"].ToString() + ",";
                        }
                        _Result = _Result.TrimEnd( ',' );
                    }
                    _DT = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetUserBindTypeList Exception:" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion
        #region 获取用户最近一条佣金提现申请记录12904
        /// <summary>
        /// 获取用户最近一条佣金提现申请记录12904
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static DataSet GetUserBrokerageApplyLastest( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUserPoints _DAL = new DALUserPoints();
                _DS = _DAL.GetUserBrokerageApplyLastest( _UserID );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 获取会员佣金提现列表记录12905
        /// <summary>
        /// 获取会员佣金提现列表记录12905
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="count">返回总记录数</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterMentionList( out int count, params object[] para )
        {
            DataSet _DS = null;
            count = 0;
            int _UserID = (int)para[0];
            int _FIdx = (int)para[1];
            int _EIdx = (int)para[2];
            DateTime _BeginTime = (DateTime)para[3];
            DateTime _EndTime = (DateTime)para[4];
            int _IsCount = (int)para[5];
            if ( _UserID > 0 && _FIdx > 0 && _EIdx > _FIdx )
            {
                IDALUserPoints _DAL = new DALUserPoints();
                _DS = _DAL.GetMemberCenterMentionList( _UserID, _FIdx, _EIdx, _BeginTime, _EndTime, _IsCount, out count );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 会员佣金直接充值到云购账户12906
        /// <summary>
        /// 会员佣金直接充值到云购账户12906
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="money">充值金额</param>
        /// <returns></returns>
        public static int ApplyUserBrokerageToAccount( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            decimal _Money = (decimal)para[1];
            if ( _UserID > 0 && _Money > 0m )
            {
                IDALUserPoints _DAL = new DALUserPoints();
                _Result = _DAL.ApplyUserBrokerageToAccount( _UserID, _Money );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 会员佣金提现申请12907
        /// <summary>
        /// 会员佣金提现申请12907
        /// 1成功，-1不足100，-2执行失败
        /// </summary>
        /// <param name="userID">int申请者</param>
        /// <param name="money">decimal提现金额</param>
        /// <param name="serviceMoney">decimal手续费</param>
        /// <param name="bankName">string银行名称</param>
        /// <param name="bankUser">string开户者</param>
        /// <param name="bankDetail">string开户支行</param>
        /// <param name="BankAccount">string开户账号</param>
        /// <param name="userTelePho">string联系电话</param>
        /// <returns></returns>
        public static int ApplyUserBrokerageToBank( params object[] para )
        {
            int _Result = -3;
            int _UserID = (int)para[0];
            decimal _Money = (decimal)para[1];
            decimal _ServiceMoney = (decimal)para[2];
            string _BankName = (string)para[3];
            string _BankUser = (string)para[4];
            string _BankDetail = (string)para[5];
            string _BankAccount = (string)para[6];
            string _UserTel = (string)para[7];
            if ( _UserID > 0 )
            {
                IDALUserPoints _DAL = new DALUserPoints();
                _Result = _DAL.ApplyUserBrokerageToBank( _UserID, _Money, _ServiceMoney, _BankName, _BankUser, _BankDetail, _BankAccount, _UserTel );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 会员中心-获取佣金明细列表12908
        /// <summary>
        /// 会员中心-获取佣金明细列表12908
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userID">会员ID</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">总记录数</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterCommissionList( out int count, params object[] para )
        {
            DataSet _DS = null;
            count = 0;
            int _FIdx = (int)para[0];
            int _EIdx = (int)para[1];
            DateTime _BeginTime = (DateTime)para[2];
            DateTime _EndTime = (DateTime)para[3];
            int _UserID = (int)para[4];
            int _IsCount = (int)para[5];
            if ( _UserID > 0 && _FIdx > 0 && _EIdx > _FIdx )
            {
                IDALUserPoints _DAL = new DALUserPoints();
                _DS = _DAL.GetMemberCenterCommissionList( _FIdx, _EIdx, _BeginTime, _EndTime, _UserID, _IsCount, out count );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 获取用户佣金总收入与总提取12909
        /// <summary>
        /// 获取用户佣金总收入与总提取12909
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static DataSet GetUserBrokerageSummary( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUserPoints _DAL = new DALUserPoints();
                _DS = _DAL.GetUserBrokerageSummary( _UserID );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 获取某用户某商品编号的详细云购记录(商品详细页)12910
        /// <summary>
        /// 获取某用户某商品编号的详细云购记录(商品详细页)12910
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="codeID"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public static DataSet GetUserBuyListByCodeID( params object[] para )
        {
            int userID = (int)para[0];
            int codeID = (int)para[1];
            int quantity = (int)para[2];
            DataSet _DS = null;
            if ( userID > 0 && codeID > 0 && quantity > 0 )
            {
                try
                {
                    IDALUserBuy _DAL = new DALUserBuy();
                    _DS = _DAL.GetUserBuyListByCodeID( userID, codeID, quantity );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserBuy.GetUserBuyListByCodeID Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
        #region 检测用户对于某期限购商品的购买情况12911
        /// <summary>
        /// 检测用户对于某期限购商品的购买情况12911
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="codeID">期数ID</param>
        /// <returns></returns>
        public static DataSet CheckLimitBuyForUser( params object[] para )
        {
            int userID = (int)para[0];
            int codeID = (int)para[1];
            DataSet _DS = null;
            try
            {
                IDALBarcode _DAL = new DALBarcode();
                _DS = _DAL.CheckLimitBuyForUser( userID, codeID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Barcode.CheckLimitBuyForUser Ex:" + ex.Message );
            }
            return _DS;
        }

        #endregion
        #region 获取所有商品条码总售出份额12912
        /// <summary>
        /// 获取所有商品条码总售出份额12912
        /// </summary>
        /// <returns></returns>
        public static long GetBarcodeSalesTotal()
        {
            long _Result = 0L;
            try
            {
                IDALUserBuy _DAL = new DALUserBuy();
                _Result = _DAL.GetBarcodeSalesTotal();
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "UserBuy.GetBarcodeSalesTotal抛出异常：" + ex.Message );
            }
            return _Result;
        }
        #endregion
        #region 90天后退购12913
        /// <summary>
        /// 90天后退购12913
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="buyIDs">购买ID</param>
        /// <returns></returns>
        public static int RefundUserBuyAfter90( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            string _BuyIDs = (string)para[1];
            if ( _UserID > 0 && _BuyIDs != "" )
            {
                IDALUserBuy _DAL = new DALUserBuy();
                _Result = _DAL.RefundUserBuyAfter90( _UserID, _BuyIDs );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 获取离指定的云购码最接近的幸运云购码12914
        /// <summary>
        /// 获取离指定的云购码最接近的幸运云购码12914
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <param name="rnoNum">指定的云购码</param>
        /// <returns></returns>
        public static int GetNearestRno( params object[] para )
        {
            int codeID = (int)para[0];
            int rnoNum = (int)para[1];
            int _RNO = 0;
            if ( codeID > 0 )
            {
                try
                {
                    IDALUserBuy _DAL = new DALUserBuy();
                    _RNO = _DAL.GetNearestRno( codeID, rnoNum );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserBuy.GetNearestRno Exception:" + ex.Message );
                }
            }
            return _RNO;
        }
        #endregion
        #region 根据buyID获取相应的云购码12915
        /// <summary>
        /// 根据buyID获取相应的云购码12915
        /// </summary>
        /// <param name="codeID"></param>
        /// <param name="buyID"></param>
        /// <returns></returns>
        public static DataSet GetUserBuyCodeByBuyid( params object[] para )
        {
            int codeID = (int)para[0];
            int buyID = (int)para[1];
            DataSet _DS = null;
            if ( codeID > 0 && buyID > 0 )
            {
                try
                {
                    IDALUserBuy _DAL = new DALUserBuy();
                    _DS = _DAL.GetUserBuyCodeByBuyid( codeID, buyID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserBuy.GetBarcodeSalesTotal抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
        #region  添加交易记录(云购)12916
        /// <summary>
        /// 添加交易记录(云购)12916
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="payBalance">是否启用余额</param>
        /// <param name="shopID">购物车ID</param>
        /// <param name="shopKey">购物车Key</param>
        /// <param name="points">福分</param>
        /// <param name="payDevice">提交终端(PC:0 手机:1)</param>
        /// <param name="payIP">支付者IP地址</param>
        /// <returns></returns>
        public static int InsertUserCartPaymentRecord( params object[] para )
        {
            int userID = (int)para[0];
            int payBalance = (int)para[1];
            long shopID = (long)para[2];
            string shopKey = (string)para[3];
            long points = (long)para[4];
            byte payDevice = (byte)para[5];
            string payIP = (string)para[6];
            int payBroker = 0;
            if ( para.Length == 8 )
            {
                payBroker = (int)para[7];
            }

            //保证非负数
            points = points > 0L ? points : 0L;
            payBroker = payBroker > 0 ? payBroker : 0;

            int _Result = 0;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.InsertUserCartPaymentRecord( userID, payBalance, shopID, shopKey, points, payDevice, payIP, payBroker );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.InsertUserCartPaymentRecord抛出异常：" + ex.Message );
            }
            return _Result;
        }
        #endregion
        #region 删除收货地址信息，默认地址不可删除12918
        /// <summary>
        /// 删除收货地址信息，默认地址不可删除12918
        /// </summary>
        /// <param name="contactID">地址ID号</param>
        /// <param name="userID">会员ID号</param>
        /// <returns></returns>
        public static int DeleteUserContact( params object[] para )
        {
            int _Result = 0;
            int _ContactID = (int)para[0];
            int _UserID = (int)para[1];
            if ( _ContactID > 0 && _UserID > 0 )
            {
                IDALUserContact _DAL = new DALUserContact();
                _Result = _DAL.DeleteUserContact( _ContactID, _UserID );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 获取某会员的收货地址数量12919
        /// <summary>
        /// 获取某会员的收货地址数量12919
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public static int GetUserContactCount( params object[] para )
        {
            int _Count = 0;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUserContact _DAL = new DALUserContact();
                _Count = _DAL.GetUserContactCount( _UserID );
                _DAL = null;
            }
            return _Count;
        }
        #endregion
        #region 获取收货地址信息12920
        /// <summary>
        /// 获取收货地址信息12920
        /// </summary>
        /// <param name="contactID">地址ID</param>
        /// <returns></returns>
        public static DataSet GetUserContactInfoByID( params object[] para )
        {
            DataSet _DS = null;
            int _ContactID = (int)para[0];
            if ( _ContactID > 0 )
            {
                IDALUserContact _DAL = new DALUserContact();
                _DS = _DAL.GetUserContactInfoByID( _ContactID );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 获取某会员收货地址列表信息12921
        /// <summary>
        /// 获取某会员收货地址列表信息12921
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public static DataSet GetUserContactListByID( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUserContact _DAL = new DALUserContact();
                _DS = _DAL.GetUserContactListByID( _UserID );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 添加收货地址信息12922
        /// <summary>
        /// 添加收货地址信息12922
        /// </summary>
        /// <param name="userID">int会员ID</param>
        /// <param name="userName">string收货人姓名</param>
        /// <param name="areaID">int所在区ID</param>
        /// <param name="streetID">int所在街道ID</param>
        /// <param name="address">string收货地址</param>
        /// <param name="zip">string邮编</param>
        /// <param name="mobile">string手机号</param>
        /// <param name="tel">string联系电话</param>
        /// <param name="isDefault">bool是否默认地址</param>
        /// <returns></returns>
        public static int AddNewUserContact( params object[] para )
        {
            int _ID = 0;
            int _UserID = (int)para[0];
            string _UserName = (string)para[1];
            int _AreaID = (int)para[2];
            int _StreetID = (int)para[3];
            string _Address = (string)para[4];
            string _Zip = (string)para[5];
            string _Mobile = (string)para[6];
            string _Tel = (string)para[7];
            bool _IsDefault = (bool)para[8];
            if ( _UserID > 0 && _UserName != "" && _AreaID > 0 && _Address != "" && ( _Mobile != "" || _Tel != "" ) )
            {
                IDALUserContact _DAL = new DALUserContact();
                _ID = _DAL.AddNewUserContact( _UserID, _UserName, _AreaID, _StreetID, _Address, _Zip, _Mobile, _Tel, _IsDefault );
                _DAL = null;
            }
            return _ID;
        }
        #endregion
        #region 修改收货地址信息12923
        /// <summary>
        /// 修改收货地址信息12923
        /// </summary>
        /// <param name="contactID">ID</param>
        /// <param name="userID">会员ID</param>
        /// <param name="userName">收货人姓名</param>
        /// <param name="areaID">所在区ID</param>
        /// <param name="streetID">所在街道ID</param>
        /// <param name="address">收货地址</param>
        /// <param name="zip">邮编</param>
        /// <param name="mobile">手机号</param>
        /// <param name="tel">联系电话</param>
        /// <param name="isDefault">是否默认地址</param>
        /// <returns></returns>
        public static int UpdateUserContact( params object[] para )
        {
            int _Result = 0;
            int _ContactID = (int)para[0];
            int _UserID = (int)para[1];
            string _UserName = (string)para[2];
            int _AreaID = (int)para[3];
            int _StreetID = (int)para[4];
            string _Address = (string)para[5];
            string _Zip = (string)para[6];
            string _Mobile = (string)para[7];
            string _Tel = (string)para[8];
            bool _IsDefault = (bool)para[9];
            if ( _ContactID > 0 && _UserID > 0 && _UserName != "" && _AreaID > 0 && _Address != "" && ( _Mobile != "" || _Tel != "" ) )
            {
                IDALUserContact _DAL = new DALUserContact();
                _Result = _DAL.UpdateUserContact( _ContactID, _UserID, _UserName, _AreaID, _StreetID, _Address, _Zip, _Mobile, _Tel, _IsDefault );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 修改收货地址是否为默认地址12924
        /// <summary>
        /// 修改收货地址是否为默认地址12924
        /// </summary>
        /// <param name="contactID">地址ID号</param>
        /// <param name="userID">会员ID号</param>
        /// <returns></returns>
        public static int UpdateUserContactDefault( params object[] para )
        {
            int _Result = 0;
            int _ContactID = (int)para[0];
            int _UserID = (int)para[1];
            if ( _ContactID > 0 && _UserID > 0 )
            {
                IDALUserContact _DAL = new DALUserContact();
                _Result = _DAL.UpdateUserContactDefault( _ContactID, _UserID );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 审核申请好友的验证信息 - 忽略验证信息12925
        /// <summary>
        /// 审核申请好友的验证信息 - 忽略验证信息12925
        /// -1: 操作失败;  1:操作成功
        /// </summary>
        /// <param name="applyID">申请ID，等于0时清空所有</param>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static int DeleteUserFriendApply( params object[] para )
        {
            int _Result = 0;
            int _ApplyID = (int)para[0];
            int _UserID = (int)para[1];
            if ( _ApplyID >= 0 && _UserID > 0 )//0:忽略全部
            {
                IDALUserFriends _DAL = new DALUserFriends();
                _Result = _DAL.DeleteUserFriendApply( _ApplyID, _UserID );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 获取会员好友请求信息数量12926
        /// <summary>
        /// 获取会员好友请求信息数量12926
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static int GetUserFriendApplyTotalByUser( params object[] para )
        {
            int _Count = 0;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUserFriends _DAL = new DALUserFriends();
                _Count = _DAL.GetUserFriendApplyTotalByUser( _UserID );
                _DAL = null;
            }
            return _Count;
        }
        #endregion
        #region 审核申请好友的验证信息 - 同意加为好友12927
        /// <summary>
        /// 审核申请好友的验证信息 - 同意加为好友12927
        /// -1: 操作失败;  1:操作成功
        /// </summary>
        /// <param name="applyID">申请ID</param>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static int CheckUserFriendApply( params object[] para )
        {
            int _Result = 0;
            int _ApplyID = (int)para[0];
            int _UserID = (int)para[1];
            if ( _ApplyID > 0 && _UserID > 0 )
            {
                IDALUserFriends _DAL = new DALUserFriends();
                string _ApplyUserIDStr = "";
                _Result = _DAL.CheckUserFriendApply( _ApplyID, _UserID, out _ApplyUserIDStr );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 批量审核申请好友的验证信息 - 同意加为好友1292701
        /// <summary>
        /// 批量审核申请好友的验证信息 - 同意加为好友1292701
        /// -1: 操作失败;  1:操作成功
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static DataSet CheckAllUserFriendApply( params object[] para )
        {
            DataSet _Result = null;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )//0：通过全部
            {
                IDALUserFriends _DAL = new DALUserFriends();
                _Result = _DAL.CheckUserAllFriendApply( _UserID );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 删除会员的好友记录，成功则返回影响 2 行12928
        /// <summary>
        /// 删除会员的好友记录，成功则返回影响 2 行12928
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="friendID">好友ID</param>
        /// <returns></returns>
        public static int DeleteUserFriendLink( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            int _FriendID = (int)para[1];
            if ( _UserID > 0 && _FriendID > 0 )
            {
                IDALUserFriends _DAL = new DALUserFriends();
                _Result = _DAL.DeleteUserFriendLink( _UserID, _FriendID );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 会员中心 - 获取会员好友数量12930
        /// <summary>
        /// 会员中心 - 获取会员好友数量12930
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static int GetUserFriendLinkTotalByUser( params object[] para )
        {
            int _Count = 0;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUserFriends _DAL = new DALUserFriends();
                _Count = _DAL.GetUserFriendLinkTotalByUser( _UserID );
                _DAL = null;
            }
            return _Count;
        }
        #endregion
        #region 查询会员余额12933
        /// <summary>
        /// 查询会员余额12933
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static decimal GetUserBalance( params object[] para )
        {
            decimal _Balance = 0m;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _Balance = _DAL.GetUserBalance( _UserID );
                _DAL = null;
            }
            return _Balance;
        }
        #endregion
        #region 获取会员登录后的相关信息12934
        /// <summary>
        /// 会员登录后获取相关信息12934
        /// UserID,UserName,UserMobile,UserEmail,UserPhoto,UserWeb,userPrevTime,UserBirthAreaName,UserExperience
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public static DataSet GetUserCachedInfo( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _DS = _DAL.GetUserCachedInfo( _UserID );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 获取会员ID号12935
        /// <summary>
        /// 获取会员ID号12935
        /// </summary>
        /// <param name="str">手机号、Email、昵称任一项</param>
        /// <returns></returns>
        public static int GetUserIDByStr( params object[] para )
        {
            int _UserID = 0;
            string _Str = (string)para[0];
            if ( !UtilityFun.IsEmptyString( _Str ) )
            {
                IDALUsers _DAL = new DALUsers();
                _UserID = _DAL.GetUserIDByStr( _Str );
                _DAL = null;
            }
            return _UserID;
        }
        #endregion
        #region 根据主页标识获取会员ID号12936
        /// <summary>
        /// 根据主页标识获取会员ID号12936
        /// </summary>
        /// <param name="userWeb">会员主页标识</param>
        /// <returns></returns>
        public static int GetUserIDByUserWeb( params object[] para )
        {
            int _UserID = 0;
            string _UserWeb = (string)para[0];
            if ( !UtilityFun.IsEmptyString( _UserWeb ) )
            {
                IDALUsers _DAL = new DALUsers();
                _UserID = _DAL.GetUserIDByUserWeb( _UserWeb );
                _DAL = null;
            }
            return _UserID;
        }
        #endregion
        #region 查询会员的key12937
        /// <summary>
        /// 查询会员的key12937
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public static string GetUserKey( params object[] para )
        {
            string _Key = "";
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _Key = _DAL.GetUserKey( _UserID );
                _DAL = null;
            }
            return _Key;
        }
        #endregion
        #region 会员登录12938
        /// <summary>
        /// 会员登录12938
        /// 返回值
        /// >0 登录成功，userID
        /// -1 密码错误
        /// -2 用户名不存在
        /// -3 用户被禁
        /// -4 用户未激活
        /// -5 帐号异常被禁，可通过取回密码解除
        /// </summary>
        /// <param name="userMobile">手机号</param>
        /// <param name="userEmail">邮箱</param>
        /// <param name="userPwd">密码</param>
        /// <param name="userLastIP">最近登录IP</param>
        /// <param name="loginDevice">登录平台</param>
        /// <returns></returns>
        public static int LoginUser( params object[] para )
        {
            string userMobile = (string)para[0];
            string userEmail = (string)para[1];
            string userPwd = (string)para[2];
            string userLastIP = (string)para[3];
            int loginDevice = (int)para[4];
            int _Result = 0;
            if ( ( !UtilityFun.IsEmptyString( userMobile ) || !UtilityFun.IsEmptyString( userEmail ) ) && !UtilityFun.IsEmptyString( userPwd ) )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Result = _DAL.LoginUser( userMobile, userEmail, userPwd, userLastIP, loginDevice, 0 );
                    _DAL = null;

                    if ( _Result < 0 )
                    {
                        UtilityFile.AddLogErrMsg( "userlogin", string.Format( "mobile:{0},email:{1},ip:{2},device:{3},retVal:{4}", userMobile, userEmail, userLastIP, loginDevice, _Result ) );
                    }
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.LoginUser抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion
        #region 检测用户账号密码是否正确 非登录业务1293801
        /// <summary>
        /// 检测用户账号密码是否正确 非登录业务1293801
        /// 返回值
        /// >0 存在用户，userID
        /// -1 密码错误
        /// -2 用户名不存在
        /// -3 用户被禁
        /// -4 用户未激活
        /// -5 帐号异常被禁，可通过取回密码解除
        /// </summary>
        /// <param name="userMobile">手机号,邮箱</param>
        /// <param name="userPwd">密码</param>
        /// <returns></returns>
        public static int CheckUserAccount( params object[] para )
        {
            string userAccount = (string)para[0];
            string userPwd = (string)para[1];
            int _Result = 0;
            if ( !UtilityFun.IsEmptyString( userAccount ) && !UtilityFun.IsEmptyString( userPwd ) )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    string _UserMobile = "", _UserEmail = "";
                    if ( userAccount.Contains( "@" ) )
                    {
                        _UserEmail = userAccount;
                    }
                    else
                    {
                        _UserMobile = userAccount;
                    }
                    _Result = _DAL.LoginUser( _UserMobile, _UserEmail, userPwd, "", 0, 1 );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.CheckUserAccount抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion
        #region 记录登录日志，针对第三方快速登录的12939
        /// <summary>
        /// 记录登录日志，针对第三方快速登录的12939
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="userLastIP">最近登录IP</param>
        /// <param name="loginDevice">登录平台</param>
        /// <returns></returns>
        public static int InsertUserLoginLog( params object[] para )
        {
            int userID = (int)para[0];
            string userLastIP = (string)para[1];
            int loginDevice = (int)para[2];
            int _Result = 0;
            if ( userID > 0 && userLastIP != "" )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Result = _DAL.InsertUserLoginLog( userID, userLastIP, loginDevice ) ? 1 : 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.InsertUserLoginLog抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion
        #region 删除会员系统信息记录12940
        /// <summary>
        /// 删除会员系统信息记录12940
        /// </summary>
        /// <param name="msgID">信息ID</param>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public static int DeleteUserMessage( params object[] para )
        {
            int _Result = 0;
            int _MsgID = (int)para[0];
            int _UserID = (int)para[1];
            if ( _MsgID > 0 && _UserID > 0 )
            {
                IDALUserMsg _DAL = new DALUserMsg();
                _Result = _DAL.DeleteUserMessage( _MsgID, _UserID );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 删除会员全部系统信息记录12941
        /// <summary>
        /// 删除会员全部系统信息记录12941
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static int DeleteUserMessageAll( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUserMsg _DAL = new DALUserMsg();
                _Result = _DAL.DeleteUserMessageAll( _UserID );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 添加会员系统信息记录12942
        /// <summary>
        /// 添加会员系统信息记录12942
        /// </summary>
        /// <param name="userID">接收会员ID</param>
        /// <param name="msgContent">信息内容</param>
        /// <param name="msgTime">发送时间</param>
        /// <param name="msgType">0:系统产生  1：后台管理员所发</param>
        /// <returns></returns>
        public static int InsertUserMessage( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            string _MsgContent = (string)para[1];
            DateTime _MsgTime = (DateTime)para[2];
            int _MsgType = (int)para[3];
            if ( _UserID > 0 && _MsgContent != "" )
            {
                IDALUserMsg _DAL = new DALUserMsg();
                _Result = _DAL.InsertUserMessage( _UserID, _MsgContent, _MsgTime, _MsgType );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 检查昵称是否存在12943
        /// <summary>
        /// 检查昵称是否存在12943
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="nickName">昵称</param>
        /// <returns>1存在，0不存在</returns>
        public static int CheckNickName( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            string _NickName = (string)para[1];
            IDALUsers _DAL = new DALUsers();
            _Result = _DAL.CheckNickName( _UserID, _NickName );
            _DAL = null;
            return _Result;
        }
        #endregion
        #region 获取用户福分12944
        /// <summary>
        /// 获取用户福分12944
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static long GetUserPointsByUserID( params object[] para )
        {
            long _Points = 0L;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUserPoints _DAL = new DALUserPoints();
                _Points = _DAL.GetUserPointsByUserId( _UserID );
                _DAL = null;
            }
            return _Points;
        }
        #endregion
        #region 用户福分详细信息列表12945
        /// <summary>
        /// 用户福分详细信息列表12945
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">截止序号</param>
        /// <param name="BeginTime">开始时间</param>
        /// <param name="EndTime">结束时间</param>
        /// <param name="IsCount">是否返回总记录数 0：不返回，1：返回</param>
        /// <returns></returns>
        public static DataSet GetUserPointsLogPageList( out int totalCount, params object[] para )
        {
            DataSet _DS = null;
            totalCount = 0;
            int _UserID = (int)para[0];
            int _FIdx = (int)para[1];
            int _EIdx = (int)para[2];
            DateTime _BeginTime = (DateTime)para[3];
            DateTime _EndTime = (DateTime)para[4];
            int _IsCount = (int)para[5];
            if ( _UserID > 0 && _FIdx > 0 && _EIdx > _FIdx )
            {
                IDALUserPoints _DAL = new DALUserPoints();
                _DS = _DAL.GetUserPointsLogPageList( _UserID, _FIdx, _EIdx, _BeginTime, _EndTime, _IsCount, out totalCount );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 更新用户福分\日志12947
        /// <summary>
        /// 更新用户福分\日志12947
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="pointNum">福分值</param>
        /// <param name="logType">福分日志类型</param>
        /// <param name="logTime">记录日志时间</param>
        /// <param name="refrenceID">福分来源ID</param>
        /// <param name="logDesc">日志描述</param>
        /// <returns></returns>
        public static int UpdateUserPoints( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            int _PointNum = (int)para[1];
            int _LogType = (int)para[2];
            DateTime _LogTime = (DateTime)para[3];
            int _RefrenceID = (int)para[4];
            string _LogDesc = (string)para[5];
            try
            {
                IDALUserPoints _DAL = new DALUserPoints();
                _Result = _DAL.UpdateUserPoints( _UserID, _PointNum, _LogType, _LogTime, _RefrenceID, _LogDesc );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "UserPoints.UserPointsUpdatePoint抛出异常：" + ex.Message );
            }
            return _Result;
        }
        #endregion
        #region 屏蔽某私信记录12948
        /// <summary>
        /// 屏蔽某私信记录12948
        /// </summary>
        /// <param name="msgID">消息ID</param>
        /// <param name="userID">接收会员ID</param>
        /// <param name="oppUserID">会话对方会员ID</param>
        /// <returns></returns>
        public static int DeleteUserPrivMsg( params object[] para )
        {
            int _Result = 0;
            int _MsgID = (int)para[0];
            int _UserID = (int)para[1];
            int _OppUserID = (int)para[2];
            if ( _MsgID > 0 && _UserID > 0 && _OppUserID > 0 )
            {
                IDALUserMsg _DAL = new DALUserMsg();
                _Result = _DAL.DeleteUserPrivMsg( _MsgID, _UserID, _OppUserID );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 清空某好友所有私信记录12949
        /// <summary>
        /// 清空某好友所有私信记录12949
        /// </summary>
        /// <param name="userID">接收会员ID</param>
        /// <param name="senderUserID">发送会员ID</param>
        /// <returns></returns>
        public static int DeleteUserPrivMsgHead( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            int _SenderUserID = (int)para[1];
            if ( _UserID > 0 && _SenderUserID > 0 )
            {
                IDALUserMsg _DAL = new DALUserMsg();
                _Result = _DAL.DeleteUserPrivMsgHead( _UserID, _SenderUserID );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 清空会员所有私信记录12950
        /// <summary>
        /// 清空会员所有私信记录12950
        /// </summary>
        /// <param name="userID">接收会员ID</param>
        /// <returns></returns>
        public static int DeleteUserPrivMsgHeadAll( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUserMsg _DAL = new DALUserMsg();
                _Result = _DAL.DeleteUserPrivMsgHeadAll( _UserID );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 给会员发送私信12951
        /// <summary>
        /// 给会员发送私信12951
        /// -2  禁止任何人发私信
        /// -1  只接受好友的私信
        ///  0  失败
        ///  1  成功
        /// </summary>
        /// <param name="inceptUserID">接收方ID</param>
        /// <param name="senderUserID">发送者ID</param>
        /// <param name="content">私信内容</param>
        /// <returns></returns>
        public static int InsertUserPrivMsg( params object[] para )
        {
            int _Result = -3;
            int _InceptUserID = (int)para[0];
            int _SenderUserID = (int)para[1];
            string _Content = (string)para[2];
            if ( _InceptUserID > 0 && _SenderUserID > 0 && _Content != "" )
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.InsertUserPrivMsg( _InceptUserID, _SenderUserID, _Content );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 检测发送者是否可以发私信给接收者12952
        /// <summary>
        /// 检测发送者是否可以发私信给接收者12952
        /// </summary>
        /// <param name="senderUserID">发送者ID</param>
        /// <param name="inceptUserID">接收者ID</param>
        /// <returns></returns>
        public static int CheckUserPrivMsgSend( params object[] para )
        {
            int _Result = 0;
            int _SenderUserID = (int)para[0];
            int _InceptUserID = (int)para[1];
            if ( _SenderUserID > 0 && _InceptUserID > 0 )
            {
                IDALUserMsg _DAL = new DALUserMsg();
                _Result = _DAL.CheckUserPrivMsgSend( _SenderUserID, _InceptUserID );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region  添加交易记录(充值)12953
        /// <summary>
        /// 添加交易记录(充值)
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="payMoney">金额</param>
        /// <param name="shopID">购物车ID</param>
        /// <param name="shopKey">购物车Key</param>
        /// <param name="payDevice">提交终端(PC:0 手机:1)</param>
        /// <param name="payIP">支付者IP地址</param>
        /// <param name="payBalance">是否使用余额：0 未使用 1 使用</param>
        /// <param name="payCodeID">当是云购平台时，对应 barcode表的ID，当是直播平台时，是对应wishbarcode的ID</param>
        /// <param name="payPoint">使用的福分</param>
        /// <param name="payBroker">使用的佣金</param>
        /// <param name="paySource">充值发起源 空或0：云购平台 1：直播平台 其它待定</param>
        /// <returns></returns>
        public static int InsertUserRechargePaymentRecord( params object[] para )
        {
            int userID = (int)para[0];
            decimal payMoney = (decimal)para[1];
            long shopID = (long)para[2];
            string shopKey = (string)para[3];
            byte payDevice = (byte)para[4];
            string payIP = (string)para[5];
            int payBalance = 0;
            int payCodeID = 0;
            int payPoint = 0;
            int payBroker = 0;
            int paySource = 0;
            if ( para.Length > 6 )
            {
                payBalance = (int)para[6];
                payCodeID = (int)para[7];
                payPoint = (int)para[8];
                payBroker = (int)para[9];
                paySource = (int)para[10];
            }
            int _Result = 0;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.InsertUserRechargePaymentRecord( userID, payMoney, shopID, shopKey, payDevice, payIP, payBalance, payCodeID, payPoint, payBroker, paySource ) ? 1 : 0;
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.InsertUserRechargePaymentRecord抛出异常：" + ex.Message );
            }
            return _Result;
        }
        #endregion
        #region 会员注册12954
        /// <summary>
        /// 会员注册12954
        /// </summary>
        /// <param name="userMobile">手机号</param>
        /// <param name="userEmail">邮箱</param>
        /// <param name="userName">昵称</param>
        /// <param name="userPwd">加密密码</param>
        /// <param name="userKey">密钥</param>
        /// <param name="userBlance">余额</param>
        /// <param name="userRegIP">注册IP</param>
        /// <param name="inviteUserID">邀请人ID</param>
        /// <param name="marketUserID"></param>
        /// <param name="userRegSource">注册来源平台:0.未知来源平台 1.PC 2.微信 3.Android手机 4.IOS 5.触屏</param>
        /// <returns></returns>
        public static int InsertUser( params object[] para )
        {
            string userMobile = (string)para[0];
            string userEmail = (string)para[1];
            string userName = (string)para[2];
            string userPwd = (string)para[3];
            string userKey = (string)para[4];
            decimal userBlance = (decimal)para[5];
            string userRegIP = (string)para[6];
            int inviteUserID = (int)para[7];
            int marketUserID = (int)para[8];
            int userRegSource = 0;
            if ( para.Length > 9 )
            {
                userRegSource = (int)para[9];
            }
            int _UserID = 0;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _UserID = _DAL.InsertUser( userMobile, userEmail, userName, userPwd, userKey,
                    userBlance, userRegIP, inviteUserID, marketUserID, userRegSource );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.InsertUser抛出异常：" + ex.Message );
            }
            return _UserID;
        }
        #endregion
        #region 获取会员绑定类型(旧的解决方案)12955
        /// <summary>
        /// 获取会员绑定类型 0本站 1电信云密保12955
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static int GetUserBindTypeByID( params object[] para )
        {
            int userID = (int)para[0];
            int _BindType = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _BindType = _DAL.GetUserBindTypeByID( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetUserBindTypeByID抛出异常：" + ex.Message );
                }
            }
            return _BindType;
        }
        #endregion
        #region 获取会员隐私设置[云购记录、获得的商品、晒单记录]12956
        /// <summary>
        /// 获取会员隐私设置[云购记录、获得的商品、晒单记录]12956
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static DataSet GetUserPrivSetByID( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _DS = _DAL.GetUserPrivSetByID( _UserID );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 获取userForbid 12957
        /// <summary>
        /// 获取userForbid 12957
        /// -1 不存在此会员
        /// 0：正常
        /// 1：帐户被冻结
        /// 2: 刚注册未激活
        /// 3: 帐号异常被禁，可通过取回密码解除
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static int GetUserForbid( params object[] para )
        {
            int userID = (int)para[0];
            int _Forbid = -1;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Forbid = _DAL.GetUserForbid( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetUserForbid抛出异常：" + ex.Message );
                }
            }
            return _Forbid;
        }
        #endregion
        #region 会员首页-检测会员是否已签到12958
        /// <summary>
        /// 会员首页-检测会员是否已签到12958
        /// -1 未签到; 1 已经签到
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static int CheckUserSign( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.CheckUserSign( _UserID );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 会员中心 - 签到12959
        /// <summary>
        /// 会员中心 - 签到12959
        /// 1 签到成功;0 签到失败;-1 已经签到
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static int InsertUserSignLog( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.InsertUserSignLog( _UserID );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 更新会员昵称与绑定类型值12960
        /// <summary>
        /// 更新会员昵称与绑定类型值12960
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="userName">用户名称</param>
        /// <param name="bindType">绑定类型</param>
        /// <returns>1成功   -1失败</returns>
        public static int UpdateYmbUserByID( params object[] para )
        {
            int userID = (int)para[0];
            string userName = (string)para[1];
            int bindType = (int)para[2];
            int _Result = -1;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Result = _DAL.UpdateYmbUserByID( userID, userName, bindType );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.UpdateYmbUserByID抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion
        #region 更新会员帐户状态12961
        /// <summary>
        /// 更新会员帐户状态12961
        /// </summary>
        /// <param name="userID">会员ID号</param>
        /// <param name="forbid">状态值
        /// 0：正常
        /// 1：帐户被冻结
        /// 2: 刚注册未激活
        /// 3: 帐号异常被禁，可通过取回密码解除
        /// </param>
        /// <param name="unForbidTime">解冻时间</param>
        /// <param name="reason">解冻原因</param>
        /// <returns></returns>
        public static int UpdateUserForbid( params object[] para )
        {
            int userID = (int)para[0];
            int forbid = (int)para[1];
            DateTime unForbidTime = (DateTime)para[2];
            string reason = (string)para[3];
            int _Result = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Result = _DAL.UpdateUserForbid( userID, forbid, unForbidTime, reason ) ? 1 : 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.UpdateUserForbid抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion
        #region 会员中心 - 隐私设置12962
        /// <summary>
        /// 会员中心 - 隐私设置12962
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="userPrivMsgSet">私信设置值</param>
        /// <param name="userAreaSet">地理位置设置值</param>
        /// <param name="userSearchSet">是否允许搜索设置值</param>
        /// <param name="buySet">云购记录设置值</param>
        /// <param name="rafSet">获得商品设置值</param>
        /// <param name="postSet">晒单设置值</param>
        /// <param name="buyShowNum">云购记录显示数量</param>
        /// <param name="rafShowNum">获得商品显示数量</param>
        /// <param name="pastShowNum">晒单显示数量</param>
        /// <returns></returns>
        public static int UpdateUserPrivSet( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            int _UserPrivMsgSet = (int)para[1];
            int _UserAreaSet = (int)para[2];
            int _UserSearchSet = (int)para[3];
            int _BuySet = (int)para[4];
            int _RafSet = (int)para[5];
            int _PostSet = (int)para[6];
            int _BuyShowNum = (int)para[7];
            int _RafShowNum = (int)para[8];
            int _PostShowNum = (int)para[9];
            if ( _UserID > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.UpdateUserPrivSet( _UserID, _UserPrivMsgSet, _UserAreaSet, _UserSearchSet, _BuySet, _RafSet, _PostSet, _BuyShowNum, _RafShowNum, _PostShowNum );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 修改会员Key12963
        /// <summary>
        /// 修改会员Key12963
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        public static int UpdateUserKey( params object[] para )
        {
            int _Result = 0;
            int userID = (int)para[0];
            string key = (string)para[1];
            if ( userID > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.UpdateUserKey( userID, key );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 更新会员密码12964
        /// <summary>
        /// 更新会员密码,只能更新forbid为0,3状态会员12964
        /// </summary>
        /// <param name="userID">会员ID号</param>
        /// <param name="password">密码对应的密文(sha1)</param>
        /// <returns></returns>
        public static int UpdateUserPassword( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            string _Password = (string)para[1];
            if ( _UserID > 0 && !UtilityFun.IsEmptyString( _Password ) )
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.UpdateUserPassword( _UserID, _Password );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 会员中心-修改会员头像12965
        /// <summary>
        /// 会员中心-修改会员头像12965
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="userPhoto">用户头像名称</param>
        /// <returns></returns>
        public static int UpdateMemberCenterForUserPhoto( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            string _UserPhoto = (string)para[1];
            if ( _UserID > 0 && _UserPhoto != "" )
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.UpdateMemberCenterForUserPhoto( _UserID, _UserPhoto );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 返回本周人气排行商品信息12966
        /// <summary>
        /// 返回本周人气排行商品信息12966
        /// </summary>
        /// <param name="quantity">获取数目</param>
        /// <returns></returns>
        public static DataSet GetUserBuyForWeekRanking( params object[] para )
        {
            int quantity = (int)para[0];
            DataSet _DS = null;
            if ( quantity > 0 )
            {
                try
                {
                    DALUserBuy _DAL = new DALUserBuy();
                    _DS = _DAL.GetUserBuyForWeekRanking( quantity );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserBuy.GetUserBuyForWeekRanking Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
        #region 插入申请加为好友的验证信息12967
        /// <summary>
        /// 插入申请加为好友的验证信息12967
        /// </summary>
        /// <param name="userID">申请者ID</param>
        /// <param name="applyUserID">被申请者ID</param>
        /// <returns></returns>
        public static int InsertUserFriendApply( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            int _ApplyUserID = (int)para[1];
            if ( _UserID > 0 && _ApplyUserID > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.InsertUserFriendApply( _UserID, _ApplyUserID );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 手机版清除会员所有消息[系统、好友申请、私信]12969
        /// <summary>
        /// 手机版清除会员所有消息12969
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static int ClearUserAllMessage( params object[] para )
        {
            int userID = (int)para[0];
            int _Result = 0;
            try
            {
                IDALUserMsg _DAL = new DALUserMsg();
                _Result = _DAL.ClearUserAllMessage( userID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "UserMsg.ClearUserAllMessage Ex:" + ex.Message );
            }
            return _Result;
        }
        #endregion

    }
}
