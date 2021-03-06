﻿using System;
using System.Data;

namespace wcfNSYGShop
{
    public interface IDALLive
    {
        #region 实名认证申请通过第三方API40402
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
        int AddRealNameAuth( int userID, string mobile, string realName, int sex, string ethnicity, string birth, string address, string idNumber, string authority, string fvalidity, string uploadPic );

        #endregion
        #region 第三方认证日志40403
        /// <summary>
        /// 第三方认证日志40403
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="executant">操作人id</param>
        /// <param name="logType">日志类型: 0 调用第三方API认证 1 第三方API认证失败 2 会员上传资料等待审批 3 审批成功 4 审批失败 5 重新提交(失败后)</param>
        /// <param name="logDetail">日志详情</param>
        /// <returns></returns>
        int AddAuthLog( int userID, int executant, int logType, string logDetail );

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
        int CheckAuthApi( int userID, string idNumber );

        #endregion
        #region 开始直播，直播入口40405
        /// <summary>
        /// 开始直播，直播入口40405
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="title">直播主题</param>
        /// <param name="cover">直播封面</param>
        /// <returns></returns>
        DataSet AddLiveVideo( int userID, string title, string cover );

        #endregion
        #region 获取举报类型列表40406
        /// <summary>
        /// 获取举报类型列表40506
        /// </summary>
        /// <returns></returns>
        DataSet GetLiveReportList();

        #endregion
        #region 结束直播40407
        /// <summary>
        /// 结束直播40507
        /// </summary>
        /// <param name="liveID">直播ID</param>
        /// <param name="viewerNum">观众人数</param>
        /// <returns></returns>
        DataSet EndLiveVideo( int liveID, int viewerNum );

        #endregion
        #region 通过主播的userId 得出直播的id40408
        /// <summary>
        /// 通过主播的userId 得出直播的id40508
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        DataSet GetLiveIDByUserID( int userID );

        #endregion
        #region 修改直播间直播标题40409
        /// <summary>
        /// 修改直播间直播标题40409
        /// </summary>
        /// <param name="liveID">直播ID</param>
        /// <param name="title">标题</param>
        /// <returns></returns>
        int UpdateLiveVideoTitle( int liveID, string title );

        #endregion
        #region 直播开播页面返回观众信息和打赏额40410
        /// <summary>
        /// 直播开播页面返回观众信息和打赏额40410
        /// </summary>
        /// <param name="i_supportuserid">用户ID观众ID</param>
        /// <param name="userID">主播ID</param>
        /// <returns></returns>
        DataSet GetLiveViewUserList( int supUserID, int userID );

        #endregion
        #region 获取个人名片40411
        /// <summary>
        /// 获取个人名片40411
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="role">角色 1.观众 2.主播</param>
        /// <returns></returns>
        DataSet GetLivePersonCard( int userID, int role );

        #endregion
        #region 更新视频回放地址40412
        /// <summary>
        /// 更新视频回放地址40412
        /// </summary>
        /// <param name="liveID"></param>
        /// <param name="replayUrl">回放地址</param>
        /// <returns></returns>
        int UpdateLiveReplayURL( int liveID, string replayUrl );

        #endregion
      #region 根据直播ID获取直播信息40413
        /// <summary>
        /// 根据直播ID获取直播信息40413
        /// </summary>
        /// <param name="liveID">直播ID</param>
        /// <returns></returns>
        DataSet GetlivevideoByID( int liveID );

        #endregion
        #region 更新视频回放次数40414
        /// <summary>
        /// 更新视频回放次数40414
        /// </summary>
        /// <param name="liveID">直播ID</param>
        /// <param name="replayCnt">回放次数</param>
        /// <returns></returns>
        int UpdateLiveReplayCnt( int liveID, int replayCnt );

        #endregion
        #region 获取心愿单商品列表40415
        /// <summary>
        /// 获取心愿单商品列表40415
        /// </summary>
        /// <param name="FIdx">分页开始索引</param>
        /// <param name="EIdx">分页结束索引</param>
        /// <returns></returns>
        DataSet GetLiveWishGoodsList( int FIdx, int EIdx );

