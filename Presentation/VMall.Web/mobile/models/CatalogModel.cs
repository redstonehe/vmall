﻿using System;
using System.Data;
using System.Collections.Generic;

using VMall.Core;
using VMall.Services;
using VMall.Web.Framework;

namespace VMall.Web.Mobile.Models
{
    /// <summary>
    /// 商品模型类
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// 商品id
        /// </summary>
        public int Pid { get; set; }
        /// <summary>
        /// 商品信息
        /// </summary>
        public ProductInfo ProductInfo { get; set; }
        /// <summary>
        /// 商品分类
        /// </summary>
        public CategoryInfo CategoryInfo { get; set; }
        /// <summary>
        /// 商品品牌
        /// </summary>
        public BrandInfo BrandInfo { get; set; }
        /// <summary>
        /// 店铺信息
        /// </summary>
        public StoreInfo StoreInfo { get; set; }
        /// <summary>
        /// 商品图片列表
        /// </summary>
        public List<ProductImageInfo> ProductImageList { get; set; }
        /// <summary>
        /// 商品SKU列表
        /// </summary>
        public List<ExtProductSKUItemInfo> ProductSKUList { get; set; }
        /// <summary>
        /// 商品库存数量
        /// </summary>
        public int StockNumber { get; set; }
        /// <summary>
        /// 单品促销活动
        /// </summary>
        public SinglePromotionInfo SinglePromotionInfo { get; set; }
        /// <summary>
        /// 单品秒杀
        /// </summary>
        public SinglePromotionInfo FlashSaleInfo { get; set; }
        /// <summary>
        /// 买送促销活动列表
        /// </summary>
        public List<BuySendPromotionInfo> BuySendPromotionList { get; set; }
        /// <summary>
        /// 赠品促销活动
        /// </summary>
        public GiftPromotionInfo GiftPromotionInfo { get; set; }
        /// <summary>
        /// 扩展赠品列表
        /// </summary>
        public List<ExtGiftInfo> ExtGiftList { get; set; }
        /// <summary>
        /// 套装商品列表
        /// </summary>
        public List<KeyValuePair<SuitPromotionInfo, List<ExtSuitProductInfo>>> SuitProductList { get; set; }
        /// <summary>
        /// 满赠促销活动
        /// </summary>
        public FullSendPromotionInfo FullSendPromotionInfo { get; set; }
        /// <summary>
        /// 满减促销活动
        /// </summary>
        public FullCutPromotionInfo FullCutPromotionInfo { get; set; }
        /// <summary>
        /// 广告语
        /// </summary>
        public string Slogan { get; set; }
        /// <summary>
        /// 商品促销信息
        /// </summary>
        public string PromotionMsg { get; set; }
        /// <summary>
        /// 商品折扣价格
        /// </summary>
        public decimal DiscountPrice { get; set; }
        /// <summary>
        /// 关联商品列表
        /// </summary>
        public List<PartProductInfo> RelateProductList { get; set; }
        /// <summary>
        /// 是否收藏
        /// </summary>
        public bool IsFav { get; set; }
    }

    /// <summary>
    /// 商品细节模型类
    /// </summary>
    public class ProductDetailsModel
    {
        /// <summary>
        /// 商品id
        /// </summary>
        public int Pid { get; set; }
        /// <summary>
        /// 商品信息
        /// </summary>
        public ProductInfo ProductInfo { get; set; }
        /// <summary>
        /// 扩展商品属性列表
        /// </summary>
        public List<ExtProductAttributeInfo> ExtProductAttributeList { get; set; }
    }

    /// <summary>
    /// 商品套装列表
    /// </summary>
    public class ProductSuitListModel
    {
        /// <summary>
        /// 商品id
        /// </summary>
        public int Pid { get; set; }
        /// <summary>
        /// 商品信息
        /// </summary>
        public PartProductInfo ProductInfo { get; set; }
        /// <summary>
        /// 套装商品列表
        /// </summary>
        public List<KeyValuePair<SuitPromotionInfo, List<ExtSuitProductInfo>>> SuitProductList { get; set; }
    }

    /// <summary>
    /// 分类模型类
    /// </summary>
    public class CategoryModel
    {
        /// <summary>
        /// 分类id
        /// </summary>
        public int CateId { get; set; }
        /// <summary>
        /// 品牌id
        /// </summary>
        public int BrandId { get; set; }
        /// <summary>
        /// 筛选价格
        /// </summary>
        public int FilterPrice { get; set; }
        /// <summary>
        /// 筛选属性
        /// </summary>
        public string FilterAttr { get; set; }
        /// <summary>
        /// 是否只显示有货
        /// </summary>
        public int OnlyStock { get; set; }
        /// <summary>
        /// 排序列
        /// </summary>
        public int SortColumn { get; set; }
        /// <summary>
        /// 排序方向
        /// </summary>
        public int SortDirection { get; set; }
        /// <summary>
        /// 分类信息
        /// </summary>
        public CategoryInfo CategoryInfo { get; set; }
        /// <summary>
        /// 品牌列表
        /// </summary>
        public List<BrandInfo> BrandList { get; set; }
        /// <summary>
        /// 分类价格范围列表
        /// </summary>
        public string[] CatePriceRangeList { get; set; }
        /// <summary>
        /// 属性及其值列表
        /// </summary>
        public List<KeyValuePair<AttributeInfo, List<AttributeValueInfo>>> AAndVList { get; set; }
        /// <summary>
        /// 分页对象
        /// </summary>
        public PageModel PageModel { get; set; }
        /// <summary>
        /// 商品列表
        /// </summary>
        public List<StoreProductInfo> ProductList { get; set; }

        public List<CategoryInfo> ChildrenCateory { get; set; }
    }

    /// <summary>
    /// 分类模型类
    /// </summary>
    public class AjaxCategoryModel
    {
        /// <summary>
        /// 分页对象
        /// </summary>
        public PageModel PageModel { get; set; }
        /// <summary>
        /// 商品列表
        /// </summary>
        public List<StoreProductInfo> ProductList { get; set; }
    }

    /// <summary>
    /// 频道模型类
    /// </summary>
    public class ChannelModel
    {
        /// <summary>
        /// 频道id
        /// </summary>
        public int ChId { get; set; }
        /// <summary>
        /// 组id
        /// </summary>
        public int GId { get; set; }
        /// <summary>
        /// 分类id
        /// </summary>
        public int CateId { get; set; }
        /// <summary>
        /// 品牌id
        /// </summary>
        public int BrandId { get; set; }
        /// <summary>
        /// 筛选价格
        /// </summary>
        public int FilterPrice { get; set; }
        /// <summary>
        /// 是否只显示有货
        /// </summary>
        public int OnlyStock { get; set; }
        /// <summary>
        /// 排序列
        /// </summary>
        public int SortColumn { get; set; }
        /// <summary>
        /// 排序方向
        /// </summary>
        public int SortDirection { get; set; }
        /// <summary>
        /// 分类信息
        /// </summary>
        public ChannelInfo ChannelInfo { get; set; }
        /// <summary>
        /// 组信息
        /// </summary>
        public GroupProductInfo GroupProductInfo { get; set; }
        /// <summary>
        /// 品牌列表
        /// </summary>
        public List<BrandInfo> BrandList { get; set; }
        /// <summary>
        /// 分类价格范围列表
        /// </summary>
        public string[] CatePriceRangeList { get; set; }

        /// <summary>
        /// 分页对象
        /// </summary>
        public PageModel PageModel { get; set; }
        /// <summary>
        /// 商品列表
        /// </summary>
        public List<StoreProductInfo> ProductList { get; set; }
    }

    /// <summary>
    /// 频道首页模型类
    /// </summary>
    public class ChannelIndexModel
    {
        /// <summary>
        /// 频道id
        /// </summary>
        public int ChId { get; set; }
        /// <summary>
        /// 分区频道信息
        /// </summary>
        public ChannelInfo ChannelInfo { get; set; }

        /// <summary>
        /// 分页对象
        /// </summary>
        public PageModel PageModel { get; set; }
        /// <summary>
        /// 商品组列表
        /// </summary>
        public List<GroupProductInfo> GroupProductList { get; set; }
    }

    /// <summary>
    /// 秒杀列表模型类
    /// </summary>
    public class FlashSaleModel
    {

        /// <summary>
        /// 排序列
        /// </summary>
        public int SortColumn { get; set; }
        /// <summary>
        /// 排序方向
        /// </summary>
        public int SortDirection { get; set; }



        /// <summary>
        /// 分页对象
        /// </summary>
        public PageModel PageModel { get; set; }
        /// <summary>
        /// 商品列表
        /// </summary>
        public DataTable ProductList { get; set; }
    }
    /// <summary>
    /// 列表模型类
    /// </summary>
    public class SuitListModel
    {
        /// <summary>
        /// 排序列
        /// </summary>
        public int SortColumn { get; set; }
        /// <summary>
        /// 排序方向
        /// </summary>
        public int SortDirection { get; set; }

        /// <summary>
        /// 分页对象
        /// </summary>
        public PageModel PageModel { get; set; }
        /// <summary>
        /// 商品列表
        /// </summary>
        public List<SuitPromotionInfo> ProductList { get; set; }

        public List<KeyValuePair<SuitPromotionInfo, List<ExtSuitProductInfo>>> SuitProductList { get; set; }
    }

    /// <summary>
    /// 商城搜索模型类
    /// </summary>
    public class MallSearchModel
    {
        /// <summary>
        /// 搜索词
        /// </summary>
        public string Word { get; set; }
        /// <summary>
        /// 分类id
        /// </summary>
        public int CateId { get; set; }
        /// <summary>
        /// 品牌id
        /// </summary>
        public int BrandId { get; set; }
        /// <summary>
        /// 筛选价格
        /// </summary>
        public int FilterPrice { get; set; }
        /// <summary>
        /// 筛选属性
        /// </summary>
        public string FilterAttr { get; set; }
        /// <summary>
        /// 是否只显示有货
        /// </summary>
        public int OnlyStock { get; set; }
        /// <summary>
        /// 排序列
        /// </summary>
        public int SortColumn { get; set; }
        /// <summary>
        /// 排序方向
        /// </summary>
        public int SortDirection { get; set; }
        /// <summary>
        /// 分类列表
        /// </summary>
        public List<CategoryInfo> CategoryList { get; set; }
        /// <summary>
        /// 分类信息
        /// </summary>
        public CategoryInfo CategoryInfo { get; set; }
        /// <summary>
        /// 品牌列表
        /// </summary>
        public List<BrandInfo> BrandList { get; set; }
        /// <summary>
        /// 分类价格范围列表
        /// </summary>
        public string[] CatePriceRangeList { get; set; }
        /// <summary>
        /// 属性及其值列表
        /// </summary>
        public List<KeyValuePair<AttributeInfo, List<AttributeValueInfo>>> AAndVList { get; set; }
        /// <summary>
        /// 分页对象
        /// </summary>
        public PageModel PageModel { get; set; }
        /// <summary>
        /// 商品列表
        /// </summary>
        public List<StoreProductInfo> ProductList { get; set; }
        /// <summary>
        /// 热销产品推荐
        /// </summary>
        public List<PartProductInfo> HotSaleProductList { get; set; }
    }

    /// <summary>
    /// 商城搜索模型类
    /// </summary>
    public class AjaxMallSearchModel
    {
        /// <summary>
        /// 分页对象
        /// </summary>
        public PageModel PageModel { get; set; }
        /// <summary>
        /// 商品列表
        /// </summary>
        public List<StoreProductInfo> ProductList { get; set; }
    }

    /// <summary>
    /// 商品评价列表模型类
    /// </summary>
    public class ProductReviewListModel
    {
        /// <summary>
        /// 商品信息
        /// </summary>
        public PartProductInfo ProductInfo { get; set; }
        /// <summary>
        /// 店铺信息
        /// </summary>
        public StoreInfo StoreInfo { get; set; }
        /// <summary>
        /// 评价类型
        /// </summary>
        public int ReviewType { get; set; }
        /// <summary>
        /// 分页对象
        /// </summary>
        public PageModel PageModel { get; set; }
        /// <summary>
        /// 商品评价列表
        /// </summary>
        public DataTable ProductReviewList { get; set; }
    }

    /// <summary>
    /// 商品咨询列表模型类
    /// </summary>
    public class ProductConsultListModel
    {
        /// <summary>
        /// 商品信息
        /// </summary>
        public PartProductInfo ProductInfo { get; set; }
        /// <summary>
        /// 店铺信息
        /// </summary>
        public StoreInfo StoreInfo { get; set; }
        /// <summary>
        /// 咨询类型id
        /// </summary>
        public int ConsultTypeId { get; set; }
        /// <summary>
        /// 咨询信息
        /// </summary>
        public string ConsultMessage { get; set; }
        /// <summary>
        /// 分页对象
        /// </summary>
        public PageModel PageModel { get; set; }
        /// <summary>
        /// 商品咨询列表
        /// </summary>
        public List<ProductConsultInfo> ProductConsultList { get; set; }
        /// <summary>
        /// 商品咨询类型列表
        /// </summary>
        public ProductConsultTypeInfo[] ProductConsultTypeList { get; set; }
        /// <summary>
        /// 是否显示验证码
        /// </summary>
        public bool IsVerifyCode { get; set; }
    }

    public class ApplyTryFreeModel
    {
        /// <summary>
        /// 收货地址列表
        /// </summary>
        public List<FullShipAddressInfo> shipAddress { get; set; }
    }
}