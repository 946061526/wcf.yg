using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class WCFServiceFun
    {
        #region 获取链接列表
        /// <summary>
        /// 获取链接列表
        /// </summary>
        /// <param name="type">类别</param>
        /// <returns></returns>
        public DataSet GetLinksInfoByType( int type )
        {
            DataSet _DS = null;
            try
            {
                IDALLinks _DAL = new DALLinks();
                _DS = _DAL.GetLinksInfoByType( type );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Links.GetLinksInfoByType Exception:" + ex.Message );
            }
            return _DS;
        }
        #endregion
    }
}
