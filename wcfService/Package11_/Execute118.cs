using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {

        #region 获取限时揭晓列表页数据11801
        /// <summary>
        /// 获取限时揭晓列表页数据11801
        /// </summary>
        /// <returns></returns>
        public static DataSet mGetAutoLotteryList()
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
                UtilityFile.AddLogErrMsg( "Goods.mGetAutoLotteryList抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 获取商品详细页面所需数据11802
        /// <summary>
        /// 获取商品详细页面所需数据11802
        /// </summary>
        /// <param name="goodsID">商品ID号</param>
        /// <param name="codeID">条码ID号</param>
        /// <param name="retValue">返回值:1 正常返回数据; -1 不在此商品数据; -2 已满员或已揭晓，跳转至揭晓页面</param>
        /// <returns></returns>
        public static DataSet mGetGoodsDetailPageData( out int retValue, params object[] para )
        {
            int goodsID = (int)para[0];
            int codeID = (int)para[1];
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
        #region 获取商品的某期的所有云购记录11803/12205
        /// <summary>
        /// 获取商品的某期的所有云购记录11803/12205
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <param name="FIdx">开始记录编号</param>
        /// <param name="EIdx">结束记录编号</param>
        /// <param name="sortType">排序方式：0倒序  1正序</param>
        /// <param name="isCount">是否统计总记录数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public static DataSet GetUserBuyListByBarcode( out int totalCount, params object[] para )
        {
            int codeID = (int)para[0];
            int FIdx = (int)para[1];
            int EIdx = (int)para[2];
            int sortType = (int)para[3];
            int isCount = (int)para[4];
            DataSet _DS = null;
            totalCount = 0;
            if ( codeID > 0 )
            {
                try
                {
                    IDALUserBuy _DAL = new DALUserBuy();
                    if ( sortType == 0 )
                    {
                        //判断是否从DG库查询
                        bool _UseDG = IsDGUserBuyListByBarcode( codeID );

                        _DS = _DAL.GetUserBuyListByBarcodeDesc( codeID, FIdx, EIdx, isCount, _UseDG, out totalCount );
                    }
                    else
                    {
                        _DS = _DAL.GetUserBuyListByBarcodeAsc( codeID, FIdx, EIdx, isCount, out totalCount );
                    }
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserBuy.GetUserBuyListByBarcode抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
        #region 获取手机版首页数据11805
        /// <summary>
        /// 获取手机版首页数据11805
        /// </summary>
        /// <returns>返回两张表：0今天限时；1热门推荐；</returns>
        public static DataSet mGetHomePage()
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
        #region 分页获取晒单列表11806
        /// <summary>
        /// 分页获取晒单列表11806
        /// </summary>
        /// <param name="FIdx">开始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="order">排序方式(10最新，20人气，30评论)</param>
        /// <param name="isCount">是否统计总记录数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public static DataSet mGetPostSinglePageList( out int totalCount, params object[] para )
        {
            int FIdx = (int)para[0];
            int EIdx = (int)para[1];
            int order = (int)para[2];
            int isCount = (int)para[3];
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
        #region 手机版获得最新揭晓详情信息11807

        /// <summary>
        /// 手机版获得最新揭晓详情信息11807
        /// </summary>
        /// <param name="codeId">条码ID</param>
        /// <param name="retVal">1正常，-1本条码为正在进行中的状态</param>
        /// <returns></returns>
        public static DataSet mGetRaffleBaseInfo( out int retVal, params object[] para )
        {
            int codeId = (int)para[0];
            DataSet _DS = null;
            retVal = 0;
            if ( codeId > 0 )
            {
                try
                {
                    IDALBarcode _DAL = new DALBarcode();
                    _DS = _DAL.mGetRaffleBaseInfo( codeId, out retVal );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Barcode.mGetRaffleBaseInfo抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
        #region 手机版个人主页获取会员晒单11808
        /// <summary>
        /// 手机版个人主页获取会员晒单11808
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public static DataSet mGetUserWebPagePostList( out int totalCount, params object[] para )
        {
            int userID = (int)para[0];
            int FIdx = (int)para[1];
            int EIdx = (int)para[2];
            DateTime _BeginTime = (DateTime)para[3];
            DateTime _EndTime = (DateTime)para[4];
            int isCount = (int)para[5];
            DataSet _DS = null;
            totalCount = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALPostSingle _DAL = new DALPostSingle();
                    _DS = _DAL.mGetUserWebPagePostList( userID, FIdx, EIdx, _BeginTime, _EndTime, isCount, out totalCount );
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

        #region 获取商品条码的介绍详情【房产】

        #region 获取商品条码的介绍详情【房产】
        /// <summary>
        /// 获取商品条码的介绍详情【房产】
        /// </summary>
        /// <param name="codeID">期数ID</param>
        /// <returns></returns>
        public static DataSet GetBarcodeDescByCodeID( params object[] para )
        {
            int _CodeID = (int)para[0];
            IDALBarcode _DAL = new DALBarcode();
            DataSet _DS = _DAL.GetBarcodeDescByCodeID( _CodeID );
            _DAL = null;
            return _DS;
        }
        #endregion
        #endregion

        #region 根据商品对应分类人气推荐，最多显示8个11810
        /// <summary>
        /// 根据商品对应分类人气推荐，最多显示8个11810
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        public static DataSet GetHotSortGoodsIDByGID( params object[] para )
        {
            int goodsID = (int)para[0];
            DataSet _DS = null;
            if ( goodsID > 0)
            {
                try
                {
                    IDALGoods _DAL = new DALGoods();
                    _DS = _DAL.GetHotSortGoodsIDByGID( goodsID);
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Goods.GetHotSortGoodsIDByGID抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
        #region 获取热门推荐商品11811
        /// <summary>
        /// 获取热门推荐商品11811
        /// </summary>
        /// <param name="quantity">获取数量</param>
        /// <returns></returns>
        public static DataSet GetPopularGoods( params object[] para )
        {
            int quantity = (int)para[0];
            DataSet _DS = null;
            if ( quantity > 0 )
            {
                try
                {
                    IDALGoods _DAL = new DALGoods();
                    _DS = _DAL.GetPopularGoods( quantity );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Goods.GetPopularGoods抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
        #region 微信触屏获取商品某期的期数信息11812
        /// <summary>
        /// 获取限购商品列表（新增排序功能）
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public static DataSet mGetLimitBuyGoods( out int totalCount, params object[] para )
        {
            int orderFlag = (int)para[0];
            int FIdx = (int)para[1];
            int EIdx = (int)para[2];
            int isCount = (int)para[3];
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.mGetLimitBuyGoods( orderFlag, FIdx, EIdx, isCount, out totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.mGetLimitBuyGoods Ex:" + ex.Message );
            }
            return _DS;
        }
        #endregion
    }
}
