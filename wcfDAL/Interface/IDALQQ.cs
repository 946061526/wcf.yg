using System;
using System.Data;

namespace wcfNSYGShop
{
    public interface IDALQQ
    {
        /// <summary>
        /// 获取QQ群帐号置顶列表
        /// </summary>
        /// <returns></returns>
        DataSet GetQQAccountTopList();

        /// <summary>
        /// 获取QQ群帐号列表
        /// </summary>
        /// <param name="areaID">区域</param>
        /// <param name="key">查询关键字</param>
        /// <param name="FIdx">开始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        DataSet GetQQAccountPageList( int areaID, string key, int FIdx, int EIdx, bool isCount, out int totalCount );
    }
}
