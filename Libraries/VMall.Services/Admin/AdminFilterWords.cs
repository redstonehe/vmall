﻿using System;

using VMall.Core;

namespace VMall.Services
{
    /// <summary>
    /// 后台筛选词操作管理类
    /// </summary>
    public partial class AdminFilterWords : FilterWords
    {
        /// <summary>
        /// 添加筛选词
        /// </summary>
        public static void AddFilterWord(FilterWordInfo filterWordInfo)
        {
            VMall.Data.FilterWords.AddFilterWord(filterWordInfo);
        }

        /// <summary>
        /// 更新筛选词
        /// </summary>
        public static void UpdateFilterWord(FilterWordInfo filterWordInfo)
        {
            VMall.Data.FilterWords.UpdateFilterWord(filterWordInfo);
        }

        /// <summary>
        /// 删除筛选词
        /// </summary>
        /// <param name="idList">id列表</param>
        public static void DeleteFilterWordById(int[] idList)
        {
            if (idList != null && idList.Length > 0)
                VMall.Data.FilterWords.DeleteFilterWordById(CommonHelper.IntArrayToString(idList));
        }
    }
}
