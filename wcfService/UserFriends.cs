using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class WCFServiceFun
    {
        #region 新版会员中心 2012.8

        /// <summary>
        /// 会员中心 - 获取推荐的好友
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        public DataSet GetMemberCenterForSearchFriendsDefault( int userID, int quanlity )
        {
            DataSet _DS = null;
            if ( userID > 0 && quanlity > 0 )
            {
                try
                {
                    IDALUserFriends _DAL = new DALUserFriends();
                    _DS = _DAL.GetMemberCenterForSearchFriendsDefault( userID, quanlity );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserFriends.GetMemberCenterForSearchFriendsDefault Exception:" + ex.Message );
                }
            }
            return _DS;
        }

        /// <summary>
        /// 会员中心 - 搜索全站未添加好友的会员信息
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="keywords"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public DataSet GetMemberCenterForSearchFriends( int userID, int FIdx, int EIdx, int isCount, string keywords, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            if ( userID > 0 && FIdx > 0 && EIdx > FIdx )
            {
                try
                {
                    IDALUserFriends _DAL = new DALUserFriends();
                    _DS = _DAL.GetMemberCenterForSearchFriends( userID, FIdx, EIdx, isCount, keywords, out totalCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserFriends.GetMemberCenterForSearchFriends Exception:" + ex.Message );
                }
            }
            return _DS;
        }

        /// <summary>
        /// 会员中心 - 查找好友 - 获得商品最多的
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <returns></returns>
        public DataSet GetMemberCenterForSearchFriendsRaffle( int userID, int FIdx, int EIdx, int IsCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            if ( userID > 0 && FIdx > 0 && EIdx > FIdx )
            {
                try
                {
                    IDALUserFriends _DAL = new DALUserFriends();
                    _DS = _DAL.GetMemberCenterForSearchFriendsRaffle( userID, FIdx, EIdx, IsCount, out totalCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserFriends.GetMemberCenterForSearchFriendsRaffle Exception:" + ex.Message );
                }
            }
            return _DS;
        }

        /// <summary>
        /// 会员中心 - 查找好友 - 最活跃的用户
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="IsCount"></param>
        /// <returns></returns>
        public DataSet GetMemberCenterForSearchFriendsHot( int userID, int FIdx, int EIdx, int IsCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            if ( userID > 0 && FIdx > 0 && EIdx > FIdx )
            {
                try
                {
                    IDALUserFriends _DAL = new DALUserFriends();
                    _DS = _DAL.GetMemberCenterForSearchFriendsHot( userID, FIdx, EIdx, IsCount, out totalCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserFriends.GetMemberCenterForSearchFriendsHot Exception:" + ex.Message );
                }
            }
            return _DS;
        }

        /// <summary>
        /// 会员中心 - 查找好友 - 最新加入的用户
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <returns></returns>
        public DataSet GetMemberCenterForSearchFriendsLastRegister( int userID, int FIdx, int EIdx, int IsCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            if ( userID > 0 && FIdx > 0 && EIdx > FIdx )
            {
                try
                {
                    IDALUserFriends _DAL = new DALUserFriends();
                    _DS = _DAL.GetMemberCenterForSearchFriendsLastRegister( userID, FIdx, EIdx, IsCount, out totalCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserFriends.GetMemberCenterForSearchFriendsLastRegister Exception:" + ex.Message );
                }
            }
            return _DS;
        }

        /// <summary>
        /// 会员中心 - 获取某会员所有的好友分页列表
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="keywords"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public DataSet GetMemberCenterForFriendsPageList( int userID, int FIdx, int EIdx, int isCount, string keywords, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            if ( userID > 0 && FIdx > 0 && EIdx > FIdx )
            {
                try
                {
                    IDALUserFriends _DAL = new DALUserFriends();
                    _DS = _DAL.GetMemberCenterForFriendsPageList( userID, FIdx, EIdx, isCount, keywords, out totalCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserFriends.GetMemberCenterForFriendsPageList Exception:" + ex.Message );
                }
            }
            return _DS;
        }

        /// <summary>
        /// 会员中心 - 获取会员好友数量
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int GetUserFriendLinkTotalByUser( int userID )
        {
            int _Count = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALUserFriends _DAL = new DALUserFriends();
                    _Count = _DAL.GetUserFriendLinkTotalByUser( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserFriends.GetUserFriendLinkTotalByUser Exception:" + ex.Message );
                }
            }
            return _Count;
        }

        /// <summary>
        /// 获取会员好友请求信息数量
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int GetUserFriendApplyTotalByUser( int userID )
        {
            int _Count = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALUserFriends _DAL = new DALUserFriends();
                    _Count = _DAL.GetUserFriendApplyTotalByUser( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserFriends.GetUserFriendApplyTotalByUser Exception:" + ex.Message );
                }
            }
            return _Count;
        }

        /// <summary>
        /// 删除会员的好友记录，成功则返回影响 2 行
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="friendID"></param>
        /// <returns></returns>
        public int DeleteUserFriendLink( int userID, int friendID )
        {
            int _Result = 0;
            if ( userID > 0 && friendID > 0 )
            {
                try
                {
                    IDALUserFriends _DAL = new DALUserFriends();
                    _Result = _DAL.DeleteUserFriendLink( userID, friendID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserFriends.DeleteUserFriendLink Exception:" + ex.Message );
                }
            }
            return _Result;
        }

        /// <summary>
        /// 会员中心获取好友申请列表
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public DataSet GetMemberCenterForFriendsApplyPageList( int userID, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            if ( userID > 0 && FIdx > 0 && EIdx > FIdx )
            {
                try
                {
                    IDALUserFriends _DAL = new DALUserFriends();
                    _DS = _DAL.GetMemberCenterForFriendsApplyPageList( userID, FIdx, EIdx, isCount, out totalCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserFriends.GetMemberCenterForFriendsApplyPageList Exception:" + ex.Message );
                }
            }
            return _DS;
        }

        /// <summary>
        /// 审核申请好友的验证信息 - 同意加为好友
        /// -1: 操作失败;  1:操作成功
        /// </summary>
        /// <param name="applyID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int CheckUserFriendApply( int applyID, int userID )
        {
            string _ApplyUserIDStr = "";
            return CheckAllUserFriendApply( applyID, userID, out _ApplyUserIDStr );
        }

        /// <summary>
        /// 审核申请好友的验证信息 - 同意加为好友
        /// -1: 操作失败;  1:操作成功
        /// </summary>
        /// <param name="applyID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int CheckAllUserFriendApply( int applyID, int userID, out string applyUserIDStr )
        {
            int _Result = 0;
            applyUserIDStr = "";
            if ( applyID >= 0 && userID > 0 )//0：通过全部
            {
                try
                {
                    IDALUserFriends _DAL = new DALUserFriends();
                    _Result = _DAL.CheckUserFriendApply( applyID, userID , out applyUserIDStr);
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    applyUserIDStr = "";
                    UtilityFile.AddLogErrMsg( string.Format( "UserFriends.CheckAllUserFriendApply Exception: [applyID-{0} userID-{1}] {2}", applyID, userID, ex.Message ) );
                }
            }
            return _Result;
        }

        /// <summary>
        /// 审核申请好友的验证信息 - 忽略验证信息
        /// -1: 操作失败;  1:操作成功
        /// </summary>
        /// <param name="applyID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int DeleteUserFriendApply( int applyID, int userID )
        {
            int _Result = 0;
            if ( applyID >= 0 && userID > 0 )//0:忽略全部
            {
                try
                {
                    IDALUserFriends _DAL = new DALUserFriends();
                    _Result = _DAL.DeleteUserFriendApply( applyID, userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserFriends.DeleteUserFriendApply Exception:" + ex.Message );
                }
            }
            return _Result;
        }

        /// <summary>
        /// 会员中心 - 首页好友最新动态信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataSet GetMemberCenterForUserFriendMsg( int userID )
        {
            DataSet _DS = null;
            if ( userID > 0 )
            {
                try
                {
                    IDALUserFriends _DAL = new DALUserFriends();
                    _DS = _DAL.GetMemberCenterForUserFriendMsg( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserFriends.GetMemberCenterForUserFriendMsg Exception:" + ex.Message );
                }
            }
            return _DS;
        }

        /// <summary>
        /// 获取会员感兴趣的人
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        public DataSet GetInterestedPeople( int userID, int quanlity )
        {
            DataSet _DS = null;
            if ( userID > 0 && quanlity > 0 )
            {
                try
                {
                    IDALUserFriends _DAL = new DALUserFriends();
                    _DS = _DAL.GetInterestedPeople( userID, quanlity );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserFriends.GetInterestedPeople Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
    }
}
