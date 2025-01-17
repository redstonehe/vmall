﻿//验证密码
function verifyPassword() {
    var verifyPasswordForm = document.forms["verifyPasswordForm"];

    var act = verifyPasswordForm.elements["act"].value;
    var password = verifyPasswordForm.elements["password"].value;
    var verifyCode = verifyPasswordForm.elements["verifyCode"].value;

    if (password.length == 0) {
        alert("请输入密码");
        return;
    }
    if (verifyCode.length == 0) {
        alert("请输入验证码");
        return;
    }

    Ajax.post("/ucenter/verifypassword?act=" + act, { 'password': password, 'verifyCode': verifyCode }, false, function (data) {
        var result = eval("(" + data + ")");
        if (result.state == "success") {
            window.location.href = result.content;
        }
        else {
            alert(result.content)
        }
    })
}

function timeCheckForSafeVerify(n, o) {
    var t = n;
    if (n == 0) {
        $(o).attr("href", "javascript:sendVerifyMobile()");
        $(o).css("color", "#FFFFFF").html('重新发送');
        n = t;
    } else {
        n--;
        $(o).html('重新发送&nbsp;' + n);
        setTimeout(function () {
            timeCheckForSafeVerify(n, o);
        }, 1000);
    }
}

//发送验证手机短信
function sendVerifyMobile() {

    Ajax.get("/ucenter/sendverifymobile", false, function (data) {
        var result = eval("(" + data + ")");
        if (result.state == "success") {
            $("#sendSuccess").show();
            $(".sendMobileCode").attr("href", "javascript:void(0);").css("color", "#C1C1C1");
            timeCheckForSafeVerify(120, $(".sendMobileCode"));

        } else {
            alert(result.content)
        }
    })
}

//验证手机
function verifyMobile() {
    var verifyMobileForm = document.forms["verifyMobileForm"];

    var act = verifyMobileForm.elements["act"].value;
    var moibleCode = verifyMobileForm.elements["moibleCode"].value;
    var verifyCode = verifyMobileForm.elements["verifyCode"].value;

    if (moibleCode.length == 0) {
        alert("请输入短信验证码");
        return;
    }
    if (verifyCode.length == 0) {
        alert("请输入验证码");
        return;
    }

    Ajax.post("/ucenter/verifymobile?act=" + act, { 'moibleCode': moibleCode, 'verifyCode': verifyCode }, false, function (data) {
        var result = eval("(" + data + ")");
        if (result.state == "success") {
            window.location.href = result.content;
        }
        else {
            alert(result.content)
        }
    })
}

//发送验证邮件
function sendVerifyEmail() {
    var sendVerifyEmailForm = document.forms["sendVerifyEmailForm"];

    var act = sendVerifyEmailForm.elements["act"].value;
    var verifyCode = sendVerifyEmailForm.elements["verifyCode"].value;

    if (verifyCode.length == 0) {
        alert("请输入验证码");
        return;
    }

    Ajax.post("/ucenter/sendverifyemail?act=" + act, { 'verifyCode': verifyCode }, false, function (data) {
        var result = eval("(" + data + ")");
        alert(result.content)
    })
}

