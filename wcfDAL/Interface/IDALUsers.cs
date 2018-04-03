using System;
using System.Data;

namespace wcfNSYGShop
{
    public interface IDALUsers
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
        int InsertUser( string userMobile, string userEmail, string userName, string userPwd, string userKey,
            decimal userBlance, string userRegIP, int inviteUserID, int marketUserID, int userRegSource );
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
        /// <returns></returns>
        int LoginUser( string userMobile, string userEmail, string userPwd, string userLastIP, int loginDevice, int isCheckOnly );
        #endregion

        #region 记录登录日志
        /// <summary>
        /// 记录登录日志，针对第三方快速登录的
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="userLastIP"></param>
        /// <returns></returns>
        bool InsertUserLoginLog( int userID, string userLastIP, int loginDevice );
        #endregion

        #region 查询会员余额
        /// <summary>
        /// 查询会员余额
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        decimal GetUserBalance( int userID );
        #endregion

        #region 会员消费总金额
        /// <summary>
        /// 会员消费总金额
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        int GetUserConsumptionSum( int userID );
        #endregion

        #region 获取会员ID号
        /// <summary>
        /// 获取会员ID号
        /// </summary>
        /// <param name="str">手机号、Email、昵称任一项</param>
        /// <returns></returns>
        int GetUserIDByStr( string str );
        #endregion

        #region 修改会员Key
        /// <summary>
        /// 修改会员Key
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        int UpdateUserKey( int userID, string key );
        #endregion

        #region 查询会员的key
        /// <summary>
        /// 查询会员的key
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        string GetUserKey( int userID );
        #endregion

        #region 更新会员密码
        /// <summary>
        /// 更新会员密码,只能更新forbid为0,3状态会员
        /// </summary>
        /// <param name="userID">会员ID号</param>
        /// <param name="password">密码对应的密文(sha1)</param>
        /// <returns></returns>
        int UpdateUserPassword( int userID, string password );
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
        int GetUserForbid( int userID );
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
        bool UpdateUserForbid( int userID, int forbid, DateTime unForbidTime, string reason );
        #endregion

        #region 根据主页标识获取会员ID号
        /// <summary>
        /// 根据主页标识获取会员ID号
        /// </summary>
        /// <param name="userWeb">会员主页标识</param>
        /// <returns></returns>
        int GetUserIDByUserWeb( string userWeb );
        #endregion

        #region 个人主页获取会员基础信息
        /// <summary>
        /// 个人主页获取会员基础信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        DataSet GetUserBaseInfo( int userID );
        #endregion

        #region 获取会员隐私设置[云购记录、获得的商品、晒单记录]-个人主页显示用到
        /// <summary>
        /// 获取会员隐私设置[云购记录、获得的商品、晒单记录]
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        DataSet GetUserPrivSetByID( int userID );
        #endregion

        #region 检测两个用户之间是否为好友关系
        /// <summary>
        /// 检测两个用户之间是否为好友关系
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="friendID">另一个会员ID</param>
        /// <returns>（-1:非好友，0:已发送请求，1:已是好友）</returns>
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
        DataSet GetMemberCenterUserConsumptionEx( int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int userid, int isCount, out int count );
        #endregion

        #region 会员中心-消费详情
        /// <summary>
        /// 会员中心-消费详情
        /// </summary>
        /// <param name="userID">用户id</param>
        /// <param name="shopID">购物车id</param>
        /// <returns></returns>
        DataSet GetMemberCenterUserConsumptionDetail( int userID, long shopID );
        #endregion

        #region 获取会员登录后的相关信息
        /// <summary>
        /// 会员登录后获取相关信息 UserID,UserName,UserMobile,UserEmail,UserPhoto,UserWeb,userPrevTime,UserBirthAreaName,UserExperience
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
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
        DataSet GetMemberCenterUserRecharge( int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int userID, int isCount, out int count );
        #endregion

        #region 会员充值总金额
        /// <summary>
        /// 会员充值总金额
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        int GetUserPaySum( int userID );
        #endregion

