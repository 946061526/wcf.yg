using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 获取商品详细页面所需数据10301
        /// <summary>
        /// 获取商品详细页面所需数据10301
        /// </summary>
        /// <param name="goodsID">商品ID号</param>
        /// <param name="codeID">条码ID号</param>
        /// <param name="retValue">返回值:1 正常返回数据; -1 不在此商品数据; -2 已满员或已揭晓，跳转至揭晓页面</param>
        /// <returns></returns>
        public static DataSet appGetGoodsDetailPageData( out int retValue, params object[] para )
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
        #endregion
        #region 获取商品所有期数列表10302/1030201
        /// <summary>
        /// 获取商品所有期数列表1030201
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="codeID">条码ID</param>
        /// <returns></returns>
        public static DataSet GetGoodsPeriodList( params object[] para )
        {
            int goodsID = (int)para[0];
            int codeID = (int)para[1];
            DataSet _DS = null;
            if ( goodsID > 0 || codeID > 0 )
            {
                int _Count = 0;
                _DS = GetGoodsPeriodPageList( out _Count, goodsID, codeID, 1, int.MaxValue, 0 );
            }
            return _DS;
        }
        /// <summary>
        /// 分页获取商品所有期数列表10302
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="codeID">条码ID</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总数量</param>
        /// <returns></returns>
        public static DataSet GetGoodsPeriodPageList( out int totalCount, params object[] para )
        {

            int goodsID = (int)para[0];
            int codeID = (int)para[1];
            int FIdx = (int)para[2];
            int EIdx = (int)para[3];
            int isCount = (int)para[4];
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
        #region 手机版获得最新揭晓详情信息10303
        /// <summary>
        /// 手机版获得最新揭晓详情信息10303
        /// </summary>
        /// <param name="codeId">条码ID</param>
        /// <param name="retVal">1正常，-1本条码为正在进行中的状态</param>
        /// <returns></returns>
        public static DataSet appGetRaffleBaseInfo( out int retVal, params object[] para )
        {
            int codeId = (int)para[0];
            DataSet _DS = null;
            retVal = 0;
            if ( codeId > 0 )
            {
                try
                {
                    IDALBarcode _DAL = new DALBarcode();
                    _DS = _DAL.appGetRaffleBaseInfo( codeId, out retVal );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Barcode.appGetRaffleBaseInfo抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
        #region 手机版计算结果页：中奖条码揭晓信息10304
        /// <summary>
        /// 手机版计算结果页：中奖条码揭晓信息10304
        /// </summary>
        /// <param name="codeID"></param>
        /// <returns></returns>
        public static DataSet mGetBarcodeLotteryInfo( params object[] para )
        {
            int codeID = (int)para[0];
            DataSet _DS = null;
            if ( codeID > 0 )
            {
                try
                {
                    IDALBarcode _DAL = new DALBarcode();
                    _DS = _DAL.mGetBarcodeLotteryInfo( codeID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Barcode.mGetBarcodeLotteryInfo" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
        #region 获取手机版首页数据10305
        /// <summary>
        /// 获取手机版首页数据10305
        /// </summary>
        /// <returns>返回3张表：0最新揭晓；1人气推荐6个；2推荐的晒单分享</returns>
        public static DataSet appGetHomePage()
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
        #region 获取手机APP主页新品推荐商品10306
        /// <summary>
        /// 获取手机APP主页新品推荐商品
        /// </summary>
        /// <param name="quantity">获取数量</param>
        /// <returns></returns>
        public static DataSet appGetNewGoodsRecommand( object[] para )
        {
            DataSet _DS = null;
            try
            {
                int _Quantity = (int)para[0];
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.appGetNewGoodsRecommand( _Quantity );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.appGetNewGoodsRecommand抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 获取手机APP主页猜你喜欢商品10307
        /// <summary>
        /// 获取手机APP主页猜你喜欢商品
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="quantity">获取数量</param>
        /// <returns></returns>
        public static DataSet appGetUserLikeGoods( object[] para )
        {
            DataSet _DS = null;
            try
            {
                int _UserID = (int)para[0];
                int _Quantity = (int)para[1];
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.appGetUserLikeGoods( _UserID, _Quantity );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.appGetUserLikeGoods抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 获取手机APP最新揭晓10308
        /// <summary>
        /// 获取手机APP最新揭晓
        /// </summary>
        /// <param name="quanity">获取数量(最多20条)</param>
        /// <returns></returns>
        public static DataSet appGetNewLottery( object[] para )
        {
            DataSet _DS = null;
            try
            {
                int _Quantity = (int)para[0];
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.appGetNewLottery( _Quantity );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.appGetNewLottery抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 获取手机APP人气推荐10309
        /// <summary>
        /// 获取手机APP人气推荐
        /// </summary>
        /// <param name="quanity">获取数量(最多20条)</param>
        /// <returns></returns>
        public static DataSet appGetPopGoodsRec( object[] para )
        {
            DataSet _DS = null;
            try
            {
                int _Quantity = (int)para[0];
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.appGetPopGoodsRec( _Quantity );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.appGetPopGoodsRec抛出异常：" + ex.Message );
            }
            return _DS;
        }
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
        public static DataSet appGetGoodsHistoryWinner( out int totalCount, params object[] para )
        {
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                int _GoodsID = (int)para[0];
                int _MaxPeriod = (int)para[1];
                int _Quantity = (int)para[2];
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.appGetGoodsHistoryWinner( _GoodsID, _MaxPeriod, _Quantity, out totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.appGetGoodsHistoryWinner抛出异常：" + ex.Message );
            }
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
        public static DataSet appGetGoodsHistoryWinner2( out int totalCount, params object[] para )
        {
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                int _GoodsID = (int)para[0];
                int _MaxPeriod = (int)para[1];
                int _Quantity = (int)para[2];
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.appGetGoodsHistoryWinner2( _GoodsID, _MaxPeriod, _Quantity, out totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.appGetGoodsHistoryWinner抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region APP根据条码ID获取某用户的购买数量(用于商品详情页)
        /// <summary>
        /// APP根据条码ID获取某用户的购买数量(用于商品详情页)
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="codeID"></param>
        /// <returns></returns>
        public static DataSet getBuyNumByUidCid( params object[] para )
        {
            DataSet _DS = null;
            try
            {
                int _UserID = (int)para[0];
                int _CodeID = (int)para[1];
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.getBuyNumByUidCid( _UserID, _CodeID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.getBuyNumByUidCid抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region 获取商品某期的期数信息10312
        /// <summary>
        /// 获取限购商品列表（新增排序功能）
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public static DataSet appGetLimitBuyGoods( out int totalCount, params object[] para )
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
                _DS = _DAL.appGetLimitBuyGoods( orderFlag, FIdx, EIdx, isCount, out totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.appGetLimitBuyGoods Ex:" + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region app会员中心-我的云购记录分页列表10315
        /// <summary>
        /// app会员中心-我的云购记录分页列表10315
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="state">状态</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userid">会员ID</param>
        /// <param name="keyWords">关键字</param>
        /// <param name="count">返回总记录数</param>
        /// <returns></returns>
        public static DataSet appGetMemberCenterBuyList( out int count, params object[] para )
        {
            DataSet _DS = null;
            count = 0;
            int _FIdx = (int)para[0];
            int _EIdx = (int)para[1];
            int _State = (int)para[2];
            DateTime _BeginTime = (DateTime)para[3];
            DateTime _EndTime = (DateTime)para[4];
            int _UserID = (int)para[5];
            int _IsCount = (int)para[6];
            if ( _UserID > 0 )
            {
                IDALUserBuy _DAL = new DALUserBuy();
                _DS = _DAL.appGetMemberCenterBuyList( _FIdx, _EIdx, _State, _BeginTime, _EndTime, _UserID, _IsCount, out count );
                _DAL = null;
            }
            return _DS;
        }
        #endregion

        #region app会员中心-正常中奖的商品列表10316
        /// <summary>
        /// app会员中心-正常中奖的商品列表10316
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userID">会员ID</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">总记录数</param>
        /// <returns></returns>
        public static DataSet appGetMemberCenterUserRaffleList( out int count, params object[] para )
        {
            int _ChangeCount = 0;
            para[5] = 0;
            return appGetMemberCenterUserRaffleListEx( out  count, out _ChangeCount, para );
        }
        #endregion
        #region app会员中心-中奖的商品列表1031601
        /// <summary>
        /// app会员中心-中奖的商品列表1031601
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
        public static DataSet appGetMemberCenterUserRaffleListEx( out int normalCount, out int changeCount, params object[] para )
        {
            DataSet _DS = null;
            int _FIdx = (int)para[0];
            int _EIdx = (int)para[1];
            DateTime _BeginTime = (DateTime)para[2];
            DateTime _EndTime = (DateTime)para[3];
            int _UserID = (int)para[4];
            int _OrderType = (int)para[5];
            int _IsCount = (int)para[6];
            normalCount = 0;
            changeCount = 0;
            if ( _UserID > 0 )
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.appGetMemberCenterUserRaffleList( _FIdx, _EIdx, _BeginTime, _EndTime, _UserID, _OrderType, _IsCount, out  normalCount, out changeCount );
                _DAL = null;
            }
            return _DS;
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
        public static DataSet appGetMemberCenterPostListByUserID( out int count, params object[] para )
        {
            DataSet _DS = null;
            count = 0;
            int _UserID = (int)para[0];
            int _State = (int)para[1];
            int _IsStat = (int)para[2];
            DateTime _BeginTime = (DateTime)para[3];
            DateTime _EndTime = (DateTime)para[4];
            int _FIdx = (int)para[5];
            int _EIdx = (int)para[6];
            int _IsCount = (int)para[7];
            count = 0;
            if ( _UserID > 0 && _FIdx > 0 && _EIdx >= _FIdx )
            {
                IDALPostSingle _DAL = new DALPostSingle();
                _DS = _DAL.appGetMemberCenterPostListByUserID( _UserID, _State, _IsStat, _BeginTime, _EndTime, _FIdx, _EIdx, _IsCount, out count );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 获得用户首次时间10318
        /// <summary>
        /// 获得用户首次时间10318
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="queryType">1.首次购买时间，2首次获得商品时间，3首次可晒单时间</param>
        /// <returns></returns>
        public static DataSet GetUserFirstTime( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            int _QueryType = (int)para[1];
            if ( _UserID > 0 )
            {
                IDALUserBuy _DAL = new DALUserBuy();
                _DS = _DAL.GetUserFirstTime( _UserID, _QueryType );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 获得用户有购买记录的月份10319
        /// <summary>
        /// 获得用户有购买记录的月份10319
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static DataSet GetUserBuyMonthByUserID( params object[] para )
        {
            DataSet _DS = null;
            int _UserID = (int)para[0];
            if ( _UserID > 0 )
            {
                IDALUserBuy _DAL = new DALUserBuy();
                _DS = _DAL.GetUserBuyMonthByUserID( _UserID );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
    }
}
