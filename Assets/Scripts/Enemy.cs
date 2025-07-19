using UnityEngine;

[RequireComponent (typeof(Ragdoll))]
public class Enemy : MonoBehaviour, IStackable
{
    private Transform stackPivot;
    private Ragdoll ragdoll;

    public bool IsDead {  get; private set; }

    void Awake()
    {
        ragdoll = GetComponent<Ragdoll>();
        if (stackPivot == null)
            stackPivot = transform.Find("Boy/mixamorig:Hips");

    }

    public void Damage()
    {
        if (IsDead) return;
        ragdoll.EnableRagdoll();
        IsDead = true;
    }

    public void ResetState()
    {
        IsDead = false;
        ragdoll.DisableRagdoll() ;

        transform.rotation = Quaternion.Euler(0, Random.Range(0, 190), 0);

    }

    public Transform GetStackPivot()
    {
        return stackPivot;
    }

    public void OnStacked()
    {
        ragdoll.DisableRagdoll(false);
    }

    public void OnUnstacked()
    {
        ragdoll.EnableRagdoll();
    }
}
