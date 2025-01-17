﻿using System;
using System.Collections.Generic;

using VMall.Core;
using System.Data;

namespace VMall.Services
{
    /// <summary>
    /// 搜索操作管理类
    /// </summary>
    public partial class Searches
    {
        private static ISearchStrategy _isearchstrategy = BMASearch.Instance;//搜索策略

        /// <summary>
        /// 搜索商城商品
        /// </summary>
        /// <param name="pageSize">每页数</param>
        /// <param name="pageNumber">当前页数</param>
        /// <param name="keyword">关键词</param>
        /// <param name="cateId">分类id</param>
        /// <param name="brandId">品牌id</param>
        /// <param name="filterPrice">筛选价格</param>
        /// <param name="catePriceRangeList">分类价格范围列表</param>
        /// <param name="attrValueIdList">属性值id列表</param>
        /// <param name="onlyStock">是否只显示有货</param>
        /// <param name="sortColumn">排序列</param>
        /// <param name="sortDirection">排序方向</param>
        /// <returns></returns>
        public static List<StoreProductInfo> SearchMallProducts(int pageSize, int pageNumber, string keyword, int cateId, int brandId, int filterPrice, string[] catePriceRangeList, List<int> attrValueIdList, int onlyStock, int sortColumn, int sortDirection)
        {
            return _isearchstrategy.SearchMallProducts(pageSize, pageNumber, keyword, cateId, brandId, filterPrice, catePriceRangeList, attrValueIdList, onlyStock, sortColumn, sortDirection);
        }

        /// <summary>
        /// 获得搜索商城商品数量
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="cateId">分类id</param>
        /// <param name="brandId">品牌id</param>
        /// <param name="filterPrice">筛选价格</param>
        /// <param name="catePriceRangeList">分类价格范围列表</param>
        /// <param name="attrValueIdList">属性值id列表</param>
        /// <param name="onlyStock">是否只显示有货</param>
        /// <returns></returns>
        public static int GetSearchMallProductCount(string keyword, int cateId, int brandId, int filterPrice, string[] catePriceRangeList, List<int> attrValueIdList, int onlyStock)
        {
            return _isearchstrategy.GetSearchMallProductCount(keyword, cateId, brandId, filterPrice, catePriceRangeList, attrValueIdList, onlyStock);
        }

        /// <summary>
        /// 搜索店铺商品
        /// </summary>
        /// <param name="pageSize">每页数</param>
        /// <param name="pageNumber">当前页数</param>
        /// <param name="keyword">关键词</param>
        /// <param name="storeId">店铺id</param>
        /// <param name="storeCid">店铺分类id</param>
        /// <param name="startPrice">开始价格</param>
        /// <param name="endPrice">结束价格</param>
        /// <param name="sortColumn">排序列</param>
        /// <param name="sortDirection">排序方向</param>
        /// <returns></returns>
        public static List<PartProductInfo> SearchStoreProducts(int pageSize, int pageNumber, string keyword, int storeId, int storeCid, int startPrice, int endPrice, int sortColumn, int sortDirection)
        {
            return _isearchstrategy.SearchStoreProducts(pageSize, pageNumber, keyword, storeId, storeCid, startPrice, endPrice, sortColumn, sortDirection);
        }

        /// <summary>
        /// 获得搜索店铺商品数量
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="storeId">店铺id</param>
        /// <param name="storeCid">店铺分类id</param>
        /// <param name="startPrice">开始价格</param>
        /// <param name="endPrice">结束价格</param>
        /// <returns></returns>
        public static int GetSearchStoreProductCount(string keyword, int storeId, int storeCid, int startPrice, int endPrice)
        {
            return _isearchstrategy.GetSearchStoreProductCount(keyword, storeId, storeCid, startPrice, endPrice);
        }

        /// <summary>
        /// 获得分类列表
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <returns></returns>
        public static List<CategoryInfo> GetCategoryListByKeyword(string keyword)
        {
            return _isearchstrategy.GetCategoryListByKeyword(keyword);
        }

        /// <summary>
        /// 获得分类品牌列表
        /// </summary>
        /// <param name="cateId">分类id</param>
        /// <param name="keyword">关键词</param>
        /// <returns></returns>
        public static List<BrandInfo> GetCategoryBrandListByKeyword(int cateId, string keyword)
        {
            return _isearchstrategy.GetCategoryBrandListByKeyword(cateId, keyword);
        }


        public static List<ProductKeywordInfo> GetSearchWordTips(string word) {
            List<ProductKeywordInfo> wordlist = new List<ProductKeywordInfo>();
            string commandText = string.Empty;
            commandText = string.Format(@"SELECT DISTINCT TOP 5 keyword  FROM [hlh_productkeywords] WHERE [keyword] LIKE '%{0}%'", word);
            
            using (IDataReader reader = RDBSHelper.ExecuteReader(CommandType.Text, commandText))
            {
                while (reader.Read())
                {
                    ProductKeywordInfo wordInfo = new ProductKeywordInfo();
                    if (reader["keyword"] != null && reader["keyword"].ToString() != "")
                    {
                        wordInfo.Keyword = reader["keyword"].ToString().Trim();
                    }
                    wordlist.Add(wordInfo);
                }
                reader.Close();
            }
            return wordlist;
        }
    }
}
