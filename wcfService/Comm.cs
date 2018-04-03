using System.Data;
namespace wcfNSYGShop
{
    /// <summary>
    /// 公共方法
    /// </summary>
    public partial class ExecuteFun
    {
        #region 是否从DG库查询商品的某期的所有云购记录
        /// <summary>
        /// 是否从DG库查询商品的某期的所有云购记录
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <returns></returns>
        public static bool IsDGUserBuyListByBarcode( int codeID )
        {
            bool _UseDG = false;
            using ( CouchBaseClient _ClientHot = new CouchBaseClient( 1 ) )
            {
                string _CouchKey = "dgcode" + codeID;
                MDLDGBarcodeInfo _Model = null;
                if ( _ClientHot.GetJson<MDLDGBarcodeInfo>( _CouchKey, out _Model ) && _Model != null && _Model.State >= 2 )
                {
                    _UseDG = true;
                }
                else
                {
                    //从DG库获取条码信息到缓存
                    int _State = 0;
                    IDALBarcode _DAL = new DALBarcode();
                    DataSet _DS = _DAL.GetBarcodeInfoByID( codeID, true );
                    if ( _DS != null && _DS.Tables.Count > 0 && _DS.Tables[0] != null && _DS.Tables[0].Rows.Count > 0 )
                    {
                        _State = UtilityFun.ToInt32( _DS.Tables[0].Rows[0]["codeState"] );
                    }
                    _DAL = null;
                    if ( _State >= 2 )
                    {
                        _UseDG = true;
                        //更新缓存
                        _Model = new MDLDGBarcodeInfo();
                        _Model.State = _State;
                        _ClientHot.SetJsonObject( _CouchKey, _Model, 600000 );//10分钟
                    }
                }
                _Model = null;
            }


            return _UseDG;
        }
        #endregion

    }    /// <summary>
}
