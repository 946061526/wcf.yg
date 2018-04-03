using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 插入举报用户记录14601
        /// <summary>
        /// 插入举报用户记录14601
        /// </summary>
        /// <param name="userID">举报人ID</param>
        /// <param name="reportUserID">被举报人ID</param>
        /// <param name="type">举报类型，1.钓鱼欺诈 2.广告骚扰 3.色情暴力 4.其它</param>
        /// <param name="content">举报人说的话</param>
        /// <param name="device">举报的客户端，1.安桌 2.苹果 3.触屏版 4.电脑PC 5.微信</param>
        /// <returns></returns>
        public static int InsertReportUser(params object[] para)
        {
            int _Result = 0;
            int _UserID = (int)para[0];
            int _ReportUserID = (int)para[1];
            int _Type = (int)para[2];
            string _Content = (string)para[3];
            int _Device = (int)para[4];
            if (_UserID > 0 && _ReportUserID > 0)
            {
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.InsertReportUser(_UserID, _ReportUserID, 0, 0, 0, _Type, 0, _Content, "", _Device, "");
                _DAL = null;
            }
            return _Result;
        }
        #endregion
    }
}