        #region 查询用户充值、消费、转入、转出的总额
        /// <summary>
        /// 查询用户充值、消费、转入、转出的总额
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
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
        int InsertUserCartPaymentRecord( int userID, int payBalance, long shopID, string shopKey, long points, byte payDevice, string payIP, int payBroker );
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
        bool InsertUserRechargePaymentRecord( int userID, decimal payMoney, long shopID, string shopKey, byte payDevice, string payIP, int payBalance, int payCodeID, int payPoint, int payBroker, int paySource );
        #endregion

        #region 获取某用户所有绑定类型
        /// <summary>
        /// 获取某用户所有绑定类型
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        DataTable GetUserBindTypeList( int userID );
        #endregion

        #region 获取会员绑定类型(旧的解决方案)
        /// <summary>
        /// 获取会员绑定类型 0本站 1电信云密保
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        int GetUserBindTypeByID( int userID );
        #endregion

        #region 获取会员信息
        /// <summary>
        /// 获取会员信息
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        DataSet GetUserInfoByID( int userID );
        #endregion

        #region 更新会员昵称与绑定类型值
        /// <summary>
        /// 更新会员昵称与绑定类型值
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="userName"></param>
        /// <param name="bindType"></param>
        /// <returns>1成功 -1失败</returns>
        int UpdateYmbUserByID( int userID, string userName, int bindType );
        #endregion

        #region 检查昵称是否存在
        /// <summary>
        /// 检查昵称是否存在
        /// </summary>
        /// <param name="nickName">昵称</param>
        /// <returns>1存在，0不存在</returns>
        int CheckNickName( int userID, string nickName );
        #endregion

        #region 会员中心-修改会员头像
        /// <summary>
        /// 会员中心-修改会员头像
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="photoUrl">头像路径</param>
        /// <returns></returns>
        int UpdateMemberCenterForUserPhoto( int userID, string photoUrl );
        #endregion

        #region QQ互联登录

        /// <summary>
        /// qq登录后填写相关信息
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="openId">用户身份唯一标识</param>
        /// <param name="accessToken">用户授权信息</param>
        /// <returns></returns>
        bool InsertQQAuth( int userID, string openId, string accessToken );

        /// <summary>
        /// 从qq授权信息表中获取会员ID
        /// </summary>
        /// <param name="openId">用户身份唯一标识</param>
        /// <returns>存在则userID，不存在则0</returns>
        int GetUserIDFromQQAuth( string openId );

        /// <summary>
        /// 从qq授权信息表中获取会员ID
        /// </summary>
        /// <param name="openId">用户身份唯一标识</param>
        /// <param name="isAutoLogin">是否自动登录：1不自动，0自动登录，默认0</param>
        /// <returns>存在则userID，不存在则0</returns>
        int GetUserIDFromQQAuth( string openId, out int isAutoLogin );

        /// <summary>
        /// QQ授权自动完成注册信息 返回值： &gt;0 注册成功userID
        /// -1 注册失败
        /// </summary>
        /// <param name="userEmail">注册邮件地址（qqlogin_[Guid]@qq.com产生）</param>
        /// <param name="userPwd">登录密码（随机产生）</param>
        /// <param name="userIP">注册IP</param>
        /// <param name="invitedUserID">邀请者ID</param>
        /// <param name="openID">用户身份唯一标识</param>
        /// <param name="accessToken">用户授权信息</param>
        /// <returns></returns>
        int SkipQQAuthRegister( string userEmail, string userPwd, string userIP, int invitedUserID, int marketUserID, string openID, string accessToken );
        #endregion

        #region 获取会员头像
        /// <summary>
        /// 获取会员头像
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        string GetMemberCenterForUserPhoto( int userID );
        #endregion

        #region 获取会员的最新访客
        /// <summary>
        /// 获取会员的最新访客
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        DataSet GetLatestVisitors( int userID, int quanlity );
        #endregion

        #region 插入访客记录
        /// <summary>
        /// 插入访客记录
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="browserID"></param>
        /// <returns></returns>
        int InsertUserWebBrowser( int userID, int browserID, long ipNum );
        #endregion

        #region 获取会员最新动态
        /// <summary>
        /// 获取会员最新动态
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        DataSet GetUserLatestMessage( int userID );
        #endregion

        #region 分页获取会员的好友
        /// <summary>
        /// 获取会员的好友 table0：好友记录；table1：记录数目
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
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
        DataSet GetUserFriends( int userID, int FIdx, int EIdx, int isCount, out int totalCount );
        #endregion

