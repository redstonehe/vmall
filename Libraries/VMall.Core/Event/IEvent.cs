﻿using System;

namespace VMall.Core
{
    /// <summary>
    /// VMall事件接口
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// 执行事件
        /// </summary>
        /// <param name="eventInfo">事件信息</param>
        void Execute(object eventInfo);
    }
}
