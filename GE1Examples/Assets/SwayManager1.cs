using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class SwayManager1 : MonoBehaviour {

    TransformAccessArray transforms;
    NativeArray<float> theta;
    
    public Vector3 axis;
    public float angle;
    public float frequency;

    int maxJobs = 30000;
    int numJobs = 0;

    SwayJob1 job;
    JobHandle jh;

    public static SwayManager1 Instance;

    public void Add(GameObject sway)
    {
        transforms.capacity = transforms.length + 1;
        transforms.Add(sway.transform);
        theta[numJobs] = 0;
        numJobs++;
    }

    private void Awake()
    {
        Instance = this;
        transforms = new TransformAccessArray(0, -1);
        theta = new NativeArray<float>(maxJobs, Allocator.Persistent);
    }

    private void OnDestroy()
    {
        transforms.Dispose();
        theta.Dispose();
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		job = new SwayJob1()
        {
            timeDelta = Time.deltaTime
            , frequency = this.frequency
            , angle = this.angle
            , theta = this.theta
            , axis = this.axis
        };

        jh = job.Schedule(transforms);
        //JobHandle.ScheduleBatchedJobs();
	}

    private void LateUpdate()
    {
        jh.Complete();
    }
}
public struct SwayJob1 : IJobParallelForTransform
{
    
    public NativeArray<float> theta;
    public float frequency;
    public float angle;
    public float timeDelta;
    public Vector3 axis;

    public void Execute(int i, TransformAccess t)
    {
        t.localRotation = Quaternion.AngleAxis(
            Mathf.Sin(theta[i]) * angle, axis);
        theta[i] += frequency * timeDelta * Mathf.PI * 2.0f;
    }
}
