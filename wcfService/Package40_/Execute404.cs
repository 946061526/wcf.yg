using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class ExecuteFun
    {
        #region 实名认证申请通过第三方API验证后提交和审批失败后重新提交40402
        /// <summary>
        /// 实名认证申请通过第三方API验证后提交和审批失败后重新提交40402
        /// </summary>
        /// <param name="userID">会员id</param>
        /// <param name="mobile">手机号</param>
        /// <param name="realName">真实姓名</param>
        /// <param name="sex">性别:0 未设置,1 女,2 男,3 保密</param>
        /// <param name="ethnicity">民族</param>
        /// <param name="birth">出生年月日</param>
        /// <param name="address">住址</param>
        /// <param name="idNumber">身份证号</param>
        /// <param name="authority">签发机关</param>
        /// <param name="fvalidity">有效期限</param>
        /// <param name="uploadPic">上传证照,前端自己拟定顺序</param>
        /// <returns></returns>
        public static int AddRealNameAuth( params object[] para )
        {
            int _Result = 0;
            try
            {
                int userID = (int)para[0];
                string mobile = (string)para[1];
                string realName = (string)para[2];
                int sex = (int)para[3];
                string ethnicity = (string)para[4];
                string birth = (string)para[5];
                string address = (string)para[6];
                string idNumber = (string)para[7];
                string authority = (string)para[8];
                string fvalidity = (string)para[9];
                string uploadPic = (string)para[10];

                IDALLive _DAL = new DALLive();
                _Result = _DAL.AddRealNameAuth( userID, mobile, realName, sex, ethnicity, birth, address, idNumber, authority, fvalidity, uploadPic );
                _DAL = null;

            }
            catch ( Exception ex )
            {
                _Result = -202;
                UtilityFile.AddLogErrMsg( "AddRealNameAuth Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion
        #region 第三方认证日志40403
        /// <summary>
        /// 第三方认证日志40403
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="executant">操作人id</param>
        /// <param name="logType">日志类型: 0 调用第三方API认证 1 第三方API认证失败 2 会员上传资料等待审批 3 审批成功 4 审批失败 5 重新提交(失败后)</param>
        /// <param name="logDetail">日志详情</param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        public static int AddAuthLog( params object[] para )
        {
            int _Result = 0;
            try
            {
                int userID = (int)para[0];
                int executant = (int)para[1];
                int logType = (int)para[2];
                string logDetail = (string)para[3];

                IDALLive _DAL = new DALLive();
                _Result = _DAL.AddAuthLog( userID, executant, logType, logDetail );
                _DAL = null;

            }
            catch ( Exception ex )
            {
                _Result = -202;
                UtilityFile.AddLogErrMsg( "AddAuthLog Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion
        #region 申请认证调用第三方API校验40404
        /// <summary>
        /// 申请认证调用第三方API校验40404
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="idNumber">省份证号码</param>
        /// <returns>
        /// 1--操作成功;
        /// -101--该会员已经连续三天都申请五次已经被列入黑名单;
        /// -102--该身份证已被使用
        /// -103--当天已经申请五次
        /// -104--表示连续三天都申请五次已被列入黑名单，30天内不得再次申请
        /// </returns>
        public static int CheckAuthApi( params object[] para )
        {
            int _Result = 0;
            try
            {
                int userID = (int)para[0];
                string idNumber = (string)para[1];
                IDALLive _DAL = new DALLive();
                _Result = _DAL.CheckAuthApi( userID, idNumber );
                _DAL = null;

            }
            catch ( Exception ex )
            {
                _Result = -202;
                UtilityFile.AddLogErrMsg( "CheckAuthApi Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion
        #region 开始直播，直播入口40405
        /// <summary>
        /// 开始直播，直播入口40405
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="title"></param>
        /// <param name="cover"></param>
        /// <returns></returns>
        public static DataSet AddLiveVideo( params object[] para )
        {
            DataSet _DS = null;
            try
            {
                int userID = (int)para[0];
                string title = (string)para[1];
                string cover = (string)para[2];

                IDALLive _DAL = new DALLive();
                _DS = _DAL.AddLiveVideo( userID, title, cover );
                _DAL = null;

            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "AddLiveVideo Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 获取举报类型列表40406
        /// <summary>
        /// 获取举报类型列表40406
        /// </summary>
        /// <returns></returns>
        public static DataSet GetLiveReportList()
        {
            DataSet _DS = null;
            try
            {
                IDALLive _DAL = new DALLive();
                _DS = _DAL.GetLiveReportList();
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "GetLiveReportList Ex: " + ex.Message );
            }
            return _DS;
        }

        #endregion
        #region 结束直播40407
        /// <summary>
        /// 结束直播40407
        /// </summary>
        /// <param name="liveID">直播ID</param>
        /// <param name="viewerNum">观众人数</param>
        /// <returns></returns>
        public static DataSet EndLiveVideo( params object[] para )
        {
            DataSet _DS = null;
            try
            {
                int liveID = (int)para[0];
                int viewerNum = (int)para[1];

                IDALLive _DAL = new DALLive();
                _DS = _DAL.EndLiveVideo( liveID, viewerNum );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "EndLiveVideo Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 通过主播的userId 得出直播的id40408
        /// <summary>
        /// 通过主播的userId 得出直播的id40508
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static DataSet GetLiveIDByUserID( params object[] para )
        {
            DataSet _DS = null;
            try
            {
                int userID = (int)para[0];

                IDALLive _DAL = new DALLive();
                _DS = _DAL.GetLiveIDByUserID( userID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "GetLiveIDByUserID Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 修改直播间直播标题40409
        /// <summary>
        /// 修改直播间直播标题40409
        /// </summary>
        /// <param name="liveID">直播ID</param>
        /// <param name="title">标题</param>
        /// <returns></returns>
        public static int UpdateLiveVideoTitle( params object[] para )
        {
            int _Result = 0;
            try
            {
                int liveID = (int)para[0];
                string title = (string)para[1];

                IDALLive _DAL = new DALLive();
                _Result = _DAL.UpdateLiveVideoTitle( liveID, title );
                _DAL = null;

            }
            catch ( Exception ex )
            {
                _Result = -202;
                UtilityFile.AddLogErrMsg( "UpdateLiveVideoTitle Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion
        #region 直播开播页面返回观众信息和打赏额40410
        /// <summary>
        /// 直播开播页面返回观众信息和打赏额40410
        /// </summary>
        /// <param name="i_supportuserid">用户ID观众ID</param>
        /// <param name="userID">主播ID</param>
        /// <returns></returns>
        public static DataSet GetLiveViewUserList( params object[] para )
        {
            DataSet _DS = null;
            try
            {
                int supUserID = (int)para[0];
                int userID = (int)para[1];
                IDALLive _DAL = new DALLive();
                _DS = _DAL.GetLiveViewUserList( supUserID, userID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "GetLiveViewUserList Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 获取个人名片40411
        /// <summary>
        /// 获取个人名片40411
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="role">角色 1.观众 2.主播</param>
        /// <returns></returns>
        public static DataSet GetLivePersonCard( params object[] para )
        {
            DataSet _DS = null;
            try
            {
                int userID = (int)para[0];
                int role = (int)para[1];
                IDALLive _DAL = new DALLive();
                _DS = _DAL.GetLivePersonCard( userID, role );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "GetLivePersonCard Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 更新视频回放地址40412
        /// <summary>
        /// 更新视频回放地址40412
        /// </summary>
        /// <param name="liveID"></param>
        /// <param name="replayUrl">回放地址</param>
        /// <returns></returns>
        public static int UpdateLiveReplayURL( params object[] para )
        {
            int _Result = 0;
            try
            {
                int liveID = (int)para[0];
                string replayUrl = (string)para[1];

                IDALLive _DAL = new DALLive();
                _Result = _DAL.UpdateLiveReplayURL( liveID, replayUrl );
                _DAL = null;

            }
            catch ( Exception ex )
            {
                _Result = -202;
                UtilityFile.AddLogErrMsg( "updateLiveReplayURL Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion
        #region 获取视频回放地址40413
        /// <summary>
        /// 获取视频回放地址40413
        /// </summary>
        /// <param name="liveID">直播ID</param>
        /// <returns></returns>
        public static DataSet GetlivevideoByID( params object[] para )
        {
            DataSet _DS = null;
            try
            {
                int liveID = (int)para[0];
                IDALLive _DAL = new DALLive();
                _DS = _DAL.GetlivevideoByID( liveID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "GetLiveReplayUrl Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 更新视频回放次数40414
        /// <summary>
        /// 更新视频回放次数40414
        /// </summary>
        /// <param name="liveID">直播ID</param>
        /// <param name="replayCnt">回放次数</param>
        /// <returns></returns>
        public static int UpdateLiveReplayCnt( params object[] para )
        {
            int _Result = 0;
            try
            {
                int liveID = (int)para[0];
                int replayCnt = (int)para[1];
                IDALLive _DAL = new DALLive();
                _Result = _DAL.UpdateLiveReplayCnt( liveID, replayCnt );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "UpdateLiveReplayCnt Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion
        #region 获取心愿单商品列表40415
        /// <summary>
        /// 获取心愿单商品列表40415
        /// </summary>
        /// <param name="FIdx">分页开始索引</param>
        /// <param name="EIdx">分页结束索引</param>
        /// <returns></returns>
        public static DataSet GetLiveWishGoodsList( params object[] para )
        {
            DataSet _DS = null;
            try
            {
                int FIdx = (int)para[0];
                int EIdx = (int)para[1];
                IDALLive _DAL = new DALLive();
                _DS = _DAL.GetLiveWishGoodsList( FIdx, EIdx );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "GetLiveWishGoodsList Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 获取直播间列表40416
        /// <summary>
        /// 获取直播间列表40416
        /// </summary>
        /// <returns></returns>
        public static DataSet GetLiveVideoList( params object[] para )
        {
            DataSet _DS = null;
            try
            {
                int FIdx = (int)para[0];
                int EIdx = (int)para[1];
                int sex = (int)para[2];
                int orderType = (int)para[3];

                IDALLive _DAL = new DALLive();
                _DS = _DAL.GetLiveVideoList( FIdx, EIdx, sex, orderType );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "GetLiveVideoList Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 获取主播正在进行的心愿单40417
        /// <summary>
        /// 获取主播正在进行的心愿单40417
        /// </summary>
        /// <param name="userID">主播ID</param>
        /// <returns></returns>
        public static DataSet GetLiveWishBarcodeDoing( params object[] para )
        {
            DataSet _DS = null;
            try
            {
                int userID = (int)para[0];
                IDALLive _DAL = new DALLive();
                _DS = _DAL.GetLiveWishBarcodeDoing( userID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "GetLiveWishBarcodeDoing Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 主播发布心愿商品40418
        /// <summary>
        /// 主播发布心愿商品40418
        /// </summary>
        /// <param name="userID">主播ID</param>
        /// <param name="wishGoodsID">心愿商品ID</param>
        /// <param name="sendWord">心愿寄语</param>
        /// <param name="goodsID">云购主站商品ID</param>
        /// <returns></returns>
        public static int AddLiveWishBarcode( params object[] para )
        {
            int _Result = 0;
            try
            {
                int userID = (int)para[0];
                int wishGoodsID = (int)para[1];
                string sendWord = (string)para[2];
                int goodsID = (int)para[3];

                IDALLive _DAL = new DALLive();
                _Result = _DAL.AddLiveWishBarcode( userID, wishGoodsID, sendWord, goodsID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "AddLiveWishBarcode Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion

        #region 主播开播中取消心愿40419
        /// <summary>
        /// 主播开播中取消心愿40419
        /// </summary>
        /// <param name="userID">主播ID</param>
        /// <returns></returns>
        public static int UpdateWishBarcodeStatus( params object[] para )
        {
            int _Result = 0;
            try
            {
                int userID = (int)para[0];
                int codeID = (int)para[1];
                IDALLive _DAL = new DALLive();
                _Result = _DAL.UpdateWishBarcodeStatus( userID, codeID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "UpdateWishBarcodeStatus Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion
        #region 主播开播中判断取消心愿重置次数40420
        /// <summary>
        /// 主播开播中判断取消心愿重置次数40420
        /// </summary>
        /// <param name="userID">主播ID</param>
        /// <returns></returns>
        public static int CheckWishBarcodeStatusCnt( params object[] para )
        {
            int _Result = 0;
            try
            {
                int userID = (int)para[0];
                IDALLive _DAL = new DALLive();
                _Result = _DAL.CheckWishBarcodeStatusCnt( userID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "CheckWishBarcodeStatusCnt Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion
        #region 我的云购获取心愿单列表40421
        /// <summary>
        /// 我的云购获取心愿单列表40421
        /// </summary>
        /// <param name="userID">主播ID</param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <returns></returns>
        public static DataSet GetLiveWishBarcodeList( params object[] para )
        {
            DataSet _DS = null;
            try
            {
                int userID = (int)para[0];
                int FIdx = (int)para[1];
                int EIdx = (int)para[2];
                IDALLive _DAL = new DALLive();
                _DS = _DAL.GetLiveWishBarcodeList( userID, FIdx, EIdx );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "GetLiveWishBarcodeList Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 我的云购获取心愿详情--支持者列表40422
        /// <summary>
        /// 我的云购获取心愿详情--支持者列表40422
        /// </summary>
        /// <param name="userID">主播ID</param>
        /// <param name="codeID">心愿单条码ID</param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <returns></returns>
        public static DataSet GetLiveWishSupportDetail( params object[] para )
        {
            DataSet _DS = null;
            try
            {
                int userID = (int)para[0];
                int codeID = (int)para[1];
                int FIdx = (int)para[2];
                int EIdx = (int)para[3];
                IDALLive _DAL = new DALLive();
                _DS = _DAL.GetLiveWishSupportDetail( userID, codeID, FIdx, EIdx );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "GetLiveWishSupportDetail Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 直播举报40423
        /// <summary>
        /// 直播举报40423
        /// </summary>
        /// <param name="userID">举报人</param>
        /// <param name="mantID">被举报人</param>
        /// <param name="mantRole">被举报人角色</param>
        /// <param name="liveID">举报时所在的直播id</param>
        /// <param name="reportType">举报类型</param>
        /// <returns></returns>
        public static int AddLiveReport( params object[] para )
        {
            int _Result = 0;
            try
            {
                int userID = (int)para[0];
                int mantID = (int)para[1];
                int mantRole = (int)para[2];
                int liveID = (int)para[3];
                int reportType = (int)para[4];
                int sourceType = (int)para[5];
                IDALLive _DAL = new DALLive();
                _Result = _DAL.AddLiveReport( userID, mantID, mantRole, liveID, reportType, sourceType );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "AddLiveReport Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion
        #region 判断主播是否通过实名认证,返回主播信息40424
        /// <summary>
        /// 判断主播是否通过实名认证,返回主播信息40424
        /// </summary>
        /// <param name="userID">主播ID</param>
        /// <returns></returns>
        public static DataSet GetLiveAnchorDetail( params object[] para )
        {
            DataSet _DS = null;
            try
            {
                int userID = (int)para[0];
                IDALLive _DAL = new DALLive();
                _DS = _DAL.GetLiveAnchorDetail( userID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "GetLiveAnchorDetail Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 取消心愿单与超时心愿单打赏退款入口40425
        /// <summary>
        /// 取消心愿单与超时心愿单打赏退款入口40425
        /// </summary>
        /// <returns></returns>
        public static DataSet LiveReturnPortal()
        {
            DataSet _DS = null;
            try
            {
                IDALLive _DAL = new DALLive();
                _DS = _DAL.LiveReturnPortal();
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "LiveReturnPortal Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 过期心愿单处理作业40426
        /// <summary>
        /// 过期心愿单处理作业40426
        /// </summary>
        /// <returns></returns>
        public static DataSet LiveOvertimeDeal()
        {
            DataSet _DS = null;
            try
            {
                IDALLive _DAL = new DALLive();
                _DS = _DAL.LiveOvertimeDeal();
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "LiveOvertimeDeal Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 更新心愿寄语40428
        /// <summary>
        /// 更新心愿寄语40428
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="codeID"></param>
        /// <param name="sendWord"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        public static int UpdateLivesendWord( params object[] para )
        {
            int _Result = 0;
            try
            {
                int userID = (int)para[0];
                int codeID = (int)para[1];
                string sendWord = (string)para[2];
                int isCommit = (int)para[3];
                IDALLive _DAL = new DALLive();
                _Result = _DAL.UpdateLivesendWord( userID, codeID, sendWord, isCommit );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "UpdateLivesendWord Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion
        #region 根据会员ID获取实名审批信息40429
        /// <summary>
        /// 根据会员ID获取实名审批信息40429
        /// </summary>
        /// <param name="userID">主播ID</param>
        /// <returns></returns>
        public static DataSet GetLiveAuthByUserID( params object[] para )
        {
            DataSet _DS = null;
            try
            {
                int userID = (int)para[0];
                IDALLive _DAL = new DALLive();
                _DS = _DAL.GetLiveAuthByUserID( userID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "GetLiveAuthByUserID Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 心愿单详情40430
        /// <summary>
        /// 心愿单详情40430
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="codeID"></param>
        /// <returns></returns>
        public static DataSet GetLiveWishBarCodeDetail( params object[] para )
        {
            DataSet _DS = null;
            try
            {
                int userID = (int)para[0];
                int codeID = (int)para[1];
                IDALLive _DAL = new DALLive();
                _DS = _DAL.GetLiveWishBarCodeDetail( userID, codeID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "GetLiveWishBarCodeDetail Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region 修改直播间观众人数40431
        /// <summary>
        /// 修改直播间观众人数40431
        /// </summary>
        /// <param name="liveID"></param>
        /// <param name="viewerNum"></param>
        /// <returns></returns>
        public static int UpdateLiveViewerNum( params object[] para )
        {
            int _Result = 0;
            try
            {
                int liveID = (int)para[0];
                int viewerNum = (int)para[1];
             
                IDALLive _DAL = new DALLive();
                _Result = _DAL.UpdateLiveViewerNum( liveID, viewerNum );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "UpdateLiveViewerNum Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion
    }
}
