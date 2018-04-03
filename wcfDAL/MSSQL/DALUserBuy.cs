using System.Data;
using System.Data.Common;
using System;

namespace wcfNSYGShop
{
    public class DALUserBuy : DALBase, IDALUserBuy
    {
        #region 获取商品的某期的所有云购记录
        /// <summary>
        /// 获取商品的某期的所有云购记录
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <param name="FIdx">开始记录编号</param>
        /// <param name="EIdx">结束记录编号</param>
        /// <param name="isCount">是否统计总记录数</param>
        /// <param name="useDG">是否通过DG库查询,true:DG查询</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public DataSet GetUserBuyListByBarcodeDesc( int codeID, int FIdx, int EIdx, int isCount, bool useDG, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( useDG ? "122051" : "12205" );
            Para.AddOrcNewInParameter( "i_CodeID", codeID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getDetailBuyInfoByCodeID" );//pro_PageForGoodsDetailBuyInfo
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        /// <summary>
        /// 获取商品的某期的所有云购记录
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <param name="FIdx">开始记录编号</param>
        /// <param name="EIdx">结束记录编号</param>
        /// <param name="isCount">是否统计总记录数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public DataSet GetUserBuyListByBarcodeAsc( int codeID, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11803" );
            Para.AddOrcNewInParameter( "i_codeID", codeID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MPageForPhone.sp_getGoodsCodeByCodeID" );//pro_mPageForGoodsDetailBuyInfo
            totalCount = GetOrcTotalCount( isCount, _DS );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10804" );
            Para.AddOrcNewInParameter( "i_time", time );
            Para.AddOrcNewCursorParameter( "o_result_after5" );
            Para.AddOrcNewCursorParameter( "o_result_before105" );
            return Dal.ExecuteFillDataSet( "yun_DataServerUser.sp_getTop110UserBuyByTime" );//pro_DataServerUserBuyTopInfoForView
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11720" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getAllStateRecordeByUserid" );//pro_MemberCenterForUserBuyStateTotal
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
        /// <param name="userID">会员ID</param>
        /// <param name="keyWords">关键字</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">返回总记录数</param>
        /// <returns></returns>
        public DataSet GetMemberCenterBuyList( int FIdx, int EIdx, int state, DateTime beginTime, DateTime endTime, int userID, string keyWords, int isCount, out int count )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11717" );
            Para.AddOrcNewInParameter( "i_keyWords", keyWords );
            Para.AddOrcNewInParameter( "i_State", state );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_startTime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getUserBuyInfoByUserid" );//pro_MemberCenterForUserBuyMessage
            count = GetOrcTotalCount( isCount, _DS );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11716" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_codeid", codeID );
            Para.AddOrcNewCursorParameter( "o_result_bar" );
            Para.AddOrcNewCursorParameter( "o_result_buy" );
            Para.AddOrcNewCursorParameter( "o_result_rno" );
            Para.AddOrcNewCursorParameter( "o_result_goods" );
            return Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getBuyInfoByUserid" );//pro_MemberCenterForUserBuyDetail
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
        public DataSet GetUserWebPageBuyList( int userID, int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13005" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_startTime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_iscount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_UserWeb.sp_getWebBuyByUserID" );//pro_UserWebPageForUserBuy
            totalCount = GetOrcTotalCount( isCount, _DS );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10803" );
            Para.AddOrcNewInParameter( "i_buyid", buyID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_DataServerUser.sp_getRecentUserBuyByBuyID" );//pro_DataServerUserBuyRecently
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10801" );
            Para.AddOrcNewInParameter( "i_starttime", beginTime );
            Para.AddOrcNewInParameter( "i_endtime", endTime );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_DataServerUser.sp_getUserBuyByTime" );//pro_DataServerUserBuyForPage
            count = GetOrcTotalCount( isCount, _DS );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12604" );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_RaffleForAny.sp_getLotteryInfo" );//pro_RaffleForUserBuyTopInfo
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12603" );
            Para.AddOrcNewInParameter( "i_codeID", codeId );
            Para.AddOrcNewCursorParameter( "o_result_buy" );
            Para.AddOrcNewCursorParameter( "o_result_rno" );
            return Dal.ExecuteFillDataSet( "yun_RaffleForAny.sp_getCodeOfLotteryByCodeID" );//pro_RaffleForRaffleUserBuyRno
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12215" );
            Para.AddOrcNewInParameter( "i_BuyID", buyid );
            Para.AddOrcNewInParameter( "i_quantity", 10 );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getRecentBuyByBuyID" );//pro_PageForRecentlyBuy
        }
        #endregion

