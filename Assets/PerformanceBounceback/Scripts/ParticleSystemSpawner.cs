using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemSpawner : MonoBehaviour
{
    public static ParticleSystemSpawner current;

    public List<ParticleSystem> pooledParticles;
    public static int psPoolNum = 0;

	void Awake ()
    {
        current = this;
	}

    private ParticleSystem GetPooledParticleSystem()
    {
        psPoolNum = ( psPoolNum + 1 ) % pooledParticles.Count;
        return pooledParticles[psPoolNum];
    }

	public void SpawnParticleSystem( Vector3 position )
    {
        ParticleSystem currentParticles = ParticleSystemSpawner.current.GetPooledParticleSystem();
        currentParticles.transform.position = position;
        currentParticles.Play();
    }
}
