using System;
using System.Data;

namespace wcfNSYGShop
{
    public interface IDALGoods
    {
        #region void DisposeConn() 关闭并释放连接对象资源  Edit:2010.02.08
        /// <summary>
        /// 关闭并释放连接资源
        /// </summary>
        void DisposeConn();
        #endregion
        #region void TranBegin() 事务开始  Edit:2010.12.24
        /// <summary>
        /// 启用事务
        /// </summary>
        void TranBegin();
        #endregion
        #region void TranCommit() 提交事务  Edit:2010.12.24
        /// <summary>
        /// 提交事务
        /// </summary>
        void TranCommit();
        #endregion
        #region void TranRollBack() 回滚事务  Edit:2010.12.24
        /// <summary>
        /// 回滚事务
        /// </summary>
        void TranRollBack();
        #endregion
        #region bool IsUseTrans 获取事务状态  Edit:2010.12.24
        /// <summary>
        /// 获取事务状态,true:表顺利执行
        /// </summary>
        bool IsUseTrans
        {
            get;
        }
        #endregion

        #region 获取手机版首页数据
        /// <summary>
        /// 获取手机版首页数据
        /// </summary>
        /// <returns>返回两张表：0今天限时；1热门推荐；</returns>
        DataSet mGetHomePage();
        #endregion

        #region 获取手机版首页数据
        /// <summary>
        /// 获取手机版首页数据
        /// </summary>
        /// <returns>返回3张表：0最新揭晓；1人气推荐6个；2推荐的晒单分享</returns>
        DataSet appGetHomePage();
        #endregion

        #region 获取最近的N个等待开奖数据
        /// <summary>
        /// 获取最近的N个等待开奖数据
        /// </summary>
        /// <param name="time">起始时间</param>
        /// <param name="quantity">获取记录数</param>
        /// <returns></returns>
        DataSet GetStartRaffleList( DateTime time, int quantity );
        #endregion

        #region 限时揭晓
        /// <summary>
        /// 获取限时揭晓列表页数据
        /// </summary>
        /// <returns></returns>
        DataSet mGetAutoLotteryList();
        #endregion

        #region 限时揭晓
        /// <summary>
        /// 获取限时揭晓列表页数据
        /// </summary>
        /// <returns></returns>
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
        DataSet appGetGoodsDetailPageData( int goodsID, int codeID, out int retValue );
        /// <summary>
        /// 获取商品详细页面所需数据
        /// </summary>
        /// <param name="goodsID">商品ID号</param>
        /// <param name="codeID">条码ID号</param>
        /// <param name="retValue">返回值:1 正常返回数据; -1 不在此商品数据; -2 已满员或已揭晓，跳转至揭晓页面</param>
        /// <returns></returns>
        DataSet mGetGoodsDetailPageData( int goodsID, int codeID, out int retValue );
        #endregion

        #region 获取4条最新揭晓记录
        /// <summary>
        /// 获取4条最新揭晓记录
        /// </summary>
        /// <returns></returns>
        DataSet GetRecentlyRaffleList();
        #endregion

        #region 获取商品信息
        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        DataSet GetGoodsInfoByID( int goodsID );
        #endregion

        #region 根据商品条码获取商品详情
        /// <summary>
        /// 根据商品条码获取商品详情
        /// </summary>
        /// <param name="codeID">商品条码</param>
        /// <returns></returns>
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
        /// <param name="orderType">订单类型: 1.换货订单，0.换货订单</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="normalCount">正常订单总数</param>
        /// <param name="changeCount">换货订单总数</param>
        /// <returns></returns>
        DataSet GetMemberCenterUserRaffleList( int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int userID, int orderType, int isCount, out int normalCount, out int changeCount );
        #endregion
        #region 会员中心-获得的商品及活动商品列表
        /// <summary>
        /// 会员中心-获得的商品及活动商品列表
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="orderType">订单类型 2.活动订单 1.换货订单，0.正常订单</param>
        /// <param name="orderState">订单状态 0.全部 1.待确认地址 2.待发货 3.待收货 10.待晒单</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="isStat">是否返回不同订单状态总数</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="recordCount">查询记录总数</param>
        /// <returns></returns>
        DataSet GetMemberCenterUserOrderList( int userID, int orderType, int orderState, DateTime beginTime, DateTime endTime, int FIdx, int EIdx, int isStat, int isCount, out int recordCount );
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
        DataSet GetUserWebPageRaffleList( int userID, int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int isCount, out int totalCount );
        #endregion

