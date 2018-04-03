using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {

        #region 会员中心 - 添加圈主或管理员相关申请11401
        /// <summary>
        /// 会员中心 - 添加圈主或管理员相关申请11401
        /// </summary>
        /// <param name="groupID">圈子ID</param>
        /// <param name="userID">用户ID</param>
        /// <param name="applyMsg">申请信息</param>
        /// <returns></returns>
        public static int InsertGroupAdminApply(params object[] para)
        {
            int groupID = (int)para[0];
            int userID = (int)para[1];
            string applyMsg = (string)para[2];
            int _Result = 0;
            if (groupID > 0 && userID > 0)
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _Result = _DAL.InsertGroupAdminApply(groupID, userID, applyMsg);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Group.InsertGroupAdminApply Exception:" + ex.Message);
                }
            }
            return _Result;
        }
        #endregion
        #region 获取最某个圈子的最新动态11402
        /// <summary>
        /// 获取最某个圈子的最新动态11402
        /// </summary>
        /// <param name="groupID">圈子ID</param>
        /// <param name="quanlity">获取数量</param>
        /// <returns></returns>
        public static DataSet GetGroupLastMsgNewest(params object[] para)
        {
            int groupID = (int)para[0];
            int quanlity = (int)para[1];
            DataSet _DS = null;
            if (groupID > 0 && quanlity > 0)
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupLastMsgNewest(groupID, quanlity);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Group.GetGroupLastMsgNewest Exception:" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
        #region 获取圈子动态11403
        /// <summary>
        /// 获取圈子动态11403
        /// </summary>
        /// <param name="quanlity">获取数量</param>
        /// <returns></returns>
        public static DataSet GetGroupsLastMsg(params object[] para)
        {
            int quanlity = (int)para[0];
            DataSet _DS = null;
            if (quanlity > 0)
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupsLastMsg(quanlity);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Group.GetGroupLastMsg Exception:" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
        #region 添加圈子动态信息11404
        /// <summary>
        /// 添加圈子动态信息11404
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
        public static int InsertGroupLastMsg(params object[] para)
        {
            int groupID = (int)para[0];
            int userID = (int)para[1];
            string userName = (string)para[2];
            string userFace = (string)para[3];
            string userWeb = (string)para[4];
            int msgType = (int)para[5];
            int msgLinkID = (int)para[6];
            string msgContent = (string)para[7];
            int _Flag = 0;
            try
            {
                IDALGroup _DAL = new DALGroup();
                _Flag = _DAL.InsertGroupLastMsg(groupID, userID, userName, userFace, userWeb, msgType, msgLinkID, msgContent)?1:0;
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("Group.InsertGroupLastMsg Exception" + ex.Message);
            }
            return _Flag;
        }
        #endregion
        #region 删除话题回复11406
        /// <summary>
        /// 删除回复11406
        /// </summary>
        /// <param name="topicID">话题ID</param>
        /// <param name="userID">用户ID</param>
        /// <param name="replyID">回复ID</param>
        /// <returns></returns>
        public static int DeleteGroupReply(params object[] para)
        {
            int topicID = (int)para[0];
            int userID = (int)para[1];
            int replyID = (int)para[2];
            int _Result = 0;
            if (topicID > 0 && userID > 0 && replyID > 0)
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _Result = _DAL.DeleteGroupReply(topicID, userID, replyID);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Group.DeleteGroupReply Exception:" + ex.Message);
                }
            }
            return _Result;
        }
        #endregion
        #region 获取圈子的话题回复记录翻页列表11407
        /// <summary>
        /// 获取圈子的话题回复记录翻页列表11407
        /// </summary>
        /// <param name="topicID">话题ID</param>
        /// <param name="FIdx">开始索引</param>
        /// <param name="EIdx">结束索引</param>
        /// <param name="isCount">是否统计</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public static DataSet GetGroupReplyPageList(out int totalCount, params object[] para)
        {
            int topicID = (int)para[0];
            int FIdx = (int)para[1];
            int EIdx = (int)para[2];
            int isCount = (int)para[3];
            DataSet _DS = null;
            totalCount = 0;
            if (topicID > 0)
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupReplyPageList(topicID, FIdx, EIdx, isCount, out totalCount);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Group.GetGroupReplyPageList Exception:" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
        #region 话题-回复11408
        /// <summary>
        /// 话题-回复11408
        /// </summary>
        /// <param name="topicID">话题ID</param>
        /// <param name="userID">用户ID</param>
        /// <param name="userName">用户名</param>
        /// <param name="userWeb">用户标识</param>
        /// <param name="refFloor">楼层</param>
        /// <param name="content">回复内容</param>
        /// <param name="ip">IP</param>
        /// <returns></returns>
        public static int InsertGroupReply(params object[] para)
        {
            int topicID = (int)para[0];
            int userID = (int)para[1];
            string userName = (string)para[2];
            string userWeb = (string)para[3];
            int refFloor = (int)para[4];
            string content = (string)para[5];
            string ip = (string)para[6];
            int _Result = 0;
            if (topicID > 0 && userID > 0)
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _Result = _DAL.InsertGroupReply(topicID, userID, userName, userWeb, refFloor, content, ip);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Group.InsertGroupReply Exception:" + ex.Message);
                }
            }
            return _Result;
        }
        #endregion
        #region 得到某个圈子的信息11409
        /// <summary>
        /// 得到某个圈子的信息11409
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static DataSet GetGroupInfo(params object[] para)
        {
            int groupID = (int)para[0];
            int userID = (int)para[1];
            DataSet _DS = null;
            if (groupID > 0)
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupInfo(groupID, userID);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Group.GetGroupInfo Exception" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
        #region 获取某个用户所加入的圈子11410
        /// <summary>
        /// 获取某个用户所加入的圈子11410
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static DataSet GetGroupsListByUser(params object[] para)
        {
            int userID = (int)para[0];
            DataSet _DS = null;
            if (userID > 0)
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupsListByUser(userID);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Group.GetGroupsListByUser Exception" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
        #region 分页获取圈子列表11411
        /// <summary>
        /// 分页获取圈子列表11411
        /// </summary>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public static DataSet GetGroupsPageList(out int totalCount, params object[] para)
        {
            int FIdx = (int)para[0];
            int EIdx = (int)para[1];
            int isCount = (int)para[2];
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALGroup _DAL = new DALGroup();
                _DS = _DAL.GetGroupsPageList(FIdx, EIdx, isCount, out totalCount);
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("Group.GetGroupsPageList Exception:" + ex.Message);
            }
            return _DS;
        }
        #endregion
        #region 获取某圈子的管理者信息11412
        /// <summary>
        /// 获取某圈子的管理者信息11412
        /// </summary>
        /// <param name="groupID">圈子ID</param>
        /// <returns></returns>
        public static DataSet GetGroupsPageForAdminUserInfo(params object[] para)
        {
            int groupID = (int)para[0];
            DataSet _DS = null;
            if (groupID > 0)
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupsPageForAdminUserInfo(groupID);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Group.GetGroupsPageForAdminUserInfo Exception" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion

        #region 获取圈子话题[推荐、最新、热门]11413
        /// <summary>
        /// 获取圈子话题[推荐、最新、热门]11413
        /// </summary>
        /// <param name="quanlity">获得数量</param>
        /// <param name="topicType">2.热门 0.推荐 1.最新</param>
        /// <returns></returns>
        public static DataSet GetGroupsPageForTopic(params object[] para)
        {
            DataSet _DS = null;
            int _Quanlity = (int)para[0];
            int _TopicType = (int)para[1];
            if (_Quanlity > 0)
            {
                IDALGroup _DAL = new DALGroup();
                _DS = _DAL.GetGroupsPageForTopic(_Quanlity, _TopicType);
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 获取活跃用户11414
        /// <summary>
        /// 获取活跃用户11414
        /// </summary>
        /// <param name="quanlity">获取数量</param>
        /// <returns></returns>
        public static DataSet GetGroupsPageForHotUser(params object[] para)
        {
            int quanlity = (int)para[0];
            DataSet _DS = null;
            if (quanlity > 0)
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupsPageForHotUser(quanlity);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Group.GetGroupsPageForHotUser Exception:" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
        #region 获取最新加入某个圈子的用户11415
        /// <summary>
        /// 获取最新加入某个圈子的用户11415
        /// </summary>
        /// <param name="groupID">圈子ID</param>
        /// <param name="quanlity">获取数量</param>
        /// <returns></returns>
        public static DataSet GetGroupsPageForLastJoinUser(params object[] para)
        {
            int groupID = (int)para[0];
            int quanlity = (int)para[1];
            DataSet _DS = null;
            if (groupID > 0 && quanlity > 0)
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupsPageForLastJoinUser(groupID, quanlity);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Group.GetGroupsPageForLastJoinUser Exception:" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
        #region 获取圈子中用户相关统计信息11416
        /// <summary>
        /// 获取圈子中用户相关统计信息11416
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static DataSet GetGroupsPageForUserTotalInfo(params object[] para)
        {
            int userID = (int)para[0];
            DataSet _DS = null;
            if (userID > 0)
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupsPageForUserTotalInfo(userID);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Group.GetGroupsPageForUserTotalInfo Exception:" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
        #region 修改圈子信息 1成功，0失败11417
        /// <summary>
        /// 修改圈子信息 1成功，0失败11417
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="groupName"></param>
        /// <param name="groupIco"></param>
        /// <param name="groupAbout"></param>
        /// <param name="groupNotice"></param>
        /// <returns></returns>
        public static int UpdateGroupInfo(params object[] para)
        {
            int groupID = (int)para[0];
            string groupName = (string)para[1];
            string groupIco = (string)para[2];
            string groupAbout = (string)para[3];
            string groupNotice = (string)para[4];
            int _Result = -1;
            try
            {
                IDALGroup _DAL = new DALGroup();
                _Result = _DAL.UpdateGroupInfo(groupID, groupName, groupIco, groupAbout, groupNotice, 0);//1是首页推荐
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("Group.UpdateGroupInfo Exception" + ex.Message);
            }
            return _Result;
        }
        #endregion
        #region 屏蔽话题 -1 删除失败; 1 删除成功11418
        /// <summary>
        /// 屏蔽话题 -1 删除失败; 1 删除成功11418
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="userID"></param>
        /// <param name="topicID"></param>
        /// <returns></returns>
        public static int DeleteGroupTopic(params object[] para)
        {
            int groupID = (int)para[0];
            int userID = (int)para[1];
            int topicID = (int)para[2];
            int _Result = 0;
            if (groupID > 0 && userID > 0 && topicID > 0)
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _Result = _DAL.DeleteGroupTopic(groupID, userID, topicID);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Group.DeleteGroupTopic Exception:" + ex.Message);
                }
            }
            return _Result;
        }
        #endregion
        #region 圈子 - 获取所有圈子通告类型的话题列表11419
        /// <summary>
        /// 圈子 - 获取所有圈子通告类型的话题列表11419
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public static DataSet GetGroupTopicGlobalList(params object[] para)
        {
            int groupID = (int)para[0];
            DataSet _DS = null;
            if (groupID > 0)
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupTopicGlobalList(groupID);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Group.GetGroupTopicGlobalList Exception:" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
        #region 获取圈子的(精华)话题翻页列表11420
        /// <summary>
        /// 获取圈子的(精华)话题翻页列表11420
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public static DataSet GetGroupTopicGoodPageList(out int totalCount, params object[] para)
        {
            int groupID = (int)para[0];
            int FIdx = (int)para[1];
            int EIdx = (int)para[2];
            int isCount = (int)para[3];
            DataSet _DS = null;
            totalCount = 0;
            if (groupID > 0)
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupTopicGoodPageList(groupID, FIdx, EIdx, isCount, out  totalCount);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Group.GetGroupTopicGoodPageList Exception:" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
        #region 获取话题信息11421
        /// <summary>
        /// 获取话题信息11421
        /// </summary>
        /// <param name="topicID"></param>
        /// <returns></returns>
        public static DataSet GetGroupTopicInfo(params object[] para)
        {
            int topicID = (int)para[0];
            DataSet _DS = null;
            if (topicID > 0)
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupTopicInfo(topicID);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Group.GetGroupTopicInfo Exception:" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
        #region 获取公告圈子最新发布的话题信息11422
        /// <summary>
        /// 获取公告圈子最新发布的话题信息11422
        /// </summary>
        /// <returns></returns>
        public static DataSet GetGroupTopicNoticeList()
        {
            DataSet _DS = null;
            try
            {
                IDALGroup _DAL = new DALGroup();
                _DS = _DAL.GetGroupTopicNoticeList();
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("Group.GetGroupTopicNoticeList Exception:" + ex.Message);
            }
            return _DS;
        }
        #endregion
        #region 获取公告圈子最新发布的话题信息11423
        /// <summary>
        /// 获取圈子的话题翻页列表11423
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public static DataSet GetGroupTopicPageList(out int totalCount, params object[] para)
        {
            int groupID = (int)para[0];
            int FIdx = (int)para[1];
            int EIdx = (int)para[2];
            int isCount = (int)para[3];
            DataSet _DS = null;
            totalCount = 0;
            if (groupID > 0)
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _DS = _DAL.GetGroupTopicPageList(groupID, FIdx, EIdx, isCount, out  totalCount);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Group.GetGroupTopicPageList Exception:" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
        #region 发表话题 0 失败,1 成功11424
        /// <summary>
        /// 发表话题 0 失败,1 成功11424
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="userID"></param>
        /// <param name="title"></param>
        /// <param name="about"></param>
        /// <param name="content"></param>
        /// <param name="topicImg"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static int InsertGroupTopic(out int topicID, params object[] para)
        {
            int groupID = (int)para[0];
            int userID = (int)para[1];
            string title = (string)para[2];
            string about = (string)para[3];
            string content = (string)para[4];
            string topicImg = (string)para[5];
            string ip = (string)para[6];
            int _Result = 0;
            topicID = 0;
            if (groupID > 0 && userID > 0)
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _Result = _DAL.InsertGroupTopic(groupID, userID, title, about, content, topicImg, ip, out  topicID);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Group.InsertGroupTopic Exception:" + ex.Message);
                }
            }
            return _Result;
        }
        #endregion
        #region 修改话题 0 失败,1 成功11425
        /// <summary>
        /// 修改话题 0 失败,1 成功11425
        /// </summary>
        /// <param name="topicID"></param>
        /// <param name="userID"></param>
        /// <param name="title"></param>
        /// <param name="about"></param>
        /// <param name="content"></param>
        /// <param name="topicImg"></param>
        /// <returns></returns>
        public static int UpdateGroupTopic(params object[] para)
        {
            int topicID = (int)para[0];
            int userID = (int)para[1];
            string title = (string)para[2];
            string about = (string)para[3];
            string content = (string)para[4];
            string topicImg = (string)para[5];
            int _Result = 0;
            if (topicID > 0 && userID > 0)
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _Result = _DAL.UpdateGroupTopic(topicID, userID, title, about, content, topicImg);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Group.UpdateGroupTopic Exception:" + ex.Message);
                }
            }
            return _Result;
        }
        #endregion
        #region 话题-设置精华（1：是，0：否）11426
        /// <summary>
        /// 话题-设置精华（1：是，0：否）11426
        /// </summary>
        /// <param name="topicID"></param>
        /// <param name="isGood"></param>
        /// <returns></returns>
        public static int UpdateGroupTopicGood(params object[] para)
        {
            int topicID = (int)para[0];
            int isGood = (int)para[1];
            int _Result = 0;
            if (topicID > 0 && (isGood == 0 || isGood == 1))
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _Result = _DAL.UpdateGroupTopicGood(topicID, isGood);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Group.UpdateGroupTopicGood Exception:" + ex.Message);
                }
            }
            return _Result;
        }
        #endregion
        #region 话题-更新人气11427
        /// <summary>
        /// 话题-更新人气11427
        /// </summary>
        /// <param name="topicID"></param>
        /// <returns></returns>
        public static int UpdateGroupTopicLookCount(params object[] para)
        {
            int topicID = (int)para[0];
            int _Result = 0;
            if (topicID > 0)
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _Result = _DAL.UpdateGroupTopicLookCount(topicID);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Group.UpdateGroupTopicLookCount Exception:" + ex.Message);
                }
            }
            return _Result;
        }
        #endregion
        #region 退出圈子11429
        /// <summary>
        /// 退出圈子11429
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public static int DeleteGroupUser(params object[] para)
        {
            int userID = (int)para[0];
            int groupID = (int)para[1];
            int _Result =0;
            try
            {
                IDALGroup _DAL = new DALGroup();
                _Result = _DAL.DeleteGroupUser(userID, groupID);
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("Group.DeleteGroupUser Exception" + ex.Message);
            }
            return _Result;
        }
        #endregion
        #region 退出圈子1142901
        /// <summary>
        /// 退出圈子1142901
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public static int DeleteUserGroup(params object[] para)
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            int _GroupID = (int)para[1];
            if (_UserID > 0 && _GroupID > 0)
            {
                IDALGroup _DAL = new DALGroup();
                _Result = _DAL.DeleteUserGroup(_UserID, _GroupID);
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 检测用户是否已加入某圈子11430
        /// <summary>
        /// 检测用户是否已加入某圈子11430
        /// -1: 未加入   1:  已经加入
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public static int CheckGroupUserExists(params object[] para)
        {
            int userID = (int)para[0];
            int groupID = (int)para[1];
            int _Result = -1;
            try
            {
                IDALGroup _DAL = new DALGroup();
                _Result = _DAL.CheckGroupUserExists(userID, groupID);
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("Group.CheckGroupUserExists Exception" + ex.Message);
            }
            return _Result;
        }
        #endregion
        #region 获取圈子中会员的权限值11431
        /// <summary>
        /// 获取圈子中会员的权限值11431
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public static int GetGroupUserPower(params object[] para)
        {
            int userID = (int)para[0];
            int groupID = (int)para[1];
            int _Power = 0;
            if (userID > 0 && groupID > 0)
            {
                try
                {
                    IDALGroup _DAL = new DALGroup();
                    _Power = _DAL.GetGroupUserPower(userID, groupID);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Group.GetGroupUserPower Exception:" + ex.Message);
                }
            }
            return _Power;
        }
        #endregion
        #region 加入某个圈子11432
        /// <summary>
        /// 加入某个圈子11432
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public static int InsertGroupUser(params object[] para)
        {
            int userID = (int)para[0];
            int groupID = (int)para[1];
            int _Result = -1;
            try
            {
                IDALGroup _DAL = new DALGroup();
                _Result = _DAL.InsertGroupUser(userID, groupID);
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("Group.InsertGroupUser Exception" + ex.Message);
            }
            return _Result;
        }
        #endregion
        #region 获取不同标识的圈子列表11434
        /// <summary>
        /// 获取不同标识的圈子列表11434
        /// </summary>
        /// <param name="groupType"></param>
        /// <returns></returns>
        public static DataSet GetGroupsListByGroupType(params object[] para)
        {
            int groupType = (int)para[0];
            DataSet _DS = null;
            try
            {
                IDALGroup _DAL = new DALGroup();
                _DS = _DAL.GetGroupsListByGroupType(groupType);
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("Group.GetGroupsListByGroupType Exception:" + ex.Message);
            }
            return _DS;
        }
        #endregion
        #region 返回首页显示的圈子话题11435
        /// <summary>
        /// 返回首页显示的圈子话题11435
        /// </summary>
        /// <returns></returns>
        public static DataSet GetGroupsTopicForHome()
        {
            DataSet _DS = null;
            try
            {
                IDALGroup _DAL = new DALGroup();
                _DS = _DAL.GetGroupsTopicForHome();
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("Group.GetGroupsTopicForHome Exception:" + ex.Message);
            }
            return _DS;
        }
        #endregion


    }
}
