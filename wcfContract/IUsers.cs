using System;
using System.Data;
using System.ServiceModel;

namespace wcfNSYGShop
{
    /// <summary>
    /// 会员帐户等相关接口
    /// </summary>
    public partial interface IWCFContract
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
        [OperationContract]
        int InsertUser( string userMobile, string userEmail, string userName, string userPwd, string userKey,
            decimal userBlance, string userRegIP, int inviteUserID, int marketUserID, int userRegSource );
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
        [OperationContract]
        int LoginUser( string userMobile, string userEmail, string userPwd, string userLastIP, int loginDevice );
        #endregion

        #region 记录登录日志
        /// <summary>
        /// 记录登录日志，针对第三方快速登录的
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="userLastIP"></param>
        /// <returns></returns>
        [OperationContract]
        bool InsertUserLoginLog( int userID, string userLastIP, int loginDevice );
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
        [OperationContract]
        int CheckUserAccount( string userAccount, string userPwd );
        #endregion

        #region 查询会员余额
        /// <summary>
        /// 查询会员余额
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [OperationContract]
        decimal GetUserBalance( int userID );
        #endregion

        #region 会员消费总金额
        /// <summary>
        /// 会员消费总金额
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        [OperationContract]
        int GetUserConsumptionSum( int userID );
        #endregion

        #region 获取会员ID号
        /// <summary>
        /// 获取会员ID号
        /// </summary>
        /// <param name="str">手机号、Email、昵称任一项</param>
        /// <returns></returns>
        [OperationContract]
        int GetUserIDByStr( string str );
        #endregion

        #region 修改会员Key
        /// <summary>
        /// 修改会员Key
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateUserKey( int userID, string key );
        #endregion

        #region 查询会员的key
        /// <summary>
        /// 查询会员的key
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        [OperationContract]
        string GetUserKey( int userID );
        #endregion

        #region 更新会员密码
        /// <summary>
        /// 更新会员密码,只能更新forbid为0,3状态会员
        /// </summary>
        /// <param name="userID">会员ID号</param>
        /// <param name="password">密码对应的密文(sha1)</param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateUserPassword( int userID, string password );
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
        [OperationContract]
        int GetUserForbid( int userID );
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
        [OperationContract]
        bool UpdateUserForbid( int userID, int forbid, DateTime unForbidTime, string reason );
        #endregion

        #region 根据主页标识获取会员ID号
        /// <summary>
        /// 根据主页标识获取会员ID号
        /// </summary>
        /// <param name="userWeb">会员主页标识</param>
        /// <returns></returns>
        [OperationContract]
        int GetUserIDByUserWeb( string userWeb );
        #endregion

        #region 个人主页获取会员基础信息
        /// <summary>
        /// 个人主页获取会员基础信息
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserBaseInfo( int userID );
        #endregion

        #region 获取会员隐私设置[云购记录、获得的商品、晒单记录]-个人主页显示用到
        /// <summary>
        /// 获取会员隐私设置[云购记录、获得的商品、晒单记录]
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserPrivSetByID( int userID );
        #endregion

        #region 检测两个用户之间是否为好友关系
        /// <summary>
        /// 检测两个用户之间是否为好友关系
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="friendID">另一个会员ID</param>
        /// <returns>（-1:非好友，0:已发送请求，1:已是好友）</returns>
        [OperationContract]
        int CheckUserFriendLink( int userID, int friendID );
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
        [OperationContract]
        DataSet GetMemberCenterUserConsumption( int userID, int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int isCount, out int count );

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
        [OperationContract]
        DataSet GetMemberCenterUserConsumptionEx( int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int userid, int isCount, out int count );
        #endregion

        #region 会员中心-消费详情
        /// <summary>
        /// 会员中心-消费详情
        /// </summary>
        /// <param name="userID">用户id</param>
        /// <param name="shopID">购物车id</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetMemberCenterUserConsumptionDetail( int userID, long shopID );
        #endregion

