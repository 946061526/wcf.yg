using System.Data;
using Oracle.DataAccess.Client;

namespace wcfNSYGShop
{
    /// <summary>
    /// 数据访问函数库的基类
    /// </summary>
    public partial class OracleDataAccessLibrary
    {

        #region 内部成员。_ 下划线开始的是类的内部成员，小写字母开头的是函数内部成员

        /// <summary>
        /// 出现异常时，记录出错信息，包括访问的网页、SQL语句、错误原因、访问时间等
        /// 对于外部（调用者）来说是只读的，而对于内部或者子类来说是可以写入的，所以protected
        /// </summary>
        protected string _ErrorMessage;

        /// <summary>
        /// 获取执行SQL查询语句后影响的行数
        /// 对于外部（调用者）来说是只读的，而对于内部或者子类来说是可以写入的，所以protected
        /// </summary>
        protected int _ExecuteRowCount;

        /// <summary>
        /// 标记是否已经启用了ado.net 事务
        /// </summary>
        private bool _IsUseTrans;

        #endregion

        #region 内部对象
        /// <summary>
        /// 一个DbCommand， 函数库的核心
        /// </summary>
        public OracleCommand Command;

        /// <summary>
        /// 处理存储过程参数的管理部分
        /// </summary>
        private OracleManagerParameter _ParameterManager;

        /// <summary>
        /// 处理事务的管理部分
        /// </summary>
        private OracleManagerTran _TranManager;

        /// <summary>
        /// 标记事务是否已初始化
        /// </summary>
        private bool _TranIsSetNode;

        #endregion

        #region 属性

