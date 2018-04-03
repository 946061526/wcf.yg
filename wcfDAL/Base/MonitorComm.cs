using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace wcfNSYGShop
{
    /// <summary>
    /// 监控数据库过程调用的工具类
    /// </summary>
    public static class MonitorComm
    {
        #region 静态变量
        /// <summary>
        /// 存储统计数据
        /// </summary>
        private static Dictionary<long, MdlMonitor> DictMonitor;
        /// <summary>
        /// 锁对象
        /// </summary>
        private static object DictLockObj;
        /// <summary>
        /// 写日志锁对象
        /// </summary>
        private static object LogLockObj;
        /// <summary>
        /// 写日志标记
        /// </summary>
        private static bool SaveLogFlag;
        #endregion

        static MonitorComm()
        {
            LogLockObj = new object();
            SaveLogFlag = false;
            DictLockObj = new object();
            DictMonitor = new Dictionary<long, MdlMonitor>();
        }

        /// <summary>
        /// 累加过程的调用次数
        /// </summary>
        /// <param name="moduleID">过程编号</param>
        /// <param name="invokePlat">调用平台：0.未知，1.PC，2.触屏，3.安卓，4.微信，5.苹果</param>
        public static void IncModuleExecuteNum( string invokeKey )
        {
            //ThreadPool.QueueUserWorkItem( new WaitCallback( MonitorComm.IncModuleExecuteNum ), invokeKey );
            new Thread( new ParameterizedThreadStart( MonitorComm.IncModuleExecuteNum ) ).Start( invokeKey );
        }

        /// <summary>
        /// 累加过程的调用次数
        /// </summary>
        /// <param name="moduleID">过程编号</param>
        /// <param name="invokePlat">调用平台：0.未知，1.PC，2.触屏，3.安卓，4.微信，5.苹果</param>
        private static void IncModuleExecuteNum( object invokeKey )
        {
            try
            {
                long _MonitorKey = long.Parse( DateTime.Now.ToString( "yyyyMMddHHmm" ) );
                string _InvokeKey = invokeKey.ToString();

                if ( !DictMonitor.ContainsKey( _MonitorKey ) )
                {
                    lock ( DictLockObj )
                    {
                        if ( !DictMonitor.ContainsKey( _MonitorKey ) )
                        {
                            DictMonitor.Add( _MonitorKey, new MdlMonitor() );

                            lock ( DictMonitor[_MonitorKey].LockObj )
                            {
                                DictMonitor[_MonitorKey].DictInvokers.Add( _InvokeKey, 1 );
                            }
                        }
                        else
                        {
                            DictMonitor[_MonitorKey].DictInvokers[_InvokeKey]++;
                        }
                    }
                }
                else
                {
                    if ( !DictMonitor[_MonitorKey].DictInvokers.ContainsKey( _InvokeKey ) )
                    {
                        lock ( DictMonitor[_MonitorKey].LockObj )
                        {
                            DictMonitor[_MonitorKey].DictInvokers.Add( _InvokeKey, 1 );
                        }
                    }
                    else
                    {
                        lock ( DictMonitor[_MonitorKey].LockObj )
                        {
                            DictMonitor[_MonitorKey].DictInvokers[_InvokeKey]++;
                        }
                    }
                }

                //每隔三分钟保存一次数据库
                if ( DateTime.Now.Minute % 3 == 0 )
                {
                    //确保只进来一次
                    if ( !SaveLogFlag )
                    {
                        lock ( LogLockObj )
                        {
                            if ( !SaveLogFlag )
                            {
                                SaveLogFlag = true;
                                Thread _SaveLogThread = new Thread( new ThreadStart( WriteExecuteLogToDB ) );
                                _SaveLogThread.Start();
                            }
                        }
                    }
                }
                else
                {
                    SaveLogFlag = false;
                }
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "MonitorComm.IncModuleExecuteNum Ex: " + ex.ToString() );
            }
        }

        /// <summary>
        /// 保存调用记录到数据库
        /// </summary>
        private static void WriteExecuteLogToDB()
        {
            try
            {
#if testV
                Console.WriteLine( "Time: " + DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss" ) );
#endif
                int _StartIdx = 0;
                int _EndIdx = DictMonitor.Count - 2;
                DictMonitor = DictMonitor.OrderBy( dict => dict.Key ).ToDictionary( dict => dict.Key, dict => dict.Value );
                foreach ( var key in new List<long>( DictMonitor.Keys ) )
                {
                    if ( _StartIdx < _EndIdx )
                    {
#if testV
                        Console.WriteLine( "KEY: " + key );
#endif
                        foreach ( var k in new List<string>( DictMonitor[key].DictInvokers.Keys ) )
                        {
#if testV
                            Console.WriteLine( "key:{0};num:{1}", k, DictMonitor[key].DictInvokers[k] );
#endif
                            DateTime _LogTime = DateTime.ParseExact( key.ToString(), "yyyyMMddHHmm", null );
                            string[] _TmpArr = k.Split( '|' );
                            UtilityFile.HttpPostXml( _LogTime, _TmpArr[0], _TmpArr[1], DictMonitor[key].DictInvokers[k] );
                        }
                        _StartIdx++;
                        DictMonitor.Remove( key );
                    }
                    else
                    {
                        break;
                    }
                }
#if testV
                Console.WriteLine( "" );
#endif
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "MonitorComm.WriteExecuteLogToDB Ex: " + ex.ToString() );
            }
        }
    }

    public class MdlMonitor
    {
        /// <summary>
        /// 构造方法 初始化属性
        /// </summary>
        public MdlMonitor()
        {
            DictInvokers = new Dictionary<string, int>();
            LockObj = new object();
        }
        /// <summary>
        /// 存储调用过程统计数据
        /// moduleID:num
        /// </summary>
        public Dictionary<string, int> DictInvokers
        {
            get;
            set;
        }
        /// <summary>
        /// 锁对象
        /// </summary>
        public object LockObj
        {
            get;
            set;
        }
    }
}
