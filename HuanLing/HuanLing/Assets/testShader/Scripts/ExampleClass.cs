using UnityEngine;

// Draws 3 meshes with the same material but with different colors.
public class ExampleClass : MonoBehaviour
{
    public Mesh mesh;
    public Material material;

    public string colorPropertyName = "_Color";

    private MaterialPropertyBlock block;
    private int colorID;

    void Start()
    {
        block = new MaterialPropertyBlock();
        colorID = Shader.PropertyToID(colorPropertyName);
    }

    void Update()
    {
        // red mesh
        block.SetColor(colorID, Color.red);
        Graphics.DrawMesh(mesh, this.transform.position + new Vector3(0, 0, 0), Quaternion.identity, material, 0, null, 0, block);

        // green mesh
        block.SetColor(colorID, Color.green);
        Graphics.DrawMesh(mesh, this.transform.position + new Vector3(2, 0, 0), Quaternion.identity, material, 0, null, 0, block);

        // blue mesh
        block.SetColor(colorID, Color.blue);
        Graphics.DrawMesh(mesh, this.transform.position + new Vector3(-2, 0, 0), Quaternion.identity, material, 0, null, 0, block);
    }
}