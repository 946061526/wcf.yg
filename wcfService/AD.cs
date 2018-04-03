using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class WCFServiceFun
    {
        #region 根据分类ID获取可显示的广告列表
        /// <summary>
        /// 根据分类ID获取可显示的广告列表
        /// </summary>
        /// <param name="sortID">分类ID号</param>
        /// <returns></returns>
        public DataSet GetADListForPage( int sortID )
        {
            DataSet _DS = null;
            if ( sortID > 0 )
            {
                try
                {
                    IDALAD _DAL = new DALAD();
                    _DS = _DAL.GetADListForPage( sortID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "AD.GetADListForPage抛出异常：" + ex.Message );
                }
            }
            return _DS;
        } 
        #endregion
    }
}
