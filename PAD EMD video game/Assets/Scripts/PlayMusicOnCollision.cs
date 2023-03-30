using UnityEngine;

public class PlayMusicOnCollision : MonoBehaviour
{
    public AudioClip musicClip;
    private AudioSource audioSource;


    private void Start()
    {
        // Ajoutez un AudioSource au GameObject et désactivez la lecture automatique
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.playOnAwake = false;


    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     // Si le joueur traverse le déclencheur, faites tomber la capsule
    //     if (other.gameObject == triggerObject)
    //     {
    //         rb.isKinematic = false;
    //     }
    // }

    private void OnCollisionEnter(Collision collision)
    {
        // Si la capsule touche le joueur, faites-la disparaître et jouez la musique
        if (collision.gameObject.CompareTag("Player"))
        {

            audioSource.Play();
        }
    }
}
