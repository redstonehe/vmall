﻿using System;

using VMall.Core;

namespace VMall.Services
{
    /// <summary>
    /// 后台配送公司操作管理类
    /// </summary>
    public partial class AdminShipCompanies : ShipCompanies
    {
        /// <summary>
        /// 创建配送公司
        /// </summary>
        public static void CreateShipCompany(ShipCompanyInfo shipCompanyInfo)
        {
            VMall.Data.ShipCompanies.CreateShipCompany(shipCompanyInfo);
        }

        /// <summary>
        /// 更新配送公司
        /// </summary>
        public static void UpdateShipCompany(ShipCompanyInfo shipCompanyInfo)
        {
            VMall.Data.ShipCompanies.UpdateShipCompany(shipCompanyInfo);
            VMall.Core.BMACache.Remove(CacheKeys.MALL_SHIPCOMPANY_INFO + shipCompanyInfo.ShipCoId);
        }

        /// <summary>
        /// 删除配送公司
        /// </summary>
        /// <param name="shipCoId">配送公司id</param>
        public static void DeleteShipCompanyById(int shipCoId)
        {
            VMall.Data.ShipCompanies.DeleteShipCompanyById(shipCoId);
            VMall.Core.BMACache.Remove(CacheKeys.MALL_SHIPCOMPANY_INFO + shipCoId);
        }

        /// <summary>
        /// 根据配送公司名称得到配送公司id
        /// </summary>
        /// <param name="shipCoName">配送公司名称</param>
        /// <returns></returns>
        public static int GetShipCoIdByName(string shipCoName)
        {
            if (string.IsNullOrWhiteSpace(shipCoName))
                return 0;
            return VMall.Data.ShipCompanies.GetShipCoIdByName(shipCoName);
        }
    }
}
