﻿using System;
using System.IO;
using System.Web;
using System.Text;
using System.Data;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using VMall.Core;
using VMall.Services;
using VMall.Web.Framework;
using VMall.Web.MallAdmin.Models;

namespace VMall.Web.MallAdmin.Controllers
{
    /// <summary>
    /// 商城后台店铺控制器类
    /// </summary>
    public partial class StoreController : BaseMallAdminController
    {
        #region 店铺操作
        /// <summary>
        /// 店铺列表
        /// </summary>
        public ActionResult StoreList(string storeName, string sortColumn, string sortDirection, int storeRid = 0, int storeIid = 0, int state = -1, int pageNumber = 1, int pageSize = 50)
        {
            string condition = AdminStores.AdminGetStoreListCondition(storeName, storeRid, storeIid, state);
            string sort = AdminStores.AdminGetStoreListSort(sortColumn, sortDirection);

            PageModel pageModel = new PageModel(pageSize, pageNumber, AdminStores.AdminGetStoreCount(condition));
            StoreListModel model = new StoreListModel()
            {
                StoreList = AdminStores.AdminGetStoreList(pageModel.PageSize, pageModel.PageNumber, condition, "[storeid] ASC "),
                PageModel = pageModel,
                SortColumn = sortColumn,
                SortDirection = sortDirection,
                StoreName = storeName,
                StoreRid = storeRid,
                StoreIid = storeIid,
                State = state
            };

            List<SelectListItem> storeRankList = new List<SelectListItem>();
            storeRankList.Add(new SelectListItem() { Text = "全部等级", Value = "0" });
            foreach (StoreRankInfo storeRankInfo in AdminStoreRanks.GetStoreRankList())
            {
                storeRankList.Add(new SelectListItem() { Text = storeRankInfo.Title, Value = storeRankInfo.StoreRid.ToString() });
            }
            ViewData["storeRankList"] = storeRankList;

            List<SelectListItem> storeIndustryList = new List<SelectListItem>();
            storeIndustryList.Add(new SelectListItem() { Text = "全部行业", Value = "0" });
            foreach (StoreIndustryInfo storeIndustryInfo in AdminStoreIndustries.GetStoreIndustryList())
            {
                storeIndustryList.Add(new SelectListItem() { Text = storeIndustryInfo.Title, Value = storeIndustryInfo.StoreIid.ToString() });
            }
            ViewData["storeIndustryList"] = storeIndustryList;

            List<SelectListItem> storeStateList = new List<SelectListItem>();
            storeStateList.Add(new SelectListItem() { Text = "全部", Value = "-1" });
            storeStateList.Add(new SelectListItem() { Text = "营业", Value = ((int)StoreState.Open).ToString() });
            storeStateList.Add(new SelectListItem() { Text = "关闭", Value = ((int)StoreState.Close).ToString() });
            ViewData["storeStateList"] = storeStateList;

            MallUtils.SetAdminRefererCookie(string.Format("{0}?pageNumber={1}&pageSize={2}&sortColumn={3}&sortDirection={4}&storeName={5}&storeRid={6}&storeIid={7}&state={8}",
                                                          Url.Action("storelist"),
                                                          pageModel.PageNumber, pageModel.PageSize,
                                                          sortColumn, sortDirection,
                                                          storeName, storeRid, storeIid, state));
            return View(model);
        }

        /// <summary>
        /// 店铺选择列表
        /// </summary>
        /// <param name="storeName">店铺名称</param>
        /// <param name="pageSize">每页数</param>
        /// <param name="pageNumber">当前页数</param>
        /// <returns></returns>
        public ContentResult StoreSelectList(string storeName, int pageNumber = 1, int pageSize = 12)
        {
            string condition = AdminStores.AdminGetStoreListCondition(storeName, 0, 0, (int)StoreState.Open, WorkContext.PartUserInfo.StoreId);
            PageModel pageModel = new PageModel(pageSize, pageNumber, AdminStores.AdminGetStoreCount(condition));

            DataTable storeSelectList = AdminStores.AdminGetStoreSelectList(pageModel.PageSize, pageModel.PageNumber, condition);

            StringBuilder result = new StringBuilder("{");
            result.AppendFormat("\"totalPages\":\"{0}\",\"pageNumber\":\"{1}\",\"items\":[", pageModel.TotalPages, pageModel.PageNumber);
            foreach (DataRow row in storeSelectList.Rows)
                result.AppendFormat("{0}\"id\":\"{1}\",\"name\":\"{2}\"{3},", "{", row["storeid"], row["name"].ToString().Trim(), "}");

            if (storeSelectList.Rows.Count > 0)
                result.Remove(result.Length - 1, 1);

            result.Append("]}");
            return Content(result.ToString());
        }

        /// <summary>
        /// 添加店铺
        /// </summary>
        [HttpGet]
        public ActionResult AddStore()
        {
            AddStoreModel model = new AddStoreModel();
            ViewData["referer"] = MallUtils.GetMallAdminRefererCookie();
            return View(model);
        }