        #region 获取商品所有期数列表
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
        DataSet GetGoodsPeriodList( int goodsID, int codeID, int FIdx, int EIdx, int isCount, out int totalCount );
        #endregion

        #region 获取商品详细页面所需数据
        /// <summary>
        /// 获取商品详细页面所需数据
        /// </summary>
        /// <param name="goodsID">商品ID号</param>
        /// <param name="codeID">条码ID号</param>
        /// <param name="retValue">返回值</param>
        /// <returns></returns>
        DataSet GetGoodsDetailPageData( int goodsID, int codeID, out int retValue );
        #endregion

        #region 获取云购即将完成的商品列表（即将开奖商品）
        /// <summary>
        /// 获取云购即将完成的商品列表（即将开奖商品）
        /// </summary>
        /// <param name="quantity">返回记录数量</param>
        /// <returns></returns>
        DataSet GetRNOLastGoodsList( int quantity );
        #endregion

        #region 返回首页商品数据 lable（1：每日推荐2：精品推荐3：即将揭晓）
        /// <summary>
        /// 返回首页商品数据 lable（1：每日推荐2：精品推荐3：即将揭晓）
        /// </summary>
        /// <param name="lable"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        DataSet GetHomeGoodsByLabel( string lable, int quantity );
        #endregion

        #region 首页
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
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
        int UpdateThirdGoodsPriceByID( int goodsID, decimal goodsPrice, int supplier );
        /// <summary>
        /// 获取需要从第三方去下单的所有商品
        /// </summary>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
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
        DataSet GetLimitBuyGoodsPage( int FIdx, int EIdx, int isCount, out int totalCount );

        #endregion

        #region 收藏商品模块
        /// <summary>
        /// 用户添加收藏商品
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        int InsertCollectGoodsByUserID( int userID, int goodsID );
        /// <summary>
        /// 删除用户收藏的商品
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        int DeleteCollectGoodsByUserID( int userID, int goodsID );
        /// <summary>
        /// 删除用户的所有失效商品
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
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
        DataSet GetCollectGoodsByUserID( int userID, int FIdx, int EIdx, int isCount, out int totalCount );
        /// <summary>
        /// 检测用户是否有收藏某商品
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
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
        DataSet GetPcGoodsPerioPagedList( int goodsID, int codeID, int FIdx, int EIdx, int isCount, out int totalCount );
        #endregion

        #region 获取商品某期的期数信息
        /// <summary>
        /// 获取商品某期的期数信息
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="period">期数</param>
        /// <returns></returns>
        DataSet GetGoodsBarcodeInfoByPeriod( int goodsID, int period );
        #endregion

        #region 获取商品正在进行中的期数信息
        /// <summary>
        /// 获取商品正在进行中的期数信息
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        DataSet GetSalingBarcodeInfoByGoodsID( int goodsID );
        #endregion

        #region 获取某商品的所有期数获得者信息
        /// <summary>
        /// 获取某商品的所有期数获得者信息
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="period">当前页最小的期数</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总记录数</param>
        /// <returns></returns>
        DataSet GetBarcodeRaffListByGoodsID( int goodsID, int period, int FIdx, int EIdx, int isCount, out int totalCount );
        #endregion

        #region 商品设置配送商与不可到达地区模块
        /// <summary>
        /// 查询商品不能配送到的区域
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">输出总数</param>
        /// <returns></returns>
        DataTable GetNoDyAreaByGoodsID( int orderNO, int FIdx, int EIdx );
        #endregion

        #region 获取手机APP主页新品推荐商品
        /// <summary>
        /// 获取手机APP主页新品推荐商品
        /// </summary>
        /// <param name="quantity">获取数量</param>
        /// <returns></returns>
        DataSet appGetNewGoodsRecommand( int quantity );
        #endregion

        #region 获取手机APP主页猜你喜欢商品
        /// <summary>
        /// 获取手机APP主页猜你喜欢商品
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="quantity">获取数量</param>
        /// <returns></returns>
        DataSet appGetUserLikeGoods( int userID, int quantity );
        #endregion
        #region  web获取猜你喜欢商品12228
        /// <summary>
        /// web获取猜你喜欢商品12228
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="quantity">获取数量</param>
        /// <returns></returns>
        DataSet GetGuessYouLikeGoods( int userID, int quantity );
        #endregion
        #region 获取手机APP最新揭晓
        /// <summary>
        /// 获取手机APP最新揭晓
        /// </summary>
        /// <param name="quanity">获取数量(最多20条)</param>
        /// <returns></returns>
        DataSet appGetNewLottery( int quanity );

