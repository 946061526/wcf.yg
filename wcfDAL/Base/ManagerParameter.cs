using System;
using System.Data;
using System.Data.Common;
using Oracle.DataAccess.Client;

namespace wcfNSYGShop
{
    /// <summary>
    /// 处理OracleParameterSQL语句的参数
    /// </summary>
    public class OracleManagerParameter
    {
        /// <summary>
        /// 数据访问函数库的实例，主要是想操作Command
        /// </summary>
        internal OracleDataAccessLibrary _Dal;

        #region 索引器
        /// <summary>
        /// 对参数的一种封装
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <returns></returns>
        public OracleParameter this[string parameterName]
        {
            get
            {
                return _Dal.Command.Parameters[parameterName];
            }
            set
            {
                _Dal.Command.Parameters[parameterName] = value;
            }
        }

        /// <summary>
        /// 对参数的一种封装
        /// </summary>
        /// <param name="parameterIndex">参数名称</param>
        /// <returns></returns>
        public OracleParameter this[int parameterIndex]
        {
            get
            {
                return _Dal.Command.Parameters[parameterIndex];
            }
            set
            {
                _Dal.Command.Parameters[parameterIndex] = value;
            }
        }
        #endregion

        #region 清除参数
        /// <summary>
        /// 清除Command的存储过程的参数。
        /// </summary>
        public virtual void ClearOrcParameter()
        {
            _Dal.Command.Parameters.Clear();
        }
        #endregion

        #region 存储过程的参数部分——取参数的返回值
        /// <summary>
        /// 按序号返回参数值，一般在执行完存储过程后使用
        /// </summary>
        /// <param name="ParameterIndex">序号</param>
        /// <returns>返回参数的内容</returns>
        public string GetOrcParameter( int ParameterIndex )
        {
            return _Dal.Command.Parameters[ParameterIndex].Value.ToString();
        }

        /// <summary>
        /// 按名称返回参数值，一般在执行完存储过程后使用
        /// </summary>
        /// <param name="ParameterName">参数名称。比如 @UserName</param>
        /// <returns>返回参数的内容</returns>
        public string GetOrcParameter( string ParameterName )
        {
            return _Dal.Command.Parameters[ParameterName].Value.ToString();
        }
        #endregion

        #region Oracle参数配置
        /// <summary>
        /// Oracle添加String输入参数
        /// </summary>
        /// <param name="paraName">参数名</param>
        /// <param name="paraValue">参数值</param>
        public void AddOrcNewInParameter( string paraName, string paraValue )
        {
            OracleParameter _Para = new OracleParameter();
            _Para.ParameterName = paraName;
            _Para.OracleDbTypeEx = OracleDbType.Varchar2;
            _Para.Value = paraValue;
            _Para.Direction = System.Data.ParameterDirection.Input;
            _Dal.Command.Parameters.Add( _Para );
            _Para = null;
        }
        /// <summary>
        /// Oracle添加DateTime输入参数
        /// </summary>
        /// <param name="paraName">参数名</param>
        /// <param name="paraValue">参数值</param>
        public void AddOrcNewInParameter( string paraName, DateTime paraValue )
        {
            OracleParameter _Para = new OracleParameter();
            _Para.ParameterName = paraName;
            _Para.OracleDbTypeEx = OracleDbType.Varchar2;
            _Para.Value = paraValue.ToString( "yyyy-MM-dd HH:mm:ss.fff" );
            _Para.Direction = System.Data.ParameterDirection.Input;
            _Dal.Command.Parameters.Add( _Para );
            _Para = null;
        }
        /// <summary>
        /// Oracle添加Int32输入参数
        /// </summary>
        /// <param name="paraName">参数名</param>
        /// <param name="paraValue">参数值</param>
        public void AddOrcNewInParameter( string paraName, Int32 paraValue )
        {
            OracleParameter _Para = new OracleParameter();
            _Para.ParameterName = paraName;
            _Para.OracleDbTypeEx = OracleDbType.Int32;
            _Para.Value = paraValue;
            _Para.Direction = System.Data.ParameterDirection.Input;
            _Dal.Command.Parameters.Add( _Para );
            _Para = null;
        }
        /// <summary>
        /// Oracle添加Int64输入参数
        /// </summary>
        /// <param name="paraName">参数名</param>
        /// <param name="paraValue">参数值</param>
        public void AddOrcNewInParameter( string paraName, Int64 paraValue )
        {
            OracleParameter _Para = new OracleParameter();
            _Para.ParameterName = paraName;
            _Para.OracleDbTypeEx = OracleDbType.Int64;
            _Para.Value = paraValue;
            _Para.Direction = System.Data.ParameterDirection.Input;
            _Dal.Command.Parameters.Add( _Para );
            _Para = null;
        }
        /// <summary>
        /// Oracle添加Double输入参数
        /// </summary>
        /// <param name="paraName">参数名</param>
        /// <param name="paraValue">参数值</param>
        public void AddOrcNewInParameter( string paraName, Double paraValue )
        {
            OracleParameter _Para = new OracleParameter();
            _Para.ParameterName = paraName;
            _Para.OracleDbTypeEx = OracleDbType.Double;
            _Para.Value = paraValue;
            _Para.Direction = System.Data.ParameterDirection.Input;
            _Dal.Command.Parameters.Add( _Para );
            _Para = null;
        }
        /// <summary>
        /// Oracle添加Decimal输入参数
        /// </summary>
        /// <param name="paraName">参数名</param>
        /// <param name="paraValue">参数值</param>
        public void AddOrcNewInParameter( string paraName, Decimal paraValue )
        {
            OracleParameter _Para = new OracleParameter();
            _Para.ParameterName = paraName;
            _Para.OracleDbTypeEx = OracleDbType.Decimal;
            _Para.Value = paraValue;
            _Para.Direction = System.Data.ParameterDirection.Input;
            _Dal.Command.Parameters.Add( _Para );
            _Para = null;
        }

