using System.Collections.Generic;
using GreatWall.Menus;
using Microsoft.AspNetCore.Mvc;
using Util.Webs.Controllers;

namespace GreatWall.Apis.Tests {
    /// <summary>
    /// 菜单控制器
    /// </summary>
    public class MenuController : WebApiControllerBase {
        /// <summary>
        /// 获取应用程序数据
        /// </summary>
        [HttpGet]
        public IActionResult GetAppData() {
            var data = new AppData {
                App = { Name = "GreatWall", Description = ".Net Core权限系统" },
                User = { Name = "何镇汐", Avatar = "/assets/img/avatar.jpg", Email = "xiadao521@qq.com" },
                Menu = new List<MenuInfo> {
                    GetMainMenu(),
                    GetDemoMenu()
                }
            };
            return Success( data );
        }

        /// <summary>
        /// 获取主导航菜单
        /// </summary>
        private MenuInfo GetMainMenu() {
            return new MenuInfo {
                Text = "主菜单",
                Group = true,
                HideInBreadcrumb = true,
                Children = {
                    new MenuInfo {
                        Text = "仪表盘",
                        Icon = "anticon anticon-dashboard",
                        Children = {
                            new MenuInfo {
                                Text = "默认页",
                                Icon = "anticon anticon-dashboard",
                                Link = "/dashboard/v1",
                            }
                        }
                    }
                }
            };
        }

        /// <summary>
        /// 获取系统菜单
        /// </summary>
        private MenuInfo GetDemoMenu() {
            return new MenuInfo {
                Text = "系统菜单",
                Group = true,
                Children = {
                    new MenuInfo {
                        Text = "应用程序",
                        Icon = "cloud",
                        Link = "/systems/application"
                    }
                }
            };
        }
    }
}