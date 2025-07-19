using UnityEngine;

public class PlayerColor : MonoBehaviour
{

    [SerializeField] private Renderer playerRenderer;
    [SerializeField] private Material[] upgradeMaterials;

    public void UpgradeColor(int level)
    {
        if (level >= 0 && level < upgradeMaterials.Length)
        {
            playerRenderer.material = upgradeMaterials[level];
        }
    }
}
