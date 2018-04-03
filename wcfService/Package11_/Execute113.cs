using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 根据商品条码获取商品详情11301
        /// <summary>
        /// 根据商品条码获取商品详情11301
        /// </summary>
        /// <param name="codeID">商品条码</param>
        /// <returns></returns>
        public static DataSet GetGoodsBarcodeInfo(params object[] para)
        {
            DataSet _DS = null;
            int _CodeID = (int)para[0];
            if (_CodeID > 0)
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetGoodsBarcodeInfo(_CodeID);
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 获取商品信息11303
        /// <summary>
        /// 获取商品信息11303
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        public static DataSet GetGoodsInfoByID(params object[] para)
        {
           int goodsID = (int)para[0];
            DataSet _DS = null;
            if (goodsID > 0)
            {
                try
                {
                    IDALGoods _DAL = new DALGoods();
                    _DS = _DAL.GetGoodsInfoByID(goodsID);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Goods.GetGoodsInfoByID抛出异常：" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
        #region 返回首页推荐的商品11318
        /// <summary>
        /// 返回首页推荐的商品11318
        /// lable:12热门推荐，13新品上架
        /// </summary>
        /// <param name="goodsLabel"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public static DataSet GetGoodsForHomeRecommend(params object[] para)
        {
            int goodsLabel = (int)para[0];
            int quantity = (int)para[1];
            DataSet _DS = null;
            if (quantity > 0)
            {
                try
                {
                    IDALGoods _DAL = new DALGoods();
                    _DS = _DAL.GetGoodsForHomeRecommend(goodsLabel, quantity);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("Goods.GetGoodsForHomeRecommend Exception:" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
        #region 获取商品正在进行中的期数信息11321
        /// <summary>
        /// 获取商品正在进行中的期数信息11321
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        public static DataSet GetSalingBarcodeInfoByGoodsID(params object[] para)
        {
            int goodsID = (int)para[0];
            DataSet _DS = null;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetSalingBarcodeInfoByGoodsID(goodsID);
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("Goods.GetSalingBarcodeInfoByGoodsID Ex:" + ex.Message);
            }
            return _DS;
        }
        #endregion

        #region 返回活动推荐的商品11325
        /// <summary>
        /// 返回活动推荐的商品11325
        /// </summary>
        /// <param name="goodsLabel"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public static DataSet GetActSpecByLabel( params object[] para )
        {
            int goodsLabel = (int)para[0];
            int quantity = (int)para[1];
            DataSet _DS = null;
            if ( quantity > 0 )
            {
                try
                {
                    IDALGoods _DAL = new DALGoods();
                    _DS = _DAL.GetActSpecByLabel( goodsLabel, quantity );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Goods.GetActSpecByLabel Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
    }
}