        #endregion
        #region 获取手机APP人气推荐
        /// <summary>
        /// 获取手机APP人气推荐
        /// </summary>
        /// <param name="quanity">获取数量(最多20条)</param>
        /// <returns></returns>
        DataSet appGetPopGoodsRec( int quanity );

        #endregion

        #region 获取手机APP某商品所有获得者10310
        /// <summary>
        /// 获取手机APP某商品所有获得者
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="maxPeriod">上限期数 0表示从最大期取数据</param>
        /// <param name="quantity">获取数量</param>
        /// <param name="totalCount">输出总数</param>
        /// <returns></returns>
        DataSet appGetGoodsHistoryWinner( int goodsID, int maxPeriod, int quantity, out int totalCount );
        #endregion
        #region 获取手机APP某商品所有获得者(包含正在揭晓)10313
        /// <summary>
        /// 获取手机APP某商品所有获得者(包含正在揭晓)10313
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="maxPeriod">上限期数 0表示从最大期取数据</param>
        /// <param name="quantity">获取数量</param>
        /// <param name="totalCount">输出总数</param>
        /// <returns></returns>
        DataSet appGetGoodsHistoryWinner2( int goodsID, int maxPeriod, int quantity, out int totalCount );
        #endregion

        #region APP根据条码ID获取某用户的购买数量(用于商品详情页)
        /// <summary>
        /// APP根据条码ID获取某用户的购买数量(用于商品详情页)
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="codeID"></param>
        /// <returns></returns>
        DataSet getBuyNumByUidCid( int userID, int codeID );
        #endregion

        #region APP获取限购商品列表（新增排序功能）
        /// <summary>
        /// 获取限购商品列表（新增排序功能）
        /// </summary>
        /// <param name="orderFlag"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        DataSet appGetLimitBuyGoods( int orderFlag, int FIdx, int EIdx, int isCount, out int totalCount );
        #endregion
        //===========ERP Start===========

        #region 修改商品上架名称
        /// <summary>
        /// 修改商品上架名称
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="goodsSName">商品简称</param>
        /// <param name="goodsPic">商品图片</param>
        /// <param name="isCommit">提交方式，0：数据库提交，1：程序提交</param>
        /// <returns></returns>
        int UpdateGoodsNameByGoodsID( int goodsID, string goodsName, string goodsSName, string goodsPic, int isCommit );
        #endregion

        #region 修改附加标题说明和SEO信息
        /// <summary>
        /// 修改附加标题说明和SEO信息
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="goodsAltName">商品附加标题说明</param>
        /// <param name="goodsPreName">SEO修饰字符</param>
        /// <param name="goodsKeywords">搜索关键词</param>
        /// <param name="goodsBriefed">简介</param>
        /// <param name="goodsRecDesc">推荐描述</param>
        /// <param name="isCommit">提交方式，0：数据库提交，1：程序提交</param>
        /// <returns></returns>
        int UpdateGoodsAltNameByGoodsID( int goodsID, string goodsAltName, string goodsPreName, string goodsKeywords, string goodsBriefed, string goodsRecDesc, int isCommit );
        #endregion

        #region 修改商品的详细介绍
        /// <summary>
        /// 修改商品的详细介绍
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="goodsDesc">商品详情</param>
        /// <param name="isCommit">提交方式，0：数据库提交，1：程序提交</param>
        /// <returns></returns>
        int UpdateGoodsDescriptionByGoodsID( int goodsID, string goodsDesc, string goodsDescM, int isCommit );
        #endregion

        #region 修改商品的状态
        /// <summary>
        /// 修改商品的状态
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="goodsState">商品状态</param>
        /// <param name="isCommit">提交方式，0：数据库提交，1：程序提交</param>
        /// <returns></returns>
        int UpdateGoodsStateByGoodsID( int goodsID, int goodsState, int isCommit );
        #endregion

        #region 修改商品的一些其它设置信息
        /// <summary>
        /// 修改商品的一些其它设置信息
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="isLimited">是否限购</param>
        /// <param name="limitNum">限购人次</param>
        /// <param name="editType">商品类型：0普通商品，1房产</param>
        /// <param name="goodsLabelStr">商品特定功能标识：如 104 不可晒单</param>
        /// <param name="isCommit">提交方式，0：数据库提交，1：程序提交</param>
        /// <returns></returns>
        int UpdateGoodsInfoByGoodsID( int goodsID, int isLimited, int limitNum, int editType, int goodsLabelStr, int isCommit );
        #endregion

