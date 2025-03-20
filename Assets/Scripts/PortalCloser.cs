using UnityEngine;

public class PortalCloser : MonoBehaviour
{
    public CountdownTimer CountdownTimer;
    [SerializeField] Material _material;
    [SerializeField] MeshRenderer _meshRenderer;
    [SerializeField] int materialIndex = 1;

    void OnEnable() => CountdownTimer.timeUp += UpdateCM;
    void OnDisable() => CountdownTimer.timeUp -= UpdateCM;

    void UpdateCM()
    {
        Material[] materials = _meshRenderer.materials; 
        if (materialIndex >= 0 && materialIndex < materials.Length)
        {
            materials[materialIndex] = new Material(_material); 
            _meshRenderer.materials = materials;
        }
    }
}
