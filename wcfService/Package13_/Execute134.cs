using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 根据价格查看是否要添加第三方商品对照表的价格13408
        /// <summary>
        /// 根据价格查看是否要添加第三方商品对照表的价格13408
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="goodsPrice">商品价格</param>
        /// <param name="supplier">第三方：1京东</param>
        /// <returns></returns>
        public static int UpdateThirdGoodsPriceByID( params object[] para )
        {
            int goodsID = (int)para[0];
            decimal goodsPrice = (decimal)para[1];
            int supplier = (int)para[2];
            int _Ret = 0;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _Ret = _DAL.UpdateThirdGoodsPriceByID( goodsID, goodsPrice, supplier );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.UpdateThirdGoodsPriceByID Exception:" + ex.Message );
            }
            return _Ret;
        }
        #endregion

        #region 获取需要从第三方去下单的所有商品13410
        /// <summary>
        /// 获取需要从第三方去下单的所有商品13410
        /// </summary>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public static DataSet GetThirdGoodsList( out int totalCount, params object[] para )
        {
            int FIdx = (int)para[0];
            int EIdx = (int)para[1];
            int isCount = (int)para[2];
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALGoods _DAL = new DALGoods();
                _DS = _DAL.GetThirdGoodsList( FIdx, EIdx, isCount, out  totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.GetThirdGoodsList Exception:" + ex.Message );
            }
            return _DS;
        }
        #endregion

        //===========ERP Start===========

        #region 修改商品上架名称13435
        /// <summary>
        /// 修改商品上架名称
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="goodsPic">商品图片</param>
        /// <param name="isCommit">提交方式，0：数据库提交，1：程序提交</param>
        /// <returns></returns>
        public static int UpdateGoodsNameByGoodsID( params object[] para )
        {
            int _Result = 0;
            try
            {
                int _GoodsID = (int)para[0];
                string _GoodsName = (string)para[1];
                string _GoodsSName = (string)para[2];
                string _GoodsPic = (string)para[3];

                IDALGoods _DAL = new DALGoods();
                _Result = _DAL.UpdateGoodsNameByGoodsID( _GoodsID, _GoodsName, _GoodsSName, _GoodsPic, 0 );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.UpdateGoodsNameByGoodsID Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion

        #region 修改附加标题说明和SEO信息13436
        /// <summary>
        /// 修改附加标题说明和SEO信息
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="goodsAltName">商品附加标题说明</param>
        /// <param name="goodsPreName">SEO修饰字符</param>
        /// <param name="goodsKeywords">搜索关键词</param>
        /// <param name="goodsBriefed">简介</param>
        /// <param name="goodsRecDesc">推荐描述</param>
        /// <param name="isCommit">提交方式，0：数据库提交，1：程序提交</param>
        /// <returns></returns>
        public static int UpdateGoodsAltNameByGoodsID( params object[] para )
        {
            int _Result = 0;
            try
            {
                int _GoodsID = (int)para[0];
                string _GoodsAltName = (string)para[1];
                string _GoodsPreName = (string)para[2];
                string _GoodsKeywords = (string)para[3];
                string _GoodsBriefed = (string)para[4];
                string _GoodsRecDesc = (string)para[5];

                IDALGoods _DAL = new DALGoods();
                _Result = _DAL.UpdateGoodsAltNameByGoodsID( _GoodsID, _GoodsAltName, _GoodsPreName, _GoodsKeywords, _GoodsBriefed, _GoodsRecDesc, 0 );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.UpdateGoodsAltNameByGoodsID Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion

        #region 修改商品的详细介绍13437
        /// <summary>
        /// 修改商品的详细介绍
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="goodsDesc">商品详情</param>
        /// <param name="isCommit">提交方式，0：数据库提交，1：程序提交</param>
        /// <returns></returns>
        public static int UpdateGoodsDescriptionByGoodsID( params object[] para )
        {
            int _Result = 0;
            try
            {
                int _GoodsID = (int)para[0];
                string _GoodsDesc = (string)para[1];
                string _GoodsDescM = (string)para[2];

                IDALGoods _DAL = new DALGoods();
                _Result = _DAL.UpdateGoodsDescriptionByGoodsID( _GoodsID, _GoodsDesc, _GoodsDescM, 0 );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.UpdateGoodsDescriptionByGoodsID Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion

        #region 修改商品的状态13438
        /// <summary>
        /// 修改商品的状态
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="goodsState">商品状态</param>
        /// <param name="isCommit">提交方式，0：数据库提交，1：程序提交</param>
        /// <returns></returns>
        public static int UpdateGoodsStateByGoodsID( params object[] para )
        {
            int _Result = 0;
            try
            {
                int _GoodsID = (int)para[0];
                int _GoodsState = (int)para[1];

                IDALGoods _DAL = new DALGoods();
                _Result = _DAL.UpdateGoodsStateByGoodsID( _GoodsID, _GoodsState, 0 );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.UpdateGoodsStateByGoodsID Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion

        #region 修改商品的一些其它设置信息13439
        /// <summary>
        /// 修改商品的一些其它设置信息
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="goodsTag">商品标签：1新品，2推荐，4人气，10限购</param>
        /// <param name="isLimited">是否限购</param>
        /// <param name="limitNum">限购人次</param>
        /// <param name="editType">商品类型：0普通商品，1房产</param>
        /// <param name="goodsRecDesc">首页推荐描述信息</param>
        /// <param name="goodsLabelStr">商品特定功能标识：如 104 不可晒单</param>
        /// <param name="isCommit">提交方式，0：数据库提交，1：程序提交</param>
        /// <returns></returns>
        public static int UpdateGoodsInfoByGoodsID( params object[] para )
        {
            int _Result = 0;
            try
            {
                int _GoodsID = (int)para[0];
                int _IsLimited = (int)para[1];
                int _LimitNum = (int)para[2];
                int _EditType = (int)para[3];
                int _GoodsLabelStr = (int)para[4];//ERP: 0表示不可晒单，1表示可晒单
                //string _GoodsLabelStr = (string)para[5];

                IDALGoods _DAL = new DALGoods();
                _Result = _DAL.UpdateGoodsInfoByGoodsID( _GoodsID, _IsLimited, _LimitNum, _EditType, _GoodsLabelStr, 0 );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.UpdateGoodsInfoByGoodsID Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion

        #region 同步上架其他字段信息(为后续扩展预留的接口)13440
        /// <summary>
        /// 同步上架其他字段信息(为后续扩展预留的接口)
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="spucode">spu编码</param>
        /// <param name="saleprice">销售价格</param>
        /// <param name="shelftype">上架类型:1 普通 2 促销 3 秒杀</param>
        /// <param name="signnote">签收注意事项</param>
        /// <param name="support">售后保障</param>
        /// <param name="isCommit">提交方式，0：数据库提交，1：程序提交</param>
        /// <returns></returns>
        public static int UpdateGoodsOtherInfoByGoodsID( params object[] para )
        {
            int _Result = 0;
            try
            {
                int _GoodsID = (int)para[0];
                int _GoodsSortID = (int)para[1];
                string _SpuCode = (string)para[2];
                decimal _SalePrice = (decimal)para[3];
                int _ShelfType = (int)para[4];
                string _Signnote = (string)para[5];
                string _Support = (string)para[6];
                int isOptSku = (int)para[7];
                int isOptByStock = (int)para[8];

                IDALGoods _DAL = new DALGoods();
                _Result = _DAL.UpdateGoodsOtherInfoByGoodsID( _GoodsID, _GoodsSortID, _SpuCode, _SalePrice, _ShelfType, _Signnote, _Support, isOptSku, isOptByStock, 0 );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.UpdateGoodsOtherInfoByGoodsID Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion

        #region 新增商品新增上架信息13441
        /// <summary>
        /// 新增商品新增上架信息
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="goodsState">商品状态: 3上架，5下架</param>
        /// <param name="spuCode">spu编码</param>
        /// <param name="salePrice">销售价格</param>
        /// <param name="support">售后保障</param>
        /// <param name="isCommit">提交方式，0：数据库提交，1：程序提交</param>
        /// <returns></returns>
        public static int InsertGoodsInfo( params object[] para )
        {
            int _Result = 0;
            try
            {
                int _GoodsID = (int)para[0];
                string _GoodsName = (string)para[1];
                int _GoodsSortID = (int)para[2];
                int _GoodsState = (int)para[3];
                string _Spucode = (string)para[4];
                decimal _SalePrice = (decimal)para[5];
                int _Shelftype = (int)para[6];
                string _Signnote = (string)para[7];//签收注意事项
                string _Support = (string)para[8];//售后保障
                int _IsOptSku = (int)para[9];
                int _GoodsBrandID = (int)para[10];
                int _GoodsLableID = (int)para[11];
                int _IsOptByStock = (int)para[12];
                int _IsNeedIMEI = (int)para[13];
                int _Goodslabel = (int)para[14];
                IDALGoods _DAL = new DALGoods();
                _Result = _DAL.InsertGoodsInfo( _GoodsID, _GoodsName, _GoodsSortID, _GoodsState, _Spucode, _SalePrice, _Shelftype, _Signnote, _Support, _IsOptSku, _GoodsBrandID, _GoodsLableID, _IsOptByStock, _IsNeedIMEI,_Goodslabel, 0 );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.InsertGoodsInfo Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion

        #region 同步上架商品信息134350
        /// <summary>
        /// 同步上架商品信息
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public static int UpdateAllGoodsInfoByGoodsID( params object[] paramArr )
        {
            int _Result = 0;
            if ( paramArr != null && paramArr.Length == 8 )
            {
                bool _IsSubmit = true;
                int _Step = 0;
                int _GoodsID = 0;
                IDALGoods _DAL = new DALGoods();
                try
                {
                    _DAL.TranBegin();

                    //1.修改商品上架名称
                    object[] _Para0 = paramArr[0] as object[];
                    if ( (bool)_Para0[0] )
                    {
                        _GoodsID = (int)_Para0[1];
                        string _GoodsName = (string)_Para0[2];
                        string _GoodsSName = (string)_Para0[3];
                        string _GoodsPic = (string)_Para0[4];

                        _Step = 1;
                        _Result = _DAL.UpdateGoodsNameByGoodsID( _GoodsID, _GoodsName, _GoodsSName, _GoodsPic, 1 );
                        _IsSubmit = _Result > 0;
                    }

                    //2.修改附加标题说明和SEO信息
                    object[] _Para1 = paramArr[1] as object[];
                    if ( _IsSubmit && (bool)_Para1[0] )
                    {
                        _GoodsID = (int)_Para1[1];
                        string _GoodsAltName = (string)_Para1[2];
                        string _GoodsPreName = (string)_Para1[3];
                        string _GoodsKeywords = (string)_Para1[4];
                        string _GoodsBriefed = (string)_Para1[5];
                        string _GoodsRecDesc = (string)_Para1[6];

                        _Step = 2;
                        _Result = _DAL.UpdateGoodsAltNameByGoodsID( _GoodsID, _GoodsAltName, _GoodsPreName, _GoodsKeywords, _GoodsBriefed, _GoodsRecDesc, 1 );
                        _IsSubmit = _Result > 0;
                    }

                    //3.修改商品的详细介绍
                    object[] _Para2 = paramArr[2] as object[];
                    if ( _IsSubmit && (bool)_Para2[0] )
                    {
                        _GoodsID = (int)_Para2[1];
                        string _GoodsDesc = (string)_Para2[2];
                        string _GoodsDescM = (string)_Para2[3];

                        _Step = 3;
                        _Result = _DAL.UpdateGoodsDescriptionByGoodsID( _GoodsID, _GoodsDesc, _GoodsDescM, 1 );
                        if ( _Result > 0 )
                        {
                            _IsSubmit = true;

                            //清理商品详细介绍缓存
                            using ( CouchBaseClient couch = new CouchBaseClient() )
                            {
                                couch.RemoveObject( "GDInfo" + _GoodsID );
                            }
                        }
                    }

                    //4.修改商品的状态
                    object[] _Para3 = paramArr[3] as object[];
                    if ( _IsSubmit && (bool)_Para3[0] )
                    {
                        _GoodsID = (int)_Para3[1];
                        int _GoodsState = (int)_Para3[2];

                        _Step = 4;
                        _Result = _DAL.UpdateGoodsStateByGoodsID( _GoodsID, _GoodsState, 1 );
                        _IsSubmit = _Result > 0;
                    }

                    //5.修改商品的一些其它设置信息
                    object[] _Para4 = paramArr[4] as object[];
                    if ( _IsSubmit && (bool)_Para4[0] )
                    {
                        _GoodsID = (int)_Para4[1];
                        int _IsLimited = (int)_Para4[2];
                        int _LimitNum = (int)_Para4[3];
                        int _EditType = (int)_Para4[4];
                        int _GoodsLabelStr = (int)_Para4[5];//ERP: 0表示不可晒单，1表示可晒单

                        _Step = 5;
                        _Result = _DAL.UpdateGoodsInfoByGoodsID( _GoodsID, _IsLimited, _LimitNum, _EditType, _GoodsLabelStr, 1 );
                        _IsSubmit = _Result > 0;
                    }

                    //6.同步上架其他字段信息(为后续扩展预留的接口)
                    object[] _Para5 = paramArr[5] as object[];
                    if ( _IsSubmit && (bool)_Para5[0] )
                    {
                        _GoodsID = (int)_Para5[1];
                        int _GoodsSortID = (int)_Para5[2];
                        string _SpuCode = (string)_Para5[3];
                        decimal _SalePrice = (decimal)_Para5[4];
                        int _ShelfType = (int)_Para5[5];
                        string _Signnote = (string)_Para5[6];
                        string _Support = (string)_Para5[7];
                        int _IsOptSku = (int)_Para5[8];
                        int _IsOptByStock = (int)_Para5[9];

                        _Step = 6;
                        _Result = _DAL.UpdateGoodsOtherInfoByGoodsID( _GoodsID, _GoodsSortID, _SpuCode, _SalePrice, _ShelfType, _Signnote, _Support, _IsOptSku, _IsOptByStock, 1 );
                        _IsSubmit = _Result > 0;
                    }

                    //7.更新上架时间
                    object[] _Para6 = paramArr[6] as object[];
                    if ( _IsSubmit && (bool)_Para6[0] )
                    {
                        _GoodsID = (int)_Para6[1];
                        _Step = 7;
                        _Result = _DAL.UpdateGoodsUpdateTimeByGoodsID( _GoodsID, 1 );
                        _IsSubmit = _Result > 0;
                    }

                    //8.更新上架商品重量
                    object[] _Para7 = paramArr[7] as object[];
                    if ( _IsSubmit && (bool)_Para7[0] )
                    {
                        _GoodsID = (int)_Para7[1];
                        decimal _GoodsWeight = (decimal)_Para7[2];
                        _Step = 8;
                        _Result = _DAL.UpdateGoodsweightByGoodsID( _GoodsID, _GoodsWeight, 1 );
                        _IsSubmit = _Result > 0;
                    }
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "erpGoods", ex.Message + ex.Source + ex.StackTrace );
                }
                finally
                {
                    if ( _IsSubmit )
                    {
                        _DAL.TranCommit();
                        _Result = 1;
                    }
                    else
                    {
                        _DAL.TranRollBack();
                        _Result = -UtilityFun.ToInt32( _Step.ToString() + Math.Abs( _Result ).ToString() );
                        UtilityFile.AddLogErrMsg( "erpGoods", _GoodsID + ":" + _Result.ToString() );
                    }

                    _DAL = null;
                }
            }

            return _Result;
        }
        #endregion

        #region 根据条码ID查询房产的详情描述信息13422
        /// <summary>
        /// 根据条码ID查询房产的详情描述信息
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <returns></returns>
        public static DataSet GetHouseInfoByCodeID( params object[] para )
        {
            DataSet _DS = null;
            int _CodeID = (int)para[0];
            IDALBarcode _DAL = new DALBarcode();
            _DS = _DAL.GetHouseInfoByCodeID( _CodeID );
            _DAL = null;
            return _DS;
        }
        #endregion

        #region 同步上架品牌和标签信息13442
        /// <summary>
        /// 同步上架品牌和标签信息
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="isOptSku">是否需要选择属性</param>
        /// <param name="goodsBrandId">商品品牌ID</param>
        /// <param name="goodsLabelId">商品标签ID</param>
        /// <param name="isCommit">提交方式，0：数据库提交，1：程序提交</param>
        /// <returns></returns>
        public static int UpdateGoodsBrandLabelByGoodsID( object[] para )
        {
            int _Result = 0;
            try
            {
                string spuCode = (string)para[0];
                int goodsBrandId = (int)para[1];
                int goodsLabelId = (int)para[2];
                int isNeedIMEI = (int)para[3];
                int goodsLabelStr = (int)para[4];
                IDALGoods _DAL = new DALGoods();
                _Result = _DAL.UpdateGoodsBrandLabelByGoodsID( spuCode, goodsBrandId, goodsLabelId, isNeedIMEI, goodsLabelStr, 0 );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.UpdateGoodsBrandLabelByGoodsID Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion


        #region 添加商品展示图记录(同步ERP系统yungou_sys.GoodsPic数据)13443
        /// <summary>
        /// 添加商品展示图记录(同步ERP系统yungou_sys.GoodsPic数据)13443
        /// </summary>
        /// <param name="picID"></param>
        /// <param name="goodsID"></param>
        /// <param name="picName"></param>
        /// <param name="picRemark"></param>
        /// <param name="picHide"></param>
        /// <param name="picRank"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        public static int AddGoodspic( object[] para )
        {
            int _Result = 0;
            try
            {
                int picID = (int)para[0];
                int goodsID = (int)para[1];
                string picName = (string)para[2];
                string picRemark = (string)para[3];
                int picHide = (int)para[4];
                int picRank = (int)para[5];
                int isCommit = (int)para[6];
                IDALGoods _DAL = new DALGoods();
                _Result = _DAL.AddGoodspic( picID, goodsID, picName, picRemark, picHide, picRank, isCommit );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.AddGoodspic Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion
        #region 更新商品展示图信息(同步ERP系统yungou_sys.GoodsPic数据)13444
        /// <summary>
        /// 更新商品展示图信息(同步ERP系统yungou_sys.GoodsPic数据)13444
        /// </summary>
        /// <param name="picID"></param>
        /// <param name="goodsID"></param>
        /// <param name="picName"></param>
        /// <param name="picRemark"></param>
        /// <param name="picHide"></param>
        /// <param name="picRank"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        public static int ModGoodspicByPicID( object[] para )
        {
            int _Result = 0;
            try
            {
                int picID = (int)para[0];
                int goodsID = (int)para[1];
                string picName = (string)para[2];
                string picRemark = (string)para[3];
                int picHide = (int)para[4];
                int picRank = (int)para[5];
                int isCommit = (int)para[6];
                IDALGoods _DAL = new DALGoods();
                _Result = _DAL.ModGoodspicByPicID( picID, goodsID, picName, picRemark, picHide, picRank, isCommit );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.ModGoodspicByPicID Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion
        #region 删除商品展示图片记录(同步ERP系统yungou_sys.GoodsPic数据)13445
        /// <summary>
        /// 删除商品展示图片记录(同步ERP系统yungou_sys.GoodsPic数据)13445
        /// </summary>
        /// <param name="picID"></param>
        /// <param name="goodsID"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        public static int DelGoodsPicByPicID( object[] para )
        {
            int _Result = 0;
            try
            {
                int picID = (int)para[0];
                int goodsID = (int)para[1];
                int isCommit = (int)para[2];

                IDALGoods _DAL = new DALGoods();
                _Result = _DAL.DelGoodsPicByPicID( picID, goodsID, isCommit );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Goods.DelGoodsPicByPicID Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion

        //===========ERP End===========
    }
}