//更新密码
function updatePassword() {
    var updatePasswordForm = document.forms["updatePasswordForm"];

    var v = updatePasswordForm.elements["v"].value;
    var password = updatePasswordForm.elements["password"].value;
    var confirmPwd = updatePasswordForm.elements["confirmPwd"].value;
    var verifyCode = updatePasswordForm.elements["verifyCode"].value;

    if (password.length == 0) {
        alert("请输入密码");
        return;
    }
    if (password != confirmPwd) {
        alert("两次输入的密码不一样");
        return;
    }
    if (verifyCode.length == 0) {
        alert("请输入验证码");
        return;
    }

    Ajax.post("/ucenter/updatepassword?v=" + v, { 'password': password, 'confirmPwd': confirmPwd, 'verifyCode': verifyCode }, false, function (data) {
        var result = eval("(" + data + ")");
        if (result.state == "success") {
            window.location.href = result.content;
        }
        else {
            alert(result.content)
        }
    })
}
//更新支付密码
function updatePayPassword() {
    var updatePasswordForm = document.forms["updatePasswordForm"];

    var v = updatePasswordForm.elements["v"].value;
    var password = updatePasswordForm.elements["password"].value;
    var confirmPwd = updatePasswordForm.elements["confirmPwd"].value;
    var verifyCode = updatePasswordForm.elements["verifyCode"].value;

    if (password.length == 0) {
        alert("请输入密码");
        return;
    }
    if (password != confirmPwd) {
        alert("两次输入的密码不一样");
        return;
    }
    if (verifyCode.length == 0) {
        alert("请输入验证码");
        return;
    }

    Ajax.post("/ucenter/updatepaypassword?v=" + v, { 'password': password, 'confirmPwd': confirmPwd, 'verifyCode': verifyCode }, false, function (data) {
        var result = eval("(" + data + ")");
        if (result.state == "success") {
            window.location.href = result.content;
        }
        else {
            alert(result.content)
        }
    })
}

function timeCheckForUpdateMobile(n, o) {
    var t = n;
    if (n == 0) {
        $(o).attr("href", "javascript:sendUpdateMobile()");
        $(o).css("color", "#FFFFFF").html('重新发送');
        n = t;
    } else {
        n--;
        $(o).html('重新发送&nbsp;' + n);
        setTimeout(function () {
            timeCheckForUpdateMobile(n, o);
        }, 1000);
    }
}

//发送更新手机确认短信
function sendUpdateMobile() {
    var updateMobileForm = document.forms["updateMobileForm"];

    var v = updateMobileForm.elements["v"].value;
    var mobile = updateMobileForm.elements["mobile"].value;

    if (mobile.length == 0) {
        alert("请输入手机号");
        return;
    }

    Ajax.post("/ucenter/sendupdatemobile?v=" + v, { 'mobile': mobile }, false, function (data) {
        var result = eval("(" + data + ")");
        if (result.state == "success") {
            $("#sendSuccess").show();
            $(".sendMobileCode").attr("href", "javascript:void(0);").css("color", "#C1C1C1");
            timeCheckForUpdateMobile(120, $(".sendMobileCode"));

        } else {
            alert(result.content)
        }
    })
}

//更新手机号
function updateMobile() {
    var updateMobileForm = document.forms["updateMobileForm"];

    var v = updateMobileForm.elements["v"].value;
    var mobile = updateMobileForm.elements["mobile"].value;
    var moibleCode = updateMobileForm.elements["moibleCode"].value;
    var verifyCode = updateMobileForm.elements["verifyCode"].value;

    if (mobile.length == 0) {
        alert("请输入手机号");
        return;
    }
    if (moibleCode.length == 0) {
        alert("请输入手机验证码");
        return;
    }
    if (verifyCode.length == 0) {
        alert("请输入验证码");
        return;
    }

    Ajax.post("/ucenter/updatemobile?v=" + v, { 'mobile': mobile, 'moibleCode': moibleCode, 'verifyCode': verifyCode }, false, function (data) {
        var result = eval("(" + data + ")");
        if (result.state == "success") {
            window.location.href = result.content;
        }
        else {
            alert(result.content)
        }
    })
}

//发送更新邮箱确认邮件
function sendUpdateEmail() {
    var updateEmailForm = document.forms["updateEmailForm"];

    var v = updateEmailForm.elements["v"].value;
    var email = updateEmailForm.elements["email"].value;
    var verifyCode = updateEmailForm.elements["verifyCode"].value;

    if (email.length == 0) {
        alert("请输入邮箱");
        return;
    }
    if (verifyCode.length == 0) {
        alert("请输入验证码");
        return;
    }

    Ajax.post("/ucenter/sendupdateemail?v=" + v, { 'email': email, 'verifyCode': verifyCode }, false, function (data) {
        var result = eval("(" + data + ")");
        alert(result.content)
    })
}