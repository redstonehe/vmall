﻿using System;
using System.Data;
using System.Collections.Generic;

using VMall.Core;

namespace VMall.Services
{
    /// <summary>
    /// 后台促销活动操作管理类
    /// </summary>
    public partial class AdminPromotions : Promotions
    {
        /// <summary>
        /// 后台获得单品促销活动
        /// </summary>
        /// <param name="pmId">促销活动id</param>
        /// <returns></returns>
        public static SinglePromotionInfo AdminGetSinglePromotionById(int pmId)
        {
            if (pmId < 1) return null;
            return VMall.Data.Promotions.AdminGetSinglePromotionById(pmId);
        }

        /// <summary>
        /// 创建单品促销活动
        /// </summary>
        public static void CreateSinglePromotion(SinglePromotionInfo singlePromotionInfo)
        {
            VMall.Data.Promotions.CreateSinglePromotion(singlePromotionInfo);
        }

        /// <summary>
        /// 更新单品促销活动
        /// </summary>
        public static void UpdateSinglePromotion(SinglePromotionInfo singlePromotionInfo)
        {
            VMall.Data.Promotions.UpdateSinglePromotion(singlePromotionInfo);
        }

        /// <summary>
        /// 删除单品促销活动
        /// </summary>
        /// <param name="pmIdList">促销活动id</param>
        public static void DeleteSinglePromotionById(int[] pmIdList)
        {
            if (pmIdList != null && pmIdList.Length > 0)
                VMall.Data.Promotions.DeleteSinglePromotionById(CommonHelper.IntArrayToString(pmIdList));
        }

        /// <summary>
        /// 后台获得单品促销活动列表
        /// </summary>
        /// <param name="pageSize">每页数</param>
        /// <param name="pageNumber">当前页数</param>
        /// <param name="condition">条件</param>
        /// <param name="sort">排序</param>
        /// <returns></returns>
        public static DataTable AdminGetSinglePromotionList(int pageSize, int pageNumber, string condition, string sort)
        {
            return VMall.Data.Promotions.AdminGetSinglePromotionList(pageSize, pageNumber, condition, sort);
        }

        /// <summary>
        /// 后台获得单品促销活动列表搜索条件
        /// </summary>
        /// <param name="storeId">店铺id</param>
        /// <param name="pid">商品id</param>
        /// <param name="promotionName">活动名称</param>
        /// <param name="promotionTime">活动时间</param>
        /// <returns></returns>
        public static string AdminGetSinglePromotionListCondition(int storeId, int pid, string promotionName, string promotionTime)
        {
            return VMall.Data.Promotions.AdminGetSinglePromotionListCondition(storeId, pid, promotionName, promotionTime);
        }

        /// <summary>
        /// 后台获得单品促销活动排序
        /// </summary>
        /// <param name="sortColumn">排序列</param>
        /// <param name="sortDirection">排序方向</param>
        /// <returns></returns>
        public static string AdminGetSinglePromotionListSort(string sortColumn, string sortDirection)
        {
            return VMall.Data.Promotions.AdminGetSinglePromotionListSort(sortColumn, sortDirection);
        }

        /// <summary>
        /// 后台获得单品促销活动数量
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int AdminGetSinglePromotionCount(string condition)
        {
            return VMall.Data.Promotions.AdminGetSinglePromotionCount(condition);
        }

        /// <summary>
        /// 后台判断商品在指定时间段内是否已经存在单品促销活动
        /// </summary>
        /// <param name="pid">商品id</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public static int AdminIsExistSinglePromotion(int pid, DateTime startTime, DateTime endTime)
        {
            return VMall.Data.Promotions.AdminIsExistSinglePromotion(pid, startTime, endTime);
        }

        /// <summary>
        /// 获得店铺id列表
        /// </summary>
        /// <param name="pmIdList">单品促销活动id列表</param>
        /// <returns></returns>
        public static DataTable GetStoreIdListBySinglePmId(int[] pmIdList)
        {
            if (pmIdList != null && pmIdList.Length > 0)
                return VMall.Data.Promotions.GetStoreIdListBySinglePmId(CommonHelper.IntArrayToString(pmIdList));
            return new DataTable();
        }

        /// <summary>
        /// 判断促销活动是否为同一指定店铺
        /// </summary>
        /// <param name="storeId">店铺id</param>
        /// <param name="pmIdList">促销活动id列表</param>
        /// <returns></returns>
        public static bool IsStorePromotionBySinglePmId(int storeId, int[] pmIdList)
        {
            DataTable storeIdList = GetStoreIdListBySinglePmId(pmIdList);
            if (storeIdList.Rows.Count != 1 || storeId != TypeHelper.ObjectToInt(storeIdList.Rows[0][0]))
                return false;
            return true;
        }

