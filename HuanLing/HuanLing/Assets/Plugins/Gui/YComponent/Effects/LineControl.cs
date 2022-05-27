using System.Collections.Generic;
using SLua;

namespace UnityEngine.UI
{
    public struct YUILineInfo
    {
        //
        // 摘要:
        //     Height of the line.
        public int height;
        //
        // 摘要:
        //     Index of the first character in the line.
        public int startCharIdx;

        //
        // 摘要:
        //     Index of the end character in the line.
        public int endCharIdx;

        //
        // 摘要:
        //     offset of the line.
        public float offset;
    }

    public class LineControlInfo
    {
        /// <summary>
        /// 所有行信息
        /// </summary>
        public List<YUILineInfo> lines;
        /// <summary>
        /// image所在行编号
        /// </summary>
        public HashSet<int> imageLines;

        /// <summary>
        /// 加入图片后的总偏移量
        /// </summary>
        public float totalOffset;

        public LineControlInfo(TextGenerator textGen)
        {
            imageLines = new HashSet<int>();

            var lines = textGen.lines;
            this.lines = new List<YUILineInfo>(textGen.lineCount);
            for (int i = 0; i < lines.Count; ++i)
            {
                var yline = new YUILineInfo();
                yline.height = lines[i].height;
                yline.startCharIdx = lines[i].startCharIdx;
                if (i + 1 >= lines.Count)
                {
                    yline.endCharIdx = textGen.characterCount - 2;
                }
                else
                {
                    yline.endCharIdx = lines[i + 1].startCharIdx - 1;
                }
                this.lines.Add(yline);
            }
        }

        /// <summary>
        /// 检查image所在行
        /// </summary>
        /// <param name="imagePos">image 字符位置</param>
        /// <returns></returns>
        public int CheckImageLine(int imagePos)
        {
            int lineIndex = -1;
            for (int i = 0; i < lines.Count; ++i)
            {
                var yline = lines[i];
                if(imagePos >= yline.startCharIdx && imagePos <= yline.endCharIdx)
                {
                    lineIndex = i;
                    if (!imageLines.Contains(i))
                    {
                        imageLines.Add(i);
                    }
                }
            }
            return lineIndex;
        }

        /// <summary>
        /// 创建LineControl数据
        /// </summary>
        /// <param name="imageExtraHeight">image需要额外的高度</param>
        /// <param name="alignment">label的对齐方式</param>
        public void BuildInfo(float imageExtraHeight, TextAnchor alignment)
        {
            
            totalOffset = 0;

            if (alignment == TextAnchor.UpperCenter || alignment == TextAnchor.UpperLeft || alignment == TextAnchor.UpperRight)
            {
                // 从上到下
                for (int i = 0; i < lines.Count; ++i)
                {
                    var line = lines[i];
                    if (i > 0 && imageLines.Contains(i - 1))
                        totalOffset -= imageExtraHeight / 2;
                    if (imageLines.Contains(i))
                        totalOffset -= imageExtraHeight / 2;
                    line.offset = totalOffset;
                    lines[i] = line;
                }
                totalOffset = -totalOffset;
            }
            else if(alignment == TextAnchor.LowerCenter || alignment == TextAnchor.LowerLeft || alignment == TextAnchor.LowerRight)
            {
                // 从下到上
                for (int i = lines.Count - 1; i >= 0; --i)
                {
                    var line = lines[i];
                    if (i < lines.Count - 1 && imageLines.Contains(i + 1))
                        totalOffset += imageExtraHeight / 2;
                    if (imageLines.Contains(i))
                        totalOffset += imageExtraHeight / 2;
                    line.offset = totalOffset;
                    lines[i] = line;
                }
            }
            else if (alignment == TextAnchor.MiddleCenter || alignment == TextAnchor.MiddleLeft || alignment == TextAnchor.MiddleRight)
            {
                // 从上到下
                int mid = lines.Count / 2;
                float partOffset = 0;
                for (int i = mid; i < lines.Count; ++i)
                {
                    var line = lines[i];
                    if (i > mid && imageLines.Contains(i - 1))
                        partOffset -= imageExtraHeight / 2;
                    if (imageLines.Contains(i))
                        partOffset -= imageExtraHeight / 2;
                    line.offset = partOffset;
                    lines[i] = line;
                }
                totalOffset = -partOffset;
                partOffset = 0;

                // 从下到上
                for (int i = mid - 1; i >= 0; --i)
                {
                    var line = lines[i];
                    if (i < mid - 1 && imageLines.Contains(i + 1))
                        partOffset += imageExtraHeight / 2;
                    if (imageLines.Contains(i))
                        partOffset += imageExtraHeight / 2;
                    line.offset = partOffset;
                    lines[i] = line;
                }
                totalOffset += partOffset;
            }
        }
    }
    /// <summary>
    /// 文字行高控制
    /// </summary>
    public class LineControl : BaseMeshEffect
    {
        public LineControlInfo controlInfo;

        public override void ModifyMesh(VertexHelper vh)
        {
            if (!IsActive())
                return;

            if (controlInfo == null)
            {
                return;
            }

            for(int i = 0; i < controlInfo.lines.Count; ++i)
            {
                var lineInfo = controlInfo.lines[i];
                if (lineInfo.offset == 0)
                {
                    continue;
                }
                int beginVertexIndex = lineInfo.startCharIdx * 4;
                int endVertexIndex = lineInfo.endCharIdx * 4 + 3; //换行符号不是4个顶点
                for (int j = beginVertexIndex; j <= endVertexIndex; ++j)
                {
                    UIVertex newVertex = new UIVertex();
                    vh.PopulateUIVertex(ref newVertex, j);
                    newVertex.position = new Vector3(newVertex.position.x, newVertex.position.y + lineInfo.offset, newVertex.position.z);
                    vh.SetUIVertex(newVertex, j);
                }
            }
        }
    }
}