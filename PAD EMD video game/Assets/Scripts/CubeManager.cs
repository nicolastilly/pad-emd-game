using System;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public DragAndDrop[] cubes;

    public event Action<bool> OnCombinationChanged;

    private bool isCombinationCorrect;

    private void Start()
    {
        foreach (DragAndDrop cube in cubes)
        {
            cube.OnCombinationChanged += HandleCombinationChanged;
        }
    }

    private void OnDestroy()
    {
        foreach (DragAndDrop cube in cubes)
        {
            cube.OnCombinationChanged -= HandleCombinationChanged;
        }
    }

    private void HandleCombinationChanged(bool isCorrect)
    {
        if (isCorrect && !isCombinationCorrect)
        {
            isCombinationCorrect = true;
            OnCombinationChanged?.Invoke(true);
        }
        else if (!isCorrect && isCombinationCorrect)
        {
            isCombinationCorrect = false;
            OnCombinationChanged?.Invoke(false);
        }
    }
}
