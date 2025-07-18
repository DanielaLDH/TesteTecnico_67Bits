using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Tooltip("Player Animator")]
    [SerializeField] Animator anim;

    [Tooltip("StackPoint")]
    [SerializeField] StackEnemies stack;

    void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null && !enemy.IsDead)
        {
            anim.SetTrigger("isPunch");
            enemy.Damage();
            StartCoroutine(Delay(enemy.gameObject));
        }
    }

    private IEnumerator Delay(GameObject npc)
    {
        yield return new WaitForSeconds(1f);
        stack.AddOnStack(npc);

    }
}
