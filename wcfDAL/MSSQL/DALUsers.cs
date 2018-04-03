using System;
using System.Data;

namespace wcfNSYGShop
{
    public class DALUsers : DALBase, IDALUsers
    {
        #region 会员注册
        /// <summary>
        /// 会员注册
        /// </summary>
        /// <param name="userMobile">手机号</param>
        /// <param name="userEmail">邮箱</param>
        /// <param name="userName">昵称</param>
        /// <param name="userPwd">加密密码</param>
        /// <param name="userKey">密钥</param>
        /// <param name="userBlance">余额</param>
        /// <param name="userRegIP">注册IP</param>
        /// <param name="inviteUserID">邀请人ID</param>
        /// <param name="userRegSource">注册来源平台:0.未知来源平台 1.PC 2.微信 3.Android手机 4.IOS 5.触屏</param>
        /// <returns></returns>
        public int InsertUser( string userMobile, string userEmail, string userName, string userPwd, string userKey,
            decimal userBlance, string userRegIP, int inviteUserID, int marketUserID, int userRegSource )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12954" );
            Para.AddOrcNewInParameter( "i_userMobile", userMobile );
            Para.AddOrcNewInParameter( "i_userEmail", userEmail );
            Para.AddOrcNewInParameter( "i_userPwd", userPwd );
            Para.AddOrcNewInParameter( "i_userKey", userKey );
            Para.AddOrcNewInParameter( "i_userBalance", userBlance );
            Para.AddOrcNewInParameter( "i_userRegIP", userRegIP );
            Para.AddOrcNewInParameter( "i_userLastIP", userRegIP );
            Para.AddOrcNewInParameter( "i_userName", userName );
            Para.AddOrcNewInParameter( "i_inviteUserID", inviteUserID );
            Para.AddOrcNewInParameter( "i_marketUserID", marketUserID );
            Para.AddOrcNewInParameter( "i_userRegSource", userRegSource );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_addUserRegister" );//pro_UserRegister
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 登录
        /// <summary>
        /// 登录 返回值 &gt;0 登录成功，userID
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
        /// <param name="loginDevice">
        /// 两位数组合（平台+登录方式） 十位 个位 1.PC 0.普通账号登录 2.触屏 1.QQ快速登录 3.安卓 2.微信快速登录 4.微信 5.苹果
        /// </param>
        /// <param name="isCheckOnly">是否只是检测账号密码</param>
        /// <returns></returns>
        public int LoginUser( string userMobile, string userEmail, string userPwd, string userLastIP, int loginDevice, int isCheckOnly )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewInParameter( "i_module", "12938" );
            Para.AddOrcNewInParameter( "i_userMobile", userMobile );
            Para.AddOrcNewInParameter( "i_userEmail", userEmail );
            Para.AddOrcNewInParameter( "i_userPwd", userPwd );
            Para.AddOrcNewInParameter( "i_userLastIP", userLastIP );
            Para.AddOrcNewInParameter( "i_loginDevice", loginDevice );
            Para.AddOrcNewInParameter( "i_isCheck", isCheckOnly );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_chkUserLogin" );//pro_UserLogin
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            //if ( _RetVal < 1 )
            //{
            //string _Para = string.Format( "userMobile:{0},userEmail:{1},userPwd:{2},userLastIP:{3},loginDevice:{4},isCheckOnly:{5}", userMobile, userEmail, userPwd, userLastIP, loginDevice, isCheckOnly );
            //    AddFailLog( _RetVal );
            //}
            return _RetVal;
        }
        #endregion

