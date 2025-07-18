using UnityEngine;

public interface IStackable
{
    Transform GetStackPivot();
    void OnStacked();
    void OnUnstacked();
}