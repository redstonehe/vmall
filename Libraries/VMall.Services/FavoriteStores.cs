﻿using System;
using System.Data;

using VMall.Core;

namespace VMall.Services
{
    /// <summary>
    /// 店铺收藏夹操作管理类
    /// </summary>
    public partial class FavoriteStores
    {
        /// <summary>
        /// 将店铺添加到收藏夹
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="storeId">店铺id</param>
        /// <param name="addTime">收藏时间</param>
        /// <returns></returns>
        public static bool AddStoreToFavorite(int uid, int storeId, DateTime addTime)
        {
            return VMall.Data.FavoriteStores.AddStoreToFavorite(uid, storeId, addTime);
        }

        /// <summary>
        /// 删除收藏夹的店铺
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="storeId">店铺id</param>
        /// <returns></returns>
        public static bool DeleteFavoriteStoreByUidAndStoreId(int uid, int storeId)
        {
            return VMall.Data.FavoriteStores.DeleteFavoriteStoreByUidAndStoreId(uid, storeId);
        }

        /// <summary>
        /// 店铺是否已经收藏
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="storeId">店铺id</param>
        /// <returns></returns>
        public static bool IsExistFavoriteStore(int uid, int storeId)
        {
            return VMall.Data.FavoriteStores.IsExistFavoriteStore(uid, storeId);
        }

        /// <summary>
        /// 获得收藏夹店铺列表
        /// </summary>
        /// <param name="pageSize">每页数</param>
        /// <param name="pageNumber">当前页数</param>
        /// <param name="uid">用户id</param>
        /// <returns></returns>
        public static DataTable GetFavoriteStoreList(int pageSize, int pageNumber, int uid)
        {
            return VMall.Data.FavoriteStores.GetFavoriteStoreList(pageSize, pageNumber, uid);
        }

        /// <summary>
        /// 获得收藏夹店铺数量
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <returns></returns>
        public static int GetFavoriteStoreCount(int uid)
        {
            return VMall.Data.FavoriteStores.GetFavoriteStoreCount(uid);
        }
    }
}
