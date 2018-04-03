using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class WCFServiceFun
    {
        #region 个人主页

        /// <summary>
        /// 个人主页-获取用户加入的圈子
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        public DataSet GetUserWebPageForUserGroup( int userID, int quanlity )
        {
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

        /// <summary>
        /// 个人主页 - 获取某会员最近发表的话题
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        public DataSet GetUserWebPageForUserTopic( int userID, int quanlity )
        {
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

        /// <summary>
        /// 个人主页 - 获取某会员最近回复的话题
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        public DataSet GetUserWebPageForUserTopicReply( int userID, int quanlity )
        {
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

        #region 分页获取圈子列表
        /// <summary>
        /// 分页获取圈子列表
        /// </summary>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public DataSet GetGroupsPageList( int FIdx, int EIdx, int isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALGroup _DAL = new DALGroup();
                _DS = _DAL.GetGroupsPageList( FIdx, EIdx, isCount, out totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Group.GetGroupsPageList Exception:" + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region 获取圈子中用户相关统计信息
        /// <summary>
        /// 获取圈子中用户相关统计信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataSet GetGroupsPageForUserTotalInfo( int userID )
        {
            DataSet _DS = null;
            if ( userID > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupsPageForUserTotalInfo( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.GetGroupsPageForUserTotalInfo Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 获取圈子话题[推荐、最新、热门]
        /// <summary>
        /// 获取圈子话题[推荐、最新、热门]
        /// </summary>
        /// <param name="quanlity">获得数量</param>
        /// <param name="topicType">2.热门 0.推荐 1.最新</param>
        /// <returns></returns>
        public DataSet GetGroupsPageForTopic( int quanlity, int topicType )
        {
            DataSet _DS = null;
            if ( quanlity > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupsPageForTopic( quanlity, topicType );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.GetGroupsPageForTopic Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 获取圈子动态
        /// <summary>
        /// 获取圈子动态
        /// </summary>
        /// <param name="quanlity">获取数量</param>
        /// <returns></returns>
        public DataSet GetGroupsLastMsg( int quanlity )
        {
            DataSet _DS = null;
            if ( quanlity > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupsLastMsg( quanlity );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.GetGroupLastMsg Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 获取活跃用户
        /// <summary>
        /// 获取活跃用户
        /// </summary>
        /// <param name="quanlity">获取数量</param>
        /// <returns></returns>
        public DataSet GetGroupsPageForHotUser( int quanlity )
        {
            DataSet _DS = null;
            if ( quanlity > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupsPageForHotUser( quanlity );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.GetGroupsPageForHotUser Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 获取最新加入某个圈子的用户
        /// <summary>
        /// 获取最新加入某个圈子的用户
        /// </summary>
        /// <param name="groupID">圈子ID</param>
        /// <param name="quanlity">获取数量</param>
        /// <returns></returns>
        public DataSet GetGroupsPageForLastJoinUser( int groupID, int quanlity )
        {
            DataSet _DS = null;
            if ( groupID > 0 && quanlity > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupsPageForLastJoinUser( groupID, quanlity );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.GetGroupsPageForHotUser Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 获取最某个圈子的最新动态
        /// <summary>
        /// 获取最某个圈子的最新动态
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        public DataSet GetGroupLastMsgNewest( int groupID, int quanlity )
        {
            DataSet _DS = null;
            if ( groupID > 0 && quanlity > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupLastMsgNewest( groupID, quanlity );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.GetGroupsPageForHotUser Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 得到某个圈子的信息
        /// <summary>
        /// 得到某个圈子的信息
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataSet GetGroupInfo( int groupID, int userID )
        {
            DataSet _DS = null;
            if ( groupID > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupInfo( groupID, userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.GetGroupInfo Exception" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 获取某圈子的管理者信息
        /// <summary>
        /// 获取某圈子的管理者信息
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public DataSet GetGroupsPageForAdminUserInfo( int groupID )
        {
            DataSet _DS = null;
            if ( groupID > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupsPageForAdminUserInfo( groupID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.GetGroupsPageForAdminUserInfo Exception" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 加入某个圈子
        /// <summary>
        /// 加入某个圈子
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public int InsertGroupUser( int userID, int groupID )
        {
            int _Result = -1;
            try
            {
                IDALGroup _DAL = new DALGroup();
                _Result = _DAL.InsertGroupUser( userID, groupID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Group.InsertGroupUser Exception" + ex.Message );
            }
            return _Result;
        }
        #endregion

        #region 退出圈子
        /// <summary>
        /// 退出圈子
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public int DeleteGroupUser( int userID, int groupID )
        {
            int _Result = -1;
            try
            {
                IDALGroup _DAL = new DALGroup();
                _Result = _DAL.DeleteGroupUser( userID, groupID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Group.DeleteGroupUser Exception" + ex.Message );
            }
            return _Result;
        }
        #endregion

        #region 获取某个用户所加入的圈子
        /// <summary>
        /// 获取某个用户所加入的圈子
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataSet GetGroupsListByUser( int userID )
        {
            DataSet _DS = null;
            if ( userID > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupsListByUser( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.GetGroupsListByUser Exception" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 检测用户是否已加入某圈子
        /// <summary>
        /// 检测用户是否已加入某圈子
        /// -1: 未加入   1:  已经加入
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public int CheckGroupUserExists( int userID, int groupID )
        {
            int _Result = -1;
            try
            {
                IDALGroup _DAL = new DALGroup();
                _Result = _DAL.CheckGroupUserExists( userID, groupID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Group.CheckGroupUserExists Exception" + ex.Message );
            }
            return _Result;
        }
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
        public int UpdateGroupInfo( int groupID, string groupName, string groupIco, string groupAbout, string groupNotice )
        {
            int _Result = -1;
            try
            {
                IDALGroup _DAL = new DALGroup();
                _Result = _DAL.UpdateGroupInfo( groupID, groupName, groupIco, groupAbout, groupNotice, 0 );//1是首页推荐
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Group.UpdateGroupInfo Exception" + ex.Message );
            }
            return _Result;
        }
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
        public bool InsertGroupLastMsg( int groupID, int userID, string userName, string userFace,
           string userWeb, int msgType, int msgLinkID, string msgContent )
        {
            bool _Flag = false;
            try
            {
                IDALGroup _DAL = new DALGroup();
                _Flag = _DAL.InsertGroupLastMsg( groupID, userID, userName, userFace, userWeb, msgType, msgLinkID, msgContent );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Group.InsertGroupLastMsg Exception" + ex.Message );
            }
            return _Flag;
        }
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
        public DataSet GetGroupTopicPageList( int groupID, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            if ( groupID > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupTopicPageList( groupID, FIdx, EIdx, isCount, out  totalCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.GetGroupTopicPageList Exception:" + ex.Message );
                }
            }
            return _DS;
        }

        /// <summary>
        /// 获取圈子的(精华)话题翻页列表
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public DataSet GetGroupTopicGoodPageList( int groupID, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            if ( groupID > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupTopicGoodPageList( groupID, FIdx, EIdx, isCount, out  totalCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.GetGroupTopicGoodPageList Exception:" + ex.Message );
                }
            }
            return _DS;
        }

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
        public int InsertGroupTopic( int groupID, int userID, string title, string about, string content, string topicImg, string ip, out int topicID )
        {
            int _Result = 0;
            topicID = 0;
            if ( groupID > 0 && userID > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _Result = _DAL.InsertGroupTopic( groupID, userID, title, about, content, topicImg, ip, out  topicID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.InsertGroupTopic Exception:" + ex.Message );
                }
            }
            return _Result;
        }

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
        public int UpdateGroupTopic( int topicID, int userID, string title, string about, string content, string topicImg )
        {
            int _Result = 0;
            if ( topicID > 0 && userID > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _Result = _DAL.UpdateGroupTopic( topicID, userID, title, about, content, topicImg );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.UpdateGroupTopic Exception:" + ex.Message );
                }
            }
            return _Result;
        }

        /// <summary>
        /// 圈子 - 获取所有圈子通告类型的话题列表
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public DataSet GetGroupTopicGlobalList( int groupID )
        {
            DataSet _DS = null;
            if ( groupID > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupTopicGlobalList( groupID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.GetGroupTopicGlobalList Exception:" + ex.Message );
                }
            }
            return _DS;
        }

        #endregion

        #region 话题详细页

        /// <summary>
        /// 获取话题信息
        /// </summary>
        /// <param name="topicID"></param>
        /// <returns></returns>
        public DataSet GetGroupTopicInfo( int topicID )
        {
            DataSet _DS = null;
            if ( topicID > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupTopicInfo( topicID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.GetGroupTopicInfo Exception:" + ex.Message );
                }
            }
            return _DS;
        }

        /// <summary>
        /// 话题-更新人气
        /// </summary>
        /// <param name="topicID"></param>
        /// <returns></returns>
        public int UpdateGroupTopicLookCount( int topicID )
        {
            int _Result = 0;
            if ( topicID > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _Result = _DAL.UpdateGroupTopicLookCount( topicID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.UpdateGroupTopicLookCount Exception:" + ex.Message );
                }
            }
            return _Result;
        }

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
        public int InsertGroupReply( int topicID, int userID, string userName, string userWeb, int refFloor, string content, string ip )
        {
            int _Result = 0;
            if ( topicID > 0 && userID > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _Result = _DAL.InsertGroupReply( topicID, userID, userName, userWeb, refFloor, content, ip );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.InsertGroupReply Exception:" + ex.Message );
                }
            }
            return _Result;
        }

        /// <summary>
        /// 获取圈子的话题回复记录翻页列表
        /// </summary>
        /// <param name="topicID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public DataSet GetGroupReplyPageList( int topicID, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            if ( topicID > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupReplyPageList( topicID, FIdx, EIdx, isCount, out totalCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.GetGroupReplyPageList Exception:" + ex.Message );
                }
            }
            return _DS;
        }

        /// <summary>
        /// 删除回复
        /// </summary>
        /// <param name="topicID"></param>
        /// <param name="userID"></param>
        /// <param name="replyID"></param>
        /// <returns></returns>
        public int DeleteGroupReply( int topicID, int userID, int replyID )
        {
            int _Result = 0;
            if ( topicID > 0 && userID > 0 && replyID > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _Result = _DAL.DeleteGroupReply( topicID, userID, replyID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.DeleteGroupReply Exception:" + ex.Message );
                }
            }
            return _Result;
        }

        /// <summary>
        /// 话题-设置精华（1：是，0：否）
        /// </summary>
        /// <param name="topicID"></param>
        /// <param name="isGood"></param>
        /// <returns></returns>
        public int UpdateGroupTopicGood( int topicID, int isGood )
        {
            int _Result = 0;
            if ( topicID > 0 && ( isGood == 0 || isGood == 1 ) )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _Result = _DAL.UpdateGroupTopicGood( topicID, isGood );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.UpdateGroupTopicGood Exception:" + ex.Message );
                }
            }
            return _Result;
        }

        /// <summary>
        /// 屏蔽话题 -1 删除失败; 1 删除成功
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="userID"></param>
        /// <param name="topicID"></param>
        /// <returns></returns>
        public int DeleteGroupTopic( int groupID, int userID, int topicID )
        {
            int _Result = 0;
            if ( groupID > 0 && userID > 0 && topicID > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _Result = _DAL.DeleteGroupTopic( groupID, userID, topicID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.DeleteGroupTopic Exception:" + ex.Message );
                }
            }
            return _Result;
        }

        #endregion

        #region 获取圈子中会员的权限值
        /// <summary>
        /// 获取圈子中会员的权限值
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public int GetGroupUserPower( int userID, int groupID )
        {
            int _Power = 0;
            if ( userID > 0 && groupID > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _Power = _DAL.GetGroupUserPower( userID, groupID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.GetGroupUserPower Exception:" + ex.Message );
                }
            }
            return _Power;
        }
        #endregion

        #region 首页
        /// <summary>
        /// 获取公告圈子最新发布的话题信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetGroupTopicNoticeList()
        {
            DataSet _DS = null;
            try
            {
                IDALGroup _DAL = new DALGroup();
                _DS = _DAL.GetGroupTopicNoticeList();
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Group.GetGroupTopicNoticeList Exception:" + ex.Message );
            }
            return _DS;
        }
        /// <summary>
        /// 返回最近N条圈子话题动态信息
        /// </summary>
        /// <param name="msgID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        public DataSet GetGroupLastMsgForHome( int msgID, int quanlity )
        {
            DataSet _DS = null;
            try
            {
                IDALGroup _DAL = new DALGroup();
                _DS = _DAL.GetGroupLastMsgForHome( msgID, quanlity );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Group.GetGroupLastMsgForHome Exception:" + ex.Message );
            }
            return _DS;
        }
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
        public DataSet GetMemberCenterForUserGroupList( int userID, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            if ( userID > 0 && FIdx > 0 && EIdx > FIdx )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetMemberCenterForUserGroupList( userID, FIdx, EIdx, isCount, out totalCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.GetMemberCenterForUserGroupList Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 退出圈子
        /// <summary>
        /// 退出圈子
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public int DeleteUserGroup( int userID, int groupID )
        {
            int _Result = 0;
            if ( userID > 0 && groupID > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _Result = _DAL.DeleteUserGroup( userID, groupID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.DeleteUserGroup Exception:" + ex.Message );
                }
            }
            return _Result;
        }
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
        public DataSet GetMemberCenterForTopicPageList( int userID, int FIdx, int EIdx, int isCount, out int totalCount, out int totalReplyCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            totalReplyCount = 0;
            if ( userID > 0 && FIdx > 0 && EIdx > FIdx )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetMemberCenterForTopicPageList( userID, FIdx, EIdx, isCount, out totalCount, out totalReplyCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.GetMemberCenterForTopicPageList Exception:" + ex.Message );
                }
            }
            return _DS;
        }
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
        public DataSet GetMemberCenterForTopicReplyPageList( int userID, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            if ( userID > 0 && FIdx > 0 && EIdx > FIdx )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetMemberCenterForTopicReplyPageList( userID, FIdx, EIdx, isCount, out totalCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.GetMemberCenterForTopicReplyPageList Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 会员中心 - 添加圈主或管理员相关申请
        /// <summary>
        /// 会员中心 - 添加圈主或管理员相关申请
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="userID"></param>
        /// <param name="applyMsg"></param>
        /// <returns></returns>
        public int InsertGroupAdminApply( int groupID, int userID, string applyMsg )
        {
            int _Result = 0;
            if ( groupID > 0 && userID > 0 )
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _Result = _DAL.InsertGroupAdminApply( groupID, userID, applyMsg );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Group.InsertGroupAdminApply Exception:" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion

        #region 返回首页显示的圈子话题
        /// <summary>
        /// 返回首页显示的圈子话题
        /// </summary>
        /// <returns></returns>
        public DataSet GetGroupsTopicForHome()
        {
            DataSet _DS = null;
            try
            {
                IDALGroup _DAL = new DALGroup();
                _DS = _DAL.GetGroupsTopicForHome();
                _DAL = null;
            }
            catch( Exception ex )
            {
                UtilityFile.AddLogErrMsg("Group.GetGroupsTopicForHome Exception:" + ex.Message);
            }
            return _DS;
        }
        #endregion

        #region 获取不同标识的圈子列表
        /// <summary>
        /// 获取不同标识的圈子列表
        /// </summary>
        /// <param name="groupType"></param>
        /// <returns></returns>
        public DataSet GetGroupsListByGroupType( int groupType )
        {
            DataSet _DS = null;
            try
            {
                IDALGroup _DAL = new DALGroup();
                _DS = _DAL.GetGroupsListByGroupType(groupType);
                _DAL = null;
            }
            catch( Exception ex )
            {
                UtilityFile.AddLogErrMsg("Group.GetGroupsListByGroupType Exception:" + ex.Message);
            }
            return _DS;
        }
        #endregion
    }
}
