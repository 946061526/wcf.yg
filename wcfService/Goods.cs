using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class WCFServiceFun
    {
        #region 获取手机版首页数据
        /// <summary>
        /// 获取手机版首页数据
        /// </summary>
        /// <returns>返回两张表：0今天限时；1热门推荐；</returns>
        public DataSet mGetHomePage()
        {
            DataSet _DS = null;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.mGetHomePage();
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.mGetHomePage抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region 获取手机版首页数据
        /// <summary>
        /// 获取手机版首页数据
        /// </summary>
        /// <returns>返回3张表：0最新揭晓；1人气推荐6个；2推荐的晒单分享</returns>
        public DataSet appGetHomePage()
        {
            DataSet _DS = null;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.appGetHomePage();
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.appGetHomePage抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region 获取最近的N个等待开奖数据
        /// <summary>
        /// 获取最近的N个等待开奖数据
        /// </summary>
        /// <param name="time">起始时间</param>
        /// <param name="quantity">获取记录数</param>
        /// <returns></returns>
        public DataSet GetStartRaffleGoodsList( DateTime time, int quantity )
        {
            DataSet _DS = null;
            if ( quantity > 0 )
            {
                try
                {
                    IDALGoods _DAL = new DALGoods();
                    _DS = _DAL.GetStartRaffleList( time, quantity );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Goods.GetStartRaffleGoodsList抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 限时揭晓
        /// <summary>
        /// 获取限时揭晓列表页数据
        /// </summary>
        /// <returns></returns>
        public DataSet mGetAutoLotteryList()
        {
            DataSet _DS = null;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.mGetAutoLotteryList();
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.GetAutoLotteryList抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region 限时揭晓
        /// <summary>
        /// 获取限时揭晓列表页数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetAutoLotteryList()
        {
            DataSet _DS = null;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetAutoLotteryList();
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.GetAutoLotteryList Exception:" + ex.Message );
            }
            return _DS;
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
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetGoodsPageList( sortID, brandID, orderFlag, FIdx, EIdx, isCount, out totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.GetGoodsPageList抛出异常：" + ex.Message );
            }
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
            DataSet _DS = null;
            totalCount = 0;
            if ( FIdx > 0 && EIdx > FIdx )
            {
                try
                {
                    IDALGoods _DAL = new DALGoods();
                    _DS = _DAL.GetGoodsSearchList( keywords, FIdx, EIdx, order, isCount, out totalCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Goods.GetGoodsSearchList 抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 获取商品详细页面所需数据
        /// <summary>
        /// 获取商品详细页面所需数据
        /// </summary>
        /// <param name="goodsID">商品ID号</param>
        /// <param name="codeID">条码ID号</param>
        /// <param name="retValue">返回值:1 正常返回数据; -1 不在此商品数据; -2 已满员或已揭晓，跳转至揭晓页面</param>
        /// <returns></returns>
        public DataSet appGetGoodsDetailPageData( int goodsID, int codeID, out int retValue )
        {
            DataSet _DS = null;
            retValue = -1;
            if ( goodsID > 0 || codeID > 0 )
            {
                try
                {
                    IDALGoods _DAL = new DALGoods();
                    _DS = _DAL.appGetGoodsDetailPageData( goodsID, codeID, out retValue );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Goods.appGetGoodsDetailPageData抛出异常：" + ex.Message );
                }
            }
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
            DataSet _DS = null;
            retValue = -1;
            if ( goodsID > 0 || codeID > 0 )
            {
                try
                {
                    IDALGoods _DAL = new DALGoods();
                    _DS = _DAL.mGetGoodsDetailPageData( goodsID, codeID, out retValue );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Goods.mGetGoodsDetailPageData抛出异常：" + ex.Message );
                }
            }
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
            DataSet _DS = null;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetRecentlyRaffleList();
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.GetRecentlyRaffleList抛出异常：" + ex.Message );
            }
            return _DS;
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
            DataSet _DS = null;
            if ( goodsID > 0 )
            {
                try
                {
                    IDALGoods _DAL = new DALGoods();
                    _DS = _DAL.GetGoodsInfoByID( goodsID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Goods.GetGoodsInfoByID抛出异常：" + ex.Message );
                }
            }
            return _DS;
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
            DataSet _DS = null;
            if ( codeID > 0 )
            {
                try
                {
                    IDALGoods _DAL = new DALGoods();
                    _DS = _DAL.GetGoodsBarcodeInfo( codeID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Goods.GetGoodsBarcodeInfo抛出异常：" + ex.Message );
                }
            }
            return _DS;
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
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">总记录数</param>
        /// <returns></returns>
        public DataSet GetMemberCenterUserRaffleList( int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int userID, int isCount, out int count )
        {
            int _ChangeCount = 0;
            return GetMemberCenterUserRaffleListEx( FIdx, EIdx, beginTime, endTime, userID, 0, isCount, out  count, out _ChangeCount );
        }
        /// <summary>
        /// 会员中心-中奖的商品列表
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userID">会员ID</param>
        /// <param name="orderType">订单类型: 1.换货订单，0.正常订单</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="normalCount">正常订单总数</param>
        /// <param name="changeCount">换货订单总数</param>
        /// <returns></returns>
        public DataSet GetMemberCenterUserRaffleListEx( int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int userID, int orderType, int isCount, out int normalCount, out int changeCount )
        {
            DataSet _DS = null;
            normalCount = 0;
            changeCount = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALGoods _DAL = new DALGoods();
                    _DS = _DAL.GetMemberCenterUserRaffleList( FIdx, EIdx, beginTime, endTime, userID, orderType, isCount, out  normalCount, out  changeCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Goods.GetMemberCenterUserRaffleListEx抛出异常：" + ex.Message );
                }
            }
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
        public DataSet GetUserWebPageRaffleList( int userID, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALGoods _DAL = new DALGoods();
                    _DS = _DAL.GetUserWebPageRaffleList( userID, FIdx, EIdx, UtilityFun.ToDateTime( "2010-01-01" ), DateTime.Now, isCount, out totalCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Goods.GetUserWebPageRaffleList抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 获取商品所有期数列表
        /// <summary>
        /// 获取商品所有期数列表
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="codeID">条码ID</param>
        /// <returns></returns>
        public DataSet GetGoodsPeriodList( int goodsID, int codeID )
        {
            DataSet _DS = null;
            if ( goodsID > 0 || codeID > 0 )
            {
                int _Count = 0;
                _DS = GetGoodsPeriodPageList( goodsID, codeID, 1, int.MaxValue, 0, out  _Count );
            }
            return _DS;
        }
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
        public DataSet GetGoodsPeriodPageList( int goodsID, int codeID, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            if ( goodsID > 0 || codeID > 0 )
            {
                try
                {
                    IDALGoods _DAL = new DALGoods();
                    _DS = _DAL.GetGoodsPeriodList( goodsID, codeID, FIdx, EIdx, isCount, out  totalCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Goods.GetGoodsPeriodPageList抛出异常：" + ex.Message );
                }
            }
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
            DataSet _DS = null;
            retValue = 0;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetGoodsDetailPageData( goodsID, codeID, out retValue );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.GetGoodsDetailPageData Exception:" + ex.Message );
            }
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
            DataSet _DS = null;
            if ( quantity > 0 )
            {
                try
                {
                    IDALGoods _DAL = new DALGoods();
                    _DS = _DAL.GetRNOLastGoodsList( quantity );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Goods.GetRNOLastGoodsList Exception:" + ex.Message );
                }
            }
            return _DS;
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
            DataSet _DS = null;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetHomeGoodsByLabel( lable, quantity );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.GetHomeGoodsByLabel Exception:" + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region 首页
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public DataSet GetHomePageData()
        {
            DataSet _DS = null;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetHomePageData();
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.HomePage Exception:" + ex.Message );
            }
            return _DS;
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
            DataSet _DS = null;
            if ( quantity > 0 )
            {
                try
                {
                    IDALGoods _DAL = new DALGoods();
                    _DS = _DAL.GetGoodsForHomeRecommend( goodsLabel, quantity );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Goods.GetGoodsForHomeRecommend Exception:" + ex.Message );
                }
            }
            return _DS;
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
            int _Ret = 0;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _Ret = _DAL.UpdateThirdGoodsPriceByID( goodsID, goodsPrice, supplier );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.UpdateThirdGoodsPriceByID Exception:" + ex.Message );
            }
            return _Ret;
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
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetThirdGoodsList( FIdx, EIdx, isCount, out  totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.GetThirdGoodsList Exception:" + ex.Message );
            }
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
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetLimitBuyGoodsPage( FIdx, EIdx, isCount, out totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.GetLimitBuyGoodsPage Ex:" + ex.Message );
            }
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
            int _Result = 0;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _Result = _DAL.InsertCollectGoodsByUserID( userID, goodsID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.InsertCollectGoodsByUserID Ex:" + ex.Message );
            }
            return _Result;
        }
        /// <summary>
        /// 删除用户收藏的商品
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        public int DeleteCollectGoodsByUserID( int userID, int goodsID )
        {
            int _Result = 0;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _Result = _DAL.DeleteCollectGoodsByUserID( userID, goodsID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.DeleteCollectGoodsByUserID Ex:" + ex.Message );
            }
            return _Result;
        }
        /// <summary>
        /// 删除用户的所有失效商品
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public int DeleteAllFailCollectGoodsByUserID( int userID )
        {
            int _Result = 0;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _Result = _DAL.DeleteAllFailCollectGoodsByUserID( userID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.DeleteAllFailCollectGoodsByUserID Ex:" + ex.Message );
            }
            return _Result;
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
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetCollectGoodsByUserID( userID, FIdx, EIdx, isCount, out totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.GetCollectGoodsByUserID Ex:" + ex.Message );
            }
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
            int _Result = 0;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _Result = _DAL.CheckUserCollectGoods( userID, goodsID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.CheckUserCollectGoods Ex:" + ex.Message );
            }
            return _Result;
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
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetPcGoodsPerioPagedList( goodsID, codeID, FIdx, EIdx, isCount, out totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.GetGoodsPeriodListPage Ex:" + ex.Message );
            }
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
            DataSet _DS = null;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetGoodsBarcodeInfoByPeriod( goodsID, period );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.GetGoodsBarcodeInfoByPeriod Ex:" + ex.Message );
            }
            return _DS;
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
            DataSet _DS = null;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetSalingBarcodeInfoByGoodsID( goodsID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.GetSalingBarcodeInfoByGoodsID Ex:" + ex.Message );
            }
            return _DS;
        }
        #endregion
    }
}