        /// <summary>
        /// 获得单品促销活动商品id列表
        /// </summary>
        /// <param name="pmIdList">促销活动id列表</param>
        /// <returns></returns>
        public static List<string> GetSinglePromotionPidList(string pmIdList)
        {
            return VMall.Data.Promotions.GetSinglePromotionPidList(pmIdList);
        }






        /// <summary>
        /// 后台获得买送促销活动
        /// </summary>
        /// <param name="pmId">促销活动id</param>
        /// <returns></returns>
        public static BuySendPromotionInfo AdminGetBuySendPromotionById(int pmId)
        {
            if (pmId < 1) return null;
            return VMall.Data.Promotions.AdminGetBuySendPromotionById(pmId);
        }

        /// <summary>
        /// 创建买送促销活动
        /// </summary>
        public static void CreateBuySendPromotion(BuySendPromotionInfo buySendPromotionInfo)
        {
            VMall.Data.Promotions.CreateBuySendPromotion(buySendPromotionInfo);
        }

        /// <summary>
        /// 更新买送促销活动
        /// </summary>
        public static void UpdateBuySendPromotion(BuySendPromotionInfo buySendPromotionInfo)
        {
            VMall.Data.Promotions.UpdateBuySendPromotion(buySendPromotionInfo);
        }

        /// <summary>
        /// 删除买送促销活动
        /// </summary>
        /// <param name="pmIdList">活动id</param>
        public static void DeleteBuySendPromotionById(int[] pmIdList)
        {
            if (pmIdList != null && pmIdList.Length > 0)
                VMall.Data.Promotions.DeleteBuySendPromotionById(CommonHelper.IntArrayToString(pmIdList));
        }

        /// <summary>
        /// 后台获得买送促销活动列表
        /// </summary>
        /// <param name="pageSize">每页数</param>
        /// <param name="pageNumber">当前页数</param>
        /// <param name="condition">条件</param>
        /// <param name="sort">排序</param>
        /// <returns></returns>
        public static DataTable AdminGetBuySendPromotionList(int pageSize, int pageNumber, string condition, string sort)
        {
            return VMall.Data.Promotions.AdminGetBuySendPromotionList(pageSize, pageNumber, condition, sort);
        }

        /// <summary>
        /// 后台获得买送促销活动列表条件
        /// </summary>
        /// <param name="storeId">店铺id</param>
        /// <param name="promotionName">活动名称</param>
        /// <param name="promotionTime">活动时间</param>
        /// <returns></returns>
        public static string AdminGetBuySendPromotionListCondition(int storeId, string promotionName, string promotionTime)
        {
            return VMall.Data.Promotions.AdminGetBuySendPromotionListCondition(storeId, promotionName, promotionTime);
        }

        /// <summary>
        /// 后台获得买送促销活动排序
        /// </summary>
        /// <param name="sortColumn">排序列</param>
        /// <param name="sortDirection">排序方向</param>
        /// <returns></returns>
        public static string AdminGetBuySendPromotionListSort(string sortColumn, string sortDirection)
        {
            return VMall.Data.Promotions.AdminGetBuySendPromotionListSort(sortColumn, sortDirection);
        }

        /// <summary>
        /// 后台获得买送促销活动数量
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int AdminGetBuySendPromotionCount(string condition)
        {
            return VMall.Data.Promotions.AdminGetBuySendPromotionCount(condition);
        }

        /// <summary>
        /// 获得店铺id列表
        /// </summary>
        /// <param name="pmIdList">买送促销活动id列表</param>
        /// <returns></returns>
        public static DataTable GetStoreIdListByBuySendPmId(int[] pmIdList)
        {
            if (pmIdList != null && pmIdList.Length > 0)
                return VMall.Data.Promotions.GetStoreIdListByBuySendPmId(CommonHelper.IntArrayToString(pmIdList));
            return new DataTable();
        }

        /// <summary>
        /// 判断促销活动是否为同一指定店铺
        /// </summary>
        /// <param name="storeId">店铺id</param>
        /// <param name="pmIdList">促销活动id列表</param>
        /// <returns></returns>
        public static bool IsStorePromotionByBuySendPmId(int storeId, int[] pmIdList)
        {
            DataTable storeIdList = GetStoreIdListByBuySendPmId(pmIdList);
            if (storeIdList.Rows.Count != 1 || storeId != TypeHelper.ObjectToInt(storeIdList.Rows[0][0]))
                return false;
            return true;
        }




        /// <summary>
        /// 添加买送商品
        /// </summary>
        /// <param name="pmId">促销活动id</param>
        /// <param name="pid">商品id</param>
        public static void AddBuySendProduct(int pmId, int pid)
        {
            if (pmId > 0 && pid > 0)
                VMall.Data.Promotions.AddBuySendProduct(pmId, pid);
        }

        /// <summary>
        /// 删除买送商品
        /// </summary>
        /// <param name="recordIdList">记录id列表</param>
        /// <returns></returns>
        public static bool DeleteBuySendProductByRecordId(int[] recordIdList)
        {
            if (recordIdList != null && recordIdList.Length > 0)
                return VMall.Data.Promotions.DeleteBuySendProductByRecordId(CommonHelper.IntArrayToString(recordIdList));
            return false;
        }