        /// <summary>
        /// 添加店铺
        /// </summary>
        [HttpPost]
        public ActionResult AddStore(AddStoreModel model)
        {
            if (AdminStores.GetStoreIdByName(model.StoreName) > 0)
                ModelState.AddModelError("StoreName", "名称已经存在");

            if (ModelState.IsValid)
            {
                StoreInfo storeInfo = new StoreInfo()
                {
                    State = (int)StoreState.Open,
                    Name = model.StoreName,
                    RegionId = 0,
                    StoreRid = AdminStoreRanks.GetLowestStoreRank().StoreRid,
                    StoreIid = 0,
                    Logo = "",
                    CreateTime = DateTime.Now,
                    Mobile = "",
                    Phone = "",
                    QQ = "",
                    WW = "",
                    DePoint = 10.00m,
                    SePoint = 10.00m,
                    ShPoint = 10.00m,
                    Honesties = 0,
                    StateEndTime = model.StateEndTime,
                    Theme = "Default",
                    Banner = "",
                    Announcement = "",
                    Description = ""
                };

                StoreKeeperInfo storeKeeperInfo = new StoreKeeperInfo()
                {
                    Type = model.Type,
                    Name = model.StoreKeeperName,
                    IdCard = model.IdCard,
                    Address = model.Address
                };

                int storeId = AdminStores.CreateStore(storeInfo, storeKeeperInfo);
                if (storeId > 0)
                {
                    AddMallAdminLog("添加店铺", "添加店铺,店铺id为:" + storeId);
                    return PromptView("店铺添加成功");
                }
                else
                {
                    return PromptView("店铺添加失败");
                }
            }

            ViewData["referer"] = MallUtils.GetMallAdminRefererCookie();
            return View(model);
        }

        /// <summary>
        /// 编辑店铺
        /// </summary>
        [HttpGet]
        public ActionResult EditStore(int storeId = -1)
        {
            StoreInfo storeInfo = AdminStores.GetStoreById(storeId);
            if (storeInfo == null)
                return PromptView("店铺不存在");

            EditStoreModel model = new EditStoreModel();
            model.State = storeInfo.State;
            model.StoreName = storeInfo.Name;
            model.RegionId = storeInfo.RegionId;
            model.StoreRid = storeInfo.StoreRid;
            model.StoreIid = storeInfo.StoreIid;
            model.Logo = storeInfo.Logo;
            model.Mobile = storeInfo.Mobile;
            model.Phone = storeInfo.Phone;
            model.QQ = storeInfo.QQ;
            model.WW = storeInfo.WW;
            model.StateEndTime = storeInfo.StateEndTime.ToString();
            model.Theme = storeInfo.Theme;
            model.Banner = storeInfo.Banner;
            model.Announcement = storeInfo.Announcement;
            model.Description = storeInfo.Description;

            LoadStore(storeId, model.RegionId);
            return View(model);
        }

        /// <summary>
        /// 编辑店铺
        /// </summary>
        [HttpPost]
        public ActionResult EditStore(EditStoreModel model, int storeId = -1)
        {
            StoreInfo storeInfo = AdminStores.GetStoreById(storeId);
            if (storeInfo == null)
                return PromptView("店铺不存在");

            int storeId2 = AdminStores.GetStoreIdByName(model.StoreName);
            if (storeId2 > 0 && storeId2 != storeId)
                ModelState.AddModelError("StoreName", "店铺名已经存在");

            if (ModelState.IsValid)
            {
                storeInfo.State = model.State;
                storeInfo.Name = model.StoreName;
                storeInfo.RegionId = model.RegionId;
                storeInfo.StoreRid = model.StoreRid;
                storeInfo.StoreIid = model.StoreIid;
                storeInfo.Logo = model.Logo == null ? "" : model.Logo;
                storeInfo.Mobile = model.Mobile == null ? "" : model.Mobile;
                storeInfo.Phone = model.Phone == null ? "" : model.Phone;
                storeInfo.QQ = model.QQ == null ? "" : model.QQ;
                storeInfo.WW = model.WW == null ? "" : model.WW;
                storeInfo.Honesties = model.StoreRid == storeInfo.StoreRid ? storeInfo.Honesties : AdminStoreRanks.GetStoreRankById(model.StoreRid).HonestiesLower;
                storeInfo.StateEndTime = TypeHelper.StringToDateTime(model.StateEndTime);
                storeInfo.Theme = model.Theme;
                storeInfo.Banner = model.Banner == null ? "" : model.Banner;
                storeInfo.Announcement = model.Announcement == null ? "" : model.Announcement;
                storeInfo.Description = model.Description == null ? "" : model.Description;

                AdminStores.UpdateStore(storeInfo);
                AddMallAdminLog("修改店铺", "修改店铺,店铺ID为:" + storeId);
                return PromptView("店铺修改成功");
            }

            LoadStore(storeId, model.RegionId);
            return View(model);
        }