        #region 同步上架其他字段信息(为后续扩展预留的接口)
        /// <summary>
        /// 同步上架其他字段信息(为后续扩展预留的接口)
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="goodsSortID">商品分类ID</param>
        /// <param name="spucode">spu编码</param>
        /// <param name="saleprice">销售价格</param>
        /// <param name="shelftype">上架类型:1 普通 2 促销 3 秒杀</param>
        /// <param name="signnote">签收注意事项</param>
        /// <param name="support">售后保障</param>
        /// <param name="isCommit">提交方式，0：数据库提交，1：程序提交</param>
        /// <returns></returns>
        int UpdateGoodsOtherInfoByGoodsID( int goodsID, int goodsSortID, string spucode, decimal saleprice, int shelftype, string signnote, string support, int isOptSku, int isOptByStock, int isCommit );
        #endregion

        #region 新增商品新增上架信息
        /// <summary>
        /// 新增商品新增上架信息
        /// </summary>
        /// <param name="goodsID"></param>
        /// <param name="goodsName"></param>
        /// <param name="goodsSortID"></param>
        /// <param name="goodsState"></param>
        /// <param name="spuCode"></param>
        /// <param name="salePrice"></param>
        /// <param name="shelftype"></param>
        /// <param name="signnote"></param>
        /// <param name="support"></param>
        /// <param name="isOptSku"></param>
        /// <param name="goodsBrandID"></param>
        /// <param name="goodsLableID"></param>
        /// <param name="isOptByStock"></param>
        /// <param name="isNeedIMEI"></param>
        /// <param name="goodslabel"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        int InsertGoodsInfo( int goodsID, string goodsName, int goodsSortID, int goodsState, string spuCode, decimal salePrice, int shelftype, string signnote, string support, int isOptSku, int goodsBrandID, int goodsLableID, int isOptByStock, int isNeedIMEI, int goodslabel, int isCommit );

        #endregion

        #region 同步上架品牌和标签信息
        /// <summary>
        /// 同步上架品牌和标签信息
        /// </summary>
        /// <param name="spuCode">商品ID</param>
        /// <param name="isOptSku">是否需要选择属性</param>
        /// <param name="goodsBrandId">商品品牌ID</param>
        /// <param name="goodsLabelId">商品标签ID</param>
        /// <param name="isCommit">提交方式，0：数据库提交，1：程序提交</param>
        /// <returns></returns>
        int UpdateGoodsBrandLabelByGoodsID( string spuCode, int goodsBrandId, int goodsLabelId, int isNeedIMEI, int goodsLabelStr, int isCommit );
        #endregion
        #region 添加商品展示图记录(同步ERP系统yungou_sys.GoodsPic数据)13443
        /// <summary>
        /// 添加商品展示图记录(同步ERP系统yungou_sys.GoodsPic数据)13443
        /// </summary>
        /// <param name="picID"></param>
        /// <param name="goodsID"></param>
        /// <param name="picName"></param>
        /// <param name="picRemark"></param>
        /// <param name="picHide"></param>
        /// <param name="picRank"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        int AddGoodspic( int picID, int goodsID, string picName, string picRemark, int picHide, int picRank, int isCommit );
        #endregion
        #region 更新商品展示图信息(同步ERP系统yungou_sys.GoodsPic数据)13444
        /// <summary>
        /// 更新商品展示图信息(同步ERP系统yungou_sys.GoodsPic数据)13444
        /// </summary>
        /// <param name="picID"></param>
        /// <param name="goodsID"></param>
        /// <param name="picName"></param>
        /// <param name="picRemark"></param>
        /// <param name="picHide"></param>
        /// <param name="picRank"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        int ModGoodspicByPicID( int picID, int goodsID, string picName, string picRemark, int picHide, int picRank, int isCommit );

        #endregion
        #region 删除商品展示图片记录(同步ERP系统yungou_sys.GoodsPic数据)13445
        /// <summary>
        /// 删除商品展示图片记录(同步ERP系统yungou_sys.GoodsPic数据)13445
        /// </summary>
        /// <param name="picID"></param>
        /// <param name="goodsID"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        int DelGoodsPicByPicID( int picID, int goodsID, int isCommit );

        #endregion

