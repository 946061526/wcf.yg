using System.Data;

namespace wcfNSYGShop
{
    public class DALUserFriends : DALBase, IDALUserFriends
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11709" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_quanlity", quanlity );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getReCommFriendByUserID" );//pro_MemberCenterForSearchFriendsDefault
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11708" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewInParameter( "i_keywords", keywords );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getUserNoFriendByUserID" );//pro_MemberCenterForSearchFriends
            totalCount = GetOrcTotalCount( isCount, _DS );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11712" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", IsCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getFindMostGoodsByUserid" );//pro_MemberCenterForSearchFriendsRaffle
            totalCount = GetOrcTotalCount( IsCount, _DS );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11710" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", IsCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getFindFriendByUserID" );//pro_MemberCenterForSearchFriendsHot
            totalCount = GetOrcTotalCount( IsCount, _DS );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11711" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", IsCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getFindNewLoginByUserid" );//pro_MemberCenterForSearchFriendsLastRegister
            totalCount = GetOrcTotalCount( IsCount, _DS );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11704" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewInParameter( "i_keywords", keywords );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getFriendPageByUserID" );//pro_MemberCenterForFriendsPageList
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }

        /// <summary>
        /// 会员中心 - 获取会员好友数量
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int GetUserFriendLinkTotalByUser( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12930" );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            string _Result = Dal.ExecuteString( "yun_UserBehaver.sp_getTotalFriendByUserID" );//pro_UserFriendLinkGetTotalByUser
            return ToInt32( _Result );
        }

        /// <summary>
        /// 获取会员好友请求信息数量
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int GetUserFriendApplyTotalByUser( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12926" );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            string _Result = Dal.ExecuteString( "yun_UserBehaver.sp_getTotalApplyByUserID" );//pro_UserFriendApplyGetTotalByUser
            return ToInt32( _Result );
        }

        /// <summary>
        /// 删除会员的好友记录，成功则返回影响 2 行
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="friendID"></param>
        /// <returns></returns>
        public int DeleteUserFriendLink( int userID, int friendID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12928" );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Para.AddOrcNewInParameter( "i_FriendID", friendID );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_delFriendRecordByUserID" );//pro_UserFriendLinkDelete
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11702" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getFriendReqByUserID" );//pro_MemberCenterForFriendApplyPageList
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }

        /// <summary>
        /// 审核申请好友的验证信息 - 同意加为好友
        /// -1: 操作失败;  1:操作成功
        /// </summary>
        /// <param name="applyID"></param>
        /// <param name="userID"></param>
        /// <param name="applyUserIDStr">申请者ID串</param>
        /// <returns></returns>
        public int CheckUserFriendApply( int applyID, int userID, out string applyUserIDStr )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12927" );
            Para.AddOrcNewInParameter( "i_applyID", applyID );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataTable _DT = Dal.ExecuteFillDataTable( "yun_UserBehaver.sp_addFriendApplyByApplyID" );//pro_UserFriendApplySuccess
            applyUserIDStr = "";
            int _Retsult = -1;
            if ( _DT != null && _DT.Rows.Count > 0 )
            {
                applyUserIDStr = _DT.Rows[0][0].ToString();
                if ( !applyUserIDStr.Contains( "," ) && ToInt32( applyUserIDStr ) < 1 )
                {
                    AddFailLog( applyUserIDStr );
                }
                else
                {
                    _Retsult = 1;
                }
            }
            _DT = null;
            return _Retsult;
        }

        /// <summary>
        /// 审核申请好友的验证信息 - 同意加为好友
        /// -1: 操作失败;  1:操作成功
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns>返回申请者ID串</returns>
        public DataSet CheckUserAllFriendApply( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12927" );
            Para.AddOrcNewInParameter( "i_applyID", 0 );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_UserBehaver.sp_addFriendApplyByApplyID" );//pro_UserFriendApplySuccess
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
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12925" );
            Para.AddOrcNewInParameter( "i_applyID", applyID );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_delFriendApplyByApplyID" );//pro_UserFriendApplyDelete
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }

        /// <summary>
        /// 会员中心 - 首页好友最新动态信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataSet GetMemberCenterForUserFriendMsg( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11725" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getFriendActiveByUserid" );//pro_MemberCenterForUserFriendMsg
        }

        /// <summary>
        /// 获取会员感兴趣的人
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        public DataSet GetInterestedPeople( int userID, int quanlity )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11706" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_quanlity", quanlity );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getIntrsFriendByUserID" );//pro_MemberCenterForInterestFriends
        }
        #endregion
    }
}