        #region 获取会员登录后的相关信息
        /// <summary>
        /// 会员登录后获取相关信息
        /// UserID,UserName,UserMobile,UserEmail,UserPhoto,UserWeb,userPrevTime,UserBirthAreaName,UserExperience
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserCachedInfo( int userID );
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
        [OperationContract]
        DataSet GetMemberCenterUserRecharge( int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int userID, int isCount, out int count );
        #endregion

        #region 会员充值总金额
        /// <summary>
        /// 会员充值总金额
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        [OperationContract]
        int GetUserPaySum( int userID );
        #endregion

        #region 查询用户充值、消费、转入、转出的总额
        /// <summary>
        /// 查询用户充值、消费、转入、转出的总额
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserMoneyByUserID( int userID );
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
        [OperationContract]
        bool InsertUserCartPaymentRecord( int userID, int payBalance, long shopID, string shopKey, long points, byte payDevice, string payIP );
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
        [OperationContract]
        bool InsertUserRechargePaymentRecord( int userID, decimal payMoney, long shopID, string shopKey, byte payDevice, string payIP, int payBalance, int payCodeID, int payPoint, int payBroker, int paySource );
        #endregion

        #region 获取某用户所有绑定类型
        /// <summary>
        /// 获取某用户所有绑定类型
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns>返回格式：1,2,3</returns>
        [OperationContract]
        string GetUserBindTypeList( int userID );
        #endregion

        #region 获取会员绑定类型(旧的解决方案)
        /// <summary>
        /// 获取会员绑定类型 0本站 1电信云密保
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [OperationContract]
        int GetUserBindTypeByID( int userID );
        #endregion

        #region 获取会员信息
        /// <summary>
        /// 获取会员信息
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserInfoByID( int userID );
        #endregion

        #region 更新会员昵称与绑定类型值
        /// <summary>
        /// 更新会员昵称与绑定类型值
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="userName"></param>
        /// <param name="bindType"></param>
        /// <returns>1成功   -1失败</returns>
        [OperationContract]
        int UpdateYmbUserByID( int userID, string userName, int bindType );
        #endregion

        #region 检查昵称是否存在
        /// <summary>
        /// 检查昵称是否存在
        /// </summary>
        /// <param name="nickName">昵称</param>
        /// <returns>1存在，0不存在</returns>
        [OperationContract]
        int CheckNickName( int userID, string nickName );
        #endregion

        #region 会员中心-修改会员头像
        /// <summary>
        /// 会员中心-修改会员头像
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="photoUrl">头像路径</param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateMemberCenterForUserPhoto( int userID, string photoUrl );
        #endregion

        #region QQ互联登录

        /// <summary>
        /// qq登录后填写相关信息
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="openId">用户身份唯一标识</param>
        /// <param name="accessToken">用户授权信息</param>
        /// <returns></returns>
        [OperationContract]
        bool InsertQQAuth( int userID, string openId, string accessToken );

        /// <summary>
        /// 从qq授权信息表中获取会员ID
        /// </summary>
        /// <param name="openId">用户身份唯一标识</param>
        /// <returns>存在则userID，不存在则0</returns>
        [OperationContract]
        int GetUserIDFromQQAuth( string openId );

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
        [OperationContract]
        int SkipQQAuthRegister( string userEmail, string userPwd, string userIP, int invitedUserID, int marketUserID, string openID, string accessToken );
        #endregion

        #region 获取会员头像
        /// <summary>
        /// 获取会员头像
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        [OperationContract]
        string GetMemberCenterForUserPhoto( int userID );
        #endregion

        #region 获取会员的最新访客
        /// <summary>
        /// 获取会员的最新访客
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetLatestVisitors( int userID, int quanlity );
        #endregion

        #region 插入访客记录
        /// <summary>
        /// 插入访客记录
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="browserID"></param>
        /// <param name="ipNum">访客的IP数字型式</param>
        /// <returns></returns>
        [OperationContract]
        bool InsertUserWebBrowser( int userID, int browserID, long ipNum );
        #endregion

        #region 获取会员最新动态
        /// <summary>
        /// 获取会员最新动态
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserLatestMessage( int userID );
        #endregion

