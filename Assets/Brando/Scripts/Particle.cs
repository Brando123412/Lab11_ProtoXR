using UnityEngine;

public class Particle
{
    public Vector3 Position { get; private set; }
    public float Lifetime { get; private set; }
    private readonly ParticleSO SOparticle;
    private GameObject particleObject1 =new();
    public Vector3 Direction { get; private set; }

    public Particle(Vector3 position, float lifetime, ParticleSO flyweight, Mesh particleObject, Vector3 direction)
    {
        particleObject1.AddComponent<MeshFilter>();
        particleObject1.AddComponent<MeshRenderer>();
        particleObject1.GetComponent<MeshFilter>().mesh = particleObject;
        Direction = direction;
        Position = position;
        Lifetime = lifetime;
        this.SOparticle = flyweight;
        
        this.particleObject1.transform.position = Position;
        this.particleObject1.GetComponent<Renderer>().material = flyweight.Material;
        this.particleObject1.GetComponent<Renderer>().material.color = flyweight.Color;

    }

    public void Update(float deltaTime)
    {
        Lifetime -= deltaTime;
        Position += Vector3.up * SOparticle.Speed * deltaTime;
        particleObject1.transform.position = Position;
        particleObject1.transform.position = SOparticle.Move(Position, Direction, SOparticle.Speed);
        if (Lifetime <= 0)
        {
            GameObject.Destroy(particleObject1);
        }
    }

    public void Render()
    {
        particleObject1.transform.position = Position;
        particleObject1.GetComponent<Renderer>().material = SOparticle.Material;
        particleObject1.GetComponent<Renderer>().material.color = SOparticle.Color;
    }
}
