using System;
using System.Data;
using System.ServiceModel;

namespace wcfNSYGShop
{
    /// <summary>
    /// 商品相关接口
    /// </summary>
    public partial interface IWCFContract
    {
        #region 获取手机版首页数据
        /// <summary>
        /// 获取手机版首页数据
        /// </summary>
        /// <returns>返回两张表：0今天限时；1热门推荐；</returns>
        [OperationContract]
        DataSet mGetHomePage();
        #endregion

        #region 获取手机版首页数据
        /// <summary>
        /// 获取手机版首页数据
        /// </summary>
        /// <returns>返回3张表：0最新揭晓；1人气推荐6个；2推荐的晒单分享</returns>
        [OperationContract]
        DataSet appGetHomePage();
        #endregion

        #region 获取最近的N个等待开奖数据
        /// <summary>
        /// 获取最近的N个等待开奖数据
        /// </summary>
        /// <param name="time">起始时间</param>
        /// <param name="quantity">获取记录数</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetStartRaffleGoodsList( DateTime time, int quantity );
        #endregion

        #region 限时揭晓
        /// <summary>
        /// 获取限时揭晓列表页数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        DataSet mGetAutoLotteryList();
        #endregion

        #region 限时揭晓
        /// <summary>
        /// 获取限时揭晓列表页数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        DataSet GetAutoLotteryList();
        #endregion

        #region 获取商品列表
        /// <summary>
        /// 获取商品列表：前台商品列表页面
        /// col:goodsID, goodsSName, goodsPic, codeID, codePrice, codeQuantity, codeSales, goodsTag
        /// </summary>
        /// <param name="sortID">类别ID</param>
        /// <param name="brandID">品牌ID</param>
        /// <param name="orderFlag">排序方式</param>
        /// <param name="FIdx">起始编号</param>
        /// <param name="EIdx">结束编号</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGoodsPageList( int sortID, int brandID, int orderFlag, int FIdx, int EIdx, int isCount, out int totalCount );
        #endregion

        #region 获取商品列表-搜索
        /// <summary>
        /// 获取商品列表：主要用于前台商品的列表页面(搜索)
        /// col:goodsID, goodsSName, goodsPic, codeID, codePrice, codeQuantity, codeSales
        /// </summary>
        /// <param name="keywords">搜索关键字</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="order">排序</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGoodsSearchList( string keywords, int FIdx, int EIdx, int order, int isCount, out int totalCount );
        #endregion

        #region 获取商品详细页面所需数据
        /// <summary>
        /// 获取商品详细页面所需数据
        /// </summary>
        /// <param name="goodsID">商品ID号</param>
        /// <param name="codeID">条码ID号</param>
        /// <param name="retValue">返回值:1 正常返回数据; -1 不在此商品数据; -2 已满员或已揭晓，跳转至揭晓页面</param>
        /// <returns></returns>
        [OperationContract]
        DataSet appGetGoodsDetailPageData( int goodsID, int codeID, out int retValue );
        /// <summary>
        /// 获取商品详细页面所需数据
        /// </summary>
        /// <param name="goodsID">商品ID号</param>
        /// <param name="codeID">条码ID号</param>
        /// <param name="retValue">返回值:1 正常返回数据; -1 不在此商品数据; -2 已满员或已揭晓，跳转至揭晓页面</param>
        /// <returns></returns>
        [OperationContract]
        DataSet mGetGoodsDetailPageData( int goodsID, int codeID, out int retValue );
        #endregion

        #region 获取4条最新揭晓记录
        /// <summary>
        /// 获取4条最新揭晓记录
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        DataSet GetRecentlyRaffleList();
        #endregion

        #region 获取商品信息
        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGoodsInfoByID( int goodsID );
        #endregion

        #region 根据商品条码获取商品详情
        /// <summary>
        /// 根据商品条码获取商品详情
        /// </summary>
        /// <param name="codeID">商品条码</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGoodsBarcodeInfo( int codeID );
        #endregion

        #region 会员中心-中奖的商品列表
        /// <summary>
        /// 会员中心-中奖的商品列表
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userID">会员ID</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">总记录数</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetMemberCenterUserRaffleList( int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int userID, int isCount, out int count );

        /// <summary>
        /// 会员中心-中奖的商品列表
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userID">会员ID</param>
        /// <param name="orderType">订单类型: 1.换货订单，0.换货订单</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="normalCount">正常订单总数</param>
        /// <param name="changeCount">换货订单总数</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetMemberCenterUserRaffleListEx( int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int userID, int orderType, int isCount, out int normalCount, out int changeCount );