        #region ErrorMessage。记录出错信息
        /// <summary>
        /// 获取出错信息，没有错误的话返回string.Empty 
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return _ErrorMessage;
            }
        }
        #endregion

        #region ExecuteRowCount。记录执行sql影响的行数
        /// <summary>
        /// 获取执行SQL语句影响的行数
        /// </summary>
        public int ExecuteRowCount
        {
            get
            {
                return _ExecuteRowCount;
            }
        }
        #endregion

        #region IsUseTrans。标记是否已经启用了ado.net 事务
        /// <summary>
        /// 标记是否已经启用了ado.net 事务
        /// </summary>
        public bool IsUseTrans
        {
            set
            {
                _IsUseTrans = value;
            }
            get
            {
                return _IsUseTrans;
            }
        }
        #endregion

        #region TranIsSetNode 标记事务是否已初始化
        /// <summary>
        /// 是否已分配节点，即完成初始化事务
        /// </summary>
        public bool TranIsSetNode
        {
            set
            {
                _TranIsSetNode = value;
            }
            get
            {
                return _TranIsSetNode;
            }
        }
        #endregion

        //加载辅助管理的实例

        #region 加载事务处理的管理部分
        /// <summary>
        /// 加载事务处理的实例。用这个实例来添加事务处理的参数
        /// </summary>
        public OracleManagerTran TranManager
        {
            get
            {
                if ( _TranManager == null )
                {
                    _TranManager = new OracleManagerTran();
                    _TranManager._Dal = this;   //对应ManagerParameter类中的internal DataAccessLibrary _Dal;
                }
                return _TranManager;
            }
        }
        #endregion

        #region 加载存储过程的参数
        /// <summary>
        /// 加载处理存储过程参数的实例。用这个实例来添加存储过程的参数
        /// </summary>
        public OracleManagerParameter ParameterManager
        {
            get
            {
                if ( _ParameterManager == null )
                {
                    _ParameterManager = new OracleManagerParameter();
                    _ParameterManager._Dal = this;   //对应ManagerParameter类中的internal DataAccessLibrary _Dal;
                }
                return _ParameterManager;
            }
        }
        #endregion

        #endregion

        //===============================

        #region 无参初始化
        /// <summary>
        /// 初始化。使用配置文件的配置进行创建
        /// </summary>
        public OracleDataAccessLibrary()
        {
            Command = OracleCommonFactory.CreateCommand();
        }
        #endregion

        #region 打开数据库连接
        /// <summary>
        /// 在使用DataReader或者开始事务的时候，需要手动打开连接。
        /// 注意：DataReader使用完毕之后必须手动关闭连接。
        /// </summary>
        public void ConnectionOpen()
        {
            if ( Command.Connection.State == ConnectionState.Broken || Command.Connection.State == ConnectionState.Closed )
            {
                Command.Connection.Open();
            }
        }
        #endregion

        #region 释放资源Dispose
        /// <summary>
        /// 关闭连接，不清除参数及事务
        /// </summary>
        public void ConnectionClose()
        {
            if ( Command.Connection != null )
            {
                Command.Connection.Close();
            }
        }
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            if ( _TranManager != null )
            {
                _TranManager = null;
            }
            if ( _ParameterManager != null )
            {
                _ParameterManager = null;
            }
            this._ErrorMessage = null;
            Command.Parameters.Clear();
            if ( Command.Connection != null )
            {
                Command.Connection.Close();
            }
            Command.Dispose();
        }
        #endregion

        #region 清除连接池
        /// <summary>
        /// 清除连接池
        /// </summary>
        /// <param name="nodeNum"></param>
        public void ClearPool( int nodeNum )
        {
            OracleConnection.ClearPool( OracleCommonFactory.CreateConnection( nodeNum ) );
        }
        /// <summary>
        /// 清除所有连接池
        /// </summary>
        public void ClearPool()
        {
            OracleConnection.ClearAllPools();
        }
        #endregion

        #region 设置Command的CommandText和CommandType
        /// <summary>
        /// 设置Command的CommandText和CommandType
        /// </summary>
        /// <param name="commandText"></param>
        public int SetCommand( string commandText )
        {
            this._ErrorMessage = string.Empty;      //清空出错信息
            this._ExecuteRowCount = 0;              //重置影响的行数

            //确定使用的数据库节点
            string _SPModle = "null";
            int _DBNode = 0;

            //当启用事务时且未分配节点，需初始连的事务，事务开启延后
            bool _IsInitTran = _IsUseTrans && !_TranIsSetNode;

            //未启用事务或连接关闭
            if ( !_IsUseTrans || _IsInitTran || Command.Connection.State == ConnectionState.Closed )
            {
                if ( Command.Parameters["i_module"] != null )
                {
                    _SPModle = Command.Parameters["i_module"].Value.ToString();
                    _DBNode = DBNodeConfig.GetNodeByModule( _SPModle );
                    Command.Connection = OracleCommonFactory.CreateConnection( _DBNode );
                }
                else
                {
                    Command.Connection = OracleCommonFactory.CreateConnection();
                }

                //初始事务
                if ( _IsInitTran )
                {
                    if ( Command.Connection.State == ConnectionState.Broken || Command.Connection.State == ConnectionState.Closed )
                    {
                        Command.Connection.Open();
                    }
                    _TranManager.DbTran = Command.Connection.BeginTransaction();//开始一个事务
                    Command.Transaction = _TranManager.DbTran;//交给Command
                    _TranIsSetNode = true;
                }
            }

            //目前所有都为存储过程调用方式
            if ( commandText.StartsWith( "yun" ) )
            {
                Command.CommandType = CommandType.StoredProcedure;
                if ( commandText.ToLower().Contains( "yun_erp" ) || commandText.ToLower().Contains( "yun_jd" ) )
                {
                    Command.CommandText = "yungou_erp." + commandText;
                }
                else
                {
                    Command.CommandText = "yungou_v1." + commandText;
                }
            }
            else
            {
                Command.CommandType = CommandType.Text;
                Command.CommandText = commandText;
            }

            //记录日志
            if ( OracleCommonFactory.IsMonitor )
            {
                UtilityFile.AddLogErrMsg( "nodemonitorlog", string.Format( "iModule:{0}, node:{1}, command:{2}, tranIsSetNode{3}, connstr:{4}", _SPModle, _DBNode, commandText, _TranIsSetNode, Command.Connection.DataSource ) );
            }

            return _DBNode;
        }
        #endregion

        #region 保存出错信息
        //设置出错信息
        /// <summary>
        /// 当发生异常时，所作的处理
        /// </summary>
        /// <param name="functionName">函数名称</param>
        /// <param name="commandText">查询语句或者存储过程</param>
        /// <param name="message">错误信息</param>
        public void SetErrorMessage( string functionName, int dbNode, string commandText, string message )
        {
            if ( IsUseTrans )
            {
                _TranManager.TranRollBack();			    //事务模式下：自动回滚事务，不用调用者回滚
            }
            this.Command.Connection.Close();		//关闭连接

            //设置返回给调用者的错误信息
            this._ErrorMessage = string.Format( "{1}函数出现异常。{0}错误信息：{2}{0}数据结点：{3}{0}查询语句：{4}", "\r\n", functionName, message, dbNode, commandText );

            if ( message.ToUpper().Contains( "ORA-01012" ) || message.ToUpper().Contains( "ORA-03113" ) )
            {
                UtilityFile.WriteClearPollFile( dbNode );
            }

            UtilityFile.AddLogErrMsg( "exesqlerror", this._ErrorMessage );
        }
        #endregion

    }
}