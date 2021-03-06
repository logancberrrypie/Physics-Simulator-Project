﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newParticle : MonoBehaviour {

    //Varaible storing all instances of particles which have been created
    public static List<newParticle> ParticleInstances = new List<newParticle>();

    //Variables which can be composed for the particle
    public enum Properties
    {
        MyGameObject, 
        ParticlePrefabs,
        ParticleSprites,
        displacement,
        initialVelocity,
        currentVelocity,
        acceleration,
        motionTime,
        initialPosition,
        key,
        numberOfInputs,
        invalidInput,
        diameter,
        restitution,
        mass,
        gravity,
        collisions,
        graphingValuesSpeed,
        graphingValuesAcceleration,
        graphingValuesDistance,
        graphingValuesMomentumX,
        graphingValuesMomentumY,
    }
    //Adding properties to the particle of type propertyType
    public void AddParticlePropery(Properties propertyType)
    {
        ObjectProperties[propertyType] = null;
    }

    //Dictionary storing values of properties which have been added
    public Dictionary<Properties, object> ObjectProperties = new Dictionary<Properties, object>();

    #region Properties States
    //Varaibles look up to determine if the particle has the property whihc is stored in the dictionary
    //Returns true or false
    public bool hasMyGameObject => ObjectProperties.ContainsKey(Properties.MyGameObject);
    public bool hasParticlePrefabs => ObjectProperties.ContainsKey(Properties.ParticlePrefabs);
    public bool hasParticleSprites => ObjectProperties.ContainsKey(Properties.ParticleSprites);

    public bool hasDisplacement => ObjectProperties.ContainsKey(Properties.displacement);
    public bool hasInitialVelocity => ObjectProperties.ContainsKey(Properties.initialVelocity);
    public bool hasCurrentVelocity => ObjectProperties.ContainsKey(Properties.currentVelocity);
    public bool hasAcceleration => ObjectProperties.ContainsKey(Properties.acceleration);
    public bool hasMotionTime => ObjectProperties.ContainsKey(Properties.motionTime);

    public bool hasKey => ObjectProperties.ContainsKey(Properties.key);
    public bool hasNumberOfInputs => ObjectProperties.ContainsKey(Properties.numberOfInputs);
    public bool hasInvalidInput => ObjectProperties.ContainsKey(Properties.invalidInput);

    public bool hasDiameter => ObjectProperties.ContainsKey(Properties.diameter);
    public bool hasRestitution => ObjectProperties.ContainsKey(Properties.restitution);
    public bool hasMass => ObjectProperties.ContainsKey(Properties.mass);
    public bool hasInitialPosition => ObjectProperties.ContainsKey(Properties.initialPosition);

    public bool hasGraphingValuesSpeed => ObjectProperties.ContainsKey(Properties.graphingValuesSpeed);
    public bool hasGraphingValuesAcceleration => ObjectProperties.ContainsKey(Properties.graphingValuesAcceleration);
    public bool hasGraphingValuesMomentumX => ObjectProperties.ContainsKey(Properties.graphingValuesMomentumX);
    public bool hasGraphingValuesMomentumY => ObjectProperties.ContainsKey(Properties.graphingValuesMomentumY);
    public bool hasGraphingValuesDistance => ObjectProperties.ContainsKey(Properties.graphingValuesDistance);

    public bool hasGravity => ObjectProperties.ContainsKey(Properties.gravity);
    public bool hasCollisions => ObjectProperties.ContainsKey(Properties.collisions);

    #endregion

    #region Prefabs and GameObjects
    //Reference to gameobject of THE particle
    public GameObject MyGameObject
    {
        get
        {
            if (hasMyGameObject)
            {
                return ObjectProperties[Properties.MyGameObject] as GameObject;
            }
            else { throw new NotSupportedException("This particle has no Gameobject"); }
        }
        set
        {
            if (hasMyGameObject)
            {
                ObjectProperties[Properties.MyGameObject] = value;
            }
            else { throw new NotSupportedException("This particle has no Gameobject"); }
        }
    }
    //Particle prefabs to be initilized from
    public List<GameObject> ParticlePrefabs
    {
        get
        {
            if (hasParticlePrefabs)
            {
                return ObjectProperties[Properties.ParticlePrefabs] as List<GameObject>;
            }
            else { throw new NotSupportedException("This particle has Particle Prefabs"); }
        }
        set
        {
            if (hasParticlePrefabs)
            {
                if (ObjectProperties[Properties.ParticlePrefabs] == null)
                {
                    ObjectProperties[Properties.ParticlePrefabs] = new List<GameObject>();
                }
                ObjectProperties[Properties.ParticlePrefabs] = value;

            }
            else { throw new NotSupportedException("This particle has no Particle Prefabs"); }
        }
    }
    //Particle sprites to choose from (used for gravity)
    public UnityEngine.Object[] ParticleSprites
    {
        get
        {
            if (hasParticleSprites)
            {
                return ObjectProperties[Properties.ParticleSprites] as UnityEngine.Object[];
            }
            else { throw new NotSupportedException("This particle has Particle Sprites"); }
        }
        set
        {
            if (hasParticleSprites)
            {
                ObjectProperties[Properties.ParticleSprites] = value;
            }
            else { throw new NotSupportedException("This particle has no Particle Sprites"); }
        }
    }
    #endregion

    #region SUVATR variables 
    public Vector3 displacement
    {
        get
        {
            if (hasDisplacement)
            {
                //Casts return type as Vector3 from object
                return (Vector3)ObjectProperties[Properties.displacement];
            }
            //exception thrown when program attempts to call displacement if the particle does not have displacement as a varaible
            else { throw new NotSupportedException("This particle has Particle Displacement"); }
        }
        set
        {
            if (hasDisplacement)
            {
                //Changes value to the inputs
                ObjectProperties[Properties.displacement] = value;
            }
            //exception thrown when user attempts to call displacement if the particle does not have displacement as a varaible
            else { throw new NotSupportedException("This particle has no Displacement"); }
        }
    }

    public Vector3 initialVelocity
    {
        get
        {
            if (hasInitialVelocity)
            {
                return (Vector3)ObjectProperties[Properties.initialVelocity];
            }
            else { throw new NotSupportedException("This particle has Particle initial Velocity"); }
        }
        set
        {
            if (hasInitialVelocity)
            {
                ObjectProperties[Properties.initialVelocity] = value;
                if (hasCurrentVelocity)
                {
                    ObjectProperties[Properties.currentVelocity] = value;
                }
            }
            else { throw new NotSupportedException("This particle has no initial Velocity"); }
        }
    }

    public Vector3 currentVelocity
    {
        get
        {
            if (hasCurrentVelocity)
            {
                return (Vector3)ObjectProperties[Properties.currentVelocity];
            }
            else { throw new NotSupportedException("This particle has no current Velocity"); }
        }
        set
        {
            if (hasCurrentVelocity)
            {
                ObjectProperties[Properties.currentVelocity] = value;
            }
            else { throw new NotSupportedException("This particle has no current Velocity"); }
        }
    }

    public Vector3 acceleration
    {
        get
        {
            if (hasAcceleration)
            {
                return (Vector3)ObjectProperties[Properties.acceleration];
            }
            else { throw new NotSupportedException("This particle has Particle acceleration"); }
        }
        set
        {
            if (hasAcceleration)
            {
                ObjectProperties[Properties.acceleration] = value;
            }
            else { throw new NotSupportedException("This particle has no acceleration"); }
        }
    }

    public float motionTime
    {
        get
        {
            if (hasMotionTime)
            {
                return (float)ObjectProperties[Properties.motionTime];
            }
            else { throw new NotSupportedException("This particle has no time"); }
        }
        set
        {
            if (hasMotionTime)
            {
                ObjectProperties[Properties.motionTime] = MyMaths.Magnitude(value);
            }
            else { throw new NotSupportedException("This particle has no time"); }
        }
    }

    public Vector3 initialPosition
    {
        get
        {
            if (hasInitialPosition)
            {
                return (Vector3)ObjectProperties[Properties.initialPosition];
            }
            else { throw new NotSupportedException("This particle has initial position"); }
        }
        set
        {
            if (hasInitialPosition)
            {
                ObjectProperties[Properties.initialPosition] = value;
            }
            else { throw new NotSupportedException("This particle has no initial position"); }
        }
    }

    public string[] key
    {
        get
        {
            if (hasKey)
            {
                return (string[])ObjectProperties[Properties.key];
            }
            else { throw new NotSupportedException("This particle has no Key"); }
        }
        set
        {
            if (hasKey)
            {
                ObjectProperties[Properties.key] = value;
            }
            else { throw new NotSupportedException("This particle has no Key"); }
        }
    }

    public bool[] invalidInputs
    {
        get
        {
            if (hasInvalidInput)
            {
                return (bool[])ObjectProperties[Properties.invalidInput];
            }
            else { throw new NotSupportedException("This particle has no invalid inputs"); }
        }
        set
        {
            if (hasInvalidInput)
            {
                ObjectProperties[Properties.invalidInput] = value;
            }
            else { throw new NotSupportedException("This particle has no invalid inputs"); }
        }
    }

    public int[] numberOfInputs
    {
        get
        {
            if (hasNumberOfInputs)
            {
                return GetNumberOfInputs();
            }
            else { throw new NotSupportedException("This particle has no number of inputs"); }
        }
    }

    //Re-calculates the NumberOfInputs by using the Key
    public int[] GetNumberOfInputs()
    {
        int[] numberOfInputs = new int[3];
        int dimention;
        //for every dimention
        for (dimention = 0; dimention < 3; dimention++)
        {
            int numInputs = 0;
            //for every character
            foreach(char character in key[dimention])
            {
                //if character = '1' , meaning value has been calculated
                if (character == '1')
                {
                    //valid inputs increases by one
                    numInputs += 1;
                }
            }
            numberOfInputs[dimention] = numInputs;
        }
        return numberOfInputs;
    }

    //Sets NumberOfInputs in an index value
    public void SetNumberOfInputs(int index, int value)
    {
        //Debug.Log("Set ran");
        numberOfInputs[index] = value;
        //Debug.Log("Set wended");
    }


    //TODO Add numberOfInputs
    #endregion

    #region Diameter , restitutution , Mass

    public float restitution
    {
        get
        {
            if (hasRestitution)
            {
                return (float)ObjectProperties[Properties.restitution];
            }
            else { throw new NotSupportedException("This particle has no Restitution"); }
        }
        set
        {
            if (hasRestitution)
            {
                ObjectProperties[Properties.restitution] = MyMaths.Clamp(value,0,1);
            }
            else { throw new NotSupportedException("This particle has no Restitution"); }
        }
    }

    public float mass
    {
        get
        {
            if (hasMass)
            {
                return (float)ObjectProperties[Properties.mass];
            }
            else { throw new NotSupportedException("This particle has no mass"); }
        }
        set
        {
            if (hasMass)
            {
                ObjectProperties[Properties.mass] = MyMaths.Magnitude(value);
            }
            else { throw new NotSupportedException("This particle has no mass"); }
        }
    }

    public float diameter
    {
        get
        {
            if (hasDiameter)
            {
                return (float)ObjectProperties[Properties.diameter];
            }
            else { throw new NotSupportedException("This particle has no diameter"); }
        }
        set
        {
            if (hasDiameter)
            {
                ObjectProperties[Properties.diameter] = MyMaths.Magnitude(value);
                if (hasMyGameObject)
                {
                    (ObjectProperties[Properties.MyGameObject] as GameObject).transform.localScale = Vector3.one * diameter;
                }
            }
            else { throw new NotSupportedException("This particle has no diameter"); }
        }
    }

    #endregion

    #region HasGravity , CanCollide

    public bool gravity
    {
        get
        {
            if (hasGravity)
            {
                return (bool)ObjectProperties[Properties.gravity];
            }
            else { throw new NotSupportedException("This particle has no gravity"); }
        }
        set
        {
            if (hasGravity)
            {
                ObjectProperties[Properties.gravity] = value;
            }
            else { throw new NotSupportedException("This particle has no gravity"); }
        }
    }

    public bool collisions
    {
        get
        {
            if (hasCollisions)
            {
                return (bool)ObjectProperties[Properties.collisions];
            }
            else { throw new NotSupportedException("This particle has no collisions"); }
        }
        set
        {
            if (hasCollisions)
            {
                ObjectProperties[Properties.collisions] = value;
            }
            else { throw new NotSupportedException("This particle has no collisions"); }
        }
    }

    #endregion

    #region Graphing variables

    public List<Vector2> graphingValuesSpeed
    {
        get
        {
            if (hasGraphingValuesSpeed)
            {
                return (List<Vector2>)ObjectProperties[Properties.graphingValuesSpeed];
            }
            else { throw new NotSupportedException("This particle has no speed graph"); }
        }
        set
        {
            if (hasGraphingValuesSpeed)
            {
                ObjectProperties[Properties.graphingValuesSpeed] = value;
            }
            else { throw new NotSupportedException("This particle has no speed graph"); }
        }
    }

    public List<Vector2> graphingValuesAcceleration
    {
        get
        {
            if (hasGraphingValuesAcceleration)
            {
                return (List<Vector2>)ObjectProperties[Properties.graphingValuesAcceleration];
            }
            else { throw new NotSupportedException("This particle has no acceleration graph"); }
        }
        set
        {
            if (hasGraphingValuesAcceleration)
            {
                ObjectProperties[Properties.graphingValuesAcceleration] = value;
            }
            else { throw new NotSupportedException("This particle has no accleration graph"); }
        }
    }
    public List<Vector2> graphingValuesDistance
    {
        get
        {
            if (hasGraphingValuesDistance)
            {
                return (List<Vector2>)ObjectProperties[Properties.graphingValuesDistance];
            }
            else { throw new NotSupportedException("This particle has no distance graph"); }
        }
        set
        {
            if (hasGraphingValuesDistance)
            {
                ObjectProperties[Properties.graphingValuesDistance] = value;
            }
            else { throw new NotSupportedException("This particle has no distance graph"); }
        }
    }

    public List<Vector2> graphingValuesMomentumX
    {
        get
        {
            if (hasGraphingValuesMomentumX)
            {
                return (List<Vector2>)ObjectProperties[Properties.graphingValuesMomentumX];
            }
            else { throw new NotSupportedException("This particle has no momentum X graph"); }
        }
        set
        {
            if (hasGraphingValuesMomentumX)
            {
                ObjectProperties[Properties.graphingValuesMomentumX] = value;
            }
            else { throw new NotSupportedException("This particle has no momentum X graph"); }
        }
    }

    public List<Vector2> graphingValuesMomentumY
    {
        get
        {
            if (hasGraphingValuesMomentumY)
            {
                return (List<Vector2>)ObjectProperties[Properties.graphingValuesMomentumY];
            }
            else { throw new NotSupportedException("This particle has no momentum Y graph"); }
        }
        set
        {
            if (hasGraphingValuesMomentumY)
            {
                ObjectProperties[Properties.graphingValuesMomentumY] = value;
            }
            else { throw new NotSupportedException("This particle has no momentum Y graph"); }
        }
    }

    #endregion

    #region Gravity only methods

    //Controls the instatiation process of creating the particle
    private void CreateGravityObject()
    {
        //Creates references for the ParticlePrefabs and ParticleSprites
        CreateGravityPlanetReferences();
        //Only one prefab for Gravity
        GameObject planetObject = Instantiate(ParticlePrefabs[0]) as GameObject;
        //Centered on the screen
        planetObject.transform.position = new Vector3(0, 1, 0);
        MyGameObject = planetObject;
        //Gets random number
        System.Random generator = new System.Random();
        int index = generator.Next(0, ParticleSprites.Length - 1);
        //Random sprite is seected from the list
        MyGameObject.GetComponent<SpriteRenderer>().sprite = ParticleSprites[index] as Sprite;
        //Default value
        diameter = 0.25f;

        //Assigns particles index value to the attached script 
        //This is used when performing collision calculations
        MyGameObject.GetComponent<newCollisionsController>().particleIndex = ParticleInstances.Count;
    }

    //Creates sprite and prefab references 
    private void CreateGravityPlanetReferences()
    {
        //Initializes prefabs list
        ParticlePrefabs = new List<GameObject>();
        if (hasParticlePrefabs)
        {
            //Loads prefab for the gravity particle
            ParticlePrefabs.Add(Resources.Load("GravityEarth") as GameObject);
        }
        if (hasParticleSprites)
        {
            //loads sprites which are used for the gravity (diffrent planet texture) from the folder
            //"Planet_Sprites" and only type of Sprite
            ParticleSprites = Resources.LoadAll("Planet_Sprites", typeof(Sprite));
        }
    }
    //Creates then returns a particle with properties for the gravity simulator
    public static newParticle CreateGravityParticle()
    {
        newParticle particle = new newParticle();
        particle.AddParticlePropery(newParticle.Properties.MyGameObject);
        particle.AddParticlePropery(newParticle.Properties.ParticlePrefabs);
        particle.AddParticlePropery(newParticle.Properties.ParticleSprites);
        particle.AddParticlePropery(newParticle.Properties.initialVelocity);
        particle.AddParticlePropery(newParticle.Properties.currentVelocity);
        particle.AddParticlePropery(newParticle.Properties.diameter);
        particle.AddParticlePropery(newParticle.Properties.restitution);
        particle.AddParticlePropery(newParticle.Properties.mass);
        particle.AddParticlePropery(newParticle.Properties.gravity);
        particle.AddParticlePropery(newParticle.Properties.collisions);
        particle.AddParticlePropery(newParticle.Properties.graphingValuesAcceleration);
        particle.AddParticlePropery(newParticle.Properties.graphingValuesSpeed);

        //Creates the gameobject for the gravity particle
        particle.CreateGravityObject();
        particle.graphingValuesAcceleration = new List<Vector2>();
        particle.graphingValuesSpeed = new List<Vector2>();

        //Sets initial values for the gravity particle (defaults)
        particle.initialVelocity = Vector3.zero;
        particle.diameter = 0.25f;
        particle.restitution = 1;
        particle.mass = 1.0f;
        particle.gravity = true;
        particle.collisions = true;
        //returns particle which has been created
        return particle;
    }

    #endregion

    #region Collisions Particles
    //Method which creates a Collisions particle 
    //Adds required properties
    //Sets default values
    //Create GameObject scene
    public static newParticle CreateCollisionsParticle()
    {
        //Properties added to the particle
        newParticle particle = new newParticle();
        particle.AddParticlePropery(newParticle.Properties.MyGameObject);
        particle.AddParticlePropery(newParticle.Properties.ParticlePrefabs);
        particle.AddParticlePropery(newParticle.Properties.initialVelocity);
        particle.AddParticlePropery(newParticle.Properties.currentVelocity);
        particle.AddParticlePropery(newParticle.Properties.diameter);
        particle.AddParticlePropery(newParticle.Properties.restitution);
        particle.AddParticlePropery(newParticle.Properties.mass);
        particle.AddParticlePropery(newParticle.Properties.collisions);
        particle.AddParticlePropery(newParticle.Properties.graphingValuesMomentumX);
        particle.AddParticlePropery(newParticle.Properties.graphingValuesMomentumY);

        //Creates gameobject for the scene
        particle.CreateCollisionsObject();
        particle.graphingValuesMomentumX = new List<Vector2>();
        particle.graphingValuesMomentumY = new List<Vector2>();

        //Default values
        particle.initialVelocity = Vector3.zero;
        particle.diameter = 0.25f;
        particle.restitution = 1;
        particle.mass = 1.0f;
        particle.collisions = true;
        //returns particle
        return particle;
    }
    //Controls the instatiation process of creating the particle
    private void CreateCollisionsObject()
    {
        CreateCollisionsParticleReference();

        GameObject particleObject = Instantiate(ParticlePrefabs[0]) as GameObject;

        //Centers prefab to middle of scene
        particleObject.transform.position = new Vector3(0, 1, 0);
        //Assigns object to this instance
        MyGameObject = particleObject;
        //Assigns particles index value to the attached script 
        //This is used when performing collision calculations
        particleObject.GetComponent<newCollisionsController>().particleIndex = newParticle.ParticleInstances.Count;
    }

    //Creates sprite and prefab references 
    private void CreateCollisionsParticleReference()
    {
        //Instatiates list
        ParticlePrefabs = new List<GameObject>();
        if (hasParticlePrefabs)
        {
            //Creates collisions prefab reference
            ParticlePrefabs.Add(Resources.Load("CollisionsSphere") as GameObject);
        }
    }

    #endregion

    #region Suvat Particles
    //Method which creates a Suvat particle 
    //Adds required properties
    //Sets default values
    //Create GameObject scene
    public static newParticle CreateSuvatParticle()
    {
        //Adding suvat properties
        newParticle particle = new newParticle();
        particle.AddParticlePropery(newParticle.Properties.MyGameObject);
        particle.AddParticlePropery(newParticle.Properties.ParticlePrefabs);
        particle.AddParticlePropery(newParticle.Properties.displacement);
        particle.AddParticlePropery(newParticle.Properties.initialVelocity);
        particle.AddParticlePropery(newParticle.Properties.currentVelocity);
        particle.AddParticlePropery(newParticle.Properties.acceleration);
        particle.AddParticlePropery(newParticle.Properties.motionTime);
        particle.AddParticlePropery(newParticle.Properties.key);
        particle.AddParticlePropery(newParticle.Properties.numberOfInputs);
        particle.AddParticlePropery(newParticle.Properties.invalidInput);
        particle.AddParticlePropery(newParticle.Properties.initialPosition);
        particle.AddParticlePropery(newParticle.Properties.diameter);
        particle.AddParticlePropery(newParticle.Properties.restitution);
        particle.AddParticlePropery(newParticle.Properties.mass);
        particle.AddParticlePropery(newParticle.Properties.graphingValuesSpeed);
        particle.AddParticlePropery(newParticle.Properties.graphingValuesDistance);

        //Creates the gameObject
        particle.CreateSuvatObject();

        //Assigns default values
        particle.displacement = new Vector3();
        particle.initialVelocity = new Vector3();
        particle.currentVelocity = new Vector3();
        particle.acceleration = new Vector3();
        particle.initialPosition = new Vector3();

        //Initialises variables
        particle.key = new string[] {"00000","00000","00000"};
        particle.invalidInputs = new bool[] { false, false, false };
        particle.graphingValuesSpeed = new List<Vector2>();
        particle.graphingValuesDistance = new List<Vector2>();
        //returns the particle which has been created
        return particle;
    }
    //Creates the gameobject for the scene which is repesenting the particle
    private void CreateSuvatObject()
    {
        //Creates prefab and sprite references
        CreateSuvatObjectReference();
        //Creates object
        GameObject particleObject = Instantiate(ParticlePrefabs[0]) as GameObject;

        //Assigns object to this instance
        MyGameObject = particleObject;
        //Assigns particles index value to the attached script 
        //This is used when performing collision calculations
        particleObject.GetComponent<newCollisionsController>().particleIndex = ParticleInstances.Count;
    }
    //Creates references with the prefab and sprites
    private void CreateSuvatObjectReference()
    {
        //Initializes the list
        ParticlePrefabs = new List<GameObject>();
        if (hasParticlePrefabs)
        {
            //Adds the prefab for Suvat
            ParticlePrefabs.Add(Resources.Load("Sphere") as GameObject);
        }
    }




    #endregion


}
