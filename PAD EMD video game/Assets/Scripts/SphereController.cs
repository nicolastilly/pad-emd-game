using UnityEngine;

public class SphereController : MonoBehaviour
{
    private MeshRenderer sphereRenderer;

    private void Start()
    {
        sphereRenderer = GetComponentInChildren<MeshRenderer>();
        HideSphere();
    }

    public void ShowSphere()
    {
        sphereRenderer.enabled = true;
    }

    public void HideSphere()
    {
        sphereRenderer.enabled = false;
    }
}