        #region 插入申请加为好友的验证信息
        /// <summary>
        /// 插入申请加为好友的验证信息
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="applyUserID"></param>
        /// <returns></returns>
        int InsertUserFriendApply( int userID, int applyUserID );
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
        int InsertSuggestMessage( string title, string userName, string userTel, string userEmail, string codeID, string content, string IP, string suggestType, string suggestSubType, string terminalInfo, string uploadPictures );
        #endregion

        #region 获取会员相关资料的验证信息
        /// <summary>
        /// 获取会员相关资料的验证信息
        /// </summary>
        /// <param name="_UserID">会员ID</param>
        /// <returns></returns>
        DataSet GetUserBaseInfoForUserVerify( int userID );
        #endregion

        #region 会员中心-修改个人详细资料
        /// <summary>
        /// 会员中心-修改个人详细资料
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="userName">用户昵称</param>
        /// <param name="userQQ">用户QQ</param>
        /// <param name="userPhone">联系电话</param>
        /// <param name="userSex">性别</param>
        /// <param name="userBirthday">生日</param>
        /// <param name="userBirthStar">星座</param>
        /// <param name="userBirthArea">出生地区ID</param>
        /// <param name="userBirthAreaName">出生地名称</param>
        /// <param name="userLiveArea">居住地区ID</param>
        /// <param name="userLiveAreaName">居住地名称</param>
        /// <param name="userMonthIncome">月收入</param>
        /// <param name="userSignature">签名</param>
        /// <param name="userBirthUpdateTime">生日更新时间</param>
        /// <param name="userVerifyName">是否已填写过昵称</param>
        /// <param name="userVerifySex">是否已填写过性别</param>
        /// <param name="userVerifyBirthDay">是否已填写过生日</param>
        /// <param name="userVerifyBirthArea">是否已填写过出生地</param>
        /// <param name="userVerifyLiveArea">是否已填写过居住地</param>
        /// <param name="userVerifyQQ">是否已填写过qq</param>
        /// <param name="userVerifyWage">是否已填写过收入</param>
        /// <param name="userVerifySignature">是否已填写过签名</param>
        /// <returns></returns>
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
        DataSet GetMemberCenterHome( int userID );
        #endregion

        #region 会员中心-个人资料详情
        /// <summary>
        /// 会员中心-个人资料详情
        /// </summary>
        /// <param name="userID">用户id</param>
        /// <returns></returns>
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
        int UpdateMemberCenterForUserBase( int userID, string userMobile, string userEmail );
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
        int UpdateUserPrivSet( int userID, int userPrivMsgSet, int userAreaSet, int userSearchSet, int buySet, int rafSet, int postSet, int buyShowNum, int rafShowNum, int postShowNum );
        #endregion

        #region 会员首页签到
        /// <summary>
        /// 会员首页-检测会员是否已签到
        /// -1 未签到; 1 已经签到
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        int CheckUserSign( int userID );
        /// <summary>
        /// 会员中心 - 签到 1 签到成功;0 签到失败;-1 已经签到
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        int InsertUserSignLog( int userID );
        #endregion

        #region 支付状态反查相关方法
        /// <summary>
        /// 查询需要回查的支付记录列表 shopID,orderTime
        /// </summary>
        /// <param name="payTypeNO">支付方式编号</param>
        /// <returns></returns>
        DataSet GetPaymentRecordCheckList( int payTypeNO );
        #endregion

        #region 统计会员获得的商品最新个数
        /// <summary>
        /// 统计会员获得的商品最新个数
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="orderNO"></param>
        /// <returns></returns>
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
        int InsertTransferAccount( int outUserID, int inUserID, int money, string inAccount, string transMemo );

        /// <summary>
        /// 执行余额转账
        /// </summary>
        /// <param name="transID">转账申请ID</param>
        /// <param name="outUserID">转出账号ID</param>
        /// <returns></returns>
        int ExecuteTransferAccount( int transID, int outUserID );

        /// <summary>
        /// 删除转账申请
        /// </summary>
        /// <param name="transID">转账申请ID</param>
        /// <param name="outUserID">转出账号ID</param>
        /// <returns></returns>
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
        DataSet GetTransferAccountList( int userID, DateTime beginTime, DateTime endTime, int state, int transferWay, int FIdx, int EIdx, int isCount, out int totalCount );

