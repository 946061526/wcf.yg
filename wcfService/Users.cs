using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class WCFServiceFun
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

        #region 登录
        /// <summary>
        /// 登录
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
        /// <returns></returns>
        public int LoginUser( string userMobile, string userEmail, string userPwd, string userLastIP, int loginDevice )
        {
            int _Result = 0;
            if ( ( !UtilityFun.IsEmptyString( userMobile ) || !UtilityFun.IsEmptyString( userEmail ) ) && !UtilityFun.IsEmptyString( userPwd ) )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Result = _DAL.LoginUser( userMobile, userEmail, userPwd, userLastIP, loginDevice, 0 );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.LoginUser抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion

        #region 记录登录日志
        /// <summary>
        /// 记录登录日志，针对第三方快速登录的
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="userLastIP"></param>
        /// <returns></returns>
        public bool InsertUserLoginLog( int userID, string userLastIP, int loginDevice )
        {
            bool _Result = false;
            if ( userID > 0 && userLastIP != "" )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Result = _DAL.InsertUserLoginLog( userID, userLastIP, loginDevice );
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

        #region 检测用户账号密码是否正确 非登录业务
        /// <summary>
        /// 检测用户账号密码是否正确 非登录业务
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
        public int CheckUserAccount( string userAccount, string userPwd )
        {
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

        #region 查询会员余额
        /// <summary>
        /// 查询会员余额
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public decimal GetUserBalance( int userID )
        {
            decimal _Balance = 0m;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Balance = _DAL.GetUserBalance( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetUserBalance抛出异常：" + ex.Message );
                }
            }
            return _Balance;
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
            int _Money = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Money = _DAL.GetUserConsumptionSum( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetUserConsumptionSum抛出异常：" + ex.Message );
                }
            }
            return _Money;
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
            int _UserID = 0;
            if ( !UtilityFun.IsEmptyString( str ) )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _UserID = _DAL.GetUserIDByStr( str );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetUserIDByStr抛出异常：" + ex.Message );
                }
            }
            return _UserID;
        }
        #endregion

        #region 修改会员Key
        /// <summary>
        /// 修改会员Key
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        public bool UpdateUserKey( int userID, string key )
        {
            bool _Result = false;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Result = _DAL.UpdateUserKey( userID, key ) > 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.UpdateUserKey抛出异常：" + ex.Message );
                }
            }
            return _Result;
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
            string _Key = "";
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Key = _DAL.GetUserKey( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetUserKey抛出异常：" + ex.Message );
                }
            }
            return _Key;
        }
        #endregion

        #region 更新会员密码
        /// <summary>
        /// 更新会员密码,只能更新forbid为0,3状态会员
        /// </summary>
        /// <param name="userID">会员ID号</param>
        /// <param name="password">密码对应的密文(sha1)</param>
        /// <returns></returns>
        public bool UpdateUserPassword( int userID, string password )
        {
            bool _Result = false;
            if ( userID > 0 && !UtilityFun.IsEmptyString( password ) )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Result = _DAL.UpdateUserPassword( userID, password ) > 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.UpdateUserPassword抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion

        #region 获取userForbid
        /// <summary>
        /// 获取userForbid
        /// -1 不存在此会员
        /// 0：正常
        /// 1：帐户被冻结
        /// 2: 刚注册未激活
        /// 3: 帐号异常被禁，可通过取回密码解除
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int GetUserForbid( int userID )
        {
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

        #region 更新会员帐户状态
        /// <summary>
        /// 更新会员帐户状态
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
        public bool UpdateUserForbid( int userID, int forbid, DateTime unForbidTime, string reason )
        {
            bool _Result = false;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Result = _DAL.UpdateUserForbid( userID, forbid, unForbidTime, reason );
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

        #region 根据主页标识获取会员ID号
        /// <summary>
        /// 根据主页标识获取会员ID号
        /// </summary>
        /// <param name="userWeb">会员主页标识</param>
        /// <returns></returns>
        public int GetUserIDByUserWeb( string userWeb )
        {
            int _UserID = 0;
            if ( !UtilityFun.IsEmptyString( userWeb ) )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _UserID = _DAL.GetUserIDByUserWeb( userWeb );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.UserGetIDByUserWeb抛出异常：" + ex.Message );
                }
            }
            return _UserID;
        }
        #endregion

        #region 个人主页获取会员基础信息
        /// <summary>
        /// 个人主页获取会员基础信息
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public DataSet GetUserBaseInfo( int userID )
        {
            DataSet _DS = null;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _DS = _DAL.GetUserBaseInfo( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetUserBaseInfo抛出异常：" + ex.Message );
                }
            }
            return _DS;
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
            DataSet _DS = null;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _DS = _DAL.GetUserPrivSetByID( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.UsersGetPrivSet抛出异常：" + ex.Message );
                }
            }
            return _DS;
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
            int _Result = -1;
            if ( userID > 0 && friendID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Result = _DAL.CheckUserFriendLink( userID, friendID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.CheckUserFriendLink抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion

        #region 会员中心-消费记录
        /// <summary>
        /// 会员中心-消费记录
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
            DataSet _DS = null;
            count = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _DS = _DAL.GetMemberCenterUserConsumption( userID, FIdx, EIdx, beginTime, endTime, isCount, out count );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetMemberCenterUserConsumption抛出异常：" + ex.Message );
                }
            }
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
            DataSet _DS = null;
            count = 0;
            if ( userid > 0 && FIdx > 0 && EIdx > FIdx )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _DS = _DAL.GetMemberCenterUserConsumptionEx( FIdx, EIdx, beginTime, endTime, userid, isCount, out count );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetMemberCenterUserConsumptionEx Exception:" + ex.Message );
                }
            }
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
            DataSet _DS = null;
            if ( userID > 0 && shopID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _DS = _DAL.GetMemberCenterUserConsumptionDetail( userID, shopID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetMemberCenterUserConsumptionDetail抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 获取会员登录后的相关信息
        /// <summary>
        /// 会员登录后获取相关信息
        /// UserID,UserName,UserMobile,UserEmail,UserPhoto,UserWeb,userPrevTime,UserBirthAreaName,UserExperience
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public DataSet GetUserCachedInfo( int userID )
        {
            DataSet _DS = null;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _DS = _DAL.GetUserCachedInfo( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetUserCachedInfo抛出异常：" + ex.Message );
                }
            }
            return _DS;
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
            DataSet _DS = null;
            count = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _DS = _DAL.GetMemberCenterUserRecharge( FIdx, EIdx, beginTime, endTime, userID, isCount, out count );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetMemberCenterUserPays抛出异常：" + ex.Message );
                }
            }
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
            int _Sum = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Sum = _DAL.GetUserPaySum( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "User.GetUserPaySum抛出异常：" + ex.Message );
                }
            }
            return _Sum;
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
            DataSet _DS = null;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _DS = _DAL.GetUserMoneyByUserID( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetUserMoneyByUserID抛出异常：" + ex.Message );
                }
            }
            return _DS;
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
        public bool InsertUserCartPaymentRecord( int userID, int payBalance, long shopID, string shopKey, long points, byte payDevice, string payIP )
        {
            bool _Result = false;
            try
            {
                //2016.12.07 增加使用佣金支付调整，前端不再提供此过程 czm

                //IDALUsers _DAL = new DALUsers();
                //_Result = _DAL.InsertUserCartPaymentRecord( userID, payBalance, shopID, shopKey, points, payDevice, payIP ) > 0;
                //_DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.InsertUserCartPaymentRecord抛出异常：" + ex.Message );
            }
            return _Result;
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
            bool _Result = false;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.InsertUserRechargePaymentRecord( userID, payMoney, shopID, shopKey, payDevice, payIP, payBalance, payCodeID, payPoint, payBroker, paySource );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.InsertUserRechargePaymentRecord抛出异常：" + ex.Message );
            }
            return _Result;
        }
        #endregion

        #region 获取某用户所有绑定类型
        /// <summary>
        /// 获取某用户所有绑定类型
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns>返回格式：1,2,3</returns>
        public string GetUserBindTypeList( int userID )
        {
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

        #region 获取会员绑定类型(旧的解决方案)
        /// <summary>
        /// 获取会员绑定类型 0本站 1电信云密保
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int GetUserBindTypeByID( int userID )
        {
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

        #region 获取会员信息
        /// <summary>
        /// 获取会员信息
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public DataSet GetUserInfoByID( int userID )
        {
            DataSet _DS = null;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _DS = _DAL.GetUserInfoByID( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetUserInfoByID抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 更新会员昵称与绑定类型值
        /// <summary>
        /// 更新会员昵称与绑定类型值
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="userName"></param>
        /// <param name="bindType"></param>
        /// <returns>1成功   -1失败</returns>
        public int UpdateYmbUserByID( int userID, string userName, int bindType )
        {
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
                    UtilityFile.AddLogErrMsg( "Users.UpdateYbmUserByID抛出异常：" + ex.Message );
                }
            }
            return _Result;
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
            int _Result = 0;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.CheckNickName( userID, nickName );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.CheckNickName抛出异常：" + ex.Message );
            }
            return _Result;
        }
        #endregion

        #region 会员中心-修改会员头像
        /// <summary>
        /// 会员中心-修改会员头像
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="photoUrl">头像路径</param>
        /// <returns></returns>
        public bool UpdateMemberCenterForUserPhoto( int userID, string photoUrl )
        {
            bool _Result = false;
            if ( userID > 0 && photoUrl != "" )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Result = _DAL.UpdateMemberCenterForUserPhoto( userID, photoUrl ) > 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.UpdateMemberCenterForUserPhoto抛出异常：" + ex.Message );
                }
            }
            return _Result;
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
            bool _Result = false;
            if ( userID > 0 && openId != "" )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Result = _DAL.InsertQQAuth( userID, openId, accessToken );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.InsertQQAuth抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }

        /// <summary>
        /// 从qq授权信息表中获取会员ID
        /// </summary>
        /// <param name="openId">用户身份唯一标识</param>
        /// <returns>存在则userID，不存在则0</returns>
        public int GetUserIDFromQQAuth( string openId )
        {
            int _UserID = 0;
            if ( openId != "" )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _UserID = _DAL.GetUserIDFromQQAuth( openId );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetUserIDFromQQAuth抛出异常：" + ex.Message );
                }
            }
            return _UserID;
        }

        /// <summary>
        /// QQ授权自动完成注册信息
        /// 返回值：
        /// >0 注册成功userID
        /// -1 注册失败
        /// </summary>
        /// <param name="userEmail">注册邮件地址（qqlogin_[Guid]@qq.com产生）</param>
        /// <param name="userPwd">登录密码（随机产生）</param>
        /// <param name="userIP">注册IP</param>
        /// <param name="invitedUserID">邀请者ID</param>
        /// <param name="openID">用户身份唯一标识</param>
        /// <param name="accessToken">用户授权信息</param>
        /// <returns></returns>
        public int SkipQQAuthRegister( string userEmail, string userPwd, string userIP, int invitedUserID, int marketUserID, string openID, string accessToken )
        {
            int _Result = 0;
            if ( userEmail != "" && userPwd != "" && openID != "" )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Result = _DAL.SkipQQAuthRegister( userEmail, userPwd, userIP, invitedUserID, marketUserID, openID, accessToken );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.SkipQQAuthRegister抛出异常：" + ex.Message );
                }
            }
            return _Result;
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
            string _Photo = "";
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Photo = _DAL.GetMemberCenterForUserPhoto( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetMemberCenterForUserPhoto Exception:" + ex.Message );
                }
            }
            return _Photo;
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
            DataSet _DS = null;
            if ( userID > 0 && quanlity > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _DS = _DAL.GetLatestVisitors( userID, quanlity );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetLatestVisitors Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 插入访客记录
        /// <summary>
        /// 插入访客记录
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="browserID"></param>
        /// <returns></returns>
        public bool InsertUserWebBrowser( int userID, int browserID, long ipNum )
        {
            bool _Result = false;
            if ( userID > 0 && browserID > 0 && ipNum > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Result = _DAL.InsertUserWebBrowser( userID, browserID, ipNum ) > 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.InsertUserWebBrowser Exception:" + ex.Message );
                }
            }
            return _Result;
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
            DataSet _DS = null;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _DS = _DAL.GetUserLatestMessage( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetUserLatestMessage Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 分页获取会员的好友
        /// <summary>
        /// 获取会员的好友
        /// table0：好友记录；table1：记录数目
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        public DataSet GetUserFriends( int userID, int quanlity, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            if ( userID > 0 && quanlity > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _DS = _DAL.GetUserFriends( userID, quanlity, out totalCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetUserFriends Exception:" + ex.Message );
                }
            }
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
        public DataSet GetUserFriendsList( int userID, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _DS = _DAL.GetUserFriends( userID, FIdx, EIdx, isCount, out totalCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetUserFriends Exception:" + ex.Message );
                }
            }
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
            int _Result = 0;
            if ( userID > 0 && applyUserID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Result = _DAL.InsertUserFriendApply( userID, applyUserID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.InsertUserFriendApply Exception:" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion

        #region 给会员发送私信
        /// <summary>
        /// 给会员发送私信
        /// -2  禁止任何人发私信
        /// -1  只接受好友的私信
        ///  0  失败
        ///  1  成功
        /// </summary>
        /// <param name="inceptUserID">接收方ID</param>
        /// <param name="senderUserID">发送者ID</param>
        /// <param name="content">私信内容</param>
        /// <returns></returns>
        public int InsertUserPrivMsg( int inceptUserID, int senderUserID, string content )
        {
            int _Result = -3;
            if ( inceptUserID > 0 && senderUserID > 0 && content != "" )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Result = _DAL.InsertUserPrivMsg( inceptUserID, senderUserID, content );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.InsertUserPrivMsg Exception:" + ex.Message );
                }
            }
            return _Result;
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
        /// <returns></returns>
        public int InsertSuggestMessage( string title, string userName, string userTel, string userEmail, string codeID, string content, string IP )
        {
            int _RetVal = -1;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _RetVal = _DAL.InsertSuggestMessage( title, userName, userTel, userEmail, codeID, content, IP, "", "", "", "" );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.InsertSuggestMessage Exception:" + ex.Message );
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
            DataSet _DS = null;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _DS = _DAL.GetUserBaseInfoForUserVerify( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetUserBaseInfoForUserVerify Exception:" + ex.Message );
                }
            }
            return _DS;
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
            int _Result = 0;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.UpdateMemberCenterForUserDetail( userID, userName, userQQ, userPhone, userSex, userBirthday, userBirthStar, userBirthArea, userBirthAreaName,
                    userLiveArea, userLiveAreaName, userMonthIncome, userSignature, userBirthUpdateTime, userVerifyName, userVerifySex, userVerifyBirthDay, userVerifyBirthArea,
                    userVerifyLiveArea, userVerifyQQ, userVerifyWage, userVerifySignature );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.UpdateMemberCenterForUserDetail Exception:" + ex.Message );
            }
            return _Result;
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
            DataSet _DS = null;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _DS = _DAL.GetMemberCenterHome( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetMemberCenterHome Exception:" + ex.Message );
                }
            }
            return _DS;
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
            DataSet _DS = null;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _DS = _DAL.GetMemberCenterUserInfo( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetMemberCenterUserInfo Exception:" + ex.Message );
                }
            }
            return _DS;
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
        public bool UpdateMemberCenterForUserBase( int userID, string userMobile, string userEmail )
        {
            bool _Flag = false;
            if ( userID > 0 && ( !UtilityFun.IsEmptyString( userMobile ) || !UtilityFun.IsEmptyString( userEmail ) ) )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Flag = _DAL.UpdateMemberCenterForUserBase( userID, userMobile, userEmail ) > 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.UpdateMemberCenterForUserBase Exception:" + ex.Message );
                }
            }
            return _Flag;
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
            int _Result = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Result = _DAL.UpdateUserPrivSet( userID, userPrivMsgSet, userAreaSet, userSearchSet, buySet, rafSet, postSet, buyShowNum, rafShowNum, postShowNum );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.UpdateUserPrivSet Exception:" + ex.Message );
                }
            }
            return _Result;
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
            int _Result = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Result = _DAL.CheckUserSign( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.CheckUserSign Exception:" + ex.Message );
                }
            }
            return _Result;
        }
        /// <summary>
        /// 会员中心 - 签到
        /// 1 签到成功;0 签到失败;-1 已经签到
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int InsertUserSignLog( int userID )
        {
            int _Result = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Result = _DAL.InsertUserSignLog( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.InsertUserSignLog Exception:" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion

        #region 支付状态反查相关方法
        /// <summary>
        /// 查询需要回查的支付记录列表
        /// shopID,orderTime
        /// </summary>
        /// <param name="payTypeNO">支付方式编号</param>
        /// <returns></returns>
        public DataSet GetPaymentRecordCheckList( int payTypeNO )
        {
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

        #region 统计会员获得的商品最新个数
        /// <summary>
        /// 统计会员获得的商品最新个数
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="orderNO"></param>
        /// <returns></returns>
        public int GetMemberCenterForUserRaffleNewCount( int userID, int orderNO )
        {
            int _Count = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Count = _DAL.GetMemberCenterForUserRaffleNewCount( userID, orderNO );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetMemberCenterForUserRaffleNewCount Exception:" + ex.Message );
                }
            }
            return _Count;
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
            int _Result = 0;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.InsertTransferAccount( outUserID, inUserID, money, inAccount, transMemo );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.InsertTransferAccount Ex:" + ex.Message );
            }
            return _Result;
        }

        /// <summary>
        /// 执行余额转账
        /// </summary>
        /// <param name="transID">转账申请ID</param>
        /// <param name="outUserID">转出账号ID</param>
        /// <returns></returns>
        public int ExecuteTransferAccount( int transID, int outUserID )
        {
            int _Result = 0;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.ExecuteTransferAccount( transID, outUserID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.ExecuteTransferAccount Ex:" + ex.Message );
            }
            return _Result;
        }

        /// <summary>
        /// 删除转账申请
        /// </summary>
        /// <param name="transID">转账申请ID</param>
        /// <param name="outUserID">转出账号ID</param>
        /// <returns></returns>
        public int DeleteTransferAccount( int transID, int outUserID )
        {
            int _Result = 0;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.DeleteTransferAccount( transID, outUserID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.DeleteTransferAccount Ex:" + ex.Message );
            }
            return _Result;
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
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _DS = _DAL.GetTransferAccountList( userID, beginTime, endTime, state, transferWay, FIdx, EIdx, isCount, out totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.GetTransferAccountList Ex:" + ex.Message );
            }
            return _DS;
        }

        /// <summary>
        /// 根据转帐申请ID获取详细信息
        /// </summary>
        /// <param name="transID">转账申请ID</param>
        /// <returns></returns>
        public DataSet GetTransferByTransID( int transID )
        {
            DataSet _DS = null;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _DS = _DAL.GetTransferByTransID( transID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.GetTransferByTransID Ex:" + ex.Message );
            }
            return _DS;
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
            int _Result = 0;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.UpdateCardStateByAccount( cardAccount, buyPlat );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.UpdateCardStateByAccount Ex:" + ex.Message );
            }
            return _Result;
        }

        /// <summary>
        /// 获取充值卡信息
        /// </summary>
        /// <param name="cardAccount">充值卡账号</param>
        /// <returns></returns>
        public DataSet GetCardInfoByAccount( long cardAccount )
        {
            DataSet _DS = null;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _DS = _DAL.GetCardInfoByAccount( cardAccount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.GetCardInfoByAccount Ex:" + ex.Message );
            }
            return _DS;
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
            int _Result = 0;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.UpdateCardWasteByUserID( userID, cardAccount, cardPwd, userIP );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.UpdateCardWasteByUserID Ex:" + ex.Message );
            }
            return _Result;
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
            int _Result = 0;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.SetUserPayPwdByUserID( userID, userPayPwd );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.SetUserPayPwdByUserID Ex:" + ex.Message );
            }
            return _Result;
        }

        /// <summary>
        /// 修改支付密码
        /// </summary>
        /// <param name="userID">用户 ID</param>
        /// <param name="userPayPwd">用户支付密码</param>
        /// <returns></returns>
        public int UpdateUserPayPwdByUserID( int userID, string userPayPwd )
        {
            int _Result = 0;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.UpdateUserPayPwdByUserID( userID, userPayPwd );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.UpdateUserPayPwdByUserID Ex:" + ex.Message );
            }
            return _Result;
        }

        /// <summary>
        /// 关闭用户支付密码
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public int CloseUserPayPwdByUserID( int userID )
        {
            int _Result = 0;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.CloseUserPayPwdByUserID( userID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.CloseUserPayPwdByUserID Ex:" + ex.Message );
            }
            return _Result;
        }

        /// <summary>
        /// 修改小额免密码金额
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="smallPayMoney">免密码金额</param>
        /// <returns></returns>
        public int UpdateSmallPayMoneyByUserID( int userID, int smallPayMoney )
        {
            int _Result = 0;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.UpdateSmallPayMoneyByUserID( userID, smallPayMoney );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.UpdateSmallPayMoneyByUserID Ex:" + ex.Message );
            }
            return _Result;
        }

        /// <summary>
        /// 验证支付密码
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="userPayPwd">支付密码</param>
        /// <returns></returns>
        public int CheckPayPwdByUserID( int userID, string userPayPwd )
        {
            int _Result = 0;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.CheckPayPwdByUserID( userID, userPayPwd );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.CheckPayPwdByUserID Ex:" + ex.Message );
            }
            return _Result;
        }

        /// <summary>
        /// 设置登录保护
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="isWxKeeyLogin">1微信提示，0不提示</param>
        /// <returns>1成功，－1用户不存在</returns>
        public int SetWxKeepLoginByUserID( int userID, int isWxKeeyLogin )
        {
            int _Result = 0;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.SetWxKeepLoginByUserID( userID, isWxKeeyLogin );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.SetWxKeepLoginByUserID Ex:" + ex.Message );
            }
            return _Result;
        }

        /// <summary>
        /// 设置购买失败的微信邮箱消息推送开关
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="isWxMailSend"></param>
        /// <returns></returns>
        public int SetWxMailNoticeByUserID( int userID, int isWxMailSend )
        {
            int _Result = 0;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.SetWxMailNoticeByUserID( userID, isWxMailSend );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.SetWxMailNoticeByUserID Ex:" + ex.Message );
            }
            return _Result;
        }

        /// <summary>
        /// 设置购买失败的云购帐户系统消息推送
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="isSysMsgSend"></param>
        /// <returns></returns>
        public int SetSysMsgNoticeByUserID( int userID, int isSysMsgSend )
        {
            int _Result = 0;
            try
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.SetSysMsgNoticeByUserID( userID, isSysMsgSend );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Users.SetSysMsgNoticeByUserID Ex:" + ex.Message );
            }
            return _Result;
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
            DataSet _DS = null;
            if ( cartID > 0L )
            {
                try
                {
                    IDALUsers _DALUsers = new DALUsers();
                    _DS = _DALUsers.GetPaymentRecordList( cartID, isSingle );
                    _DALUsers = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetPaymentRecordList抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 获取云购结果的信息
        /// <summary>
        /// 获取云购结果的信息
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="userID">购物车ID</param>
        /// <param name="state">返回状态</param>
        /// <returns></returns>
        public DataSet GetUserShopInfo( int userID, long shopID, out int state )
        {
            DataSet _DS = null;
            state = -1;
            if ( userID > 0 && shopID > 0L )
            {
                try
                {
                    IDALUsers _DALUsers = new DALUsers();
                    _DS = _DALUsers.GetUserShopInfo( userID, shopID, out state );
                    _DALUsers = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetUserShopInfo抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
    }
}
