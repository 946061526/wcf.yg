using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace wcfNSYGShop
{
    public class CachedStrategy : CouchBaseStrategy, ICachedStrategy
    {
        /// <summary>
        /// 定义缓存ID对应的标识字符,存在则表正在更新
        /// </summary>
        private object _LockHelper = new object();
        private object _LockHelper1 = new object();
        private object _LockHelper2 = new object();
        protected static volatile Cache webCache = HttpRuntime.Cache;

        /// <summary>
        /// 默认缓存存活期为3600秒(1小时)
        /// </summary>
        protected int _timeOut = 3600;

        /// <summary>
        /// 构造函数
        /// </summary>
        public CachedStrategy()
            : base()
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public CachedStrategy( string bucketName, string password )
            : base( bucketName, password )
        {

        }

        /// <summary>
        /// 设置到期相对时间[单位: 秒] 
        /// </summary>
        public int TimeOut
        {
            set
            {
                _timeOut = value > 0 ? value : 3600;
            }
            get
            {
                return _timeOut > 0 ? _timeOut : 3600;
            }
        }

        public static Cache GetWebCacheObj
        {
            get
            {
                return webCache;
            }
        }

        /// <summary>
        /// 添加当前对象到couch及本地缓存中
        /// </summary>
        /// <param name="objId">对象的键值</param>
        /// <param name="o">缓存的对象</param>
        /// <param name="couchTimeout">过期时间秒</param>
        public bool SetObject( string objId, object o, int couchTimeout )
        {
            if ( string.IsNullOrEmpty( objId ) || o == null )
            {
                return false;
            }
            bool _Result = false;
            try
            {
                _Result = base.SetObject( objId, o, 1000.0 * couchTimeout );
                if ( _Result )
                {
                    _Result = AddLocalObject( objId, o );
                }
            }
            catch ( Exception ex )
            {
                _Result = false;
                UtilityFile.AddLogMsg( "添加缓存(" + objId + ")到Couch及本地cache时:" + ex.Message );
            }
            return _Result;
        }

        /// <summary>
        /// 添加当前对象到本地缓存中
        /// </summary>
        /// <param name="objId">对象的键值</param>
        /// <param name="o">缓存的对象</param>
        public bool AddLocalObject( string objId, object o )
        {
            if ( string.IsNullOrEmpty( objId ) || o == null )
            {
                return false;
            }
            bool _Result = false;
            try
            {
                RemoveLocalObject( objId );
                webCache.Insert( objId, o, null, DateTime.Now.AddSeconds( _timeOut ), Cache.NoSlidingExpiration, CacheItemPriority.High, null );
                _Result = true;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogMsg( "添加数据(" + objId + ")到本地cache时:" + ex.Message );
                _Result = false;
            }
            return _Result;
        }

        /// <summary>
        /// 删除缓存对象
        /// </summary>
        /// <param name="objId">对象的关键字</param>
        public override bool RemoveObject( string objId )
        {
            if ( objId == null || objId.Length == 0 )
            {
                return true;
            }
            try
            {
                webCache.Remove( objId );
                base.RemoveObject( objId );
                return true;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogMsg( "删除本地及couchbase数据(" + objId + ")时:" + ex.Message );
                return false;
            }
        }

        /// <summary>
        /// 删除本地缓存对象
        /// </summary>
        /// <param name="objId">对象的关键字</param>
        public bool RemoveLocalObject( string objId )
        {
            if ( objId == null || objId.Length == 0 )
            {
                return true;
            }
            try
            {
                webCache.Remove( objId );
                return true;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogMsg( "删除本地cache数据(" + objId + ")时:" + ex.Message );
                return false;
            }
        }

        /// <summary>
        /// 返回指定的缓存内容
        /// 当本地缓存失效则会从couch取值更新本址缓存填充，但会返回false
        /// </summary>
        /// <param name="objId">缓存键名</param>
        /// <param name="isFalseUpTimeout">当本地失效时是否更新couch的过期时间（当couch有效时）</param>
        /// <param name="timeout">新的过期时间（秒）</param>
        /// <param name="tmp">缓存的内容</param>
        /// <returns>对象</returns>
        public bool GetObject( string objId, bool isFalseUpTimeout, int timeout, out object tmp )
        {
            bool _Result = false;
            tmp = null;
            if ( string.IsNullOrEmpty( objId ) )
            {
                return false;
            }
            try
            {
                tmp = webCache.Get( objId );
                if ( tmp == null )
                {
                    lock ( _LockHelper1 )
                    {
                        if ( tmp == null )
                        {
                            //本地Cache失效,到Couchbase获取数据
                            bool _GetCouch = isFalseUpTimeout ? base.GetObject( objId, 1000.0 * timeout, out tmp ) : base.GetObject( objId, out tmp );
                            if ( _GetCouch )
                            {
                                _Result = true;
                                //更新本地缓存
                                AddLocalObject( objId, tmp );
                            }
                        }
                        else
                        {
                            _Result = true;
                        }
                    }
                }
                else
                {
                    _Result = true;
                }
            }
            catch
            {
                _Result = false;
            }
            return _Result;
        }

        /// <summary>
        /// 返回指定的缓存内容
        /// 当本地缓存失效则会从couch取值(有效时)更新本址缓存填充
        /// </summary>
        /// <param name="objId">缓存键名</param>
        /// <returns>对象</returns>
        public override T GetObject<T>( string objId )
        {
            object tmp = null;
            if ( string.IsNullOrEmpty( objId ) )
            {
                return default( T );
            }
            try
            {
                tmp = webCache.Get( objId );
                if ( tmp == null )
                {
                    lock ( _LockHelper2 )
                    {
                        if ( tmp == null )
                        {
                            //本地Cache失效,到Couchbase获取数据
                            bool _GetCouch = base.GetObject( objId, out tmp );
                            if ( _GetCouch )
                            {
                                //更新本地缓存
                                AddLocalObject( objId, tmp );
                            }
                            else
                            {
                                tmp = null;
                            }
                        }
                    }
                }
            }
            catch
            {
                tmp = null;
            }
            return tmp == null ? default( T ) : (T)tmp;
        }


        /// <summary>
        /// 返回一个指定的对象
        /// </summary>
        /// <param name="objId">对象的关键字</param>
        /// <returns>对象</returns>
        public T GetObject<T>( MDLUpdateCouch model, GetDataSourceDelegate<T> dtm, params object[] paraList )
        {
            if ( string.IsNullOrEmpty( model.Key ) )
            {
                return default( T );
            }

            object obj = null;
            try
            {
                obj = webCache.Get( model.Key );
                if ( obj == null )
                {
                    //本地Cache失效,到Couchbase获取数据
                    lock ( _LockHelper )
                    {
                        //再次检查本地
                        obj = webCache.Get( model.Key );
                        if ( obj == null )
                        {
                            //仍然未更新到数据，从上一级获取
                            obj = base.GetCouchData<T>( model, dtm, paraList );
                            if ( obj != null )
                            {
                                //把Couchbase数据保存到Cache
                                AddLocalObject( model.Key, obj );
                            }
                        }
                    }
                }
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogMsg( "获取本地及更新couchbase的Cache数据(" + model.Key + ")时:" + ex.Message );
                obj = null;
            }

            return (T)obj;
        }

        /// <summary>
        /// 返回本地的一个指定的对象
        /// </summary>
        /// <param name="objId">对象的关键字</param>
        /// <returns>对象</returns>
        public T GetLocalObject<T>( string objId )
        {
            object obj = null;
            if ( objId == null || objId.Length == 0 )
            {
                obj = null;
            }
            else
            {
                try
                {
                    obj = webCache.Get( objId );
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogMsg( "获取本地Cache数据(" + objId + ")时:" + ex.Message );
                    obj = null;
                }
            }
            return obj == null ? default( T ) : (T)obj;
        }
    }
}
