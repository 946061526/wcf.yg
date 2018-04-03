using System;
using System.Configuration;
using Oracle.DataAccess.Client;

namespace wcfNSYGShop
{
    /// <summary>
    /// 创建OracleConnection、OracleCommand、OracleDataAdapter实例的工厂
    /// </summary>
    public static class OracleCommonFactory
    {
        #region 定义成员

        /// <summary>
        /// 数据库SQL执行超时默认15秒。
        /// </summary>
        public static readonly int CommandTimeout = System.Convert.ToInt32( ConfigurationManager.AppSettings["commandTimeout"] );

        /// <summary>
        /// 数据库节点数量
        /// </summary>
        public static readonly int DBNodeNum = System.Convert.ToInt32( ConfigurationManager.AppSettings["dbNodeNum"] );

        /// <summary>
        /// 是否启用日志监控
        /// </summary>
        public static bool IsMonitor = false;

        /// <summary>
        /// 是否清除相应节点的数据库连接池
        /// 0为不清除，-1为清除全部连接池，大于0则为清除对应节点的连接池
        /// </summary>
        public static int clearPoolNode = 0;
        
        /// <summary>
        /// 默认的连接字符串。从webconfig获取。
        /// </summary>
        public static string[] ConnectionString = new string[DBNodeNum];

        #endregion

        #region 静态初始化，进行默认设置
        /// <summary>
        /// 静态初始化，进行默认设置
        /// </summary>
        static OracleCommonFactory()
        {
            ConnectionString[0] = "";
            for ( int i = 0; i < DBNodeNum; i++ )
            {
                ConnectionString[i] = ConfigurationManager.ConnectionStrings["connNode" + ( i + 1 )].ConnectionString;
            }
        }
        #endregion

        #region 创建Connection
        /// <summary>
        /// 根据数据库的连接方式创建一个Connection的实例,默认随机选一个节点
        /// </summary>
        /// <returns></returns>
        public static OracleConnection CreateConnection()
        {
            return new OracleConnection( ConnectionString[new Random().Next( 0, DBNodeNum )] );
        }
        /// <summary>
        /// 根据数据库的连接方式创建一个Connection的实例，使用指定的节点
        /// </summary>
        /// <param name="node">节点编号</param>
        /// <returns></returns>
        public static OracleConnection CreateConnection( int node )
        {
            return new OracleConnection( ConnectionString[node - 1] );
        }
        #endregion

        #region 创建Command
        /// <summary>
        /// 根据数据库的连接方式创建一个Command的实例
        /// </summary>
        /// <returns></returns>
        public static OracleCommand CreateCommand()
        {
            OracleCommand _Cmd = new OracleCommand();
            //_Cmd.Connection = CreateConnection();
            _Cmd.CommandTimeout = CommandTimeout;//根据配置文件设置超时时间
            _Cmd.BindByName = true;
            return _Cmd;
        }
        #endregion

        #region 创建DataAdapter
        /// <summary>
        /// 根据数据库的连接方式创建一个DataAdapter的实例，并设置查询命令
        /// </summary>
        /// <param name="command">DbCommand</param>
        /// <returns></returns>
        public static OracleDataAdapter CreateDataAdapter( OracleCommand command )
        {
            OracleDataAdapter _DA = new OracleDataAdapter( command );
            _DA.SelectCommand = command;
            return _DA;
        }
        #endregion
    }
}
