using UnityEngine;
using UnityEngine.UI;

namespace UYMO
{
    public class ProgressBar:MonoBehaviour
    {
        public Image background;
        public Image front;
        public Image posEffect;
        public float PreEndBlank;
        public Text label;

        void Start()
        {
            
        }

        public float progress
        {
            get
            {
                if( front == null )
                {
                    return 0;
                }
                float ret = front.rectTransform.sizeDelta.x / clientWidth;
                return Mathf.Clamp(ret, 0, 1);
            }
            set
            {
                if(front)
                {
                    Vector2 pos = front.rectTransform.anchoredPosition;
                    pos.x = PreEndBlank;
                    front.rectTransform.anchoredPosition = pos;

                    float prg = Mathf.Clamp(value, 0, 1);
                    Vector2 size = front.rectTransform.sizeDelta;
                    size.x = clientWidth * prg;
                    front.rectTransform.sizeDelta = size;

                    if( posEffect )
                    {
                        Vector2 efPos = posEffect.rectTransform.anchoredPosition;
                        efPos.x = size.x;
                        posEffect.rectTransform.anchoredPosition = efPos;
                    }
                }
            }
        }

        public string text
        {
            get
            {
                return label ? label.text : "";
            }
            set
            {
                if( label )
                {
                    label.text = value;
                }
            }
        }

        private float clientWidth
        {
            get
            {
                return background.rectTransform.sizeDelta.x - PreEndBlank * 2;
            }
        }
    }
}