        #endregion
        #region 获取直播间列表40416
        /// <summary>
        /// 获取直播间列表40416
        /// </summary>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="sex">性别 0 未设置,1 女,2 男,3 保密,全部传Null</param>
        /// <param name="orderType">排列顺序 1时间(最新) 2观众人数(热门)</param>
        /// <returns></returns>
        DataSet GetLiveVideoList( int FIdx, int EIdx, int sex, int orderType );

        #endregion
        #region 获取主播正在进行的心愿单40417
        /// <summary>
        /// 获取主播正在进行的心愿单40417
        /// </summary>
        /// <param name="userID">主播ID</param>
        /// <returns></returns>
        DataSet GetLiveWishBarcodeDoing( int userID );

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
        int AddLiveWishBarcode( int userID, int wishGoodsID, string sendWord, int goodsID );

        #endregion

        #region 主播开播中取消心愿40419
        /// <summary>
        /// 主播开播中取消心愿40419
        /// </summary>
        /// <param name="userID">主播ID</param>
        /// <param name="codeID">心愿条码ID</param>
        /// <returns></returns>
        int UpdateWishBarcodeStatus( int userID, int codeID );

        #endregion
        #region 主播开播中判断取消心愿重置次数40420
        /// <summary>
        /// 主播开播中判断取消心愿重置次数40420
        /// </summary>
        /// <param name="userID">主播ID</param>
        /// <returns></returns>
        int CheckWishBarcodeStatusCnt( int userID );

        #endregion
        #region 我的云购获取心愿单列表40421
        /// <summary>
        /// 我的云购获取心愿单列表40421
        /// </summary>
        /// <param name="userID">主播ID</param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <returns></returns>
        DataSet GetLiveWishBarcodeList( int userID, int FIdx, int EIdx );

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
        DataSet GetLiveWishSupportDetail( int userID, int codeID, int FIdx, int EIdx );

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
        /// <param name="reportType">举报生成来源 1系统生成（阿里云有个鉴黄的接口） 2人工举报</param>
        /// <returns></returns>
        int AddLiveReport( int userID, int mantID, int mantRole, int liveID, int reportType, int sourceType );

        #endregion
        #region 判断主播是否通过实名认证,返回主播信息40424
        /// <summary>
        /// 判断主播是否通过实名认证,返回主播信息40424
        /// </summary>
        /// <param name="userID">主播ID</param>
        /// <returns></returns>
        DataSet GetLiveAnchorDetail( int userID );

        #endregion

        #region 取消心愿单与超时心愿单打赏退款入口40425
        /// <summary>
        /// 取消心愿单与超时心愿单打赏退款入口40425
        /// </summary>
        /// <returns></returns>
        DataSet LiveReturnPortal();

        #endregion
        #region 过期心愿单处理作业40426
        /// <summary>
        /// 过期心愿单处理作业40426
        /// </summary>
        /// <returns></returns>
        DataSet LiveOvertimeDeal();

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
        int UpdateLivesendWord( int userID, int codeID, string sendWord, int isCommit );

        #endregion

        #region 根据会员ID获取实名审批信息40429
        /// <summary>
        /// 根据会员ID获取实名审批信息40429
        /// </summary>
        /// <param name="userID">主播ID</param>
        /// <returns></returns>
        DataSet GetLiveAuthByUserID( int userID );

        #endregion
        #region 心愿单详情40430
        /// <summary>
        /// 心愿单详情40430
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="codeID"></param>
        /// <returns></returns>
        DataSet GetLiveWishBarCodeDetail( int userID, int codeID );

        #endregion
        #region 修改直播间观众人数40431
        /// <summary>
        /// 修改直播间观众人数40431
        /// </summary>
        /// <param name="liveID"></param>
        /// <param name="viewerNum"></param>
        /// <returns></returns>
        int UpdateLiveViewerNum( int liveID, int viewerNum );

        #endregion
    }
}
