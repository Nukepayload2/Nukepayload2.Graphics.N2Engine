Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class WorldBuilderSidebarViewModel
        Public ReadOnly Property Items As New ObservableCollection(Of WorldBuilderSidebarModel)
        Sub New()

            'Items.Add(New WorldBuilderSidebarModel("障碍物", {
            '                                       New TerrainItem("颜色实体方块"),
            '                                       New TerrainItem("线性渐变实体方块"),
            '                                       New TerrainItem("径向渐变实体方块"),
            '                                       New TerrainItem("贴图实体方块"),
            '                                       New TerrainItem("图块表贴图实体方块")
            '                                       }))
            'Items.Add(New WorldBuilderSidebarModel("装饰物xxxx", {
            '                                       New TerrainItem("颜色装饰方块"),
            '                                       New TerrainItem("线性渐变装饰方块"),
            '                                       New TerrainItem("径向渐变装饰方块"),
            '                                       New TerrainItem("贴图装饰方块"),
            '                                       New TerrainItem("图块表贴图装饰方块")
            '                                       }))
            'Items.Add(New WorldBuilderSidebarModel("标记", {
            '                                       New TerrainItem("触发区域"),
            '                                       New TerrainItem("路径点")
            '                                       }))
            'Items.Add(New WorldBuilderSidebarModel("机关", {
            '                                       New TerrainItem("不带锁的门"),
            '                                       New TerrainItem("带锁的门"),
            '                                       New TerrainItem("拉杆"),
            '                                       New TerrainItem("按钮"),
            '                                       New TerrainItem("箱子"),
            '                                       New TerrainItem("踏板"),
            '                                       New TerrainItem("刷怪箱"),
            '                                       New TerrainItem("投掷器"),
            '                                       New TerrainItem("发射器"),
            '                                       New TerrainItem("命令方块")
            '                                       }))
            'Items.Add(New WorldBuilderSidebarModel("场景道具", {
            '                                       New TerrainItem("箭矢"),
            '                                       New TerrainItem("大石块"),
            '                                       New TerrainItem("文字提示"),
            '                                       New TerrainItem("火焰弹"),
            '                                       New TerrainItem("长矛"),
            '                                       New TerrainItem("门的钥匙")
            '                                       }))
            'Items.Add(New WorldBuilderSidebarModel("粒子系统", {
            '                                       New TerrainItem("喷火"),
            '                                       New TerrainItem("大字火"),
            '                                       New TerrainItem("火花"),
            '                                       New TerrainItem("烟雾"),
            '                                       New TerrainItem("轨道炮")
            '                                       }))
            'Items.Add(New WorldBuilderSidebarModel("光照", {
            '                                       New TerrainItem("点光源")
            '                                       }))
            'Items.Add(New WorldBuilderSidebarModel("单位", {
            '                                       New TerrainItem("秦始皇"),
            '                                       New TerrainItem("伤害测试者"),
            '                                       New TerrainItem("动画测试者"),
            '                                       New TerrainItem("小强"),
            '                                       New TerrainItem("镐子杂鱼")
            '                                       }))
        End Sub
    End Class
End Namespace
