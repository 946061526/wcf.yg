using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 获取会员的最新访客13001
        /// <summary>
        /// 获取会员的最新访客13001
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="quanlity">获取数量</param>
        /// <returns></returns>
        public static DataSet GetLatestVisitors( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            int _Quanlity = (int)para[1];
            if ( _UserID > 0 && _Quanlity > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _DS = _DAL.GetLatestVisitors( _UserID, _Quanlity );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 插入访客记录13002
        /// <summary>
        /// 插入访客记录13002
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="browserID">访客ID</param>
        /// <param name="ipNum">访客IP值</param>
        /// <returns></returns>
        public static int InsertUserWebBrowser( params object[] para )
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            int _BrowserID = (int)para[1];
            long _IpNum = (long)para[2];
            if ( _UserID > 0 && _BrowserID > 0 && _IpNum > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.InsertUserWebBrowser( _UserID, _BrowserID, _IpNum );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 个人主页获取会员基础信息13003
        /// <summary>
        /// 个人主页获取会员基础信息13003
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public static DataSet GetUserBaseInfo( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _DS = _DAL.GetUserBaseInfo( _UserID );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 获取会员最新动态13004
        /// <summary>
        /// 获取会员最新动态13004
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static DataSet GetUserLatestMessage( params object[] para )
        {
            int userID = (int)para[0];
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
        #region 个人主页-获取会员最新云购记录13005
        /// <summary>
        /// 个人主页-获取会员最新云购记录13005
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public static DataSet GetUserWebPageBuyList( out int totalCount, params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            int _FIdx = (int)para[1];
            int _EIdx = (int)para[2];
            DateTime _BeginTime = UtilityFun.ToDateTime( "2010-01-01" );
            DateTime _EndTime = DateTime.Now;
            int _IsCount = 0;
            if ( para.Length == 6 )
            {
                _BeginTime = (DateTime)para[3];
                _EndTime = (DateTime)para[4];
                _IsCount = (int)para[5];
            }
            else
            {
                _IsCount = (int)para[3];
            }
            totalCount = 0;
            if ( _UserID > 0 )
            {
                IDALUserBuy _DAL = new DALUserBuy();
                _DS = _DAL.GetUserWebPageBuyList( _UserID, _FIdx, _EIdx, _BeginTime, _EndTime, _IsCount, out totalCount );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 分页获取会员的好友13006
        /// <summary>
        /// 分页获取会员的好友13006
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">输出总记录数</param>
        /// <returns></returns>
        public static DataSet GetUserFriendsList( out int totalCount, params object[] para )
        {
            DataSet _DS = null;
            totalCount = 0;
            int _UserID = (int)para[0];
            int _FIdx = (int)para[1];
            int _EIdx = (int)para[2];
            int _IsCount = (int)para[3];
            if ( _UserID > 0 )
            {
                IDALUsers _DAL = new DALUsers();
                _DS = _DAL.GetUserFriends( _UserID, _FIdx, _EIdx, _IsCount, out totalCount );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 个人主页-获取用户加入的圈子13007
        /// <summary>
        /// 个人主页-获取用户加入的圈子13007
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        public static DataSet GetUserWebPageForUserGroup( params object[] para )
        {
            int userID = (int)para[0];
            int quanlity = (int)para[1];
            DataSet _DS = null;
            if ( userID > 0 && quanlity > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetUserWebPageForUserGroup( userID, quanlity );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.GetUserWebPageForUserGroup Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
        #region 个人主页-获取会员晒单13008
        /// <summary>
        /// 个人主页获取会员晒单13008
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public static DataSet GetUserWebPagePostList( out int totalCount, params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            int _FIdx = (int)para[1];
            int _EIdx = (int)para[2];
            int _IsCount = (int)para[3];
            totalCount = 0;
            if ( _UserID > 0 )
            {
                IDALPostSingle _DAL = new DALPostSingle();
                _DS = _DAL.GetUserWebPagePostList( _UserID, _FIdx, _EIdx, _IsCount, out totalCount );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 个人主页-获取会员获得的商品13009
        /// <summary>
        /// 获取会员获得的商品13009
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public static DataSet GetUserWebPageRaffleList( out int totalCount, params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            int _FIdx = (int)para[1];
            int _EIdx = (int)para[2];
            DateTime _BeginTime = UtilityFun.ToDateTime( "2010-01-01" );
            DateTime _EndTime = DateTime.Now;
            int _IsCount = 0;
            if ( para.Length == 6 )
            {
                _BeginTime = (DateTime)para[3];
                _EndTime = (DateTime)para[4];
                _IsCount = (int)para[5];
            }
            else
            {
                _IsCount = (int)para[3];
            }
            totalCount = 0;
            if ( _UserID > 0 )
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetUserWebPageRaffleList( _UserID, _FIdx, _EIdx, _BeginTime, _EndTime, _IsCount, out totalCount );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 个人主页-获取某会员最近发表的话题13010
        /// <summary>
        /// 个人主页 - 获取某会员最近发表的话题13010
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="quanlity">获取数量</param>
        /// <returns></returns>
        public static DataSet GetUserWebPageForUserTopic( params object[] para )
        {
            int userID = (int)para[0];
            int quanlity = (int)para[1];
            DataSet _DS = null;
            if ( userID > 0 && quanlity > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetUserWebPageForUserTopic( userID, quanlity );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.GetUserWebPageForUserTopic Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
        #region 个人主页-获取某会员最近回复的话题13011
        /// <summary>
        /// 个人主页 - 获取某会员最近回复的话题13011
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        public static DataSet GetUserWebPageForUserTopicReply( params object[] para )
        {
            int userID = (int)para[0];
            int quanlity = (int)para[1];
            DataSet _DS = null;
            if ( userID > 0 && quanlity > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetUserWebPageForUserTopicReply( userID, quanlity );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.GetUserWebPageForUserTopicReply Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
        #region 获取会员的好友13012
        /// <summary>
        /// 获取会员的好友13012
        /// table0：好友记录；table1：记录数目
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        public static DataSet GetUserFriends( out int totalCount, params object[] para )
        {
            int userID = (int)para[0];
            int quanlity = (int)para[1];
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
        #endregion
    }
}
