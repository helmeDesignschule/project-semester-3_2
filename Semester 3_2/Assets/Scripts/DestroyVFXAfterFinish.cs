using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class DestroyVFXAfterFinish : MonoBehaviour
{
    private ParticleSystem particleSystem;

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (particleSystem.IsAlive())
            return;
        
        Destroy(gameObject);
    }
}
