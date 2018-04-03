using System;
using System.Data;
using System.Threading;
using Oracle.DataAccess.Client;

namespace wcfNSYGShop
{
    /// <summary>
    /// 数据访问函数库
    /// </summary>
    public partial class OracleDataAccessLibrary
    {
        // - close 表示：启用了事务，则没有关闭连接，否则关闭了。
        // + close 表示：不管有没启用事务，都关闭了连接。

        #region ExecuteFillDataSet + close
        /// <summary>
        /// 运行SQL语句、参数化的SQL语句或者存储过程，返回DataSet。
        /// 可以传入多条查询语句，返回的DataSet里会有多个DataTable
        /// </summary>
        /// <param name="text">查询语句或者存储过程的名称。
        /// 比如select * from tableName1 select * from tableName2
        /// 或者 pro_xxxGetDataSet
        /// </param>
        /// <returns>返回DataSet</returns>
        public virtual DataSet ExecuteFillDataSet( string text )
        {
            //设置command
            int _DBNode = SetCommand( text );
            //创建一个DataAdapter，用于填充数据
            OracleDataAdapter _DA = OracleCommonFactory.CreateDataAdapter( Command );
            try
            {
#if testV
                DateTime _Start = DateTime.Now;
#endif
                DataSet _DS = new DataSet();
                _DA.Fill( _DS );  //打开数据库，填充数据
#if testV
                int _UseTime = (int)DateTime.Now.Subtract( _Start ).TotalMilliseconds;
                if ( _UseTime > 1000 )
                {
                    UtilityFile.AddLogErrMsg( "timeout", string.Format( "usetime:{0}, command:{1}", _UseTime, text ) );
                }
#endif
                return _DS;
            }
            catch ( Exception ex )
            {
                SetErrorMessage( "ExecuteFillDataSet", _DBNode, Command.CommandText, ex.Message );    //处理错误
                return null;
            }
            finally
            {
                //自动关闭了，不用手动关闭。
                _DA.Dispose();

                if ( Command.Parameters["i_module"] != null )
                {
                    MonitorComm.IncModuleExecuteNum( Command.Parameters["i_module"].Value + "|0" );
                }
            }
        }
        #endregion

        #region ExecuteFillDataTable + close
        /// <summary>
        /// 运行SQL语句、参数化的SQL语句或者存储过程，返回DataTable记录集
        /// </summary>
        /// <param name="text">查询语句或者存储过程的名称。
        /// 比如select * from tableName1 
        /// 或者 pro_xxxGetDataTable
        /// </param>
        /// <returns></returns>
        public virtual DataTable ExecuteFillDataTable( string text )
        {
            //设置command
            int _DBNode = SetCommand( text );
            OracleDataAdapter _DA = OracleCommonFactory.CreateDataAdapter( Command );
            try
            {
#if testV
                DateTime _Start = DateTime.Now;
#endif
                DataTable _DT = new DataTable();
                _DA.Fill( _DT );
#if testV
                int _UseTime = (int)DateTime.Now.Subtract( _Start ).TotalMilliseconds;
                if ( _UseTime > 1000 )
                {
                    UtilityFile.AddLogErrMsg( "timeout", string.Format( "usetime:{0}, command:{1}", _UseTime, text ) );
                }
#endif
                return _DT;
            }
            catch ( Exception ex )
            {
                SetErrorMessage( "ExecuteFillDataTable", _DBNode, Command.CommandText, ex.Message );	//处理错误
                return null;
            }
            finally
            {
                //自动关闭了，不用手动关闭。
                _DA.Dispose();

                if ( Command.Parameters["i_module"] != null )
                {
                    MonitorComm.IncModuleExecuteNum( Command.Parameters["i_module"].Value + "|0" );
                }
            }

        }
        #endregion

