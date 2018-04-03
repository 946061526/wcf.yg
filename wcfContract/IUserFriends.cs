using System;
using System.Data;
using System.ServiceModel;

namespace wcfNSYGShop
{
    public partial interface IWCFContract
    {
        #region 新版会员中心 2012.8

        /// <summary>
        /// 会员中心 - 获取推荐的好友
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetMemberCenterForSearchFriendsDefault( int userID, int quanlity );

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
        [OperationContract]
        DataSet GetMemberCenterForSearchFriends( int userID, int FIdx, int EIdx, int isCount, string keywords, out int totalCount );

        /// <summary>
        /// 会员中心 - 查找好友 - 获得商品最多的
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetMemberCenterForSearchFriendsRaffle( int userID, int FIdx, int EIdx, int IsCount, out int totalCount );

        /// <summary>
        /// 会员中心 - 查找好友 - 最活跃的用户
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="IsCount"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetMemberCenterForSearchFriendsHot( int userID, int FIdx, int EIdx, int IsCount, out int totalCount );

        /// <summary>
        /// 会员中心 - 查找好友 - 最新加入的用户
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetMemberCenterForSearchFriendsLastRegister( int userID, int FIdx, int EIdx, int IsCount, out int totalCount );

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
        [OperationContract]
        DataSet GetMemberCenterForFriendsPageList( int userID, int FIdx, int EIdx, int isCount, string keywords, out int totalCount );

        /// <summary>
        /// 会员中心 - 获取会员好友数量
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [OperationContract]
        int GetUserFriendLinkTotalByUser( int userID );

        /// <summary>
        /// 获取会员好友请求信息数量
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [OperationContract]
        int GetUserFriendApplyTotalByUser( int userID );

        /// <summary>
        /// 删除会员的好友记录，成功则返回影响 2 行
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="friendID"></param>
        /// <returns></returns>
        [OperationContract]
        int DeleteUserFriendLink( int userID, int friendID );

        /// <summary>
        /// 会员中心获取好友申请列表
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetMemberCenterForFriendsApplyPageList( int userID, int FIdx, int EIdx, int isCount, out int totalCount );

        /// <summary>
        /// 审核申请好友的验证信息 - 同意加为好友
        /// -1: 操作失败;  1:操作成功
        /// </summary>
        /// <param name="applyID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        [OperationContract]
        int CheckUserFriendApply( int applyID, int userID );

        /// <summary>
        /// 审核申请好友的验证信息 - 同意加为好友
        /// -1: 操作失败;  1:操作成功
        /// </summary>
        /// <param name="applyID"></param>
        /// <param name="userID"></param>
        /// <param name="applyUserIDStr">申请者ID串</param>
        /// <returns></returns>
        [OperationContract]
        int CheckAllUserFriendApply( int applyID, int userID, out string applyUserIDStr );

        /// <summary>
        /// 审核申请好友的验证信息 - 忽略验证信息
        /// -1: 操作失败;  1:操作成功
        /// </summary>
        /// <param name="applyID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        [OperationContract]
        int DeleteUserFriendApply( int applyID, int userID );

        /// <summary>
        /// 会员中心 - 首页好友最新动态信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetMemberCenterForUserFriendMsg( int userID );

        /// <summary>
        /// 获取会员感兴趣的人
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetInterestedPeople( int userID, int quanlity );
        #endregion
    }
}
