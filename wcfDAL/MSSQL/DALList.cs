using System.Data.Common;
using System.Collections.Generic;

namespace wcfNSYGShop
{
    public class DALList<T> : DALBase
    {

        #region 委托，把SqlDataReader中的一行数据转换成Model  Edit:2011.7.13
        /// <summary>
        /// 委托，把SqlDataReader中的一行数据转换成Model
        /// </summary>
        /// <param name="reader">SqlDataReader</param>
        /// <returns></returns>
        public delegate T DRToModelDelegate( DbDataReader reader );
        #endregion

        #region 从SqlDataReader提取数据到泛型数组  Edit:2011.7.13
        /// <summary>
        /// 从SqlDataReader提取数据到泛型数组
        /// </summary>
        /// <param name="dtm">DataToModelDelegate委托的实现</param>
        /// <param name="dr">传入一个已经打开的SqlDataReader</param>
        /// <returns></returns>
        protected List<T> ListFromDR( DRToModelDelegate dtm, DbDataReader dr )
        {
            List<T> list = new List<T>();
            if ( dr.HasRows )
            {
                while ( dr.Read() )
                {
                    list.Add( dtm( dr ) );
                }
            }
            dr.Close();
            if ( list.Count == 0 )
            {
                return null;
            }
            return list;
        }
        #endregion

    }
}