        /// <summary>
        /// 后台获得买送商品列表
        /// </summary>
        /// <param name="pageSize">每页数</param>
        /// <param name="pageNumber">当前页数</param>
        /// <param name="pmId">活动id</param>
        /// <param name="pid">商品id</param>
        /// <returns></returns>
        public static DataTable AdminGetBuySendProductList(int pageSize, int pageNumber, int pmId, int pid)
        {
            return VMall.Data.Promotions.AdminGetBuySendProductList(pageSize, pageNumber, pmId, pid);
        }

        /// <summary>
        /// 后台获得买送商品数量
        /// </summary>
        /// <param name="pmId">活动id</param>
        /// <param name="pid">商品id</param>
        /// <returns></returns>
        public static int AdminGetBuySendProductCount(int pmId, int pid)
        {
            if (pmId < 1) return 0;
            return VMall.Data.Promotions.AdminGetBuySendProductCount(pmId, pid);
        }

        /// <summary>
        /// 获得店铺id列表
        /// </summary>
        /// <param name="recordIdList">买送商品记录id列表</param>
        /// <returns></returns>
        public static DataTable GetStoreIdListByBuySendProductRecordId(int[] recordIdList)
        {
            if (recordIdList != null && recordIdList.Length > 0)
                return VMall.Data.Promotions.GetStoreIdListByBuySendProductRecordId(CommonHelper.IntArrayToString(recordIdList));
            return new DataTable();
        }

        /// <summary>
        /// 判断买送促销商品是否为同一指定店铺
        /// </summary>
        /// <param name="storeId">店铺id</param>
        /// <param name="recordIdList">买送商品记录id列表</param>
        /// <returns></returns>
        public static bool IsStoreBuySendProductByBuySendProductRecordId(int storeId, int[] recordIdList)
        {
            DataTable storeIdList = GetStoreIdListByBuySendProductRecordId(recordIdList);
            if (storeIdList.Rows.Count != 1 || storeId != TypeHelper.ObjectToInt(storeIdList.Rows[0][0]))
                return false;
            return true;
        }

        /// <summary>
        /// 获得买送商品id列表
        /// </summary>
        /// <param name="recordIdList">记录id列表</param>
        /// <returns></returns>
        public static List<string> GetBuySendPidList(string recordIdList)
        {
            return VMall.Data.Promotions.GetBuySendPidList(recordIdList);
        }







        /// <summary>
        /// 后台获得赠品促销活动
        /// </summary>
        /// <param name="pmId">活动id</param>
        /// <returns></returns>
        public static GiftPromotionInfo AdminGetGiftPromotionById(int pmId)
        {
            if (pmId < 1) return null;
            return VMall.Data.Promotions.AdminGetGiftPromotionById(pmId);
        }

        /// <summary>
        /// 创建赠品促销活动
        /// </summary>
        public static void CreateGiftPromotion(GiftPromotionInfo giftPromotionInfo)
        {
            VMall.Data.Promotions.CreateGiftPromotion(giftPromotionInfo);
        }

        /// <summary>
        /// 更新赠品促销活动
        /// </summary>
        public static void UpdateGiftPromotion(GiftPromotionInfo giftPromotionInfo)
        {
            VMall.Data.Promotions.UpdateGiftPromotion(giftPromotionInfo);
        }

        /// <summary>
        /// 删除赠品促销活动
        /// </summary>
        /// <param name="pmIdList">活动id</param>
        public static void DeleteGiftPromotionById(int[] pmIdList)
        {
            if (pmIdList != null && pmIdList.Length > 0)
                VMall.Data.Promotions.DeleteGiftPromotionById(CommonHelper.IntArrayToString(pmIdList));
        }

        /// <summary>
        /// 后台获得赠品促销活动列表
        /// </summary>
        /// <param name="pageSize">每页数</param>
        /// <param name="pageNumber">当前页数</param>
        /// <param name="condition">条件</param>
        /// <param name="sort">排序</param>
        /// <returns></returns>
        public static DataTable AdminGetGiftPromotionList(int pageSize, int pageNumber, string condition, string sort)
        {
            return VMall.Data.Promotions.AdminGetGiftPromotionList(pageSize, pageNumber, condition, sort);
        }

        /// <summary>
        /// 后台获得赠品促销活动列表条件
        /// </summary>
        /// <param name="storeId">店铺id</param>
        /// <param name="pid">商品id</param>
        /// <param name="promotionName">活动名称</param>
        /// <param name="promotionTime">活动时间</param>
        /// <returns></returns>
        public static string AdminGetGiftPromotionListCondition(int storeId, int pid, string promotionName, string promotionTime)
        {
            return VMall.Data.Promotions.AdminGetGiftPromotionListCondition(storeId, pid, promotionName, promotionTime);
        }

