using System;
using System.Collections.Generic;
using System.Text;

namespace LuciusLiang.MyShops.DataModel.Infrastructure
{
    /// <summary>
    /// 侧边栏菜单数据模型
    /// </summary>
    public class SidebarMenuDTO
    {
        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// i18n主键
        /// </summary>
        public string I18n { get; set; }

        /// <summary>
        /// 是否菜单组
        /// </summary>
        public bool Group { get; set; }

        /// <summary>
        /// 路由
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// 路由是否精准匹配，默认：false
        /// </summary>
        public bool LinkExact { get; set; }

        /// <summary>
        /// 外部链接
        /// </summary>
        public string ExternalLink { get; set; }

        /// <summary>
        /// 链接 target 
        /// TODO: 暂不知用途
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 徽标数，展示的数字。（注：`group:true` 无效）
        /// </summary>
        public int Badge { get; set; }

        /// <summary>
        /// 徽标数，显示小红点
        /// </summary>
        public bool Badge_dot { get; set; }

        /// <summary>
        /// 徽标 Badge 颜色
        /// </summary>
        public string Badge_status { get; set; }

        /// <summary>
        /// 是否隐藏菜单
        /// </summary>
        public bool Hide { get; set; }

        /// <summary>
        /// 隐藏面包屑，指 "page-header" 组件的自动生成面包屑时有效
        /// </summary>
        public bool HideInBreadcrumb { get; set; }

        /// <summary>
        /// ACL配置 
        /// TODO: 暂不知用途
        /// </summary>
        public object Acl { get; set; }

        /// <summary>
        /// 是否快捷菜单项
        /// </summary>
        public bool Shortcut { get; set; }

        /// <summary>
        /// 快捷菜单根节点
        /// </summary>
        public bool Shortcut_root { get; set; }

        /// <summary>
        /// 是否允许复用，需配合 `reuse-tab` 组件
        /// </summary>
        public bool Reuse { get; set; }

        /// <summary>
        /// 二级菜单
        /// </summary>
        public  IEnumerable<SidebarMenuDTO> Children { get; set; }
    }
}
