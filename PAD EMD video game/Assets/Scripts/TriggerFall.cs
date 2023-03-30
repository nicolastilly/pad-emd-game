using UnityEngine;

public class TriggerFall : MonoBehaviour
{
    public GameObject capsuleToFall;
    private Rigidbody capsuleRb;

    private void Start()
    {
        // Récupérez le composant Rigidbody de la capsule
        capsuleRb = capsuleToFall.GetComponent<Rigidbody>();

        // Si la capsule n'a pas de composant Rigidbody, en ajoutez un et activez l'option "Is Kinematic"
        if (capsuleRb == null)
        {
            capsuleRb = capsuleToFall.AddComponent<Rigidbody>();
            capsuleRb.isKinematic = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si le cube est en contact avec le joueur, désactivez l'option "Is Kinematic" pour faire tomber la capsule
        if (other.CompareTag("Player"))
        {
            capsuleRb.isKinematic = false;
        }
    }
}
