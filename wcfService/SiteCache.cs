using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class WCFServiceFun
    {
        #region 根据ID获取模板记录
        /// <summary>
        /// 根据ID获取模板记录
        /// </summary>
        /// <param name="siteID"></param>
        /// <returns></returns>
        public DataSet GetSiteCacheByID( int siteID )
        {
            DataSet _DS = null;
            if ( siteID > 0 )
            {
                try
                {
                    IDALSiteCache _DAL = new DALSiteCache();
                    _DS = _DAL.GetSiteCacheByID( siteID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "SiteCache.GetSiteCacheByID Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
    }
}
