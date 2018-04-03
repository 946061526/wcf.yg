using System.Data;

namespace wcfNSYGShop
{
    public interface IDALMonitor
    {
        /// <summary>
        /// 读取数据库监控信息
        /// </summary>
        /// <returns></returns>
        DataSet GetMonitorMsg();

        /// <summary>
        /// 更新监控信息发送短信的标识
        /// </summary>
        /// <returns></returns>
        int UpdateMonitorIsSend();
    }
}
