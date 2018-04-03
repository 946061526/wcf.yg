using System;
using System.Data;

namespace wcfNSYGShop
{
    public interface IDALBaseArea
    {
        #region 获取某区域ID下的子区域列表
        /// <summary>
        /// 获取某区域ID下的子区域列表
        /// </summary>
        /// <param name="sortID">区域ID</param>
        /// <returns></returns>
        DataSet GetChildAreaByID( int areaID );
        #endregion
    }
}
