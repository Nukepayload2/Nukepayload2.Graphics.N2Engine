# Nukepayload2.Graphics.N2Engine
<h3>适用于Win2D的图形框架</h3><br />
<h4>version 1.0.571 alpha</h4><br />
<h5>目前的版本是早期版本，仍然会有巨大改动</h5><br />
<h6>这份源代码使用Ms-PL协议进行公开</h6><br />
<a href="https://msdn.microsoft.com/zh-cn/vstudio/bb894665.aspx">https://msdn.microsoft.com/zh-cn/vstudio/bb894665.aspx</a>
依赖：
<dlv>
    <li>
        Universal Windows
    </li>
    <li>
        Microsoft.NetCore.UniversalWindowsPlatform >= 5.0
    </li>
    <li>
        Win2D >= 1.16
    </li>
    <li>
        Newtonsoft.Json >= 8.0
    </li>
    <li>
        SQLite for Universal Windows Platform
    </li>
    <li>
        SQLite.Net-PCL >= 3.1.0
    </li>
    <li>
        Visual C++ 2015 Runtime for Universal Windows Platform Apps
    </li>
    <li>
        MathNet.Numerics >= 3.11.0
    </li>
    <li>
        SQLite.Net.Async-PCL >= 3.1.1
    </li>
    <li>
        SQLiteNetExtensions >= 1.3.0
    </li>
    <li>
        SQLiteNetExtensions.Async >= 1.3.0
    </li>
</dlv>
整体进度：<br />
<h3>模型</h3><br />
<table>
    <thead>
        <tr>
            <th>
                功能
            </th>
            <th>
                完成情况
            </th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>
                静态元素
            </td>
            <td>
                测试通过
            </td>
        </tr>
        <tr>
            <td>
                动态元素
            </td>
            <td>
                测试通过
            </td>
        </tr>
        <tr>
            <td>
                虚拟化元素
            </td>
            <td>
                构思中
            </td>
        </tr>
        <tr>
            <td>
                基础粒子系统
            </td>
            <td>
                完善中
            </td>
        </tr>
        <tr>
            <td>
                火焰粒子系统
            </td>
            <td>
                测试通过
            </td>
        </tr>
        <tr>
            <td>
                火花粒子系统
            </td>
            <td>
                测试通过
            </td>
        </tr>
        <tr>
            <td>
                气雾粒子系统
            </td>
            <td>
                等待测试
            </td>
        </tr>
        <tr>
            <td>
                轨道炮粒子系统
            </td>
            <td>
                测试通过
            </td>
        </tr>
        <tr>
            <td>
                烟雾粒子系统
            </td>
            <td>
                等待测试
            </td>
        </tr>
        <tr>
            <td>
                碎片粒子系统
            </td>
            <td>
                等待测试
            </td>
        </tr>
        <tr>
            <td>
                电弧粒子系统
            </td>
            <td>
                等待测试
            </td>
        </tr>
        <tr>
            <td>
                伤害，装甲，免疫和弹头
            </td>
            <td>
                编写中
            </td>
        </tr>
        <tr>
            <td>
                碰撞检测
            </td>
            <td>
                已使用Box2D
            </td>
        </tr>
        <tr>
            <td>
                动画系统
            </td>
            <td>
                编写中
            </td>
        </tr>
        <tr>
            <td>
                图块表
            </td>
            <td>
                编写中
            </td>
        </tr>
        <tr>
            <td>
                带光照的背景
            </td>
            <td>
                测试失败：光照效果在特定角度漏光
            </td>
        </tr>
    </tbody>
</table>
<h3>视图模型</h3><br />
<table>
    <thead>
        <tr>
            <th>
                功能
            </th>
            <th>
                完成情况
            </th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>
                面板
            </td>
            <td>
                测试通过
            </td>
        </tr>
    </tbody>
</table>
<h3>视图</h3><br />
<table>
    <thead>
        <tr>
            <th>
                功能
            </th>
            <th>
                完成情况
            </th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>
                普通画布
            </td>
            <td>
                测试通过
            </td>
        </tr>
        <tr>
            <td>
                滚动画布
            </td>
            <td>
                测试失败：鼠标滚轮的行为异常, 画面缩放到最小的行为异常，触摸屏拖动事件处理失败。
            </td>
        </tr>
        <tr>
            <td>
                虚拟化画布
            </td>
            <td>
                构思中
            </td>
        </tr>
        <tr>
            <td>
                键盘，触摸和鼠标输入
            </td>
            <td>
                完善中
            </td>
        </tr>
        <tr>
            <td>
                声音输出
            </td>
            <td>
                编写中
            </td>
        </tr>
        <tr>
            <td>
                UWP 设计器
            </td>
            <td>
                编写中
            </td>
        </tr>
        <tr>
            <td>
                拓展特效
            </td>
            <td>
                完善中
            </td>
        </tr>
    </tbody>
</table>
<h4>
    版本编码规则
</h4>
<h5>
    Major 目前主版本号都是 1
</h5>
<h5>
    Minor 目前副版本号都是 0
</h5>
<h5>
    Path 按以下规则编码。如果较高位增加，则会清空较低位的数据。
</h5>
<table>
    <thead>
        <tr>
            <th>
                功能
            </th>
            <th>
                掩码
            </th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>
                实现Method级别功能, 比如写了某种判定方法。
            </td>
            <td>
                127
            </td>
        </tr>
        <tr>
            <td>
                实现Class级别功能, 表示一个Class的功能已经确定并基本实现
            </td>
            <td>
                384
            </td>
        </tr>
        <tr>
            <td>
                实现Namespace级别功能, 表示一个Namespace下面的内容以后不会轻易改变
            </td>
            <td>
                1536
            </td>
        </tr>
        <tr>
            <td>
                实现Assembly级别功能, 这通常指示一个程序集写完了。
            </td>
            <td>
                6144
            </td>
        </tr>
        <tr>
            <td>
                实现跨Runtime级别功能
            </td>
            <td>
                24576
            </td>
        </tr>
    </tbody>
</table>
<h5>
    Revision 按以下规则编码。如果较高位增加，则会清空较低位的数据。Revision 可能不会每次更新都会公开。
</h5>
<table>
    <thead>
        <tr>
            <th>
                功能
            </th>
            <th>
                掩码
            </th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>
                最初设计
            </td>
            <td>
                0
            </td>
        </tr>
        <tr>
            <td>
                较大的重构计数
            </td>
            <td>
                255
            </td>
        </tr>
        <tr>
            <td>
                拼合稳定化代码计数
            </td>
            <td>
                16128
            </td>
        </tr>
    </tbody>
</table>