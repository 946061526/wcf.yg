using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 获取所有IM服务器的IP记录
        /// <summary>
        /// 获取所有IM服务器的IP记录
        /// </summary>
        /// <returns></returns>
        public static DataSet GetIMServerIPTable()
        {
            DataSet _DS = null;
            using ( IDALIM _DAL = new DALIM() )
            {
                _DS = _DAL.GetIMServerIPTable();
            }
            return _DS;
        }
        #endregion
    }
}
