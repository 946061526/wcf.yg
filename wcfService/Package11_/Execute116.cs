using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 获取链接列表11603
        /// <summary>
        /// 获取链接列表11603
        /// </summary>
        /// <param name="type">类别</param>
        /// <returns></returns>
        public static DataSet GetLinksInfoByType(params object[] para)
        {
            int type = (int)para[0];
            DataSet _DS = null;
            try
            {
                IDALLinks _DAL = new DALLinks();
                _DS = _DAL.GetLinksInfoByType(type);
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("Links.GetLinksInfoByType Exception:" + ex.Message);
            }
            return _DS;
        }
        #endregion
    }
}
