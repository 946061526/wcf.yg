using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 获取京东账号信息13404
        /// <summary>
        /// 获取京东账号信息
        /// </summary>
        /// <param name="yunUser">云购账号</param>
        /// <returns></returns>
        public static DataSet GetJdTokenByUser( params object[] para )
        {
            DataSet _DS = null;
            string yunUser = (string)para[0];
            using ( IDALJdBussy _DAL = new DALJdBussy() )
            {
                _DS = _DAL.GetJdTokenByUser( yunUser );
            }
            return _DS;
        }
        #endregion
        #region 分布获取修改京东下单明细14314
        /// <summary>
        /// 分布获取修改京东下单明细14314
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public static DataSet GetJdOrderDetailByONO( params object[] para )
        {
            DataSet _DS = null;
            int _OrderNO = (int)para[0];
            if ( _OrderNO > 0 )
            {
                using ( IDALJdBussy _DAL = new DALJdBussy() )
                {
                    _DS = _DAL.GetJdOrderDetailByONO( _OrderNO );
                }
            }
            return _DS;
        }
        #endregion
    }
}
