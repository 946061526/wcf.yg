using System;
using NSYGShop;

namespace wcfNSYGShop
{
    public class DALBase : IDALBase
    {

        private OracleDataAccessLibrary _Dal = new OracleDataAccessLibrary();
        private OracleManagerParameter _Para;

        #region 构造函数 初始参数、事务
        /// <summary>
        /// 构造函数
        /// </summary>
        public DALBase()
        {
            ///do fun()...
            _Para = _Dal.ParameterManager;

            //检查数据节点配置
            if ( DBNodeConfig.IsUpdate() )
            {
                try
                {
                    //读取清除节点连接池的配置
                    OracleCommonFactory.clearPoolNode = DBNodeConfig.ReadClearPoolConfig();
                    if ( OracleCommonFactory.clearPoolNode == -1 )
                    {
                        _Dal.ClearPool();
                        UtilityFile.AddLogErrMsg( "clearpool", string.Format( "已清除所有节点的数据库连接池", OracleCommonFactory.clearPoolNode ) );
                    }
                    else if ( OracleCommonFactory.clearPoolNode > 0 )
                    {
                        _Dal.ClearPool( OracleCommonFactory.clearPoolNode );
                        UtilityFile.AddLogErrMsg( "clearpool", string.Format( "已清除节点：{0} 的数据库连接池", OracleCommonFactory.clearPoolNode ) );
                    }

                    //更新是否启用监控配置
                    OracleCommonFactory.IsMonitor = UtilityFile.ReadMonitorSwitchFile() == 1;

                    //获取节点配置信息
                    Para.ClearOrcParameter();
                    Para.AddOrcNewCursorParameter( "o_result" );
                    DBNodeConfig.UpdateNodeConfig( Dal.ExecuteFillDataTable( "yun_others.sp_getmodulenode" ) );
                }
                catch ( Exception ex )
                {
                    DBNodeConfig.RollbackUpdateTime();
                    UtilityFile.AddLogErrMsg( "nodeupdate", string.Format( "检查数据节点配置时发生异常：{0}, {1}", ex.Message, ex.Source ) );
                }
            }
        }
        #endregion

        #region 数据类型转换及基本函数
        /// <summary>
        /// 数据库SQL Server最小时间为1753-01-01 12:00:00
        /// </summary>
        protected DateTime MinDTValue
        {
            get
            {
                return DateTime.Parse( "1753-01-01 12:00:00" );
            }
        }

        #region GetNowTime 返回系统当前时间 Edit:2010.12.27
        /// <summary>
        /// 返回系统当前时间
        /// </summary>
        /// <returns></returns>
        protected DateTime GetNowTime
        {
            get
            {
                return DateTime.Now;
            }
        }
        #endregion

