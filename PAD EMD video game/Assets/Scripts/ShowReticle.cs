using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowReticle : MonoBehaviour
{
    // Start is called before the first frame update
    // La texture à utiliser pour le réticule
    public Texture2D reticleTexture;

    void OnGUI()
    {
        // Calcule la position du centre de l'écran
        Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);

        // Calcule la position du coin supérieur gauche de la texture
        Vector2 topLeft = center - new Vector2(reticleTexture.width / 2, reticleTexture.height / 2);

        // Affiche la texture à l'écran
        GUI.DrawTexture(new Rect(topLeft.x, topLeft.y, reticleTexture.width, reticleTexture.height), reticleTexture);
    }
}