        /// <summary>
        /// 编辑店铺优惠
        /// </summary>
        [HttpGet]
        public ActionResult EditStoreDiscount(int storeId = -1)
        {
            StoreInfo storeInfo = AdminStores.GetStoreById(storeId);
            if (storeInfo == null)
                return PromptView("店铺不存在");

            EditStoreDiscountModel model = new EditStoreDiscountModel();
            model.StoreId = storeInfo.StoreId;
            model.Amount1 = storeInfo.Amount1;
            model.Discount1 = storeInfo.Discount1;
            model.Amount2 = storeInfo.Amount2;
            model.Discount2 = storeInfo.Discount2;
            model.Amount3 = storeInfo.Amount3;
            model.Discount3 = storeInfo.Discount3;
            model.Amount4 = storeInfo.Amount4;
            model.Discount4 = storeInfo.Discount4;
            model.Amount5 = storeInfo.Amount5;
            model.Discount5 = storeInfo.Discount5;
            ViewData["referer"] = MallUtils.GetMallAdminRefererCookie();

            return View(model);
        }

        /// <summary>
        /// 编辑店铺
        /// </summary>
        [HttpPost]
        public ActionResult EditStoreDiscount(EditStoreDiscountModel model, int storeId = -1)
        {
            StoreInfo storeInfo = AdminStores.GetStoreById(storeId);
            if (storeInfo == null)
                return PromptView("店铺不存在");

            if (ModelState.IsValid)
            {
                storeInfo.Amount1 = model.Amount1;
                storeInfo.Discount1 = model.Discount1;
                storeInfo.Amount2 = model.Amount2;
                storeInfo.Discount2 = model.Discount2;
                storeInfo.Amount3 = model.Amount3;
                storeInfo.Discount3 = model.Discount3;
                storeInfo.Amount4 = model.Amount4;
                storeInfo.Discount4 = model.Discount4;
                storeInfo.Amount5 = model.Amount5;
                storeInfo.Discount5 = model.Discount5;

                AdminStores.UpdateStoreDiscount(storeInfo);
                AddMallAdminLog("修改店铺", "修改店铺优惠折扣,店铺ID为:" + storeId);
                return PromptView("店铺优惠折扣修改成功");
            }

            ViewData["referer"] = MallUtils.GetMallAdminRefererCookie();
            return View(model);
        }

        /// <summary>
        /// 删除店铺
        /// </summary>
        public ViewResult DelStore(int storeId)
        {
            int result = AdminStores.DeleteStoreById(storeId);
            if (result == -1)
                return PromptView("删除失败请先转移或删除此店铺下的商品");

            AddMallAdminLog("删除店铺", "删除店铺,店铺ID为:" + storeId);
            return PromptView("店铺删除成功");
        }

        private void LoadStore(int storeId, int regionId)
        {
            ViewData["storeId"] = storeId;

            List<SelectListItem> storeRankList = new List<SelectListItem>();
            storeRankList.Add(new SelectListItem() { Text = "选择店铺等级", Value = "-1" });
            foreach (StoreRankInfo storeRankInfo in AdminStoreRanks.GetStoreRankList())
            {
                storeRankList.Add(new SelectListItem() { Text = storeRankInfo.Title, Value = storeRankInfo.StoreRid.ToString() });
            }
            ViewData["storeRankList"] = storeRankList;


            List<SelectListItem> storeIndustryList = new List<SelectListItem>();
            storeIndustryList.Add(new SelectListItem() { Text = "选择店铺行业", Value = "-1" });
            foreach (StoreIndustryInfo storeIndustryInfo in AdminStoreIndustries.GetStoreIndustryList())
            {
                storeIndustryList.Add(new SelectListItem() { Text = storeIndustryInfo.Title, Value = storeIndustryInfo.StoreIid.ToString() });
            }
            ViewData["storeIndustryList"] = storeIndustryList;

            List<SelectListItem> themeList = new List<SelectListItem>();
            DirectoryInfo dir = new DirectoryInfo(IOHelper.GetMapPath("/themes"));
            foreach (DirectoryInfo themeDir in dir.GetDirectories())
            {
                themeList.Add(new SelectListItem() { Text = themeDir.Name, Value = themeDir.Name });
            }
            ViewData["themeList"] = themeList;

            RegionInfo regionInfo = Regions.GetRegionById(regionId);
            if (regionInfo != null)
            {
                ViewData["provinceId"] = regionInfo.ProvinceId;
                ViewData["cityId"] = regionInfo.CityId;
                ViewData["countyId"] = regionInfo.RegionId;
            }
            else
            {
                ViewData["provinceId"] = -1;
                ViewData["cityId"] = -1;
                ViewData["countyId"] = -1;
            }

            string allowImgType = string.Empty;
            string[] imgTypeList = StringHelper.SplitString(BMAConfig.MallConfig.UploadImgType, ",");
            foreach (string imgType in imgTypeList)
                allowImgType += string.Format("*{0};", imgType.ToLower());

            string[] sizeList = StringHelper.SplitString(WorkContext.MallConfig.StoreLogoThumbSize);

            ViewData["size"] = sizeList[sizeList.Length / 2];
            ViewData["allowImgType"] = allowImgType;
            ViewData["maxImgSize"] = BMAConfig.MallConfig.UploadImgSize;

            ViewData["referer"] = MallUtils.GetMallAdminRefererCookie();
        }

        #endregion

