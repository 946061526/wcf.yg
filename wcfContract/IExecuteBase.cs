using System;
using System.Data;
using System.ServiceModel;

namespace wcfNSYGShop
{
    /// <summary>
    /// 服务契约接口定义
    /// </summary>
    [ServiceKnownType( typeof( DBNull ) )]//当传输的对象有DataTable等时
    [ServiceContract( Namespace = "http://wcf.1yyg.com" )]
    public partial interface IWCFContract
    {
        #region 空方法，供客户端检测状态使用
        /// <summary>
        /// 空方法，供客户端检测状态使用
        /// </summary>
        [OperationContract]
        int CheckConnState();
        #endregion

        #region ExecuteForDataSet( out DataSet result, int module, params object[] para )
        /// <summary>
        /// 执行查询过程输出数据集
        /// </summary>
        /// <param name="result">返回数据集</param>
        /// <param name="module">数据库过程编号</param>
        /// <param name="para">参数集</param>
        /// <returns></returns>
        [OperationContract]
        int ExecuteForDataSet( out DataSet result, int module, params object[] para );
        #endregion

        #region ExecuteForDataSet2( out DataSet result, out int count, int module, params object[] para )
        /// <summary>
        /// 执行查询过程输出数据集
        /// </summary>
        /// <param name="result">返回数据集</param>
        /// <param name="count">返回统计数</param>
        /// <param name="module">数据库过程编号</param>
        /// <param name="para">参数集</param>
        /// <returns></returns>
        [OperationContract]
        int ExecuteForDataSet2( out DataSet result, out int count, int module, params object[] para );
        #endregion

        #region ExecuteForDataSet3( out DataSet result, out int count1, out int count2, int module, params object[] para )
        /// <summary>
        /// 执行查询过程输出数据集
        /// </summary>
        /// <param name="result">返回数据集</param>
        /// <param name="count">返回统计数1</param>
        /// <param name="count">返回统计数2</param>
        /// <param name="module">数据库过程编号</param>
        /// <param name="para">参数集</param>
        /// <returns></returns>
        [OperationContract]
        int ExecuteForDataSet3( out DataSet result, out int count1, out int count2, int module, params object[] para );
        #endregion

        #region ExecuteForInt( out int result, int module, params object[] para )
        /// <summary>
        /// 执行查询过程输出整数
        /// </summary>
        /// <param name="result">输出整数</param>
        /// <param name="module">数据库过程编号</param>
        /// <param name="para">参数集</param>
        /// <returns></returns>
        [OperationContract]
        int ExecuteForInt( out int result, int module, params object[] para );
        #endregion

        #region ExecuteForInt2( out int result, out int count, int module, params object[] para )
        /// <summary>
        /// 执行查询过程输出整数
        /// </summary>
        /// <param name="result">输出整数</param>
        /// <param name="count">返回统计数</param>
        /// <param name="module">数据库过程编号</param>
        /// <param name="para">参数集</param>
        /// <returns></returns>
        [OperationContract]
        int ExecuteForInt2( out int result, out int count, int module, params object[] para );
        #endregion

        #region ExecuteForString( out string result, int module, params object[] para )
        /// <summary>
        /// 执行查询过程输出字符串
        /// </summary>
        /// <param name="result">输出字符串</param>
        /// <param name="module">数据库过程编号</param>
        /// <param name="para">参数集</param>
        /// <returns></returns>
        [OperationContract]
        int ExecuteForString( out string result, int module, params object[] para );
        #endregion

        #region ExecuteForDecimal( out decimal result, int module, params object[] para )
        /// <summary>
        /// 执行查询过程输出小数
        /// </summary>
        /// <param name="result">输出小数</param>
        /// <param name="module">数据库过程编号</param>
        /// <param name="para">参数集</param>
        /// <returns></returns>
        [OperationContract]
        int ExecuteForDecimal( out decimal result, int module, params object[] para );
        #endregion

        #region ExecuteForLong( out long result, int module, params object[] para )
        /// <summary>
        /// 执行查询过程输出长整型
        /// </summary>
        /// <param name="result">输出长整型</param>
        /// <param name="module">数据库过程编号</param>
        /// <param name="para">参数集</param>
        /// <returns></returns>
        [OperationContract]
        int ExecuteForLong( out long result, int module, params object[] para );
        #endregion
        /*
        #region ExecuteCachedForDataSet( out DataSet result, int module, params object[] para )
        /// <summary>
        /// 执行查询过程输出数据集
        /// 带缓存操作
        /// </summary>
        /// <param name="result"></param>
        /// <param name="module"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        [OperationContract]
        int ExecuteCachedForDataSet2(out DataSet result, out int count, int module, params object[] para);
        #endregion

        #region ExecuteCachedForAdd( out bool result, params object[] para )
        /// <summary>
        /// 执行添加缓存操作
        /// </summary>
        /// <param name="result">执行结果值</param>
        /// <param name="para">参数集</param>
        /// <returns></returns>
        [OperationContract]
        int ExecuteCachedForAdd(out bool result, params object[] para);
        #endregion

        #region ExecuteCachedForSet( out bool result, params object[] para )
        /// <summary>
        /// 执行设置缓存操作
        /// </summary>
        /// <param name="result">执行结果值</param>
        /// <param name="para">参数集</param>
        /// <returns></returns>
        [OperationContract]
        int ExecuteCachedForSet(out bool result, params object[] para);
        #endregion

        #region ExecuteCachedForSetJson( out bool result, params object[] para )
        /// <summary>
        /// 执行设置缓存操作
        /// </summary>
        /// <param name="result">执行结果值</param>
        /// <param name="para">参数集</param>
        /// <returns></returns>
        [OperationContract]
        int ExecuteCachedForSetJson(out bool result, params object[] para);
        #endregion

        #region ExecuteCachedForGet( out object result, params object[] para )
        /// <summary>
        /// 执行读取缓存操作
        /// </summary>
        /// <param name="result">执行结果值</param>
        /// <param name="para">参数集</param>
        /// <returns></returns>
        [OperationContract]
        int ExecuteCachedForGet(out object result, params object[] para);
        #endregion

        #region ExecuteCachedForGetJson( out object result, params object[] para )
        /// <summary>
        /// 执行读取缓存操作
        /// </summary>
        /// <param name="result">执行结果值</param>
        /// <param name="para">参数集</param>
        /// <returns></returns>
        [OperationContract]
        int ExecuteCachedForGetJson(out object result, params object[] para);
        #endregion

        #region ExecuteCachedForRemove( out bool result, params object[] para )
        /// <summary>
        /// 执行读取缓存操作
        /// </summary>
        /// <param name="result">执行结果值</param>
        /// <param name="para">参数集</param>
        /// <returns></returns>
        [OperationContract]
        int ExecuteCachedForRemove(out bool result, params object[] para);
        #endregion
        */
    }
}
