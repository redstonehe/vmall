﻿using System;
using System.Collections.Generic;

using VMall.Core;

namespace VMall.Web.Mobile.Models
{
    /// <summary>
    /// 购物车模型类
    /// </summary>
    public class CartModel
    {
        /// <summary>
        /// 商品总数量
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 商品合计
        /// </summary>
        public decimal ProductAmount { get; set; }
        /// <summary>
        /// 满减
        /// </summary>
        public int FullCut { get; set; }
        /// <summary>
        /// 关税
        /// </summary>
        public decimal taxAmount { get; set; }
        /// <summary>
        /// 红包减免
        /// </summary>
        public decimal HongBaoCutAmount { get; set; }
        /// <summary>
        /// PV
        /// </summary>
        public decimal PVAmount { get; set; }
        /// <summary>
        /// 订单合计
        /// </summary>
        public decimal OrderAmount { get; set; }
        /// <summary>
        /// 店铺购物车列表
        /// </summary>
        public List<StoreCartInfo> StoreCartList { get; set; }
    }
}