        #region 店铺管理者、分类
        /// <summary>
        /// 编辑店长
        /// </summary>
        [HttpGet]
        public ActionResult EditStoreKeeper(int storeId = -1)
        {
            StoreKeeperInfo storeKeeperInfo = AdminStores.GetStoreKeeperById(storeId);
            if (storeKeeperInfo == null)
                return PromptView("店长不存在");

            StoreKeeperModel model = new StoreKeeperModel();
            model.Type = storeKeeperInfo.Type;
            model.StoreKeeperName = storeKeeperInfo.Name;
            model.IdCard = storeKeeperInfo.IdCard;
            model.Address = storeKeeperInfo.Address;

            ViewData["referer"] = MallUtils.GetMallAdminRefererCookie();
            return View(model);
        }

        /// <summary>
        /// 编辑店长
        /// </summary>
        [HttpPost]
        public ActionResult EditStoreKeeper(StoreKeeperModel model, int storeId = -1)
        {
            StoreKeeperInfo storeKeeperInfo = AdminStores.GetStoreKeeperById(storeId);
            if (storeKeeperInfo == null)
                return PromptView("店长不存在");

            if (ModelState.IsValid)
            {
                storeKeeperInfo.Type = model.Type;
                storeKeeperInfo.Name = model.StoreKeeperName;
                storeKeeperInfo.IdCard = model.IdCard;
                storeKeeperInfo.Address = model.Address;

                AdminStores.UpdateStoreKeeper(storeKeeperInfo);
                AddMallAdminLog("修改店长", "修改店长,店铺ID为:" + storeId);
                return PromptView("店长修改成功");
            }

            ViewData["referer"] = MallUtils.GetMallAdminRefererCookie();
            return View(model);
        }




        /// <summary>
        /// 设置店铺管理员
        /// </summary>
        [HttpGet]
        public ActionResult SetStoreAdminer(int storeId = -1)
        {
            StoreInfo storeInfo = AdminStores.GetStoreById(storeId);
            if (storeInfo == null)
                return PromptView("店铺不存在");

            StoreAdminerModel model = new StoreAdminerModel();
            model.AdminAccountList = AdminUsers.GetStoreAdminUserList(20, 1, " [storeid]=" + storeId, "", "");
            return View(model);
        }

        /// <summary>
        /// 设置店铺管理员
        /// </summary>
        [HttpPost]
        public ActionResult SetStoreAdminer(StoreAdminerModel model, int storeId = -1)
        {
            StoreInfo storeInfo = AdminStores.GetStoreById(storeId);
            if (storeInfo == null)
                return PromptView("店铺不存在");

            int uid = AdminUsers.GetUidByAccountName(model.AccountName.Trim());
            if (uid < 1)
                ModelState.AddModelError("AccountName", "账号不存在");

            if (ModelState.IsValid)
            {
                AdminUsers.SetStoreAdminer(uid, storeId);
                AddMallAdminLog("设置店铺管理员", "设置店铺管理员,店铺ID为:" + storeId);
                return PromptView("店铺管理员设置成功");
            }
            return View(model);
        }

        /// <summary>
        /// 撤销店铺管理员
        /// </summary>

        public ActionResult RemoveStoreAdminer(int uid = -1)
        {
            PartUserInfo Info = Users.GetPartUserById(uid);

            if (Info == null)
                return PromptView("会员不存在");
            bool result = AdminUsers.RemoveStoreAdminer(uid);
            if (result)
                return Content("1");

            else
                return Content("0");

        }


        /// <summary>
        /// 店铺分类列表
        /// </summary>
        public ActionResult StoreClassList(int storeId = -1)
        {
            StoreInfo storeInfo = AdminStores.GetStoreById(storeId);
            if (storeInfo == null)
                return PromptView("店铺不存在");

            StoreClassListModel model = new StoreClassListModel()
            {
                StoreId = storeId,
                StoreClassList = AdminStores.GetStoreClassList(storeId)
            };
            MallUtils.SetAdminRefererCookie(string.Format("{0}?storeId={1}", Url.Action("storeclasslist"), storeId));
            return View(model);
        }

        /// <summary>
        /// 店铺分类选择列表
        /// </summary>
        public ActionResult StoreClassSelectList(int storeId = -1)
        {
            List<StoreClassInfo> storeClassSelectList = AdminStores.GetStoreClassList(storeId).FindAll(x => x.HasChild == 0);

            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (StoreClassInfo storeClassInfo in storeClassSelectList)
            {
                sb.AppendFormat("{0}\"id\":\"{1}\",\"name\":\"{2}\"{3},", "{", storeClassInfo.StoreCid, storeClassInfo.Name, "}");
            }
            if (storeClassSelectList.Count > 0)
                sb.Remove(sb.Length - 1, 1);
            sb.Append("]");

            return Content(sb.ToString());
        }

        /// <summary>
        /// 添加店铺分类
        /// </summary>
        [HttpGet]
        public ViewResult AddStoreClass(int storeId = -1)
        {
            StoreInfo storeInfo = AdminStores.GetStoreById(storeId);
            if (storeInfo == null)
                return PromptView("店铺不存在");

            StoreClassModel model = new StoreClassModel();
            LoadStoreClass(storeId);
            return View(model);
        }

