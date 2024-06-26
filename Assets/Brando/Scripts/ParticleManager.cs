using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public List<ParticleSO> particleSO;
    private List<Particle> particles = new List<Particle>();
    [SerializeField] private Mesh particleObject;
    [SerializeField] CustomVector position;
    [SerializeField] CustomVector direction;
    [SerializeField] float timeRepeting;
    [SerializeField] float lifeTimeParticle;
    [SerializeField] bool playOnAwake;
    [SerializeField] float timeParticleLook;

    private void Start()
    {
        if(playOnAwake)
            InvokeRepeating("InicialParticle", 0, timeRepeting);
    }

    private void Update()
    {
        float deltaTime = Time.deltaTime;
        UpdateParticles(deltaTime);
        RenderParticles();
        if (timeParticleLook <= Time.time)
        {
            CancelInvoke("InicialParticle");
        }
    }
    private void InicialParticle()
    {
        CreateParticle(position.RandomVector(), particleSO[0], lifeTimeParticle);
    }
    public void CreateParticle(Vector3 position, ParticleSO soParticle, float lifetime)
    {
        Particle particle = new Particle(position, lifetime, soParticle, particleObject, direction.RandomVector());
        particles.Add(particle);
    }

    public void UpdateParticles(float deltaTime)
    {
        for (int i = particles.Count - 1; i >= 0; i--)
        {
            particles[i].Update(deltaTime);
            if (particles[i].Lifetime <= 0)
            {
                particles.RemoveAt(i);
            }
        }
    }

    public void RenderParticles()
    {
        foreach (var particle in particles)
        {
            particle.Render();
        }
    }


}


[System.Serializable]
public struct CustomVector
{
    public AxisMovement AxisX;
    public AxisMovement AxisY;
    public AxisMovement AxisZ;
    public Vector3 RandomVector()
    {
        return new Vector3(AxisX.GetRandomMovementAxis(), AxisY.GetRandomMovementAxis(), AxisZ.GetRandomMovementAxis());
    }
}
[System.Serializable]
public struct AxisMovement
{
    public float minAxis;
    public float maxAxis;
    public float GetRandomMovementAxis()
    {
        return Random.Range(minAxis, maxAxis);
    }
}