        #region ExecuteString - close
        /// <summary>
        /// 运行SQl语句返回第一条记录的第一个字段的值，无则返回Null。区分内部函数调用的情况
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Null</returns>
        public virtual string ExecuteString( string text )
        {
            int _DBNode = SetCommand( text );		//设置command
            OracleDataReader _DR = null;
            try
            {
#if testV
                DateTime _Start = DateTime.Now;
#endif
                this.ConnectionOpen();
                _DR = Command.ExecuteReader( CommandBehavior.SingleRow );
                string _ReVal = "";
                if ( _DR.Read() )
                {
                    _ReVal = _DR.GetValue( 0 ).ToString();
                }
                else
                {
                    _ReVal = null;
                }
#if testV
                int _UseTime = (int)DateTime.Now.Subtract( _Start ).TotalMilliseconds;
                if ( _UseTime > 1000 )
                {
                    UtilityFile.AddLogErrMsg( "timeout", string.Format( "usetime:{0}, command:{1}", _UseTime, text ) );
                }
#endif
                return _ReVal;

            }
            catch ( Exception ex )
            {
                SetErrorMessage( "ExecuteString", _DBNode, Command.CommandText, ex.Message );	//处理错误
                return null;
            }
            finally
            {
                if ( _DR != null )
                {
                    _DR.Close();
                }
                if ( !IsUseTrans )
                {
                    //判断是否使用了事务，没有使用事务的情况下，才可以关闭连接
                    this.ConnectionClose();
                }

                if ( Command.Parameters["i_module"] != null )
                {
                    MonitorComm.IncModuleExecuteNum( Command.Parameters["i_module"].Value + "|0" );
                }
            }
        }
        #endregion

        #region ExecuteReader - close
        /// <summary>
        /// 运行SQl语句返回查询结果，无则返回Null。区分内部函数调用的情况
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Null</returns>
        public virtual OracleDataReader ExecuteReader( string text )
        {
            int _DBNode = SetCommand( text );		//设置command
            try
            {
                this.ConnectionOpen();
                return Command.ExecuteReader( CommandBehavior.CloseConnection );
            }
            catch ( Exception ex )
            {
                SetErrorMessage( "ExecuteReader", _DBNode, Command.CommandText, ex.Message );	//处理错误
                return null;
            }
            finally
            {
                if ( Command.Parameters["i_module"] != null )
                {
                    MonitorComm.IncModuleExecuteNum( Command.Parameters["i_module"].Value + "|0" );
                }
            }
        }
        #endregion

        #region ExecuteStringsBySingleRow - close
        /// <summary>
        /// 运行SQl语句返回第一条记录的数组。返回字符串数组,无则返回Null
        /// </summary>
        /// <param name="text">查询语句。比如select top 1 * from tableName</param>
        /// <returns></returns>
        public virtual string[] ExecuteStringsBySingleRow( string text )
        {
            //返回ID 传入查询语句，返回第一条记录的数组
            int _DBNode = SetCommand( text );		//设置command
            OracleDataReader _DR = null;
            try
            {
                this.ConnectionOpen();
                _DR = Command.ExecuteReader();
                string[] _StrArr = null;
                if ( _DR.Read() )
                {
                    int ArrLength = _DR.FieldCount;
                    _StrArr = new string[ArrLength];
                    for ( int i = 0; i < ArrLength; i++ )
                    {
                        _StrArr[i] = _DR.GetValue( i ).ToString();
                    }
                }
                return _StrArr;
            }
            catch ( Exception ex )
            {
                SetErrorMessage( "ExecuteStringsBySingleRow", _DBNode, Command.CommandText, ex.Message );	//处理错误
                return null;
            }
            finally
            {
                if ( _DR != null )
                {
                    _DR.Close();
                }
                if ( !IsUseTrans )
                {
                    //判断是否使用了事务，没有使用事务的情况下，才可以关闭连接
                    this.ConnectionClose();
                }
                if ( Command.Parameters["i_module"] != null )
                {
                    MonitorComm.IncModuleExecuteNum( Command.Parameters["i_module"].Value + "|0" );
                }
            }
        }
        #endregion