        /// <summary>
        /// 添加店铺分类
        /// </summary>
        [HttpPost]
        public ActionResult AddStoreClass(StoreClassModel model, int storeId = -1)
        {
            StoreInfo storeInfo = AdminStores.GetStoreById(storeId);
            if (storeInfo == null)
                return PromptView("店铺不存在");

            if (AdminStores.GetStoreCidByStoreIdAndName(storeId, model.StoreClassName) > 0)
                ModelState.AddModelError("StoreClassName", "名称已经存在");

            if (model.ParentId != 0 && AdminStores.GetStoreClassByStoreIdAndStoreCid(storeId, model.ParentId) == null)
                ModelState.AddModelError("ParentId", "父分类不存在");

            if (ModelState.IsValid)
            {
                StoreClassInfo storeClassInfo = new StoreClassInfo()
                {
                    StoreId = storeId,
                    DisplayOrder = model.DisplayOrder,
                    Name = model.StoreClassName,
                    ParentId = model.ParentId
                };

                AdminStores.CreateStoreClass(storeClassInfo);
                AddMallAdminLog("添加店铺分类", "添加店铺分类,店铺分类为:" + model.StoreClassName);
                return PromptView("店铺分类添加成功");
            }

            LoadStoreClass(storeId);
            return View(model);
        }

        /// <summary>
        /// 编辑店铺分类
        /// </summary>
        [HttpGet]
        public ActionResult EditStoreClass(int storeId = -1, int storeCid = -1)
        {
            StoreClassInfo storeClassInfo = AdminStores.GetStoreClassByStoreIdAndStoreCid(storeId, storeCid);
            if (storeClassInfo == null)
                return PromptView("此店铺分类不存在");

            StoreClassModel model = new StoreClassModel();
            model.StoreClassName = storeClassInfo.Name;
            model.ParentId = storeClassInfo.ParentId;
            model.DisplayOrder = storeClassInfo.DisplayOrder;

            LoadStoreClass(storeId);
            return View(model);
        }

        /// <summary>
        /// 编辑店铺分类
        /// </summary>
        [HttpPost]
        public ActionResult EditStoreClass(StoreClassModel model, int storeId = -1, int storeCid = -1)
        {
            StoreClassInfo storeClassInfo = AdminStores.GetStoreClassByStoreIdAndStoreCid(storeId, storeCid);
            if (storeClassInfo == null)
                return PromptView("此店铺分类不存在");

            int storeCid2 = AdminStores.GetStoreCidByStoreIdAndName(storeId, model.StoreClassName);
            if (storeCid2 > 0 && storeCid2 != storeCid)
                ModelState.AddModelError("StoreClassName", "名称已经存在");

            if (model.ParentId == storeClassInfo.StoreCid)
                ModelState.AddModelError("ParentId", "不能将自己作为父分类");

            if (model.ParentId != 0 && AdminStores.GetStoreClassByStoreIdAndStoreCid(storeId, model.ParentId) == null)
                ModelState.AddModelError("ParentId", "父分类不存在");

            if (model.ParentId != 0 && AdminStores.GetChildStoreClassList(storeId, storeCid, true).Exists(x => x.StoreCid == model.ParentId))
                ModelState.AddModelError("ParentId", "不能将分类调整到自己的子分类下");

            if (ModelState.IsValid)
            {
                int oldParentId = storeClassInfo.ParentId;

                storeClassInfo.ParentId = model.ParentId;
                storeClassInfo.Name = model.StoreClassName;
                storeClassInfo.DisplayOrder = model.DisplayOrder;

                AdminStores.UpdateStoreClass(storeClassInfo, oldParentId);
                AddMallAdminLog("修改店铺分类", "修改店铺分类,店铺分类ID为:" + storeCid);
                return PromptView("商品修改成功");
            }

            LoadStoreClass(storeId);
            return View(model);
        }

        /// <summary>
        /// 删除店铺分类
        /// </summary>
        public ActionResult DelStoreClass(int storeId = -1, int storeCid = -1)
        {
            int result = AdminStores.DeleteStoreClassByStoreIdAndStoreCid(storeId, storeCid);
            if (result == -2)
                return PromptView("此店铺分类不存在");
            else if (result == -1)
                return PromptView("删除失败请先转移或删除此店铺分类下的店铺分类");
            else if (result == 0)
                return PromptView("删除失败请先转移或删除此店铺分类下的商品");
            AddMallAdminLog("删除店铺分类", "删除店铺分类,店铺分类ID为:" + storeCid);
            return PromptView("店铺分类删除成功");
        }

        private void LoadStoreClass(int storeId)
        {
            ViewData["storeClassList"] = AdminStores.GetStoreClassList(storeId);
            ViewData["referer"] = MallUtils.GetMallAdminRefererCookie();
        }

        #endregion


        #region 配送模板、配送费用

