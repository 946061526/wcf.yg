using System;
using System.ServiceModel;
using System.Data;

namespace wcfNSYGShop
{
    /// <summary>
    /// 云购圈子
    /// </summary>
    public partial interface IWCFContract
    {
        #region 个人主页

        /// <summary>
        /// 个人主页-获取用户加入的圈子
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserWebPageForUserGroup(int userID, int quanlity);

        /// <summary>
        /// 个人主页 - 获取某会员最近发表的话题
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserWebPageForUserTopic(int userID, int quanlity);

        /// <summary>
        /// 个人主页 - 获取某会员最近回复的话题
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserWebPageForUserTopicReply(int userID, int quanlity);

        #endregion

        #region 分页获取圈子列表
        /// <summary>
        /// 分页获取圈子列表
        /// </summary>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGroupsPageList(int FIdx, int EIdx, int isCount, out int totalCount);
        #endregion

        #region 获取圈子中用户相关统计信息
        /// <summary>
        /// 获取圈子中用户相关统计信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGroupsPageForUserTotalInfo(int userID);
        #endregion

        #region 获取圈子话题[推荐、最新、热门]
        /// <summary>
        /// 获取圈子话题[推荐、最新、热门]
        /// </summary>
        /// <param name="quanlity">获得数量</param>
        /// <param name="topicType">2.热门 0.推荐 1.最新</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGroupsPageForTopic(int quanlity, int topicType);
        #endregion

        #region 获取圈子动态
        /// <summary>
        /// 获取圈子动态
        /// </summary>
        /// <param name="quanlity">获取数量</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGroupsLastMsg(int quanlity);
        #endregion

        #region 获取活跃用户
        /// <summary>
        /// 获取活跃用户
        /// </summary>
        /// <param name="quanlity">获取数量</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGroupsPageForHotUser(int quanlity);
        #endregion

        #region 获取最新加入某个圈子的用户
        /// <summary>
        /// 获取最新加入某个圈子的用户
        /// </summary>
        /// <param name="groupID">圈子ID</param>
        /// <param name="quanlity">获取数量</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGroupsPageForLastJoinUser(int groupID, int quanlity);
        #endregion

        #region 获取最某个圈子的最新动态
        /// <summary>
        /// 获取最某个圈子的最新动态
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGroupLastMsgNewest(int groupID, int quanlity);
        #endregion

        #region 得到某个圈子的信息
        /// <summary>
        /// 得到某个圈子的信息
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGroupInfo(int groupID, int userID);
        #endregion

        #region 获取某圈子的管理者信息
        /// <summary>
        /// 获取某圈子的管理者信息
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGroupsPageForAdminUserInfo(int groupID);
        #endregion

        #region 加入某个圈子
        /// <summary>
        /// 加入某个圈子
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="groupID"></param>
        /// <returns></returns>
        [OperationContract]
        int InsertGroupUser(int userID, int groupID);
        #endregion

        #region 退出圈子
        /// <summary>
        /// 退出圈子
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="groupID"></param>
        /// <returns></returns>
        [OperationContract]
        int DeleteGroupUser(int userID, int groupID);
        #endregion

        #region 获取某个用户所加入的圈子
        /// <summary>
        /// 获取某个用户所加入的圈子
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGroupsListByUser(int userID);
        #endregion

        #region 检测用户是否已加入某圈子
        /// <summary>
        /// 检测用户是否已加入某圈子
        /// -1: 未加入   1:  已经加入
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="groupID"></param>
        /// <returns></returns>
        [OperationContract]
        int CheckGroupUserExists(int userID, int groupID);
        #endregion

        #region 修改圈子信息 1成功，0失败
        /// <summary>
        /// 修改圈子信息 1成功，0失败
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="groupName"></param>
        /// <param name="groupIco"></param>
        /// <param name="groupAbout"></param>
        /// <param name="groupNotice"></param>
        /// <returns></returns>
        [OperationContract]
        int UpdateGroupInfo(int groupID, string groupName, string groupIco, string groupAbout, string groupNotice);
        #endregion

        #region 添加圈子动态信息
        /// <summary>
        /// 添加圈子动态信息
        /// </summary>
        /// <param name="groupID">圈子ID</param>
        /// <param name="userID">会员ID</param>
        /// <param name="userName">会员昵称</param>
        /// <param name="userFace">会员头像</param>
        /// <param name="userWeb">会员主页标识</param>
        /// <param name="msgType">消息类型</param>
        /// <param name="msgLinkID">消息链接对应ID</param>
        /// <param name="msgContent">消息内容</param>
        /// <returns></returns>
        [OperationContract]
        bool InsertGroupLastMsg(int groupID, int userID, string userName, string userFace,
           string userWeb, int msgType, int msgLinkID, string msgContent);
        #endregion

        #region 话题列表页

        /// <summary>
        /// 获取圈子的话题翻页列表
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGroupTopicPageList(int groupID, int FIdx, int EIdx, int isCount, out int totalCount);

        /// <summary>
        /// 获取圈子的(精华)话题翻页列表
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGroupTopicGoodPageList(int groupID, int FIdx, int EIdx, int isCount, out int totalCount);

