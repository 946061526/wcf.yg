using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 根据ID获取模板记录12702
        /// <summary>
        /// 根据ID获取模板记录12702
        /// </summary>
        /// <param name="siteID"></param>
        /// <returns></returns>
        public static DataSet GetSiteCacheByID(params object[] para)
        {
            int siteID = (int)para[0];
            DataSet _DS = null;
            if (siteID > 0)
            {
                try
                {
                    IDALSiteCache _DAL = new DALSiteCache();
                    _DS = _DAL.GetSiteCacheByID(siteID);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("SiteCache.GetSiteCacheByID Exception:" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
    }
}
