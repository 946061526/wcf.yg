using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 获取所有揭晓记录12201
        /// <summary>
        /// 获取所有揭晓记录12201
        /// </summary>
        /// <param name="FIdx">开始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="totalCount">总记录数，不返回则为0</param>
        /// <returns></returns>
        public static DataSet GetBarcodeRaffleList( out int totalCount, params object[] para )
        {
            return GetBarcodeRaffleListEx( out totalCount, new object[] { para[0], para[1], 0, para[2] } );
        }

        #endregion
        #region 获取所有揭晓记录1220101
        /// <summary>
        /// 获取所有揭晓记录1220101
        /// </summary>
        /// <param name="FIdx">开始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="sortID">商品类别ID</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="totalCount">总记录数，不返回则为0</param>
        /// <returns></returns>
        public static DataSet GetBarcodeRaffleListEx( out int totalCount, params object[] para )
        {
            int FIdx = (int)para[0];
            int EIdx = (int)para[1];
            int sortID = (int)para[2];
            int isCount = (int)para[3];
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALBarcode _DAL = new DALBarcode();
                _DS = _DAL.GetBarcodeRaffleList( FIdx, EIdx, sortID, isCount, out totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Barcode.GetBarcodeRaffleList抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 限时揭晓12202
        /// <summary>
        /// 获取限时揭晓列表页数据12202
        /// </summary>
        /// <returns></returns>
        public static DataSet GetAutoLotteryList()
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
        #region 获取某分类下的品牌列表12203
        /// <summary>
        /// 获取某分类下的品牌列表12203
        /// </summary>
        /// <param name="sortID"></param>
        /// <returns></returns>
        public static DataSet GetBrandBySortID( params object[] para )
        {
            int sortID = (int)para[0];
            DataSet _DS = null;
            try
            {
                IDALBrand _DAL = new DALBrand();
                _DS = _DAL.GetBrandBySortID( sortID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Brand.GetBrandBySortID Exception:" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 获取商品详细页面所需数据12204
        /// <summary>
        /// 获取商品详细页面所需数据12204
        /// </summary>
        /// <param name="goodsID">商品ID号</param>
        /// <param name="codeID">条码ID号</param>
        /// <param name="retValue">返回值</param>
        /// <returns></returns>
        public static DataSet GetGoodsDetailPageData( out int retValue, params object[] para )
        {
            int goodsID = (int)para[0];
            int codeID = (int)para[1];
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
        #region 返回商品指定范围内的历史期数列表12206
        /// <summary>
        /// 返回商品指定范围内的历史期数列表12206
        /// (小于等于当前期数列表)
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="codePeriod">当前期数</param>
        /// <returns></returns>
        public static DataSet GetGoodsHistoryPeriod( params object[] para )
        {
            int goodsID = (int)para[0];
            int codePeriod = (int)para[1];
            DataSet _DS = null;
            try
            {
                IDALUserBuy _DAL = new DALUserBuy();
                _DS = _DAL.GetGoodsHistoryPeriod( goodsID, codePeriod );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "UserBuy.GetGoodsHistoryPeriod Exception:" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 获取商品列表12207
        /// <summary>
        /// 获取商品列表：前台商品列表页面12207
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
        public static DataSet GetGoodsPageList( out int totalCount, params object[] para )
        {
            int sortID = (int)para[0];
            int brandID = (int)para[1];
            int orderFlag = (int)para[2];
            int FIdx = (int)para[3];
            int EIdx = (int)para[4];
            int isCount = (int)para[5];
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
        #region 获取商品列表-搜索12208
        /// <summary>
        /// 获取商品列表：主要用于前台商品的列表页面(搜索)12208
        /// col:goodsID, goodsSName, goodsPic, codeID, codePrice, codeQuantity, codeSales
        /// </summary>
        /// <param name="keywords">搜索关键字</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="order">排序</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public static DataSet GetGoodsSearchList( out int totalCount, params object[] para )
        {
            string keywords = (string)para[0];
            int FIdx = (int)para[1];
            int EIdx = (int)para[2];
            int order = (int)para[3];
            int isCount = (int)para[4];
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
        #region 分页获取商品详细页的晒单列表记录[商品页调用]12209
        /// <summary>
        /// 分页获取商品详细页的晒单列表记录12209
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="isCount">是否统计总数</param>
        /// <returns>第一张表(晒单数，回复数)；第二张晒单记录</returns>
        public static DataSet GetPageForGoodsPostSingle( params object[] para )
        {
            int goodsID = (int)para[0];
            int FIdx = (int)para[1];
            int EIdx = (int)para[2];
            int isCount = (int)para[3];
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
        #region 分页获取商品详细页的晒单列表记录1220901
        /// <summary>
        /// 分页获取商品详细页的晒单列表记录1220901
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="FIdx">起始索引</param>
        /// <param name="EIdx">结束索引</param>
        /// <param name="isCount">是否统计总数</param>
        /// <returns>表1为统计数据，表2为记录</returns>
        public static DataSet mGetPageForGoodsPostSingle( params object[] para )
        {
            int goodsID = (int)para[0];
            int FIdx = (int)para[1];
            int EIdx = (int)para[2];
            int isCount = (int)para[3];
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
        #region 返回最近N条圈子话题动态信息12211
        /// <summary>
        /// 返回最近N条圈子话题动态信息12211
        /// </summary>
        /// <param name="msgID"></param>
        /// <param name="quanlity"></param>
        /// <returns></returns>
        public static DataSet GetGroupLastMsgForHome( params object[] para )
        {
            int msgID = (int)para[0];
            int quanlity = (int)para[1];
            DataSet _DS = null;
            try
            {
                IDALGroup _DAL = new DALGroup();
                _DS = _DAL.GetGroupLastMsgForHome( msgID, quanlity );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Group.GetGroupLastMsgForHome Exception:" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 首页12212
        /// <summary>
        /// 首页12212
        /// </summary>
        /// <returns></returns>
        public static DataSet GetHomePageData()
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
        #region 返回首页商品数据 lable（1：每日推荐2：精品推荐3：即将揭晓）12213
        /// <summary>
        /// 返回首页商品数据 lable（1：每日推荐2：精品推荐3：即将揭晓）12213
        /// </summary>
        /// <param name="lable"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public static DataSet GetHomeGoodsByLabel( params object[] para )
        {
            string lable = (string)para[0];
            int quantity = (int)para[1];
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
        #region 获取大于云购ID的云购信息12215
        /// <summary>
        /// 获取大于云购ID的云购信息12215
        /// </summary>
        /// <param name="buyid"></param>
        /// <returns></returns>
        public static DataSet GetUserBuyNewList( params object[] para )
        {
            int buyid = (int)para[0];
            DataSet _DS = null;
            try
            {
                IDALUserBuy _DAL = new DALUserBuy();
                _DS = _DAL.GetUserBuyNewList( buyid );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "UserBuy.GetUserBuyNewList抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 获取4条最新揭晓记录12217
        /// <summary>
        /// 获取4条最新揭晓记录12217
        /// </summary>
        /// <returns></returns>
        public static DataSet GetRecentlyRaffleList()
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
        #region 获取最近的N个等待开奖数据12218
        /// <summary>
        /// 获取最近的N个等待开奖数据12218
        /// </summary>
        /// <param name="time">起始时间</param>
        /// <param name="quantity">获取记录数</param>
        /// <returns></returns>
        public static DataSet GetStartRaffleGoodsList( params object[] para )
        {
            DateTime time = (DateTime)para[0];
            int quantity = (int)para[1];
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
        #region 限购模块12219

        /// <summary>
        /// 分页获取限购商品列表12219
        /// </summary>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总记录数</param>
        /// <returns></returns>
        public static DataSet GetLimitBuyGoodsPage( out int totalCount, params object[] para )
        {
            int FIdx = (int)para[0];
            int EIdx = (int)para[1];
            int isCount = (int)para[2];
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
        #region PC分页获取商品期数列表12220
        /// <summary>
        /// PC分页获取商品期数列表12220
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="codeID">期数ID</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总记录数</param>
        /// <returns></returns>
        public static DataSet GetPcGoodsPerioPagedList( out int totalCount, params object[] para )
        {
            int goodsID = (int)para[0];
            int codeID = (int)para[1];
            int FIdx = (int)para[2];
            int EIdx = (int)para[3];
            int isCount = (int)para[4];
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
        #region 获取商品某期的期数信息12221
        /// <summary>
        /// 获取商品某期的期数信息12221
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="period">期数</param>
        /// <returns></returns>
        public static DataSet GetGoodsBarcodeInfoByPeriod( params object[] para )
        {
            int goodsID = (int)para[0];
            int period = (int)para[1];
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
        #region 获取商品列表(新增导航)12224
        /// <summary>
        /// 获取商品列表(新增导航)12224
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
        public static DataSet GetGoodsListByNvgtID( out int totalCount, params object[] para )
        {
            int nvgtID = (int)para[0];
            int brandID = (int)para[1];
            int orderFlag = (int)para[2];
            int FIdx = (int)para[3];
            int EIdx = (int)para[4];
            int isCount = (int)para[5];
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetGoodsListByNvgtID( nvgtID, brandID, orderFlag, FIdx, EIdx, isCount, out totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.GetPreviewGoodsList抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 预览时跳转导航关联的有上架商品的品牌列表(新增导航)12225
        /// <summary>
        /// 预览时跳转导航关联的有上架商品的品牌列表12225
        /// </summary>
        /// <param name="nvgtID">导航ID</param>
        /// <returns></returns>
        public static DataSet GetBrandListByNvgtID( params object[] para )
        {
            int nvgtID = (int)para[0];
            DataSet _DS = null;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetBrandListByNvgtID( nvgtID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.GetPreviewBrandList抛出异常：" + ex.Message );
            }
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
        public static DataSet GetPreviewGoodsList( out int totalCount, params object[] para )
        {
            int nvgtID = (int)para[0];
            int brandID = (int)para[1];
            int orderFlag = (int)para[2];
            int FIdx = (int)para[3];
            int EIdx = (int)para[4];
            int isCount = (int)para[5];
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetPreviewGoodsList( nvgtID, brandID, orderFlag, FIdx, EIdx, isCount, out totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.GetPreviewGoodsList抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 预览时跳转导航关联的有上架商品的品牌列表(新增导航_预览)12227
        /// <summary>
        /// 预览时跳转导航关联的有上架商品的品牌列表12227
        /// </summary>
        /// <param name="nvgtID">导航ID</param>
        /// <returns></returns>
        public static DataSet GetPreviewBrandList( params object[] para )
        {
            int nvgtID = (int)para[0];
            DataSet _DS = null;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetPreviewBrandList( nvgtID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.GetPreviewBrandList抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region web获取猜你喜欢商品12228
        /// <summary>
        /// web获取猜你喜欢商品12228
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="quantity">获取数量</param>
        /// <returns></returns>
        public static DataSet GetGuessYouLikeGoods( params object[] para )
        {
            int userID = (int)para[0];
            int quantity = (int)para[1];
            DataSet _DS = null;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetGuessYouLikeGoods( userID, quantity );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.GetGuessYouLikeGoods抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 根据导航ID获取导航名称12229
        /// <summary>
        /// 根据导航ID获取导航名称12229
        /// </summary>
        /// <param name="nvgtID">导航ID</param>
        /// <returns></returns>
        public static DataSet GetNvgNameByID( params object[] para )
        {
            int nvgtID = (int)para[0];
            DataSet _DS = null;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetNvgNameByID( nvgtID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Execute122.GetNvgNameByID抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 预览根据导航ID获取导航名称12230
        /// <summary>
        /// 预览根据导航ID获取导航名称12230
        /// </summary>
        /// <param name="nvgtID">导航ID</param>
        /// <returns></returns>
        public static DataSet GetPreNvgNameByID( params object[] para )
        {
            int nvgtID = (int)para[0];
            DataSet _DS = null;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetPreNvgNameByID( nvgtID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Execute122.GetPreNvgNameByID抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 微信导航展板获取12231
        /// <summary>
        /// 微信导航展板获取12231
        /// </summary>
        /// <returns></returns>
        public static DataSet GetWeChatNvgtion()
        {
            DataSet _DS = null;
            try
            {
                IDALWeixin _DAL = new DALWeixin();
                _DS = _DAL.GetWeChatNvgtion();
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Execute122.GetWeChatNvgtion抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion
    }
}
