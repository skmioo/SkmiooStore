//This script will only work in editor mode. You cannot adjust the scale dynamically in-game!
using UnityEngine;
using System.Collections;

#if UNITY_EDITOR 
using UnityEditor;
#endif

[ExecuteInEditMode]
public class ParticleScaler : MonoBehaviour 
{
	public float particleScale = 1.0f;
	public bool alsoScaleGameobject = true;

	float prevScale;

	void Start()
	{
		prevScale = particleScale;
	}

	void Update () 
	{
#if UNITY_EDITOR 
		//check if we need to update
		if (prevScale != particleScale && particleScale > 0)
		{
			if (alsoScaleGameobject)
				transform.localScale = new Vector3(particleScale, particleScale, particleScale);

			float scaleFactor = particleScale / prevScale;

			//scale legacy particle systems
			ScaleLegacySystems(scaleFactor);

			//scale shuriken particle systems
			ScaleShurikenSystems(scaleFactor);

			//scale trail renders
			ScaleTrailRenderers(scaleFactor);

			prevScale = particleScale;
		}
#endif
	}

	void ScaleShurikenSystems(float scaleFactor)
	{
#if UNITY_EDITOR 
		//get all shuriken systems we need to do scaling on
        var systems = UYMO.UIUtil.GetParticleSystemListInChildren(gameObject, false);
		foreach (ParticleSystem system in systems)
		{
			system.startSpeed *= scaleFactor;
			system.startSize *= scaleFactor;
			system.gravityModifier *= scaleFactor;

			//some variables cannot be accessed through regular script, we will acces them through a serialized object
			SerializedObject so = new SerializedObject(system);
			
			//unity 4.0 and onwards will already do this one for us
#if UNITY_3_5 
			so.FindProperty("ShapeModule.radius").floatValue *= scaleFactor;
			so.FindProperty("ShapeModule.boxX").floatValue *= scaleFactor;
			so.FindProperty("ShapeModule.boxY").floatValue *= scaleFactor;
			so.FindProperty("ShapeModule.boxZ").floatValue *= scaleFactor;
#endif
			
			so.FindProperty("VelocityModule.x.scalar").floatValue *= scaleFactor;
			so.FindProperty("VelocityModule.y.scalar").floatValue *= scaleFactor;
			so.FindProperty("VelocityModule.z.scalar").floatValue *= scaleFactor;
			so.FindProperty("ClampVelocityModule.magnitude.scalar").floatValue *= scaleFactor;
			so.FindProperty("ClampVelocityModule.x.scalar").floatValue *= scaleFactor;
			so.FindProperty("ClampVelocityModule.y.scalar").floatValue *= scaleFactor;
			so.FindProperty("ClampVelocityModule.z.scalar").floatValue *= scaleFactor;
			so.FindProperty("ForceModule.x.scalar").floatValue *= scaleFactor;
			so.FindProperty("ForceModule.y.scalar").floatValue *= scaleFactor;
			so.FindProperty("ForceModule.z.scalar").floatValue *= scaleFactor;
			so.FindProperty("ColorBySpeedModule.range").vector2Value *= scaleFactor;
			so.FindProperty("SizeBySpeedModule.range").vector2Value *= scaleFactor;
			so.FindProperty("RotationBySpeedModule.range").vector2Value *= scaleFactor;

			so.ApplyModifiedProperties();
		}
        UYMO.ObjectPool.particleSystemListPool.Gabage(systems);
#endif
	}

	void ScaleLegacySystems(float scaleFactor)
	{
#if UNITY_EDITOR && UNITY_5
		//get all emitters we need to do scaling on
        var emitters = UYMO.UIUtil.GetComponentListInChildren<ParticleEmitter>(gameObject, false);
        var animators = UYMO.UIUtil.GetComponentListInChildren<ParticleAnimator>(gameObject, false);

		//apply scaling to emitters
		foreach (ParticleEmitter emitter in emitters)
		{
			emitter.minSize *= scaleFactor;
			emitter.maxSize *= scaleFactor;
			emitter.worldVelocity *= scaleFactor;
			emitter.localVelocity *= scaleFactor;
			emitter.rndVelocity *= scaleFactor;

			//some variables cannot be accessed through regular script, we will acces them through a serialized object
			SerializedObject so = new SerializedObject(emitter);

			so.FindProperty("m_Ellipsoid").vector3Value *= scaleFactor;
			so.FindProperty("tangentVelocity").vector3Value *= scaleFactor;
			so.ApplyModifiedProperties();
		}

		//apply scaling to animators
		foreach (ParticleAnimator animator in animators)
		{
			animator.force *= scaleFactor;
			animator.rndForce *= scaleFactor;
		}
        UYMO.ObjectPool.GabageList(emitters);
        UYMO.ObjectPool.GabageList(animators);
#endif
	}

	void ScaleTrailRenderers(float scaleFactor)
	{
		//get all animators we need to do scaling on
        var trails = UYMO.UIUtil.GetComponentListInChildren<TrailRenderer>(gameObject, true);
		//apply scaling to animators
        for (int i = 0; i < trails.Count; ++i )
        {
            var trail = trails[i];
            trail.startWidth *= scaleFactor;
            trail.endWidth *= scaleFactor;
        }
        UYMO.ObjectPool.trailRendererListPool.Gabage(trails);
	}
}
