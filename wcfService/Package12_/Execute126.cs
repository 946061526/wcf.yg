using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 获得最新揭晓详情信息12602
        /// <summary>
        /// 获得最新揭晓详情信息12602
        /// </summary>
        /// <param name="codeId"></param>
        /// <param name="retVal">1:正常;-1:本条码非揭晓状态;-2 没有进行中的期数</param>
        /// <returns></returns>
        public static DataSet GetRaffleBaseInfo( out int retVal, params object[] para )
        {
            int codeId = (int)para[0];
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
        #region 中奖用户所有云购码列表12603
        /// <summary>
        /// 中奖用户所有云购码列表12603
        /// </summary>
        /// <param name="codeId"></param>
        /// <returns></returns>
        public static DataSet GetUserBuyRnoList( params object[] para )
        {
            int codeId = (int)para[0];
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
        #region 12条最新云购记录12604
        /// <summary>
        /// 12条最新云购记录12604
        /// </summary>
        /// <returns></returns>
        public static DataSet GetUserBuyLast()
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
        #region 返回揭晓结果12605
        /// <summary>
        /// 返回揭晓结果12605
        /// </summary>
        /// <param name="codeID">条码</param>
        /// <param name="rnoNum">幸运云购码</param>
        /// <param name="rTime">揭晓时间</param>
        /// <param name="rCheckSum">揭晓的基数</param>
        /// <returns></returns>
        public static DataSet GetStartRaffleResult( params object[] para )
        {
            int codeID = (int)para[0];
            int rnoNum = (int)para[1];
            DateTime rTime = (DateTime)para[2];
            long rCheckSum = (long)para[3];
            DataSet _DS = null;
            if ( codeID > 0 )
            {
                try
                {
                    IDALOrders _DAL = new DALOrders();
                    _DS = _DAL.GetStartRaffleResult( codeID, rnoNum, rTime, rCheckSum );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Orders.GetStartRaffleResult Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
        #region 计算条码的揭晓结果12605
        /// <summary>
        /// 计算条码的揭晓结果12605
        /// </summary>
        /// <param name="codeID">条码</param>
        /// <param name="rnoNum">幸运云购码</param>
        /// <param name="rTime">揭晓时间</param>
        /// <param name="rCheckSum">揭晓的基数</param>
        /// <returns></returns>
        public static DataSet GetStartRaffleResultNew( params object[] para )
        {
            int codeID = (int)para[0];
            int rnoNum = (int)para[1];
            DateTime rTime = (DateTime)para[2];
            long rCheckSum = (long)para[3];
            DataSet _DS = null;
            if ( codeID > 0 )
            {
                try
                {
                    IDALOrders _DAL = new DALOrders();
                    _DS = _DAL.GetStartRaffleResultNew( codeID, rnoNum, rTime, rCheckSum );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Orders.GetStartRaffleResultNew Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
        #region 获取限购商品最新揭晓记录12606
        /// <summary>
        /// 获取限购商品最新揭晓记录12606
        /// </summary>
        /// <param name="quantity">获取数量</param>
        /// <param name="lastTime">上一次读取时间</param>
        /// <returns></returns>
        public static DataSet GetLimitBuyNewLotteryNote( params object[] para )
        {
            int quantity = (int)para[0];
            DateTime lastTime = (DateTime)para[1];
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
        #endregion
        #region 更改商品条码揭晓状态[1分钟计算，3分钟揭晓]12607
        /// <summary>
        /// 更改商品条码揭晓状态[1分钟计算，3分钟揭晓]
        /// </summary>
        /// <returns></returns>
        public static DataSet GetBarcodeLotteryList()
        {
            IDALBarcode _DAL = new DALBarcode();
            DataSet _DS = _DAL.GetBarcodeLotteryList();
            _DAL = null;
            return _DS;
        }
        #endregion
    }
}
