using System;
using System.Collections.Generic;
using System.Data;

namespace wcfNSYGShop
{
    public static class DBNodeConfig
    {
        /// <summary>
        /// 数据库SQL执行超时默认15秒。
        /// </summary>
        private static DateTime configUpdateTime;
        private static SortedList<int, int> ModuleConfig;
        private static object UpdateLock = new object();

        static DBNodeConfig()
        {
            configUpdateTime = DateTime.Now.AddSeconds( -120 );//以达到先加载节点配置数据
            ModuleConfig = new SortedList<int, int>();
        }

        /// <summary>
        /// 根据模块编号获取分配的节点编号
        /// </summary>
        /// <param name="Module">模块编号</param>
        /// <returns></returns>
        public static int GetNodeByModule( string Module )
        {
            int _Node = 1;
            try
            {
                if ( ModuleConfig != null && ModuleConfig.Count > 0 )
                {
                    _Node = ModuleConfig[Convert.ToInt32( Module )];
                }
            }
            catch
            {
                _Node = 1;
            }
            return _Node;
        }

        /// <summary>
        /// 更新节点分配表
        /// </summary>
        /// <param name="configTable">节点分配表</param>
        /// <returns></returns>
        public static bool UpdateNodeConfig( DataTable configTable )
        {
            bool _Result = false;
            try
            {
                if ( configTable != null && configTable.Rows.Count > 0 )
                {
                    configUpdateTime = DateTime.Now;
                    foreach ( DataRow row in configTable.Rows )
                    {
                        int _ModeleID = Convert.ToInt32( row["moduleID"] );
                        int _ModeleNode = Convert.ToInt32( row["moduleNode"] );
                        if ( ModuleConfig.ContainsKey( _ModeleID ) )
                        {
                            ModuleConfig[_ModeleID] = _ModeleNode;
                        }
                        else
                        {
                            ModuleConfig.Add( _ModeleID, _ModeleNode );
                        }
                    }
                    _Result = true;
                    if ( OracleCommonFactory.IsMonitor )
                    {
                        UtilityFile.AddLogErrMsg( "nodeupdate", "更新节点配置表成功" );
                    }
                }
                else if ( OracleCommonFactory.IsMonitor )
                {
                    UtilityFile.AddLogErrMsg( "nodeupdate", "更新节点配置时获取配置表无记录" );
                }
            }
            catch ( Exception ex )
            {
                _Result = false;
                configUpdateTime = DateTime.Now.AddSeconds( -60 );
                UtilityFile.AddLogErrMsg( "nodeupdate", string.Format( "更新节点配置时发生异常：{0}, {1}", ex.Message, ex.Source ) );
            }
            return _Result;
        }


        /// <summary>
        /// 判断是否需要更新节点分配表信息
        /// </summary>
        /// <param name="configTable">节点分配表</param>
        /// <returns></returns>
        public static bool IsUpdate()
        {
            bool _Result = false;
            lock ( UpdateLock )
            {
                if ( configUpdateTime.AddSeconds( 60 ) < DateTime.Now )
                {
                    configUpdateTime = DateTime.Now;
                    _Result = true;
                }
            }
            return _Result;
        }

        /// <summary>
        /// 回滚更新时间
        /// </summary>
        public static void BackrollUpdateTime()
        {
            configUpdateTime = DateTime.Now.AddSeconds( -61 );
        }
    }
}
