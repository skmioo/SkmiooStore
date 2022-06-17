using System;
using UnityEngine.Events;
using UnityEngine.Rendering;

namespace UnityEngine.UI
{
    //MaskableGraphic
    //找到父对象中的RectMask2D组件 该组件可以被RectMask2D进行裁剪
    //https://blog.csdn.net/ecidevilin/article/details/52555253
    /// <summary>
    /// A Graphic that is capable of being masked out.（屏蔽图形遮罩）
    /// </summary>
    public abstract class MaskableGraphic : Graphic, IClippable, IMaskable, IMaterialModifier
    {
        /// <summary>
        /// 是否需要重新计算模板
        /// OnTransformParentChanged（当父对象改变）和OnCanvasHierarchyChanged（当画布层次改变）方法
        /// 这些方法间接继承自UIBehavior。这些方法里都设置了m_ShouldRecalculateStencil（是否需要重新计算模板）为true，
        [NonSerialized]
        protected bool m_ShouldRecalculateStencil = true;

        [NonSerialized]
        protected Material m_MaskMaterial;

        [NonSerialized]
        private RectMask2D m_ParentMask;

        //m_Maskable表示是否这个图形允许被屏蔽，它具有可屏蔽的公共属性
        //m_Maskable默认值是true，因此掩码下的图形会被屏蔽掉。
        // 如果不需要屏蔽，用户可以从脚本中关闭可屏蔽属性。
        [NonSerialized]
        private bool m_Maskable = true;

        [NonSerialized]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [Obsolete("Not used anymore.", true)]
        protected bool m_IncludeForMasking = false;

        [Serializable]
        public class CullStateChangedEvent : UnityEvent<bool> {}

        // Event delegates triggered on click.
        [SerializeField]
        private CullStateChangedEvent m_OnCullStateChanged = new CullStateChangedEvent();

        /// <summary>
        /// Callback issued when culling changes.
        /// </summary>
        /// <remarks>
        /// Called whene the culling state of this MaskableGraphic either becomes culled or visible. You can use this to control other elements of your UI as culling happens.
        /// </remarks>
        public CullStateChangedEvent onCullStateChanged
        {
            get { return m_OnCullStateChanged; }
            set { m_OnCullStateChanged = value; }
        }

        /// <summary>
        /// Does this graphic allow masking.
        /// </summary>
        public bool maskable
        {
            get { return m_Maskable; }
            set
            {
                if (value == m_Maskable)
                    return;
                m_Maskable = value;
                m_ShouldRecalculateStencil = true;
                SetMaterialDirty();
            }
        }

        [NonSerialized]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [Obsolete("Not used anymore", true)]
        protected bool m_ShouldRecalculate = true;

        /// <summary>
        /// 模板深度值
        /// MaskUtilities.GetStencilDepth(transform, s_RootCanvas)
        /// </summary>
        [NonSerialized]
        protected int m_StencilValue;

        /// <summary>
        /// IMaterialModifier接口 Graphic调用，用于重建图像时，或许修改过的材质。
		/// 更改材质
        /// See IMaterialModifier.GetModifiedMaterial
        /// </summary>
        public virtual Material GetModifiedMaterial(Material baseMaterial)
        {
            var toUse = baseMaterial;
            //如果需要重算模板，便会从根画布（或者父对象中overrideSorting为true的Canvas）获取模板的深度。
            if (m_ShouldRecalculateStencil)
            {
                //获取模板的深度
                //简单来讲就是从本对象往上找，找到一个图像有效的Mask组件，便深度加1，
                var rootCanvas = MaskUtilities.FindRootSortOverrideCanvas(transform);
                m_StencilValue = maskable ? MaskUtilities.GetStencilDepth(transform, rootCanvas) : 0;
                m_ShouldRecalculateStencil = false;
            }

            // if we have a enabled Mask component then it will
            // generate the mask material. This is an optimisation
            // it adds some coupling between components though :(
            //如果深度大于零，且本对象含有Mask组件，便将baseMaterial（即当前的material）加入StencilMaterial，
            //并移除旧的m_MaskMaterial。最后，替换m_MaskMaterial并返回（似乎m_MaskMaterial这个变量只是为了从StencilMaterial移除才存在的）。
            Mask maskComponent = GetComponent<Mask>();
            if (m_StencilValue > 0 && (maskComponent == null || !maskComponent.IsActive()))
            {
                var maskMat = StencilMaterial.Add(toUse, (1 << m_StencilValue) - 1, StencilOp.Keep, CompareFunction.Equal, ColorWriteMask.All, (1 << m_StencilValue) - 1, 0);
                StencilMaterial.Remove(m_MaskMaterial);
                m_MaskMaterial = maskMat;
                toUse = m_MaskMaterial;
            }
            return toUse;
        }

