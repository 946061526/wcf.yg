using System;
using System.Threading;
using Couchbase;
using Couchbase.Extensions;
using Enyim.Caching.Memcached;
using Enyim.Caching.Memcached.Results;

namespace wcfNSYGShop
{
    /// <summary>
    /// 操作一级缓存的类，建议使用using实例化
    /// </summary>
    public class CouchBaseClient : IDisposable
    {
        /* 创建对象实例 */
        private CouchbaseClient Client = null;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public CouchBaseClient()
        {
            /* 初始为配置文件中的默认bucket缓存 */
            Client = CouchBaseFactory.GetClient;
        }
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public CouchBaseClient( string bucketName, string password )
        {
            /* 初始为配置文件中的默认bucket缓存 */
            Client = CouchBaseFactory.CreateClient( bucketName, password );
        }
        /// <summary>
        /// 更新缓存时的更新标识
        /// </summary>
        private string updateSuffix = "_update";

        /// <summary>
        /// 重置缓存对象
        /// 不存在则创建，存在则替换
        /// 长期有效
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public bool SetObject( string key, object value )
        {
            try
            {
                if ( string.IsNullOrEmpty( key ) || value == null )
                {
                    return false;
                }
                else
                {
                    return Client.Store( StoreMode.Set, key, value );
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 重置缓存对象
        /// 不存在则创建，存在则替换
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="time">缓存时间：毫秒</param>
        /// <returns></returns>
        public bool SetObject( string key, object value, double time )
        {
            try
            {
                if ( string.IsNullOrEmpty( key ) || value == null || time <= 0d )
                {
                    return false;
                }
                else
                {
                    return Client.Store( StoreMode.Set, key, value, DateTime.Now.AddMilliseconds( time ) );
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 重置缓存对象，适用Json对象
        /// 不存在则创建，存在则替换
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="time">缓存时间：毫秒</param>
        /// <returns></returns>
        public bool SetJsonObject( string key, object value, double time )
        {
            try
            {
                if ( string.IsNullOrEmpty( key ) || value == null || time <= 0d )
                {
                    return false;
                }
                else
                {
                    return Client.StoreJson( StoreMode.Set, key, value, DateTime.Now.AddMilliseconds( time ) );
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 重置缓存对象,长期有效，适用Json对象
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public bool SetJsonObject( string key, object value )
        {
            try
            {
                if ( string.IsNullOrEmpty( key ) || value == null )
                {
                    return false;
                }
                else
                {
                    return Client.StoreJson( StoreMode.Set, key, value );
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 对缓存内容值自增，限ulong类型
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">不存在时默认值</param>
        /// <param name="step">自增幅度</param>
        /// <param name="time">缓存时间：毫秒</param>
        /// <returns></returns>
        public ulong Increment( string key, ulong defaultValue, ulong step, double time )
        {
            try
            {
                if ( string.IsNullOrEmpty( key ) || step == 0 || time <= 0d )
                {
                    return 0;
                }
                else
                {
                    return Client.Increment( key, defaultValue, step, DateTime.Now.AddMilliseconds( time ) );
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 添加缓存对象
        /// 存在则会添加失败
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public bool AddObject( string key, object value )
        {
            try
            {
                if ( string.IsNullOrEmpty( key ) || value == null )
                {
                    return false;
                }
                else
                {
                    return Client.Store( StoreMode.Add, key, value );
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 添加缓存对象
        /// 存在则会添加失败
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="time">缓存时间：毫秒</param>
        /// <returns></returns>
        public bool AddObject( string key, object value, double time )
        {
            try
            {
                if ( string.IsNullOrEmpty( key ) || value == null || time <= 0d )
                {
                    return false;
                }
                else
                {
                    return Client.Store( StoreMode.Add, key, value, DateTime.Now.AddMilliseconds( time ) );
                    //bool _Flag = Client.Store( StoreMode.Add, key, value, DateTime.Now.AddMilliseconds( time ) );//
                    //Console.WriteLine( "AddObject: " + _Flag + "; time:" + time );
                    //Console.WriteLine( "IsExsits: " + this.IsExsits( key ) );
                    //Console.WriteLine( "GetObject: " + this.GetObject<int>( key ) );
                    //return _Flag;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 移除缓存对象
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public bool RemoveObject( string key )
        {
            try
            {
                if ( string.IsNullOrEmpty( key ) )
                {
                    return false;
                }
                else
                {
                    return Client.ExecuteRemove( key ).Success;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断缓存对象是否已存在
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public bool IsExsits( string key )
        {
            try
            {
                return Client.KeyExists( key );
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断缓存对象是否已存在并设定过期时间
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public bool IsExsits( string key, double newTimeout )
        {
            try
            {
                var _Result = Client.ExecuteGet( key, DateTime.Now.AddMilliseconds( newTimeout ) );
                return _Result.Success && _Result.HasValue;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取缓存对象
        /// 取值成功则返回True
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="tmp">用来存值的变量</param>
        /// <returns></returns>
        public bool GetObject( string key, out object tmp )
        {
            tmp = null;
            try
            {
                if ( string.IsNullOrEmpty( key ) )
                {
                    return false;
                }
                else
                {
                    return Client.TryGet( key, out tmp );
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取缓存对象
        /// 获值失败则返回default(T)
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public T GetObject<T>( string key )
        {
            try
            {
                object _Value;
                if ( GetObject( key, out _Value ) )
                {
                    return (T)_Value;
                }
            }
            catch
            {
            }
            return default( T );
        }

        /// <summary>
        /// 获取缓存对象
        /// 获值失败则返回default(T)
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public bool GetJson<T>( string key, out T model ) where T : class
        {
            model = null;
            try
            {
                IGetOperationResult<T> _Result = Client.ExecuteGetJson<T>( key );
                if ( _Result.Success )
                {
                    model = _Result.Value;
                    return true;
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

        /// <summary>
        /// 获取数据库的数据源的委托
        /// </summary>
        /// <typeparam name="T">返回泛型数据</typeparam>
        /// <param name="paraList">参数集合</param>
        /// <returns></returns>
        public delegate T GetDataSourceDelegate<T>( params object[] paraList );

        /// <summary>
        /// 从缓存中获取数据
        /// </summary>
        /// <typeparam name="T">返回泛型数据</typeparam>
        /// <param name="model">更新缓存的配置实体</param>
        /// <param name="dtm">数据源调用方法</param>
        /// <param name="paraList">数据源所需参数</param>
        /// <returns></returns>
        public T GetCouchData<T>( MDLUpdateCouch model, GetDataSourceDelegate<T> dtm, params object[] paraList )
        {
            object _value;
            #region 获取数据缓存
            if ( !this.GetObject( model.Key, out _value ) )
            {
                #region 缓存失效
                /* 缓存已过期,则创建读取数据库标志，
                 * 在未读取到数据并更新到缓存或取数据未超时之前
                 * 其他线程或进程禁止访问数据库和缓存 */

                int _UserTime = 0;//等待所耗时间
                bool _GetDBSourceOK = false;//在等待的周期内是否成功获得源数据

                try
                {
                    /* 根据缓存键创建的原子性来解决并发 */
                    do
                    {
                        if ( _UserTime > model.WaitTime )
                        {
                            /* 等待时间已经超过更新缓存所需时间，则不再等待 */
                            break;
                        }
                        else if ( this.IsExsits( model.Key + updateSuffix ) )
                        {
                            /* 有其它线程读取数据库了 */
                            //Console.Write( "线程{0}：进入等待", paraList[3] );
                            Thread.Sleep( model.CheckTime );
                            _UserTime += model.CheckTime;
                        }
                        else
                        {
                            /* 当有等待最少一次后再判断缓存是否有效 */
                            if ( _UserTime > 0 )
                            {
                                if ( this.GetObject( model.Key, out _value ) )
                                {
                                    _GetDBSourceOK = true;
                                    break;
                                }
                            }
                            #region 读取数据库并更新缓存
                            int _SignVal = Guid.NewGuid().GetHashCode();
                            bool _SetSign = this.AddObject( model.Key + updateSuffix, _SignVal, model.WaitTime );
                            if ( _SetSign )
                            {
                                /* 从数据库中读取数据 */
                                _value = dtm( paraList );
                                _GetDBSourceOK = true;

                                /* 已经获得数据，更新到缓存
                                 * 检查是否标识一致，不一致则可能获取数据超时，其他线程已去获取数据了 */
                                if ( _SignVal == this.GetObject<int>( model.Key + updateSuffix ) )
                                {
                                    if ( model.TimeOut <= 0.0 )
                                    {
                                        /* 永久保存 */
                                        this.SetObject( model.Key, _value );
                                    }
                                    else
                                    {
                                        this.SetObject( model.Key, _value, model.TimeOut );
                                    }

                                    /* 移除更新标识 */
                                    this.RemoveObject( model.Key + updateSuffix );
                                }

                                /* 不管更新与否都退出循环 */
                                break;
                            }
                            else
                            {
                                /* 已被别的线程创建成功了
                                 * 则循环等待更新缓存后取缓存数据 */
                                Thread.Sleep( model.CheckTime );
                                _UserTime += model.CheckTime;
                            }
                            #endregion
                        }
                    } while ( true );
                }
                catch
                {
                    _value = default( T );
                }

                /* 判断是否已经获取数据源，没有则重新从数据库中获取数据源，以保证业务正常运行 */
                if ( !_GetDBSourceOK )
                {
                    _value = dtm( paraList );
                }
                #endregion
            }
            #endregion
            return (T)_value;
        }

        /// <summary>
        /// 从缓存中获取数据，适用于Json对象数据
        /// </summary>
        /// <typeparam name="T">返回泛型数据</typeparam>
        /// <param name="model">更新缓存的配置实体</param>
        /// <param name="jsonData">获取的Json内容</param>
        /// <param name="dtm">数据源调用方法</param>
        /// <param name="paraList">数据源所需参数</param>
        /// <returns></returns>
        public bool GetCouchJsonData<T>( MDLUpdateCouch model, out T jsonData, GetDataSourceDelegate<T> dtm, params object[] paraList ) where T : class
        {
            jsonData = null;

            #region 获取数据缓存
            if ( !this.GetJson<T>( model.Key, out jsonData ) )
            {
                #region 缓存失效
                /* 缓存已过期,则创建读取数据库标志，
                 * 在未读取到数据并更新到缓存或取数据未超时之前
                 * 其他线程或进程禁止访问数据库和缓存 */

                int _UserTime = 0;//等待所耗时间
                bool _GetDBSourceOK = false;//在等待的周期内是否成功获得源数据

                try
                {
                    /* 根据缓存键创建的原子性来解决并发 */
                    do
                    {
                        if ( _UserTime > model.WaitTime )
                        {
                            /* 等待时间已经超过更新缓存所需时间，则不再等待 */
                            break;
                        }
                        else if ( this.IsExsits( model.Key + updateSuffix ) )
                        {
                            /* 有其它线程读取数据库了 */
                            //Console.Write( "线程{0}：进入等待", paraList[3] );
                            Thread.Sleep( model.CheckTime );
                            _UserTime += model.CheckTime;
                        }
                        else
                        {
                            /* 当有等待最少一次后再判断缓存是否有效 */
                            if ( _UserTime > 0 )
                            {
                                if ( this.GetJson<T>( model.Key, out jsonData ) )
                                {
                                    _GetDBSourceOK = true;
                                    break;
                                }
                            }
                            #region 读取数据库并更新缓存
                            int _SignVal = Guid.NewGuid().GetHashCode();
                            bool _SetSign = this.AddObject( model.Key + updateSuffix, _SignVal, model.WaitTime );
                            if ( _SetSign )
                            {
                                /* 从数据库中读取数据 */
                                jsonData = dtm( paraList );
                                _GetDBSourceOK = true;

                                /* 已经获得数据，更新到缓存
                                 * 检查是否标识一致，不一致则可能获取数据超时，其他线程已去获取数据了 */
                                if ( _SignVal == this.GetObject<int>( model.Key + updateSuffix ) )
                                {
                                    if ( model.TimeOut <= 0.0 )
                                    {
                                        /* 永久保存 */
                                        this.SetJsonObject( model.Key, jsonData );
                                    }
                                    else
                                    {
                                        this.SetJsonObject( model.Key, jsonData, model.TimeOut );
                                    }

                                    /* 移除更新标识 */
                                    this.RemoveObject( model.Key + updateSuffix );
                                }

                                /* 不管更新与否都退出循环 */
                                break;
                            }
                            else
                            {
                                /* 已被别的线程创建成功了或缓存操作异常
                                 * 则循环等待更新缓存后取缓存数据 */
                                Thread.Sleep( model.CheckTime );
                                _UserTime += model.CheckTime;
                            }
                            #endregion
                        }
                    } while ( true );
                }
                catch
                {
                    jsonData = null;
                }

                /* 判断是否已经获取数据源，没有则重新从数据库中获取数据源，以保证业务正常运行 */
                if ( !_GetDBSourceOK )
                {
                    jsonData = dtm( paraList );
                }
                #endregion
            }
            #endregion
            return jsonData != null;
        }

        public void Dispose()
        {
            Client = null;
        }
    }
}