        /// <summary>
        /// 后台获得赠品促销活动列表排序
        /// </summary>
        /// <param name="sortColumn">排序列</param>
        /// <param name="sortDirection">排序方向</param>
        /// <returns></returns>
        public static string AdminGetGiftPromotionListSort(string sortColumn, string sortDirection)
        {
            return VMall.Data.Promotions.AdminGetGiftPromotionListSort(sortColumn, sortDirection);
        }

        /// <summary>
        /// 后台获得赠品促销活动数量
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int AdminGetGiftPromotionCount(string condition)
        {
            return VMall.Data.Promotions.AdminGetGiftPromotionCount(condition);
        }

        /// <summary>
        /// 后台判断商品在指定时间段内是否已经存在赠品促销活动
        /// </summary>
        /// <param name="pid">商品id</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public static int AdminIsExistGiftPromotion(int pid, DateTime startTime, DateTime endTime)
        {
            return VMall.Data.Promotions.AdminIsExistGiftPromotion(pid, startTime, endTime);
        }

        /// <summary>
        /// 获得店铺id列表
        /// </summary>
        /// <param name="pmIdList">赠品促销活动id列表</param>
        /// <returns></returns>
        public static DataTable GetStoreIdListByGiftPmId(int[] pmIdList)
        {
            if (pmIdList != null && pmIdList.Length > 0)
                return VMall.Data.Promotions.GetStoreIdListByGiftPmId(CommonHelper.IntArrayToString(pmIdList));
            return new DataTable();
        }

        /// <summary>
        /// 判断促销活动是否为同一指定店铺
        /// </summary>
        /// <param name="storeId">店铺id</param>
        /// <param name="pmIdList">促销活动id列表</param>
        /// <returns></returns>
        public static bool IsStorePromotionByGiftPmId(int storeId, int[] pmIdList)
        {
            DataTable storeIdList = GetStoreIdListByGiftPmId(pmIdList);
            if (storeIdList.Rows.Count != 1 || storeId != TypeHelper.ObjectToInt(storeIdList.Rows[0][0]))
                return false;
            return true;
        }

        /// <summary>
        /// 获得赠品促销活动商品id列表
        /// </summary>
        /// <param name="pmIdList">促销活动id列表</param>
        /// <returns></returns>
        public static List<string> GetGiftPromotionPidList(string pmIdList)
        {
            return VMall.Data.Promotions.GetGiftPromotionPidList(pmIdList);
        }






        /// <summary>
        /// 添加赠品
        /// </summary>
        /// <param name="pmId">促销活动id</param>
        /// <param name="giftId">赠品id</param>
        /// <param name="number">数量</param>
        /// <param name="pid">商品id</param>
        public static void AddGift(int pmId, int giftId, int number, int pid)
        {
            VMall.Data.Promotions.AddGift(pmId, giftId, number, pid);
        }

        /// <summary>
        /// 删除赠品
        /// </summary>
        /// <param name="pmId">促销活动id</param>
        /// <param name="giftId">赠品id</param>
        /// <returns></returns>
        public static bool DeleteGiftByPmIdAndGiftId(int pmId, int giftId)
        {
            return VMall.Data.Promotions.DeleteGiftByPmIdAndGiftId(pmId, giftId);
        }

        /// <summary>
        /// 更新赠品的数量
        /// </summary>
        /// <param name="pmId">促销活动id</param>
        /// <param name="giftId">赠品id</param>
        /// <param name="number">数量</param>
        /// <returns></returns>
        public static bool UpdateGiftNumber(int pmId, int giftId, int number)
        {
            if (number > 0)
                return VMall.Data.Promotions.UpdateGiftNumber(pmId, giftId, number);
            return false;
        }

        /// <summary>
        /// 后台获得扩展赠品列表
        /// </summary>
        /// <param name="pmId">促销活动id</param>
        /// <returns></returns>
        public static List<ExtGiftInfo> AdminGetExtGiftList(int pmId)
        {
            return VMall.Data.Promotions.AdminGetExtGiftList(pmId);
        }







        /// <summary>
        /// 后台获得套装促销活动
        /// </summary>
        /// <param name="pmId">促销活动id</param>
        /// <returns></returns>
        public static SuitPromotionInfo AdminGetSuitPromotionById(int pmId)
        {
            if (pmId < 1) return null;
            return VMall.Data.Promotions.AdminGetSuitPromotionById(pmId);
        }

        /// <summary>
        /// 创建套装促销活动
        /// </summary>
        public static int CreateSuitPromotion(SuitPromotionInfo suitPromotionInfo)
        {
            return VMall.Data.Promotions.CreateSuitPromotion(suitPromotionInfo);
        }

        /// <summary>
        /// 更新套装促销活动
        /// </summary>
        public static void UpdateSuitPromotion(SuitPromotionInfo suitPromotionInfo)
        {
            VMall.Data.Promotions.UpdateSuitPromotion(suitPromotionInfo);
        }