        #region IsEmptyString(string str) 检查字符串是否为空 Edit:2010.12.27
        /// <summary>
        /// 检查字符串是否为空
        /// </summary>
        /// <param name="str">要检查的字符串</param>
        /// <returns>为空返回true;否则返回false;</returns>
        protected bool IsEmptyString( string str )
        {
            if ( string.IsNullOrEmpty( str ) || str == "" )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ToInt32(string refVal) 把字符串转换成整型，非数字返回0 Edit:2010.12.27
        /// <summary>
        /// 把字符串转换成整型，非数字返回0
        /// </summary>
        /// <param name="refVal">要转换的字符串</param>
        /// <returns></returns>
        protected int ToInt32( string refVal )
        {
            int _Result = 0;
            int.TryParse( refVal, out _Result );
            return _Result;
        }
        #endregion
        #region ToInt32(object refVal, int defaultVal) 把对象转换成整型，非数字返回defaultVal Edit:2011.08.03
        /// <summary>
        /// 把对象转换成整型，非数字返回defaultVal
        /// </summary>
        /// <param name="refVal">要转换的对象</param>
        /// <param name="defaultVal">不为整数时返回值</param>
        /// <returns></returns>
        protected int ToInt32( object refVal, int defaultVal )
        {
            if ( refVal == null )
            {
                return defaultVal;
            }
            else
            {
                int _Result = 0;
                if ( !int.TryParse( refVal.ToString(), out _Result ) )
                {
                    _Result = defaultVal;
                }
                return _Result;
            }
        }
        #endregion
        #region ToInt32(object refVal) 把对象转换成整型，非数字返回0 Edit:2011.08.03
        /// <summary>
        /// 把对象转换成整型，非数字返回0
        /// </summary>
        /// <param name="refVal">要转换的对象</param>
        /// <returns></returns>
        protected int ToInt32( object refVal )
        {
            return ToInt32( refVal, 0 );
        }
        #endregion
        #region ToInt64(string refVal) 把字符串转换成整型，非数字返回0 Edit:2010.12.27
        /// <summary>
        /// 把字符串转换成64整型，非数字返回0L
        /// </summary>
        /// <param name="refVal">要转换的字符串</param>
        /// <returns></returns>
        protected long ToInt64( string refVal )
        {
            if ( !IsEmptyString( refVal ) )
            {
                try
                {
                    return Convert.ToInt64( refVal );
                }
                catch
                {
                    return 0L;
                }
            }
            else
            {
                return 0L;
            }
        }
        #endregion
        #region ToInt64(object refVal) 把对象转换成整型，非数字返回0 Edit:2011.08.03
        /// <summary>
        /// 把对象转换成64整型，非数字返回0L
        /// </summary>
        /// <param name="refVal">要转换的对象</param>
        /// <returns></returns>
        protected long ToInt64( object refVal )
        {
            if ( refVal == null )
            {
                return 0L;
            }
            else
            {
                try
                {
                    return Convert.ToInt64( refVal );
                }
                catch
                {
                    return 0L;
                }
            }
        }
        #endregion

        #region ToDecimal(string refVal) 把字符串转换成Decimal，非数字返回0m Edit:2011.01.24
        /// <summary>
        /// 把字符串转换成Decimal，非数字返回0m
        /// </summary>
        /// <param name="refVal">要转换的字符串</param>
        /// <returns></returns>
        protected decimal ToDecimal( string refVal )
        {
            if ( !IsEmptyString( refVal ) )
            {
                try
                {
                    return Convert.ToDecimal( refVal );
                }
                catch
                {
                    return 0m;
                }
            }
            else
            {
                return 0m;
            }
        }
        #endregion
        #region ToDecimal(object refVal) 把对象转换成Decimal，非数字返回0m Edit:2011.08.05
        /// <summary>
        /// 把对象转换成Decimal，非数字返回0m
        /// </summary>
        /// <param name="refVal">要转换的对象</param>
        /// <returns></returns>
        protected decimal ToDecimal( object refVal )
        {
            if ( refVal == null )
            {
                return 0m;
            }
            else
            {
                try
                {
                    return Convert.ToDecimal( refVal );
                }
                catch
                {
                    return 0m;
                }
            }
        }
        #endregion

        #region ToDateTime(object refVal) 把对象转换成DateTime，非数字返回MinDTValue Edit:2011.08.05
        /// <summary>
        /// 把对象转换成DateTime，非数字返回MinDTValue
        /// </summary>
        /// <param name="refVal">要转换的对象</param>
        /// <returns></returns>
        protected DateTime ToDateTime( object refVal )
        {
            if ( refVal == null )
            {
                return MinDTValue;
            }
            else
            {
                try
                {
                    return Convert.ToDateTime( refVal );
                }
                catch
                {
                    return MinDTValue;
                }
            }
        }
        #endregion

        #region # ToNumber(string refVal, int defaultVal) 把字符串转换成整型 Edit:2010.12.27
        /// <summary>
        /// 把字符串转换成整型
        /// </summary>
        /// <param name="refVal">要转换的字符串</param>
        /// <param name="defaultVal">转换失败的缺省值</param>
        /// <returns>转换后的整型</returns>
        //protected int ToNumber(string refVal, int defaultVal) {
        //    if (!IsEmptyString(refVal)) {
        //        try {
        //            return Convert.ToInt32(refVal);
        //        } catch {
        //            return defaultVal;
        //        }
        //    } else {
        //        return defaultVal;
        //    }
        //}
        #endregion

        #region GetOrcTotalCount( int isCount, System.Data.DataSet ds )从查询返回数据数据DataSet中取得返回的总记录数
        /// <summary>
        /// 从查询返回数据数据DataSet中取得返回的总记录数
        /// </summary>
        /// <param name="isCount">是否统计总行数</param>
        /// <param name="ds">数据集</param>
        /// <returns></returns>
        protected int GetOrcTotalCount( int isCount, System.Data.DataSet ds )
        {
            return GetOrcTotalCount( isCount, ds, "TOTALROWS" );
        }
        /// <summary>
        /// 从查询返回数据数据DataSet中取得返回的总记录数
        /// </summary>
        /// <param name="isCount">是否统计总行数</param>
        /// <param name="ds">数据集</param>
        /// <param name="colName">统计结果列名</param>
        /// <returns></returns>
        protected int GetOrcTotalCount( int isCount, System.Data.DataSet ds, string colName )
        {
            int totalCount = 0;
            if ( isCount == 1 && ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 )
            {
                totalCount = ToInt32( ds.Tables[0].Rows[0][colName] );
            }
            return totalCount;
        }
        #endregion

        #region GetOrcReturnValue( System.Data.DataSet ds )从查询返回数据数据DataSet中取得返回值
        /// <summary>
        /// 从查询返回数据数据DataSet中取得返回值
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        protected int GetOrcReturnValue( System.Data.DataSet ds )
        {
            int _RetVal = 0;
            if ( ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 )
            {
                _RetVal = ToInt32( ds.Tables[0].Rows[0][0] );
                ds.Tables.RemoveAt( 0 );//移除掉存放返回值的表
            }
            return _RetVal;
        }
        #endregion

        #endregion

        #region Dal 数据库访问实例  Edit:2011.7.13
        /// <summary>
        /// 获取数据库访问实例
        /// </summary>
        protected OracleDataAccessLibrary Dal
        {
            get
            {
                return _Dal;
            }
        }
        #endregion
        #region Para 数据库访问实例的参数  Edit:2011.7.13
        /// <summary>
        /// 获取数据库访问实例的参数
        /// </summary>
        protected OracleManagerParameter Para
        {
            get
            {
                return _Para;
            }
        }
        #endregion

        #region DisposeConn() 关闭并释放连接对象资源  Edit:2010.02.08
        /// <summary>
        /// 关闭并释放连接资源
        /// </summary>
        public void DisposeConn()
        {
            _Dal.Dispose();
        }
        #endregion
        #region TranBegin() 事务开始  Edit:2010.02.08
        /// <summary>
        /// 启用事务
        /// </summary>
        public void TranBegin()
        {
            _Dal.TranManager.TranBegin();
        }
        #endregion
        #region TranCommit() 提交事务  Edit:2010.02.08
        /// <summary>
        /// 提交事务,并关闭连接
        /// </summary>
        public void TranCommit()
        {
            //如果事务标记有效，说明没有出错
            if ( _Dal.IsUseTrans )
            {
                _Dal.TranManager.TranCommit();
            }
        }
        #endregion
        #region TranRollBack() 回滚事务  Edit:2010.02.08
        /// <summary>
        /// 回滚事务,并关闭连接
        /// </summary>
        public void TranRollBack()
        {
            if ( _Dal.IsUseTrans )
            {
                _Dal.TranManager.TranRollBack();
            }
        }
        #endregion
        #region IsUseTrans 获取事务状态  Edit:2010.12.24
        /// <summary>
        /// 获取事务状态,true:表顺利执行
        /// </summary>
        public bool IsUseTrans
        {
            get
            {
                return _Dal.IsUseTrans;
            }
        }
        #endregion

        #region AddFailLog 记录业务处理失败日志  Edit:2015.14.29
        /// <summary>
        /// 记录业务处理失败日志
        /// </summary>
        public bool AddFailLog( object retVal )
        {
            return UtilityFile.AddLogErrMsg( "exesqlfail", string.Format( "sql:{0} retval:{1}", _Dal.Command.CommandText, retVal ) );
        }
        #endregion

    }
}
