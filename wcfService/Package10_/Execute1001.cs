using System;
using System.Data;

namespace wcfNSYGShop
{
 
    public partial class ExecuteFun
    {
        #region 读取数据库监控信息100101
        /// <summary>
        /// 读取数据库监控信息100101
        /// </summary>
        /// <returns></returns>
        public static DataSet GetMonitorMsg()
        {
            DataSet _DS = null;
            try
            {
                IDALMonitor _DAL = new DALMonitor();
                _DS = _DAL.GetMonitorMsg();
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("Monitor.GetMonitorMsg Exception:" + ex.Message);
            }
            return _DS;
        }
        #endregion
        #region 更新监控信息发送短信的标识100102
        /// <summary>
        /// 更新监控信息发送短信的标识100102
        /// </summary>
        /// <returns></returns>
        public static int UpdateMonitorIsSend()
        {
            int _Ret = 0;
            try
            {
                IDALMonitor _DAL = new DALMonitor();
                _Ret = _DAL.UpdateMonitorIsSend();
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("Monitor.UpdateMonitorIsSend Exception:" + ex.Message);
            }
            return _Ret;
        }
        #endregion

    }
}
