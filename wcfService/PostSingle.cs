using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class WCFServiceFun
    {
        #region 分页获取晒单列表
        /// <summary>
        /// 分页获取晒单列表
        /// </summary>
        /// <param name="FIdx">开始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="order">排序方式(10最新，20人气，30评论)</param>
        /// <param name="isCount">是否统计总记录数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public DataSet GetPostSinglePageList( int FIdx, int EIdx, int order, int isCount, out int totalCount )
        {
            return GetPostSinglePageListEx( FIdx, EIdx, order, 0, isCount, out totalCount );
        }

        /// <summary>
        /// 分页获取晒单列表
        /// </summary>
        /// <param name="FIdx">开始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="order">排序方式(10最新，20人气，30推荐，40精华)</param>
        /// <param name="sortID">分类ID</param>
        /// <param name="isCount">是否统计总记录数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public DataSet GetPostSinglePageListEx( int FIdx, int EIdx, int order, int sortID, int isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALPostSingle _DAL = new DALPostSingle();
                _DS = _DAL.GetPostSinglePageList( FIdx, EIdx, order, sortID, isCount, out totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "PostSingle.GetPostSinglePageListEx抛出异常：" + ex.Message );
            }
            return _DS;
        }

        /// <summary>
        /// 分页获取晒单列表
        /// </summary>
        /// <param name="FIdx">开始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="order">排序方式(10最新，20人气，30评论)</param>
        /// <param name="isCount">是否统计总记录数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public DataSet mGetPostSinglePageList( int FIdx, int EIdx, int order, int isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALPostSingle _DAL = new DALPostSingle();
                _DS = _DAL.mGetPostSinglePageList( FIdx, EIdx, order, isCount, out totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "PostSingle.mGetPostSinglePageList抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region 获取晒单详情信息
        /// <summary>
        /// 获取晒单详情信息
        /// </summary>
        /// <param name="postID">晒单ID</param>
        /// <returns></returns>
        public DataSet GetPostSingleDetail( int postID )
        {
            DataSet _DS = null;
            if ( postID > 0 )
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _DS = _DAL.GetPostSingleDetail( postID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "PostSingle.GetPostSingleDetail抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 分页查询晒单的所有评论
        /// <summary>
        /// 分页查询晒单的所有评论
        /// </summary>
        /// <param name="postID">晒单id</param>
        /// <param name="FIdx">开始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="replyCount">一级回复数</param>
        /// <param name="hits">点击数</param>
        /// <returns></returns>
        public DataSet GetPostReplyListByID( int postID, int FIdx, int EIdx, int isCount, out int replyCount, out int hits )
        {
            DataSet _DS = null;
            replyCount = 0;
            hits = 0;
            if ( postID > 0 )
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _DS = _DAL.GetPostReplyListByID( postID, FIdx, EIdx, isCount, out replyCount, out hits );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "PostSingle.GetPostReplyGetByID抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 晒单人气+1
        /// <summary>
        /// 晒单人气+1
        /// </summary>
        /// <param name="postID">晒单ID</param>
        /// <param name="IP">IP</param>
        /// <returns></returns>
        public bool InsertPostHits( int postID, long IP )
        {
            bool _Result = false;
            if ( postID > 0 )
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _Result = _DAL.InsertPostHits( postID, IP );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "PostSingle.InsertPostHits抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion

        #region 检测用户回复晒单是否需要验证码
        /// <summary>
        /// 检测用户回复晒单是否需要验证码
        /// </summary>
        /// <param name="userID">会员id</param>
        /// <returns></returns>
        public bool GetPostReplyConfigCheck( int userID )
        {
            bool _Result = false;
            if ( userID > 0 )
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _Result = _DAL.GetPostReplyConfigCheck( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "PostSingle.GetPostReplyConfigCheck抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion

        #region 会员对某一晒单添加评论
        /// <summary>
        /// 会员对某一晒单添加评论
        /// </summary>
        /// <param name="postID">晒单id</param>
        /// <param name="userID">用户id</param>
        /// <param name="refContent">引用内容</param>
        /// <param name="content">评论内容</param>
        /// <param name="IP">IP</param>
        /// <param name="userName">评论人姓名</param>
        /// <param name="originalContent">评论的原始内容</param>
        /// <param name="replyRefUserName">评论的引用者姓名</param>
        /// <param name="refReplyID">引用的评论ID</param>
        /// <param name="refFloor">引用的楼层</param>
        /// <returns>返回：1成功；0失败；-1回复评论同一人</returns>
        public int InsertPostReply( int postID, int userID, string content, string IP, string userName,
            string originalContent, string replyRefUserName, int refReplyID, int refFloor )
        {
            int _Result = 0;
            if ( postID > 0 && userID > 0 )
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _Result = _DAL.InsertPostReply( postID, userID, content, IP, userName, originalContent, replyRefUserName, refReplyID, refFloor );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "PostSingle.InsertPostReply抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion

        #region 分页获取商品详细页的晒单列表记录
        /// <summary>
        /// 分页获取商品详细页的晒单列表记录
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="FIdx">起始索引</param>
        /// <param name="EIdx">结束索引</param>
        /// <param name="isCount">是否统计总数</param>
        /// <returns>表1为统计数据，表2为记录</returns>
        public DataSet mGetPageForGoodsPostSingle( int goodsID, int FIdx, int EIdx, int isCount )
        {
            DataSet _DS = null;
            if ( goodsID > 0 )
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _DS = _DAL.mGetPageForGoodsPostSingle( goodsID, FIdx, EIdx, isCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "PostSingle.mGetPageForGoodsPostSingle抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 个人主页获取会员晒单
        /// <summary>
        /// 个人主页获取会员晒单
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public DataSet GetUserWebPagePostList( int userID, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _DS = _DAL.GetUserWebPagePostList( userID, FIdx, EIdx, isCount, out totalCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "PostSingle.GetUserWebPagePostList抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 手机版个人主页获取会员晒单
        /// <summary>
        /// 手机版个人主页获取会员晒单
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public DataSet mGetUserWebPagePostList( int userID, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _DS = _DAL.mGetUserWebPagePostList( userID, FIdx, EIdx, UtilityFun.ToDateTime( "2010-01-01" ), DateTime.Now, isCount, out totalCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "PostSingle.mGetUserWebPagePostList抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 会员中心-我的已晒单分页列表
        /// <summary>
        /// 会员中心-我的已晒单分页列表
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="userid">会员ID</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="postCount">已晒单总记录数</param>
        /// <param name="unPostCount">未晒单总记录数</param>
        /// <returns></returns>
        public DataSet GetMemberCenterForUserPostSingle( int FIdx, int EIdx, int userID, int isCount, out int postCount, out int unPostCount )
        {
            DataSet _DS = null;
            postCount = 0;
            unPostCount = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    //2015.11.30 屏蔽
                    //_DS = _DAL.GetMemberCenterForUserPostSingle( FIdx, EIdx, userID, isCount, out postCount, out unPostCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "PostSingle.GetMemberCenterUserPostSingle抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 会员中心 - 会员未晒单列表
        /// <summary>
        /// 会员中心 - 会员未晒单列表
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="userID">会员ID</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">未晒单总记录数</param>
        /// <returns></returns>
        public DataSet GetMemberCenterForUserUnPostSingle( int FIdx, int EIdx, int userID, int isCount, out int count )
        {
            DataSet _DS = null;
            count = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    //2015.11.30 屏蔽
                    //_DS = _DAL.GetMemberCenterForUserUnPostSingle( FIdx, EIdx, userID, isCount, out count );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "PostSingle.GetMemberCenterForUserUnPostSingle抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 添加晒单信息
        /// <summary>
        /// 添加晒单信息
        /// </summary>
        /// <param name="codeID">晒单对应的商品条码ID</param>
        /// <param name="userID">用户ID</param>
        /// <param name="postTitle">晒单标题</param>
        /// <param name="postContent">晒单内容</param>
        /// <param name="postAllPic">晒单图片</param>
        /// <param name="postTime">晒单时间</param>
        /// <returns></returns>
        public int InsertPostSingle( int codeID, int userID, string postTitle, string postContent, string postAllPic, DateTime postTime )
        {
            int _Result = 0;
            if ( codeID > 0 && userID > 0 )
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _Result = _DAL.InsertPostSingle( codeID, userID, postTitle, postContent, postAllPic, postTime );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "PostSingle.InsertPostSingle抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion

        #region 分页获取商品详细页的晒单列表记录[商品页调用]
        /// <summary>
        /// 分页获取商品详细页的晒单列表记录
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="isCount">是否统计总数</param>
        /// <returns>第一张表(晒单数，回复数)；第二张晒单记录</returns>
        public DataSet GetPageForGoodsPostSingle( int goodsID, int FIdx, int EIdx, int isCount )
        {
            DataSet _DS = null;
            if ( goodsID > 0 )
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _DS = _DAL.GetPageForGoodsPostSingle( goodsID, FIdx, EIdx, isCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "PostSingle.GetPageForGoodsPostSingle抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 检查是否可以晒单
        /// <summary>
        /// 检查是否可以晒单
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="codeID">商品条码</param>
        /// <returns></returns>
        public bool CheckPostSingleByID( int userID, int codeID )
        {
            bool _Result = false;
            if ( userID > 0 && codeID > 0 )
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _Result = _DAL.CheckPostSingleByID( userID, codeID ) > 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "PostSingle.GetCheckPostSingle抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion

        #region 获取晒单详情
        /// <summary>
        /// 获取晒单详情
        /// </summary>
        /// <param name="postID">晒单ID号</param>
        /// <param name="userID">发布的会员ID号</param>
        /// <returns></returns>
        public DataSet GetMemberCenterUserPostSingleDetail( int postID, int userID )
        {
            DataSet _DS = null;
            if ( postID > 0 && userID > 0 )
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _DS = _DAL.GetMemberCenterUserPostSingleDetail( postID, userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "PostSingle.GetMemberCenterUserPostSingleDetail抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 修改晒单信息
        /// <summary>
        /// 修改晒单信息
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="postID">晒单ID</param>
        /// <param name="postTitle">标题</param>
        /// <param name="postContent">内容</param>
        /// <param name="postAllPic">晒单图片</param>
        /// <param name="postState">晒单状态</param>
        /// <param name="postTime">晒单时间</param>
        /// <returns></returns>
        public int UpdatePostSingle( int userID, int postID, string postTitle, string postContent, string postAllPic, int postState, DateTime postTime )
        {
            int _Result = -1;
            try
            {
                IDALPostSingle _DAL = new DALPostSingle();
                _Result = _DAL.UpdatePostSingle( userID, postID, postTitle, postContent, postAllPic, postState, postTime );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "PostSingle.UpdatePostSingle抛出异常：" + ex.Message );
            }
            return _Result;
        }
        #endregion

        #region 分页查询往期获得者
        /// <summary>
        /// 晒单详细页右侧显示往期获得者
        /// </summary>
        /// <param name="FIdx">开始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="codeID">codeID</param>
        /// <param name="isCount">是否返回总数</param>
        /// <param name="totalCount">总数</param>
        /// <returns></returns>
        public DataSet GetPostSingleOldPeriodList( int FIdx, int EIdx, int codeID, int isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            if ( codeID > 0 )
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _DS = _DAL.GetPostSingleOldPeriodList( FIdx, EIdx, codeID, isCount, out totalCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "PostSingle.GetPostSingleOldPeriodList抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 查询最新晒单指定数量列表
        /// <summary>
        /// 晒单详请右侧查询最新晒单列表
        /// </summary>
        /// <param name="Quantity">查询的数量</param>
        /// <returns></returns>
        public DataSet GetListNewPostSingleTopList( int Quantity )
        {
            DataSet _DS = null;
            if ( Quantity > 0 )
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _DS = _DAL.GetListNewPostSingleTopList( Quantity );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "PostSingle.GetListNewPostSingleTopList抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 读取评论的5条回复数据
        /// <summary>
        /// 读取评论的5条回复数据
        /// </summary>
        /// <param name="replyId"></param>
        /// <returns></returns>
        public DataSet GetPostReplyInfo( int replyId )
        {
            DataSet _DS = null;
            if ( replyId > 0 )
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _DS = _DAL.GetPostReplyInfo( replyId );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "PostSingle.GetPostReplyInfo抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 删除回复(修改回复信息状态)
        /// <summary>
        /// 删除回复(修改回复信息状态)
        /// </summary>
        /// <param name="replyId">主键</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public int SetPostReplyHide( int replyId, int userId )
        {
            int _Result = -1;
            if ( replyId > 0 )
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _Result = _DAL.SetPostReplyHide( replyId, userId );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "PostSingle.SetPostReplyHide抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion

        #region 进行获取用户的晒单信息列表，用于前台显示
        /// <summary>
        /// 进行获取用户的晒单信息列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetPostSingleShow()
        {
            DataSet _DS = null;
            try
            {
                IDALPostSingle _DAL = new DALPostSingle();
                _DS = _DAL.GetPostSingleShow();
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "PostSingle.GetPostSingleShow Exception:" + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region 查询晒单的基本字段信息
        /// <summary>
        /// 查询晒单的基本字段信息
        /// </summary>
        /// <param name="postID">晒单ID号</param>
        /// <returns></returns>
        public DataSet GetPostSingleBaseInfo( int postID )
        {
            DataSet _DS = null;
            if ( postID > 0 )
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _DS = _DAL.GetPostSingleBaseInfo( postID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "PostSingle.GetPostSingleBaseInfo Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 获取最新晒单回复
        /// <summary>
        /// 获取最新晒单回复
        /// </summary>
        /// <param name="quantity">获取数目</param>
        /// <param name="lastReplyID">最后的回复ID</param>
        /// <returns></returns>
        public DataSet GetPostReplyLastest( int quantity, int lastReplyID )
        {
            DataSet _DS = null;
            if ( quantity > 0 && lastReplyID >= 0 )
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _DS = _DAL.GetPostReplyLastest( quantity, lastReplyID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "PostSingle.GetPostReplyLastest Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 获取首页推荐的晒单
        /// <summary>
        /// 获取首页推荐的晒单
        /// </summary>
        /// <returns></returns>
        public DataSet GetPostSingleForHomeRecommend()
        {
            DataSet _DS = null;
            try
            {
                IDALPostSingle _DAL = new DALPostSingle();
                _DS = _DAL.GetPostSingleForHomeRecommend();
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "PostSingle.GetPostSingleForHomeRecommend Exception:" + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region 插入晒单详情阅读量（+1）
        /// <summary>
        /// 添加晒单阅读量
        /// </summary>
        /// <param name="postID">晒单ID</param>
        /// <returns></returns>
        public int InsertPostsingleReadCount( int postID )
        {
            int _Result = -3;
            if ( postID > 0 )
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _Result = _DAL.InsertPostsingleReadCount( postID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "PostSingle.InsertPostsingleReadCount Exception:" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion

        #region 会员中心-获取晒单列表（整合未晒与已晒）
        /// <summary>
        /// 会员中心-获取晒单列表（整合未晒与已晒）
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="state">晒单状态 0.全部 1.已经晒单 2.未晒单 3.待审核 4.未通过 5.已通过</param>
        /// <param name="isStat">是否需要统计 1.需要统计 0.表示不需要</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总记录数</param>
        /// <param name="totalCount">返回总记录数</param>
        /// <returns></returns>
        public DataSet GetMemberCenterPostListByUserID( int userID, int state, int isStat, DateTime beginTime, DateTime endTime, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALPostSingle _DAL = new DALPostSingle();
                _DS = _DAL.GetMemberCenterPostListByUserID( userID, state, isStat, beginTime, endTime, FIdx, EIdx, isCount, out totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "PostSingle.GetMemberCenterPostListByUserID Exception:" + ex.Message );
            }
            return _DS;
        }
        #endregion
    }
}
