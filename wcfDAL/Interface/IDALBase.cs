
namespace wcfNSYGShop
{
    public interface IDALBase
    {

        #region void DisposeConn() 关闭并释放连接对象资源  Edit:2010.02.08
        /// <summary>
        /// 关闭并释放连接资源
        /// </summary>
        void DisposeConn();
        #endregion

        #region void TranBegin() 事务开始  Edit:2010.12.24
        /// <summary>
        /// 启用事务
        /// </summary>
        void TranBegin();
        #endregion
        #region void TranCommit() 提交事务  Edit:2010.12.24
        /// <summary>
        /// 提交事务
        /// </summary>
        void TranCommit();
        #endregion
        #region void TranRollBack() 回滚事务  Edit:2010.12.24
        /// <summary>
        /// 回滚事务
        /// </summary>
        void TranRollBack();
        #endregion
        #region bool IsUseTrans 获取事务状态  Edit:2010.12.24
        /// <summary>
        /// 获取事务状态,true:表顺利执行
        /// </summary>
        bool IsUseTrans
        {
            get;
        }
        #endregion

    }
}
