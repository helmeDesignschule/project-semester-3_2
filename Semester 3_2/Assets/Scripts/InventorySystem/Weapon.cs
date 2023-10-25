using UnityEngine;
using UnityEngine.Serialization;

public class Weapon : MonoBehaviour
{
    public float damage;
    public MoverBase owner;
    
    public void GetEquippedBy(MoverBase owner)
    {
        this.owner = owner;
    }
    
    public virtual void StartShooting()
    {
    }

    public virtual void StopShooting()
    {
    }

    public virtual void Reload()
    {
    }
}