        /// <summary>
        /// 店铺配送模板列表
        /// </summary>
        public ActionResult StoreShipTemplateList(int storeId = -1)
        {
            StoreInfo storeInfo = AdminStores.GetStoreById(storeId);
            if (storeInfo == null)
                return PromptView("店铺不存在");

            StoreShipTemplateListModel model = new StoreShipTemplateListModel()
            {
                StoreId = storeId,
                StoreShipTemplateList = AdminStores.GetStoreShipTemplateList(storeId)
            };

            MallUtils.SetAdminRefererCookie(string.Format("{0}?storeId={1}", Url.Action("storeshiptemplatelist"), storeId));
            return View(model);
        }

        /// <summary>
        /// 店铺配送模板选择列表
        /// </summary>
        public ActionResult StoreShipTemplateSelectList(int storeId = -1)
        {
            List<StoreShipTemplateInfo> storeShipTemplateList = AdminStores.GetStoreShipTemplateList(storeId);

            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (StoreShipTemplateInfo storeShipTemplateInfo in storeShipTemplateList)
            {
                sb.AppendFormat("{0}\"id\":\"{1}\",\"title\":\"{2}\"{3},", "{", storeShipTemplateInfo.StoreSTid, storeShipTemplateInfo.Title, "}");
            }
            if (storeShipTemplateList.Count > 0)
                sb.Remove(sb.Length - 1, 1);
            sb.Append("]");

            return Content(sb.ToString());
        }

        /// <summary>
        /// 添加店铺配送模板
        /// </summary>
        [HttpGet]
        public ActionResult AddStoreShipTemplate(int storeId = -1)
        {
            StoreInfo storeInfo = AdminStores.GetStoreById(storeId);
            if (storeInfo == null)
                return PromptView("店铺不存在");

            AddStoreShipTemplateModel model = new AddStoreShipTemplateModel();
            ViewData["referer"] = MallUtils.GetMallAdminRefererCookie();
            return View(model);
        }

        /// <summary>
        /// 添加店铺配送模板
        /// </summary>
        [HttpPost]
        public ActionResult AddStoreShipTemplate(AddStoreShipTemplateModel model, int storeId = -1)
        {
            StoreInfo storeInfo = AdminStores.GetStoreById(storeId);
            if (storeInfo == null)
                return PromptView("店铺不存在");

            if (ModelState.IsValid)
            {
                StoreShipTemplateInfo storeShipTemplateInfo = new StoreShipTemplateInfo()
                {
                    StoreId = storeId,
                    Title = model.TemplateTitle,
                    Free = model.Free,
                    Type = model.Type,
                    FreeStartPrice = model.FreeStartPrice,
                    TemplateRemark = model.TemplateRemark ?? ""
                };

                int storeSTid = AdminStores.CreateStoreShipTemplate(storeShipTemplateInfo);
                if (storeSTid > 0)
                {
                    StoreShipFeeInfo storeShipFeeInfo = new StoreShipFeeInfo()
                    {
                        StoreSTid = storeSTid,
                        RegionId = "-1",
                        StartValue = model.StartValue,
                        StartFee = model.StartFee,
                        AddValue = model.AddValue,
                        AddFee = model.AddFee
                    };
                    AdminStores.CreateStoreShipFee(storeShipFeeInfo);
                    AddMallAdminLog("添加店铺配送模板", "添加店铺配送模板,店铺配送模板为:" + model.TemplateTitle);
                    return PromptView("店铺配送模板添加成功");
                }
                else
                {
                    return PromptView("店铺配送模板添加失败");
                }
            }
            ViewData["referer"] = MallUtils.GetMallAdminRefererCookie();
            return View(model);
        }

        /// <summary>
        /// 编辑店铺配送模板
        /// </summary>
        [HttpGet]
        public ActionResult EditStoreShipTemplate(int storeSTid = -1)
        {
            StoreShipTemplateInfo storeShipTemplateInfo = AdminStores.GetStoreShipTemplateById(storeSTid);
            if (storeShipTemplateInfo == null)
                return PromptView("店铺配送模板不存在");

            EditStoreShipTemplateModel model = new EditStoreShipTemplateModel();
            model.TemplateTitle = storeShipTemplateInfo.Title;
            model.Free = storeShipTemplateInfo.Free;
            model.Type = storeShipTemplateInfo.Type;
            model.FreeStartPrice = storeShipTemplateInfo.FreeStartPrice;
            model.TemplateRemark = storeShipTemplateInfo.TemplateRemark;
            model.NoSendArea = storeShipTemplateInfo.NoSendArea;
            model.NoSendCity = storeShipTemplateInfo.NoSendCity;
            ViewData["referer"] = MallUtils.GetMallAdminRefererCookie();
            return View(model);
        }