        /// <summary>
        /// 删除套装促销活动
        /// </summary>
        /// <param name="pmIdList">活动id</param>
        public static void DeleteSuitPromotionById(int[] pmIdList)
        {
            if (pmIdList != null && pmIdList.Length > 0)
                VMall.Data.Promotions.DeleteSuitPromotionById(CommonHelper.IntArrayToString(pmIdList));
        }

        /// <summary>
        /// 后台获得套装促销活动列表
        /// </summary>
        /// <param name="pageSize">每页数</param>
        /// <param name="pageNumber">当前页数</param>
        /// <param name="condition">条件</param>
        /// <param name="sort">排序</param>
        /// <returns></returns>
        public static DataTable AdminGetSuitPromotionList(int pageSize, int pageNumber, string condition, string sort)
        {
            return VMall.Data.Promotions.AdminGetSuitPromotionList(pageSize, pageNumber, condition, sort);
        }

        /// <summary>
        /// 后台获得套装促销活动列表条件
        /// </summary>
        /// <param name="storeId">店铺id</param>
        /// <param name="pid">商品id</param>
        /// <param name="promotionName">活动名称</param>
        /// <param name="promotionTime">活动时间</param>
        /// <returns></returns>
        public static string AdminGetSuitPromotionListCondition(int storeId, int pid, string promotionName, string promotionTime)
        {
            return VMall.Data.Promotions.AdminGetSuitPromotionListCondition(storeId, pid, promotionName, promotionTime);
        }

        /// <summary>
        /// 后台获得套装促销活动列表排序
        /// </summary>
        /// <param name="sortColumn">排序列</param>
        /// <param name="sortDirection">排序方向</param>
        /// <returns></returns>
        public static string AdminGetSuitPromotionListSort(string sortColumn, string sortDirection)
        {
            return VMall.Data.Promotions.AdminGetSuitPromotionListSort(sortColumn, sortDirection);
        }

        /// <summary>
        /// 后台获得套装促销活动数量
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int AdminGetSuitPromotionCount(string condition)
        {
            return VMall.Data.Promotions.AdminGetSuitPromotionCount(condition);
        }

        /// <summary>
        /// 获得店铺id列表
        /// </summary>
        /// <param name="pmIdList">套装促销活动id列表</param>
        /// <returns></returns>
        public static DataTable GetStoreIdListBySuitPmId(int[] pmIdList)
        {
            if (pmIdList != null && pmIdList.Length > 0)
                return VMall.Data.Promotions.GetStoreIdListBySuitPmId(CommonHelper.IntArrayToString(pmIdList));
            return new DataTable();
        }

        /// <summary>
        /// 判断促销活动是否为同一指定店铺
        /// </summary>
        /// <param name="storeId">店铺id</param>
        /// <param name="pmIdList">促销活动id列表</param>
        /// <returns></returns>
        public static bool IsStorePromotionBySuitPmId(int storeId, int[] pmIdList)
        {
            DataTable storeIdList = GetStoreIdListBySuitPmId(pmIdList);
            if (storeIdList.Rows.Count != 1 || storeId != TypeHelper.ObjectToInt(storeIdList.Rows[0][0]))
                return false;
            return true;
        }





        /// <summary>
        /// 添加套装商品
        /// </summary>
        public static void AddSuitProduct(int pmId, int pid, decimal discount, int number)
        {
            if (pmId > 0 && pid > 0 && discount > -1 && number > 0)
                VMall.Data.Promotions.AddSuitProduct(pmId, pid, discount, number);
        }

        /// <summary>
        /// 删除套装商品
        /// </summary>
        /// <param name="pmId">促销活动id</param>
        /// <param name="pid">商品id</param>
        /// <returns></returns>
        public static bool DeleteSuitProductByPmIdAndPid(int pmId, int pid)
        {
            return VMall.Data.Promotions.DeleteSuitProductByPmIdAndPid(pmId, pid);
        }

        /// <summary>
        /// 修改套装商品数量
        /// </summary>
        /// <param name="pmId">促销活动id</param>
        /// <param name="pid">商品id</param>
        /// <param name="number">数量</param>
        /// <returns></returns>
        public static bool UpdateSuitProductNumber(int pmId, int pid, int number)
        {
            if (number > 0)
                return VMall.Data.Promotions.UpdateSuitProductNumber(pmId, pid, number);
            return false;
        }

        /// <summary>
        /// 修改套装商品折扣
        /// </summary>
        /// <param name="pmId">促销活动id</param>
        /// <param name="pid">商品id</param>
        /// <param name="discount">折扣</param>
        /// <returns></returns>
        public static bool UpdateSuitProductDiscount(int pmId, int pid, decimal discount)
        {
            if (discount > 0)
                return VMall.Data.Promotions.UpdateSuitProductDiscount(pmId, pid, discount);
            return false;
        }