        /// <summary>
        /// IClippable 
		/// 检测并设置是否剔除
		/// 进行剔除操作
		/// MaskUtilities中一个方法是GetRectMasksForClip，这个方法将自己和父对象中的所有有效的RectMask2D组件打包给m_Clippers.
		/// Clipping的FindCullAndClipWorldRect方法将这些m_Clippers的canvasRect求交集，得到一个最小的裁剪区域（如果这个裁剪区域不合理，validRect便为false）。
        /// 接着，如果新的出来的clipRect与旧的不同，那么遍历m_ClipTargets，为他们设置裁剪区域，就是我们前面讲的SetClipRect。最后调用所有IClippable的剔除方法（前面讲的Cull）。
        /// See IClippable.Cull
        /// </summary>
        public virtual void Cull(Rect clipRect, bool validRect)
        {
            //如果输入参数validRect为false或者输入的clipRect与所属Canvas的矩形区域不重合，cull为true，剔除不显示
            var cull = !validRect || !clipRect.Overlaps(rootCanvasRect, true);
            UpdateCull(cull);
        }

        private void UpdateCull(bool cull)
        {
            //每个ui都会自带一个CanvasRenderer
            if (canvasRenderer.cull != cull)
            {
                //设置CanvasRenderer为剔除
                canvasRenderer.cull = cull;
                UISystemProfilerApi.AddMarker("MaskableGraphic.cullingChanged", this);
                //发送剔除变化通知
                m_OnCullStateChanged.Invoke(cull);
                //重新绘制
                OnCullingChanged();
            }
        }

        /// <summary>
        /// IClippable  
		/// 根据输入validRect为canvasRenderer开启或关闭矩形裁剪
		/// 设置裁剪区域
        /// See IClippable.SetClipRect
        /// </summary>
        public virtual void SetClipRect(Rect clipRect, bool validRect)
        {
            if (validRect)
                canvasRenderer.EnableRectClipping(clipRect);
            else
                canvasRenderer.DisableRectClipping();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            m_ShouldRecalculateStencil = true;
            UpdateClipParent();
            SetMaterialDirty();

            if (GetComponent<Mask>() != null)
            {
                MaskUtilities.NotifyStencilStateChanged(this);
            }
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            m_ShouldRecalculateStencil = true;
            SetMaterialDirty();
            UpdateClipParent();
            StencilMaterial.Remove(m_MaskMaterial);
            m_MaskMaterial = null;

            if (GetComponent<Mask>() != null)
            {
                MaskUtilities.NotifyStencilStateChanged(this);
            }
        }

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();
            m_ShouldRecalculateStencil = true;
            UpdateClipParent();
            SetMaterialDirty();
        }

#endif

