using System;
using System.Data;
using System.ServiceModel;

namespace wcfNSYGShop
{
    /// <summary>
    /// 收货地址相关接口
    /// </summary>
    public partial interface IWCFContract
    {
        #region 获取某会员收货地址列表信息
        /// <summary>
        /// 获取某会员收货地址列表信息
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserContactListByID( int userID );
        #endregion

        #region 添加收货地址信息
        /// <summary>
        /// 添加收货地址信息
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="userName">收货人姓名</param>
        /// <param name="areaID">所在区ID</param>
        /// <param name="streetID">所在街道ID</param>
        /// <param name="address">收货地址</param>
        /// <param name="zip">邮编</param>
        /// <param name="mobile">手机号</param>
        /// <param name="tel">联系电话</param>
        /// <param name="isDefault">是否默认地址</param>
        /// <returns></returns>
        [OperationContract]
        int AddNewUserContact( int userID, string userName, int areaID, int streetID, string address, string zip, string mobile, string tel, bool isDefault );
        #endregion

        #region 修改收货地址信息
        /// <summary>
        /// 修改收货地址信息
        /// </summary>
        /// <param name="contactID">ID</param>
        /// <param name="userID">会员ID</param>
        /// <param name="userName">收货人姓名</param>
        /// <param name="areaID">所在区ID</param>
        /// <param name="streetID">所在街道ID</param>
        /// <param name="address">收货地址</param>
        /// <param name="zip">邮编</param>
        /// <param name="mobile">手机号</param>
        /// <param name="tel">联系电话</param>
        /// <param name="isDefault">是否默认地址</param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateUserContact( int contactID, int userID, string userName, int areaID, int streetID, string address, string zip, string mobile, string tel, bool isDefault );
        #endregion

        #region 获取收货地址信息
        /// <summary>
        /// 获取收货地址信息
        /// </summary>
        /// <param name="contactID">地址ID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserContactInfoByID( int contactID );
        #endregion

        #region 删除收货地址信息，默认地址不可删除
        /// <summary>
        /// 删除收货地址信息，默认地址不可删除
        /// </summary>
        /// <param name="contactID">地址ID号</param>
        /// <param name="userID">会员ID号</param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteUserContact( int contactID, int userID );
        #endregion

        #region 获取某会员的收货地址数量
        /// <summary>
        /// 获取某会员的收货地址数量
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        [OperationContract]
        int GetUserContactCount( int userID );
        #endregion

        #region 修改收货地址是否为默认地址
        /// <summary>
        /// 修改收货地址是否为默认地址
        /// </summary>
        /// <param name="contactID">地址ID号</param>
        /// <param name="userID">会员ID号</param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateUserContactDefault( int contactID, int userID );
        #endregion
    }
}