        /// <summary>
        /// 编辑店铺配送模板
        /// </summary>
        [HttpPost]
        public ActionResult EditStoreShipTemplate(EditStoreShipTemplateModel model, int storeSTid = -1)
        {
            StoreShipTemplateInfo storeShipTemplateInfo = AdminStores.GetStoreShipTemplateById(storeSTid);
            if (storeShipTemplateInfo == null)
                return PromptView("店铺配送模板不存在");

            if (ModelState.IsValid)
            {
                storeShipTemplateInfo.Title = model.TemplateTitle;
                storeShipTemplateInfo.Free = model.Free;
                storeShipTemplateInfo.Type = model.Type;
                storeShipTemplateInfo.FreeStartPrice = model.FreeStartPrice;
                storeShipTemplateInfo.TemplateRemark = model.TemplateRemark ?? "";
                storeShipTemplateInfo.NoSendArea = model.NoSendArea ?? "";
                storeShipTemplateInfo.NoSendCity = model.NoSendCity ?? "";
                AdminStores.UpdateStoreShipTemplate(storeShipTemplateInfo);
                AddMallAdminLog("修改店铺配送模板", "修改店铺配送模板,店铺配送模板ID为:" + storeSTid);
                return PromptView("店铺配送模板修改成功");
            }

            ViewData["referer"] = MallUtils.GetMallAdminRefererCookie();
            return View(model);
        }

        /// <summary>
        /// 删除店铺配送模板
        /// </summary>
        public ActionResult DelStoreShipTemplate(int storeSTid = -1)
        {
            int result = AdminStores.DeleteStoreShipTemplateById(storeSTid);
            if (result == -1)
                return PromptView("请先移除此模板下的商品");
            AddMallAdminLog("删除店铺配送模板", "删除店铺配送模板,店铺配送模板ID为:" + storeSTid);
            return PromptView("店铺配送模板删除成功");
        }


        /// <summary>
        /// 店铺配送费用列表
        /// </summary>
        public ActionResult StoreShipFeeList(int storeSTid = -1)
        {
            StoreShipTemplateInfo storeShipTemplateInfo = AdminStores.GetStoreShipTemplateById(storeSTid);
            if (storeShipTemplateInfo == null)
                return PromptView("店铺配送模板不存在");

            StoreShipFeeListModel model = new StoreShipFeeListModel()
            {
                StoreSTid = storeSTid,
                StoreId = storeShipTemplateInfo.StoreId,
                Type = storeShipTemplateInfo.Type,
                Free = storeShipTemplateInfo.Free,
                StoreShipFeeList = Stores.GetStoreShipFeeList(storeSTid)
            };
            //ViewData["referer"] = MallUtils.GetMallAdminRefererCookie();
            MallUtils.SetAdminRefererCookie(string.Format("{0}?storeSTid={1}", Url.Action("storeshipfeelist"), storeSTid));
            return View(model);
        }

        /// <summary>
        /// 添加店铺配送费用
        /// </summary>
        [HttpGet]
        public ActionResult AddStoreShipFee(int storeSTid = -1)
        {
            StoreShipTemplateInfo storeShipTemplateInfo = AdminStores.GetStoreShipTemplateById(storeSTid);
            if (storeShipTemplateInfo == null)
                return PromptView("店铺配送模板不存在");

            StoreShipFeeModel model = new StoreShipFeeModel();
            model.Type = storeShipTemplateInfo.Type;
            model.Free = storeShipTemplateInfo.Free;
            //LoadStoreShipFee(0);
            ViewData["referer"] = MallUtils.GetMallAdminRefererCookie();
            return View(model);
        }

        /// <summary>
        /// 添加店铺配送费用
        /// </summary>
        [HttpPost]
        public ActionResult AddStoreShipFee(StoreShipFeeModel model, int storeSTid = -1)
        {
            StoreShipTemplateInfo storeShipTemplateInfo = AdminStores.GetStoreShipTemplateById(storeSTid);
            if (storeShipTemplateInfo == null)
                return PromptView("店铺配送模板不存在");

            if (ModelState.IsValid)
            {
                StoreShipFeeInfo storeShipFeeInfo = new StoreShipFeeInfo()
                {
                    StoreSTid = storeSTid,
                    RegionId = model.RegionId,
                    CityId =  model.CityId ?? "",
                    StartValue = model.StartValue,
                    StartFee = model.StartFee,
                    AddValue = model.AddValue,
                    AddFee = model.AddFee,
                    ShipType = model.ShipType
                };
                AdminStores.CreateStoreShipFee(storeShipFeeInfo);
                AddMallAdminLog("添加店铺配送费用", "添加店铺配送费用");
                return PromptView("店铺配送费用添加成功");
            }
            //LoadStoreShipFee(model.RegionId);
            ViewData["referer"] = MallUtils.GetMallAdminRefererCookie();
            return View(model);
        }

