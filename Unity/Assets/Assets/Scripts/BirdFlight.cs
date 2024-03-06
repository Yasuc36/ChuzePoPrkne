using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BirdFlight : MonoBehaviour
{
    // Takes care for bird behavior, like behavior in a flock, travel system etc.

    public GameObject birds;
    public GameObject[] startPoints;
    public GameObject[] endPoints;
    public float flightSpeed;
    public float maxFlocks;
    public float spawnInterval;
    float lastSpawn;

    public Toggle toggleIsNight;

    class BirdFlock
    {
        GameObject Flock;
        Animator[] BirdsAnimator;
        Vector3 PointA;
        Vector3 PointB;
        float StartTime;
        float TravelDistance;
        float Speed;
        public float TraveledFraction;

        public BirdFlock(GameObject flock, Vector3 pointA, Vector3 pointB, float speed)
        {
            Flock = flock;
            BirdsAnimator = flock.GetComponentsInChildren<Animator>();
            randomizeAnimation();
            PointA = pointA;
            PointB = pointB;
            StartTime = Time.time;
            TravelDistance = Vector3.Distance(pointA, pointB);
            Speed = speed;
            TraveledFraction = 0.0f;
        }
        public void DestroyGO() // Destroy GameObject
        {
            Destroy(Flock);
        }

        public void Move()  // Move flock by calculated distance
        {
            if (TraveledFraction < 1.0f)
            {
                TraveledFraction = (Time.time - StartTime) * Speed / TravelDistance;    // Where on route should flock be?
                Flock.transform.position = Vector3.Lerp(PointA, PointB, TraveledFraction);
            }
        }

        public void randomizeAnimation()    // Used to offset animation of each individual bird in flock
        {
            foreach(Animator bird in BirdsAnimator) 
                bird.Play("Ptak-animace", -1, Random.Range(0.0f, 0.9f));
        }
    }

    List<BirdFlock> activeBirds;


    // Start is called before the first frame update
    void Start()
    {
        toggleIsNight.onValueChanged.AddListener(delegate {
            ToggleValueChanged(toggleIsNight);
        });
        activeBirds = new List<BirdFlock>();
        lastSpawn = Time.time;
        Spawn(startPoints[GetRandomElement(startPoints.Count() - 1)].transform.position,
                endPoints[GetRandomElement(startPoints.Count() - 1)].transform.position);   // Spawn first flock on game start
    }

    int GetRandomElement(int max)   // Choose random int from 0 to parameter max
    {
        return Mathf.RoundToInt(Random.Range(0.0f, max));
    }

    void FixedUpdate()
    {
        if (activeBirds.Count < maxFlocks && spawnInterval < Time.time - lastSpawn && !toggleIsNight.isOn)  // If all is good (timer, max number of flocks, night toggle), spawn new flock
            Spawn(startPoints[GetRandomElement(startPoints.Count() - 1)].transform.position,
                    endPoints[GetRandomElement(startPoints.Count() - 1)].transform.position);
        for (int i = activeBirds.Count-1; i >= 0; i--)  // Manage spawned flocks
        {
            activeBirds[i].Move();
            if (activeBirds[i].TraveledFraction >= 1.0f) DestroyBirdFlock(i);
        }
    }

    Quaternion GetDirection(Vector3 a, Vector3 b)   // Used to get correct direction for birds to face
    {
        return (Quaternion.LookRotation((b - a).normalized));
    }

    void Spawn(Vector3 a, Vector3 b)    // Spawn flock, that will fly from A to B
    {
        lastSpawn = Time.time;
        GameObject newSpawnedObject = Instantiate(birds, a, GetDirection(a, b));
        activeBirds.Add(new BirdFlock(newSpawnedObject, a, b, flightSpeed));
    }

    void DestroyBirdFlock(int index)    // Destroy all the birds of the flock and the flock itself
    {
        if (activeBirds.Count > index)
        {
            activeBirds[index].DestroyGO();
            activeBirds.RemoveAt(index);
        }
    }

    void ToggleValueChanged(Toggle toggle)  // listener for toggle value change -> Birds spawn and fly only during the day
    {
        if (toggle.isOn)
        {
            for (int i = activeBirds.Count - 1; i >= 0; i--) DestroyBirdFlock(i);
        }
    }
}
