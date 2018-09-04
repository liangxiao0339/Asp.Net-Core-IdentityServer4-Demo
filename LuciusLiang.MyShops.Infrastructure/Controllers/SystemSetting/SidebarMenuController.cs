using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

using LuciusLiang.MyShops.DataModel.Infrastructure;
using Microsoft.AspNetCore.Authorization;

namespace LuciusLiang.MyShops.Infrastructure.Controllers
{
    [Authorize]
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/SystemSetting/[controller]")]
    [ApiController]
    public class SidebarMenuController : ControllerBase
    {
        /// <summary>
        /// 获取侧边栏菜单数据
        /// </summary>
        /// <returns>侧边栏菜单集合</returns>
        [HttpGet]
        public ActionResult<IEnumerable<SidebarMenuDTO>> Get()
        {
            var sidebarMenuDTO = new SidebarMenuDTO();

            return new SidebarMenuDTO[] {
                new SidebarMenuDTO(){
                    Text = "基础架构",
                    Group = true,
                    Icon = "anticon anticon-table",
                    Link = "",
                    Children = new SidebarMenuDTO[]{
                        new SidebarMenuDTO(){
                            Text = "菜单管理",
                            Icon = "anticon anticon-table",
                            Link = "/systemSetting"
                        }
                    }
                },
                new SidebarMenuDTO(){
                    Text = "业务模块",
                    Group = true,
                    Icon = "anticon anticon-table",
                    Link = "/business",
                    Children = new SidebarMenuDTO[]{
                        new SidebarMenuDTO(){
                            Text = "库存管理",
                            Icon = "anticon anticon-table",
                            Link = "/business/inventory"
                        }
                    }
                }
            };
        }

        [HttpPost]
        public ActionResult<bool> Post([FromBody]SidebarMenuDTO sidebarMenu)
        {
            // TODO: 保存 Menu 数据

            return true;
        }

    }
}
