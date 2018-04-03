using System;
using System.Data;

namespace wcfNSYGShop
{
    public class DALBarcode : DALBase, IDALBarcode
    {
        #region 获取已经开奖的商品条码信息
        /// <summary>
        /// 获取已经开奖的商品条码信息
        /// </summary>
        /// <param name="codeID">商品条码</param>
        /// <returns></returns>
        public DataSet GetBarcodeRNOInfo( int codeID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10404" );
            Para.AddOrcNewInParameter( "i_codeid", codeID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_Barcode.sp_getCodeInfoByRTime" );//pro_BarcodeGetRNOInfo
        }
        #endregion

        #region 获取所有揭晓记录
        /// <summary>
        /// 获取所有揭晓记录
        /// </summary>
        /// <param name="FIdx">开始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="sortID">商品分类ID</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="totalCount">总记录数，不返回则为0</param>
        /// <returns></returns>
        public DataSet GetBarcodeRaffleList( int FIdx, int EIdx, int sortID, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12201" );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewInParameter( "i_sortID", sortID );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getRecentLotteryForHome" );//pro_PageForAllRaffleList
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion

        #region 手机版获得最新揭晓详情信息
        /// <summary>
        /// 手机版获得最新揭晓详情信息
        /// </summary>
        /// <param name="codeId">条码ID</param>
        /// <param name="retVal">1正常，-1本条码为正在进行中的状态，0异常</param>
        /// <returns></returns>
        public DataSet appGetRaffleBaseInfo( int codeId, out int retVal )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10303" );
            Para.AddOrcNewInParameter( "i_codeid", codeId );
            Para.AddOrcNewCursorParameter( "o_result1" );
            Para.AddOrcNewCursorParameter( "o_result_code" );
            Para.AddOrcNewCursorParameter( "o_result_pic" );
            Para.AddOrcNewCursorParameter( "o_result_bar" );
            Para.AddOrcNewCursorParameter( "o_result_post" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_apppageforphone.sp_getRafInfoByCodeID" );//pro_appPageForRaffleDetail
            retVal = GetOrcReturnValue( _DS );
            return _DS;
        }
        /// <summary>
        /// 手机版获得最新揭晓详情信息
        /// </summary>
        /// <param name="codeId">条码ID</param>
        /// <param name="retVal">1正常，-1本条码为正在进行中的状态</param>
        /// <returns></returns>
        public DataSet mGetRaffleBaseInfo( int codeId, out int retVal )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11807" );
            Para.AddOrcNewInParameter( "i_codeID", codeId );
            Para.AddOrcNewCursorParameter( "o_result1" );
            Para.AddOrcNewCursorParameter( "o_result_perd" );
            Para.AddOrcNewCursorParameter( "o_result_bar" );
            Para.AddOrcNewCursorParameter( "o_result_goods" );
            Para.AddOrcNewCursorParameter( "o_result_prun" );
            Para.AddOrcNewCursorParameter( "o_result_post" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MPageForPhone.sp_getRafflePageByCodeID" );//pro_mRaffleForPageBaseInfo
            retVal = GetOrcReturnValue( _DS );
            return _DS;
        }
        #endregion

        #region 返回条码的揭晓时间
        /// <summary>
        /// 返回条码的揭晓时间
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <returns></returns>
        public DateTime GetCodeRTime( int codeID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10405" );
            Para.AddOrcNewInParameter( "i_codeid", codeID );
            Para.AddOrcNewCursorParameter( "o_result" );
            DateTime _Time = MinDTValue;
            DataTable _DT = Dal.ExecuteFillDataTable( "yun_Barcode.sp_getRTimeByCodeID" );//pro_BarcodeGetRTimeByID
            if ( _DT != null && _DT.Rows.Count > 0 )
            {
                _Time = ToDateTime( _DT.Rows[0]["codeRTime"] );
            }
            _DT = null;
            return _Time;
        }
        #endregion

        #region 获取商品条码信息
        /// <summary>
        /// 获取商品条码信息
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <param name="useDG">是否通过DG库查询,true:DG查询</param>
        /// <returns></returns>
        public DataSet GetBarcodeInfoByID( int codeID, bool useDG )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( useDG ? "104021" : "10402" );
            Para.AddOrcNewInParameter( "i_codeid", codeID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_Barcode.sp_getBarcodeByCodeID" );//pro_BarcodeGetInfoByID
        }
        #endregion

        #region 手机版计算结果页：中奖条码揭晓信息
        /// <summary>
        /// 手机版计算结果页：中奖条码揭晓信息
        /// </summary>
        /// <param name="codeID"></param>
        /// <returns></returns>
        public DataSet mGetBarcodeLotteryInfo( int codeID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10304" );
            Para.AddOrcNewInParameter( "i_codeid", codeID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_apppageforphone.sp_getLotteryInfoByCodeID" );//pro_mBarcodeGetLotteryInfo
        }
        #endregion

        #region 获得最新揭晓详情信息
        /// <summary>
        /// 获得最新揭晓详情信息
        /// </summary>
        /// <param name="codeId"></param>
        /// <param name="retVal">1:正常;-1:本条码非揭晓状态;-2 没有进行中的期数</param>
        /// <returns></returns>
        public DataSet GetRaffleBaseInfo( int codeId, out int retVal )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12602" );
            Para.AddOrcNewInParameter( "i_codeID", codeId );
            Para.AddOrcNewCursorParameter( "o_result1" );
            Para.AddOrcNewCursorParameter( "o_result_pid" );
            Para.AddOrcNewCursorParameter( "o_result_bar" );
            Para.AddOrcNewCursorParameter( "o_result_operd" );
            Para.AddOrcNewCursorParameter( "o_result_rperd" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_RaffleForAny.sp_getLotteryPageByCodeID" );//pro_RaffleForPageBaseInfo
            retVal = GetOrcReturnValue( _DS );
            return _DS;
        }
        #endregion

        #region 获取符合指定时间前的等待开奖的条码列表
        /// <summary>
        /// 获取符合指定时间前的等待开奖的条码列表
        /// </summary>
        /// <param name="timeSpan">揭晓时间间隔</param>
        /// <returns></returns>
        public DataSet GetWaitLotteryList( int timeSpan )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10403" );
            Para.AddOrcNewInParameter( "i_codertime", timeSpan );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_Barcode.sp_getWaitLottByRTime" );//pro_BarcodeGetListForWaitLottery
        }
        #endregion

        #region 更新定时揭晓商品期数的状态
        /// <summary>
        /// 更新定时揭晓商品期数的状态
        /// </summary>
        /// <returns></returns>
        public bool UpdateBarcodeStateForAutoRTime()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "10409" );
            Dal.ExecuteNonQuery( "yun_Barcode.f_modBarcodeByCodeid" );//pro_BarcodeUpdateStateForAutoRTime
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 0 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal == 1;
        }
        #endregion

