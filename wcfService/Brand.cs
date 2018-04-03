using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class WCFServiceFun
    {
        #region 获取某分类下的品牌列表
        /// <summary>
        /// 获取某分类下的品牌列表
        /// </summary>
        /// <param name="sortID"></param>
        /// <returns></returns>
        public DataSet GetBrandBySortID( int sortID )
        {
            DataSet _DS = null;
            try
            {
                IDALBrand _DAL = new DALBrand();
                _DS = _DAL.GetBrandBySortID( sortID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Brand.GetBrandBySortID Exception:" + ex.Message );
            }
            return _DS;
        }
        #endregion
    }
}