        /// <summary>
        /// Oracle添加输出参数
        /// </summary>
        /// <param name="paraName">参数名</param>
        /// <param name="dbType">0：字符串，1：数字</param>
        /// <param name="size">参数长度，不定义会报异长[ORA-06502: PL/SQL: numeric or value error]</param>
        public void AddOrcNewOutParameter( string paraName, int dbType, int size )
        {
            OracleParameter _Para = new OracleParameter();
            _Para.ParameterName = paraName;
            switch ( dbType )
            {
                case 0:
                    _Para.OracleDbType = OracleDbType.Varchar2;
                    break;
                case 1:
                    _Para.OracleDbType = OracleDbType.Int32;
                    break;
            }
            _Para.Direction = System.Data.ParameterDirection.Output;
            if ( size > 0 )
            {
                _Para.Size = size;
            }
            _Dal.Command.Parameters.Add( _Para );
            _Para = null;
        }

        /// <summary>
        /// Oracle添加游标参数
        /// </summary>
        /// <param name="paraName">参数名</param>
        public void AddOrcNewCursorParameter( string paraName )
        {
            OracleParameter _Para = new OracleParameter();
            _Para.ParameterName = paraName;
            //_Para.OracleDbType = OracleDbType.RefCursor;
            _Para.OracleDbTypeEx = OracleDbType.RefCursor;
            _Para.Direction = System.Data.ParameterDirection.Output;
            _Dal.Command.Parameters.Add( _Para );
            _Para = null;
        }

        /// <summary>
        /// Oracle添加返回值参数
        /// </summary>
        /// <param name="paraName">参数名</param>
        /// <param name="dbType">0：字符串，1：数字</param>
        public void AddOrcNewReturnParameter( string paraName, int dbType )
        {
            OracleParameter _Para = new OracleParameter();
            _Para.ParameterName = paraName;
            switch( dbType )
            {
                case 0:
                    //_Para.OracleDbType = OracleDbType.Varchar2;
                    _Para.OracleDbTypeEx = OracleDbType.Varchar2;
                    break;
                case 1:
                    //_Para.OracleDbType = OracleDbType.Int32;
                    _Para.OracleDbTypeEx = OracleDbType.Int32;
                    break;
            }
            _Para.Direction = System.Data.ParameterDirection.ReturnValue;
            _Dal.Command.Parameters.Add( _Para );
            _Para = null;
        }

        /// <summary>
        /// Oracle添加统一输入的模块化参数Module值
        /// </summary>
        /// <param name="moduleValue">Module值</param>
        public void AddOrcNewModuleParameter( string moduleValue )
        {
            OracleParameter _Para = new OracleParameter();
            _Para.ParameterName = "i_module";
            //_Para.OracleDbType = OracleDbType.Varchar2;
            _Para.OracleDbTypeEx = OracleDbType.Varchar2;
            _Para.Value = moduleValue;
            _Para.Direction = System.Data.ParameterDirection.Input;
            _Dal.Command.Parameters.Add( _Para );
            _Para = null;
        }
        #endregion

        /// <summary>
        /// 测试时，输出参数信息至日志里
        /// </summary>
        public void WriteParaStr()
        {
            System.Text.StringBuilder _SB = new System.Text.StringBuilder();
            for ( int i = 0; i < _Dal.Command.Parameters.Count; i++ )
            {
                _SB.AppendFormat( "{0}:{1}\r\n", _Dal.Command.Parameters[i].ParameterName, _Dal.Command.Parameters[i].Value );
            }
            UtilityFile.AddLogErrMsg( _SB.ToString() );
            _SB.Length = 0;
            _SB = null;
        }
    }
}
