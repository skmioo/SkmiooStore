
/// <summary>
/// 物品类型
/// </summary>
public enum ObjType
{
    饰品,圣物,物品,勋章,宝物
}

/// <summary>
/// 品级类型
/// </summary>
public enum LevelType
{
    起源,稀有,精良,残缺,消耗品,资源,普通
}

/// <summary>
/// 勋章类型
/// </summary>
public enum MedalType
{
    白骨勋章,青石勋章,赤银勋章,黑金勋章,血髓勋章,原黯勋章
}

/// <summary>
/// 掉落类型/掉落方式/拥有者类型
/// </summary>
public enum OwnerType
{
    BOSS,所有,交互_怪物,怪物,交互
}

/// <summary>
/// 起效限制
/// </summary>
public enum ObjLimitType
{
    无, 生命值大于等于, 生命值小于, 使用特定技能后的一回合, 奇数回合, 偶数回合, 处于某个位置, 回合数等于1, 特定职业,每次任务仅生效一次
}

/// <summary>
/// 圣物所属区域
/// </summary>
public enum SacredArea
{
    世界=0,镂空之地,冥河矿洞
}

/// <summary>
/// 交互物类型
/// </summary>
public enum InteractiveType
{
    经文,冥想台,祭坛,解救,地下游商
}
/// <summary>
/// 经文类型
/// </summary>
public enum ScriptureType {
    疗愈经文, 提振经文, 未知经文
}
/// <summary>
/// 祭坛类型
/// </summary>
public enum AltarType
{
    贪婪祭坛,愚昧祭坛
}

/// <summary>
/// 祭坛奖励类型
/// </summary>
public enum AltarRewardType
{
    无,鳞片,普通饰品,精良饰品,稀有饰品,起源饰品,上级祝福,下级祝福
}

/// <summary>
/// 解救事件类型
/// </summary>
public enum RescueType
{
    猎头,老千,商人,饰品贩子,矿工
}
/// <summary>
/// 解救事件 结果类型
/// </summary>
public enum RescueResultType {
    reward,fight
}