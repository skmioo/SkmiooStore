
namespace UYMO
{
    public interface ISpriteUser
    {
        /// <summary>
        /// ʹ�õ�ͼƬ�Ƿ��Ѿ�׼���׵�
        /// </summary>
        bool imageReady { get; }
        /// <summary>
        /// ���ڳ��е�ͼƬid�б�
        /// </summary>
        ResID[] imageHold { get; }
    }
}
