using System;
using System.Configuration;

namespace wcfNSYGShop
{
    public class UtilityFun
    {
        /// <summary>
        /// 定义系统中使用最小的日期值，以便兼容数据库或其它系统的最小日期范围
        /// </summary>
        public static DateTime MinDTValue = DateTime.Parse( "1753-01-01 12:00:00" );

        #region 获取配置文件中的AppSettings健值

        /// <summary>
        /// 获取配置文件中的AppSettings健值
        /// </summary>
        /// <param name="key">配置值的项名</param>
        /// <returns></returns>
        public static string GetConfigStr( string key )
        {
            return ConfigurationManager.AppSettings[key];
        }

        #endregion

        #region GetIntIP() 返回客户端的IP地址

        /// <summary>
        /// 返回客户端的IP地址
        /// </summary>
        /// <param name="ip">IP地址（格式：255.255.255.255）</param>
        /// <returns></returns>
        public static long GetIntIP( string ip )
        {
            long _Result = 0L;
            try
            {
                if ( !IsEmptyString( ip ) && !ip.Equals( "0.0.0.0" ) )
                {
                    string[] _Arr = ip.Split( '.' );
                    if ( _Arr.Length == 4 )
                    {
                        _Result = ToInt32( _Arr[0] ) * 256 * 256 * 256L + ToInt32( _Arr[1] ) * 256 * 256L + ToInt32( _Arr[2] ) * 256 + ToInt32( _Arr[3] );
                    }
                    _Arr = null;
                }
            }
            catch
            {
                _Result = 0L;
            }
            return _Result;
        }

        #endregion


        #region IsEmptyString(string str) 检查字符串是否为空

        /// <summary>
        /// 检查字符串是否为空
        /// </summary>
        /// <param name="str">要检查的字符串</param>
        /// <returns>为空返回true;否则返回false;</returns>
        public static bool IsEmptyString( string str )
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

        #region ToDecimal(string refVal) 把字符串转换成Decimal

        /// <summary>
        /// 把字符串转换成Decimal,非Decimal字符串返回0
        /// </summary>
        /// <param name="refVal">要转换的字符串</param>
        /// <returns></returns>
        public static decimal ToDecimal( string refVal )
        {
            return ToNumber( refVal, 0m );
        }

        #endregion

        #region ToInt32(object refVal) 把对象转换成整型

        /// <summary>
        /// 把对象转换成整型,非整型字符串返回0
        /// </summary>
        /// <param name="refVal">要转换的对象</param>
        /// <returns></returns>
        public static int ToInt32( object refVal )
        {
            if ( refVal == null )
            {
                return 0;
            }
            else
            {
                return ToNumber( refVal.ToString(), 0 );
            }
        }

        #endregion

        #region ToInt32(string refVal) 把字符串转换成整型

        /// <summary>
        /// 把字符串转换成整型,非整型字符串返回0
        /// </summary>
        /// <param name="refVal">要转换的字符串</param>
        /// <returns></returns>
        public static int ToInt32( string refVal )
        {
            return ToNumber( refVal, 0 );
        }

        #endregion

        #region ToInt64(object refVal) 把对象转换成整型

        /// <summary>
        /// 把对象转换成整型,非整型字符串返回0
        /// </summary>
        /// <param name="refVal">要转换的对象</param>
        /// <returns></returns>
        public static long ToInt64( object refVal )
        {
            if ( refVal == null )
            {
                return 0L;
            }
            else
            {
                return ToNumber( refVal.ToString(), 0L );
            }
        }

        #endregion

        #region ToInt64(string refVal) 把字符串转换成整型

        /// <summary>
        /// 把字符串转换成整型,非整型字符串返回0
        /// </summary>
        /// <param name="refVal">要转换的字符串</param>
        /// <returns></returns>
        public static long ToInt64( string refVal )
        {
            return ToNumber( refVal, 0L );
        }

        #endregion

        #region ToNumber(string refVal, int defaultVal) 把字符串转换成整型

        /// <summary>
        /// 把字符串转换成整型
        /// </summary>
        /// <param name="refVal">要转换的字符串</param>
        /// <param name="defaultVal">转换失败的缺省值</param>
        /// <returns>转换后的整型</returns>
        public static int ToNumber( string refVal, int defaultVal )
        {
            int _Result = defaultVal;
            bool _Flag = int.TryParse( refVal, out _Result );
            if ( !_Flag )
            {
                _Result = defaultVal;
            }
            return _Result;
        }

        #endregion

        #region ToNumber(string refVal, long defaultVal) 把字符串转换成整型

        /// <summary>
        /// 把字符串转换成整型
        /// </summary>
        /// <param name="refVal">要转换的字符串</param>
        /// <param name="defaultVal">转换失败的缺省值</param>
        /// <returns>转换后的整型</returns>
        public static long ToNumber( string refVal, long defaultVal )
        {
            long _Result = defaultVal;
            bool _Flag = long.TryParse( refVal, out _Result );
            if ( !_Flag )
            {
                _Result = defaultVal;
            }
            return _Result;
        }

        #endregion

        #region ToNumber(string refVal, decimal defaultVal) 把字符串转换成Decimal类型

        /// <summary>
        /// 把字符串转换成Decimal类型，失败以defaultVal填充
        /// </summary>
        /// <param name="refVal">要转换的字符串</param>
        /// <param name="defaultVal">转换失败的缺省值</param>
        /// <returns></returns>
        public static decimal ToNumber( string refVal, decimal defaultVal )
        {
            decimal _Result = defaultVal;
            bool _Flag = decimal.TryParse( refVal, out _Result );
            if ( !_Flag )
            {
                _Result = defaultVal;
            }
            return _Result;
        }

        #endregion


        #region ToDateTime(string vDateTime) 把字符串转换成日期类型

        /// <summary>
        /// 把字符串转换成日期类型,出错返回最小日期
        /// </summary>
        /// <param name="vDateTime">日期字符串</param>
        /// <returns>转换后的日期</returns>
        public static DateTime ToDateTime( string vDateTime )
        {
            DateTime minVal;
            if ( DateTime.TryParse( vDateTime, out minVal ) )
            {
                return minVal;
            }
            else
            {
                return MinDTValue;
            }
        }

        #endregion

        #region ToDateTime(object vDateTime) 把字符串转换成日期类型

        /// <summary>
        /// 把字符串转换成日期类型,出错返回最小日期
        /// </summary>
        /// <param name="vDateTime">日期对象</param>
        /// <returns>转换后的日期</returns>
        public static DateTime ToDateTime( object vDateTime )
        {
            if ( vDateTime != null )
            {
                return ToDateTime( vDateTime.ToString() );
            }
            else
            {
                return MinDTValue;
            }
        }

        #endregion
    }
}
