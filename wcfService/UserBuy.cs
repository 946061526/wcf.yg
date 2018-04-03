using System;
using System.Data;

namespace wcfNSYGShop
{
    /// <summary>
    /// userbuy服务
    /// </summary>
    public partial class WCFServiceFun
    {
        #region 获取商品的某期的所有云购记录
        /// <summary>
        /// 获取商品的某期的所有云购记录
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <param name="FIdx">开始记录编号</param>
        /// <param name="EIdx">结束记录编号</param>
        /// <param name="sortType">排序方式：0倒序  1正序</param>
        /// <param name="isCount">是否统计总记录数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public DataSet GetUserBuyListByBarcode( int codeID, int FIdx, int EIdx, int sortType, int isCount, out int totalCount )
        {
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
                        bool _UseDG = ExecuteFun.IsDGUserBuyListByBarcode( codeID );

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

        #region 获取一个时间段的前后N条记录
        /// <summary>
        /// 获取一个时间段的前后N条记录
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns></returns>
        public DataSet GetUserBuyRecordsEndView( DateTime time )
        {
            DataSet _DSRes = null;
            try
            {
                IDALUserBuy _DAL = new DALUserBuy();
                DataSet _DSTmp = _DAL.GetUserBuyRecordsEndView( time );
                _DAL = null;

                //oracle那边返回表为两个，第一个最新5条[可能为空表]，第二个后面105条
                if ( _DSTmp != null && _DSTmp.Tables.Count == 2 && _DSTmp.Tables[1].Rows.Count == 105 )
                {
                    _DSRes = new DataSet();
                    _DSRes.Tables.Add( _DSTmp.Tables[0].Copy() );
                    DataTable _DT = _DSTmp.Tables[1].Clone();
                    _DT.TableName = "Table2";
                    for ( int i = 0; i < 5; i++ )//把后面5条放到第三个表
                    {
                        _DT.ImportRow( _DSTmp.Tables[1].Rows[100] );
                        _DSTmp.Tables[1].Rows.RemoveAt( 100 );
                    }
                    _DSRes.Tables.Add( _DSTmp.Tables[1].Copy() );
                    _DSRes.Tables.Add( _DT );
                    _DT = null;
                }
                _DSTmp = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "UserBuy.GetUserBuyRecordsEndView抛出异常：" + ex.Message );
            }
            return _DSRes;
        }
        #endregion

