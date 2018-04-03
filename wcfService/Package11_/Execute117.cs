using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class ExecuteFun
    {
        #region 会员中心首页信息11701
        /// <summary>
        /// 会员中心首页信息11701
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterHome( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _DS = _DAL.GetMemberCenterHome( _UserID );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 会员中心获取好友申请列表11702
        /// <summary>
        /// 会员中心获取好友申请列表11702
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总数</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterForFriendsApplyPageList( out int totalCount, params object[] para )
        {
            DataSet _DS = null;
            totalCount = 0;
            int _UserID = (int)para[0];
            int _FIdx = (int)para[1];
            int _EIdx = (int)para[2];
            int _IsCount = (int)para[3];
            if ( _UserID > 0 && _FIdx > 0 && _EIdx >= _FIdx )
            {
                IDALUserFriends _DAL = new DALUserFriends();
                _DS = _DAL.GetMemberCenterForFriendsApplyPageList( _UserID, _FIdx, _EIdx, _IsCount, out totalCount );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 获取某会员所有的好友分页列表11704
        /// <summary>
        /// 会员中心 - 获取某会员所有的好友分页列表11704
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="keywords">关键词</param>
        /// <param name="totalCount">返回总数</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterForFriendsPageList( out int totalCount, params object[] para )
        {
            DataSet _DS = null;
            totalCount = 0;
            int _UserID = (int)para[0];
            int _FIdx = (int)para[1];
            int _EIdx = (int)para[2];
            int _IsCount = (int)para[3];
            string _Keywords = (string)para[4];
            if ( _UserID > 0 && _FIdx > 0 && _EIdx >= _FIdx )
            {
                IDALUserFriends _DAL = new DALUserFriends();
                _DS = _DAL.GetMemberCenterForFriendsPageList( _UserID, _FIdx, _EIdx, _IsCount, _Keywords, out totalCount );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 获取会员所有信息统计:FriendCount,sysMsgCount,privMsgCount,replyMsgCount11705
        /// <summary>
        /// 获取会员所有信息统计11705 FriendCount,sysMsgCount,privMsgCount,replyMsgCount
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public static DataSet GetUserMsgCount( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                try
                {
                    IDALUserMsg _DAL = new DALUserMsg();
                    _DS = _DAL.GetUserMsgCount( _UserID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserMsg.GetUserMsgCount Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
        #region 获取会员感兴趣的人11706
        /// <summary>
        /// 获取会员感兴趣的人11706
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="quanlity">数量</param>
        /// <returns></returns>
        public static DataSet GetInterestedPeople( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            int _Quanlity = (int)para[1];
            if ( _UserID > 0 && _Quanlity > 0 )
            {
                IDALUserFriends _DAL = new DALUserFriends();
                _DS = _DAL.GetInterestedPeople( _UserID, _Quanlity );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 搜索全站未添加好友的会员信息11708
        /// <summary>
        /// 会员中心 - 搜索全站未添加好友的会员信息11708
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="keywords">关键词</param>
        /// <param name="totalCount">返回总数</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterForSearchFriends( out int totalCount, params object[] para )
        {
            DataSet _DS = null;
            totalCount = 0;
            int _UserID = (int)para[0];
            int _FIdx = (int)para[1];
            int _EIdx = (int)para[2];
            int _IsCount = (int)para[3];
            string _Keywords = (string)para[4];
            if ( _UserID > 0 && _FIdx > 0 && _EIdx >= _FIdx )
            {
                IDALUserFriends _DAL = new DALUserFriends();
                _DS = _DAL.GetMemberCenterForSearchFriends( _UserID, _FIdx, _EIdx, _IsCount, _Keywords, out totalCount );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 获取推荐的好友11709
        /// <summary>
        /// 会员中心 - 获取推荐的好友11709
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="quanlity">获取数量</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterForSearchFriendsDefault( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            int _Quanlity = (int)para[1];
            if ( _UserID > 0 && _Quanlity > 0 )
            {
                IDALUserFriends _DAL = new DALUserFriends();
                _DS = _DAL.GetMemberCenterForSearchFriendsDefault( _UserID, _Quanlity );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 查找好友 - 最活跃的用户11710
        /// <summary>
        /// 会员中心 - 查找好友 - 最活跃的用户11710
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总数</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterForSearchFriendsHot( out int totalCount, params object[] para )
        {
            DataSet _DS = null;
            totalCount = 0;
            int _UserID = (int)para[0];
            int _FIdx = (int)para[1];
            int _EIdx = (int)para[2];
            int _IsCount = (int)para[3];
            if ( _UserID > 0 && _FIdx > 0 && _EIdx >= _FIdx )
            {
                IDALUserFriends _DAL = new DALUserFriends();
                _DS = _DAL.GetMemberCenterForSearchFriendsHot( _UserID, _FIdx, _EIdx, _IsCount, out totalCount );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 查找好友 - 最新加入的用户11711
        /// <summary>
        /// 会员中心 - 查找好友 - 最新加入的用户11711
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总数</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterForSearchFriendsLastRegister( out int totalCount, params object[] para )
        {
            DataSet _DS = null;
            totalCount = 0;
            int _UserID = (int)para[0];
            int _FIdx = (int)para[1];
            int _EIdx = (int)para[2];
            int _IsCount = (int)para[3];
            if ( _UserID > 0 && _FIdx > 0 && _EIdx >= _FIdx )
            {
                IDALUserFriends _DAL = new DALUserFriends();
                _DS = _DAL.GetMemberCenterForSearchFriendsLastRegister( _UserID, _FIdx, _EIdx, _IsCount, out totalCount );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 查找好友 - 获得商品最多的11712
        /// <summary>
        /// 会员中心 - 查找好友 - 获得商品最多的11712
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总数</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterForSearchFriendsRaffle( out int totalCount, params object[] para )
        {
            DataSet _DS = null;
            totalCount = 0;
            int _UserID = (int)para[0];
            int _FIdx = (int)para[1];
            int _EIdx = (int)para[2];
            int _IsCount = (int)para[3];
            if ( _UserID > 0 && _FIdx > 0 && _EIdx >= _FIdx )
            {
                IDALUserFriends _DAL = new DALUserFriends();
                _DS = _DAL.GetMemberCenterForSearchFriendsRaffle( _UserID, _FIdx, _EIdx, _IsCount, out totalCount );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 会员中心 - 获取某会员发表的话题列表11713
        /// <summary>
        /// 会员中心 - 获取某会员发表的话题列表11713
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <param name="totalReplyCount"></param>
        /// <returns></returns>
        public static DataSet GetMemberCenterForTopicPageList( out int totalCount, out int totalReplyCount, params object[] para )
        {
            DataSet _DS = null;
            totalCount = 0;
            totalReplyCount = 0;
            int _UserID = (int)para[0];
            int _FIdx = (int)para[1];
            int _EIdx = (int)para[2];
            int _IsCount = (int)para[3];
            if ( _UserID > 0 && _FIdx > 0 && _EIdx >= _FIdx )
            {
                IDALGroup _DAL = new DALGroup();
                _DS = _DAL.GetMemberCenterForTopicPageList( _UserID, _FIdx, _EIdx, _IsCount, out totalCount, out totalReplyCount );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 会员中心 - 获取某会员回复圈子话题列表11714
        /// <summary>
        /// 会员中心 - 获取某会员回复圈子话题列表11714
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public static DataSet GetMemberCenterForTopicReplyPageList( out int totalCount, params object[] para )
        {
            DataSet _DS = null;
            totalCount = 0;
            int _UserID = (int)para[0];
            int _FIdx = (int)para[1];
            int _EIdx = (int)para[2];
            int _IsCount = (int)para[3];
            if ( _UserID > 0 && _FIdx > 0 && _EIdx > _FIdx )
            {
                IDALGroup _DAL = new DALGroup();
                _DS = _DAL.GetMemberCenterForTopicReplyPageList( _UserID, _FIdx, _EIdx, _IsCount, out totalCount );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 会员中心-修改个人基本资料11715
        /// <summary>
        /// 会员中心-修改个人基本资料11715
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="userMobile">用户手机号</param>
        /// <param name="userEmail">用户邮箱</param>
        /// <returns></returns>
        public static int UpdateMemberCenterForUserBase( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            string _UserMobile = (string)para[1];
            string _UserEmail = (string)para[2];
            if ( _UserID > 0 && ( !UtilityFun.IsEmptyString( _UserMobile ) || !UtilityFun.IsEmptyString( _UserEmail ) ) )
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.UpdateMemberCenterForUserBase( _UserID, _UserMobile, _UserEmail );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 会员中心-查询会员云购的商品详情11716
        /// <summary>
        /// 会员中心-查询会员云购的商品详情11716
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="codeID">条码ID</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterUserBuyDetail( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            int _CodeID = (int)para[1];
            if ( _UserID > 0 && _CodeID > 0 )
            {
                IDALUserBuy _DAL = new DALUserBuy();
                _DS = _DAL.GetMemberCenterUserBuyDetail( _UserID, _CodeID );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 会员中心-我的云购记录分页列表11717
        /// <summary>
        /// 会员中心-我的云购记录分页列表11717
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="state">状态</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userid">会员ID</param>
        /// <param name="keyWords">关键字</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">返回总记录数</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterBuyList( out int count, params object[] para )
        {
            DataSet _DS = null;
            count = 0;
            int _FIdx = (int)para[0];
            int _EIdx = (int)para[1];
            int _State = (int)para[2];
            DateTime _BeginTime = (DateTime)para[3];
            DateTime _EndTime = (DateTime)para[4];
            int _UserID = (int)para[5];
            string _KeyWords = (string)para[6];
            int _IsCount = (int)para[7];
            if ( _UserID > 0 )
            {
                IDALUserBuy _DAL = new DALUserBuy();
                _DS = _DAL.GetMemberCenterBuyList( _FIdx, _EIdx, _State, _BeginTime, _EndTime, _UserID, _KeyWords, _IsCount, out count );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 获取会员退购记录11718
        /// <summary>
        /// 获取会员退购记录11718
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userid">会员ID</param>
        /// <param name="keyWords">关键字</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">返回总记录数</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterBuyRefund( out int count, params object[] para )
        {
            DataSet _DS = null;
            count = 0;
            int _FIdx = (int)para[0];
            int _EIdx = (int)para[1];
            DateTime _BeginTime = (DateTime)para[2];
            DateTime _EndTime = (DateTime)para[3];
            int _UserID = (int)para[4];
            string _KeyWords = (string)para[5];
            int _IsCount = (int)para[6];
            if ( _UserID > 0 && _FIdx > 0 && _EIdx >= _FIdx )
            {
                IDALUserBuy _DAL = new DALUserBuy();
                _DS = _DAL.GetMemberCenterBuyRefund( _FIdx, _EIdx, _BeginTime, _EndTime, _UserID, _KeyWords, _IsCount, out count );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 会员中心-查询会员云购的商品所有云购码11719
        /// <summary>
        /// 会员中心-查询会员云购的商品所有云购码11719
        /// </summary>
        /// <param name="userid">会员ID</param>
        /// <param name="codeid">条码ID</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterUserBuyRno( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            int _CodeID = (int)para[1];
            if ( _UserID > 0 && _CodeID > 0 )
            {
                IDALUserBuy _DAL = new DALUserBuy();
                _DS = _DAL.GetMemberCenterUserBuyRno( _UserID, _CodeID );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 会员中心 - 用户云购记录各状态(1-3)统计11720
        /// <summary>
        /// 会员中心 - 用户云购记录各状态(1-3)统计11720
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static DataSet GetMemberCenterUserBuyStateTotal( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUserBuy _DAL = new DALUserBuy();
                _DS = _DAL.GetMemberCenterUserBuyStateTotal( _UserID );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 网页版会员中心-消费记录11721
        /// <summary>
        /// 网页版会员中心-消费记录11721
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userid">会员ID</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">总记录数</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterUserConsumptionEx( out int count, params object[] para )
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
                IDALUsers _DAL = new DALUsers();
                _DS = _DAL.GetMemberCenterUserConsumptionEx( _FIdx, _EIdx, _BeginTime, _EndTime, _UserID, _IsCount, out count );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 会员中心-消费详情11722
        /// <summary>
        /// 会员中心-消费详情11722
        /// </summary>
        /// <param name="userID">用户id</param>
        /// <param name="shopID">购物车id</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterUserConsumptionDetail( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            long _ShopID = (long)para[1];
            if ( _UserID > 0 && _ShopID > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _DS = _DAL.GetMemberCenterUserConsumptionDetail( _UserID, _ShopID );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 会员消费总金额11723
        /// <summary>
        /// 会员消费总金额11723
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public static int GetUserConsumptionSum( params object[] para )
        {
            int _Money = 0;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _Money = _DAL.GetUserConsumptionSum( _UserID );
                _DAL = null;
            }
            return _Money;
        }
        #endregion
        #region 会员中心-修改个人详细资料11724
        /// <summary> 会员中心-修改个人详细资料11724 </summary> <param name="userID"></param> <param
        /// name="userName"></param> <param name="userQQ"></param> <param name="userPhone"></param>
        /// <param name="userSex"></param> <param name="userBirthday"></param> <param
        /// name="userBirthStar"></param> <param name="userBirthArea"></param> <param
        /// name="userBirthAreaName"></param> <param name="userLiveArea"></param> <param
        /// name="userLiveAreaName"></param> <param name="userMonthIncome"></param> <param
        /// name="userSignature"></param> <param name="userBirthUpdateTime"></param> <param
        /// name="userVerifyName"></param> <param name="userVerifySex">param> <param
        /// name="userVerifyBirthDay"></param> <param name="userVerifyBirthArea"></param> <param
        /// name="userVerifyLiveArea"></param> <param name="userVerifyQQ"></param> <param
        /// name="userVerifyWage"></param> <param name="userVerifySignature"></param> <returns></returns>
        public static int UpdateMemberCenterForUserDetail( params object[] para )
        {
            int _Result = 0;
            int userID = (int)para[0];
            string userName = (string)para[1];
            string userQQ = (string)para[2];
            string userPhone = (string)para[3];
            int userSex = (int)para[4];
            DateTime userBirthday = (DateTime)para[5];
            int userBirthStar = (int)para[6];
            int userBirthArea = (int)para[7];
            string userBirthAreaName = (string)para[8];
            int userLiveArea = (int)para[9];
            string userLiveAreaName = (string)para[10];
            string userMonthIncome = (string)para[11];
            string userSignature = (string)para[12];
            DateTime userBirthUpdateTime = (DateTime)para[13];
            int userVerifyName = (int)para[14];
            int userVerifySex = (int)para[15];
            int userVerifyBirthDay = (int)para[16];
            int userVerifyBirthArea = (int)para[17];
            int userVerifyLiveArea = (int)para[18];
            int userVerifyQQ = (int)para[19];
            int userVerifyWage = (int)para[20];
            int userVerifySignature = (int)para[21];
            IDALUsers _DAL = new DALUsers();
            _Result = _DAL.UpdateMemberCenterForUserDetail( userID, userName, userQQ, userPhone, userSex, userBirthday, userBirthStar, userBirthArea, userBirthAreaName,
                userLiveArea, userLiveAreaName, userMonthIncome, userSignature, userBirthUpdateTime, userVerifyName, userVerifySex, userVerifyBirthDay, userVerifyBirthArea,
                userVerifyLiveArea, userVerifyQQ, userVerifyWage, userVerifySignature );
            _DAL = null;
            return _Result;
        }
        #endregion
        #region 会员中心 - 首页好友最新动态信息11725
        /// <summary>
        /// 会员中心 - 首页好友最新动态信息11725
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterForUserFriendMsg( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUserFriends _DAL = new DALUserFriends();
                _DS = _DAL.GetMemberCenterForUserFriendMsg( _UserID );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 会员中心 - 获取某会员加入的圈子信息11726
        /// <summary>
        /// 会员中心 - 获取某会员加入的圈子信息11726
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public static DataSet GetMemberCenterForUserGroupList( out int totalCount, params object[] para )
        {
            DataSet _DS = null;
            totalCount = 0;
            int _UserID = (int)para[0];
            int _FIdx = (int)para[1];
            int _EIdx = (int)para[2];
            int _IsCount = (int)para[3];
            if ( _UserID > 0 && _FIdx > 0 && _EIdx >= _FIdx )
            {
                IDALGroup _DAL = new DALGroup();
                _DS = _DAL.GetMemberCenterForUserGroupList( _UserID, _FIdx, _EIdx, _IsCount, out totalCount );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 会员中心-个人资料详情11727
        /// <summary>
        /// 会员中心-个人资料详情11727
        /// </summary>
        /// <param name="userID">用户id</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterUserInfo( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _DS = _DAL.GetMemberCenterUserInfo( _UserID );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 获取会员信息11728
        /// <summary>
        /// 获取会员信息11728
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public static DataSet GetUserInfoByID( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _DS = _DAL.GetUserInfoByID( _UserID );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 会员中心 - 查询会员系统信息分页记录11729
        /// <summary>
        /// 会员中心 - 查询会员系统信息分页记录11729
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">系统消息总记录数</param>
        /// <param name="privMsgCount">私信总记录数</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterForUserMessageList( out int totalCount, out int privMsgCount, params object[] para )
        {
            DataSet _DS = null;
            totalCount = 0;
            privMsgCount = 0;
            int _UserID = (int)para[0];
            int _FIdx = (int)para[1];
            int _EIdx = (int)para[2];
            bool _IsCount = (int)para[3] == 1;
            if ( _UserID > 0 && _FIdx > 0 && _EIdx > _FIdx )
            {
                IDALUserMsg _DAL = new DALUserMsg();
                _DS = _DAL.GetMemberCenterForUserMessageList( _UserID, _FIdx, _EIdx, _IsCount, out totalCount, out privMsgCount );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 会员中心-充值记录11730
        /// <summary>
        /// 会员中心-充值记录11730
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userID">会员ID</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">总记录数</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterUserRecharge( out int count, params object[] para )
        {
            DataSet _DS = null;
            count = 0;
            int _FIdx = (int)para[0];
            int _EIdx = (int)para[1];
            DateTime _BeginTime = (DateTime)para[2];
            DateTime _EndTime = (DateTime)para[3];
            int _UserID = (int)para[4];
            int _IsCount = (int)para[5];
            if ( _UserID > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _DS = _DAL.GetMemberCenterUserRecharge( _FIdx, _EIdx, _BeginTime, _EndTime, _UserID, _IsCount, out count );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 会员充值总金额11731
        /// <summary>
        /// 会员充值总金额11731
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public static int GetUserPaySum( params object[] para )
        {
            int _Sum = 0;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _Sum = _DAL.GetUserPaySum( _UserID );
                _DAL = null;
            }
            return _Sum;
        }
        #endregion
        #region 获取会员头像11732
        /// <summary>
        /// 获取会员头像11732
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public static string GetMemberCenterForUserPhoto( params object[] para )
        {
            string _Photo = "";
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _Photo = _DAL.GetMemberCenterForUserPhoto( _UserID );
                _DAL = null;
            }
            return _Photo;
        }
        #endregion
        #region 成功邀请会员列表11733
        /// <summary>
        /// 成功邀请会员列表11733
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="FIdx">起始编号</param>
        /// <param name="EIdx">截至编号</param>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">截至时间</param>
        /// <param name="isCount">是否返回总数据行 0:否，1:返回</param>
        /// <param name="totalCount">总行数</param>
        /// <returns></returns>
        public static DataSet GetInvitedMemberInfoList( out int totalCount, params object[] para )
        {
            DataSet _DS = null;
            totalCount = 0;
            int _UserID = (int)para[0];
            int _FIdx = (int)para[1];
            int EIdx = (int)para[2];
            DateTime _StartTime = (DateTime)para[3];
            DateTime _EndTime = (DateTime)para[4];
            int isCount = (int)para[5];
            if ( _UserID > 0 && _FIdx > 0 && EIdx > _FIdx )
            {
                IDALUserPoints _DAL = new DALUserPoints();
                _DS = _DAL.GetInvitedMemberInfoList( _UserID, _FIdx, EIdx, _StartTime, _EndTime, isCount, out totalCount );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 会员中心-我的已晒单分页列表11734
        /// <summary>
        /// 会员中心-我的已晒单分页列表11734
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="userid">会员ID</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="postCount">已晒单总记录数</param>
        /// <param name="unPostCount">未晒单总记录数</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterForUserPostSingle( out int postCount, out int unPostCount, params object[] para )
        {
            DataSet _DS = null;
            postCount = 0;
            unPostCount = 0;
            int _FIdx = (int)para[0];
            int _EIdx = (int)para[1];
            int _UserID = (int)para[2];
            DateTime _BeginTime = (DateTime)para[3];
            DateTime _EndTime = (DateTime)para[4];
            int _IsCount = (int)para[5];
            if ( _UserID > 0 )
            {
                IDALPostSingle _DAL = new DALPostSingle();
                _DS = _DAL.GetMemberCenterForUserPostSingle( _FIdx, _EIdx, _UserID, _BeginTime, _EndTime, _IsCount, out postCount, out unPostCount );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 获取晒单详情11735
        /// <summary>
        /// 获取晒单详情11735
        /// </summary>
        /// <param name="postID">晒单ID号</param>
        /// <param name="userID">发布的会员ID号</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterUserPostSingleDetail( params object[] para )
        {
            DataSet _DS = null;
            int _PostID = (int)para[0];
            int _UserID = (int)para[1];
            if ( _PostID > 0 && _UserID > 0 )
            {
                IDALPostSingle _DAL = new DALPostSingle();
                _DS = _DAL.GetMemberCenterUserPostSingleDetail( _PostID, _UserID );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 会员中心 - 获取会员单条私信会话分页记录11736
        /// <summary>
        /// 获取会员单条私信会话分页记录11736
        /// </summary>
        /// <param name="userID">接收会员ID</param>
        /// <param name="senderUserID">发送会员ID</param>
        /// <param name="FIdx">记录开始序号</param>
        /// <param name="EIdx">记录结束序号</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public static DataSet GetUserPrivMsgDetailList( out int totalCount, params object[] para )
        {
            DataSet _DS = null;
            totalCount = 0;
            int _UserID = (int)para[0];
            int _SendUserID = (int)para[1];
            int _FIdx = (int)para[2];
            int _EIdx = (int)para[3];
            bool _IsCount = (int)para[4] == 1;
            if ( _UserID > 0 && _SendUserID > 0 && _FIdx > 0 && _EIdx >= _FIdx )
            {
                IDALUserMsg _DAL = new DALUserMsg();
                _DS = _DAL.GetUserPrivMsgDetailList( _UserID, _SendUserID, _FIdx, _EIdx, _IsCount, out totalCount );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 会员中心 - 获取会员所有私信分页记录11737
        /// <summary>
        /// 获取会员所有私信分页记录11737
        /// </summary>
        /// <param name="userID">接收会员ID</param>
        /// <param name="FIdx">记录开始序号</param>
        /// <param name="EIdx">记录结束序号</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public static DataSet GetUserPrivMsgList( out int totalCount, params object[] para )
        {
            DataSet _DS = null;
            totalCount = 0;
            int _UserID = (int)para[0];
            int _FIdx = (int)para[1];
            int _EIdx = (int)para[2];
            bool _IsCount = (int)para[3] == 1;
            if ( _UserID > 0 && _FIdx > 0 && _EIdx >= _FIdx )
            {
                IDALUserMsg _DAL = new DALUserMsg();
                _DS = _DAL.GetUserPrivMsgList( _UserID, _FIdx, _EIdx, _IsCount, out totalCount );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 会员中心-正常中奖的商品列表11738
        /// <summary>
        /// 会员中心-正常中奖的商品列表11738
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userID">会员ID</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">总记录数</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterUserRaffleList( out int count, params object[] para )
        {
            int _ChangeCount = 0;
            if ( para.Length > 6 )
            {
                para[5] = 0;
            }
            else
            {
                para = new object[] { para[0], para[1], para[2], para[3], para[4], 0, para[5] };
            }
            return GetMemberCenterUserRaffleListEx( out  count, out _ChangeCount, para );
        }

        #endregion
        #region 会员中心-中奖的商品列表1173801
        /// <summary>
        /// 会员中心-中奖的商品列表1173801
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userID">会员ID</param>
        /// <param name="orderType">订单类型: 1.换货订单，0.正常订单</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="normalCount">正常订单总数</param>
        /// <param name="changeCount">换货订单总数</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterUserRaffleListEx( out int normalCount, out int changeCount, params object[] para )
        {
            DataSet _DS = null;
            int _FIdx = (int)para[0];
            int _EIdx = (int)para[1];
            DateTime _BeginTime = (DateTime)para[2];
            DateTime _EndTime = (DateTime)para[3];
            int _UserID = (int)para[4];
            int _OrderType = (int)para[5];
            int _IsCount = (int)para[6];
            normalCount = 0;
            changeCount = 0;
            if ( _UserID > 0 )
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetMemberCenterUserRaffleList( _FIdx, _EIdx, _BeginTime, _EndTime, _UserID, _OrderType, _IsCount, out  normalCount, out changeCount );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 统计会员获得的商品最新个数11739
        /// <summary>
        /// 统计会员获得的商品最新个数11739
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public static int GetMemberCenterForUserRaffleNewCount( params object[] para )
        {
            int userID = (int)para[0];
            int orderNO = (int)para[1];
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
        #region 检测两个用户之间是否为好友关系11740
        /// <summary>
        /// 检测两个用户之间是否为好友关系11740
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="friendID">另一个会员ID</param>
        /// <returns>（-1:非好友，0:已发送请求，1:已是好友）</returns>
        public static int CheckUserFriendLink( params object[] para )
        {
            int _Result = -1;
            int _UserID = (int)para[0];
            int _FriendID = (int)para[1];
            if ( _UserID > 0 && _FriendID > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.CheckUserFriendLink( _UserID, _FriendID );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 会员中心 - 会员未晒单列表11741
        /// <summary>
        /// 会员中心 - 会员未晒单列表11741
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="userID">会员ID</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">未晒单总记录数</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterForUserUnPostSingle( out int count, params object[] para )
        {
            DataSet _DS = null;
            count = 0;
            int _FIdx = (int)para[0];
            int _EIdx = (int)para[1];
            int _UserID = (int)para[2];
            DateTime _BeginTime = (DateTime)para[3];
            DateTime _EndTime = (DateTime)para[4];
            int _IsCount = (int)para[5];
            if ( _UserID > 0 )
            {
                IDALPostSingle _DAL = new DALPostSingle();
                _DS = _DAL.GetMemberCenterForUserUnPostSingle( _FIdx, _EIdx, _UserID, _BeginTime, _EndTime, _IsCount, out count );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 会员中心-消费记录11742
        /// <summary>
        /// 会员中心-消费记录11742
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userID">会员ID</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">总记录数</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterUserConsumption( out int count, params object[] para )
        {
            int userID = (int)para[0];
            int FIdx = (int)para[1];
            int EIdx = (int)para[2];
            DateTime beginTime = (DateTime)para[3];
            DateTime endTime = (DateTime)para[4];
            int isCount = (int)para[5];
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
        #endregion
        #region 会员中心-获取会员活动订单11743
        /// <summary>
        /// 会员中心-获取会员活动订单11743
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="beginTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="FIdx">起始索引</param>
        /// <param name="EIdx">结束索引</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总数</param>
        /// <returns></returns>
        public static DataSet GetActOrderByUserID( out int totalCount, params object[] para )
        {
            DataSet _DS = null;
            int userID = (int)para[0];
            DateTime beginTime = (DateTime)para[1];
            DateTime endTime = (DateTime)para[2];
            int FIdx = (int)para[3];
            int EIdx = (int)para[4];
            int isCount = (int)para[5];
            IDALOrders _DAL = new DALOrders();
            _DS = _DAL.GetActOrderByUserid( userID, beginTime, endTime, FIdx, EIdx, isCount, out totalCount );
            _DAL = null;
            return _DS;
        }
        #endregion
        #region 查询用户充值、消费、转入、转出的总额11744
        /// <summary>
        /// 查询用户充值、消费、转入、转出的总额11744
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public static DataSet GetUserMoneyByUserID( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _DS = _DAL.GetUserMoneyByUserID( _UserID );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 开启支付密码11745
        /// <summary>
        /// 开启支付密码11745
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="userPayPwd">用户支付密码</param>
        /// <returns></returns>
        public static int SetUserPayPwdByUserID( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            string _UserPayPwd = (string)para[1];
            IDALUsers _DAL = new DALUsers();
            _Result = _DAL.SetUserPayPwdByUserID( _UserID, _UserPayPwd );
            _DAL = null;
            return _Result;
        }
        #endregion
        #region 修改支付密码11746
        /// <summary>
        /// 修改支付密码11746
        /// </summary>
        /// <param name="userID">用户 ID</param>
        /// <param name="userPayPwd">用户支付密码</param>
        /// <returns></returns>
        public static int UpdateUserPayPwdByUserID( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            string _UserPayPwd = (string)para[1];
            IDALUsers _DAL = new DALUsers();
            _Result = _DAL.UpdateUserPayPwdByUserID( _UserID, _UserPayPwd );
            _DAL = null;
            return _Result;
        }
        #endregion
        #region 关闭用户支付密码11747
        /// <summary>
        /// 关闭用户支付密码11747
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static int CloseUserPayPwdByUserID( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            IDALUsers _DAL = new DALUsers();
            _Result = _DAL.CloseUserPayPwdByUserID( _UserID );
            _DAL = null;
            return _Result;
        }
        #endregion
        #region 修改小额免密码金额11748
        /// <summary>
        /// 修改小额免密码金额11748
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="smallPayMoney">免密码金额</param>
        /// <returns></returns>
        public static int UpdateSmallPayMoneyByUserID( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            int _SmallPayMoney = (int)para[1];
            IDALUsers _DAL = new DALUsers();
            _Result = _DAL.UpdateSmallPayMoneyByUserID( _UserID, _SmallPayMoney );
            _DAL = null;
            return _Result;
        }
        #endregion
        #region 验证支付密码11749
        /// <summary>
        /// 验证支付密码11749
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="userPayPwd">支付密码</param>
        /// <returns></returns>
        public static int CheckPayPwdByUserID( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            string _UserPayPwd = (string)para[1];
            IDALUsers _DAL = new DALUsers();
            _Result = _DAL.CheckPayPwdByUserID( _UserID, _UserPayPwd );
            _DAL = null;
            return _Result;
        }
        #endregion
        #region 设置登录保护11750
        /// <summary>
        /// 设置登录保护11750
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="isWxKeeyLogin">1微信提示，0不提示</param>
        /// <returns>1成功，－1用户不存在</returns>
        public static int SetWxKeepLoginByUserID( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            int _IsWxKeeyLogin = (int)para[1];
            IDALUsers _DAL = new DALUsers();
            _Result = _DAL.SetWxKeepLoginByUserID( _UserID, _IsWxKeeyLogin );
            _DAL = null;
            return _Result;
        }
        #endregion
        #region 设置购买失败的微信邮箱消息推送开关11751
        /// <summary>
        /// 设置购买失败的微信邮箱消息推送开关11751
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="isWxMailSend">是否推送邮件</param>
        /// <returns></returns>
        public static int SetWxMailNoticeByUserID( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            int _IsWxMailSend = (int)para[1];
            IDALUsers _DAL = new DALUsers();
            _Result = _DAL.SetWxMailNoticeByUserID( _UserID, _IsWxMailSend );
            _DAL = null;
            return _Result;
        }
        #endregion
        #region 设置购买失败的云购帐户系统消息推送11752
        /// <summary>
        /// 设置购买失败的云购帐户系统消息推送11752
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="isSysMsgSend">是否推送系统消息</param>
        /// <returns></returns>
        public static int SetSysMsgNoticeByUserID( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            int _IsSysMsgSend = (int)para[1];
            IDALUsers _DAL = new DALUsers();
            _Result = _DAL.SetSysMsgNoticeByUserID( _UserID, _IsSysMsgSend );
            _DAL = null;
            return _Result;
        }
        #endregion
        #region 用户添加收藏商品11753
        /// <summary>
        /// 用户添加收藏商品11753
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        public static int InsertCollectGoodsByUserID( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            int _GoodsID = (int)para[1];
            IDALGoods _DAL = new DALGoods();
            _Result = _DAL.InsertCollectGoodsByUserID( _UserID, _GoodsID );
            _DAL = null;
            return _Result;
        }
        #endregion
        #region 删除用户收藏的商品11754
        /// <summary>
        /// 删除用户收藏的商品11754
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        public static int DeleteCollectGoodsByUserID( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            int _GoodsID = (int)para[1];
            IDALGoods _DAL = new DALGoods();
            _Result = _DAL.DeleteCollectGoodsByUserID( _UserID, _GoodsID );
            _DAL = null;
            return _Result;
        }
        #endregion
        #region 删除用户的所有失效商品11755
        /// <summary>
        /// 删除用户的所有失效商品11755
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static int DeleteAllFailCollectGoodsByUserID( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            IDALGoods _DAL = new DALGoods();
            _Result = _DAL.DeleteAllFailCollectGoodsByUserID( _UserID );
            _DAL = null;
            return _Result;
        }
        #endregion
        #region 分页获取用户收藏的商品11756
        /// <summary>
        /// 分页获取用户收藏的商品11756
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总记录数</param>
        /// <returns></returns>
        public static DataSet GetCollectGoodsByUserID( out int totalCount, params object[] para )
        {
            DataSet _DS = null;
            totalCount = 0;
            int _UserID = (int)para[0];
            int _FIdx = (int)para[1];
            int _EIdx = (int)para[2];
            int _IsCount = (int)para[3];
            IDALGoods _DAL = new DALGoods();
            _DS = _DAL.GetCollectGoodsByUserID( _UserID, _FIdx, _EIdx, _IsCount, out totalCount );
            _DAL = null;
            return _DS;
        }
        #endregion
        #region 检测用户是否有收藏某商品11757
        /// <summary>
        /// 检测用户是否有收藏某商品11757
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        public static int CheckUserCollectGoods( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            int _GoodsID = (int)para[1];
            IDALGoods _DAL = new DALGoods();
            _Result = _DAL.CheckUserCollectGoods( _UserID, _GoodsID );
            _DAL = null;
            return _Result;
        }
        #endregion
        #region 会员中心-获得的商品及活动商品列表11758
        /// <summary>
        /// 会员中心-获得的商品及活动商品列表11758
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="orderType">订单类型 2.活动订单 1.换货订单，0.正常订单</param>
        /// <param name="orderState">订单状态 0.全部 1.待确认地址 2.待发货 3.待收货 10.待晒单</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="isStat">是否返回不同订单状态总数</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="recordCount">查询记录总数</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterUserOrderList( out int recordCount, params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            int _OrderType = (int)para[1];
            int _OrderState = (int)para[2];
            DateTime _BeginTime = (DateTime)para[3];
            DateTime _EndTime = (DateTime)para[4];
            int _FIdx = (int)para[5];
            int _EIdx = (int)para[6];
            int _IsStat = (int)para[7];
            int _IsCount = (int)para[8];
            recordCount = 0;
            if ( _UserID > 0 )
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetMemberCenterUserOrderList( _UserID, _OrderType, _OrderState, _BeginTime, _EndTime, _FIdx, _EIdx, _IsStat, _IsCount, out recordCount );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 会员中心-根据订单号查其换货后的订单信息11759
        /// <summary>
        /// 根据订单号查其换货后的订单信息11759
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public static DataSet GetChangeOrderListByUserID( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            int _OrderNO = (int)para[1];
            if ( _UserID > 0 && _OrderNO > 0 )
            {
                IDALOrders _DAL = new DALOrders();
                _DS = _DAL.GetChangeOrderListByUserID( _UserID, _OrderNO );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 会员中心-获取晒单列表（整合未晒与已晒）11760
        /// <summary>
        /// 会员中心-获取晒单列表（整合未晒与已晒）11760
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="state">晒单状态 0.全部 1.已经晒单 2.未晒单 3.待审核 4.未通过 5.已通过</param>
        /// <param name="isStat">是否需要统计 1.需要统计 0.表示不需要</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总记录数</param>
        /// <param name="totalCount">返回总记录数</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterPostListByUserID( out int count, params object[] para )
        {
            DataSet _DS = null;
            count = 0;
            int _UserID = (int)para[0];
            int _State = (int)para[1];
            int _IsStat = (int)para[2];
            DateTime _BeginTime = (DateTime)para[3];
            DateTime _EndTime = (DateTime)para[4];
            int _FIdx = (int)para[5];
            int _EIdx = (int)para[6];
            int _IsCount = (int)para[7];
            count = 0;
            if ( _UserID > 0 && _FIdx > 0 && _EIdx >= _FIdx )
            {
                IDALPostSingle _DAL = new DALPostSingle();
                _DS = _DAL.GetMemberCenterPostListByUserID( _UserID, _State, _IsStat, _BeginTime, _EndTime, _FIdx, _EIdx, _IsCount, out count );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 根据订单号查询换货订单详细信息11761
        /// <summary>
        /// 根据订单号查询换货订单详细信息11761
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public static DataSet GetOrderInfoByOrderNO( params object[] para )
        {
            int orderNO = (int)para[0];
            DataSet _DS = null;
            try
            {
                IDALOrders _DAL = new DALOrders();
                _DS = _DAL.GetOrderInfoByOrderNO( orderNO );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Orders.GetOrderInfoByOrderNO Ex:" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 会员中心-我的账户全部记录11762
        /// <summary>
        /// 会员中心-我的账户全部记录11762
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总记录数</param>
        /// <returns></returns>
        public static DataSet GetMemberCenterAllBalanceRecord( out int count, params object[] para )
        {
            int _UserID = (int)para[0];
            DateTime _BeginTime = (DateTime)para[1];
            DateTime _EndTime = (DateTime)para[2];
            int _FIdx = (int)para[3];
            int _EIdx = (int)para[4];
            int _IsCount = (int)para[5];
            count = 0;
            DataSet _DS = null;
            if ( _UserID > 0 && _FIdx > 0 && _EIdx >= _FIdx && _EndTime > _BeginTime )
            {
                IDALUsers _DAL = new DALUsers();
                _DS = _DAL.GetMemberCenterAllBalanceRecord( _UserID, _BeginTime, _EndTime, _FIdx, _EIdx, _IsCount, out count );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 会员中心-佣金明细全部记录11763
        /// <summary>
        /// 会员中心-佣金明细全部记录11763
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
        public static DataSet GetMemberCenterBrokerPageByUserID( out int totalCount, params object[] para )
        {
            int _UserID = (int)para[0];
            int _BrokerType = (int)para[1];
            DateTime _BeginTime = (DateTime)para[2];
            DateTime _EndTime = (DateTime)para[3];
            int _FIdx = (int)para[4];
            int _EIdx = (int)para[5];
            int _IsCount = (int)para[6];
            DataSet _DS = null;
            totalCount = 0;
            if ( _UserID > 0 && _FIdx > 0 && _EIdx >= _FIdx )
            {
                IDALUsers _DAL = new DALUsers();
                _DS = _DAL.GetMemberCenterBrokerPageByUserID( _UserID, _BrokerType, _BeginTime, _EndTime, _FIdx, _EIdx, _IsCount, out totalCount );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 分页获取晒单或话题的评论回复消息列表11764
        /// <summary>
        /// 分页获取晒单或话题的评论回复消息列表11764
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总记录数</param>
        /// <returns></returns>
        public static DataSet GetReplyMsgPageByUserID( out int totalCount, params object[] para )
        {
            int _UserID = (int)para[0];
            int _FIdx = (int)para[1];
            int _EIdx = (int)para[2];
            int _IsCount = (int)para[3];
            DataSet _DS = null;
            totalCount = 0;
            if ( _UserID > 0 && _FIdx > 0 && _EIdx >= _FIdx )
            {
                IDALUserMsg _DAL = new DALUserMsg();
                _DS = _DAL.GetReplyMsgPageByUserID( _UserID, _FIdx, _EIdx, _IsCount, out totalCount );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 用户删除晒单或话题的评论回复消息11765
        /// <summary>
        /// 用户删除晒单或话题的评论回复消息11765
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="msgID">消息ID 等于0则删除全部</param>
        /// <returns></returns>
        public static int DeleteReplyMsgByUserID( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            int _MsgID = (int)para[1];
            if ( _UserID > 0 && _MsgID >= 0 )
            {
                IDALUserMsg _DAL = new DALUserMsg();
                _Result = _DAL.DeleteReplyMsgByUserID( _UserID, _MsgID );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 添加会员邀请链接短地址11766
        /// <summary>
        /// 添加会员邀请链接短地址11766
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="urlType">地址类型 0.会员中心 1.邀请页面</param>
        /// <param name="shortUrl">短地址</param>
        /// <returns></returns>
        public static int InsertUserShortUrl( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            int _UrlType = (int)para[1];
            string _ShortUrl = (string)para[2];
            IDALUsers _DAL = new DALUsers();
            _Result = _DAL.InsertUserShortUrl( _UserID, _UrlType, _ShortUrl );
            _DAL = null;
            return _Result;
        }
        #endregion
        #region 根据短地址获取用户ID11767
        /// <summary>
        /// 根据短地址获取用户ID11767
        /// </summary>
        /// <param name="shortUrl">短地址</param>
        /// <returns></returns>
        public static DataSet GetUserIDByShortUrl( params object[] para )
        {
            DataSet _DS = null;
            string _ShortUrl = (string)para[0];
            IDALUsers _DAL = new DALUsers();
            _DS = _DAL.GetUserIDByShortUrl( _ShortUrl );
            _DAL = null;
            return _DS;
        }
        #endregion
        #region 根据用户ID获取短地址11768
        /// <summary>
        /// 根据用户ID获取短地址11768
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static DataSet GetShortUrlByUserID( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            IDALUsers _DAL = new DALUsers();
            _DS = _DAL.GetShortUrlByUserID( _UserID );
            _DAL = null;
            return _DS;
        }
        #endregion
        #region 获取需要补差价的换货列表11770
        /// <summary>
        /// 获取需要补差价的换货列表
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总数</param>
        /// <returns></returns>
        public static DataSet GetExChangeListByUserID( out int totalCount, params object[] para )
        {
            int _UserID = (int)para[0];
            int _FIdx = (int)para[1];
            int _EIdx = (int)para[2];
            int _IsCount = (int)para[3];
            IDALUsers _DAL = new DALUsers();
            DataSet _DS = _DAL.GetExChangeListByUserID( _UserID, _FIdx, _EIdx, _IsCount, out totalCount );
            _DAL = null;
            return _DS;
        }
        #endregion
        #region 根据换货编号获取换货详情11771
        /// <summary>
        /// 根据换货编号获取换货详情
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="exID">换货编号</param>
        /// <returns></returns>
        public static DataSet GetExChangeInfoByExID( params object[] para )
        {
            int _UserID = (int)para[0];
            int _ExID = (int)para[1];
            IDALUsers _DAL = new DALUsers();
            DataSet _DS = _DAL.GetExChangeInfoByExID( _UserID, _ExID );
            _DAL = null;
            return _DS;
        }
        #endregion
        #region 根据换货编号单条申请的记录11772
        /// <summary>
        /// 根据换货编号单条申请的记录
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="exID">换货编号</param>
        /// <returns></returns>
        public static DataSet GetExChangeOneByExID( params object[] para )
        {
            int _UserID = (int)para[0];
            int _ExID = (int)para[1];
            IDALUsers _DAL = new DALUsers();
            DataSet _DS = _DAL.GetExChangeOneByExID( _UserID, _ExID );
            _DAL = null;
            return _DS;
        }
        #endregion
        #region 修改用户基本信息11773
        /// <summary>
        /// 修改用户基本信息11773
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="modType">要修改的字段类型</param>
        /// <param name="content">要修改的内容</param>
        /// <returns></returns>
        public static int UpdateMemberCenterForUserBaseByType( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            int _ModType = (int)para[1];
            string _Content = (string)para[2];
            if ( _ModType == 0 && UtilityFun.IsEmptyString( _Content ) )
            {
                return _Result;
            }
            if ( _UserID > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.UpdateMemberCenterForUserBaseByType( _UserID, _ModType, _Content );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 验证支付密码,返回冻结剩余时间（s）11774
        /// <summary>
        /// 验证支付密码,返回冻结剩余时间（s）11774
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="userPayPwd">支付密码</param>
        /// <returns></returns>
        public static int CheckPayPwdByUserID( out int surplusTime, params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            string _UserPayPwd = (string)para[1];
            IDALUsers _DAL = new DALUsers();
            _Result = _DAL.CheckPayPwdByUserID( _UserID, _UserPayPwd, out surplusTime );
            _DAL = null;
            return _Result;
        }
        #endregion
        #region 获取用户消费金额及注册时间11775
        /// <summary>
        /// 获取用户消费金额及注册时间11775
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static DataSet GetWasteRegTimeByUserID( params object[] para )
        {
            DataSet _DS = null;
            try
            {
                int _UserID = (int)para[0];
                IDALUsers _DAL = new DALUsers();
                _DS = _DAL.GetWasteRegTimeByUserID( _UserID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "GetWasteRegTimeByUserID Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion
    }
}