        /// <summary>
        /// 后台获得扩展套装商品列表
        /// </summary>
        /// <param name="pmId">促销活动id</param>
        /// <returns></returns>
        public static List<ExtSuitProductInfo> AdminGetExtSuitProductList(int pmId)
        {
            return VMall.Data.Promotions.AdminGetExtSuitProductList(pmId);
        }

        /// <summary>
        /// 后台获得全部扩展套装商品列表
        /// </summary>
        /// <param name="pmIdList">促销活动id列表</param>
        /// <returns></returns>
        public static List<ExtSuitProductInfo> AdminGetAllExtSuitProductList(string pmIdList)
        {
            return VMall.Data.Promotions.AdminGetAllExtSuitProductList(pmIdList);
        }





        /// <summary>
        /// 后台获得满赠促销活动
        /// </summary>
        /// <param name="pmId">活动id</param>
        /// <returns></returns>
        public static FullSendPromotionInfo AdminGetFullSendPromotionById(int pmId)
        {
            if (pmId < 1) return null;
            return VMall.Data.Promotions.AdminGetFullSendPromotionById(pmId);
        }

        /// <summary>
        /// 创建满赠促销活动
        /// </summary>
        public static void CreateFullSendPromotion(FullSendPromotionInfo fullSendPromotionInfo)
        {
            VMall.Data.Promotions.CreateFullSendPromotion(fullSendPromotionInfo);
        }

        /// <summary>
        /// 更新满赠促销活动
        /// </summary>
        public static void UpdateFullSendPromotion(FullSendPromotionInfo fullSendPromotionInfo)
        {
            VMall.Data.Promotions.UpdateFullSendPromotion(fullSendPromotionInfo);
        }

        /// <summary>
        /// 删除满赠促销活动
        /// </summary>
        /// <param name="pmIdList">活动id</param>
        public static void DeleteFullSendPromotionById(int[] pmIdList)
        {
            if (pmIdList != null && pmIdList.Length > 0)
                VMall.Data.Promotions.DeleteFullSendPromotionById(CommonHelper.IntArrayToString(pmIdList));
        }

        /// <summary>
        /// 后台获得满赠促销活动列表
        /// </summary>
        /// <param name="pageSize">每页数</param>
        /// <param name="pageNumber">当前页数</param>
        /// <param name="condition">条件</param>
        /// <param name="sort">排序</param>
        /// <returns></returns>
        public static DataTable AdminGetFullSendPromotionList(int pageSize, int pageNumber, string condition, string sort)
        {
            return VMall.Data.Promotions.AdminGetFullSendPromotionList(pageSize, pageNumber, condition, sort);
        }

        /// <summary>
        /// 后台获得满赠促销活动列表条件
        /// </summary>
        /// <param name="storeId">店铺id</param>
        /// <param name="promotionName">活动名称</param>
        /// <param name="promotionTime">活动时间</param>
        /// <returns></returns>
        public static string AdminGetFullSendPromotionListCondition(int storeId, string promotionName, string promotionTime)
        {
            return VMall.Data.Promotions.AdminGetFullSendPromotionListCondition(storeId, promotionName, promotionTime);
        }

        /// <summary>
        /// 后台获得满赠促销活动排序
        /// </summary>
        /// <param name="sortColumn">排序列</param>
        /// <param name="sortDirection">排序方向</param>
        /// <returns></returns>
        public static string AdminGetFullSendPromotionListSort(string sortColumn, string sortDirection)
        {
            return VMall.Data.Promotions.AdminGetFullSendPromotionListSort(sortColumn, sortDirection);
        }

        /// <summary>
        /// 后台获得满赠促销活动数量
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int AdminGetFullSendPromotionCount(string condition)
        {
            return VMall.Data.Promotions.AdminGetFullSendPromotionCount(condition);
        }

        /// <summary>
        /// 获得店铺id列表
        /// </summary>
        /// <param name="pmIdList">满赠促销活动id列表</param>
        /// <returns></returns>
        public static DataTable GetStoreIdListByFullSendPmId(int[] pmIdList)
        {
            if (pmIdList != null && pmIdList.Length > 0)
                return VMall.Data.Promotions.GetStoreIdListByFullSendPmId(CommonHelper.IntArrayToString(pmIdList));
            return new DataTable();
        }

        /// <summary>
        /// 判断促销活动是否为同一指定店铺
        /// </summary>
        /// <param name="storeId">店铺id</param>
        /// <param name="pmIdList">促销活动id列表</param>
        /// <returns></returns>
        public static bool IsStorePromotionByFullSendPmId(int storeId, int[] pmIdList)
        {
            DataTable storeIdList = GetStoreIdListByFullSendPmId(pmIdList);
            if (storeIdList.Rows.Count != 1 || storeId != TypeHelper.ObjectToInt(storeIdList.Rows[0][0]))
                return false;
            return true;
        }




