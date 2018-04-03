using System;
using System.IO;
using System.Net;
using System.Text;

namespace wcfNSYGShop
{
    public class UtilityFile
    {
        /// <summary>
        /// 日志站点接收post日志的地址
        /// </summary>
        private static string LogSiteUrl = "http://log.1yyg.com/ashx/LogRecord.ashx";

        #region 记录操作缓存错误日志
        /// <summary>
        /// 记录操作缓存错误日志
        /// /log/cached/目录下
        /// </summary>
        /// <param name="msg">描述信息，即保存到日志文件里的信息</param>
        public static bool AddLogMsg( string msg )
        {
            return AddLogErrMsg( "log/cached/", msg );
        }

        /// <summary>
        /// 记录错误日志，/log目录下
        /// </summary>
        /// <param name="msg">描述信息，即保存到日志文件里的信息</param>
        public static bool AddLogErrMsg( string msg )
        {
            return AddLogErrMsg( "log/", msg );
        }

        /// <summary>
        /// 记录错误跟踪日志，/log/{path}/yyyyMMddHH.txt
        /// </summary>
        /// <param name="path">{path}路径</param>
        /// <param name="msg">错误描述信息，即保存到日志文件里的信息</param>
        public static bool AddLogErrMsg( string path, string msg )
        {
            try
            {
                DateTime _NowTime = DateTime.Now;
                string _Path = UtilityFun.GetConfigStr( "errLogPath" ) + path + _NowTime.ToString( "/yyyy/MM" );
                //判断是否建立了log文件夹
                if ( ExistsPath( _Path, true ) )
                {
                    //记录到日志文件
                    string _FilePath = _Path + _NowTime.ToString( "/ddHH" ) + ".txt";
                    StringBuilder _Contents = new StringBuilder();
                    _Contents.Append( _NowTime.ToString() );//访问的时间
                    _Contents.Append( "\t" );
                    _Contents.Append( msg );          //填写正文
                    _Contents.Append( "\r\n\r\n" );
                    return WriteMsg( _FilePath, _Contents.ToString(), true );
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region 检查目录是否存在

        /// <summary>
        /// 检查目录是否存在
        /// </summary>
        /// <param name="phyPath">目录绝对物理地址</param>
        /// <param name="isCreate">不存在是否创建目录</param>
        /// <returns></returns>
        public static bool ExistsPath( string phyPath, bool isCreate )
        {
            if ( Directory.Exists( phyPath ) )
            {
                return true;
            }
            else if ( isCreate )
            {
                try
                {
                    Directory.CreateDirectory( phyPath );
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 保存文件内容到指定的文件

        /// <summary>
        /// 保存文件内容到指定的文件
        /// </summary>
        /// <param name="fileUrl">文件完整的物理路径包括文件名</param>
        /// <param name="msg">内容</param>
        /// <param name="isAppend">是否追加内容(false:覆盖)</param>
        public static bool WriteMsg( string fileUrl, string msg, bool isAppend )
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter( fileUrl, isAppend, System.Text.Encoding.Unicode );
                sw.Write( msg );
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if ( sw != null )
                {
                    sw.Close();
                    sw.Dispose();
                }
            }
        }

        #endregion

        #region 写服务程序是否设置为启动
        /// <summary>
        /// 写服务程序是否设置为启动
        /// 0不可用，1可用。
        /// </summary>
        /// <param name="swtichNO"></param>
        /// <returns></returns>
        public static bool WriteSystemSwitchFile( int swtichNO )
        {
            bool _Flag = false;
            StreamWriter _Writer = null;
            try
            {
                string _FileName = Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().Location ) + "\\sysConfig.txt";

                //AddLogErrMsg( _FileName );
                _Writer = new StreamWriter( _FileName, false, System.Text.Encoding.Unicode );
                _Writer.Write( swtichNO );
                _Flag = true;
            }
            catch
            {
                _Flag = false;
            }
            finally
            {
                if ( _Writer != null )
                {
                    _Writer.Close();
                    _Writer.Dispose();
                }
            }
            return _Flag;
        }
        #endregion

        #region 读服务程序是否启动的设置值
        /// <summary>
        /// 读服务程序是否启动的设置值
        /// </summary>
        /// <returns></returns>
        public static int ReadSystemSwitchFile()
        {
            int _RetVal = 1;
            try
            {
                string _FileName = Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().Location ) + "\\sysConfig.txt";
                //string _FileName = System.Environment.CurrentDirectory + "/sysConfig.txt";
                if ( File.Exists( _FileName ) )
                {
                    StreamReader _Reader = new StreamReader( _FileName, Encoding.Default );
                    string _Str = _Reader.ReadLine();
                    _RetVal = UtilityFun.ToInt32( _Str );
                    _Reader.Close();
                    _Reader = null;
                }
            }
            catch
            {
            }
            return _RetVal;
        }
        #endregion
        #region 读服务程序是否启用临控日志的设置值
        /// <summary>
        /// 读服务程序是否启用临控日志的设置值
        /// 1为启用，0为不启用
        /// </summary>
        /// <returns></returns>
        public static int ReadMonitorSwitchFile()
        {
            int _RetVal = 0;
            try
            {
                string _FileName = Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().Location ) + "\\monitorConfig.txt";
                if ( File.Exists( _FileName ) )
                {
                    StreamReader _Reader = new StreamReader( _FileName, Encoding.Default );
                    string _Str = _Reader.ReadLine();
                    _RetVal = UtilityFun.ToInt32( _Str );
                    _Reader.Close();
                    _Reader = null;
                }
                else
                {
                    StreamWriter _Writer = new StreamWriter( _FileName, false, System.Text.Encoding.Unicode );
                    _Writer.Write( 0 );
                    _Writer.Close();
                    _Writer.Dispose();
                }
            }
            catch
            {
                _RetVal = 0;
            }
            return _RetVal;
        }
        #endregion
        #region 是否清除相应节点的数据库连接池
        /// <summary>
        /// 是否清除相应节点的数据库连接池
        /// 0为不清除，-1为清除全部连接池，大于0则为清除对应的连接池
        /// </summary>
        /// <returns></returns>
        public static int ReadClearPollFile()
        {
            int _RetVal = 0;
            try
            {
                string _FileName = Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().Location ) + "\\poolConfig.txt";
                if ( File.Exists( _FileName ) )
                {
                    StreamReader _Reader = new StreamReader( _FileName, Encoding.Default );
                    string _Str = _Reader.ReadLine();
                    _RetVal = UtilityFun.ToInt32( _Str );
                    _Reader.Close();
                    _Reader = null;

                    if ( _RetVal != 0 )
                    {
                        StreamWriter _Writer = new StreamWriter( _FileName, false, System.Text.Encoding.Unicode );
                        _Writer.Write( 0 );
                        _Writer.Close();
                        _Writer.Dispose();
                    }
                }
                else
                {
                    StreamWriter _Writer = new StreamWriter( _FileName, false, System.Text.Encoding.Unicode );
                    _Writer.Write( 0 );
                    _Writer.Close();
                    _Writer.Dispose();
                }
            }
            catch
            {
                _RetVal = 0;
            }
            return _RetVal;
        }
        #endregion

