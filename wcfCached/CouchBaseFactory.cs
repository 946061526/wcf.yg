using System;
using Couchbase;

namespace wcfNSYGShop
{
    public static class CouchBaseFactory
    {
        /// <summary>
        /// 缓存操作对象
        /// </summary>
        private static CouchbaseClient _CouchbaseClient;

        /// <summary>
        /// 静态初始化，可以进行默认设置
        /// </summary>
        static CouchBaseFactory()
        {
            try
            {
                //初始缓存服务器
                _CouchbaseClient = new CouchbaseClient();
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogMsg( "初始默认缓存服务器时:" + ex.Message );
            }
        }

        #region CouchbaseClient
        /// <summary>
        /// 获取CouchbaseClient实例对象
        /// </summary>
        /// <returns></returns>
        public static CouchbaseClient GetClient
        {
            get
            {
                if ( _CouchbaseClient == null )
                {
                    try
                    {
                        _CouchbaseClient = new CouchbaseClient();

                    }
                    catch ( Exception ex )
                    {
                        UtilityFile.AddLogMsg( "初始默认缓存服务器时:" + ex.Message );
                    }
                }
                return _CouchbaseClient;
            }
        }

        /// <summary>
        /// 创建新的CouchbaseClient实例对象
        /// </summary>
        /// <returns></returns>
        public static CouchbaseClient CreateClient( string bucketName, string password )
        {
            CouchbaseClient _Client = null;
            try
            {
                _Client = new CouchbaseClient( bucketName, password );

            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogMsg( "在创建指定的bucket缓存服务器时:" + ex.Message );
            }
            return _Client;
        }

        #endregion

    }
}