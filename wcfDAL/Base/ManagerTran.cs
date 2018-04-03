using Oracle.DataAccess.Client;

namespace wcfNSYGShop
{
    /// <summary>
    /// 关于事务的处理
    /// </summary>
    public class OracleManagerTran
    {
        /// <summary>
        /// 数据访问函数库的实例，主要是想操作Connection
        /// </summary>
        internal OracleDataAccessLibrary _Dal;

        /// <summary>
        /// 用于事务处理
        /// </summary>
        private OracleTransaction _DbTran;



        //事务日志
        #region 事务处理部分。并没有做太多的测试，有不合理的地方请多指教
        /// <summary>
        /// 打开连接，并且开始事务。
        /// </summary>
        public void TranBegin()
        {
            //启用事务暂延时到执行第一个业务之前，直到回滚事务或者提交事务。
            _Dal.IsUseTrans = true;  //标记为启用事务
            _Dal.TranIsSetNode = false;  //是否已分配节点，即完成初始化事务
        }
        public OracleTransaction DbTran
        {
            get
            {
                return _DbTran;
            }
            set
            {
                _DbTran = value;
            }
        }
        #endregion

        #region 提交事务，并关闭连接
        /// <summary>
        /// 提交事务，并关闭连接
        /// </summary>
        public void TranCommit()
        {
            if ( _Dal.IsUseTrans && _Dal.TranIsSetNode )
            {
                //启用了事务
                _DbTran.Commit();           //提交事务
                _Dal.ConnectionClose();     //关闭连接
                _Dal.IsUseTrans = false;    //修改事务标志。
                _DbTran.Dispose();
            }
        }
        #endregion

        #region 回滚事务，并关闭连接。在程序出错的时候，自动调用。
        /// <summary>
        /// 回滚事务，并关闭连接。在程序出错的时候，自动调用。
        /// </summary>
        public void TranRollBack()
        {
            if ( _Dal.IsUseTrans && _Dal.TranIsSetNode )
            {
                _DbTran.Rollback();         //回滚事务
                _Dal.ConnectionClose();     //关闭连接
                _Dal.IsUseTrans = false;    //修改事务标志。
                _DbTran.Dispose();
            }
        }
        #endregion
    }
}
