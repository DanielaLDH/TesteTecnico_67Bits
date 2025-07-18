using UnityEngine;

public class SellZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StackEnemies stackEnemies = other.GetComponentInChildren<StackEnemies>();

            if (stackEnemies != null)
                stackEnemies.RemoveOnStack();

        }
    }
}
