using UnityEngine;

public class ObjectVisibilityController : MonoBehaviour
{
    public CubeManager cubeManager;
    public GameObject objectToReplace;
    public GameObject replacement; // Remplacez 'public GameObject replacementPrefab' par 'public GameObject replacement'

    private void Start()
    {
        cubeManager.OnCombinationChanged += HandleCombinationChanged;
    }

    private void OnDestroy()
    {
        cubeManager.OnCombinationChanged -= HandleCombinationChanged;
    }

    private void HandleCombinationChanged(bool isCorrect)
    {
        if (isCorrect)
        {
            ShowReplacement();
        }
    }

    private void ShowReplacement()
    {
        // Activez le GameObject de remplacement
        replacement.SetActive(true);

        // Détruire l'objet actuel
        Destroy(objectToReplace);
    }
}
