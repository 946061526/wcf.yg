using System.Data;

namespace wcfNSYGShop
{
    public class DALIM : DALBase, IDALIM
    {
        #region IDisposable 成员

        public void Dispose()
        {
        }

        #endregion

        #region 获取所有IM服务器的IP记录
        /// <summary>
        /// 获取所有IM服务器的IP记录
        /// </summary>
        /// <returns></returns>
        public DataSet GetIMServerIPTable()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "14570" );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_IMComunicate.sp_getIMIPTable" );
        }
        #endregion

    }
}
