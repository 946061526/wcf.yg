using System;
using System.Data;

namespace wcfNSYGShop
{
    public class DALGroup : DALBase, IDALGroup
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13007" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_quanlity", quanlity );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_UserWeb.sp_getUserGroupByUserID" );//pro_UserWebPageForUserGroup
        }

        /// <summary>
        /// 个人主页 - 获取某会员最近发表的话题
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        public DataSet GetUserWebPageForUserTopic( int userID, int quanlity )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13010" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_quanlity", quanlity );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_UserWeb.sp_getUserPubTopicByUserID" );//pro_UserWebPageForUserTopic
        }

        /// <summary>
        /// 个人主页 - 获取某会员最近回复的话题
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        public DataSet GetUserWebPageForUserTopicReply( int userID, int quanlity )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13011" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_quanlity", quanlity );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_UserWeb.sp_getUserRepTopicByUserID" );//pro_UserWebPageForUserTopicReply
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11411" );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_GroupCircle.sp_getGroupPagelist" );//pro_GroupsGetPageList
            totalCount = GetOrcTotalCount( isCount, _DS );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11416" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_GroupCircle.sp_getStatUserGroupByUserid" );//pro_GroupsPageForUserTotalInfo
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11413" );
            Para.AddOrcNewInParameter( "i_quanlity", quanlity );
            Para.AddOrcNewInParameter( "i_kind", topicType );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_GroupCircle.sp_getHotTopicOfGroup" );//pro_GroupsPageForHotTopic
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11403" );
            Para.AddOrcNewInParameter( "i_quanlity", quanlity );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_GroupCircle.sp_getRecentMsgList" );//pro_GroupLastMsgGetLast
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11414" );
            Para.AddOrcNewInParameter( "i_quanlity", quanlity );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_GroupCircle.sp_getMostHotUser" );//pro_GroupsPageForHotUser
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11415" );
            Para.AddOrcNewInParameter( "i_groupid", groupID );
            Para.AddOrcNewInParameter( "i_quanlity", quanlity );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_GroupCircle.sp_getRecentUserByGroupid" );//pro_GroupsPageForLastJoinUser
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11402" );
            Para.AddOrcNewInParameter( "i_groupID", groupID );
            Para.AddOrcNewInParameter( "i_quanlity", quanlity );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_GroupCircle.sp_getGroupLastByGroupID" );//pro_GroupLastMsgGetGroupLast
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11409" );
            Para.AddOrcNewInParameter( "i_groupid", groupID );
            Para.AddOrcNewInParameter( "i_Userid", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_GroupCircle.sp_getGroupInfoByGroupid" );//pro_GroupsGetInfo
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11412" );
            Para.AddOrcNewInParameter( "i_groupid", groupID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_GroupCircle.sp_getGroupAdminByGroupid" );//pro_GroupsPageForAdminUserInfo
        }
        #endregion

        #region 加入某个圈子
        /// <summary>
        /// 加入某个圈子
        /// return:1加入成功 0异常 -1加入失败  -2禁止加入圈子
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public int InsertGroupUser( int userID, int groupID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "11432" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_groupid", groupID );
            Dal.ExecuteNonQuery( "yun_GroupCircle.f_modInGroupByUserid" );//pro_GroupUserInsert
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;//1加入成功 0异常 -1加入失败  -2禁止加入圈子
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
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "11429" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_groupid", groupID );
            Dal.ExecuteNonQuery( "yun_GroupCircle.f_modExitGroupByUserid" );//pro_GroupUserDelete
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
            /*
            >0 更新圈子的成员数量的影响行数
            0  异常 
            -1 更新圈子的成员数量失败，影响行数为0
            -2 删除圈子成员失败 */
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11410" );
            Para.AddOrcNewInParameter( "i_Userid", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_GroupCircle.sp_getGroupOfUserInByUserid" );//pro_GroupsGetListByUser
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
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "11430" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_groupid", groupID );
            Dal.ExecuteNonQuery( "yun_GroupCircle.f_chkUserInGroupByUserid" );//pro_GroupUserExists
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
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
        public int UpdateGroupInfo( int groupID, string groupName, string groupIco, string groupAbout, string groupNotice, int groupType )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "11417" );
            Para.AddOrcNewInParameter( "i_groupID", groupID );
            Para.AddOrcNewInParameter( "i_groupName", groupName );
            Para.AddOrcNewInParameter( "i_groupIco", groupIco );
            Para.AddOrcNewInParameter( "i_groupAbout", groupAbout );
            Para.AddOrcNewInParameter( "i_groupNotice", groupNotice );
            Para.AddOrcNewInParameter( "i_groupType", groupType );
            Dal.ExecuteNonQuery( "yun_GroupCircle.f_modGroupRecordByGroupid" );//pro_GroupsUpdate
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
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
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "11404" );
            Para.AddOrcNewInParameter( "i_groupID", groupID );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_userName", userName );
            Para.AddOrcNewInParameter( "i_userFace", userFace );
            Para.AddOrcNewInParameter( "i_userWeb", userWeb );
            Para.AddOrcNewInParameter( "i_msgType", msgType );
            Para.AddOrcNewInParameter( "i_msgLinkID", msgLinkID );
            Para.AddOrcNewInParameter( "i_msgContent", msgContent );
            Dal.ExecuteNonQuery( "yun_GroupCircle.f_addMsgToRecentCircle" );//pro_GroupLastMsgInsert
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal > 0;//1  成功    0  异常
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11423" );
            Para.AddOrcNewInParameter( "i_groupID", groupID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_GroupCircle.sp_getTopicPageByGroupID" );//pro_GroupTopicGetPageList
            totalCount = GetOrcTotalCount( isCount, _DS );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11420" );
            Para.AddOrcNewInParameter( "i_groupID", groupID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_GroupCircle.sp_getMainTopicByGroupid" );//pro_GroupTopicGetGoodPageList
            totalCount = GetOrcTotalCount( isCount, _DS );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "11424" );
            Para.AddOrcNewInParameter( "i_groupID", groupID );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_title", title );
            Para.AddOrcNewInParameter( "i_about", about );
            Para.AddOrcNewInParameter( "i_topicImg", topicImg );
            Para.AddOrcNewInParameter( "i_content", content );
            Para.AddOrcNewInParameter( "i_ip", ip );
            Dal.ExecuteNonQuery( "yun_GroupCircle.f_addGroupTopic" );//pro_GroupTopicInsert
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            topicID = _RetVal;
            return _RetVal;
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
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "11425" );
            Para.AddOrcNewInParameter( "i_topicID", topicID );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_title", title );
            Para.AddOrcNewInParameter( "i_about", about );
            Para.AddOrcNewInParameter( "i_topicImg", topicImg );
            Para.AddOrcNewInParameter( "i_content", content );
            Dal.ExecuteNonQuery( "yun_GroupCircle.f_modGroupTopicByTopicID" );//pro_GroupTopicUpdate
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }

        /// <summary>
        /// 圈子 - 获取所有圈子通告类型的话题列表
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public DataSet GetGroupTopicGlobalList( int groupID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11419" );
            Para.AddOrcNewInParameter( "i_groupid", groupID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_GroupCircle.sp_getAllTocpicByGroupid" );//pro_GroupTopicGetGlobalList
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11421" );
            Para.AddOrcNewInParameter( "i_topicID", topicID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_GroupCircle.sp_getTopicContentByTopicID" );//pro_GroupTopicGetInfo
        }

        /// <summary>
        /// 话题-更新人气
        /// </summary>
        /// <param name="topicID"></param>
        /// <returns></returns>
        public int UpdateGroupTopicLookCount( int topicID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "11427" );
            Para.AddOrcNewInParameter( "i_topicid", topicID );
            Dal.ExecuteNonQuery( "yun_GroupCircle.f_modPopularByTopicID" );//pro_GroupTopicUpdateLookCount
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
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
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "11408" );
            Para.AddOrcNewInParameter( "i_topicID", topicID );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_userName", userName );
            Para.AddOrcNewInParameter( "i_userWeb", userWeb );
            Para.AddOrcNewInParameter( "i_refFloor", refFloor );
            Para.AddOrcNewInParameter( "i_content", content );
            Para.AddOrcNewInParameter( "i_ip", ip );
            Dal.ExecuteNonQuery( "yun_GroupCircle.f_addReplyTopic" );//pro_GroupReplyInsert
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11407" );
            Para.AddOrcNewInParameter( "i_topicid", topicID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_GroupCircle.sp_getReplyListByTopicid" );//pro_GroupReplyGetPageList
            totalCount = GetOrcTotalCount( isCount, _DS );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "11406" );
            Para.AddOrcNewInParameter( "i_topicid", topicID );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_replyid", replyID );
            Dal.ExecuteNonQuery( "yun_GroupCircle.f_modReplyDelByToicid" );//pro_GroupReplyDelete
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }

        /// <summary>
        /// 话题-设置精华（1：是，0：否）
        /// </summary>
        /// <param name="topicID"></param>
        /// <param name="isGood"></param>
        /// <returns></returns>
        public int UpdateGroupTopicGood( int topicID, int isGood )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "11426" );
            Para.AddOrcNewInParameter( "i_topicid", topicID );
            Para.AddOrcNewInParameter( "i_isGoods", isGood );
            Dal.ExecuteNonQuery( "yun_GroupCircle.f_modTopicGoodsByTopicID" );//pro_GroupTopicUpdateGood
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
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
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "11418" );
            Para.AddOrcNewInParameter( "i_groupID", groupID );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_topicid", topicID );
            Dal.ExecuteNonQuery( "yun_GroupCircle.f_modTopicByGroupid" );//pro_GroupTopicDelete
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11431" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_groupID", groupID );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataTable _DT = Dal.ExecuteFillDataTable( "yun_GroupCircle.sp_getPermisOfUserByUserID" );//pro_GroupUserGetUserPower
            int _power = 0;
            if ( _DT != null && _DT.Rows.Count > 0 )
            {
                _power = ToInt32( _DT.Rows[0][0] );
            }
            return _power;
        }
        #endregion

        #region 首页

        /// <summary>
        /// 获取公告圈子最新发布的话题信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetGroupTopicNoticeList()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11422" );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_GroupCircle.sp_getRecentTopicOfNotice" );//pro_GroupTopicGetNoticeList
        }

        /// <summary>
        /// 返回最近N条圈子话题动态信息
        /// </summary>
        /// <param name="msgID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        public DataSet GetGroupLastMsgForHome( int msgID, int quanlity )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12211" );
            Para.AddOrcNewInParameter( "i_Msgid", msgID );
            Para.AddOrcNewInParameter( "i_quantity", quanlity );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getNMsgGroupByMsgID" );//pro_PageForGroupLastMsg
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11726" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getMemJoinGroupByUserid" );//pro_MemberCenterForUserGroupList
            totalCount = GetOrcTotalCount( isCount, _DS );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "11429" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_groupid", groupID );
            Dal.ExecuteNonQuery( "yun_GroupCircle.f_modExitGroupByUserid" );//pro_GroupUserDelete
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
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
            totalCount = 0;
            totalReplyCount = 0;
            DataSet _DS = null;

            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11713" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result_rep" );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DSTmp = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getPubTopicByUserid" );//pro_MemberCenterForTopicPageList
            if ( _DSTmp != null && _DSTmp.Tables.Count > 0 && _DSTmp.Tables[0].Rows.Count > 0 )//对返回结果特殊处理
            {
                totalReplyCount = ToInt32( _DSTmp.Tables[0].Rows[0][0] );//总回复数

                _DS = new DataSet();
                _DS.Tables.Add( _DSTmp.Tables[1].Copy() );
                totalCount = GetOrcTotalCount( isCount, _DS );
            }
            _DSTmp = null;
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11714" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getRepTopicByUserid" );//pro_MemberCenterForTopicReplyPageList
            totalCount = GetOrcTotalCount( isCount, _DS );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "11401" );
            Para.AddOrcNewInParameter( "i_groupID", groupID );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_ApplyMsg", applyMsg );
            Dal.ExecuteNonQuery( "yun_GroupCircle.f_addGroupAdminApply" );//pro_GroupAdminApplyInsert
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 返回首页显示的圈子话题
        /// <summary>
        /// 返回首页显示的圈子话题
        /// </summary>
        /// <returns></returns>
        public DataSet GetGroupsTopicForHome()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11435" );
            Para.AddOrcNewCursorParameter( "o_result1" );
            Para.AddOrcNewCursorParameter( "o_result2" );
            Para.AddOrcNewCursorParameter( "o_result3" );

            return Dal.ExecuteFillDataSet( "yun_GroupCircle.sp_getTopicForHomePage" );//pro_GroupsTopicForHome
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11434" );
            Para.AddOrcNewInParameter( "i_groupType", groupType );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_GroupCircle.sp_getDeferentGroupByType" );//pro_GroupsGetListByGroupType
        }
        #endregion

    }
}
