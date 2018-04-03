using System.Data;

namespace wcfNSYGShop
{
    public class DALMonitor : DALBase, IDALMonitor
    {
        /// <summary>
        /// 读取数据库监控信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetMonitorMsg()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_dbmonitor.sp_getmonitormsg" );
        }

        /// <summary>
        /// 更新监控信息发送短信的标识
        /// </summary>
        /// <returns></returns>
        public int UpdateMonitorIsSend()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_dbmonitor.f_modmonitorissend" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
    }
}
