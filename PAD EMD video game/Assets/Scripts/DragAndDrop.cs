using UnityEngine;
using System; // Ajoutez cette ligne


public class DragAndDrop : MonoBehaviour
{
    public enum CubeColor
    {
        Red,
        Green,
        Yellow
    }

    public CubeColor cubeColor;
    public SphereController sphereController;

   
    private Vector3 offset;
    private float zCoord;
    private Rigidbody rb;
    private Vector3 previousPosition;
    private Vector3 currentVelocity;


    public event Action<bool> OnCombinationChanged; // Ajoutez cet événement

  

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPos();
        rb.isKinematic = true;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        previousPosition = transform.position;
        transform.position = GetMouseWorldPos() + offset;
        currentVelocity = (transform.position - previousPosition) / Time.deltaTime;
    }

    private void OnMouseUp()
    {
        rb.isKinematic = false;
        rb.velocity = currentVelocity;
        Invoke("CheckStackCompletion", 0.5f);
    }

    private void CheckStackCompletion()
    {

        RaycastHit hit;
        Vector3 rayOrigin = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        bool isStackedCorrectly = false;

        if (Physics.Raycast(rayOrigin, Vector3.down, out hit))
        {
            DragAndDrop otherCube = hit.collider.gameObject.GetComponent<DragAndDrop>();

            if (otherCube != null)
            {
                if (cubeColor == CubeColor.Yellow && otherCube.cubeColor == CubeColor.Green)
                {
                    RaycastHit hit2;
                    Vector3 rayOrigin2 = new Vector3(otherCube.transform.position.x, otherCube.transform.position.y + 0.5f, otherCube.transform.position.z);

                    if (Physics.Raycast(rayOrigin2, Vector3.down, out hit2))
                    {
                        DragAndDrop bottomCube = hit2.collider.gameObject.GetComponent<DragAndDrop>();

                        if (bottomCube != null && bottomCube.cubeColor == CubeColor.Red)
                        {
                            isStackedCorrectly = true;
                        }
                    }


                    if (isStackedCorrectly)
        {
            Debug.Log("La combinaison est correcte !");
            sphereController.ShowSphere();
            OnCombinationChanged?.Invoke(true); // Déclenchez l'événement avec 'true'
        }
        else
        {
            OnCombinationChanged?.Invoke(false); // Déclenchez l'événement avec 'false'
        }



                }
            }
        }

        if (isStackedCorrectly)
        {
            Debug.Log("La combinaison est correcte !");
            sphereController.ShowSphere();
        }
    }
}