        #region 分页获取会员的好友
        /// <summary>
        /// 获取会员的好友
        /// table0：好友记录；table1：记录数目
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="quanlity"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserFriends( int userID, int quanlity, out int totalCount );
        /// <summary>
        /// 分页获取会员的好友
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserFriendsList( int userID, int FIdx, int EIdx, int isCount, out int totalCount );
        #endregion

        #region 插入申请加为好友的验证信息
        /// <summary>
        /// 插入申请加为好友的验证信息
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="applyUserID"></param>
        /// <returns></returns>
        [OperationContract]
        int InsertUserFriendApply( int userID, int applyUserID );
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
        [OperationContract]
        int InsertUserPrivMsg( int inceptUserID, int senderUserID, string content );
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
        [OperationContract]
        int InsertSuggestMessage( string title, string userName, string userTel, string userEmail, string codeID, string content, string IP );
        #endregion

        #region 获取会员相关资料的验证信息
        /// <summary>
        /// 获取会员相关资料的验证信息
        /// </summary>
        /// <param name="_UserID">会员ID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserBaseInfoForUserVerify( int userID );
        #endregion

        #region 会员中心-修改个人详细资料
        /// <summary>
        /// 会员中心-修改个人详细资料
        /// </summary>
        /// <param name="model">用户实例</param>
        /// <param name="modelVerify">用户验证实例</param>
        /// <returns></returns>
        [OperationContract]
        int UpdateMemberCenterForUserDetail( int userID, string userName, string userQQ, string userPhone, int userSex, DateTime userBirthday, int userBirthStar,
            int userBirthArea, string userBirthAreaName, int userLiveArea, string userLiveAreaName, string userMonthIncome, string userSignature, DateTime userBirthUpdateTime,
            int userVerifyName, int userVerifySex, int userVerifyBirthDay, int userVerifyBirthArea, int userVerifyLiveArea, int userVerifyQQ, int userVerifyWage, int userVerifySignature );
        #endregion

        #region 会员中心首页信息
        /// <summary>
        /// 会员中心首页信息
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetMemberCenterHome( int userID );
        #endregion

        #region 会员中心-个人资料详情
        /// <summary>
        /// 会员中心-个人资料详情
        /// </summary>
        /// <param name="userID">用户id</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetMemberCenterUserInfo( int userID );
        #endregion

        #region 会员中心-修改个人基本资料
        /// <summary>
        /// 会员中心-修改个人基本资料
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="userMobile"></param>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateMemberCenterForUserBase( int userID, string userMobile, string userEmail );
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
        [OperationContract]
        int UpdateUserPrivSet( int userID, int userPrivMsgSet, int userAreaSet, int userSearchSet, int buySet, int rafSet, int postSet, int buyShowNum, int rafShowNum, int postShowNum );
        #endregion

        #region 会员首页签到
        /// <summary>
        /// 会员首页-检测会员是否已签到
        /// -1 未签到; 1 已经签到
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [OperationContract]
        int CheckUserSign( int userID );
        /// <summary>
        /// 会员中心 - 签到
        /// 1 签到成功;0 签到失败;-1 已经签到
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [OperationContract]
        int InsertUserSignLog( int userID );
        #endregion

        #region 支付状态反查相关方法
        /// <summary>
        /// 查询需要回查的支付记录列表
        /// shopID,orderTime
        /// </summary>
        /// <param name="payTypeNO">支付方式编号</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetPaymentRecordCheckList( int payTypeNO );
        #endregion

        #region 统计会员获得的商品最新个数
        /// <summary>
        /// 统计会员获得的商品最新个数
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="orderNO"></param>
        /// <returns></returns>
        [OperationContract]
        int GetMemberCenterForUserRaffleNewCount( int userID, int orderNO );
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
        [OperationContract]
        int InsertTransferAccount( int outUserID, int inUserID, int money, string inAccount, string transMemo );

        /// <summary>
        /// 执行余额转账
        /// </summary>
        /// <param name="transID">转账申请ID</param>
        /// <param name="outUserID">转出账号ID</param>
        /// <returns></returns>
        [OperationContract]
        int ExecuteTransferAccount( int transID, int outUserID );

