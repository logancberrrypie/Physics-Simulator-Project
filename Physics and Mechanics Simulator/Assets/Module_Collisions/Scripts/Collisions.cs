﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour {

    //Reference to prefab used as GameObject
	public GameObject PrefabSphere;

	//When the scene is first loaded the first particle should be in the scene ready for manipulation
	void Start () {
        //Assigns prefab to the varaible from the resources folder
		PrefabSphere = Resources.Load ("CollisionsSphere") as GameObject;
        //Generates the first object in the scene
		CreateFirstObject ();
	}

	private void CreateFirstObject()
	{
        //Assigns default values to the particle
        newParticle particle = newParticle.CreateCollisionsParticle();
		particle.initialVelocity = Vector3.zero;
		particle.mass = 1.0f;
		particle.restitution = 1.0f;
		particle.diameter = 1.0f;
        //Adds particle to the list which causes the prefab to be instatiated
        newParticle.ParticleInstances.Add (particle);
	}
}