        #endregion

        #region 个人主页获取会员获得的商品
        /// <summary>
        /// 获取会员获得的商品
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserWebPageRaffleList( int userID, int FIdx, int EIdx, int isCount, out int totalCount );
        #endregion

        #region 获取商品所有期数列表
        /// <summary>
        /// 获取商品所有期数列表
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="codeID">条码ID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGoodsPeriodList( int goodsID, int codeID );

        /// <summary>
        /// 分页获取商品所有期数列表
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="codeID">条码ID</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总数量</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGoodsPeriodPageList( int goodsID, int codeID, int FIdx, int EIdx, int isCount, out int totalCount );
        #endregion

        #region 获取商品详细页面所需数据
        /// <summary>
        /// 获取商品详细页面所需数据
        /// </summary>
        /// <param name="goodsID">商品ID号</param>
        /// <param name="codeID">条码ID号</param>
        /// <param name="retValue">返回值</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGoodsDetailPageData( int goodsID, int codeID, out int retValue );
        #endregion

        #region 获取云购即将完成的商品列表（即将开奖商品）
        /// <summary>
        /// 获取云购即将完成的商品列表（即将开奖商品）
        /// </summary>
        /// <param name="quantity">返回记录数量</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetRNOLastGoodsList( int quantity );
        #endregion

        #region 返回首页商品数据 lable（1：每日推荐2：精品推荐3：即将揭晓）
        /// <summary>
        /// 返回首页商品数据 lable（1：每日推荐2：精品推荐3：即将揭晓）
        /// </summary>
        /// <param name="lable"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetHomeGoodsByLabel( string lable, int quantity );
        #endregion

        #region 首页
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        DataSet GetHomePageData();
        #endregion

        #region 返回首页推荐的商品
        /// <summary>
        /// 返回首页推荐的商品
        /// lable:12热门推荐，13新品上架
        /// </summary>
        /// <param name="goodsLabel"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGoodsForHomeRecommend( int goodsLabel, int quantity );
        #endregion

        #region 第三方商品比价模块
        /// <summary>
        /// 根据价格查看是否要添加第三方商品对照表的价格
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="goodsPrice">商品价格</param>
        /// <param name="supplier">第三方：1京东</param>
        /// <returns></returns>
        [OperationContract]
        int UpdateThirdGoodsPriceByID( int goodsID, decimal goodsPrice, int supplier );
        /// <summary>
        /// 获取需要从第三方去下单的所有商品
        /// </summary>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetThirdGoodsList( int FIdx, int EIdx, int isCount, out int totalCount );
        #endregion

        #region 限购模块

        /// <summary>
        /// 分页获取限购商品列表
        /// </summary>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总记录数</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetLimitBuyGoodsPage( int FIdx, int EIdx, int isCount, out int totalCount );

        #endregion

        #region 收藏商品模块
        /// <summary>
        /// 用户添加收藏商品
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        [OperationContract]
        int InsertCollectGoodsByUserID( int userID, int goodsID );
        /// <summary>
        /// 删除用户收藏的商品
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        [OperationContract]
        int DeleteCollectGoodsByUserID( int userID, int goodsID );
        /// <summary>
        /// 删除用户的所有失效商品
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        [OperationContract]
        int DeleteAllFailCollectGoodsByUserID( int userID );
        /// <summary>
        /// 分页获取用户收藏的商品
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总记录数</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetCollectGoodsByUserID( int userID, int FIdx, int EIdx, int isCount, out int totalCount );
        /// <summary>
        /// 检测用户是否有收藏某商品
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        [OperationContract]
        int CheckUserCollectGoods( int userID, int goodsID );
        #endregion

        #region PC分页获取商品期数列表
        /// <summary>
        /// PC分页获取商品期数列表
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="codeID">期数ID</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总记录数</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetPcGoodsPerioPagedList( int goodsID, int codeID, int FIdx, int EIdx, int isCount, out int totalCount );
        #endregion

        #region 获取商品某期的期数信息
        /// <summary>
        /// 获取商品某期的期数信息
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="period">期数</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGoodsBarcodeInfoByPeriod( int goodsID, int period );
        #endregion

        #region 获取商品正在进行中的期数信息
        /// <summary>
        /// 获取商品正在进行中的期数信息
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetSalingBarcodeInfoByGoodsID( int goodsID );
        #endregion
    }
}
