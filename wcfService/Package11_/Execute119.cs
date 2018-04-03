using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 获取新闻信息11904
        /// <summary>
        /// 获取新闻信息11904
        /// </summary>
        /// <param name="newsID">新闻ID</param>
        /// <returns></returns>
        public static DataSet GetNewsInfoByID(params object[] para)
        {
            int newsID = (int)para[0];
            DataSet _DS = null;
            if (newsID > 0)
            {
                try
                {
                    IDALNews _DAL = new DALNews();
                    _DS = _DAL.GetNewsInfoByID(newsID);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("News.GetNewsInfoByID Exception:" + ex.Message);
                }
            }
            return _DS;
        }
        #endregion
    }
}
