
namespace wcfNSYGShop
{
    public interface ICachedStrategy
    {
        /// <summary>
        /// 设置到期相对时间[单位: 秒] 
        /// </summary>
        int TimeOut
        {
            get;
            set;
        }

        /// <summary>
        /// 添加当前对象到couch及本地缓存中
        /// </summary>
        /// <param name="objId">对象的键值</param>
        /// <param name="o">缓存的对象</param>
        /// <param name="couchTimeout">过期时间秒</param>
        bool SetObject( string objId, object o, int couchTimeout );

        /// <summary>
        /// 添加当前对象到本地缓存中
        /// </summary>
        /// <param name="objId">对象的键值</param>
        /// <param name="o">缓存的对象</param>
        bool AddLocalObject( string objId, object o );

        /// <summary>
        /// 删除缓存对象
        /// </summary>
        /// <param name="objId">对象的关键字</param>
        bool RemoveObject( string objId );

        /// <summary>
        /// 删除本地缓存对象
        /// </summary>
        /// <param name="objId">对象的关键字</param>
        bool RemoveLocalObject( string objId );

        /// <summary>
        /// 返回指定的缓存内容
        /// 当本地缓存失效则会从couch取值更新本址缓存填充，但会返回false
        /// </summary>
        /// <param name="objId">缓存键名</param>
        /// <param name="isFalseUpTimeout">当本地失效时是否更新couch的过期时间（当couch有效时）</param>
        /// <param name="timeout">新的过期时间（秒）</param>
        /// <param name="tmp">缓存的内容</param>
        /// <returns>对象</returns>
        bool GetObject( string objId, bool isFalseUpTimeout, int timeout, out object tmp );

        /// <summary>
        /// 返回指定的缓存内容
        /// 当本地缓存失效则会从couch取值(有效时)更新本址缓存填充
        /// </summary>
        /// <param name="objId">缓存键名</param>
        /// <returns>对象</returns>
        T GetObject<T>( string objId );

        /// <summary>
        /// 返回一个指定的对象
        /// </summary>
        /// <param name="objId">对象的关键字</param>
        /// <returns>对象</returns>
        T GetObject<T>( MDLUpdateCouch model, CachedStrategy.GetDataSourceDelegate<T> dtm, params object[] paraList );

        /// <summary>
        /// 返回本地的一个指定的对象
        /// </summary>
        /// <param name="objId">对象的关键字</param>
        /// <returns>对象</returns>
        T GetLocalObject<T>( string objId );
    }
}
