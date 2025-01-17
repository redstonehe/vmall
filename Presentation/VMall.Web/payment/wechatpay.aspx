﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wechatpay.aspx.cs" Inherits="VMall.Web.payment.wechatpay" %>

<!DOCTYPE html>
<html>
<head lang="zh">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <title></title>
    <style>
        .weixin {
            padding: .8em;
            margin: .8em;
            border: 1px solid #ebebeb;
            border-radius: 10px;
            text-align: center;
        }

            .weixin p {
                padding: 1.5em 0;
                font-size: 20px;
            }
            .gayBt{ padding:4px 20px;/*border: 1px solid #999;*/border-radius: 1px;background-color: #00CB00;background: -webkit-gradient(linear,0 0,0 100%,from(#fffeff),to(##00CB00));line-height: 40px;font-size: 18px;color: #FFF;display:block;height:40px;width:250px;}
    </style>
    <script type="text/javascript">
        <%
        Dictionary<String, String> jumpData = (Dictionary<String, String>)Session["data"];
        int firstOid =int.Parse(jumpData["oidList"].Split(',')[0]);
        string osn = VMall.Services.Orders.GetOrderByOid(firstOid).OSN;
        
    %>
        function SavePay() {
            WeixinJSBridge.invoke('getBrandWCPayRequest', {
                "appId": "<%=Session["AppId"]%>", //公众号名称，由商户传入
                "timeStamp": "<%=jumpData["timeStamp"]%>", //时间戳
                "nonceStr": "<%=jumpData["nonceStr"]%>", //随机串
                "package": "<%=jumpData["package"]%>", //扩展包
                "signType": "MD5", //微信签名方式:1.sha1
                "paySign": "<%=jumpData["paySign"]%>" //微信签名
            },
        function (res) {
            if (res.err_msg == "get_brand_wcpay_request:ok") {
                //document.getElementById("content").innerHTML = "您已成功支付！";
                //alert("微信支付成功!");
                var osn = document.getElementById("osn").value;
                var fdStart = osn.indexOf("7");
                if (fdStart == 0) {
                    window.location.href = "/agent/order/ResultPay?oids=<%=jumpData["oidList"]%>&paystatus=1";
                } else {
                    window.location.href = "/mob/order/ResultPay?oids=<%=jumpData["oidList"]%>&paystatus=1";
                }
            } else if (res.err_msg == "get_brand_wcpay_request:cancel") {
                alert("用户取消支付!");
            } else {
                alert(res.err_msg);
                alert("支付失败!");
            }
            // 使用以上方式判断前端返回,微信团队郑重提示：res.err_msg将在用户支付成功后返回ok，但并不保证它绝对可靠。
            //因此微信团队建议，当收到ok返回时，向商户后台询问是否收到交易成功的通知，若收到通知，前端展示交易成功的界面；若此时未收到通知，商户后台主动调用查询订单接口，查询订单的当前状态，并反馈给前端展示相应的界面。
        });
    }
    //function pay() {
    //    if (typeof WeixinJSBridge == "undefined") {
    //        if (document.addEventListener) {
    //            document.addEventListener('WeixinJSBridgeReady', SavePay, false);
    //        } else if (document.attachEvent) {
    //            document.attachEvent('WeixinJSBridgeReady', SavePay);
    //            document.attachEvent('onWeixinJSBridgeReady', SavePay);
    //        }
    //    } else {
    //        SavePay();
    //    }
    //}
    </script>
</head>
<body>
    <div class="weixin">
        <img src="/images/wechatpay.jpg" width="200">
        <input type="hidden" id="osn" value="<%=osn%>" />
        <p id="content" style="text-align:center;"><a href="javascript:SavePay()" class="gayBt" style="font-size: 20px;">去微信支付</a></p>
    </div>
</body>
</html>