        /// <summary>
        /// 添加满赠商品
        /// </summary>
        public static void AddFullSendProduct(int pmId, int pid, int type)
        {
            if (pmId > 0 && pid > 0 && (type == 0 || type == 1))
                VMall.Data.Promotions.AddFullSendProduct(pmId, pid, type);
        }

        /// <summary>
        /// 删除满赠商品
        /// </summary>
        /// <param name="recordIdList">记录id</param>
        /// <returns></returns>
        public static bool DeleteFullSendProductByRecordId(int[] recordIdList)
        {
            if (recordIdList != null && recordIdList.Length > 0)
                return VMall.Data.Promotions.DeleteFullSendProductByRecordId(CommonHelper.IntArrayToString(recordIdList));
            return false;
        }

        /// <summary>
        /// 后台获得满赠商品列表
        /// </summary>
        /// <param name="pageSize">每页数</param>
        /// <param name="pageNumber">当前页数</param>
        /// <param name="pmId">活动id</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static DataTable AdminGetFullSendProductList(int pageSize, int pageNumber, int pmId, int type)
        {
            return VMall.Data.Promotions.AdminGetFullSendProductList(pageSize, pageNumber, pmId, type);
        }

        /// <summary>
        /// 后台获得满赠商品数量
        /// </summary>
        /// <param name="pmId">活动id</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static int AdminGetFullSendProductCount(int pmId, int type)
        {
            return VMall.Data.Promotions.AdminGetFullSendProductCount(pmId, type);
        }

        /// <summary>
        /// 获得店铺id列表
        /// </summary>
        /// <param name="recordIdList">满赠商品记录id列表</param>
        /// <returns></returns>
        public static DataTable GetStoreIdListByFullSendProductRecordId(int[] recordIdList)
        {
            if (recordIdList != null && recordIdList.Length > 0)
                return VMall.Data.Promotions.GetStoreIdListByFullSendProductRecordId(CommonHelper.IntArrayToString(recordIdList));
            return new DataTable();
        }

        /// <summary>
        /// 判断满赠促销商品是否为同一指定店铺
        /// </summary>
        /// <param name="storeId">店铺id</param>
        /// <param name="recordIdList">满赠商品记录id列表</param>
        /// <returns></returns>
        public static bool IsStoreFullSendProductByFullSendProductRecordId(int storeId, int[] recordIdList)
        {
            DataTable storeIdList = GetStoreIdListByFullSendProductRecordId(recordIdList);
            if (storeIdList.Rows.Count != 1 || storeId != TypeHelper.ObjectToInt(storeIdList.Rows[0][0]))
                return false;
            return true;
        }

        /// <summary>
        /// 获得满赠商品列表
        /// </summary>
        /// <param name="recordIdList">记录id列表</param>
        /// <returns></returns>
        public static DataTable GetFullSendProductList(string recordIdList)
        {
            return VMall.Data.Promotions.GetFullSendProductList(recordIdList);
        }





        /// <summary>
        /// 后台获得满减促销活动
        /// </summary>
        /// <param name="pmId">活动id</param>
        /// <returns></returns>
        public static FullCutPromotionInfo AdminGetFullCutPromotionById(int pmId)
        {
            if (pmId < 1) return null;
            return VMall.Data.Promotions.AdminGetFullCutPromotionById(pmId);
        }

        /// <summary>
        /// 创建满减促销活动
        /// </summary>
        public static void CreateFullCutPromotion(FullCutPromotionInfo fullCutPromotionInfo)
        {
            VMall.Data.Promotions.CreateFullCutPromotion(fullCutPromotionInfo);
        }

        /// <summary>
        /// 更新满减促销活动
        /// </summary>
        public static void UpdateFullCutPromotion(FullCutPromotionInfo fullCutPromotionInfo)
        {
            VMall.Data.Promotions.UpdateFullCutPromotion(fullCutPromotionInfo);
        }

        /// <summary>
        /// 删除满减促销活动
        /// </summary>
        /// <param name="pmIdList">活动id</param>
        public static void DeleteFullCutPromotionById(int[] pmIdList)
        {
            if (pmIdList != null && pmIdList.Length > 0)
                VMall.Data.Promotions.DeleteFullCutPromotionById(CommonHelper.IntArrayToString(pmIdList));
        }

        /// <summary>
        /// 后台获得满减促销活动列表
        /// </summary>
        /// <param name="pageSize">每页数</param>
        /// <param name="pageNumber">当前页数</param>
        /// <param name="condition">条件</param>
        /// <param name="sort">排序</param>
        /// <returns></returns>
        public static DataTable AdminGetFullCutPromotionList(int pageSize, int pageNumber, string condition, string sort)
        {
            return VMall.Data.Promotions.AdminGetFullCutPromotionList(pageSize, pageNumber, condition, sort);
        }

