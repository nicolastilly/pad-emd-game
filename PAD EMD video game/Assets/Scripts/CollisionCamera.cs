using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class CollisionCamera : MonoBehaviour
{
    public GameObject sphere;

    // Le nom de la scène vers laquelle nous voulons changer
    public string sceneToLoad;


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "ecran")
                {
                    Debug.Log(hit.transform.name);
                    SceneManager.LoadScene("sceneI_Yoan");

                }
            }

        }

    }




    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "collision_camera")
        {
            //SceneManager.LoadScene("sceneI_Yoan");
            Debug.Log("OKLOL");

            // Change de scène
            //SceneManager.LoadScene("sceneI_Yoan");

        }



    }
}
