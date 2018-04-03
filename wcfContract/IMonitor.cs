using System;
using System.Data;
using System.ServiceModel;

namespace wcfNSYGShop
{
    public partial interface IWCFContract
    {
     
        /// <summary>
        /// 读取数据库监控信息
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        DataSet GetMonitorMsg();

        /// <summary>
        /// 更新监控信息发送短信的标识
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        int UpdateMonitorIsSend();
    }
}
