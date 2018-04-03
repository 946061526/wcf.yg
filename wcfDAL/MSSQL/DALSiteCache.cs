using System;
using System.Data;

namespace wcfNSYGShop
{
    public class DALSiteCache : DALBase, IDALSiteCache
    {
        #region 根据ID获取模板记录
        /// <summary>
        /// 根据ID获取模板记录
        /// </summary>
        /// <param name="SiteID"></param>
        /// <returns></returns>
        public DataSet GetSiteCacheByID( int siteID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12702" );
            Para.AddOrcNewInParameter( "i_siteID", siteID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_SiteCache.sp_getCacheCfgBySiteID" );//pro_SiteCacheGetInfoBySiteID
        }
        #endregion
    }
}