        #region 获取所有商品条码总售出份额
        /// <summary>
        /// 获取所有商品条码总售出份额
        /// </summary>
        /// <returns></returns>
        public Int64 GetBarcodeSalesTotal()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12912" );
            Para.AddOrcNewCursorParameter( "o_result" );
            return ToInt64( Dal.ExecuteString( "yun_UserBehaver.sp_getTotalBuyTimes" ) );//pro_UserBuyNumTotal
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12915" );
            Para.AddOrcNewInParameter( "i_buyID", buyID );
            Para.AddOrcNewInParameter( "i_codeID", codeID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_UserBehaver.sp_getLuckCodeByCodeID" );//pro_UserBuyRNOGetRNOByBuyID
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12911" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_codeID", codeID );
            Para.AddOrcNewCursorParameter( "o_result" );
            string _Result = Dal.ExecuteString( "yun_UserBehaver.sp_getBuyTimesByUserID" );//pro_UserBuyGetCodeUserBuyTotal
            return ToInt32( _Result );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12910" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_codeID", codeID );
            Para.AddOrcNewInParameter( "i_quantity", quantity );
            Para.AddOrcNewCursorParameter( "o_result_buy" );
            Para.AddOrcNewCursorParameter( "o_result_rno" );
            return Dal.ExecuteFillDataSet( "yun_UserBehaver.sp_getBuyRecordByUserID" );//pro_UserBuyGetCodeUserBuyList
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11718" );
            if ( keyWords != "" )
            {
                Para.AddOrcNewInParameter( "i_keyWords", keyWords );
            }
            Para.AddOrcNewInParameter( "i_userID", userid );
            Para.AddOrcNewInParameter( "i_startTime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getBuyTurnBackByUserid" );//pro_MemberCenterForUserBuyRefund
            count = GetOrcTotalCount( isCount, _DS );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11719" );
            Para.AddOrcNewInParameter( "i_userID", userid );
            Para.AddOrcNewInParameter( "i_codeID", codeid );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getBarCodeByUserid" );//pro_MemberCenterForUserBuyRno
        }
        #endregion

        #region 90后天退购
        /// <summary>
        /// 90后天退购
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="buyIDs">购买ID</param>
        /// <returns></returns>
        public int RefundUserBuyAfter90( int userID, string buyIDs )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12913" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_buyIDStr", buyIDs );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_modRefundRnoByUserID" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;//1  成功  0  异常   -1 传入的这些buyID不符合   -2 删除的云购码和buyNum不一致
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12206" );
            Para.AddOrcNewInParameter( "i_GoodsID", goodsID );
            Para.AddOrcNewInParameter( "i_CodePeriod", codePeriod );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getHistoryPeriodByGoodsID" );//pro_PageForGoodsHistoryPeriod
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12914" );
            Para.AddOrcNewInParameter( "i_codeID", codeID );
            Para.AddOrcNewInParameter( "i_rnoNum", rnoNum );
            Para.AddOrcNewCursorParameter( "o_result" );
            return ToInt32( Dal.ExecuteString( "yun_UserBehaver.sp_getRecLuckCodeByCodeID" ) );//pro_UserBuyRnoGetNearestRno
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10802" );
            Para.AddOrcNewInParameter( "i_endtime", endTime );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_DataServerUser.sp_getTop100UserBuyByTime" );//pro_DataServerUserBuyForRaffle
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12966" );
            Para.AddOrcNewInParameter( "i_quantity", quantity );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_UserBehaver.sp_getUserBuyForWeekRanking" );//pro_UserBuyForWeekRanking
        }
        #endregion

        #region app会员中心-我的云购记录分页列表
        /// <summary>
        /// app会员中心-我的云购记录分页列表
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="state">状态</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userID">会员ID</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">返回总记录数</param>
        /// <returns></returns>
        public DataSet appGetMemberCenterBuyList( int FIdx, int EIdx, int state, DateTime beginTime, DateTime endTime, int userID, int isCount, out int count )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10315" );
            Para.AddOrcNewInParameter( "i_State", state );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_startTime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_apppageforphone.sp_getUserBuyInfoByUserid" );
            count = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion

        #region 获得用户首次时间10318
        /// <summary>
        /// 获得用户首次时间10318
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="queryType">1.首次购买时间，2首次获得商品时间，3首次可晒单时间</param>
        /// <returns></returns>
        public DataSet GetUserFirstTime( int userID, int queryType )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10318" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_querytype", queryType );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_apppageforphone.sp_getUserFirstTime" );
        }
        #endregion
        #region 获得用户有购买记录的月份10319
        /// <summary>
        /// 获得用户有购买记录的月份10319
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataSet GetUserBuyMonthByUserID( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10319" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_apppageforphone.sp_getUserBuyMonthByUserid" );
        }
        #endregion
        #region 返回小程序会员中心用户云购信息40201
        /// <summary>
        /// 返回小程序会员中心用户云购信息40201
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public DataSet GetUserBuyInfoByUserID( int userID, DateTime beginTime, DateTime endTime, int FIdx, int EIdx, int isCount, out int count )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "40201" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_startTime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_WXSmallAuto.sp_getUserBuyInfoByUserid" );
            count = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion
    }
}