        protected override void OnTransformParentChanged()
        {
            base.OnTransformParentChanged();

            if (!isActiveAndEnabled)
                return;

            m_ShouldRecalculateStencil = true;
            UpdateClipParent();
            SetMaterialDirty();
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [Obsolete("Not used anymore.", true)]
        public virtual void ParentMaskStateChanged() {}

        protected override void OnCanvasHierarchyChanged()
        {
            base.OnCanvasHierarchyChanged();

            if (!isActiveAndEnabled)
                return;

            m_ShouldRecalculateStencil = true;
            UpdateClipParent();
            SetMaterialDirty();
        }

        readonly Vector3[] m_Corners = new Vector3[4];
        private Rect rootCanvasRect
        {
            get
            {
                rectTransform.GetWorldCorners(m_Corners);

                if (canvas)
                {
                    Matrix4x4 mat = canvas.rootCanvas.transform.worldToLocalMatrix;
                    for (int i = 0; i < 4; ++i)
                        m_Corners[i] = mat.MultiplyPoint(m_Corners[i]);
                }

                // bounding box is now based on the min and max of all corners (case 1013182)

                Vector2 min = m_Corners[0];
                Vector2 max = m_Corners[0];
                for (int i = 1; i < 4; i++)
                {
                    min.x = Mathf.Min(m_Corners[i].x, min.x);
                    min.y = Mathf.Min(m_Corners[i].y, min.y);
                    max.x = Mathf.Max(m_Corners[i].x, max.x);
                    max.y = Mathf.Max(m_Corners[i].y, max.y);
                }

                return new Rect(min, max - min);
            }
        }

        /// <summary>
        /// 更新裁剪的父对象
        /// 找到父对象中的RectMask2D组件
        /// </summary>
        private void UpdateClipParent()
        {
            //GetRectMaskForClippable 从父对象中找到RectMask2D组件
            var newParent = (maskable && IsActive()) ? MaskUtilities.GetRectMaskForClippable(this) : null;

            // if the new parent is different OR is now inactive
            if (m_ParentMask != null && (newParent != m_ParentMask || !newParent.IsActive()))
            {
                m_ParentMask.RemoveClippable(this);
                UpdateCull(false);
            }

            // don't re-add it if the newparent is inactive
            if (newParent != null && newParent.IsActive())
                newParent.AddClippable(this);

            m_ParentMask = newParent;
        }

        /// <summary>
        /// IClippable 更新裁剪RectMask2D
		/// 它在MaskUtilities中的Notify2DMaskStateChanged被调用（遍历RectMask2D的所有子对象，找到IClippable接口的组件，调用RecalculateClipping方法）
		/// 这个方法是在RectMask2D的OnEnable、OnDisable以及编辑器模式下的OnValidate方法中被调用。
		/// OnValidate方法在Inspector 中的任何值被修改时调用
		/// https://blog.csdn.net/piai9568/article/details/96645500?spm=1001.2101.3001.6661.1&utm_medium=distribute.pc_relevant_t0.none-task-blog-2%7Edefault%7ECTRLIST%7Edefault-1-96645500-blog-106568528.pc_relevant_blogantidownloadv1&depth_1-utm_source=distribute.pc_relevant_t0.none-task-blog-2%7Edefault%7ECTRLIST%7Edefault-1-96645500-blog-106568528.pc_relevant_blogantidownloadv1&utm_relevant_index=1
        /// See IClippable.RecalculateClipping
        /// </summary>
        public virtual void RecalculateClipping()
        {
            UpdateClipParent();
        }

        /// <summary>
        /// See IMaskable.RecalculateMasking
        /// IMaskable接口
		/// MaskableGraphic继承了IMaskable，需要实现RecalculateMasking方法
		/// 这个方法会在MaskUtilities中调用，用于图像的遮罩。
		/// 方法名为NotifyStencilStateChanged（遍历Mask的所有子对象，找到IMaskable接口的组件，调用RecalculateMasking方法），在Mask的OnEnable、OnDisable以及编辑器模式下的OnValidate方法中被调用。
        /// </summary>
        public virtual void RecalculateMasking()
        {
            // Remove the material reference as either the graphic of the mask has been enable/ disabled.
            // This will cause the material to be repopulated from the original if need be. (case 994413)
            StencilMaterial.Remove(m_MaskMaterial);
            m_MaskMaterial = null;
            m_ShouldRecalculateStencil = true;
            SetMaterialDirty();
        }
    }
}
