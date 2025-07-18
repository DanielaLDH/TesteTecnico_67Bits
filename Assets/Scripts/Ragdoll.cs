using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    private Rigidbody[] ragRigidBodies;
    private Collider[] ragColliders;
    private Animator anim;

    void Awake()
    {
        ragRigidBodies = GetComponentsInChildren<Rigidbody>(true);
        ragColliders = GetComponentsInChildren<Collider>(true);
        anim = GetComponentInChildren<Animator>();

        DisableRagdoll(); // Default state is non-ragdoll
    }

    //Enables ragdoll physics by disabling animator and activating colliders + rigidbodies.
    public void EnableRagdoll()
    {
        anim.enabled = false;

        foreach(var rb in ragRigidBodies)
            rb.isKinematic = false;

        foreach (var col in ragColliders)
            col.enabled = true;
    }

    // Disables ragdoll physics and optionally re-enables the Animator
    public void DisableRagdoll(bool enableAnim = true)
    {
        if(anim != null)
        {
            anim.enabled = enableAnim;
        }

        foreach(var rb in ragRigidBodies)
            rb.isKinematic = true;

        foreach (var col in ragColliders)

            if (col.gameObject != gameObject)
            {
                col.enabled = false;
            }
    }

}
