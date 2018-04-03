using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class WCFServiceFun
    {
        #region 获取某区域ID下的子区域列表
        /// <summary>
        /// 获取某区域ID下的子区域列表
        /// </summary>
        /// <param name="sortID">区域ID</param>
        /// <returns></returns>
        public DataSet GetChildAreaByID( int areaID )
        {
            DataSet _DS = null;
            if ( areaID > 0 )
            {
                try
                {
                    IDALBaseArea _DAL = new DALBaseArea();
                    _DS = _DAL.GetChildAreaByID( areaID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "BaseArea.GetChildArea抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
    }
}