        /// <summary>
        /// 根据转帐申请ID获取详细信息
        /// </summary>
        /// <param name="transID">转账申请ID</param>
        /// <returns></returns>
        DataSet GetTransferByTransID( int transID );

        #endregion

        #region 会员充值卡充值模块

        /// <summary>
        /// 购买充值卡时更新卡状态
        /// </summary>
        /// <param name="cardAccount">充值卡账号</param>
        /// <param name="buyPlat">1：淘宝</param>
        /// <returns></returns>
        int UpdateCardStateByAccount( long cardAccount, int buyPlat );

        /// <summary>
        /// 获取充值卡信息
        /// </summary>
        /// <param name="cardAccount">充值卡账号</param>
        /// <returns></returns>
        DataSet GetCardInfoByAccount( long cardAccount );

        /// <summary>
        /// 用户使用充值卡进行充值
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="cardAccount">充值卡账号</param>
        /// <param name="cardPwd">充值卡密码</param>
        /// <returns></returns>
        int UpdateCardWasteByUserID( int userID, long cardAccount, int cardPwd, string userIP );

        #endregion

        #region 安全设置－支付密码模块
        /// <summary>
        /// 开启支付密码
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="userPayPwd">用户支付密码</param>
        /// <returns>-1：密码为空，－2已开启，－3支付密码与登录密码相同，1开启成功</returns>
        int SetUserPayPwdByUserID( int userID, string userPayPwd );

        /// <summary>
        /// 修改支付密码
        /// </summary>
        /// <param name="userID">用户 ID</param>
        /// <param name="userPayPwd">用户支付密码</param>
        /// <returns>-1：密码为空，－2未开启支付密码，－3支付密码与登录密码相同，－4新旧支付密码相同，1成功</returns>
        int UpdateUserPayPwdByUserID( int userID, string userPayPwd );

        /// <summary>
        /// 关闭用户支付密码
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns>－1仍未开启，1成功</returns>
        int CloseUserPayPwdByUserID( int userID );

        /// <summary>
        /// 修改小额免密码金额
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="smallPayMoney">免密码金额</param>
        /// <returns>－1金额小于0，－2仍未开启支付密码，－3用户不存在，1成功</returns>
        int UpdateSmallPayMoneyByUserID( int userID, int smallPayMoney );

        /// <summary>
        /// 验证支付密码
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="userPayPwd">支付密码</param>
        /// <returns>－1密码为空，－2用户不存在，－3仍未开启支付密码，－4支付密码因错误次数过多而锁住了，－5密码错误，1成功</returns>
        int CheckPayPwdByUserID( int userID, string userPayPwd );

        /// <summary>
        /// 设置登录保护
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="isWxKeeyLogin">1微信提示，0不提示</param>
        /// <returns>1成功，－1用户不存在</returns>
        int SetWxKeepLoginByUserID( int userID, int isWxKeeyLogin );

        /// <summary>
        /// 设置购买失败的微信邮箱消息推送开关
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="isWxMailSend"></param>
        /// <returns></returns>
        int SetWxMailNoticeByUserID( int userID, int isWxMailSend );

        /// <summary>
        /// 设置购买失败的云购帐户系统消息推送
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="isSysMsgSend"></param>
        /// <returns></returns>
        int SetSysMsgNoticeByUserID( int userID, int isSysMsgSend );
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
        DataSet GetMemberCenterAllBalanceRecord( int userID, DateTime beginTime, DateTime endTime, int FIdx, int EIdx, int isCount, out int totalCount );
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
        DataSet GetMemberCenterBrokerPageByUserID( int userID, int brokerType, DateTime beginTime, DateTime endTime, int FIdx, int EIdx, int isCount, out int totalCount );
        #endregion

        #region 添加会员邀请链接短地址
        /// <summary>
        /// 添加会员邀请链接短地址
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="urlType">地址类型 0.会员中心 1.邀请页面</param>
        /// <param name="shortUrl">短地址</param>
        /// <returns></returns>
        int InsertUserShortUrl( int userID, int urlType, string shortUrl );
        #endregion

        #region 根据短地址获取用户ID
        /// <summary>
        /// 根据短地址获取用户ID
        /// </summary>
        /// <param name="shortUrl">短地址</param>
        /// <returns></returns>
        DataSet GetUserIDByShortUrl( string shortUrl );
        #endregion

