using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 获取商品条码信息10402
        /// <summary>
        /// 获取商品条码信息10402
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <returns></returns>
        public static DataSet GetBarcodeInfoByID( params object[] para )
        {
            int codeID = (int)para[0];
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
        #region 获取符合指定时间前的等待开奖的条码列表10403
        /// <summary>
        /// 获取符合指定时间前的等待开奖的条码列表10403
        /// </summary>
        /// <param name="timeSpan">揭晓时间间隔</param>
        /// <returns></returns>
        public static DataSet GetWaitLotteryList( params object[] para )
        {
            int timeSpan = (int)para[0];
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
        #region 获取已经开奖的商品条码信息10404
        /// <summary>
        /// 获取已经开奖的商品条码信息10404
        /// </summary>
        /// <param name="codeID"></param>
        /// <returns></returns>
        public static DataSet GetBarcodeRNOInfo( params object[] para )
        {
            int codeID = (int)para[0];
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
        #region 返回条码的揭晓时间10405
        /// <summary>
        /// 返回条码的揭晓时间10405
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <returns></returns>
        public static string GetCodeRTime( params object[] para )
        {
            int codeID = (int)para[0];
            string _RTime = UtilityFun.MinDTValue.ToString();
            if ( codeID > 0 )
            {
                try
                {
                    IDALBarcode _DAL = new DALBarcode();
                    _RTime = _DAL.GetCodeRTime( codeID ).ToString( "yyyy-MM-dd HH:mm:ss.fff" );
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
        #region 更新定时揭晓商品期数的状态10409
        /// <summary>
        /// 更新定时揭晓商品期数的状态10409
        /// </summary>
        /// <returns></returns>
        public static int UpdateBarcodeStateForAutoRTime()
        {
            int _Result = 0;
            try
            {
                IDALBarcode _DAL = new DALBarcode();
                _Result = _DAL.UpdateBarcodeStateForAutoRTime() ? 1 : 0;
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Barcode.UpdateBarcodeStateForAutoRTime Exception:" + ex.Message );
            }
            return _Result;
        }
        #endregion
        #region 获取云购即将完成的商品列表（即将开奖商品）10410
        /// <summary>
        /// 获取云购即将完成的商品列表（即将开奖商品）10410
        /// </summary>
        /// <param name="quantity">返回记录数量</param>
        /// <returns></returns>
        public static DataSet GetRNOLastGoodsList( params object[] para )
        {
            int quantity = (int)para[0];
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

        //===========ERP Start===========

        #region 添加一定期数的条码10413
        /// <summary>
        /// 添加一定期数的条码
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="codePrice">条码价值</param>
        /// <param name="codeQuantity">条码总需参与人次</param>
        /// <param name="codeLimitBuyNum">条码限购人次</param>
        /// <param name="codeCount">批量添加数目</param>
        /// <returns></returns>
        public static int InsertBarcodeByGoodsID( object[] para )
        {
            int _Result = 0;
            try
            {
                int _GoodsID = (int)para[0];
                decimal _CodePrice = (decimal)para[1];
                int _CodeQuantity = (int)para[2];
                int _CodeLimitBuyNum = (int)para[3];
                int _CodeCount = (int)para[4];
                int _ApplyID = (int)para[5];
                int _ApplyNum = (int)para[6];
                string _Executant = (string)para[7];

                DateTime _BeginTime = DateTime.Now;

                IDALBarcode _dalBarcode = new DALBarcode();
                _Result = _dalBarcode.InsertBarcodeByGoodsID( _GoodsID, _CodePrice, _CodeQuantity, _CodeLimitBuyNum, _CodeCount,_ApplyID, _ApplyNum, _Executant );
                _dalBarcode = null;

                UtilityFile.AddLogErrMsg( "addBarcode", string.Format( "goodsID:{0},codePrice:{1},codeQuantity:{2},codeLimitBuyNum:{3},codeCount:{4},ApplyID:{5},ApplyNum:{6},executant:{7},takesTime:{8}ms"
                                                                        , _GoodsID
                                                                        , _CodePrice
                                                                        , _CodeQuantity
                                                                        , _CodeLimitBuyNum
                                                                        , _CodeCount
                                                                        , _ApplyID
                                                                        , _ApplyNum
                                                                        , _Executant
                                                                        , DateTime.Now.Subtract( _BeginTime ).TotalMilliseconds
                                                                      )
                                        );
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Barcode.InsertBarcodeByGoodsID Ex：" + ex.Message );
            }
            return _Result;
        }
        #endregion

        #region 批量删除商品的条码10414
        /// <summary>
        /// 批量删除商品的条码
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="codeCount">批量删除数目</param>
        /// <returns></returns>
        public static int DeleteBarcodeByGoodsID( object[] para )
        {
            int _Result = 0;
            try
            {
                int _GoodsID = (int)para[0];
                int _CodeCount = (int)para[1];
                string _Executant = (string)para[2];

                IDALBarcode _dalBarcode = new DALBarcode();
                _Result = _dalBarcode.DeleteBarcodeByGoodsID( _GoodsID, _CodeCount, _Executant );
                _dalBarcode = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Barcode.DeleteBarcodeByGoodsID Ex：" + ex.Message );
            }
            return _Result;
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
        public static DataSet GetGoodsBarcodePageList( out int totalCount, params object[] para )
        {
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                int _GoodsID = (int)para[0];
                int _State = (int)para[1];
                int _FIdx = (int)para[2];
                int _EIdx = (int)para[3];
                int _IsCount = (int)para[4];

                IDALBarcode _DAL = new DALBarcode();
                _DS = _DAL.GetGoodsBarcodePageList( _GoodsID, _State, _FIdx, _EIdx, _IsCount, out totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Barcode.GetGoodsBarcodePageList Ex：" + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region 获取商品条码剩余期数数目10416
        /// <summary>
        /// 获取商品条码剩余期数数目
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        public static int GetRemainPeriodCountByGoodsID( params object[] para )
        {
            int _Count = 0;
            try
            {
                int _GoodsID = (int)para[0];

                IDALBarcode _DAL = new DALBarcode();
                _Count = _DAL.GetRemainPeriodCountByGoodsID( _GoodsID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Barcode.GetGoodsBarcodePageList Ex：" + ex.Message );
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
        public static int UpdateBarGoodsDescByCodeID( params object[] para )
        {
            int _RetVal = 0;
            try
            {
                int _CodeID = (int)para[0];
                string _GoodsName = (string)para[1];
                string _BarAttachName = (string)para[2];
                string _BarGoodsAllPic = (string)para[3];
                string _BarGoodsDescription = (string)para[4];

                IDALBarcode _DAL = new DALBarcode();
                _RetVal = _DAL.UpdateBarGoodsDescByCodeID( _CodeID, _GoodsName, _BarAttachName, _BarGoodsAllPic, _BarGoodsDescription );
                _DAL = null;

                if ( _RetVal > 0 )
                {
                    using ( CouchBaseClient couch = new CouchBaseClient() )
                    {
                        couch.RemoveObject( "GDInfoByCode" + _CodeID );
                    }
                }
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Barcode.UpdateBarGoodsDescByCodeID Ex：" + ex.Message );
            }
            return _RetVal;
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
        public static int UpdateBarcodePriceByGoodsID( object[] para )
        {
            int _Result = -3;
            try
            {
                //执行状态码:  >0 成功，  －11 执行超时，－12 执行异常，-103 商品ID不存在，-104 未有可调价的期数
                int _GoodsID = (int)para[0];
                decimal _SalePrice = (decimal)para[1];
                int _CodeQuantity = (int)para[2];
                string _Executant = (string)para[3];
                IDALBarcode _DAL = new DALBarcode();
                _Result = _DAL.UpdateBarcodePriceByGoodsID( _GoodsID, _SalePrice, _CodeQuantity, _Executant );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogMsg( "Barcode.UpdateBarcodePriceByGoodsID Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion

        //===========ERP End=============
    }
}