        #region 限购模块

        /// <summary>
        /// 获取限购商品最新揭晓记录
        /// </summary>
        /// <param name="quantity">获取数量</param>
        /// <param name="lastTime">上一次读取时间</param>
        /// <returns></returns>
        public DataSet GetLimitBuyNewLotteryNote( int quantity, DateTime lastTime )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12606" );
            Para.AddOrcNewInParameter( "i_quantity", quantity );
            Para.AddOrcNewInParameter( "i_lastTime", lastTime );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_RaffleForAny.sp_getNewLotteryNote" );
        }

        /// <summary>
        /// 检测用户对于某期限购商品的购买情况
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="codeID">期数ID</param>
        /// <returns></returns>
        public DataSet CheckLimitBuyForUser( int userID, int codeID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12911" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_codeID", codeID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_UserBehaver.sp_getBuyTimesByUserID" );
        }

        #endregion

        #region 获取商品条码的介绍详情【房产】
        /// <summary>
        /// 获取商品条码的介绍详情【房产】
        /// </summary>
        /// <param name="codeID">期数ID</param>
        /// <returns></returns>
        public DataSet GetBarcodeDescByCodeID( int codeID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11809" );
            Para.AddOrcNewInParameter( "i_codeid", codeID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_MPageForPhone.sp_getHouseDescByCodeID" );
        }
        #endregion

        #region 更改商品条码揭晓状态并返回结果集[1分钟计算，3分钟揭晓]
        /// <summary>
        /// 更改商品条码揭晓状态并返回结果集[1分钟计算，3分钟揭晓]
        /// </summary>
        /// <returns></returns>
        public DataSet GetBarcodeLotteryList()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12607" );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_RaffleForAny.sp_getBarcodeLottery" );
        }
        #endregion

        //===========ERP Start===========

        #region 添加一定期数的条码10413
        /// <summary>
        /// 添加一定期数的条码
        /// </summary>
        /// <param name="goodsID"></param>
        /// <param name="codePrice"></param>
        /// <param name="codeQuantity"></param>
        /// <param name="codeLimitBuyNum"></param>
        /// <param name="codeCount"></param>
        /// <param name="applyID"></param>
        /// <param name="applyNum"></param>
        /// <param name="executant"></param>
        /// <returns></returns>
        public int InsertBarcodeByGoodsID( int goodsID, decimal codePrice, int codeQuantity, int codeLimitBuyNum, int codeCount, int applyID, int applyNum, string executant )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10413" );
            Para.AddOrcNewInParameter( "i_goodsID", goodsID );
            Para.AddOrcNewInParameter( "i_codePrice", codePrice );
            Para.AddOrcNewInParameter( "i_codeQuantity", codeQuantity );
            Para.AddOrcNewInParameter( "i_codeLimitBuy", codeLimitBuyNum );
            Para.AddOrcNewInParameter( "i_CodeCount", codeCount );
            Para.AddOrcNewInParameter( "i_applyID", applyID );
            Para.AddOrcNewInParameter( "i_applyNum", applyNum );
            Para.AddOrcNewInParameter( "i_Executant", executant );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_Barcode.f_addBarCodeByCount" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        #endregion

        #region 批量删除商品的条码10414
        /// <summary>
        /// 批量删除商品的条码
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="codeCount">批量删除数目</param>
        /// <returns></returns>
        public int DeleteBarcodeByGoodsID( int goodsID, int codeCount, string executant )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10414" );
            Para.AddOrcNewInParameter( "i_goodsID", goodsID );
            Para.AddOrcNewInParameter( "i_CodeCount", codeCount );
            Para.AddOrcNewInParameter( "i_Executant", executant );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_Barcode.f_delBarCodeByCount" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        #endregion

        #region 分页获取商品所有期数列表（可按期数状态筛选）10415
        /// <summary>
        /// 分页获取商品所有期数列表（可按期数状态筛选）
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="state">状态：－10全部，－1未售卖，1进行中，2已满员，3已揭晓</param>
        /// <param name="FIdx">起始编号</param>
        /// <param name="EIdx">结束编号</param>
        /// <param name="IsCount">是否统计总数</param>
        /// <param name="totalCount">输出总记录数</param>
        /// <returns></returns>
        public DataSet GetGoodsBarcodePageList( int goodsID, int state, int FIdx, int EIdx, int IsCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10415" );
            Para.AddOrcNewInParameter( "i_goodsID", goodsID );
            Para.AddOrcNewInParameter( "i_state", state );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", IsCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_Barcode.sp_getBarcodeByGoodsID" );
            totalCount = GetOrcTotalCount( IsCount, _DS );
            return _DS;
        }
        #endregion

        #region 获取商品条码剩余期数数目10416
        /// <summary>
        /// 获取商品条码剩余期数数目
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        public int GetRemainPeriodCountByGoodsID( int goodsID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10416" );
            Para.AddOrcNewInParameter( "i_goodsID", goodsID );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_Barcode.sp_getRemainPeriodByGoodsID" );
            int _Count = 0;
            if ( _DS != null && _DS.Tables[0].Rows.Count > 0 )
            {
                _Count = ToInt32( _DS.Tables[0].Rows[0]["RemainPeriod"] );
            }
            return _Count;
        }
        #endregion

        #region 修改特殊类商品的条码详情10417
        /// <summary>
        /// 修改特殊类商品的条码详情
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <param name="goodsName">条码商品名称</param>
        /// <param name="barAttachName">条码附加标题</param>
        /// <param name="barGoodsAllPic">条码商品详情里的所有图片名称，英文逗号隔开</param>
        /// <param name="barGoodsDescription">条码商品详情</param>
        /// <returns></returns>
        public int UpdateBarGoodsDescByCodeID( int codeID, string goodsName, string barAttachName, string barGoodsAllPic, string barGoodsDescription )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10417" );
            Para.AddOrcNewInParameter( "i_codeid", codeID );
            Para.AddOrcNewInParameter( "i_goodsName", goodsName );
            Para.AddOrcNewInParameter( "i_barAttachname", barAttachName );
            Para.AddOrcNewInParameter( "i_bargoodsallpic", barGoodsAllPic );
            Para.AddOrcNewInParameter( "i_bargoodsdescription", barGoodsDescription );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_Barcode.f_modBarGoodsDescByCodeID" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        #endregion

        #region 根据上架商品ID调整未出售的条码价格10419
        /// <summary>
        /// 根据上架商品ID调整未出售的条码价格
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="salePrice">价值</param>
        /// <param name="codeQuantity">总需参与人次</param>
        /// <param name="executant">操作者</param>
        /// <returns></returns>
        public int UpdateBarcodePriceByGoodsID( int goodsID, decimal salePrice, int codeQuantity, string executant )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10419" );
            Para.AddOrcNewInParameter( "i_GoodsID", goodsID );
            Para.AddOrcNewInParameter( "i_codeQuantity", codeQuantity );
            Para.AddOrcNewInParameter( "i_salePrice", salePrice );
            Para.AddOrcNewInParameter( "i_Executant", executant );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            int _ExecuteState = 0;
            Dal.ExecuteNonQuery( "yun_Barcode.f_modBarPriceByGoodsID", out _ExecuteState );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            UtilityFile.AddLogErrMsg( "updateGoodsPrice", string.Format( "goodsID:{0},price:{1},quantity:{2},executant:{3},state:{4},retVal:{5}", goodsID, salePrice, codeQuantity, executant, _ExecuteState, _RetVal ) );
            return _ExecuteState > 0 ? _RetVal : _ExecuteState;
        }
        #endregion

        #region 根据条码ID查询房产的详情描述信息
        /// <summary>
        /// 根据条码ID查询房产的详情描述信息
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <returns></returns>
        public DataSet GetHouseInfoByCodeID( int codeID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13422" );
            Para.AddOrcNewInParameter( "i_codeid", codeID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_ZSys_Goods.sp_getHouseInfoByCodeID" );
        }
        #endregion

        //===========ERP End=============
    }
}
