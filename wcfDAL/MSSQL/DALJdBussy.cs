using System.Data;

namespace wcfNSYGShop
{
    public class DALJdBussy : DALBase, IDALJdBussy
    {
        #region 获取京东账号信息
        /// <summary>
        /// 获取京东账号信息
        /// </summary>
        /// <param name="yunUser">云购账号</param>
        /// <returns></returns>
        public DataSet GetJdTokenByUser( string yunUser )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "14304" );
            Para.AddOrcNewInParameter( "i_YunUser", yunUser );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_JDBussy.sp_getJDTokenByUser" );
        }
        #endregion

        #region 分布获取修改京东下单明细14314
        /// <summary>
        /// 分布获取修改京东下单明细14314
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public DataSet GetJdOrderDetailByONO( int orderNO )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "14314" );
            Para.AddOrcNewInParameter( "i_yunOrderno", orderNO );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_JDBussy.sp_getjdOrderDetailByONO" );
        }
        #endregion
        #region IDisposable 成员

        public void Dispose()
        {
        }

        #endregion
    }
}
