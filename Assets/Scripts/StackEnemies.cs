using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackEnemies : MonoBehaviour
{
    List<StackedEnemy> stack = new List<StackedEnemy>();

    [Tooltip("Vertical space between stacked enemies")]
    [SerializeField] float spaceBetween;

    [Tooltip("Maximum number of enemies in the stack")]
    [SerializeField] int stackLimit;

    [Tooltip("Reference to the PlayerMoney script for reward on removal")]
    [SerializeField] PlayerMoney playerMoney;

    private struct StackedEnemy
    {
        public GameObject gameObject;
        public Enemy enemy;

        public StackedEnemy(GameObject obj, Enemy e)
        {
            gameObject = obj;
            enemy = e;
        }
    }


    void Update()
    {
        UpdateStackEnemyPosition();

    }

    public void AddOnStack(GameObject npc)
    {
        if (stack.Count < stackLimit)
        {
            npc.transform.localRotation = Quaternion.identity;

            Enemy enemy = npc.GetComponent<Enemy>();
            enemy.OnStacked();

            stack.Add(new StackedEnemy(npc, enemy));
        }
    }

    public void RemoveOnStack()
    {
        foreach (var stacked in stack)
        {
            stacked.enemy.OnUnstacked();
            playerMoney.AddMoney(2);
            EnemyPooler.Instance.ReturnEnemy(stacked.gameObject);
        }
        stack.Clear();
    }

    void UpdateStackEnemyPosition()
    {

        for (int i = 0; i < stack.Count; i++)
        {
            GameObject npc = stack[i].gameObject;
            Enemy enemy = stack[i].enemy;

            float inertia = 30f / (i + 1);

            Transform pivot = enemy.GetStackPivot();
            Vector3 offset = -transform.forward * 2f + Vector3.up * i * spaceBetween;
            Vector3 targetPosition = transform.position + offset - (pivot.position - npc.transform.position);

            npc.transform.position = Vector3.Lerp(npc.transform.position, targetPosition, Time.deltaTime * inertia);
        }

    }

    public void IncreseStackLimit(int amount)
    {
        stackLimit += amount;
    }
}