        #region 会员中心 - 用户云购记录各状态(1-3)统计
        /// <summary>
        /// 会员中心 - 用户云购记录各状态(1-3)统计
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataSet GetMemberCenterUserBuyStateTotal( int userID )
        {
            DataSet _DS = null;
            if ( userID > 0 )
            {
                try
                {
                    IDALUserBuy _DAL = new DALUserBuy();
                    _DS = _DAL.GetMemberCenterUserBuyStateTotal( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserBuy.MemberCenterForUserBuyStateTotal抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 会员中心-我的云购记录分页列表
        /// <summary>
        /// 会员中心-我的云购记录分页列表
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="state">状态</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userid">会员ID</param>
        /// <param name="keyWords">关键字</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">返回总记录数</param>
        /// <returns></returns>
        public DataSet GetMemberCenterBuyList( int FIdx, int EIdx, int state, DateTime beginTime, DateTime endTime, int userID, string keyWords, int isCount, out int count )
        {
            DataSet _DS = null;
            count = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALUserBuy _DAL = new DALUserBuy();
                    _DS = _DAL.GetMemberCenterBuyList( FIdx, EIdx, state, beginTime, endTime, userID, keyWords, isCount, out count );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserBuy.GetMemberCenterBuyMessage抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 会员中心-查询会员云购的商品详情
        /// <summary>
        /// 会员中心-查询会员云购的商品详情
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="codeID">条码ID</param>
        /// <returns></returns>
        public DataSet GetMemberCenterUserBuyDetail( int userID, int codeID )
        {
            DataSet _DS = null;
            if ( userID > 0 && codeID > 0 )
            {
                try
                {
                    IDALUserBuy _DAL = new DALUserBuy();
                    _DS = _DAL.GetMemberCenterUserBuyDetail( userID, codeID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserBuy.GetMemberCenterUserBuyDetail抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 个人主页-获取会员最新云购记录
        /// <summary>
        /// 个人主页-获取会员最新云购记录
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public DataSet GetUserWebPageBuyList( int userID, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALUserBuy _DAL = new DALUserBuy();
                    _DS = _DAL.GetUserWebPageBuyList( userID, FIdx, EIdx, UtilityFun.ToDateTime( "2010-01-01" ), DateTime.Now, isCount, out totalCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserBuy.GetUserLatestBuy抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 获取网站最新100条云购记录
        /// <summary>
        /// 获取网站最新100条云购记录
        /// </summary>
        /// <param name="buyID">buyID</param>
        /// <returns></returns>
        public DataSet GetUserBuyRecentlyList( int buyID )
        {
            DataSet _DS = null;
            try
            {
                IDALUserBuy _DAL = new DALUserBuy();
                _DS = _DAL.GetUserBuyRecentlyList( buyID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "UserBuy.GetUserBuyRecentlyList抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region 获取全站历史云购记录
        /// <summary>
        /// 获取全站历史云购记录
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">总记录数</param>
        /// <returns></returns>
        public DataSet GetUsersHistoryBuyRecords( int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int isCount, out int count )
        {
            DataSet _DS = null;
            count = 0;
            try
            {
                IDALUserBuy _DAL = new DALUserBuy();
                _DS = _DAL.GetUsersHistoryBuyRecords( FIdx, EIdx, beginTime, endTime, isCount, out count );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "UserBuy.GetUsersHistoryBuyRecords抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region 12条最新云购记录
        /// <summary>
        /// 12条最新云购记录
        /// </summary>
        /// <returns></returns>
        public DataSet GetUserBuyLast()
        {
            DataSet _DS = null;
            try
            {
                IDALUserBuy _DAL = new DALUserBuy();
                _DS = _DAL.GetUserBuyLast();
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "UserBuy.GetUserBuyLast抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region 中奖用户所有云购码列表
        /// <summary>
        /// 中奖用户所有云购码列表
        /// </summary>
        /// <param name="codeId"></param>
        /// <returns></returns>
        public DataSet GetUserBuyRnoList( int codeId )
        {
            DataSet _DS = null;
            if ( codeId > 0 )
            {
                try
                {
                    IDALUserBuy _DAL = new DALUserBuy();
                    _DS = _DAL.GetUserBuyRnoList( codeId );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserBuy.GetUserBuyRnoList抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 获取大于云购ID的云购信息
        /// <summary>
        /// 获取大于云购ID的云购信息
        /// </summary>
        /// <param name="buyid"></param>
        /// <returns></returns>
        public DataSet GetUserBuyNewList( int buyid )
        {
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

        #region 获取所有商品条码总售出份额
        /// <summary>
        /// 获取所有商品条码总售出份额
        /// </summary>
        /// <returns></returns>
        public Int64 GetBarcodeSalesTotal()
        {
            Int64 _Result = 0L;
            try
            {
                IDALUserBuy _DAL = new DALUserBuy();
                _Result = _DAL.GetBarcodeSalesTotal();
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "UserBuy.GetBarcodeSalesTotal抛出异常：" + ex.Message );
            }
            return _Result;
        }
        #endregion

        #region 根据buyID获取相应的云购码
        /// <summary>
        /// 根据buyID获取相应的云购码
        /// </summary>
        /// <param name="codeID"></param>
        /// <param name="buyID"></param>
        /// <returns></returns>
        public DataSet GetUserBuyCodeByBuyid( int codeID, int buyID )
        {
            DataSet _DS = null;
            if ( codeID > 0 && buyID > 0 )
            {
                try
                {
                    IDALUserBuy _DAL = new DALUserBuy();
                    _DS = _DAL.GetUserBuyCodeByBuyid( codeID, buyID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserBuy.GetBarcodeSalesTotal抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 获取会员某期商品的购买数量(商品列表页)
        /// <summary>
        /// 获取会员某期商品的购买数量(商品列表页)
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="codeID"></param>
        /// <returns></returns>
        public int GetUserBuyCountByCodeID( int userID, int codeID )
        {
            return 0;//数据库屏闭
            //int _BuyCount = 0;
            //if ( userID > 0 && codeID > 0 )
            //{
            //    try
            //    {
            //        IDALUserBuy _DAL = new DALUserBuy();
            //        _BuyCount = _DAL.GetUserBuyCountByCodeID( userID, codeID );
            //        _DAL = null;
            //    }
            //    catch ( Exception ex )
            //    {
            //        UtilityFile.AddLogErrMsg( "UserBuy.GetUserBuyCountByCodeID Exception:" + ex.Message );
            //    }
            //}
            //return _BuyCount;
        }
        #endregion

        #region 获取某用户某商品编号的详细云购记录(商品详细页)
        /// <summary>
        /// 获取某用户某商品编号的详细云购记录(商品详细页)
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="codeID"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public DataSet GetUserBuyListByCodeID( int userID, int codeID, int quantity )
        {
            DataSet _DS = null;
            if ( userID > 0 && codeID > 0 && quantity > 0 )
            {
                try
                {
                    IDALUserBuy _DAL = new DALUserBuy();
                    _DS = _DAL.GetUserBuyListByCodeID( userID, codeID, quantity );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserBuy.GetUserBuyListByCodeID Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 获取会员退购记录
        /// <summary>
        /// 获取会员退购记录
        /// </summary>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="userid"></param>
        /// <param name="keyWords"></param>
        /// <param name="isCount"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public DataSet GetMemberCenterBuyRefund( int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int userid, string keyWords, int isCount, out int count )
        {
            DataSet _DS = null;
            count = 0;
            if ( userid > 0 && FIdx > 0 && EIdx > FIdx )
            {
                try
                {
                    IDALUserBuy _DAL = new DALUserBuy();
                    _DS = _DAL.GetMemberCenterBuyRefund( FIdx, EIdx, beginTime, endTime, userid, keyWords, isCount, out count );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserBuy.GetMemberCenterBuyRefund Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 会员中心-查询会员云购的商品所有云够码
        /// <summary>
        /// 会员中心-查询会员云购的商品所有云够码
        /// </summary>
        /// <param name="userid">会员ID</param>
        /// <param name="codeid">条码ID</param>
        /// <returns></returns>
        public DataSet GetMemberCenterUserBuyRno( int userid, int codeid )
        {
            DataSet _DS = null;
            if ( userid > 0 && codeid > 0 )
            {
                try
                {
                    IDALUserBuy _DAL = new DALUserBuy();
                    _DS = _DAL.GetMemberCenterUserBuyRno( userid, codeid );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserBuy.GetMemberCenterUserBuyRno Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 90后天退购
        /// <summary>
        /// 90后天退购
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="buyIDs">购买ID</param>
        /// <returns></returns>
        public bool RefundUserBuyAfter90( int userID, string buyIDs )
        {
            bool _Flag = false;
            if ( userID > 0 && buyIDs != "" )
            {
                try
                {
                    IDALUserBuy _DAL = new DALUserBuy();
                    _Flag = _DAL.RefundUserBuyAfter90( userID, buyIDs ) > 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserBuy.RefundUserBuyAfter90 Exception:" + ex.Message );
                }
            }
            return _Flag;
        }
        #endregion

        #region 返回商品指定范围内的历史期数列表
        /// <summary>
        /// 返回商品指定范围内的历史期数列表
        /// (小于等于当前期数列表)
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="codePeriod">当前期数</param>
        /// <returns></returns>
        public DataSet GetGoodsHistoryPeriod( int goodsID, int codePeriod )
        {
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

        #region 获取离指定的云购码最接近的幸运云购码
        /// <summary>
        /// 获取离指定的云购码最接近的幸运云购码
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <param name="rnoNum">指定的云购码</param>
        /// <returns></returns>
        public int GetNearestRno( int codeID, int rnoNum )
        {
            int _RNO = 0;
            if ( codeID > 0 )
            {
                try
                {
                    IDALUserBuy _DAL = new DALUserBuy();
                    _RNO = _DAL.GetNearestRno( codeID, rnoNum );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserBuy.GetNearestRno Exception:" + ex.Message );
                }
            }
            return _RNO;
        }
        #endregion

        #region 获取开奖基数计算的100条记录
        /// <summary>
        /// 获取开奖基数计算的100条记录
        /// </summary>
        /// <param name="endTime">截止时间</param>
        /// <returns></returns>
        public DataSet GetRaffleDataByTime( DateTime endTime )
        {
            DataSet _DS = null;
            try
            {
                IDALUserBuy _DAL = new DALUserBuy();
                _DS = _DAL.GetRaffleDataByTime( endTime );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "UserBuy.GetRaffleDataByTime Exception:" + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region 返回本周人气排行商品信息
        /// <summary>
        /// 返回本周人气排行商品信息
        /// </summary>
        /// <param name="quantity">获取数目</param>
        /// <returns></returns>
        public DataSet GetUserBuyForWeekRanking( int quantity )
        {
            DataSet _DS = null;
            if ( quantity > 0 )
            {
                try
                {
                    DALUserBuy _DAL = new DALUserBuy();
                    _DS = _DAL.GetUserBuyForWeekRanking( quantity );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserBuy.GetUserBuyForWeekRanking Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
    }
}
