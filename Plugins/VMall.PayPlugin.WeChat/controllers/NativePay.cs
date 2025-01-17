﻿using System;
using System.Collections.Generic;
using System.Web;
using VMall.Core;
namespace VMall.PayPlugin.WeChat
{
    public class NativePay
    {
        /**
        * 生成扫描支付模式一URL
        * @param productId 商品ID
        * @return 模式一URL
        */
        //public string GetPrePayUrl(string productId)
        //{
        //    Log.Info(this.GetType().ToString(), "Native pay mode 1 url is producing...");

        //    WxPayData data = new WxPayData();
        //    data.SetValue("appid", WxPayConfig.APPID);//公众帐号id
        //    data.SetValue("mch_id", WxPayConfig.MCHID);//商户号
        //    data.SetValue("time_stamp", WxPayApi.GenerateTimeStamp());//时间戳
        //    data.SetValue("nonce_str", WxPayApi.GenerateNonceStr());//随机字符串
        //    data.SetValue("product_id", productId);//商品ID
        //    data.SetValue("sign", data.MakeSign());//签名
        //    string str = ToUrlParams(data.GetValues());//转换为URL串
        //    string url = "weixin://wxpay/bizpayurl?" + str;

        //    Log.Info(this.GetType().ToString(), "Get native pay mode 1 url : " + url);
        //    return url;
        //}

        /**
        * 生成直接支付url，支付url有效期为2小时,模式二
        * @param productId 商品ID
        * @return 模式二URL
        */
        public string GetPayUrl(string productId,decimal total_fee,string attach,string outTradeNo)
        {
            //Log.Info(this.GetType().ToString(), "Native pay mode 2 url is producing...");
            //LogHelper.WriteOperateLog("WeChatPay", "微信支付请求记录", "Native pay mode 2 url is producing...");
            //Log.Info(this.GetType().ToString(), "============ 生成模式二直接支付二维码url开始 =====================");
            //LogHelper.WriteOperateLog("WeChatPayNative", "微信支付请求记录", "============ 生成模式二直接支付二维码url开始 =====================");
            WxPayData data = new WxPayData();
            data.SetValue("body", string.Format("{0}购物", new MallConfigInfo().SiteTitle));//商品描述
            data.SetValue("attach", attach);//附加数据
            data.SetValue("out_trade_no", WxPayApi.GenerateOutTradeNo());//随机字符串 WxPayApi.GenerateOutTradeNo()
            data.SetValue("total_fee", Convert.ToInt32(total_fee * 100));//总金额 allSurplusMoney.ToString().Replace(".", "")
            data.SetValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));//交易起始时间
            data.SetValue("time_expire", DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss"));//交易结束时间
            data.SetValue("goods_tag", "wx");//商品标记
            data.SetValue("trade_type", "NATIVE");//交易类型
            data.SetValue("product_id", productId);//商品ID
            data.SetValue("notify_url", string.Format("http://{0}/mob/wechat/notify", BMAConfig.MallConfig.SiteUrl));//回调url

            WxPayData result = WxPayApi.UnifiedOrder(data);//调用统一下单接口
            //返回成功状态码才有二维码返回
            string url=string.Empty;
            if (!result.GetValue("result_code").Equals("SUCCESS")) {
                return url;
            }
            url= result.GetValue("code_url").ToString();//获得统一下单接口返回的二维码链接

            //Log.Info(this.GetType().ToString(), "Get native pay mode 2 url : " + url);
            //LogHelper.WriteOperateLog("WeChatPayNative", "微信支付请求记录", "Get native pay mode 2 url : " + url);
            //Log.Info(this.GetType().ToString(), "============ 生成模式二直接支付二维码url结束 =====================");
            //LogHelper.WriteOperateLog("WeChatPayNative", "微信支付请求记录", "============ 生成模式二直接支付二维码url结束 =====================");
            return url;
        }

        /**
        * 参数数组转换为url格式
        * @param map 参数名与参数值的映射表
        * @return URL字符串
        */
        private string ToUrlParams(SortedDictionary<string, object> map)
        {
            string buff = "";
            foreach (KeyValuePair<string, object> pair in map)
            {
                buff += pair.Key + "=" + pair.Value + "&";
            }
            buff = buff.Trim('&');
            return buff;
        }
    }
}