        #region 是否清除相应节点的数据库连接池
        /// <summary>
        /// 是否清除相应节点的数据库连接池
        /// 0为不清除，-1为清除全部连接池，大于0则为清除对应的连接池
        /// </summary>
        /// <returns></returns>
        public static void WriteClearPollFile( int clearDBNode )
        {
            try
            {
                string _FileName = Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().Location ) + "\\poolConfig.txt";
                using ( StreamWriter _Writer = new StreamWriter( _FileName, false, System.Text.Encoding.Unicode ) )
                {
                    _Writer.Write( clearDBNode );
                    _Writer.Close();
                    _Writer.Dispose();
                }
            }
            catch
            {
            }
        }
        #endregion

        #region 创建日志xml内容
        /// <summary>
        /// 创建日志xml内容
        /// </summary>
        /// <param name="model">日志信息</param>
        /// <returns></returns>
        private static string CreateLogXml( string logTime, string moduleID, string plat, int executeNum )
        {
            string _Xml = "";
            try
            {
                StringBuilder _Builder = new StringBuilder();
                _Builder.Append( "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" );
                _Builder.Append( "<root>" );
                _Builder.AppendFormat( "<LogContent><![CDATA[{0}]]></LogContent>", logTime );//logTime
                _Builder.AppendFormat( "<OtherInfo><![CDATA[{0}]]></OtherInfo>", moduleID );//moduleID
                _Builder.AppendFormat( "<WebDomain><![CDATA[{0}]]></WebDomain>", plat );//plat
                _Builder.AppendFormat( "<PageURL><![CDATA[{0}]]></PageURL>", "1" );//wcfType
                _Builder.AppendFormat( "<LogGrade><![CDATA[{0}]]></LogGrade>", executeNum );//executeNum
                _Builder.AppendFormat( "<LogType><![CDATA[{0}]]></LogType>", "wcf_monitor_num" );//
                _Builder.Append( "</root>" );
                _Xml = _Builder.ToString();
                _Builder.Length = 0;
                _Builder = null;
            }
            catch
            {
                _Xml = "";
            }
            return _Xml;
        }
        #endregion

        #region http发送post请求，往日志系统站点写入xml日志内容
        /// <summary>
        /// http发送post请求，往日志系统站点写入xml日志内容
        /// </summary>
        /// <param name="url">日志系统站点接收地址</param>
        /// <param name="postXml">post的xml内容</param>
        /// <returns></returns>
        public static bool HttpPostXml( DateTime logTime, string moduleID, string plat, int executeNum )
        {
            bool _Result = false;

            StreamWriter _Writer = null;
            HttpWebRequest _Request = null;
            HttpWebResponse _Response = null;
            string _PostXml = "";

            try
            {
                _PostXml = CreateLogXml( logTime.ToString( "yyyy-MM-dd HH:mm:ss" ), moduleID, plat, executeNum );

                _Request = (HttpWebRequest)WebRequest.Create( LogSiteUrl );
                _Request.Method = "POST";
                _Request.ContentType = "text/xml";//提交xml
                _Request.Timeout = 3000;//设置3秒超时时间
                _Request.Referer = "wcf.1yyg.com";
                _Request.KeepAlive = false;

                _Writer = new StreamWriter( _Request.GetRequestStream(), System.Text.Encoding.UTF8 );
                _Writer.Write( _PostXml );
                _Writer.Close();

                _Response = (HttpWebResponse)_Request.GetResponse();
                _Result = _Response.StatusCode == HttpStatusCode.OK;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( string.Format( "Exception:{0}\r\nPostXml:{1}", ex.ToString(), _PostXml ) );
                return false;
            }
            finally
            {
                _Writer = null;
                if ( _Request != null )
                {
                    _Request.Abort();
                    _Request = null;
                }
                if ( _Response != null )
                {
                    _Response.Close();
                    _Response = null;
                }
            }

            return _Result;
        }
        #endregion
    }
}