        /// <summary>
        /// 后台获得满减促销活动列表条件
        /// </summary>
        /// <param name="storeId">店铺id</param>
        /// <param name="promotionName">活动名称</param>
        /// <param name="promotionTime">活动时间</param>
        /// <returns></returns>
        public static string AdminGetFullCutPromotionListCondition(int storeId, string promotionName, string promotionTime)
        {
            return VMall.Data.Promotions.AdminGetFullCutPromotionListCondition(storeId, promotionName, promotionTime);
        }

        /// <summary>
        /// 后台获得满减促销活动列表排序
        /// </summary>
        /// <param name="sortColumn">排序列</param>
        /// <param name="sortDirection">排序方向</param>
        /// <returns></returns>
        public static string AdminGetFullCutPromotionListSort(string sortColumn, string sortDirection)
        {
            return VMall.Data.Promotions.AdminGetFullCutPromotionListSort(sortColumn, sortDirection);
        }

        /// <summary>
        /// 后台获得满减促销活动数量
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int AdminGetFullCutPromotionCount(string condition)
        {
            return VMall.Data.Promotions.AdminGetFullCutPromotionCount(condition);
        }

        /// <summary>
        /// 获得店铺id列表
        /// </summary>
        /// <param name="pmIdList">满减促销活动id列表</param>
        /// <returns></returns>
        public static DataTable GetStoreIdListByFullCutPmId(int[] pmIdList)
        {
            if (pmIdList != null && pmIdList.Length > 0)
                return VMall.Data.Promotions.GetStoreIdListByFullCutPmId(CommonHelper.IntArrayToString(pmIdList));
            return new DataTable();
        }

        /// <summary>
        /// 判断促销活动是否为同一指定店铺
        /// </summary>
        /// <param name="storeId">店铺id</param>
        /// <param name="pmIdList">促销活动id列表</param>
        /// <returns></returns>
        public static bool IsStorePromotionByFullCutPmId(int storeId, int[] pmIdList)
        {
            DataTable storeIdList = GetStoreIdListByFullCutPmId(pmIdList);
            if (storeIdList.Rows.Count != 1 || storeId != TypeHelper.ObjectToInt(storeIdList.Rows[0][0]))
                return false;
            return true;
        }




        /// <summary>
        /// 添加满减商品
        /// </summary>
        public static void AddFullCutProduct(int pmId, int pid)
        {
            if (pmId > 0 && pid > 0)
                VMall.Data.Promotions.AddFullCutProduct(pmId, pid);
        }

        /// <summary>
        /// 删除满减商品
        /// </summary>
        /// <param name="recordIdList">记录id</param>
        /// <returns></returns>
        public static bool DeleteFullCutProductByRecordId(int[] recordIdList)
        {
            if (recordIdList != null && recordIdList.Length > 0)
                return VMall.Data.Promotions.DeleteFullCutProductByRecordId(CommonHelper.IntArrayToString(recordIdList));
            return false;
        }

        /// <summary>
        /// 后台获得满减商品列表
        /// </summary>
        /// <param name="pageSize">每页数</param>
        /// <param name="pageNumber">当前页数</param>
        /// <param name="pmId">活动id</param>
        /// <returns></returns>
        public static DataTable AdminGetFullCutProductList(int pageSize, int pageNumber, int pmId)
        {
            return VMall.Data.Promotions.AdminGetFullCutProductList(pageSize, pageNumber, pmId);
        }

        /// <summary>
        /// 后台获得满减商品数量
        /// </summary>
        /// <param name="pmId">活动id</param>
        /// <returns></returns>
        public static int AdminGetFullCutProductCount(int pmId)
        {
            return VMall.Data.Promotions.AdminGetFullCutProductCount(pmId);
        }

        /// <summary>
        /// 获得店铺id列表
        /// </summary>
        /// <param name="recordIdList">满减商品记录id列表</param>
        /// <returns></returns>
        public static DataTable GetStoreIdListByFullCutProductRecordId(int[] recordIdList)
        {
            if (recordIdList != null && recordIdList.Length > 0)
                return VMall.Data.Promotions.GetStoreIdListByFullCutProductRecordId(CommonHelper.IntArrayToString(recordIdList));
            return new DataTable();
        }

        /// <summary>
        /// 判断满减促销商品是否为同一指定店铺
        /// </summary>
        /// <param name="storeId">店铺id</param>
        /// <param name="recordIdList">满减商品记录id列表</param>
        /// <returns></returns>
        public static bool IsStoreFullCutProductByFullCutProductRecordId(int storeId, int[] recordIdList)
        {
            DataTable storeIdList = GetStoreIdListByFullCutProductRecordId(recordIdList);
            if (storeIdList.Rows.Count != 1 || storeId != TypeHelper.ObjectToInt(storeIdList.Rows[0][0]))
                return false;
            return true;
        }

        /// <summary>
        /// 获得满减商品id列表
        /// </summary>
        /// <param name="recordIdList">记录id列表</param>
        /// <returns></returns>
        public static List<string> GetFullCutPidList(string recordIdList)
        {
            return VMall.Data.Promotions.GetFullCutPidList(recordIdList);
        }
    }
}