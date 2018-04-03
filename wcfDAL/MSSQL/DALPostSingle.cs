using System;
using System.Data;

namespace wcfNSYGShop
{
    public class DALPostSingle : DALBase, IDALPostSingle
    {
        #region 分页获取晒单列表
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
        public DataSet GetPostSinglePageList( int FIdx, int EIdx, int order, int sortID, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12419" );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_Sort", order );
            Para.AddOrcNewInParameter( "i_kind", sortID );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result_pt" );//晒单总数
            Para.AddOrcNewCursorParameter( "o_result" );//分类晒单总数
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_PostSingle.sp_getPostSingePageBySort" );//pro_PostSinglePageList
            totalCount = 0;
            if ( _DS != null && _DS.Tables.Count == 2 && _DS.Tables[0].Rows.Count > 0 )
            {
                totalCount = ToInt32( _DS.Tables[0].Rows[0][0] );
                _DS.Tables.RemoveAt( 0 );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11806" );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewInParameter( "i_sort", order );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MPageForPhone.sp_getPostSinglePage" );//pro_mPostSinglePageList
            totalCount = GetOrcTotalCount( isCount, _DS );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12410" );
            Para.AddOrcNewInParameter( "i_PostID", postID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PostSingle.sp_getPostSingleByPostID" );//pro_PostSingleDetail
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

            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12404" );
            Para.AddOrcNewInParameter( "i_postID", postID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result_hit" );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DSTmp = Dal.ExecuteFillDataSet( "yun_PostSingle.sp_getReplyOfPostByPostID" );//pro_PostReplyGetListByID
            if ( _DSTmp != null && _DSTmp.Tables.Count == 2 && _DSTmp.Tables[0].Rows.Count > 0 )
            {
                hits = ToInt32( _DSTmp.Tables[0].Rows[0][0] );

                _DS = new DataSet();
                _DS.Tables.Add( _DSTmp.Tables[1].Copy() );
                replyCount = GetOrcTotalCount( isCount, _DS );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12401" );
            Para.AddOrcNewInParameter( "i_postID", postID );
            Para.AddOrcNewInParameter( "i_ip", IP );
            Dal.ExecuteNonQuery( "yun_PostSingle.f_addPostHitByPostID" );//pro_PostHitsInsert
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal > 0;
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
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12402" );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Dal.ExecuteNonQuery( "yun_PostSingle.f_chkIsReplyByUserID" );//pro_PostReplyConfigCheck
            return ToInt32( Para.GetOrcParameter( "retVal" ) ) < 1;//1该用户可以回复  0异常  -1该用户不可以回复
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
        /// <returns>返回：1成功 0异常 -1失败,回复评论同一人 -2失败,回复中有敏感词 -3发送频率超标 -4发送量超标 -5账号不正常</returns>
        public int InsertPostReply( int postID, int userID, string content, string IP, string userName,
            string originalContent, string replyRefUserName, int refReplyID, int refFloor )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12407" );
            Para.AddOrcNewInParameter( "i_postID", postID );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_userName", userName );
            Para.AddOrcNewInParameter( "i_refReplyID", refReplyID );
            Para.AddOrcNewInParameter( "i_refFloor", refFloor );
            Para.AddOrcNewInParameter( "i_refUserName", replyRefUserName );
            Para.AddOrcNewInParameter( "i_content", content );
            Para.AddOrcNewInParameter( "i_ip", IP );
            Para.AddOrcNewInParameter( "i_originalContent", originalContent );
            Dal.ExecuteNonQuery( "yun_PostSingle.f_addPostReply" );//pro_PostReplyInsert
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12209" );
            Para.AddOrcNewInParameter( "i_GoodsID", goodsID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result1" );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getPostSingleByGoodsID" );//pro_PageForGoodsPostSingle
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13008" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_iscount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_UserWeb.sp_getPostSingleByUserID" );//pro_UserWebPageForUserPostSingle
            totalCount = GetOrcTotalCount( isCount, _DS );
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
        public DataSet mGetUserWebPagePostList( int userID, int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11808" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_startTime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MPageForPhone.sp_getPostRecordeHome" );//pro_mUserWebPageForUserPostSingle
            totalCount = GetOrcTotalCount( isCount, _DS );
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
        public DataSet GetMemberCenterForUserPostSingle( int FIdx, int EIdx, int userID, DateTime beginTime, DateTime endTime, int isCount, out int postCount, out int unPostCount )
        {
            DataSet _DS = null;
            postCount = 0;
            unPostCount = 0;

            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11734" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_startTime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            Para.AddOrcNewCursorParameter( "o_result_post" );
            DataSet _DSTmp = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getPostSingleByUserid" );//Pro_MemberCenterForUserPostSingle
            if ( _DSTmp != null && _DSTmp.Tables.Count == 2 && _DSTmp.Tables[1].Rows.Count > 0 )
            {
                unPostCount = ToInt32( _DSTmp.Tables[1].Rows[0][0] );

                _DS = new DataSet();
                _DS.Tables.Add( _DSTmp.Tables[0].Copy() );
                postCount = GetOrcTotalCount( isCount, _DS );
            }
            _DSTmp = null;
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
        public DataSet GetMemberCenterForUserUnPostSingle( int FIdx, int EIdx, int userID, DateTime beginTime, DateTime endTime, int isCount, out int count )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11741" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_startTime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getUserNotPostByUserid" );//pro_MemberCenterForUserUnPostSingle
            count = GetOrcTotalCount( isCount, _DS );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12416" );
            Para.AddOrcNewInParameter( "i_postCodeID", codeID );
            Para.AddOrcNewInParameter( "i_postUserID", userID );
            Para.AddOrcNewInParameter( "i_postTitle", postTitle );
            Para.AddOrcNewInParameter( "i_postContent", postContent );
            Para.AddOrcNewInParameter( "i_postAllPic", postAllPic );
            Para.AddOrcNewInParameter( "i_postTime", postTime );
            Dal.ExecuteNonQuery( "yun_PostSingle.f_addPostSingle" );//pro_PostSingleInsert
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal; //成功则返回postID
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12209" );
            Para.AddOrcNewInParameter( "i_GoodsID", goodsID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result1" );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getPostSingleByGoodsID" );//pro_PageForGoodsPostSingle
        }
        #endregion

        #region 检查是否可以晒单
        /// <summary>
        /// 检查是否可以晒单
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="codeID">商品条码</param>
        /// <returns></returns>
        public int CheckPostSingleByID( int userID, int codeID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12409" );
            Para.AddOrcNewInParameter( "i_codeID", codeID );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Dal.ExecuteNonQuery( "yun_PostSingle.f_chkIsPostByUserID" );//pro_PostSingleCheck
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            return _RetVal;
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11735" );
            Para.AddOrcNewInParameter( "i_postid", postID );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getPostDetailByPostid" );//pro_MemberCenterForUserPostSingleDetail
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
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12420" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_postID", postID );
            Para.AddOrcNewInParameter( "i_postTitle", postTitle );
            Para.AddOrcNewInParameter( "i_postContent", postContent );
            Para.AddOrcNewInParameter( "i_postAllPic", postAllPic );
            Para.AddOrcNewInParameter( "i_postState", postState );
            Para.AddOrcNewInParameter( "i_postTime", postTime );
            Dal.ExecuteNonQuery( "yun_PostSingle.f_modPostSingleByUserID" );//pro_PostSingleUpdate
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;//0成功，1已审核，-1失败
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12411" );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_codeID", codeID );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_PostSingle.sp_getOldPeriodListByCodeID" );//pro_PostSingleDetailOldPeriodList
            totalCount = GetOrcTotalCount( isCount, _DS );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12417" );
            Para.AddOrcNewInParameter( "i_quantity", Quantity );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PostSingle.sp_getRightRecentPost" );//pro_PostSingleListForDetail
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12406" );
            Para.AddOrcNewInParameter( "i_ReplyID", replyId );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PostSingle.sp_getTopReplyInfoByReplyID" );//pro_PostReplyGetReplyTopInfo
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
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12408" );
            Para.AddOrcNewInParameter( "i_replyID", replyId );
            Para.AddOrcNewInParameter( "i_userid", userId );
            Dal.ExecuteNonQuery( "yun_PostSingle.f_addReplyHideByReplyID" );//pro_PostReplySetHide
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 进行获取用户的晒单信息列表，用于前台显示
        /// <summary>
        /// 进行获取用户的晒单信息列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetPostSingleShow()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12422" );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PostSingle.sp_getHomePostSingle" );//pro_GetPostSingleForIndexPage
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12414" );
            Para.AddOrcNewInParameter( "i_postid", postID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PostSingle.sp_getSomePostByPostID" );//pro_PostSingleGetInfoByPostID
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12423" );
            Para.AddOrcNewInParameter( "i_quantity", quantity );
            Para.AddOrcNewInParameter( "i_lastReplyID", lastReplyID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PostSingle.sp_getNewPostSingle" );//pro_PostReplyGetLastest
        }
        #endregion

        #region 获取首页推荐的晒单
        /// <summary>
        /// 获取首页推荐的晒单
        /// </summary>
        /// <returns></returns>
        public DataSet GetPostSingleForHomeRecommend()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12424" );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PostSingle.sp_getRecommendPostSingle" );//pro_PostSingleForHomeRecommend
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12425" );
            Para.AddOrcNewInParameter( "i_postID", postID );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_PostSingle.f_modtReadCountkByPostID" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11760" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_state", state );
            Para.AddOrcNewInParameter( "i_isStat", isStat );
            Para.AddOrcNewInParameter( "i_startTime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result_list" );
            Para.AddOrcNewCursorParameter( "o_result_stat" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getPostListByUserid" );
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion

        #region APP获取某云商品晒单信息
        /// <summary>
        /// APP获取某云商品晒单信息
        /// </summary>
        /// <param name="codeID"></param>
        /// <returns></returns>
        public DataSet GetPostSingleByCodeID( int codeID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12430" );
            Para.AddOrcNewInParameter( "i_CodeID", codeID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PostSingle.sp_getPostSingleByCodeID" );
        }
        #endregion

        #region app会员中心-获取晒单列表（整合未晒与已晒）10317
        /// <summary>
        /// app会员中心-获取晒单列表（整合未晒与已晒）10317
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="state">晒单状态 0.全部 1.已经晒单 2.未晒单 3.待审核 4.未通过 5.已通过</param>
        /// <param name="isStat">是否需要统计 1.需要统计 0.表示不需要</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总记录数</param>
        /// <param name="totalCount">返回总记录数</param>
        /// <returns></returns>
        public DataSet appGetMemberCenterPostListByUserID( int userID, int state, int isStat, DateTime beginTime, DateTime endTime, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10317" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_state", state );
            Para.AddOrcNewInParameter( "i_isStat", isStat );
            Para.AddOrcNewInParameter( "i_startTime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result_list" );
            Para.AddOrcNewCursorParameter( "o_result_stat" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_apppageforphone.sp_getPostListByUserid" );
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion
    }
}