        #region 刷新上架商品的更新时间
        /// <summary>
        /// 刷新上架商品的更新时间
        /// </summary>
        /// <param name="goodsID"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        int UpdateGoodsUpdateTimeByGoodsID( int goodsID, int isCommit );
        #endregion
        #region 更新上架商品重量
        /// <summary>
        /// 更新上架商品重量
        /// </summary>
        /// <param name="goodsID"></param>
        /// <param name="goodsWeight"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        int UpdateGoodsweightByGoodsID( int goodsID, decimal goodsWeight, int isCommit );
        #endregion
        //===========ERP End===========
        #region 根据商品对应分类人气推荐，最多显示8个
        /// <summary>
        /// 根据商品对应分类人气推荐，最多显示8个
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        DataSet GetHotSortGoodsIDByGID( int goodsID );
        #endregion
        #region 获取热门推荐商品
        /// <summary>
        /// 获取热门推荐商品
        /// </summary>
        /// <param name="quantity">获取数量</param>
        /// <returns></returns>
        DataSet GetPopularGoods( int quantity );
        #endregion
        #region 微信触屏获取限购商品列表（新增排序功能）
        /// <summary>
        /// 获取限购商品列表（新增排序功能）11812
        /// </summary>
        /// <param name="orderFlag">       
        /// -- 50是上架时间降序
        //-- 40是剩余人次降序
        //-- 31是价格升序 
        //-- 30是价格降序
        //-- 20是人气降序，百分比+期数*50%
        //-- 10是即将揭晓降序，完成百分比</param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <returns></returns>
        DataSet mGetLimitBuyGoods( int orderFlag, int FIdx, int EIdx, int isCount, out int totalCount );
        #endregion


        #region 获取商品列表(新增导航)12224
        /// <summary>
        /// 获取商品列表(新增导航)12226
        /// col:goodsID, goodsSName, goodsPic, codeID, codePrice, codeQuantity, codeSales, goodsTag
        /// </summary>
        /// <param name="nvgtID">导航ID</param>
        /// <param name="brandID">品牌ID</param>
        /// <param name="orderFlag">排序方式</param>
        /// <param name="FIdx">起始编号</param>
        /// <param name="EIdx">结束编号</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        DataSet GetGoodsListByNvgtID( int nvgtID, int brandID, int orderFlag, int FIdx, int EIdx, int isCount, out int totalCount );

        #endregion
        #region 预览时跳转导航关联的有上架商品的品牌列表(新增导航)12225
        /// <summary>
        /// 预览时跳转导航关联的有上架商品的品牌列表12225
        /// </summary>
        /// <param name="nvgtID">导航ID</param>
        /// <returns></returns>
        DataSet GetBrandListByNvgtID( int nvgtID );

        #endregion
        #region 获取商品列表(新增导航_预览)12226
        /// <summary>
        /// 获取商品列表(新增导航)12226
        /// col:goodsID, goodsSName, goodsPic, codeID, codePrice, codeQuantity, codeSales, goodsTag
        /// </summary>
        /// <param name="nvgtID">导航ID</param>
        /// <param name="brandID">品牌ID</param>
        /// <param name="orderFlag">排序方式</param>
        /// <param name="FIdx">起始编号</param>
        /// <param name="EIdx">结束编号</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        DataSet GetPreviewGoodsList( int nvgtID, int brandID, int orderFlag, int FIdx, int EIdx, int isCount, out int totalCount );

        #endregion
        #region 预览时跳转导航关联的有上架商品的品牌列表(新增导航_预览)12227
        /// <summary>
        /// 预览时跳转导航关联的有上架商品的品牌列表12227
        /// </summary>
        /// <param name="nvgtID">导航ID</param>
        /// <returns></returns>
        DataSet GetPreviewBrandList( int nvgtID );

        #endregion
        #region 根据导航ID获取导航名称12229
        /// <summary>
        /// 根据导航ID获取导航名称12229
        /// </summary>
        /// <param name="nvgtID">导航ID</param>
        /// <returns></returns>
        DataSet GetNvgNameByID( int nvgtID );
        #endregion
        #region 预览根据导航ID获取导航名称12230
        /// <summary>
        /// 预览根据导航ID获取导航名称12230
        /// </summary>
        /// <param name="nvgtID">导航ID</param>
        /// <returns></returns>
        DataSet GetPreNvgNameByID( int nvgtID );
        #endregion
        #region 返回活动推荐的商品
        /// <summary>
        /// 返回活动推荐的商品
        /// </summary>
        /// <param name="goodsLabel"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        DataSet GetActSpecByLabel( int goodsLabel, int quantity );
        #endregion

        #region app会员中心-中奖的商品列表10316
        /// <summary>
        /// app会员中心-中奖的商品列表10316
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
        DataSet appGetMemberCenterUserRaffleList( int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int userID, int orderType, int isCount, out int normalCount, out int changeCount );
        #endregion
    }
}
