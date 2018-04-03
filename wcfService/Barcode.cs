using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class WCFServiceFun
    {
        #region 获取已经开奖的商品条码信息
        /// <summary>
        /// 获取已经开奖的商品条码信息
        /// </summary>
        /// <param name="codeID"></param>
        /// <returns></returns>
        public DataSet GetBarcodeRNOInfo( int codeID )
        {
            DataSet _DS = null;
            if ( codeID > 0 )
            {
                try
                {
                    IDALBarcode _DAL = new DALBarcode();
                    _DS = _DAL.GetBarcodeRNOInfo( codeID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Barcode.GetBarcodeRNOInfo抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 获取所有揭晓记录
        /// <summary>
        /// 获取所有揭晓记录
        /// </summary>
        /// <param name="FIdx">开始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="totalCount">总记录数，不返回则为0</param>
        /// <returns></returns>
        public DataSet GetBarcodeRaffleList( int FIdx, int EIdx, int isCount, out int totalCount )
        {
            return this.GetBarcodeRaffleListEx( FIdx, EIdx, 0, isCount, out totalCount );
        }
        /// <summary>
        /// 获取所有揭晓记录
        /// </summary>
        /// <param name="FIdx">开始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="sortID">商品类别ID</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="totalCount">总记录数，不返回则为0</param>
        /// <returns></returns>
        public DataSet GetBarcodeRaffleListEx( int FIdx, int EIdx, int sortID, int isCount, out int totalCount )
        {
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

        #region 手机版获得最新揭晓详情信息
        /// <summary>
        /// 手机版获得最新揭晓详情信息
        /// </summary>
        /// <param name="codeId">条码ID</param>
        /// <param name="retVal">1正常，-1本条码为正在进行中的状态</param>
        /// <returns></returns>
        public DataSet appGetRaffleBaseInfo( int codeId, out int retVal )
        {
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
        /// <summary>
        /// 手机版获得最新揭晓详情信息
        /// </summary>
        /// <param name="codeId">条码ID</param>
        /// <param name="retVal">1正常，-1本条码为正在进行中的状态</param>
        /// <returns></returns>
        public DataSet mGetRaffleBaseInfo( int codeId, out int retVal )
        {
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

        #region 返回条码的揭晓时间
        /// <summary>
        /// 返回条码的揭晓时间
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <returns></returns>
        public  DateTime GetCodeRTime( int codeID )
        {
            DateTime _RTime = UtilityFun.MinDTValue;
            if ( codeID > 0 )
            {
                try
                {
                    IDALBarcode _DAL = new DALBarcode();
                    _RTime = _DAL.GetCodeRTime( codeID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Barcode.GetCodeRTime抛出异常：" + ex.Message );
                }
            }
            return _RTime;
        }
        #endregion

        #region 获取商品条码信息
        /// <summary>
        /// 获取商品条码信息
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <returns></returns>
        public DataSet GetBarcodeInfoByID( int codeID )
        {
            DataSet _DS = null;
            if ( codeID > 0 )
            {
                try
                {
                    IDALBarcode _DAL = new DALBarcode();
                    _DS = _DAL.GetBarcodeInfoByID( codeID, false );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Barcode.GetBarcodeInfoByID抛出异常：" + ex.Message );
                }
            }
            return _DS;
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

        #region 获得最新揭晓详情信息
        /// <summary>
        /// 获得最新揭晓详情信息
        /// </summary>
        /// <param name="codeId"></param>
        /// <param name="retVal">1:正常;-1:本条码非揭晓状态;-2 没有进行中的期数</param>
        /// <returns></returns>
        public DataSet GetRaffleBaseInfo( int codeId, out int retVal )
        {
            DataSet _DS = null;
            retVal = 0;
            try
            {
                IDALBarcode _DAL = new DALBarcode();
                _DS = _DAL.GetRaffleBaseInfo( codeId, out retVal );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Barcode.GetRaffleBaseInfo抛出异常：" + ex.Message );
            }
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
            DataSet _DS = null;
            try
            {
                IDALBarcode _DAL = new DALBarcode();
                _DS = _DAL.GetWaitLotteryList( timeSpan );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Barcode.GetWaitLotteryList Exception:" + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region 更新定时揭晓商品期数的状态
        /// <summary>
        /// 更新定时揭晓商品期数的状态
        /// </summary>
        /// <returns></returns>
        public bool UpdateBarcodeStateForAutoRTime()
        {
            bool _Result = false;
            try
            {
                IDALBarcode _DAL = new DALBarcode();
                _Result = _DAL.UpdateBarcodeStateForAutoRTime();
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Barcode.UpdateBarcodeStateForAutoRTime Exception:" + ex.Message );
            }
            return _Result;
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
            DataSet _DS = null;
            if ( quantity > 0 )
            {
                try
                {
                    IDALBarcode _DAL = new DALBarcode();
                    _DS = _DAL.GetLimitBuyNewLotteryNote( quantity, lastTime );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Barcode.GetLimitBuyNewLotteryNote Ex:" + ex.Message );
                }
            }
            return _DS;
        }

        /// <summary>
        /// 检测用户对于某期限购商品的购买情况
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="codeID">期数ID</param>
        /// <returns></returns>
        public DataSet CheckLimitBuyForUser( int userID, int codeID )
        {
            DataSet _DS = null;
            try
            {
                IDALBarcode _DAL = new DALBarcode();
                _DS = _DAL.CheckLimitBuyForUser( userID, codeID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Barcode.CheckLimitBuyForUser Ex:" + ex.Message );
            }
            return _DS;
        }

        #endregion
    }
}
