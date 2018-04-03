using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 获取订单配送信息列表12003
        /// <summary>
        /// 获取订单配送信息列表12003
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public static DataSet GetOrderDeliveryListByNO( params object[] para )
        {
            DataSet _DS = null;
            int _OrderNO = (int)para[0];
            if ( _OrderNO > 0 )
            {
                IDALOrders _DAL = new DALOrders();
                _DS = _DAL.GetOrderDeliveryListByNO( _OrderNO );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 获取非删除状态的订单处理步骤12006
        /// <summary>
        /// 获取非删除状态的订单处理步骤12006
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public static DataSet GetOrderDoStepListByNO( params object[] para )
        {
            DataSet _DS = null;
            int _OrderNO = (int)para[0];
            if ( _OrderNO > 0 )
            {
                IDALOrders _DAL = new DALOrders();
                _DS = _DAL.GetOrderDoStepListByNO( _OrderNO );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 获取订单信息12010
        /// <summary>
        /// 获取订单信息12010
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public static DataSet GetOrderInfoByNO( params object[] para )
        {
            DataSet _DS = null;
            int _OrderNO = (int)para[0];
            if ( _OrderNO > 0 )
            {
                IDALOrders _DAL = new DALOrders();
                _DS = _DAL.GetOrderInfoByNO( _OrderNO );
                _DAL = null;
            }
            return _DS;
        }
        #endregion
        #region 更新订单状态及备注信息12011
        /// <summary>
        /// 更新订单状态及备注信息12011
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="orderRemark">订单备注</param>
        /// <param name="orderState">订单状态</param>
        /// <param name="orderUpdateTime">更新时间</param>
        /// <returns></returns>
        public static int UpdateOrders( params object[] para )
        {
            int _Result = 0;
            int _OrderNO = (int)para[0];
            string _OrderRemark = (string)para[1];
            int _OrderState = (int)para[2];
            DateTime _OrderUpdateTime = (DateTime)para[3];
            if ( _OrderNO > 0 )
            {
                IDALOrders _DAL = new DALOrders();
                _Result = _DAL.UpdateOrders( _OrderNO, _OrderRemark, _OrderState, _OrderUpdateTime );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 更新订单配送信息12012
        /// <summary>
        /// 更新订单配送信息12012
        /// </summary>
        /// <param name="orderNo">订单编号</param>
        /// <param name="userName">收货人姓名</param>
        /// <param name="tel">联系电话</param>
        /// <param name="mobile">手机号</param>
        /// <param name="areaID">所在区ID</param>
        /// <param name="streetID">所在街道ID</param>
        /// <param name="address">收货地址</param>
        /// <param name="zip">邮编</param>
        /// <param name="shipTime">送货时间</param>
        /// <param name="shipRemark">备注</param>
        /// <param name="invoiceT">发票抬头</param>
        /// <param name="invoiceC">发票条目</param>
        /// <param name="dyTypeID"></param>
        /// <returns></returns>
        public static int UpdateOrderShipInfo( params object[] para )
        {
            int orderNO = (int)para[0];
            string buyer = (string)para[1];
            string tel = (string)para[2];
            string mobile = (string)para[3];
            int areaID = (int)para[4];
            int streetID = (int)para[5];
            string address = (string)para[6];
            string zip = (string)para[7];
            DateTime shipTime = (DateTime)para[8];
            string remark = (string)para[9];
            string invoiceT = (string)para[10];
            string invoiceC = (string)para[11];
            int dyTypeID = (int)para[12];
            int _Flag = 0;
            try
            {
                IDALOrders _DAL = new DALOrders();
                _Flag = _DAL.UpdateOrderShipInfo( orderNO, buyer, tel, mobile, areaID, streetID, address, zip,
                    shipTime, remark, invoiceT, invoiceC, dyTypeID ) ? 1 : 0;
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Orders.UpdateOrderShipInfo抛出异常：" + ex.Message );
            }
            return _Flag;
        }
        #endregion
        #region 启用事务更新订单完成状态及备注信息--状态置为10 12013
        /// <summary>
        /// 启用事务
        /// 更新订单完成状态及备注信息、添加订单处理步骤、添加订单日志12013
        /// </summary>
        /// <param name="orderNo">订单编号</param>
        /// <param name="orderRemark">订单备注</param>
        /// <param name="logDescription">配送评价</param>
        /// <param name="loginUserName">登录者姓名</param>
        /// <returns></returns>
        public static int UpdateOrderForEndTran( params object[] para )
        {
            int _Result = 0;
            int _OrderNo = (int)para[0];
            string _OrderRemark = (string)para[1];
            string _LogDescription = (string)para[2];
            string _LoginUserName = (string)para[3];
            if ( _OrderNo > 0 )
            {
                IDALOrders _DAL = new DALOrders();
                _Result = _DAL.UpdateOrderForEndTran( _OrderNo, _OrderRemark, _LogDescription, _LoginUserName );
                _DAL = null;
            }
            return _Result;
        }
        #endregion
        #region 更新订单配送信息、添加订单处理步骤、添加订单日志12014
        /// <summary>
        /// 启用事务
        /// 更新订单配送信息、添加订单处理步骤、添加订单日志12014
        /// </summary>
        /// <param name="orderNo">订单编号</param>
        /// <param name="userName">收货人姓名</param>
        /// <param name="tel">联系电话</param>
        /// <param name="mobile">手机号</param>
        /// <param name="areaID">所在区ID</param>
        /// <param name="areaID">所在街道ID</param>
        /// <param name="address">收货地址</param>
        /// <param name="zip">邮编</param>
        /// <param name="shipTime">送货时间</param>
        /// <param name="shipRemark">备注</param>
        /// <param name="invoiceT">发票抬头</param>
        /// <param name="invoiceC">发票条目</param>
        /// <param name="loginUserName">登录者姓名</param>
        /// <returns></returns>
        public static int UpdateOrderShipInfoTran( params object[] para )
        {
            return UpdateOrderShipInfoTranEx( para );
        }
        #endregion
        #region 更新订单配送信息、添加订单处理步骤、添加订单日志120142
        /// <summary>
        /// 启用事务
        /// 更新订单配送信息、添加订单处理步骤、添加订单日志120142
        /// </summary>
        /// <param name="orderNo">订单编号</param>
        /// <param name="userName">收货人姓名</param>
        /// <param name="tel">联系电话</param>
        /// <param name="mobile">手机号</param>
        /// <param name="areaID">所在区ID</param>
        /// <param name="areaID">所在街道ID</param>
        /// <param name="address">收货地址</param>
        /// <param name="zip">邮编</param>
        /// <param name="shipTime">送货时间</param>
        /// <param name="shipRemark">备注</param>
        /// <param name="invoiceT">发票抬头</param>
        /// <param name="invoiceC">发票条目</param>
        /// <param name="loginUserName">登录者姓名</param>
        /// <returns></returns>
        public static int UpdateOrderShipInfoTranEx( params object[] para )
        {
            int _Result = 0;
            int _DoStep = 0;
            int _OrderNo = 0;
            int _ContactID = 0;

            try
            {
                _DoStep = 1;

                _OrderNo = (int)para[0];//订单号
                string _LoginUserName = (string)para[1];//会员登录名(昵称-手机号-邮箱)
                _ContactID = (int)para[2];//地址ID
                string _IdentSortIDStr = (string)para[3];//证件ID串
                string _IdentContentStr = (string)para[4];//证件内容串
                string _OrderSpecIDStr = (string)para[5];//订单商品规格ID串
                string _DeltaNumber = (string)para[6];//充值手机号
                string _ShipRemark = (string)para[7];//订单备注
                string _OrderSpecValStr = "";//订单商品规格val串
                bool _IsAppSubmit = true;
                if ( para.Length == 9 )
                {
                    _OrderSpecValStr = (string)para[8];
                    _IsAppSubmit = false;
                }

                string _UserName = "";
                string _Tel = "";
                string _Mobile = "";
                int _AreaAID = 0;
                int _AreaBID = 0;
                int _AreaCID = 0;
                int _AreaDID = 0;
                string _Address = "";
                string _Zip = "";
                string _ShipTime = "";
                string _InvoiceT = "";
                string _InvoiceC = "";

                int _IsNoDelvery = 0;//是否不能配送地区

                if ( _OrderNo > 0 && _ContactID > 0 )
                {
                    _DoStep = 2;

                    #region 一、获取用户地址信息
                    IDALUserContact _DALUC = new DALUserContact();
                    DataSet _DS = _DALUC.GetUserContactInfoByID( _ContactID );
                    _DALUC = null;
                    if ( _DS != null && _DS.Tables.Count > 0 && _DS.Tables[0].Rows.Count > 0 )
                    {
                        DataRow _DR = _DS.Tables[0].Rows[0];
                        _UserName = _DR["contactName"].ToString();
                        _Tel = _DR["contactTel"].ToString();
                        _Mobile = _DR["contactMobile"].ToString();
                        _AreaAID = UtilityFun.ToInt32( _DR["areaAID"] );
                        _AreaBID = UtilityFun.ToInt32( _DR["areaBID"] );
                        _AreaCID = UtilityFun.ToInt32( _DR["areaCID"] );
                        _AreaDID = UtilityFun.ToInt32( _DR["areaDID"] );
                        _Address = string.Format( "{0} {1} {2} {3}{4}", _DR["areaAName"], _DR["areaBName"], _DR["areaCName"], _AreaDID <= 0 ? "" : _DR["areaDName"].ToString() + " ", _DR["contactAddress"] );
                        _Zip = _DR["contactZip"].ToString();
                        _DR = null;
                    }
                    _DS = null;
                    #endregion

                    _DoStep = 3;

                    #region 二、检测用户地址是否能配送
                    IDALGoods _DALGoods = new DALGoods();
                    DataTable _DTGoodsShip = _DALGoods.GetNoDyAreaByGoodsID( _OrderNo, 1, 1000 );
                    _DALGoods = null;
                    if ( _DTGoodsShip != null && _DTGoodsShip.Rows.Count > 0 )
                    {
                        string _UserAreaIDStr = "," + _AreaAID + "," + _AreaBID + "," + _AreaCID + "," + ( _AreaDID > 0 ? _AreaDID + "," : "" );
                        for ( int i = 0; i < _DTGoodsShip.Rows.Count; i++ )
                        {
                            if ( _UserAreaIDStr.IndexOf( "," + _DTGoodsShip.Rows[i]["areaid"].ToString() + "," ) > -1 )
                            {
                                _IsNoDelvery = 1;//此用户地址不可配送
                                break;
                            }
                        }
                    }
                    _DTGoodsShip = null;
                    #endregion


                    //三、处理订单提交收货信息
                    IDALOrders _DAL = new DALOrders();
                    _DAL.TranBegin();
                    bool _IsCommit = true;

                    #region 1.保存证件信息
                    if ( _IdentSortIDStr != "" && _IdentContentStr != "" )
                    {
                        _DoStep = 4;

                        string[] _IdentSortIDArr = _IdentSortIDStr.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries );
                        string[] _IdentContentArr = _IdentContentStr.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries );
                        if ( _IdentSortIDArr != null && _IdentSortIDArr.Length > 0 && _IdentContentArr != null && _IdentSortIDArr.Length == _IdentContentArr.Length )
                        {
                            for ( int i = 0; i < _IdentSortIDArr.Length; i++ )
                            {
                                _Result = _DAL.InsertOrderIdentification( _OrderNo, UtilityFun.ToInt32( _IdentSortIDArr[i] ), _IdentContentArr[i], i + 1, 1 );
                                if ( _Result < 1 || !_DAL.IsUseTrans )
                                {
                                    _IsCommit = false;
                                    break;
                                }
                            }

                            if ( _IsCommit )
                            {
                                _DoStep = 5;
                                //2.关联地址ID与证件信息
                                _Result = _DAL.InsertAddressIdentification( _ContactID, _OrderNo, 1 );
                                if ( _Result < 1 || !_DAL.IsUseTrans )
                                {
                                    _IsCommit = false;
                                }
                            }
                        }
                    }
                    #endregion

                    if ( _IsCommit )
                    {
                        _DoStep = 6;

                        //3.提交收货地址
                        _Result = _DAL.UpdateOrderShipInfoTran( _OrderNo, _UserName, _Tel, _Mobile, _AreaCID, _AreaDID, _Address, _Zip, _ShipTime, _ShipRemark, _InvoiceT, _InvoiceC, _OrderSpecIDStr, _DeltaNumber, _IsNoDelvery, _LoginUserName, 1 );

                        if ( _Result > 0 && _DAL.IsUseTrans )
                        {
                            //4.保存商品规格信息
                            if ( _OrderSpecIDStr != "" )
                            {
                                _DoStep = 7;

                                string _SkuCode = GetOrderSkuBySelectAttrID( _OrderNo, _OrderSpecIDStr );

                                if ( _IsAppSubmit )//app提交，需根据属性ID找到属性名称
                                {
                                    _OrderSpecValStr = GetAttrValueStrByAttrID( _OrderNo, _OrderSpecIDStr );
                                }

                                int _IsNeedUpdateSku = _SkuCode == "" ? 1 : 0;

                                _Result = _DAL.UpdateOrderSkuByOrderNO( _OrderNo, _SkuCode, _OrderSpecValStr, _IsNeedUpdateSku, 1 );
                                if ( _Result < 1 || !_DAL.IsUseTrans )
                                {
                                    _IsCommit = false;
                                }
                                //string[] _LabelSortIDArr = _OrderSpecIDStr.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries );
                                //if ( _LabelSortIDArr != null && _LabelSortIDArr.Length > 0 )
                                //{
                                //    for ( int i = 0; i < _LabelSortIDArr.Length; i++ )
                                //    {
                                //        _Result = _DAL.InsertOrderSpec( _OrderNo, UtilityFun.ToInt32( _LabelSortIDArr[i] ), i + 1, 1 );
                                //        if ( _Result < 1 || !_DAL.IsUseTrans )
                                //        {
                                //            _IsCommit = false;
                                //            break;
                                //        }
                                //    }
                                //}
                            }
                        }
                        else
                        {
                            _IsCommit = false;
                        }
                    }

                    if ( _IsCommit )
                    {
                        _DAL.TranCommit();
                        _Result = 1;
                    }
                    else
                    {
                        _DAL.TranRollBack();
                    }

                    _DAL.DisposeConn();
                    _DAL = null;
                }
            }
            catch ( Exception ex )
            {
                _Result = -2;
                UtilityFile.AddLogErrMsg( "OrderShip", string.Format( "orderNO:{0},contactID:{1},doStep:{2},Ex:{3}", _OrderNo, _ContactID, _DoStep, ex.Message ) );
            }

            if ( _Result != 1 )
            {
                _Result = Math.Abs( _Result );
                _Result = -UtilityFun.ToInt32( _DoStep.ToString() + ( _Result < 10 ? "10" + _Result.ToString() : _Result < 100 ? "1" + _Result.ToString() : ( 100 + _Result ).ToString() ) );
                UtilityFile.AddLogErrMsg( "OrderShip", string.Format( "orderNO:{0},contactID:{1},doStep:{2},result:{3}", _OrderNo, _ContactID, _DoStep, _Result ) );
            }
            return _Result;
        }
        /// <summary>
        /// 根据用户所选属性ID找到相应sku码
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="attrIDStr">属性ID串</param>
        /// <returns></returns>
        private static string GetOrderSkuBySelectAttrID( int orderNO, string attrIDStr )
        {
            string _SkuCode = "";
            try
            {
                DataSet _DS = GetSkuAttrByOrderNo( new object[] { 0, orderNO } );
                if ( _DS != null && _DS.Tables[0].Rows.Count > 0 )
                {
                    string[] _AttrIDAttr = attrIDStr.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries );
                    if ( _AttrIDAttr != null && _AttrIDAttr.Length > 0 )
                    {
                        attrIDStr = "," + attrIDStr + ",";
                        DataTable _SkuList = _DS.Tables[0];
                        DataRow[] _Rows = _SkuList.Select( "status=2 and valueid=" + _AttrIDAttr[0] );
                        if ( _Rows != null && _Rows.Length > 0 )
                        {
                            DataRow[] _Rows2;
                            for ( int i = 0; i < _Rows.Length; i++ )
                            {
                                _Rows2 = _SkuList.Select( "code='" + _Rows[i]["code"].ToString() + "'" );
                                //检测此sku是否所选的
                                if ( _Rows2 != null && _Rows2.Length == _AttrIDAttr.Length )
                                {
                                    bool _isTrue = true;
                                    for ( int j = 0; j < _Rows2.Length; j++ )
                                    {
                                        if ( !attrIDStr.Contains( "," + _Rows2[j]["valueid"] + "," ) )
                                        {
                                            _isTrue = false;
                                            break;
                                        }
                                    }

                                    if ( _isTrue )
                                    {
                                        _SkuCode = _Rows[i]["code"].ToString();
                                        break;
                                    }
                                }
                            }
                            _Rows2 = null;
                        }
                        _Rows = null;
                        _SkuList = null;
                    }
                }
                _DS = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogMsg( "Orders.GetOrderSkuBySelectAttrID Ex: " + ex.Message );
            }
            return _SkuCode;
        }
        /// <summary>
        /// 根据用户所选属性ID找到相应的属性名称
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="attrIDStr">属性ID串</param>
        /// <returns></returns>
        private static string GetAttrValueStrByAttrID( int orderNO, string attrIDStr )
        {
            string _AttrValue = "";
            try
            {
                DataSet _DS = GetSkuAttrByOrderNo( new object[] { 0, orderNO } );
                if ( _DS != null && _DS.Tables[1].Rows.Count > 0 )
                {
                    string[] _AttrIDAttr = attrIDStr.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries );
                    if ( _AttrIDAttr != null && _AttrIDAttr.Length > 0 )
                    {
                        DataTable _AttrList = _DS.Tables[1];
                        DataRow[] _Rows = null;
                        for ( int i = 0; i < _AttrIDAttr.Length; i++ )
                        {
                            _Rows = _AttrList.Select( "valueid=" + _AttrIDAttr[i] );
                            if ( _Rows != null && _Rows.Length > 0 )
                            {
                                _AttrValue += _Rows[0]["valuename"].ToString() + ",";
                            }
                        }
                        _Rows = null;
                        _AttrList = null;
                    }
                }
                _DS = null;
                _AttrValue = _AttrValue.Trim( ',' );
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogMsg( "Orders.GetAttrValueStrByAttrID Ex: " + ex.Message );
            }
            return _AttrValue;
        }
        #endregion
        #region 获取订单配送信息12020
        /// <summary>
        /// 获取订单配送信息
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public static DataSet GetOrderDischInfoByOrderNO( params object[] para )
        {
            DataSet _DS = null;
            int _OrderNO = (int)para[0];
            IDALOrders _DAL = new DALOrders();
            _DS = _DAL.GetOrderDischInfoByOrderNO( _OrderNO );
            _DAL = null;
            return _DS;
        }
        #endregion

        #region 修改订单证件信息12022
        /// <summary>
        /// 修改订单证件信息
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="addriSortID">证件类型ID</param>
        /// <param name="identification">证件内容</param>
        /// <param name="isCommit">是由程序提交：0否，1是</param>
        /// <returns></returns>
        public static int UpdateOrderIdentification( params object[] para )
        {
            int _Result = -201;
            int _OrderNO = (int)para[0];
            string _IdentSortIDStr = (string)para[1];
            string _IdentContentStr = (string)para[2];
            if ( _OrderNO > 0 && _IdentSortIDStr != "" && _IdentContentStr != "" )
            {
                string[] _IdentSortIDArr = _IdentSortIDStr.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries );
                string[] _IdentContentArr = _IdentContentStr.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries );
                if ( _IdentSortIDArr != null && _IdentSortIDArr.Length > 0 && _IdentContentArr != null && _IdentSortIDArr.Length == _IdentContentArr.Length )
                {
                    IDALOrders _DAL = new DALOrders();
                    _DAL.TranBegin();
                    bool _IsCommit = true;
                    for ( int i = 0; i < _IdentSortIDArr.Length; i++ )
                    {
                        _Result = _DAL.UpdateOrderIdentification( _OrderNO, UtilityFun.ToInt32( _IdentSortIDArr[i] ), _IdentContentArr[i], 1 );
                        if ( _Result < 1 || !_DAL.IsUseTrans )
                        {
                            _IsCommit = false;
                            break;
                        }
                    }

                    if ( _IsCommit )
                    {
                        DataTable _DT = _DAL.GetOrderExtendInfoByOrderNO( _OrderNO );
                        if ( _DT != null && _DT.Rows.Count > 0 )
                        {
                            int _ContactID = UtilityFun.ToInt32( _DT.Rows[0]["contactid"] );
                            if ( _ContactID > 0 )
                            {
                                _Result = _DAL.InsertAddressIdentification( _ContactID, _OrderNO, 1 );
                                if ( _Result < 1 || !_DAL.IsUseTrans )
                                {
                                    _IsCommit = false;
                                }
                            }
                        }
                        _DT = null;
                    }

                    if ( _IsCommit )
                    {
                        _DAL.TranCommit();
                        _Result = 1;
                    }
                    else
                    {
                        _DAL.TranRollBack();
                    }

                    _DAL.DisposeConn();
                    _DAL = null;
                }
            }
            return _Result;
        }
        #endregion

        #region 根据订单号获取相关证件列表12023
        /// <summary>
        /// 根据订单号获取相关证件列表
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public static DataSet GetIdentificationByOrderNO( params object[] para )
        {
            DataSet _DS = null;
            int _GoodsID = (int)para[0];
            int _OrderNO = (int)para[1];
            IDALOrders _DAL = new DALOrders();
            _DS = _DAL.GetIdentificationByOrderNO( _GoodsID, _OrderNO );
            _DAL = null;
            return _DS;
        }
        #endregion

        #region 获取绑定到地址信息里面的证件信息12025
        /// <summary>
        /// 获取绑定到地址信息里面的证件信息
        /// </summary>
        /// <param name="contactID"></param>
        /// <returns></returns>
        public static DataSet GetAddressIdentification( params object[] para )
        {
            DataSet _DS = null;
            int _ContactID = (int)para[0];
            IDALOrders _DAL = new DALOrders();
            _DS = _DAL.GetAddressIdentification( _ContactID );
            _DAL = null;
            return _DS;
        }
        #endregion

        #region 根据订单号获取相关规格列表12027
        /// <summary>
        /// 根据订单号获取相关规格列表
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public static DataSet GetSpecListByOrderNO( params object[] para )
        {
            int _GoodsID = (int)para[0];
            int _OrderNO = (int)para[1];
            IDALOrders _DAL = new DALOrders();
            DataSet _DS = _DAL.GetSpecListByOrderNO( _GoodsID, _OrderNO );
            _DAL = null;
            return _DS;
        }
        #endregion

        #region 根据时间抓取数据（跨境电商）12028
        /// <summary>
        /// 根据时间抓取数据（跨境电商）
        /// </summary>
        /// <param name="fetchTime">抓取时间</param>
        /// <param name="FIdx">起始索引</param>
        /// <param name="EIdx">线束索引</param>
        /// <param name="totalCount">输出总行数</param>
        /// <returns></returns>
        public static DataSet GetOrderListByTime( out int totalCount, params object[] para )
        {
            DateTime _FetchTime = DateTime.Now;
            int _OrderNO = (int)para[1];
            if ( _OrderNO == 0 )
            {
                _FetchTime = (DateTime)para[0];
            }
            int _FIdx = (int)para[2];
            int _EIdx = (int)para[3];
            IDALOrders _DAL = new DALOrders();
            DataSet _DS = _DAL.GetOrderListByTime( _FetchTime, _OrderNO, _FIdx, _EIdx, out totalCount );
            _DAL = null;
            return _DS;
        }
        #endregion

        #region 跨境电商订单发货回写并出库12029
        /// <summary>
        /// 跨境电商订单发货回写并出库
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="shipName">快递商名字</param>
        /// <param name="shipNO">快递单号</param>
        /// <returns></returns>
        public static int UpdateKJDSorderFinish( params object[] para )
        {
            int _OrderNO = (int)para[0];
            string _ShipName = (string)para[1];
            string _ShipNO = (string)para[2];
            IDALOrders _DAL = new DALOrders();
            int _RetVal = _DAL.UpdateKJDSorderFinish( _OrderNO, _ShipName, _ShipNO );
            _DAL = null;
            UtilityFile.AddLogErrMsg( "KJDS", string.Format( "orderNO:{0},shipName:{1},shipNO:{2},retVal:{3}", _OrderNO, _ShipName, _ShipNO, _RetVal ) );
            return _RetVal;
        }
        #endregion

        #region 根据商品ID及订单号获取相关SKU和属性列表12031
        /// <summary>
        /// 根据商品ID及订单号获取相关SKU和属性列表
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public static DataSet GetSkuAttrByOrderNo( object[] para )
        {
            DataSet _DS = null;
            try
            {
                int goodsID = (int)para[0];
                int orderNO = (int)para[1];
                IDALOrders _DAL = new DALOrders();
                _DS = _DAL.GetSkuAttrByOrderNo( goodsID, orderNO );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogMsg( "Orders.GetSkuAttrByOrderNo Ex:" + ex.Message );
            }
            return _DS;
        }
        #endregion
    }
}