        #region 记录登录日志
        /// <summary>
        /// 记录登录日志，针对第三方快速登录的
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="userLastIP"></param>
        /// <param name="loginDevice">
        /// 两位数组合（平台+登录方式） 十位 个位 1.PC 0.普通账号登录 2.触屏 1.QQ快速登录 3.安卓 2.微信快速登录 4.微信 5.苹果
        /// </param>
        /// <returns></returns>
        public bool InsertUserLoginLog( int userID, string userLastIP, int loginDevice )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12939" );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Para.AddOrcNewInParameter( "i_userLastIP", userLastIP );
            Para.AddOrcNewInParameter( "i_loginDevice", loginDevice );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_addUserLoginLogByUserID" );//pro_UserLoginLogInsert
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal == 1;
        }
        #endregion

        #region 查询会员余额
        /// <summary>
        /// 查询会员余额
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public decimal GetUserBalance( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12933" );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            string _Result = Dal.ExecuteString( "yun_UserBehaver.sp_getUserBaclanceByUserID" );//pro_UserGetBaclance
            return ToDecimal( _Result );
        }
        #endregion

        #region 会员消费总金额
        /// <summary>
        /// 会员消费总金额
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public int GetUserConsumptionSum( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11723" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            string _Result = Dal.ExecuteString( "yun_MemberCenter.sp_getConsumeValueByUserid" );//pro_MemberCenterForUserConsumptionSum
            return -ToInt32( _Result );
        }
        #endregion

        #region 获取会员ID号
        /// <summary>
        /// 获取会员ID号
        /// </summary>
        /// <param name="str">手机号、Email、昵称任一项</param>
        /// <returns></returns>
        public int GetUserIDByStr( string str )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12935" );
            Para.AddOrcNewInParameter( "i_str", str );
            Para.AddOrcNewCursorParameter( "o_result" );
            return ToInt32( Dal.ExecuteString( "yun_UserBehaver.sp_getUserIDByStr" ) );//pro_UserGetIDByStr
        }
        #endregion

        #region 修改会员Key
        /// <summary>
        /// 修改会员Key
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        public int UpdateUserKey( int userID, string key )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12963" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_userKey", key );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_modUserKeyByUserID" );//pro_UserUpdateKey
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 查询会员的key
        /// <summary>
        /// 查询会员的key
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public string GetUserKey( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12937" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteString( "yun_UserBehaver.sp_getUserKeyByUserID" );//pro_UserGetKey
        }
        #endregion

        #region 更新会员密码
        /// <summary>
        /// 更新会员密码,只能更新forbid为0,3状态会员
        /// </summary>
        /// <param name="userID">会员ID号</param>
        /// <param name="password">密码对应的密文(sha1)</param>
        /// <returns></returns>
        public int UpdateUserPassword( int userID, string password )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12964" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_password", password );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_modUserPasswordByUserID" );//pro_UserUpdatePassword
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 获取userForbid
        /// <summary>
        /// 获取userForbid
        /// -1 不存在此会员 0：正常 1：帐户被冻结
        /// 2: 刚注册未激活
        /// 3: 帐号异常被禁，可通过取回密码解除
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int GetUserForbid( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12957" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return ToInt32( Dal.ExecuteString( "yun_UserBehaver.sp_getUserActiveByUserID" ), -1 );//pro_UsersGetuserForbid
        }
        #endregion

        #region 更新会员帐户状态
        /// <summary>
        /// 更新会员帐户状态
        /// </summary>
        /// <param name="userID">会员ID号</param>
        /// <param name="forbid">
        /// 状态值 0：正常 1：帐户被冻结
        /// 2: 刚注册未激活
        /// 3: 帐号异常被禁，可通过取回密码解除
        /// </param>
        /// <param name="unForbidTime">解冻时间</param>
        /// <param name="reason">解冻原因</param>
        /// <returns></returns>
        public bool UpdateUserForbid( int userID, int forbid, DateTime unForbidTime, string reason )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12961" );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Para.AddOrcNewInParameter( "i_forbid", forbid );
            Para.AddOrcNewInParameter( "i_time", unForbidTime );
            Para.AddOrcNewInParameter( "i_reson", reason );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_modUserForbidByUserID" );//pro_UsersUpdateForbid
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal > 0;
        }
        #endregion

        #region 根据主页标识获取会员ID号
        /// <summary>
        /// 根据主页标识获取会员ID号
        /// </summary>
        /// <param name="userWeb">会员主页标识</param>
        /// <returns></returns>
        public int GetUserIDByUserWeb( string userWeb )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12936" );
            Para.AddOrcNewInParameter( "i_userWeb", userWeb );
            Para.AddOrcNewCursorParameter( "o_result" );
            return ToInt32( Dal.ExecuteString( "yun_UserBehaver.sp_getUserIDByUserWeb" ) );//pro_UserGetIDByUserWeb
        }
        #endregion

        #region 个人主页获取会员基础信息
        /// <summary>
        /// 个人主页获取会员基础信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataSet GetUserBaseInfo( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13003" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_UserWeb.sp_getWebPageInfoByUserID" );//pro_UserWebPageBaseInfo
        }
        #endregion

        #region 获取会员隐私设置[云购记录、获得的商品、晒单记录]-个人主页显示用到
        /// <summary>
        /// 获取会员隐私设置[云购记录、获得的商品、晒单记录]
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataSet GetUserPrivSetByID( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12956" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_UserBehaver.sp_getPrivateSetByUserID" );//pro_UsersGetPrivSet
        }
        #endregion

        #region 检测两个用户之间是否为好友关系
        /// <summary>
        /// 检测两个用户之间是否为好友关系
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="friendID">另一个会员ID</param>
        /// <returns>（-1:非好友，0:已发送请求，1:已是好友）</returns>
        public int CheckUserFriendLink( int userID, int friendID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "11740" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_applyUserID", friendID );
            Dal.ExecuteNonQuery( "yun_MemberCenter.f_chkRelateOfTwoUserByUserID" );//pro_MemberCenterForUserRelationship
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            return _RetVal;
        }
        #endregion

        #region 会员中心-消费记录
        /// <summary>
        /// 手机版会员中心-消费记录
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userID">会员ID</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">总记录数</param>
        /// <returns></returns>
        public DataSet GetMemberCenterUserConsumption( int userID, int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int isCount, out int count )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11742" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_startTime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DateTime _DTBegin = DateTime.Now;
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getConsueForPhoneByUserid" );//pro_mMemberCenterForUserConsumption
            //UtilityFile.AddLogErrMsg( "time", "sp_getConsueForPhoneByUserid beginTime: " + beginTime + " endTime:" + endTime+
            //    " FIdx:" + FIdx + " EIdx:" + EIdx + " userID:" + userID +" time:"+ DateTime.Now.Subtract( _DTBegin ).TotalMilliseconds );
            count = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }

        /// <summary>
        /// 网页版会员中心-消费记录
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userid">会员ID</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">总记录数</param>
        /// <returns></returns>
        public DataSet GetMemberCenterUserConsumptionEx( int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int userid, int isCount, out int count )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11721" );
            Para.AddOrcNewInParameter( "i_userID", userid );
            Para.AddOrcNewInParameter( "i_starttime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getConsumeInfoByUserid" );//pro_MemberCenterForUserConsumption
            count = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion

        #region 会员中心-消费详情
        /// <summary>
        /// 会员中心-消费详情
        /// </summary>
        /// <param name="userID">用户id</param>
        /// <param name="shopID">购物车id</param>
        /// <returns></returns>
        public DataSet GetMemberCenterUserConsumptionDetail( int userID, long shopID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11722" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_shopid", shopID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getConsumeRecordByUserid" );//pro_MemberCenterForUserConsumptionDetail
        }
        #endregion

        #region 获取会员登录后的相关信息
        /// <summary>
        /// 会员登录后获取相关信息 UserID,UserName,UserMobile,UserEmail,UserPhoto,UserWeb,userPrevTime,UserBirthAreaName,UserExperience
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public DataSet GetUserCachedInfo( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12934" );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_UserBehaver.sp_getOftenUseInfoByUserID" );//pro_UserGetCachedInfo
        }
        #endregion

        #region 会员中心-充值记录
        /// <summary>
        /// 会员中心-充值记录
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userID">会员ID</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">总记录数</param>
        /// <returns></returns>
        public DataSet GetMemberCenterUserRecharge( int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int userID, int isCount, out int count )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11730" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_startTime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getTopUpOfUserByUserid" );//pro_MemberCenterForUserPays
            count = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion

        #region 会员充值总金额
        /// <summary>
        /// 会员充值总金额
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public int GetUserPaySum( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11731" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            string _Result = Dal.ExecuteString( "yun_MemberCenter.sp_getTopUpTotalByUserid" );//pro_MemberCenterForUserPaySum
            return ToInt32( _Result );
        }
        #endregion

        #region 查询用户充值、消费、转入、转出的总额
        /// <summary>
        /// 查询用户充值、消费、转入、转出的总额
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public DataSet GetUserMoneyByUserID( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11744" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getUserMoneyByUserID" );
        }
        #endregion

        #region  添加交易记录(云购)
        /// <summary>
        /// 添加交易记录(云购)
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="payBalance">是否启用余额</param>
        /// <param name="shopID">购物车ID</param>
        /// <param name="shopKey">购物车Key</param>
        /// <param name="points">福分</param>
        /// <param name="payDevice">提交终端(PC:0 手机:1)</param>
        /// <param name="payIP">支付者IP地址</param>
        /// <returns></returns>
        public int InsertUserCartPaymentRecord( int userID, int payBalance, long shopID, string shopKey, long points, byte payDevice, string payIP, int payBroker )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12916" );
            Para.AddOrcNewInParameter( "i_payUserID", userID );
            Para.AddOrcNewInParameter( "i_payBalance", payBalance );
            Para.AddOrcNewInParameter( "i_payPoint", points );
            Para.AddOrcNewInParameter( "i_payShopID", shopID );
            Para.AddOrcNewInParameter( "i_payShopKey", shopKey );
            Para.AddOrcNewInParameter( "i_payDevice", payDevice );
            Para.AddOrcNewInParameter( "i_payIP", payIP );
            Para.AddOrcNewInParameter( "i_payBroker", payBroker );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_addTradRecord" );//pro_UserCartPaymentRecord
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region  添加交易记录(充值)
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
        public bool InsertUserRechargePaymentRecord( int userID, decimal payMoney, long shopID, string shopKey, byte payDevice, string payIP, int payBalance, int payCodeID, int payPoint, int payBroker, int paySource )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12953" );
            Para.AddOrcNewInParameter( "i_payUserID", userID );
            Para.AddOrcNewInParameter( "i_paymoney", payMoney );
            Para.AddOrcNewInParameter( "i_payShopID", shopID );
            Para.AddOrcNewInParameter( "i_payShopKey", shopKey );
            Para.AddOrcNewInParameter( "i_payDevice", payDevice );
            Para.AddOrcNewInParameter( "i_payIP", payIP );
            if ( payCodeID > 0 )
            {
                Para.AddOrcNewInParameter( "i_payBalance", payBalance );
                Para.AddOrcNewInParameter( "i_payCodeID", payCodeID );
                Para.AddOrcNewInParameter( "i_paypoint", payPoint );
                Para.AddOrcNewInParameter( "i_paybroker", payBroker );
                Para.AddOrcNewInParameter( "i_paysource", paySource );
            }
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_addTradRecordInfo" );//pro_UserRechargePaymentRecord
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal > 0;
        }
        #endregion

        #region 获取某用户所有绑定类型
        /// <summary>
        /// 获取某用户所有绑定类型
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public DataTable GetUserBindTypeList( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12903" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataTable( "yun_UserBehaver.sp_getUserBindTypeByUserID" );//pro_UserBindLinkGetBindList
        }
        #endregion

        #region 获取会员绑定类型(旧的解决方案)
        /// <summary>
        /// 获取会员绑定类型 0本站 1电信云密保
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int GetUserBindTypeByID( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12955" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return ToInt32( Dal.ExecuteString( "yun_UserBehaver.sp_getUserBandTypeByUserID" ) );//pro_UsersGetBindType
        }
        #endregion

        #region 获取会员信息
        /// <summary>
        /// 获取会员信息
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public DataSet GetUserInfoByID( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11728" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getUserMainInfoByUserid" );//pro_MemberCenterForUserMainInfo
        }
        #endregion

        #region 更新会员昵称与绑定类型值
        /// <summary>
        /// 更新会员昵称与绑定类型值
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="userName"></param>
        /// <param name="bindType"></param>
        /// <returns>1成功 -1失败</returns>
        public int UpdateYmbUserByID( int userID, string userName, int bindType )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12960" );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Para.AddOrcNewInParameter( "i_userName", userName );
            Para.AddOrcNewInParameter( "i_userBindType", bindType );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_modUserTypeByUserID" );//pro_UsersUpdateBindType
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 检查昵称是否存在
        /// <summary>
        /// 检查昵称是否存在
        /// </summary>
        /// <param name="nickName">昵称</param>
        /// <returns>1存在，0不存在</returns>
        public int CheckNickName( int userID, string nickName )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12943" );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Para.AddOrcNewInParameter( "i_userName", nickName );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_chkIsExistsName" );//pro_UserNickName
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );//oracle: 1  此昵称不存在  0  异常  -1此昵称存在
            return _RetVal == 1 ? 0 : 1;
        }
        #endregion

        #region 会员中心-修改会员头像
        /// <summary>
        /// 会员中心-修改会员头像
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="photoUrl">头像路径</param>
        /// <returns></returns>
        public int UpdateMemberCenterForUserPhoto( int userID, string photoUrl )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12965" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_UserPhoto", photoUrl );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_modUserPhotoByUserID" );//pro_UserUpdatePhoto
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region QQ互联登录

        /// <summary>
        /// qq登录后填写相关信息
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="openId">用户身份唯一标识</param>
        /// <param name="accessToken">用户授权信息</param>
        /// <returns></returns>
        public bool InsertQQAuth( int userID, string openId, string accessToken )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12508" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_openID", openId );
            Para.AddOrcNewInParameter( "i_accessToken", accessToken );
            Dal.ExecuteNonQuery( "yun_QQAccount.f_addQQAccountAuth" );//pro_QQAuthInsert
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal > 0;
        }

        /// <summary>
        /// 从qq授权信息表中获取会员ID
        /// </summary>
        /// <param name="openId">用户身份唯一标识</param>
        /// <returns>存在则userID，不存在则0</returns>
        public int GetUserIDFromQQAuth( string openId )
        {
            int _IsAutoLogin = 0;
            return GetUserIDFromQQAuth( openId, out _IsAutoLogin );
        }

        /// <summary>
        /// 从qq授权信息表中获取会员ID
        /// </summary>
        /// <param name="openId">用户身份唯一标识</param>
        /// <param name="isAutoLogin">是否自动登录：1不自动，0自动登录，默认0</param>
        /// <returns>存在则userID，不存在则0</returns>
        public int GetUserIDFromQQAuth( string openId, out int isAutoLogin )
        {
            isAutoLogin = 0;
            int _UserID = 0;

            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12507" );
            Para.AddOrcNewInParameter( "i_openID", openId );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataTable _DT = Dal.ExecuteFillDataTable( "yun_QQAccount.sp_getQQLoginByOpenID" );//pro_QQAuthGetUserID
            if ( _DT != null && _DT.Rows.Count > 0 )
            {
                _UserID = ToInt32( _DT.Rows[0]["userID"] );
                isAutoLogin = ToInt32( _DT.Rows[0]["isAutoLogin"] );
            }
            _DT = null;
            return _UserID;
        }

        /// <summary>
        /// QQ授权自动完成注册信息 返回值： &gt;0 注册成功userID
        /// -1 注册失败
        /// </summary>
        /// <param name="userEmail">注册邮件地址（qqlogin_[Guid]@qq.com产生）</param>
        /// <param name="userPwd">登录密码（随机产生）</param>
        /// <param name="userIP">注册IP</param>
        /// <param name="invitedUserID">邀请者ID</param>
        /// <param name="marketUserID">推广者ID</param>
        /// <param name="openID">用户身份唯一标识</param>
        /// <param name="accessToken">用户授权信息</param>
        /// <returns></returns>
        public int SkipQQAuthRegister( string userEmail, string userPwd, string userIP, int invitedUserID, int marketUserID, string openID, string accessToken )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12509" );
            Para.AddOrcNewInParameter( "i_userEmail", userEmail );
            Para.AddOrcNewInParameter( "i_userPwd", userPwd );
            Para.AddOrcNewInParameter( "i_userIP", userIP );
            Para.AddOrcNewInParameter( "i_invitedUserID", invitedUserID );
            Para.AddOrcNewInParameter( "i_marketUserID", marketUserID );
            Para.AddOrcNewInParameter( "i_openID", openID );
            Para.AddOrcNewInParameter( "i_accessToken", accessToken );
            Dal.ExecuteNonQuery( "yun_QQAccount.f_addQQAuthRegister" );//pro_QQAuthSkipRegister
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }

        #endregion

        #region 获取会员头像
        /// <summary>
        /// 获取会员头像
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public string GetMemberCenterForUserPhoto( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11732" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteString( "yun_MemberCenter.sp_getPhotoOfUserByUserid" );//pro_MemberCenterForUserPhoto
        }
        #endregion

        #region 获取会员的最新访客
        /// <summary>
        /// 获取会员的最新访客
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        public DataSet GetLatestVisitors( int userID, int quanlity )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13001" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_quanlity", quanlity );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_UserWeb.sp_getBrowserLastByUserID" );//pro_UserWebBrowserGetLastList
        }
        #endregion

        #region 插入访客记录
        /// <summary>
        /// 插入访客记录
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="browserID"></param>
        /// <param name="ipNum"></param>
        /// <returns></returns>
        public int InsertUserWebBrowser( int userID, int browserID, long ipNum )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "13002" );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Para.AddOrcNewInParameter( "i_BrowserUserID", browserID );
            Para.AddOrcNewInParameter( "i_ipNum", ipNum );
            Dal.ExecuteNonQuery( "yun_UserWeb.f_addVisiterInfo" );//pro_UserWebBrowserInsert
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 获取会员最新动态
        /// <summary>
        /// 获取会员最新动态
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataSet GetUserLatestMessage( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13004" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewCursorParameter( "o_result1" );
            Para.AddOrcNewCursorParameter( "o_result2" );
            Para.AddOrcNewCursorParameter( "o_result3" );
            Para.AddOrcNewCursorParameter( "o_result4" );
            Para.AddOrcNewCursorParameter( "o_result5" );
            Para.AddOrcNewCursorParameter( "o_result6" );
            return Dal.ExecuteFillDataSet( "yun_UserWeb.sp_getWebFocusInfoByUserID" );//pro_UserWebPageFocusInfo
        }
        #endregion

        #region 分页获取会员的好友
        /// <summary>
        /// 获取会员的好友 table0：好友记录；table1：记录数目
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        public DataSet GetUserFriends( int userID, int quanlity, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13012" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_quanlity", quanlity );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_UserWeb.sp_getRecentFriendByUserID" );//pro_UserWebPageLastFriends
            totalCount = GetOrcTotalCount( 1, _DS );
            return _DS;
        }
        /// <summary>
        /// 分页获取会员的好友
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public DataSet GetUserFriends( int userID, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13006" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_iscount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_UserWeb.sp_getFriendListByUserID" );//pro_UserWebPageForUserFriend
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion

        #region 插入申请加为好友的验证信息
        /// <summary>
        /// 插入申请加为好友的验证信息
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="applyUserID"></param>
        /// <returns></returns>
        public int InsertUserFriendApply( int userID, int applyUserID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12967" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_applyUserID", applyUserID );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_UserFriendMsg" );//pro_UserFriendApplyInsert
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 给会员发送私信
        /// <summary>
        /// 给会员发送私信
        /// -2 禁止任何人发私信
        /// -1 只接受好友的私信 0 失败 1 成功
        /// </summary>
        /// <param name="inceptUserID">接收方ID</param>
        /// <param name="senderUserID">发送者ID</param>
        /// <param name="content">私信内容</param>
        /// <returns></returns>
        public int InsertUserPrivMsg( int inceptUserID, int senderUserID, string content )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12951" );
            Para.AddOrcNewInParameter( "i_inceptUserID", inceptUserID );
            Para.AddOrcNewInParameter( "i_senderUserID", senderUserID );
            Para.AddOrcNewInParameter( "i_content", content );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_modSendPrivMsgByUserID" );//pro_UserPrivMsgInsert
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 插入用户反馈信息
        /// <summary>
        /// 插入用户反馈信息
        /// </summary>
        /// <param name="title"></param>
        /// <param name="userName"></param>
        /// <param name="userTel"></param>
        /// <param name="userEmail"></param>
        /// <param name="codeID"></param>
        /// <param name="content"></param>
        /// <param name="IP"></param>
        /// <param name="suggestType"></param>
        /// <param name="suggestSubType"></param>
        /// <param name="terminalInfo"></param>
        /// <param name="uploadPictures"></param>
        /// <returns></returns>
        public int InsertSuggestMessage( string title, string userName, string userTel, string userEmail, string codeID, string content, string IP, string suggestType, string suggestSubType, string terminalInfo, string uploadPictures )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12901" );
            Para.AddOrcNewInParameter( "i_cmtatile", title );
            Para.AddOrcNewInParameter( "i_cmCustomerName", userName );
            Para.AddOrcNewInParameter( "i_cmTell", userTel );
            Para.AddOrcNewInParameter( "i_cmEmail", userEmail );
            Para.AddOrcNewInParameter( "i_cmCodeID", codeID );
            Para.AddOrcNewInParameter( "i_cmContent", content );
            Para.AddOrcNewInParameter( "i_cmIP", IP );
            Para.AddOrcNewInParameter( "i_suggestType", suggestType );
            Para.AddOrcNewInParameter( "i_suggestSubType", suggestSubType );
            Para.AddOrcNewInParameter( "i_terminalInfo", terminalInfo );
            Para.AddOrcNewInParameter( "i_uploadPictures", uploadPictures );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_addSuggest" );//pro_SuggestInsert
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 获取会员相关资料的验证信息
        /// <summary>
        /// 获取会员相关资料的验证信息
        /// </summary>
        /// <param name="_UserID">会员ID</param>
        /// <returns></returns>
        public DataSet GetUserBaseInfoForUserVerify( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12902" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_UserBehaver.sp_getUserVerifyByUserID" );//pro_UserBaseInfoGetUserVerify
        }
        #endregion

        #region 会员中心-修改个人详细资料
        /// <summary>
        /// 会员中心-修改个人详细资料
        /// </summary>
        /// <param name="model">用户实例</param>
        /// <param name="modelVerify">用户验证实例</param>
        /// <returns></returns>
        public int UpdateMemberCenterForUserDetail( int userID, string userName, string userQQ, string userPhone, int userSex, DateTime userBirthday, int userBirthStar,
            int userBirthArea, string userBirthAreaName, int userLiveArea, string userLiveAreaName, string userMonthIncome, string userSignature, DateTime userBirthUpdateTime,
            int userVerifyName, int userVerifySex, int userVerifyBirthDay, int userVerifyBirthArea, int userVerifyLiveArea, int userVerifyQQ, int userVerifyWage, int userVerifySignature )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "11724" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_userName", userName );
            Para.AddOrcNewInParameter( "i_userQQ", userQQ );
            Para.AddOrcNewInParameter( "i_userPhone", userPhone );
            Para.AddOrcNewInParameter( "i_userSex", userSex );
            Para.AddOrcNewInParameter( "i_userBirthDay", userBirthday );
            Para.AddOrcNewInParameter( "i_userBirthStar", userBirthStar );
            Para.AddOrcNewInParameter( "i_userBirthArea", userBirthArea );
            Para.AddOrcNewInParameter( "i_userBirthAreaName", userBirthAreaName );
            Para.AddOrcNewInParameter( "i_userLiveArea", userLiveArea );
            Para.AddOrcNewInParameter( "i_userLiveAreaName", userLiveAreaName );
            Para.AddOrcNewInParameter( "i_userMonthIncome", userMonthIncome );
            Para.AddOrcNewInParameter( "i_userSignature", userSignature );
            Para.AddOrcNewInParameter( "i_userBirthUpdateTime", userBirthUpdateTime );

            Para.AddOrcNewInParameter( "i_userVerifyName", userVerifyName );
            Para.AddOrcNewInParameter( "i_userVerifySex", userVerifySex );
            Para.AddOrcNewInParameter( "i_userVerifyBirthDay", userVerifyBirthDay );
            Para.AddOrcNewInParameter( "i_userVerifyBirthArea", userVerifyBirthArea );
            Para.AddOrcNewInParameter( "i_userVerifyLiveArea", userVerifyLiveArea );
            Para.AddOrcNewInParameter( "i_userVerifyQQ", userVerifyQQ );
            Para.AddOrcNewInParameter( "i_userVerifyWage", userVerifyWage );
            Para.AddOrcNewInParameter( "i_userVerifySignature", userVerifySignature );

            Dal.ExecuteNonQuery( "yun_MemberCenter.f_modMemberAllInfoByUserID" );//Pro_MemberCenterForUserDetailUpdate
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 会员中心首页信息
        /// <summary>
        /// 会员中心首页信息
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public DataSet GetMemberCenterHome( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11701" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewCursorParameter( "o_result_user" );
            Para.AddOrcNewCursorParameter( "o_result_cfg" );
            Para.AddOrcNewCursorParameter( "o_result_post" );
            Para.AddOrcNewCursorParameter( "o_result_car" );
            return Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getUserInfoByUserID" );//pro_MemberCenterForFirstPage
        }
        #endregion

        #region 会员中心-个人资料详情
        /// <summary>
        /// 会员中心-个人资料详情
        /// </summary>
        /// <param name="userID">用户id</param>
        /// <returns></returns>
        public DataSet GetMemberCenterUserInfo( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11727" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getOneUserInfoByUserid" );//pro_MemberCenterForUserInfo
        }
        #endregion

        #region 会员中心-修改个人基本资料
        /// <summary>
        /// 会员中心-修改个人基本资料
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="userMobile"></param>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public int UpdateMemberCenterForUserBase( int userID, string userMobile, string userEmail )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "11715" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_userMobile", userMobile );
            Para.AddOrcNewInParameter( "i_userEmail", userEmail );
            Dal.ExecuteNonQuery( "yun_MemberCenter.f_modMemberBaseByUserID" );//Pro_MemberCenterForUserBaseUpdate
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 会员中心 - 隐私设置
        /// <summary>
        /// 会员中心 - 隐私设置
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="userPrivMsgSet"></param>
        /// <param name="userAreaSet"></param>
        /// <param name="userSearchSet"></param>
        /// <param name="buySet"></param>
        /// <param name="rafSet"></param>
        /// <param name="postSet"></param>
        /// <param name="buyShowNum"></param>
        /// <param name="rafShowNum"></param>
        /// <param name="pastShowNum"></param>
        /// <returns></returns>
        public int UpdateUserPrivSet( int userID, int userPrivMsgSet, int userAreaSet, int userSearchSet, int buySet, int rafSet, int postSet, int buyShowNum, int rafShowNum, int postShowNum )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12962" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_userPrivMsgSet", userPrivMsgSet );
            Para.AddOrcNewInParameter( "i_userAreaSet", userAreaSet );
            Para.AddOrcNewInParameter( "i_userSearchSet", userSearchSet );
            Para.AddOrcNewInParameter( "i_userBuySet", buySet );
            Para.AddOrcNewInParameter( "i_userBuyValue", buyShowNum );
            Para.AddOrcNewInParameter( "i_userBarcodeSet", rafSet );
            Para.AddOrcNewInParameter( "i_userBarcodeValue", rafShowNum );
            Para.AddOrcNewInParameter( "i_userPostSet", postSet );
            Para.AddOrcNewInParameter( "i_userPostValue", postShowNum );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_modPrivSetByUserID" );//pro_UsersUpdatePrivSet
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 会员首页签到
        /// <summary>
        /// 会员首页-检测会员是否已签到
        /// -1 未签到; 1 已经签到
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int CheckUserSign( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12958" );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_chkSignLogExistsByUserID" );//pro_UserSignLogExists
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        /// <summary>
        /// 会员中心 - 签到 1 签到成功;0 签到失败;-1 已经签到
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int InsertUserSignLog( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12959" );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_modUserSignLogByUserID" );//pro_UserSignLogInsert
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 支付状态反查相关方法
        /// <summary>
        /// 查询需要回查的支付记录列表 shopID,orderTime
        /// </summary>
        /// <param name="payTypeNO">支付方式编号</param>
        /// <returns></returns>
        public DataSet GetPaymentRecordCheckList( int payTypeNO )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12301" );
            Para.AddOrcNewInParameter( "i_paytypeno", payTypeNO );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PayMentRecord.sp_getPayRecordByPaytypeNO" );//pro_PaymentRecordCheckList
        }
        #endregion

        #region 统计会员获得的商品最新个数
        /// <summary>
        /// 统计会员获得的商品最新个数
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="orderNO"></param>
        /// <returns></returns>
        public int GetMemberCenterForUserRaffleNewCount( int userID, int orderNO )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11739" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_orderNO", orderNO );
            Para.AddOrcNewCursorParameter( "o_result" );
            return ToInt32( Dal.ExecuteString( "yun_MemberCenter.sp_getRecentGoodsByUserid" ) );//pro_MemberCenterForUserRaffleNewCount
        }
        #endregion

        #region 会员余额转账模块
        /// <summary>
        /// 添加转账申请
        /// </summary>
        /// <param name="outUserID">转出账号ID</param>
        /// <param name="inUserID">转入账号ID</param>
        /// <param name="money">转出金额</param>
        /// <param name="inAccount">转入账号</param>
        /// <param name="transMemo">转账备注</param>
        /// <returns></returns>
        public int InsertTransferAccount( int outUserID, int inUserID, int money, string inAccount, string transMemo )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12305" );
            Para.AddOrcNewInParameter( "i_outUserID", outUserID );
            Para.AddOrcNewInParameter( "i_InUserID", inUserID );
            Para.AddOrcNewInParameter( "i_money", money );
            Para.AddOrcNewInParameter( "i_inAccount", inAccount );
            Para.AddOrcNewInParameter( "i_transMemo", transMemo );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_PayMentRecord.f_addTransferAccount" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }

        /// <summary>
        /// 执行余额转账
        /// </summary>
        /// <param name="transID">转账申请ID</param>
        /// <param name="outUserID">转出账号ID</param>
        /// <returns></returns>
        public int ExecuteTransferAccount( int transID, int outUserID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12306" );
            Para.AddOrcNewInParameter( "i_TransID", transID );
            Para.AddOrcNewInParameter( "i_outUserID", outUserID );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_PayMentRecord.f_modTransferAccount" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }

        /// <summary>
        /// 删除转账申请
        /// </summary>
        /// <param name="transID">转账申请ID</param>
        /// <param name="outUserID">转出账号ID</param>
        /// <returns></returns>
        public int DeleteTransferAccount( int transID, int outUserID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12307" );
            Para.AddOrcNewInParameter( "i_TransID", transID );
            Para.AddOrcNewInParameter( "i_outUserID", outUserID );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_PayMentRecord.f_delTransferAccount" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }

        /// <summary>
        /// 获取用户转帐列表
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
        public DataSet GetTransferAccountList( int userID, DateTime beginTime, DateTime endTime, int state, int transferWay, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12308" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_startTime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_state", state );
            Para.AddOrcNewInParameter( "i_outIn", transferWay );//转入与转出，0.全部 1.转出 2.转入
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_PayMentRecord.sp_getPayTransAccount" );
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }

        /// <summary>
        /// 根据转帐申请ID获取详细信息
        /// </summary>
        /// <param name="transID">转账申请ID</param>
        /// <returns></returns>
        public DataSet GetTransferByTransID( int transID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12309" );
            Para.AddOrcNewInParameter( "i_TransID", transID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PayMentRecord.sp_getPayTransInfoByTransID" );
        }

        #endregion

        #region 会员充值卡充值模块

        /// <summary>
        /// 购买充值卡时更新卡状态
        /// </summary>
        /// <param name="cardAccount">充值卡账号</param>
        /// <param name="buyPlat">1：淘宝</param>
        /// <returns></returns>
        public int UpdateCardStateByAccount( long cardAccount, int buyPlat )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12312" );
            Para.AddOrcNewInParameter( "i_CardAccount", cardAccount );
            Para.AddOrcNewInParameter( "i_buyPlat", buyPlat );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_PayMentRecord.f_modCardStateByAccount" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }

        /// <summary>
        /// 获取充值卡信息
        /// </summary>
        /// <param name="cardAccount">充值卡账号</param>
        /// <returns></returns>
        public DataSet GetCardInfoByAccount( long cardAccount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12316" );
            Para.AddOrcNewInParameter( "i_CardAccount", cardAccount );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PayMentRecord.sp_getMoneyByAccount" );
        }

        /// <summary>
        /// 用户使用充值卡进行充值
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="cardAccount">充值卡账号</param>
        /// <param name="cardPwd">充值卡密码</param>
        /// <returns></returns>
        public int UpdateCardWasteByUserID( int userID, long cardAccount, int cardPwd, string userIP )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12313" );
            Para.AddOrcNewInParameter( "i_CardAccount", cardAccount );
            Para.AddOrcNewInParameter( "i_CardPwd", cardPwd );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_userIP", userIP );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_PayMentRecord.f_modCardWasteByUserID" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }

        #endregion

        #region 安全设置－支付密码模块
        /// <summary>
        /// 开启支付密码
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="userPayPwd">用户支付密码</param>
        /// <returns></returns>
        public int SetUserPayPwdByUserID( int userID, string userPayPwd )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11745" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_userPayPwd", userPayPwd );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_MemberCenter.f_modEnablePayPwdByUserID" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }

        /// <summary>
        /// 修改支付密码
        /// </summary>
        /// <param name="userID">用户 ID</param>
        /// <param name="userPayPwd">用户支付密码</param>
        /// <returns></returns>
        public int UpdateUserPayPwdByUserID( int userID, string userPayPwd )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11746" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_userPayPwd", userPayPwd );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_MemberCenter.f_modPayPwdByUserID" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }

        /// <summary>
        /// 关闭用户支付密码
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public int CloseUserPayPwdByUserID( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11747" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_MemberCenter.f_modClosePayPwdByUserID" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }

        /// <summary>
        /// 修改小额免密码金额
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="smallPayMoney">免密码金额</param>
        /// <returns></returns>
        public int UpdateSmallPayMoneyByUserID( int userID, int smallPayMoney )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11748" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_smallpaymoney", smallPayMoney );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_MemberCenter.f_modSmallPayMoneyByUserID" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }

        /// <summary>
        /// 验证支付密码
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="userPayPwd">支付密码</param>
        /// <returns></returns>
        public int CheckPayPwdByUserID( int userID, string userPayPwd )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11749" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_UserPayPwd", userPayPwd );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_MemberCenter.f_chkPayPwdByUserID" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        /// <summary>
        /// 设置登录保护
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="isWxKeeyLogin">1微信提示，0不提示</param>
        /// <returns>1成功，－1用户不存在</returns>
        public int SetWxKeepLoginByUserID( int userID, int isWxKeeyLogin )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11750" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_isWXKeepLogin", isWxKeeyLogin );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_MemberCenter.f_modWXLoginKeepByUserID" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }

        /// <summary>
        /// 设置购买失败的微信邮箱消息推送开关
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="isWxMailSend"></param>
        /// <returns></returns>
        public int SetWxMailNoticeByUserID( int userID, int isWxMailSend )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11751" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_isWXEmailSend", isWxMailSend );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_MemberCenter.f_modWXMailNoTiceByUserID" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }

        /// <summary>
        /// 设置购买失败的云购帐户系统消息推送
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="isSysMsgSend"></param>
        /// <returns></returns>
        public int SetSysMsgNoticeByUserID( int userID, int isSysMsgSend )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11752" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_isSysMsgSend", isSysMsgSend );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_MemberCenter.f_modYunMsgNoticeByUserID" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 会员中心-我的账户全部记录
        /// <summary>
        /// 会员中心-我的账户全部记录
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总记录数</param>
        /// <returns></returns>
        public DataSet GetMemberCenterAllBalanceRecord( int userID, DateTime beginTime, DateTime endTime, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11762" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_startTime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getAllBalanceByUserid" );
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion

        #region 会员中心-佣金明细全部记录
        /// <summary>
        /// 会员中心-佣金明细全部记录
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="brokerType">佣金类型 0：全部 1：收入 2：提现</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总记录数</param>
        /// <returns></returns>
        public DataSet GetMemberCenterBrokerPageByUserID( int userID, int brokerType, DateTime beginTime, DateTime endTime, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11763" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_BrokerType", brokerType );
            Para.AddOrcNewInParameter( "i_startTime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getBrokerPageByUserid" );
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion

        #region 添加会员邀请链接短地址
        /// <summary>
        /// 添加会员邀请链接短地址
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="urlType">地址类型 0.会员中心 1.邀请页面</param>
        /// <param name="shortUrl">短地址</param>
        /// <returns></returns>
        public int InsertUserShortUrl( int userID, int urlType, string shortUrl )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11766" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_AddrType", urlType );
            Para.AddOrcNewInParameter( "i_shortAddr", shortUrl );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_MemberCenter.f_addShortAddr" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        #endregion

        #region 根据短地址获取用户ID
        /// <summary>
        /// 根据短地址获取用户ID
        /// </summary>
        /// <param name="shortUrl">短地址</param>
        /// <returns></returns>
        public DataSet GetUserIDByShortUrl( string shortUrl )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11767" );
            Para.AddOrcNewInParameter( "i_shortAddr", shortUrl );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getUserIDByShortAddr" );
        }
        #endregion

        #region 根据用户ID获取短地址
        /// <summary>
        /// 根据用户ID获取短地址
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public DataSet GetShortUrlByUserID( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11768" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getShortAddrByUserID" );
        }
        #endregion

        #region 插入举报用户记录
        /// <summary>
        /// 插入举报用户记录
        /// </summary>
        /// <param name="userID">举报人ID</param>
        /// <param name="reportUserID">被举报人ID</param>
        /// <param name="reportGroupID">被举群ID</param>
        /// <param name="kind">举报属性，1.圈子回复 2.晒单回复 3.用户昵称及签名 4.好友私信 5.群信息</param>
        /// <param name="repplyID">根据举报属性关联的ID，如圈子回复ID，晒单回复ID等</param>
        /// <param name="type">举报类型，1.钓鱼欺诈 2.广告骚扰 3.色情暴力 4.其它</param>
        /// <param name="level">举报严重程度：默认为0，1.一般 2.较严重 3.非常严重 4.不可容忍</param>
        /// <param name="content">举报者说的话</param>
        /// <param name="reportContent">被举报者的内容</param>
        /// <param name="device">举报的客户端，1.安桌 2.苹果 3.触屏版 4.电脑PC 5.微信</param>
        /// <param name="allPic">截图，用逗号隔开</param>
        /// <returns></returns>
        public int InsertReportUser( int userID, int reportUserID, int reportGroupID, int kind, int repplyID, int type, int level, string content, string reportContent, int device, string allPic )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "14601" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_reportUserID", reportUserID );
            Para.AddOrcNewInParameter( "i_reportIMGroupID", reportGroupID );
            Para.AddOrcNewInParameter( "i_kind", kind );
            Para.AddOrcNewInParameter( "i_repplyID", repplyID );
            Para.AddOrcNewInParameter( "i_type", type );
            Para.AddOrcNewInParameter( "i_level", level );
            Para.AddOrcNewInParameter( "i_content", content );
            Para.AddOrcNewInParameter( "i_reportContent", reportContent );
            Para.AddOrcNewInParameter( "i_device", device );
            Para.AddOrcNewInParameter( "i_AllPic", allPic );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_ReportUser.f_addReportUser" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        #endregion

        #region 根据购物车ID查询交易记录
        /// <summary>
        /// 根据购物车ID查询交易记录
        /// </summary>
        /// <param name="cartID">购物车ID</param>
        /// <param name="isSingle">是否只获取一条记录</param>
        /// <returns></returns>
        public DataSet GetPaymentRecordList( long cartID, bool isSingle )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13207" );
            Para.AddOrcNewInParameter( "i_CartID", cartID );
            Para.AddOrcNewInParameter( "i_isSingle", isSingle ? 1 : 0 );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_ZBuy_Payment.sp_getPaymentListByCartID" );//probuy_PaymentRecordGetListByCartID
        }
        #endregion

        #region 获取云购成功的信息
        /// <summary>
        /// 获取云购成功的信息
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="shopID">云购交易标识号</param>
        /// <param name="state">
        /// 返回数据状态
        /// -1 没有交易记录或未完成交易 1 已完成交易记录 2 已完成交易记录，但有云购失败商品
        /// </param>
        /// <returns></returns>
        public DataSet GetUserShopInfo( int userID, long shopID, out int state )
        {
            state = -1;

            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13304" );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Para.AddOrcNewInParameter( "i_shopID", shopID );
            Para.AddOrcNewCursorParameter( "o_result1" );
            Para.AddOrcNewCursorParameter( "o_result_buy1" );
            Para.AddOrcNewCursorParameter( "o_result_buy2" );
            Para.AddOrcNewCursorParameter( "o_result_bar" );
            DataSet _DSTmp = Dal.ExecuteFillDataSet( "yun_ZBuy_User.sp_getUserGetShopInfo" );//probuy_UserGetShopInfo
            if ( _DSTmp != null && _DSTmp.Tables.Count == 4 && _DSTmp.Tables[0].Rows.Count > 0 )
            {
                state = ToInt32( _DSTmp.Tables[0].Rows[0][0] );
                _DSTmp.Tables.RemoveAt( 0 );
            }

            return _DSTmp;
        }
        #endregion

        #region 会员中心换货补扣差价
        /// <summary>
        /// 会员中心换货补扣差价
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="applyID">换货申请ID</param>
        /// <returns></returns>
        public int UpdateMinusPriceByUserID( int userID, int applyID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12321" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_applyID", applyID );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_PayMentRecord.f_modMinusPriceByUserID" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        #endregion

        #region 获取需要补差价的换货列表
        /// <summary>
        /// 获取需要补差价的换货列表
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总数</param>
        /// <returns></returns>
        public DataSet GetExChangeListByUserID( int userID, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11770" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getExChangeListByUserID" );
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion

        #region 根据换货编号获取换货详情
        /// <summary>
        /// 根据换货编号获取换货详情
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="exID">换货编号</param>
        /// <returns></returns>
        public DataSet GetExChangeInfoByExID( int userID, int exID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11771" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_ExID", exID );
            Para.AddOrcNewCursorParameter( "o_result_before" );
            Para.AddOrcNewCursorParameter( "o_result_after" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getExChangeInfoByExID" );
            return _DS;
        }
        #endregion

        #region 根据换货编号单条申请的记录
        /// <summary>
        /// 根据换货编号单条申请的记录
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="exID">换货编号</param>
        /// <returns></returns>
        public DataSet GetExChangeOneByExID( int userID, int exID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11772" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_ExID", exID );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getExChangeOneByExID" );
            return _DS;
        }
        #endregion

        #region 修改用户基本信息
        /// <summary>
        /// 修改用户基本信息
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="modType">要修改的字段类型</param>
        /// <param name="content">要修改的内容</param>
        /// <returns></returns>
        public int UpdateMemberCenterForUserBaseByType( int userID, int modType, string content )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11773" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_modType", modType );
            Para.AddOrcNewInParameter( "i_content", content );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_MemberCenter.f_modUserBaseInfoByUserID" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion
        #region 验证支付密码,返回冻结剩余时间（s）11774
        /// <summary>
        /// 验证支付密码,返回冻结剩余时间（s）11774
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="userPayPwd">支付密码</param>
        /// <returns></returns>
        public int CheckPayPwdByUserID( int userID, string userPayPwd, out int surplusTime )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11774" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_UserPayPwd", userPayPwd );
            Para.AddOrcNewCursorParameter( "o_result" );
            int _RetVal = 0;
            surplusTime = 0;
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_chkPayPwdByUserID" );
            if ( _DS != null && _DS.Tables.Count > 0 )
            {
                _RetVal = ToInt32( _DS.Tables[0].Rows[0]["a"] );
                if ( _RetVal == -4 )
                {
                    surplusTime = ToInt32( _DS.Tables[0].Rows[0]["PayPwdLockTime"] );
                }
            }
            return _RetVal;
        }
        #endregion

        #region 运营应用相关
        #region 修改用户基本信息40103
        /// <summary>
        /// app相关操作记录40103
        /// </summary>
        /// <param name="IMEI">IMEI码</param>
        /// <param name="appMarketCode">应用平台代码</param>
        /// <param name="operateType">1.下载且激活app,2.在app上注册,3.在app上登录,4.卸载app</param>
        /// <param name="loginUserID">登录用户ID</param>
        /// <param name="registerUserID">注册用户ID</param>
        /// <param name="device">设备型号</param>
        /// <param name="sysVer">系统版本</param>
        /// <param name="appVer">app版本</param>
        /// <returns></returns>
        public int appUsingTheApp( string IMEI, string appMarketCode, int operateType, int loginUserID, int registerUserID, string device, string sysVer, string appVer )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "40103" );
            Para.AddOrcNewInParameter( "i_IMEI", IMEI );
            Para.AddOrcNewInParameter( "i_AppMarketCode", appMarketCode );
            Para.AddOrcNewInParameter( "i_OperateType", operateType );
            Para.AddOrcNewInParameter( "i_LoginUserID", loginUserID );
            Para.AddOrcNewInParameter( "i_RegisterUserID", registerUserID );
            Para.AddOrcNewInParameter( "i_Device", device );
            Para.AddOrcNewInParameter( "i_Sysver", sysVer );
            Para.AddOrcNewInParameter( "i_Appver", appVer );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_operationApply.f_usingTheApp" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion
        #endregion

        #region 校验用户转账次数,返回1表示未超过5次,-1表示已大于等于5次12345
        /// <summary>
        /// 校验用户转账次数,返回1表示未超过5次,-1表示已大于等于5次12345
        /// </summary>
        /// <param name="outUserID"></param>
        /// <returns></returns>
        public int ChkTransferTimes( int outUserID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12345" );
            Para.AddOrcNewInParameter( "i_outUserID", outUserID );
            Dal.ExecuteNonQuery( "yun_PayMentRecord.f_chkTransferTimes" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            return _RetVal;
        }
        #endregion

        #region APP弹窗引导用户评论或反馈
        #region APP用户评论校验40105
        /// <summary>
        /// APP用户评论校验40105
        /// </summary>
        /// <param name="imei"></param>
        /// <param name="userID"></param>
        /// <param name="buyDayNum">扫描天数，默认14</param>
        /// <param name="getGoodsNum">近两周内获得商品数量的最低值，默认3</param>
        /// <param name="appMarketCode">应用平台代码，默认appstore</param>
        /// <param name="appVer">app版本</param>
        /// <param name="sDayNum">意见反馈，多少日不再提示，默认180天</param>
        /// <param name="nDayNum">下次再说，多少日内不再提示，默认60天</param>
        /// <param name="percent">消费金额与获得总价比，默认1</param>
        /// <returns></returns>
        public int ChkAppUserComment( string imei, int userID, int buyDayNum, int getGoodsNum, string appMarketCode, string appVer, int sDayNum, int nDayNum, double percent )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "40105" );
            Para.AddOrcNewInParameter( "i_imei", imei );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_buydaynum", buyDayNum );
            Para.AddOrcNewInParameter( "i_getgooodsnum", getGoodsNum );
            Para.AddOrcNewInParameter( "i_AppMarketCode", appMarketCode );
            Para.AddOrcNewInParameter( "i_Appver", appVer );
            Para.AddOrcNewInParameter( "i_Sdaynum", sDayNum );
            Para.AddOrcNewInParameter( "i_Ndaynum", nDayNum );
            Para.AddOrcNewInParameter( "i_percent", percent );
            Dal.ExecuteNonQuery( "yun_OperationApply.f_chkAppUserComment" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            return _RetVal;
        }
        #endregion
        #region APP用户评论校验40106
        /// <summary>
        /// 弹窗用户选择记录40106
        /// </summary>
        /// <param name="imei"></param>
        /// <param name="userID"></param>
        /// <param name="appMarketCode">-应用平台代码，默认appstore</param>
        /// <param name="appVer">app版本</param>
        /// <param name="commentType">1-好评;2-反馈意见;3-下次再说</param>
        /// <returns></returns>
        public int AddAppComments( string imei, int userID, string appMarketCode, string appVer, int commentType )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "40106" );
            Para.AddOrcNewInParameter( "i_imei", imei );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_AppMarketCode", appMarketCode );
            Para.AddOrcNewInParameter( "i_Appver", appVer );
            Para.AddOrcNewInParameter( "i_commenttype", commentType );
            Dal.ExecuteNonQuery( "yun_OperationApply.f_AddAppComments" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            return _RetVal;
        }
        #endregion
        #endregion
        #region 根据卡号获取对应的银行名称12328
        /// <summary>
        /// 根据卡号获取对应的银行名称12328
        /// </summary>
        /// <param name="cardNO">卡号</param>
        /// <param name="cardLength">卡长度</param>
        /// <returns></returns>
        public DataSet GetBankNameByCardNO( string cardNO, int cardLength )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12328" );
            Para.AddOrcNewInParameter( "i_cardNum", cardNO );
            Para.AddOrcNewInParameter( "i_cardLength", cardLength );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PayMentRecord.sp_getBankMarkByCard" );
        }
        #endregion

        #region 退补会员运费或差价操作
        /// <summary>
        /// 退补会员运费或差价操作
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="orderNO">订单号</param>
        /// <param name="logType">操作类型</param>
        /// <param name="money">金额</param>
        /// <param name="loginName">登录账号</param>
        /// <returns></returns>
        public int FillUserBalance( int userID, int orderNO, int logType, int money, string loginName )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12323" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_orderno", orderNO );
            Para.AddOrcNewInParameter( "i_logType", logType );
            Para.AddOrcNewInParameter( "i_logMoney", money );
            Para.AddOrcNewInParameter( "i_executant", loginName );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_PayMentRecord.f_addBalancelogByUser" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        #endregion
        #region 获取用户消费金额及注册时间11775
        /// <summary>
        /// 获取用户消费金额及注册时间11775
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataSet GetWasteRegTimeByUserID( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11775" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getWasteRegTimeByUserID" );
        }
        #endregion

    }
}
