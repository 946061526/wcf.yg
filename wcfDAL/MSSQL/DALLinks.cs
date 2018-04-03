using System;
using System.Data;

namespace wcfNSYGShop
{
    public class DALLinks : DALBase, IDALLinks
    {
        /// <summary>
        /// 获取链接列表
        /// </summary>
        /// <param name="type">类别</param>
        /// <returns></returns>
        public DataSet GetLinksInfoByType( int type )
        {
            /* 此方法目前未使用 */
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11603" );
            Para.AddOrcNewInParameter( "i_linksType", type );
            Para.AddOrcNewInParameter( "i_FIdx", 1 );
            Para.AddOrcNewInParameter( "i_EIdx", int.MaxValue );
            Para.AddOrcNewInParameter( "i_IsCount", 0 );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_LinksForFriend.sp_getLinkForBeforeByType" );//pro_LinksGetInfoForDisplay
        }
    }
}
