using System;
using System.Data;
using System.ServiceModel;

namespace wcfNSYGShop
{
    /// <summary>
    /// 商品晒单相关接口
    /// </summary>
    public partial interface IWCFContract
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
        [OperationContract]
        DataSet GetPostSinglePageList( int FIdx, int EIdx, int order, int isCount, out int totalCount );
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
        [OperationContract]
        DataSet GetPostSinglePageListEx( int FIdx, int EIdx, int order, int sortID, int isCount, out int totalCount );
        /// <summary>
        /// 分页获取晒单列表
        /// </summary>
        /// <param name="FIdx">开始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="order">排序方式(10最新，20人气，30评论)</param>
        /// <param name="isCount">是否统计总记录数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        [OperationContract]
        DataSet mGetPostSinglePageList( int FIdx, int EIdx, int order, int isCount, out int totalCount );
        #endregion

        #region 获取晒单详情信息
        /// <summary>
        /// 获取晒单详情信息
        /// </summary>
        /// <param name="postID">晒单ID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetPostSingleDetail( int postID );
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
        [OperationContract]
        DataSet GetPostReplyListByID( int postID, int FIdx, int EIdx, int isCount, out int replyCount, out int hits );
        #endregion

        #region 晒单人气+1
        /// <summary>
        /// 晒单人气+1
        /// </summary>
        /// <param name="postID">晒单ID</param>
        /// <param name="IP">IP</param>
        /// <returns></returns>
        [OperationContract]
        bool InsertPostHits( int postID, long IP );
        #endregion

        #region 检测用户回复晒单是否需要验证码
        /// <summary>
        /// 检测用户回复晒单是否需要验证码
        /// </summary>
        /// <param name="userID">会员id</param>
        /// <returns></returns>
        [OperationContract]
        bool GetPostReplyConfigCheck( int userID );
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
        [OperationContract]
        int InsertPostReply( int postID, int userID, string content, string IP, string userName,
            string originalContent, string replyRefUserName, int refReplyID, int refFloor );
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
        [OperationContract]
        DataSet mGetPageForGoodsPostSingle( int goodsID, int FIdx, int EIdx, int isCount );
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
        [OperationContract]
        DataSet GetUserWebPagePostList( int userID, int FIdx, int EIdx, int isCount, out int totalCount );
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
        [OperationContract]
        DataSet mGetUserWebPagePostList( int userID, int FIdx, int EIdx, int isCount, out int totalCount );
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
        [OperationContract]
        DataSet GetMemberCenterForUserPostSingle( int FIdx, int EIdx, int userID, int isCount, out int postCount, out int unPostCount );
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
        [OperationContract]
        DataSet GetMemberCenterForUserUnPostSingle( int FIdx, int EIdx, int userID, int isCount, out int count );
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
        [OperationContract]
        int InsertPostSingle( int codeID, int userID, string postTitle, string postContent, string postAllPic, DateTime postTime );
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
        [OperationContract]
        DataSet GetPageForGoodsPostSingle( int goodsID, int FIdx, int EIdx, int isCount );
        #endregion

        #region 检查是否可以晒单
        /// <summary>
        /// 检查是否可以晒单
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="codeID">商品条码</param>
        /// <returns></returns>
        [OperationContract]
        bool CheckPostSingleByID( int userID, int codeID );
        #endregion

        #region 获取晒单详情
        /// <summary>
        /// 获取晒单详情
        /// </summary>
        /// <param name="postID">晒单ID号</param>
        /// <param name="userID">发布的会员ID号</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetMemberCenterUserPostSingleDetail( int postID, int userID );
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
        [OperationContract]
        int UpdatePostSingle( int userID, int postID, string postTitle, string postContent, string postAllPic, int postState, DateTime postTime );
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
        [OperationContract]
        DataSet GetPostSingleOldPeriodList( int FIdx, int EIdx, int codeID, int isCount, out int totalCount );
        #endregion

        #region 查询最新晒单指定数量列表
        /// <summary>
        /// 晒单详请右侧查询最新晒单列表
        /// </summary>
        /// <param name="Quantity">查询的数量</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetListNewPostSingleTopList( int Quantity );
        #endregion

        #region 读取评论的5条回复数据
        /// <summary>
        /// 读取评论的5条回复数据
        /// </summary>
        /// <param name="replyId"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetPostReplyInfo( int replyId );
        #endregion

        #region 删除回复(修改回复信息状态)
        /// <summary>
        /// 删除回复(修改回复信息状态)
        /// </summary>
        /// <param name="replyId">主键</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        [OperationContract]
        int SetPostReplyHide( int replyId, int userId );
        #endregion

        #region 进行获取用户的晒单信息列表，用于前台显示
        /// <summary>
        /// 进行获取用户的晒单信息列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        DataSet GetPostSingleShow();
        #endregion

        #region 查询晒单的基本字段信息
        /// <summary>
        /// 查询晒单的基本字段信息
        /// </summary>
        /// <param name="postID">晒单ID号</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetPostSingleBaseInfo( int postID );
        #endregion

        #region 获取最新晒单回复
        /// <summary>
        /// 获取最新晒单回复
        /// </summary>
        /// <param name="quantity">获取数目</param>
        /// <param name="lastReplyID">最后的回复ID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetPostReplyLastest( int quantity, int lastReplyID );
        #endregion

        #region 获取首页推荐的晒单
        /// <summary>
        /// 获取首页推荐的晒单
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        DataSet GetPostSingleForHomeRecommend();
        #endregion

        #region 插入晒单详情阅读量（+1）
        /// <summary>
        /// 添加晒单阅读量
        /// </summary>
        /// <param name="postID">晒单ID</param>
        /// <returns></returns>
        [OperationContract]
        int InsertPostsingleReadCount( int postID );
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
        [OperationContract]
        DataSet GetMemberCenterPostListByUserID( int userID, int state, int isStat, DateTime beginTime, DateTime endTime, int FIdx, int EIdx, int isCount, out int totalCount );
        #endregion
    }
}
