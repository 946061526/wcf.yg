using System;
using System.Data;

namespace wcfNSYGShop
{
    public class DALGoods : DALBase, IDALGoods
    {
        #region 获取手机版首页数据
        /// <summary>
        /// 获取手机版首页数据
        /// </summary>
        /// <returns>返回两张表：0今天限时；1热门推荐；</returns>
        public DataSet mGetHomePage()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11805" );
            //Para.AddOrcNewCursorParameter( "o_result_bar" );
            Para.AddOrcNewCursorParameter( "o_result_goods" );
            //Para.AddOrcNewCursorParameter( "o_result_post" );
            return Dal.ExecuteFillDataSet( "yun_MPageForPhone.sp_getDataForHomePage" );//pro_mPageForHome
        }
        #endregion

        #region 获取手机版首页数据
        /// <summary>
        /// 获取手机版首页数据
        /// </summary>
        /// <returns>返回3张表：0最新揭晓；1人气推荐6个；2推荐的晒单分享</returns>
        public DataSet appGetHomePage()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10305" );
            Para.AddOrcNewCursorParameter( "o_result_bar" );
            Para.AddOrcNewCursorParameter( "o_result_goods" );
            Para.AddOrcNewCursorParameter( "o_result_post" );
            return Dal.ExecuteFillDataSet( "yun_apppageforphone.sp_getDataOfHomePage" );//pro_appPageForHome
        }
        #endregion

        #region 获取最近的N个等待开奖数据
        /// <summary>
        /// 获取最近的N个等待开奖数据
        /// </summary>
        /// <param name="time">起始时间</param>
        /// <param name="quantity">获取记录数</param>
        /// <returns></returns>
        public DataSet GetStartRaffleList( DateTime time, int quantity )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12218" );
            Para.AddOrcNewInParameter( "i_time", time );
            Para.AddOrcNewInParameter( "i_quantity", quantity );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getRecentNRaffleByTime" );//pro_PageForStartRaffleList
        }
        #endregion

        #region 限时揭晓
        /// <summary>
        /// 获取限时揭晓列表页数据
        /// </summary>
        /// <returns></returns>
        public DataSet mGetAutoLotteryList()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11801" );
            Para.AddOrcNewCursorParameter( "o_result_today" );
            Para.AddOrcNewCursorParameter( "o_result_tomorrow" );
            return Dal.ExecuteFillDataSet( "yun_MPageForPhone.sp_getAutoLotteryList" );//pro_mPageForAutoLotteryList
        }
        #endregion

        #region 限时揭晓
        /// <summary>
        /// 获取限时揭晓列表页数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetAutoLotteryList()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12202" );
            Para.AddOrcNewCursorParameter( "o_result_today" );
            Para.AddOrcNewCursorParameter( "o_result_tomorrow" );
            Para.AddOrcNewCursorParameter( "o_result_before" );
            return Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getAutoLotteryForHome" );//pro_PageForAutoLotteryList
        }
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
        public DataSet GetGoodsPageList( int sortID, int brandID, int orderFlag, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12207" );
            Para.AddOrcNewInParameter( "i_sortID", sortID );
            Para.AddOrcNewInParameter( "i_brandID", brandID );
            Para.AddOrcNewInParameter( "i_OrderFlag", orderFlag );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_isCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getGoodsListBySortID" );//pro_PageForGoodsList
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
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
        public DataSet GetGoodsSearchList( string keywords, int FIdx, int EIdx, int order, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12208" );
            Para.AddOrcNewInParameter( "i_keywords", keywords );
            Para.AddOrcNewInParameter( "i_OrderFlag", order );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_isCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getGoodsListByKeyWord" );//pro_PageForGoodsListByKeywords
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion

        #region 获取商品详细页面所需数据
        /// <summary>
        /// 获取商品详细页面所需数据
        /// </summary>
        /// <param name="goodsID">商品ID号</param>
        /// <param name="codeID">条码ID号</param>
        /// <param name="retValue">返回值:1 正常返回数据; 0:异常; -1 不在此商品数据; -2 已满员或已揭晓，跳转至揭晓页面</param>
        /// <returns></returns>
        public DataSet appGetGoodsDetailPageData( int goodsID, int codeID, out int retValue )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10301" );
            Para.AddOrcNewInParameter( "i_goodsid", goodsID );
            Para.AddOrcNewInParameter( "i_codeid", codeID );
            Para.AddOrcNewCursorParameter( "o_result1" );
            Para.AddOrcNewCursorParameter( "o_result2" );
            Para.AddOrcNewCursorParameter( "o_result_pic" );
            Para.AddOrcNewCursorParameter( "o_result_goods" );
            Para.AddOrcNewCursorParameter( "o_result_bar" );
            Para.AddOrcNewCursorParameter( "o_result_post" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_apppageforphone.sp_getGoodsByGoodsID" );//pro_appPageForGoodsDetail
            retValue = GetOrcReturnValue( _DS );
            return _DS;
        }
        /// <summary>
        /// 获取商品详细页面所需数据
        /// </summary>
        /// <param name="goodsID">商品ID号</param>
        /// <param name="codeID">条码ID号</param>
        /// <param name="retValue">返回值:1 正常返回数据; -1 不在此商品数据; -2 已满员或已揭晓，跳转至揭晓页面</param>
        /// <returns></returns>
        public DataSet mGetGoodsDetailPageData( int goodsID, int codeID, out int retValue )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11802" );
            Para.AddOrcNewInParameter( "i_goodsid", goodsID );
            Para.AddOrcNewInParameter( "i_codeid", codeID );
            Para.AddOrcNewCursorParameter( "o_result1" );
            Para.AddOrcNewCursorParameter( "o_result_period" );
            Para.AddOrcNewCursorParameter( "o_result_goods" );
            Para.AddOrcNewCursorParameter( "o_result_pic" );
            Para.AddOrcNewCursorParameter( "o_result_gbar" );
            Para.AddOrcNewCursorParameter( "o_result_bar" );
            Para.AddOrcNewCursorParameter( "o_result_post" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MPageForPhone.sp_getGoodsInfoByGoodsID" );//pro_mPageForGoodsDetail
            retValue = GetOrcReturnValue( _DS );
            return _DS;
        }
        #endregion

        #region 获取4条最新揭晓记录
        /// <summary>
        /// 获取4条最新揭晓记录
        /// </summary>
        /// <returns></returns>
        public DataSet GetRecentlyRaffleList()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12217" );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getRecentlyRaffleOfHome" );//pro_PageForRecentlyRaffleList
        }
        #endregion

        #region 获取商品信息
        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        public DataSet GetGoodsInfoByID( int goodsID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11303" );
            Para.AddOrcNewInParameter( "i_GoodsID", goodsID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_Goods.sp_getGoodsByGoodsID" );//pro_GoodsGetInfoByID
        }
        #endregion

        #region 根据商品条码获取商品详情
        /// <summary>
        /// 根据商品条码获取商品详情
        /// </summary>
        /// <param name="codeID">商品条码</param>
        /// <returns></returns>
        public DataSet GetGoodsBarcodeInfo( int codeID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11301" );
            Para.AddOrcNewInParameter( "i_codeid", codeID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_Goods.sp_getGoodsInfoByCodeID" );//pro_GoodsBarcodeGetInfo
        }
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
        public DataSet GetMemberCenterUserRaffleList( int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int userID, int orderType, int isCount, out int normalCount, out int changeCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11738" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_orderType", orderType );
            Para.AddOrcNewInParameter( "i_startTime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result1" );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getUserLotteryByUserid" );//pro_MemberCenterForUserRaffleList
            normalCount = 0;
            changeCount = 0;
            if ( _DS != null && _DS.Tables.Count == 2 && _DS.Tables[0].Rows.Count > 0 )
            {
                normalCount = ToInt32( _DS.Tables[0].Rows[0]["totalrows0"] );//正常订单的总数
                changeCount = ToInt32( _DS.Tables[0].Rows[0]["totalrows1"] );//换货订单的总数
                _DS.Tables.RemoveAt( 0 );
            }
            return _DS;
        }
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
        public DataSet GetMemberCenterUserOrderList( int userID, int orderType, int orderState, DateTime beginTime, DateTime endTime, int FIdx, int EIdx, int isStat, int isCount, out int recordCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11758" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_orderType", orderType );
            Para.AddOrcNewInParameter( "i_orderState", orderState );
            Para.AddOrcNewInParameter( "i_startTime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_isStat", isStat );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result_detl" );
            Para.AddOrcNewCursorParameter( "o_result_stat" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getUserOrderListByUserid" );
            recordCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
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
        public DataSet GetUserWebPageRaffleList( int userID, int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13009" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_startTime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_iscount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_UserWeb.sp_getGetGoodsByUserID" );//pro_UserWebPageForUserRaffle
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
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
        public DataSet GetGoodsPeriodList( int goodsID, int codeID, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10302" );
            Para.AddOrcNewInParameter( "i_goodsid", goodsID );
            Para.AddOrcNewInParameter( "i_codeid", codeID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_apppageforphone.sp_getPeriodByGoodsID" );//pro_appPageForPeriodList
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion

        #region 获取商品详细页面所需数据
        /// <summary>
        /// 获取商品详细页面所需数据
        /// </summary>
        /// <param name="goodsID">商品ID号</param>
        /// <param name="codeID">条码ID号</param>
        /// <param name="retValue">返回值</param>
        /// <returns></returns>
        public DataSet GetGoodsDetailPageData( int goodsID, int codeID, out int retValue )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12204" );
            Para.AddOrcNewInParameter( "i_goodsID", goodsID );
            Para.AddOrcNewInParameter( "i_codeID", codeID );
            Para.AddOrcNewCursorParameter( "o_result1" );
            Para.AddOrcNewCursorParameter( "o_result_pid" );
            Para.AddOrcNewCursorParameter( "o_result_code" );
            Para.AddOrcNewCursorParameter( "o_result_goods" );
            Para.AddOrcNewCursorParameter( "o_result_bar" );
            Para.AddOrcNewCursorParameter( "o_result_pic" );
            Para.AddOrcNewCursorParameter( "o_result_buy" );
            //Para.AddOrcNewCursorParameter( "o_result_2" );
            //Para.AddOrcNewCursorParameter( "o_result_3" );
            //Para.AddOrcNewCursorParameter( "o_result_4" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getAllGoodsInfoByGoodsID" );//pro_PageForGoodsDetail
            retValue = GetOrcReturnValue( _DS );
            return _DS;
        }
        #endregion

        #region 获取云购即将完成的商品列表（即将开奖商品）
        /// <summary>
        /// 获取云购即将完成的商品列表（即将开奖商品）
        /// </summary>
        /// <param name="quantity">返回记录数量</param>
        /// <returns></returns>
        public DataSet GetRNOLastGoodsList( int quantity )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10410" );
            Para.AddOrcNewInParameter( "i_quantity", quantity );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_Barcode.sp_getHomeSoonLottery" );//pro_GetRNOLastGoodsList
        }
        #endregion

        #region 返回首页商品数据 lable（1：每日推荐2：精品推荐3：即将揭晓）
        /// <summary>
        /// 返回首页商品数据 lable（1：每日推荐2：精品推荐3：即将揭晓）
        /// </summary>
        /// <param name="lable"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public DataSet GetHomeGoodsByLabel( string lable, int quantity )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12213" );
            Para.AddOrcNewInParameter( "i_Label", lable );
            Para.AddOrcNewInParameter( "i_quantity", quantity );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getResumeOfHomeByLabel" );//pro_PageForHomeGoodsByLabel
        }
        #endregion

        #region 首页
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public DataSet GetHomePageData()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12212" );
            Para.AddOrcNewCursorParameter( "o_result_resu" );
            Para.AddOrcNewCursorParameter( "o_result_goods" );
            Para.AddOrcNewCursorParameter( "o_result_buy" );
            Para.AddOrcNewCursorParameter( "o_result_user" );
            Para.AddOrcNewCursorParameter( "o_result_regoods" );
            return Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getDataOfHomePage" );//pro_PageForHome
        }
        #endregion

        #region 返回首页推荐的商品
        /// <summary>
        /// 返回首页推荐的商品
        /// lable:12热门推荐，13新品上架
        /// </summary>
        /// <param name="goodsLabel"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public DataSet GetGoodsForHomeRecommend( int goodsLabel, int quantity )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11318" );
            Para.AddOrcNewInParameter( "i_goodsLabel", goodsLabel );
            Para.AddOrcNewInParameter( "i_quantity", quantity );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_Goods.sp_getHomeRecommendByLabel" );//pro_GoodsForHomeRecommend
        }
        #endregion

        #region 第三方商品比价模块
        /// <summary>
        /// 根据价格查看是否要添加第三方商品对照表的价格
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="goodsPrice">商品价格</param>
        /// <param name="supplier">第三方：1京东</param>
        /// <returns></returns>
        public int UpdateThirdGoodsPriceByID( int goodsID, decimal goodsPrice, int supplier )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13408" );
            Para.AddOrcNewInParameter( "i_GoodsID", goodsID );
            Para.AddOrcNewInParameter( "i_ThdGoodsPrice", goodsPrice );
            Para.AddOrcNewInParameter( "i_supplier", supplier );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_ZSys_Goods.f_modThirdGoodsPriceByID" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        /// <summary>
        /// 获取需要从第三方去下单的所有商品
        /// </summary>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public DataSet GetThirdGoodsList( int FIdx, int EIdx, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13410" );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_ZSys_Goods.sp_getThirdGoods" );
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
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
        public DataSet GetLimitBuyGoodsPage( int FIdx, int EIdx, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12219" );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_isCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getLimitBuyGoods" );
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }

        #endregion

        #region 收藏商品模块
        /// <summary>
        /// 用户添加收藏商品
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        public int InsertCollectGoodsByUserID( int userID, int goodsID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11753" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_goodsID", goodsID );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_MemberCenter.f_addCollectGoodsByUserID" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        /// <summary>
        /// 删除用户收藏的商品
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        public int DeleteCollectGoodsByUserID( int userID, int goodsID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11754" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_goodsID", goodsID );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_MemberCenter.f_delCollectGoodsByUserID" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        /// <summary>
        /// 删除用户的所有失效商品
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public int DeleteAllFailCollectGoodsByUserID( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11755" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_MemberCenter.f_delAllFailCollectByUserID" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        /// <summary>
        /// 分页获取用户收藏的商品
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总记录数</param>
        /// <returns></returns>
        public DataSet GetCollectGoodsByUserID( int userID, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11756" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_isCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getCollectGoodsByUserID" );
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        /// <summary>
        /// 检测用户是否有收藏某商品
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        public int CheckUserCollectGoods( int userID, int goodsID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11757" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_goodsID", goodsID );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_MemberCenter.f_chkCollectGoodsByUserID" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
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
        public DataSet GetPcGoodsPerioPagedList( int goodsID, int codeID, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12220" );
            Para.AddOrcNewInParameter( "i_goodsid", goodsID );
            Para.AddOrcNewInParameter( "i_codeid", codeID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getPCPeriodByGoodsID" );
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion

        #region 获取商品某期的期数信息
        /// <summary>
        /// 获取商品某期的期数信息
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="period">期数</param>
        /// <returns></returns>
        public DataSet GetGoodsBarcodeInfoByPeriod( int goodsID, int period )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12221" );
            Para.AddOrcNewInParameter( "i_goodsid", goodsID );
            Para.AddOrcNewInParameter( "i_period", period );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getCodeIDByGoodsID" );
        }
        #endregion

        #region 获取商品正在进行中的期数信息
        /// <summary>
        /// 获取商品正在进行中的期数信息
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        public DataSet GetSalingBarcodeInfoByGoodsID( int goodsID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11321" );
            Para.AddOrcNewInParameter( "i_GoodsID", goodsID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_Goods.sp_getCodeDetailByGoodsID" );
        }
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
        public DataSet GetBarcodeRaffListByGoodsID( int goodsID, int period, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13112" );
            Para.AddOrcNewInParameter( "i_goodsID", goodsID );
            Para.AddOrcNewInParameter( "i_period", period );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            Para.AddOrcNewCursorParameter( "o_result_buy" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_WXAuto.sp_getCodeListByGoodsID" );
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
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
        public DataTable GetNoDyAreaByGoodsID( int orderNO, int FIdx, int EIdx )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11323" );
            Para.AddOrcNewInParameter( "i_orderno", orderNO );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", 0 );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataTable _DT = Dal.ExecuteFillDataTable( "yun_Goods.sp_getNotDeAreaByGoodsID" );
            return _DT;
        }
        #endregion

        #region 获取手机APP主页新品推荐商品
        /// <summary>
        /// 获取手机APP主页新品推荐商品
        /// </summary>
        /// <param name="quantity">获取数量</param>
        /// <returns></returns>
        public DataSet appGetNewGoodsRecommand( int quantity )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10306" );
            Para.AddOrcNewInParameter( "i_quanity", quantity );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_apppageforphone.sp_getAppNewGoodsRec" );
        }
        #endregion

        #region 获取手机APP主页猜你喜欢商品
        /// <summary>
        /// 获取手机APP主页猜你喜欢商品
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="quantity">获取数量</param>
        /// <returns></returns>
        public DataSet appGetUserLikeGoods( int userID, int quantity )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10307" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_quanity", quantity );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_apppageforphone.sp_getAppUserLikeGoods" );
        }
        #endregion
        #region  web获取猜你喜欢商品12228
        /// <summary>
        /// web获取猜你喜欢商品12228
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="quantity">获取数量</param>
        /// <returns></returns>
        public DataSet GetGuessYouLikeGoods( int userID, int quantity )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12228" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_quanity", quantity );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getGuessYouLikeGoods" );
        }
        #endregion
        #region 获取手机APP最新揭晓
        /// <summary>
        /// 获取手机APP最新揭晓
        /// </summary>
        /// <param name="quanity">获取数量(最多20条)</param>
        /// <returns></returns>
        public DataSet appGetNewLottery( int quanity )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10308" );
            Para.AddOrcNewInParameter( "i_quanity", quanity );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_apppageforphone.sp_getAppNewLottery" );
        }
        #endregion
        #region 获取手机APP人气推荐
        /// <summary>
        /// 获取手机APP人气推荐
        /// </summary>
        /// <param name="quanity">获取数量(最多20条)</param>
        /// <returns></returns>
        public DataSet appGetPopGoodsRec( int quanity )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10309" );
            Para.AddOrcNewInParameter( "i_quanity", quanity );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_apppageforphone.sp_getAppPopGoodsRec" );
        }
        #endregion

        #region 获取手机APP某商品所有获得者
        /// <summary>
        /// 获取手机APP某商品所有获得者
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="maxPeriod">上限期数 0表示从最大期取数据</param>
        /// <param name="quantity">获取数量</param>
        /// <param name="totalCount">输出总数</param>
        /// <returns></returns>
        public DataSet appGetGoodsHistoryWinner( int goodsID, int maxPeriod, int quantity, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10310" );
            Para.AddOrcNewInParameter( "i_goodsid", goodsID );
            Para.AddOrcNewInParameter( "i_maxPeriod", maxPeriod );
            Para.AddOrcNewInParameter( "i_quanity", quantity );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_apppageforphone.sp_getAppHistyPeriod" );
            totalCount = GetOrcTotalCount( maxPeriod == 0 ? 1 : 0, _DS );
            return _DS;
        }
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
        public DataSet appGetGoodsHistoryWinner2( int goodsID, int maxPeriod, int quantity, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10313" );
            Para.AddOrcNewInParameter( "i_goodsid", goodsID );
            Para.AddOrcNewInParameter( "i_maxPeriod", maxPeriod );
            Para.AddOrcNewInParameter( "i_quanity", quantity );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_apppageforphone.sp_getAppHistyPeriod2" );
            totalCount = GetOrcTotalCount( maxPeriod == 0 ? 1 : 0, _DS );
            return _DS;
        }
        #endregion
        #region APP根据条码ID获取某用户的购买数量(用于商品详情页)
        /// <summary>
        /// APP根据条码ID获取某用户的购买数量(用于商品详情页)10311
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="codeID"></param>
        /// <returns></returns>
        public DataSet getBuyNumByUidCid( int userID, int codeID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10311" );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Para.AddOrcNewInParameter( "i_CodeID", codeID );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_apppageforphone.sp_getBuyNumByUidCid" );
            return _DS;
        }
        #endregion
        #region APP获取限购商品列表（新增排序功能）
        /// <summary>
        /// 获取限购商品列表（新增排序功能）10312
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
        public DataSet appGetLimitBuyGoods( int orderFlag, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10312" );
            Para.AddOrcNewInParameter( "i_OrderFlag", orderFlag );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_isCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_apppageforphone.sp_getAppLimitBuyGoods" );
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
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
        public int UpdateGoodsNameByGoodsID( int goodsID, string goodsName, string goodsSName, string goodsPic, int isCommit )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13435" );
            Para.AddOrcNewInParameter( "i_goodsid", goodsID );
            Para.AddOrcNewInParameter( "i_goodsname", goodsName );
            Para.AddOrcNewInParameter( "i_goodssname", goodsSName );
            Para.AddOrcNewInParameter( "i_goodspic", goodsPic );
            Para.AddOrcNewInParameter( "i_isCommit", isCommit );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_ZSys_Goods.f_modGoodsnameByGoodsID" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
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
        public int UpdateGoodsAltNameByGoodsID( int goodsID, string goodsAltName, string goodsPreName, string goodsKeywords, string goodsBriefed, string goodsRecDesc, int isCommit )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13436" );
            Para.AddOrcNewInParameter( "i_goodsid", goodsID );
            Para.AddOrcNewInParameter( "i_goodsaltname", goodsAltName );
            Para.AddOrcNewInParameter( "i_goodsprename", goodsPreName );
            Para.AddOrcNewInParameter( "i_goodskeywords", goodsKeywords );
            Para.AddOrcNewInParameter( "i_goodsbriefed", goodsBriefed );
            Para.AddOrcNewInParameter( "i_goodsrecdesc", goodsRecDesc );
            Para.AddOrcNewInParameter( "i_isCommit", isCommit );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_ZSys_Goods.f_modGoodsaltnameByGoodsID" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        #endregion

        #region 修改商品的详细介绍
        /// <summary>
        /// 修改商品的详细介绍
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="goodsDesc">商品详情</param>
        /// <param name="isCommit">提交方式，0：数据库提交，1：程序提交</param>
        /// <returns></returns>
        public int UpdateGoodsDescriptionByGoodsID( int goodsID, string goodsDesc, string goodsDescM, int isCommit )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13437" );
            Para.AddOrcNewInParameter( "i_goodsid", goodsID );
            Para.AddOrcNewInParameterEx( "i_goodsdescription", goodsDesc );
            Para.AddOrcNewInParameterEx( "i_goodsdescriptionm", goodsDescM );
            Para.AddOrcNewInParameter( "i_isCommit", isCommit );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_ZSys_Goods.f_modGoodsdescriptionByGoodsID" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        #endregion

        #region 修改商品的状态
        /// <summary>
        /// 修改商品的状态
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="goodsState">商品状态</param>
        /// <param name="isCommit">提交方式，0：数据库提交，1：程序提交</param>
        /// <returns></returns>
        public int UpdateGoodsStateByGoodsID( int goodsID, int goodsState, int isCommit )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13438" );
            Para.AddOrcNewInParameter( "i_goodsid", goodsID );
            Para.AddOrcNewInParameter( "i_goodsstate", goodsState );
            Para.AddOrcNewInParameter( "i_isCommit", isCommit );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_ZSys_Goods.f_modGoodsstateByGoodsID" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
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
        public int UpdateGoodsInfoByGoodsID( int goodsID, int isLimited, int limitNum, int editType, int goodsLabelStr, int isCommit )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13439" );
            Para.AddOrcNewInParameter( "i_goodsid", goodsID );
            Para.AddOrcNewInParameter( "i_islimited", isLimited );
            Para.AddOrcNewInParameter( "i_limitnum", limitNum );
            Para.AddOrcNewInParameter( "i_edittype", editType );
            Para.AddOrcNewInParameter( "i_goodslabelstr", goodsLabelStr );
            Para.AddOrcNewInParameter( "i_isCommit", isCommit );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_ZSys_Goods.f_modGoodstagByGoodsID" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        #endregion

        #region 同步上架其他字段信息(为后续扩展预留的接口)
        /// <summary>
        /// 同步上架其他字段信息(为后续扩展预留的接口)
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="spucode">spu编码</param>
        /// <param name="saleprice">销售价格</param>
        /// <param name="shelftype">上架类型:1 普通 2 促销 3 秒杀</param>
        /// <param name="signnote">签收注意事项</param>
        /// <param name="support">售后保障</param>
        /// <param name="isCommit">提交方式，0：数据库提交，1：程序提交</param>
        /// <returns></returns>
        public int UpdateGoodsOtherInfoByGoodsID( int goodsID, int goodsSortID, string spucode, decimal saleprice, int shelftype, string signnote, string support, int isOptSku, int isOptByStock, int isCommit )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13440" );
            Para.AddOrcNewInParameter( "i_goodsid", goodsID );
            Para.AddOrcNewInParameter( "i_goodssortid", goodsSortID );
            Para.AddOrcNewInParameter( "i_spucode", spucode );
            Para.AddOrcNewInParameter( "i_saleprice", saleprice );
            Para.AddOrcNewInParameter( "i_shelftype", shelftype );
            Para.AddOrcNewInParameter( "i_signnote", signnote );
            Para.AddOrcNewInParameter( "i_support", support );
            Para.AddOrcNewInParameter( "i_isoptsku", isOptSku );
            Para.AddOrcNewInParameter( "i_isoptbystock", isOptByStock );
            Para.AddOrcNewInParameter( "i_isCommit", isCommit );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_ZSys_Goods.f_modGoodInfoByGoodsID" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
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
        public int InsertGoodsInfo( int goodsID, string goodsName, int goodsSortID, int goodsState, string spuCode, decimal salePrice, int shelftype, string signnote, string support, int isOptSku, int goodsBrandID, int goodsLableID, int isOptByStock, int isNeedIMEI,int goodslabel, int isCommit )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13441" );
            Para.AddOrcNewInParameter( "i_goodsid", goodsID );
            Para.AddOrcNewInParameter( "i_goodsname", goodsName );
            Para.AddOrcNewInParameter( "i_goodssortid", goodsSortID );
            Para.AddOrcNewInParameter( "i_goodsstate", goodsState );
            Para.AddOrcNewInParameter( "i_spucode", spuCode );
            Para.AddOrcNewInParameter( "i_saleprice", salePrice );
            Para.AddOrcNewInParameter( "i_shelftype", shelftype );
            Para.AddOrcNewInParameter( "i_signnote", signnote );
            Para.AddOrcNewInParameter( "i_support", support );
            Para.AddOrcNewInParameter( "i_isoptsku", isOptSku );
            Para.AddOrcNewInParameter( "i_isoptbystock", isOptByStock );
            Para.AddOrcNewInParameter( "i_goodsBandID", goodsBrandID );
            Para.AddOrcNewInParameter( "i_goodslableid", goodsLableID );
            Para.AddOrcNewInParameter( "i_isneedimei", isNeedIMEI );
            Para.AddOrcNewInParameter( "i_goodslabelstr", goodslabel );
            Para.AddOrcNewInParameter( "i_isCommit", isCommit );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_ZSys_Goods.f_addGoodsInfo" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
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
        public int UpdateGoodsBrandLabelByGoodsID( string spuCode, int goodsBrandId, int goodsLabelId, int isNeedIMEI, int goodsLabelStr, int isCommit )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13442" );
            Para.AddOrcNewInParameter( "i_spucode", spuCode );
            Para.AddOrcNewInParameter( "i_goodsBandID", goodsBrandId );
            Para.AddOrcNewInParameter( "i_goodslableid", goodsLabelId );
            Para.AddOrcNewInParameter( "i_isneedimei", isNeedIMEI );
            Para.AddOrcNewInParameter( "i_goodslabelstr", goodsLabelStr );
            Para.AddOrcNewInParameter( "i_isCommit", isCommit );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_ZSys_Goods.f_modGoodBandByGoodsID" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
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
        public int AddGoodspic( int picID, int goodsID, string picName, string picRemark, int picHide, int picRank, int isCommit )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13443" );
            Para.AddOrcNewInParameter( "i_picid", picID );
            Para.AddOrcNewInParameter( "i_goodsID", goodsID );
            Para.AddOrcNewInParameter( "i_picName", picName );
            Para.AddOrcNewInParameter( "i_picRemark", picRemark );
            Para.AddOrcNewInParameter( "i_picHide", picHide );
            Para.AddOrcNewInParameter( "i_picRank", picRank );
            Para.AddOrcNewInParameter( "i_isCommit", isCommit );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_ZSys_Goods.f_addGoodspic" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
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
        public int ModGoodspicByPicID( int picID, int goodsID, string picName, string picRemark, int picHide, int picRank, int isCommit )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13444" );
            Para.AddOrcNewInParameter( "i_picid", picID );
            Para.AddOrcNewInParameter( "i_picgoodsid", goodsID );
            Para.AddOrcNewInParameter( "i_picname", picName );
            Para.AddOrcNewInParameter( "i_picRemark", picRemark );
            Para.AddOrcNewInParameter( "i_picHide", picHide );
            Para.AddOrcNewInParameter( "i_picrank", picRank );
            Para.AddOrcNewInParameter( "i_isCommit", isCommit );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_ZSys_Goods.f_modGoodspicByPicID" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        #endregion
        #region 删除商品展示图片记录(同步ERP系统yungou_sys.GoodsPic数据)13445
        /// <summary>
        /// 删除商品展示图片记录(同步ERP系统yungou_sys.GoodsPic数据)13445
        /// </summary>
        /// <param name="picID"></param>
        /// <param name="goodsID"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        public int DelGoodsPicByPicID( int picID, int goodsID, int isCommit )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13445" );
            Para.AddOrcNewInParameter( "i_picid", picID );
            Para.AddOrcNewInParameter( "i_goodsid", goodsID );
            Para.AddOrcNewInParameter( "i_isCommit", isCommit );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_ZSys_Goods.f_delGoodsPicByPicID" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        #endregion
        #region 刷新上架商品的更新时间
        /// <summary>
        /// 刷新上架商品的更新时间
        /// </summary>
        /// <param name="goodsID"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        public int UpdateGoodsUpdateTimeByGoodsID( int goodsID, int isCommit )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13447" );
            Para.AddOrcNewInParameter( "i_goodsid", goodsID );
            Para.AddOrcNewInParameter( "i_isCommit", isCommit );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_ZSys_Goods.f_modGoodsupdatetimeByGoodsID" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        #endregion
        #region 更新上架商品重量
        /// <summary>
        /// 更新上架商品重量
        /// </summary>
        /// <param name="goodsID"></param>
        /// <param name="goodsWeight"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        public int UpdateGoodsweightByGoodsID( int goodsID, decimal goodsWeight, int isCommit )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13448" );
            Para.AddOrcNewInParameter( "i_goodsid", goodsID );
            Para.AddOrcNewInParameter( "i_goodsweight", goodsWeight );
            Para.AddOrcNewInParameter( "i_isCommit", isCommit );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_ZSys_Goods.f_modGoodsweightByGoodsID" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        #endregion
        //===========ERP End===========
        #region 根据商品对应分类人气推荐，最多显示8个
        /// <summary>
        /// 根据商品对应分类人气推荐，最多显示8个
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        public DataSet GetHotSortGoodsIDByGID( int goodsID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11810" );
            Para.AddOrcNewInParameter( "i_goodsid", goodsID );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MPageForPhone.sp_getHotSortGoodsIDByGID" );
            return _DS;
        }
        #endregion
        #region 获取热门推荐商品
        /// <summary>
        /// 获取热门推荐商品
        /// </summary>
        /// <param name="quantity">获取数量</param>
        /// <returns></returns>
        public DataSet GetPopularGoods( int quantity )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11811" );
            Para.AddOrcNewInParameter( "i_quantity", quantity );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MPageForPhone.sp_getPopularGoods" );
            return _DS;
        }
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
        public DataSet mGetLimitBuyGoods( int orderFlag, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11812" );
            Para.AddOrcNewInParameter( "i_OrderFlag", orderFlag );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_isCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MPageForPhone.sp_getMLimitBuyGoods" );
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
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
        public DataSet GetGoodsListByNvgtID( int nvgtID, int brandID, int orderFlag, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12224" );
            Para.AddOrcNewInParameter( "i_nvgtid", nvgtID );
            Para.AddOrcNewInParameter( "i_brandID", brandID );
            Para.AddOrcNewInParameter( "i_OrderFlag", orderFlag );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            //Para.AddOrcNewInParameter( "i_isCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getGoodsListByNvgtID" );
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion
        #region 预览时跳转导航关联的有上架商品的品牌列表(新增导航)12225
        /// <summary>
        /// 预览时跳转导航关联的有上架商品的品牌列表12225
        /// </summary>
        /// <param name="nvgtID">导航ID</param>
        /// <returns></returns>
        public DataSet GetBrandListByNvgtID( int nvgtID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12225" );
            Para.AddOrcNewInParameter( "i_nvgtid", nvgtID );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getBrandListByNvgtID" );
            return _DS;
        }
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
        public DataSet GetPreviewGoodsList( int nvgtID, int brandID, int orderFlag, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12226" );
            Para.AddOrcNewInParameter( "i_nvgtid", nvgtID );
            Para.AddOrcNewInParameter( "i_brandID", brandID );
            Para.AddOrcNewInParameter( "i_OrderFlag", orderFlag );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            //Para.AddOrcNewInParameter( "i_isCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getPreviewGoodsList" );
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion
        #region 预览时跳转导航关联的有上架商品的品牌列表(新增导航_预览)12227
        /// <summary>
        /// 预览时跳转导航关联的有上架商品的品牌列表12227
        /// </summary>
        /// <param name="nvgtID">导航ID</param>
        /// <returns></returns>
        public DataSet GetPreviewBrandList( int nvgtID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12227" );
            Para.AddOrcNewInParameter( "i_nvgtid", nvgtID );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getPreviewBrandList" );
            return _DS;
        }
        #endregion
        #region 预览根据导航ID获取导航名称12229
        /// <summary>
        /// 预览根据导航ID获取导航名称12229
        /// </summary>
        /// <param name="nvgtID">导航ID</param>
        /// <returns></returns>
        public DataSet GetNvgNameByID( int nvgtID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12229" );
            Para.AddOrcNewInParameter( "i_nvgtid", nvgtID );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getNvgtInfoByID" );
            return _DS;
        }
        #endregion
        #region 预览根据导航ID获取导航名称12230
        /// <summary>
        /// 预览根据导航ID获取导航名称12230
        /// </summary>
        /// <param name="nvgtID">导航ID</param>
        /// <returns></returns>
        public DataSet GetPreNvgNameByID( int nvgtID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12230" );
            Para.AddOrcNewInParameter( "i_editNvgtid", nvgtID );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getEditNvgtInfoByID" );
            return _DS;
        }
        #endregion
        #region 返回活动推荐的商品
        /// <summary>
        /// 返回活动推荐的商品
        /// </summary>
        /// <param name="goodsLabel"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public DataSet GetActSpecByLabel( int goodsLabel, int quantity )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11325" );
            Para.AddOrcNewInParameter( "i_goodsLabel", goodsLabel );
            Para.AddOrcNewInParameter( "i_quantity", quantity );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_Goods.sp_getActSpecByLabel" );
        }
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
        public DataSet appGetMemberCenterUserRaffleList( int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int userID, int orderType, int isCount, out int normalCount, out int changeCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10316" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_orderType", orderType );
            Para.AddOrcNewInParameter( "i_startTime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result1" );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_apppageforphone.sp_getUserLotteryByUserid" );
            normalCount = 0;
            changeCount = 0;
            if ( _DS != null && _DS.Tables.Count == 2 && _DS.Tables[0].Rows.Count > 0 )
            {
                normalCount = ToInt32( _DS.Tables[0].Rows[0]["totalrows0"] );//正常订单的总数
                changeCount = ToInt32( _DS.Tables[0].Rows[0]["totalrows1"] );//换货订单的总数
                _DS.Tables.RemoveAt( 0 );
            }
            return _DS;
        }
        #endregion
    }
}
