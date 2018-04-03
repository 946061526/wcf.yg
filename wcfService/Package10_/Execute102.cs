using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 根据分类ID获取可显示的广告列表10204
        /// <summary>
        /// 根据分类ID获取可显示的广告列表10204
        /// </summary>
        /// <param name="sortID">分类ID号</param>
        /// <returns></returns>
        public static DataSet GetADListForPage(params object[] para)
        {
            int sortID = (int)para[0];
            DataSet _DS = null;
            if (sortID > 0)
            {
                try
                {
                    IDALAD _DAL = new DALAD();
                    _DS = _DAL.GetADListForPage(sortID);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("AD.GetADListForPage抛出异常：" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
    }
}