        #region 根据用户ID获取短地址
        /// <summary>
        /// 根据用户ID获取短地址
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        DataSet GetShortUrlByUserID( int userID );
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
        int InsertReportUser( int userID, int reportUserID, int reportGroupID, int kind, int repplyID, int type, int level, string content, string reportContent, int device, string allPic );
        #endregion

        #region 根据购物车ID查询交易记录
        /// <summary>
        /// 根据购物车ID查询交易记录
        /// </summary>
        /// <param name="cartID">购物车ID</param>
        /// <param name="isSingle">是否只获取一条记录</param>
        /// <returns></returns>
        DataSet GetPaymentRecordList( long cartID, bool isSingle );
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
        DataSet GetUserShopInfo( int userID, long shopID, out int state );
        #endregion

        #region 会员中心换货补扣差价
        /// <summary>
        /// 会员中心换货补扣差价
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="applyID">换货申请ID</param>
        /// <returns></returns>
        int UpdateMinusPriceByUserID( int userID, int applyID );
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
        DataSet GetExChangeListByUserID( int userID, int FIdx, int EIdx, int isCount, out int totalCount );
        #endregion

        #region 根据换货编号获取换货详情
        /// <summary>
        /// 根据换货编号获取换货详情
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="exID">换货编号</param>
        /// <returns></returns>
        DataSet GetExChangeInfoByExID( int userID, int exID );
        #endregion

        #region 根据换货编号单条申请的记录
        /// <summary>
        /// 根据换货编号单条申请的记录
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="exID">换货编号</param>
        /// <returns></returns>
        DataSet GetExChangeOneByExID( int userID, int exID );
        #endregion
        #region 修改用户基本信息
        /// <summary>
        /// 修改用户基本信息
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="modType">要修改的字段类型</param>
        /// <param name="content">要修改的内容</param>
        /// <returns></returns>
        int UpdateMemberCenterForUserBaseByType( int userID, int modType, string content );
        #endregion
        #region 验证支付密码,返回冻结剩余时间（s）11774
        /// <summary>
        /// 验证支付密码,返回冻结剩余时间（s）11774
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="userPayPwd">支付密码</param>
        /// <returns></returns>
        int CheckPayPwdByUserID( int userID, string userPayPwd, out int surplusTime );
        #endregion

        #region 运营应用相关
        #region 修改用户基本信息
        /// <summary>
        /// app相关操作记录
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
        int appUsingTheApp( string IMEI, string appMarketCode, int operateType, int loginUserID, int registerUserID, string device, string sysVer, string appVer );
        #endregion
        #endregion
        #region 校验用户转账次数,返回1表示未超过5次,-1表示已大于等于5次12345
        /// <summary>
        /// 校验用户转账次数,返回1表示未超过5次,-1表示已大于等于5次12345
        /// </summary>
        /// <param name="outUserID"></param>
        /// <returns></returns>
        int ChkTransferTimes( int outUserID );
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
        int ChkAppUserComment( string imei, int userID, int buyDayNum, int getGoodsNum, string appMarketCode, string appVer, int sDayNum, int nDayNum, double percent );

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
        int AddAppComments( string imei, int userID, string appMarketCode, string appVer, int commentType );

        #endregion
        #endregion
        #region 根据卡号获取对应的银行名称12328
        /// <summary>
        /// 根据卡号获取对应的银行名称12328
        /// </summary>
        /// <param name="cardNO">卡号</param>
        /// <param name="cardLength">卡长度</param>
        /// <returns></returns>
        DataSet GetBankNameByCardNO( string cardNO, int cardLength );

        #endregion

        #region 退补用户运费或差价操作
        /// <summary>
        /// 退补会员运费或差价操作
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="orderNO">订单号</param>
        /// <param name="logType">操作类型</param>
        /// <param name="money">金额</param>
        /// <param name="loginName">登录账号</param>
        /// <returns></returns>
        int FillUserBalance( int userID, int orderNO, int logType, int money, string loginName );
        #endregion

        #region 获取用户消费金额及注册时间11775
        /// <summary>
        /// 获取用户消费金额及注册时间11775
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        DataSet GetWasteRegTimeByUserID( int userID );

        #endregion
    }
}
