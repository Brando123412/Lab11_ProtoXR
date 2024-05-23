using UnityEngine;

[CreateAssetMenu(fileName = "ParticleSO", menuName = "ParticleSO/ParticleSO")]
public class ParticleSO : ScriptableObject
{

    [SerializeField] private Color color;
    [SerializeField] private Material material;
    [SerializeField] private float speed;
    [SerializeField] private AnimationCurve curveAnimation;

    public Color Color => color;
    public Material Material => material;
    public AnimationCurve CurveAnimation => curveAnimation;
    public float Speed => speed;
    public Vector3 Move(Vector3 position, Vector3 direction, float speed)
    {
        return position + direction * speed;
    }
}
