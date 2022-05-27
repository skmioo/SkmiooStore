
namespace UYMO
{
    public interface ISpriteUser
    {
        /// <summary>
        /// 使用的图片是否都已经准备妥当
        /// </summary>
        bool imageReady { get; }
        /// <summary>
        /// 正在持有的图片id列表
        /// </summary>
        ResID[] imageHold { get; }
    }
}