        /// <summary>
        /// 删除转账申请
        /// </summary>
        /// <param name="transID">转账申请ID</param>
        /// <param name="outUserID">转出账号ID</param>
        /// <returns></returns>
        [OperationContract]
        int DeleteTransferAccount( int transID, int outUserID );

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
        [OperationContract]
        DataSet GetTransferAccountList( int userID, DateTime beginTime, DateTime endTime, int state, int transferWay, int FIdx, int EIdx, int isCount, out int totalCount );

        /// <summary>
        /// 根据转帐申请ID获取详细信息
        /// </summary>
        /// <param name="transID">转账申请ID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetTransferByTransID( int transID );

        #endregion

        #region 会员充值卡充值模块

        /// <summary>
        /// 购买充值卡时更新卡状态
        /// </summary>
        /// <param name="cardAccount">充值卡账号</param>
        /// <param name="buyPlat">1：淘宝</param>
        /// <returns></returns>
        [OperationContract]
        int UpdateCardStateByAccount( long cardAccount, int buyPlat );

        /// <summary>
        /// 获取充值卡信息
        /// </summary>
        /// <param name="cardAccount">充值卡账号</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetCardInfoByAccount( long cardAccount );

        /// <summary>
        /// 用户使用充值卡进行充值
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="cardAccount">充值卡账号</param>
        /// <param name="cardPwd">充值卡密码</param>
        /// <returns></returns>
        [OperationContract]
        int UpdateCardWasteByUserID( int userID, long cardAccount, int cardPwd, string userIP );

        #endregion

        #region 安全设置－支付密码模块
        /// <summary>
        /// 开启支付密码
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="userPayPwd">用户支付密码</param>
        /// <returns></returns>
        [OperationContract]
        int SetUserPayPwdByUserID( int userID, string userPayPwd );

        /// <summary>
        /// 修改支付密码
        /// </summary>
        /// <param name="userID">用户 ID</param>
        /// <param name="userPayPwd">用户支付密码</param>
        /// <returns></returns>
        [OperationContract]
        int UpdateUserPayPwdByUserID( int userID, string userPayPwd );

        /// <summary>
        /// 关闭用户支付密码
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        [OperationContract]
        int CloseUserPayPwdByUserID( int userID );

        /// <summary>
        /// 修改小额免密码金额
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="smallPayMoney">免密码金额</param>
        /// <returns></returns>
        [OperationContract]
        int UpdateSmallPayMoneyByUserID( int userID, int smallPayMoney );

        /// <summary>
        /// 验证支付密码
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="userPayPwd">支付密码</param>
        /// <returns></returns>
        [OperationContract]
        int CheckPayPwdByUserID( int userID, string userPayPwd );

        /// <summary>
        /// 设置登录保护
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="isWxKeeyLogin">1微信提示，0不提示</param>
        /// <returns>1成功，－1用户不存在</returns>
        [OperationContract]
        int SetWxKeepLoginByUserID( int userID, int isWxKeeyLogin );

        /// <summary>
        /// 设置购买失败的微信邮箱消息推送开关
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="isWxMailSend"></param>
        /// <returns></returns>
        [OperationContract]
        int SetWxMailNoticeByUserID( int userID, int isWxMailSend );

        /// <summary>
        /// 设置购买失败的云购帐户系统消息推送
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="isSysMsgSend"></param>
        /// <returns></returns>
        [OperationContract]
        int SetSysMsgNoticeByUserID( int userID, int isSysMsgSend );
        #endregion

        #region 根据购物车ID查询交易记录
        /// <summary>
        /// 根据购物车ID查询交易记录
        /// </summary>
        /// <param name="cartID">购物车ID</param>
        /// <param name="isSingle">是否只获取一条记录</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetPaymentRecordList( long cartID, bool isSingle );
        #endregion

        #region 获取云购结果的信息
        /// <summary>
        /// 获取云购结果的信息
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="shopID">购物车ID</param>
        /// <param name="state">返回状态</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserShopInfo( int userID, long shopID, out int state );
        #endregion
    }
}