        /// <summary>
        /// 编辑店铺配送费用
        /// </summary>
        [HttpGet]
        public ActionResult EditStoreShipFee(int recordId = -1, int storeSTid = -1)
        {
            StoreShipFeeInfo storeShipFeeInfo = AdminStores.GetStoreShipFeeById(recordId);
            StoreShipTemplateInfo storeShipTemplateInfo = AdminStores.GetStoreShipTemplateById(storeSTid);
            if (storeShipFeeInfo == null)
                return PromptView("店铺配送费用不存在");

            StoreShipFeeModel model = new StoreShipFeeModel();
            model.RegionId = storeShipFeeInfo.RegionId;
            model.CityId = storeShipFeeInfo.CityId;
            model.StartValue = storeShipFeeInfo.StartValue;
            model.StartFee = storeShipFeeInfo.StartFee;
            model.AddValue = storeShipFeeInfo.AddValue;
            model.AddFee = storeShipFeeInfo.AddFee;
            model.ShipType = storeShipFeeInfo.ShipType;

            model.RegionName = storeShipFeeInfo.RegionId == "-1" ? "默认地区" : Regions.GetRegionNamesByregionids(storeShipFeeInfo.RegionId, storeShipFeeInfo.CityId);

            model.Type = storeShipTemplateInfo.Type;
            model.Free = storeShipTemplateInfo.Free;
            //LoadStoreShipFee(model.RegionId);
            ViewData["referer"] = MallUtils.GetMallAdminRefererCookie();
            return View(model);
        }

        /// <summary>
        /// 编辑店铺配送费用
        /// </summary>
        [HttpPost]
        public ActionResult EditStoreShipFee(StoreShipFeeModel model, int recordId = -1)
        {
            StoreShipFeeInfo storeShipFeeInfo = AdminStores.GetStoreShipFeeById(recordId);
            if (storeShipFeeInfo == null)
                return PromptView("店铺配送费用不存在");

            if (ModelState.IsValid)
            {
                storeShipFeeInfo.RegionId = model.RegionId;
                storeShipFeeInfo.StartValue = model.StartValue;
                storeShipFeeInfo.StartFee = model.StartFee;
                storeShipFeeInfo.AddValue = model.AddValue;
                storeShipFeeInfo.AddFee = model.AddFee;
                storeShipFeeInfo.ShipType = model.ShipType;
                storeShipFeeInfo.CityId = model.CityId ?? "";
                AdminStores.UpdateStoreShipFee(storeShipFeeInfo);
                AddMallAdminLog("修改店铺配送费用", "修改店铺配送费用,店铺配送费用ID为:" + recordId);
                return PromptView("店铺配送费用修改成功");
            }

            //LoadStoreShipFee(model.RegionId);
            ViewData["referer"] = MallUtils.GetMallAdminRefererCookie();
            return View(model);
        }

        /// <summary>
        /// 删除店铺配送费用
        /// </summary>
        public ActionResult DelStoreShipFee(int recordId = -1)
        {
            StoreShipFeeInfo storeShipFeeInfo = AdminStores.GetStoreShipFeeById(recordId);
            if (storeShipFeeInfo == null)
                return PromptView("店铺配送费用不存在");
            if (storeShipFeeInfo.RegionId == "-1")
                return PromptView("默认店铺配送费用不能删除");

            AdminStores.DeleteStoreShipFeeById(recordId);
            AddMallAdminLog("删除店铺配送费用", "删除店铺配送费用,店铺配送费用ID为:" + recordId);
            return PromptView("店铺配送费用删除成功");
        }

        private void LoadStoreShipFee(int regionId)
        {
            RegionInfo regionInfo = Regions.GetRegionById(regionId);
            if (regionInfo != null)
            {
                if (regionInfo.Layer == 1)
                {
                    ViewData["provinceId"] = regionInfo.ProvinceId;
                    ViewData["cityId"] = 0;
                }
                else
                {
                    RegionInfo parentRegionInfo = Regions.GetRegionById(regionInfo.ParentId);
                    ViewData["provinceId"] = parentRegionInfo.ProvinceId;
                    ViewData["cityId"] = regionInfo.RegionId;
                }
            }
            else
            {
                ViewData["provinceId"] = 0;
                ViewData["cityId"] = 0;
            }

            ViewData["referer"] = MallUtils.GetMallAdminRefererCookie();
        }

        /// <summary>
        /// 省份选择列表
        /// </summary>
        /// <param name="brandName">频道名称</param>
        /// <param name="pageSize">每页数</param>
        /// <param name="pageNumber">当前页数</param>
        /// <returns></returns>
        public ContentResult SelectList(int pageNumber = 1, int pageSize = 34)
        {
            List<RegionInfo> regionList = Regions.GetProvinceList().OrderBy(x => x.RegionId).ToList();
            PageModel pageModel = new PageModel(pageSize, pageNumber, regionList.Count);


            StringBuilder result = new StringBuilder("{");
            result.AppendFormat("\"totalPages\":\"{0}\",\"pageNumber\":\"{1}\",\"items\":[", pageModel.TotalPages, pageModel.PageNumber);

            foreach (RegionInfo info in regionList)
            {
                result.AppendFormat("{0}\"id\":\"{1}\",\"name\":\"{2}\",\"citys\":[", "{", info.RegionId, info.Name.TrimEnd());
                List<RegionInfo> citys = Regions.GetCityList(info.RegionId);
                foreach (RegionInfo item in citys)
                {
                    result.AppendFormat("{0}\"cityid\":\"{1}\",\"cityname\":\"{2}\"{3},", "{", item.RegionId, item.Name.TrimEnd(), "}");
                }

                result.Append("]},");
            }
            if (regionList.Count > 0)
                result.Remove(result.Length - 1, 1);

            result.Append("]}");
            return Content(result.ToString());
        }

        #endregion
    }
}
