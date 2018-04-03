using System;
using System.Data;

namespace wcfNSYGShop
{
    public class DALNews : DALBase, IDALNews
    {
        /// <summary>
        /// 获取新闻信息
        /// </summary>
        /// <param name="newsID">新闻ID</param>
        /// <returns></returns>
        public DataSet GetNewsInfoByID( int newsID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11904" );
            Para.AddOrcNewInParameter( "i_newsID", newsID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_News.sp_getNewsByNewsID" );//pro_NewsGetListByNewID
        }
    }
}
