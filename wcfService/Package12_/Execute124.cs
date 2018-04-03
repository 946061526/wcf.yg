using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class ExecuteFun
    {
        #region 晒单人气+1 12401
        /// <summary>
        /// 晒单人气+1 12401
        /// </summary>
        /// <param name="postID">晒单ID</param>
        /// <param name="IP">IP</param>
        /// <returns></returns>
        public static int InsertPostHits(params object[] para)
        {
            int postID = (int)para[0];
            long IP = (long)para[1];
            int _Result = 0;
            if (postID > 0)
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _Result = _DAL.InsertPostHits(postID, IP)?1:0;
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("PostSingle.InsertPostHits抛出异常：" + ex.Message);
                }
            }
            return _Result;
        }
        #endregion
        #region 检测用户回复晒单是否需要验证码12402
        /// <summary>
        /// 检测用户回复晒单是否需要验证码12402
        /// </summary>
        /// <param name="userID">会员id</param>
        /// <returns></returns>
        public static int GetPostReplyConfigCheck(params object[] para)
        {
            int userID = (int)para[0];
            int _Result = 0;
            if (userID > 0)
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _Result = _DAL.GetPostReplyConfigCheck(userID)?1:0;
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("PostSingle.GetPostReplyConfigCheck抛出异常：" + ex.Message);
                }
            }
            return _Result;
        }
        #endregion
        #region 分页查询晒单的所有评论12404
        /// <summary>
        /// 分页查询晒单的所有评论12404
        /// </summary>
        /// <param name="postID">晒单id</param>
        /// <param name="FIdx">开始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="replyCount">一级回复数</param>
        /// <param name="hits">点击数</param>
        /// <returns></returns>
        public static DataSet GetPostReplyListByID(out int replyCount, out int hits, params object[] para)
        {
            int postID = (int)para[0];
            int FIdx = (int)para[1];
            int EIdx = (int)para[2];
            int isCount = (int)para[3];
            DataSet _DS = null;
            replyCount = 0;
            hits = 0;
            if (postID > 0)
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _DS = _DAL.GetPostReplyListByID(postID, FIdx, EIdx, isCount, out replyCount, out hits);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("PostSingle.GetPostReplyGetByID抛出异常：" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
        #region 读取评论的5条回复数据12406
        /// <summary>
        /// 读取评论的5条回复数据12406
        /// </summary>
        /// <param name="replyId"></param>
        /// <returns></returns>
        public static DataSet GetPostReplyInfo(params object[] para)
        {
            int replyId = (int)para[0];
            DataSet _DS = null;
            if (replyId > 0)
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _DS = _DAL.GetPostReplyInfo(replyId);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("PostSingle.GetPostReplyInfo抛出异常：" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
        #region 会员对某一晒单添加评论12407
        /// <summary>
        /// 会员对某一晒单添加评论12407
        /// </summary>
        /// <param name="postID">晒单id</param>
        /// <param name="userID">用户id</param>
        /// <param name="content">评论内容</param>
        /// <param name="IP">IP</param>
        /// <param name="userName">评论人姓名</param>
        /// <param name="originalContent">评论的原始内容</param>
        /// <param name="replyRefUserName">评论的引用者姓名</param>
        /// <param name="refReplyID">引用的评论ID</param>
        /// <param name="refFloor">引用的楼层</param>
        /// <returns>返回：1成功；0失败；-1回复评论同一人</returns>
        public static int InsertPostReply(params object[] para)
        {
            int postID = (int)para[0];
            int userID = (int)para[1];
            string content = (string)para[2];
            string IP = (string)para[3];
            string userName = (string)para[4];
            string originalContent = (string)para[5];
            string replyRefUserName = (string)para[6];
            int refReplyID = (int)para[7];
            int refFloor = (int)para[8];
            int _Result = 0;
            if (postID > 0 && userID > 0)
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _Result = _DAL.InsertPostReply(postID, userID, content, IP, userName, originalContent, replyRefUserName, refReplyID, refFloor);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("PostSingle.InsertPostReply抛出异常：" + ex.Message);
                }
            }
            return _Result;
        }
        #endregion
        #region 删除回复(修改回复信息状态)12408
        /// <summary>
        /// 删除回复(修改回复信息状态)12408
        /// </summary>
        /// <param name="replyId">主键</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public static int SetPostReplyHide(params object[] para)
        {
            int replyId = (int)para[0];
            int userId = (int)para[1];
            int _Result = -1;
            if (replyId > 0)
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _Result = _DAL.SetPostReplyHide(replyId, userId);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("PostSingle.SetPostReplyHide抛出异常：" + ex.Message);
                }
            }
            return _Result;
        }
        #endregion
        #region 检查是否可以晒单12409
        /// <summary>
        /// 检查是否可以晒单12409
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="codeID">商品条码</param>
        /// <returns></returns>
        public static int CheckPostSingleByID(params object[] para)
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            int _CodeID = (int)para[1];
            if (_UserID > 0 && _CodeID > 0)
            {
                IDALPostSingle _DAL = new DALPostSingle();
                _Result = _DAL.CheckPostSingleByID(_UserID, _CodeID);
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 获取晒单详情信息12410
        /// <summary>
        /// 获取晒单详情信息12410
        /// </summary>
        /// <param name="postID">晒单ID</param>
        /// <returns></returns>
        public static DataSet GetPostSingleDetail(params object[] para)
        {
            int postID = (int)para[0];
            DataSet _DS = null;
            if (postID > 0)
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _DS = _DAL.GetPostSingleDetail(postID);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("PostSingle.GetPostSingleDetail抛出异常：" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
        #region 晒单详细页右侧显示往期获得者12411
        /// <summary>
        /// 晒单详细页右侧显示往期获得者12411
        /// </summary>
        /// <param name="FIdx">开始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="codeID">codeID</param>
        /// <param name="isCount">是否返回总数</param>
        /// <param name="totalCount">总数</param>
        /// <returns></returns>
        public static DataSet GetPostSingleOldPeriodList(out int totalCount, params object[] para)
        {
            int FIdx = (int)para[0];
            int EIdx = (int)para[1];
            int codeID = (int)para[2];
            int isCount = (int)para[3];
            DataSet _DS = null;
            totalCount = 0;
            if (codeID > 0)
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _DS = _DAL.GetPostSingleOldPeriodList(FIdx, EIdx, codeID, isCount, out totalCount);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("PostSingle.GetPostSingleOldPeriodList抛出异常：" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
        #region 查询晒单的基本字段信息12414
        /// <summary>
        /// 查询晒单的基本字段信息12414
        /// </summary>
        /// <param name="postID">晒单ID号</param>
        /// <returns></returns>
        public static DataSet GetPostSingleBaseInfo(params object[] para)
        {
            DataSet _DS = null;
            int _PostID = (int)para[0];
            if (_PostID > 0)
            {
                IDALPostSingle _DAL = new DALPostSingle();
                _DS = _DAL.GetPostSingleBaseInfo(_PostID);
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 添加晒单信息12416
        /// <summary>
        /// 添加晒单信息12416
        /// </summary>
        /// <param name="codeID">晒单对应的商品条码ID</param>
        /// <param name="userID">用户ID</param>
        /// <param name="postTitle">晒单标题</param>
        /// <param name="postContent">晒单内容</param>
        /// <param name="postAllPic">晒单图片</param>
        /// <param name="postTime">晒单时间</param>
        /// <returns></returns>
        public static int InsertPostSingle(params object[] para)
        {
            int _Result = 0;
            int _CodeID = (int)para[0];
            int _UserID = (int)para[1];
            string _PostTitle = (string)para[2];
            string _PostContent = (string)para[3];
            string _PostAllPic = (string)para[4];
            DateTime _PostTime = (DateTime)para[5];
            if (_CodeID > 0 && _UserID > 0)
            {
                IDALPostSingle _DAL = new DALPostSingle();
                _Result = _DAL.InsertPostSingle(_CodeID, _UserID, _PostTitle, _PostContent, _PostAllPic, _PostTime);
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 查询最新晒单指定数量列表12417
        /// <summary>
        /// 晒单详请右侧查询最新晒单列表12417
        /// </summary>
        /// <param name="Quantity">查询的数量</param>
        /// <returns></returns>
        public static DataSet GetListNewPostSingleTopList(params object[] para)
        {
            int Quantity = (int)para[0];
            DataSet _DS = null;
            if (Quantity > 0)
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _DS = _DAL.GetListNewPostSingleTopList(Quantity);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("PostSingle.GetListNewPostSingleTopList抛出异常：" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
        #region 分页获取晒单列表12419
        /// <summary>
        /// 分页获取晒单列表12419
        /// </summary>
        /// <param name="FIdx">开始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="order">排序方式(10最新，20人气，30评论)</param>
        /// <param name="isCount">是否统计总记录数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public static DataSet GetPostSinglePageList(out int totalCount, params object[] para)
        {
            return GetPostSinglePageListEx(out totalCount, new object[] { para[0], para[1],para[2],0,para[3] });
        }
        #endregion
        #region 分页获取晒单列表1241901
        /// <summary>
        /// 分页获取晒单列表1241901
        /// </summary>
        /// <param name="FIdx">开始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="order">排序方式(10最新，20人气，30推荐，40精华)</param>
        /// <param name="sortID">分类ID</param>
        /// <param name="isCount">是否统计总记录数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public static DataSet GetPostSinglePageListEx(out int totalCount, params object[] para)
        {
            int FIdx = (int)para[0];
            int EIdx = (int)para[1];
            int order = (int)para[2];
            int sortID = (int)para[3];
            int isCount = (int)para[4];
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALPostSingle _DAL = new DALPostSingle();
                _DS = _DAL.GetPostSinglePageList(FIdx, EIdx, order, sortID, isCount, out totalCount);
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("PostSingle.GetPostSinglePageListEx抛出异常：" + ex.Message);
            }
            return _DS;
        }
        #endregion
        #region 修改晒单信息12420
        /// <summary>
        /// 修改晒单信息12420
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="postID">晒单ID</param>
        /// <param name="postTitle">标题</param>
        /// <param name="postContent">内容</param>
        /// <param name="postAllPic">晒单图片</param>
        /// <param name="postState">晒单状态</param>
        /// <param name="postTime">晒单时间</param>
        /// <returns></returns>
        public static int UpdatePostSingle(params object[] para)
        {
            int _Result = -1;
            int _UserID = (int)para[0];
            int _PostID = (int)para[1];
            string _PostTitle = (string)para[2];
            string _PostContent = (string)para[3];
            string _PostAllPic = (string)para[4];
            int _PostState = (int)para[5];
            DateTime _PostTime = (DateTime)para[6];
            IDALPostSingle _DAL = new DALPostSingle();
            _Result = _DAL.UpdatePostSingle(_UserID, _PostID, _PostTitle, _PostContent, _PostAllPic, _PostState, _PostTime);
            _DAL = null;
            return _Result;
        }
        #endregion
        #region 进行获取用户的晒单信息列表，用于前台显示12422
        /// <summary>
        /// 进行获取用户的晒单信息列表12422
        /// </summary>
        /// <returns></returns>
        public static DataSet GetPostSingleShow()
        {
            DataSet _DS = null;
            try
            {
                IDALPostSingle _DAL = new DALPostSingle();
                _DS = _DAL.GetPostSingleShow();
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("PostSingle.GetPostSingleShow Exception:" + ex.Message);
            }
            return _DS;
        }
        #endregion
        #region 获取最新晒单回复12423
        /// <summary>
        /// 获取最新晒单回复12423
        /// </summary>
        /// <param name="quantity">获取数目</param>
        /// <param name="lastReplyID">最后的回复ID</param>
        /// <returns></returns>
        public static DataSet GetPostReplyLastest(params object[] para)
        {
            int quantity = (int)para[0];
            int lastReplyID = (int)para[1];
            DataSet _DS = null;
            if (quantity > 0 && lastReplyID >= 0)
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _DS = _DAL.GetPostReplyLastest(quantity, lastReplyID);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("PostSingle.GetPostReplyLastest Exception:" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
        #region 获取首页推荐的晒单12424
        /// <summary>
        /// 获取首页推荐的晒单12424
        /// </summary>
        /// <returns></returns>
        public static DataSet GetPostSingleForHomeRecommend()
        {
            DataSet _DS = null;
            try
            {
                IDALPostSingle _DAL = new DALPostSingle();
                _DS = _DAL.GetPostSingleForHomeRecommend();
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("PostSingle.GetPostSingleForHomeRecommend Exception:" + ex.Message);
            }
            return _DS;
        }
        #endregion
        #region 插入晒单详情阅读量（+1）12425
        /// <summary>
        /// 添加晒单阅读量12425
        /// </summary>
        /// <param name="postID">晒单ID</param>
        /// <returns></returns>
        public static int InsertPostsingleReadCount(params object[] para)
        {
            int postID = (int)para[0];
            int _Result = -3;
            if (postID > 0)
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _Result = _DAL.InsertPostsingleReadCount(postID);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("PostSingle.InsertPostsingleReadCount Exception:" + ex.Message);
                }
            }
            return _Result;
        }
        #endregion
        #region APP获取某云商品晒单信息12430
        /// <summary>
        /// APP获取某云商品晒单信息12430
        /// </summary>
        /// <param name="codeID"></param>
        /// <returns></returns>
        public static DataSet GetPostSingleByCodeID( params object[] para )
        {
            int codeID = (int)para[0];
            DataSet _DS = null;
            if ( codeID > 0 )
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _DS = _DAL.GetPostSingleByCodeID( codeID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "PostSingle.GetPostSingleByCodeID Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
    }
}