        /// <summary>
        /// 发表话题 0 失败   1 成功
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="userID"></param>
        /// <param name="title"></param>
        /// <param name="about"></param>
        /// <param name="content"></param>
        /// <param name="topicImg"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        [OperationContract]
        int InsertGroupTopic(int groupID, int userID, string title, string about, string content, string topicImg, string ip, out int topicID);

        /// <summary>
        /// 修改话题 0 失败   1 成功
        /// </summary>
        /// <param name="topicID"></param>
        /// <param name="userID"></param>
        /// <param name="title"></param>
        /// <param name="about"></param>
        /// <param name="content"></param>
        /// <param name="topicImg"></param>
        /// <returns></returns>
        [OperationContract]
        int UpdateGroupTopic(int topicID, int userID, string title, string about, string content, string topicImg);

        /// <summary>
        /// 圈子 - 获取所有圈子通告类型的话题列表
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGroupTopicGlobalList(int groupID);

        #endregion

        #region 话题详细页

        /// <summary>
        /// 获取话题信息
        /// </summary>
        /// <param name="topicID"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGroupTopicInfo(int topicID);

        /// <summary>
        /// 话题-更新人气
        /// </summary>
        /// <param name="topicID"></param>
        /// <returns></returns>
        [OperationContract]
        int UpdateGroupTopicLookCount(int topicID);

        /// <summary>
        /// 话题-回复
        /// </summary>
        /// <param name="topicID"></param>
        /// <param name="userID"></param>
        /// <param name="userName"></param>
        /// <param name="userWeb"></param>
        /// <param name="refFloor"></param>
        /// <param name="content"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        [OperationContract]
        int InsertGroupReply(int topicID, int userID, string userName, string userWeb, int refFloor, string content, string ip);

        /// <summary>
        /// 获取圈子的话题回复记录翻页列表
        /// </summary>
        /// <param name="topicID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGroupReplyPageList(int topicID, int FIdx, int EIdx, int isCount, out int totalCount);

        /// <summary>
        /// 删除回复
        /// </summary>
        /// <param name="topicID"></param>
        /// <param name="userID"></param>
        /// <param name="replyID"></param>
        /// <returns></returns>
        [OperationContract]
        int DeleteGroupReply(int topicID, int userID, int replyID);

        /// <summary>
        /// 话题-设置精华（1：是，0：否）
        /// </summary>
        /// <param name="topicID"></param>
        /// <param name="isGood"></param>
        /// <returns></returns>
        [OperationContract]
        int UpdateGroupTopicGood(int topicID, int isGood);

        /// <summary>
        /// 屏蔽话题 -1 删除失败; 1 删除成功
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="userID"></param>
        /// <param name="topicID"></param>
        /// <returns></returns>
        [OperationContract]
        int DeleteGroupTopic(int groupID, int userID, int topicID);

        #endregion

        #region 获取圈子中会员的权限值
        /// <summary>
        /// 获取圈子中会员的权限值
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="groupID"></param>
        /// <returns></returns>
        [OperationContract]
        int GetGroupUserPower(int userID, int groupID);
        #endregion

        #region 首页
        /// <summary>
        /// 获取公告圈子最新发布的话题信息
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGroupTopicNoticeList();
        /// <summary>
        /// 返回最近N条圈子话题动态信息
        /// </summary>
        /// <param name="msgID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGroupLastMsgForHome(int msgID, int quanlity);
        #endregion

        #region 会员中心 - 获取某会员加入的圈子信息
        /// <summary>
        /// 会员中心 - 获取某会员加入的圈子信息
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetMemberCenterForUserGroupList(int userID, int FIdx, int EIdx, int isCount, out int totalCount);
        #endregion

        #region 退出圈子
        /// <summary>
        /// 退出圈子
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="groupID"></param>
        /// <returns></returns>
        [OperationContract]
        int DeleteUserGroup(int userID, int groupID);
        #endregion

        #region 会员中心 - 获取某会员发表的话题列表
        /// <summary>
        /// 会员中心 - 获取某会员发表的话题列表
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <param name="totalReplyCount"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetMemberCenterForTopicPageList(int userID, int FIdx, int EIdx, int isCount, out int totalCount, out int totalReplyCount);
        #endregion

        #region 会员中心 - 获取某会员回复圈子话题列表
        /// <summary>
        /// 会员中心 - 获取某会员回复圈子话题列表
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetMemberCenterForTopicReplyPageList(int userID, int FIdx, int EIdx, int isCount, out int totalCount);
        #endregion

        #region 会员中心 - 添加圈主或管理员相关申请
        /// <summary>
        /// 会员中心 - 添加圈主或管理员相关申请
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="userID"></param>
        /// <param name="applyMsg"></param>
        /// <returns></returns>
        [OperationContract]
        int InsertGroupAdminApply(int groupID, int userID, string applyMsg);
        #endregion

        #region 返回首页显示的圈子话题
        /// <summary>
        /// 返回首页显示的圈子话题
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGroupsTopicForHome();
        #endregion

        #region 获取不同标识的圈子列表
        /// <summary>
        /// 获取不同标识的圈子列表
        /// </summary>
        /// <param name="groupType"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGroupsListByGroupType(int groupType);
        #endregion
    }
}