        #region ExecuteStringsByColumns - close
        /// <summary>
        /// 运行SQl语句返回每一条记录的第一个字段的值。返回字符串数组
        /// </summary>
        /// <param name="text">查询语句。比如select myName from tableName</param>
        /// <returns></returns>
        public virtual string[] ExecuteStringsByColumns( string text )
        {
            //传入查询语句，返回每条记录的第一的字段的值
            int _DBNode = SetCommand( text );		//设置command
            OracleDataReader _DR = null;
            try
            {
                this.ConnectionOpen();

                _DR = Command.ExecuteReader();
                //int i = 0;
                System.Collections.IList _List = new System.Collections.ArrayList();
                while ( _DR.Read() )
                {
                    _List.Add( _DR[0].ToString() );
                }
                string[] _StrArr = new string[_List.Count];
                _List.CopyTo( _StrArr, 0 );
                return _StrArr;

            }
            catch ( Exception ex )
            {
                SetErrorMessage( "ExecuteStringsByColumns", _DBNode, Command.CommandText, ex.Message );	//处理错误
                return null;
            }
            finally
            {
                if ( _DR != null )
                {
                    _DR.Close();
                }
                if ( !IsUseTrans )
                {
                    //判断是否使用了事务，没有使用事务的情况下，才可以关闭连接
                    this.ConnectionClose();
                }
                if ( Command.Parameters["i_module"] != null )
                {
                    MonitorComm.IncModuleExecuteNum( Command.Parameters["i_module"].Value + "|0" );
                }
            }
        }
        #endregion

        #region ExecuteNonQuery - close
        /// <summary>
        /// 运行SQL查询语句，不返回记录集。用于添加、修改、删除等操作。区分内部函数调用的情况
        /// </summary>
        /// <param name="sql">查询语句。比如insert into tableName 、update tableName...</param>
        /// <returns></returns>
        public virtual void ExecuteNonQuery( string sql )
        {
            int _DBNode = SetCommand( sql );		//设置command
            try
            {
#if testV
                DateTime _Start = DateTime.Now;
#endif
                this.ConnectionOpen();
                _ExecuteRowCount = Command.ExecuteNonQuery();
#if testV
                int _UseTime = (int)DateTime.Now.Subtract( _Start ).TotalMilliseconds;
                if ( _UseTime > 1000 )
                {
                    UtilityFile.AddLogErrMsg( "timeout", string.Format( "usetime:{0}, command:{1}", _UseTime, sql ) );
                }
#endif
            }
            catch ( Exception ex )
            {
                SetErrorMessage( "ExecuteNonQuery", _DBNode, Command.CommandText, ex.Message );	//处理错误
            }
            finally
            {
                if ( !IsUseTrans )
                {
                    //判断是否使用了事务，没有使用事务的情况下，才可以关闭连接
                    this.ConnectionClose();
                }
                if ( Command.Parameters["i_module"] != null )
                {
                    MonitorComm.IncModuleExecuteNum( Command.Parameters["i_module"].Value + "|0" );
                }
            }
        }
        #endregion

        #region ExecuteExists - close
        /// <summary>
        /// 执行一条SQL语句，看是否能查到记录 有：返回true；没有返回false，用于判断是否重名
        /// </summary>
        /// <param name="sql">查询语句。比如select ID from tableName where userName='aa'</param>
        /// <returns></returns>
        public virtual bool ExecuteExists( string sql )
        {
            int _DBNode = SetCommand( sql );
            OracleDataReader _DR = null;
            try
            {
                this.ConnectionOpen();
                _DR = Command.ExecuteReader();
                return _DR.HasRows;
            }
            catch ( Exception ex )
            {
                SetErrorMessage( "ExecuteExists", _DBNode, Command.CommandText, ex.Message );	//处理错误
                return true;
            }
            finally
            {
                if ( _DR != null )
                {
                    _DR.Close();
                }
                if ( !IsUseTrans )
                {
                    //判断是否使用了事务，没有使用事务的情况下，才可以关闭连接
                    this.ConnectionClose();
                }
                if ( Command.Parameters["i_module"] != null )
                {
                    MonitorComm.IncModuleExecuteNum( Command.Parameters["i_module"].Value + "|0" );
                }
            }
        }
        #endregion

    }
}
