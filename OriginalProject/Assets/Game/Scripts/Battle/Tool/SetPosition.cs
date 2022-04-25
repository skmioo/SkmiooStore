using System.Collections.Generic;
using UnityEngine;

public class Offset : MonoBehaviour
{
    public string name;
    public int id;
}

public class SetPosition : Offset
{
    [System.Serializable]
    public class Data
    {
        public Vector3 offset;
        public float time;
        public AnimationCurve curv = AnimationCurve.Linear(0f, 1f, 0f, 1f);
    }

    public List<Data> offsets = new List<Data>();
}
