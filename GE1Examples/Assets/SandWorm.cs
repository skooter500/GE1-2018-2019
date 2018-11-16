using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandWorm : MonoBehaviour {
    public int bodySegments = 10;
    public float size = 50;
    public bool gravity = true;

    public float spring = 100;
    public float damper = 50;

    // Use this for initialization
	void Awake () {
        if (transform.childCount == 0)
        {
            Create();
        }
        Invoke("StartMoving", 5);
    }

    void StartMoving()
    {
        moving = true;
    }

    void Create()
    { 
        float depth = size * 0.05f;
        Vector3 start = - Vector3.forward * bodySegments * depth * 2;
        GameObject previous = null;
        for (int i = 0; i < bodySegments; i++)
        {            
            float mass = 1.0f;
            GameObject segment = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Rigidbody rb = segment.AddComponent<Rigidbody>();
            rb.useGravity = gravity;
            rb.mass = mass;
            segment.name = "segment " + i;
            Vector3 pos = start + (Vector3.forward * depth * 4 * i);
            segment.transform.position = transform.TransformPoint(pos);
            segment.transform.rotation = transform.rotation;
            segment.transform.parent = this.transform;           
            segment.transform.localScale = new Vector3(size, size, depth);
            segment.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            segment.GetComponent<Renderer>().receiveShadows = false;

            segment.GetComponent<Renderer>().material.color = Color.HSVToRGB(i / (float)bodySegments, 1, 1);

            if (previous != null)
            {
                HingeJoint j = segment.AddComponent<HingeJoint>();
                j.connectedBody = previous.GetComponent<Rigidbody>();
                j.autoConfigureConnectedAnchor = false;
                j.anchor = new Vector3(0, 0, -2f);
                j.connectedAnchor = new Vector3(0, 0, 2f);
                j.axis = Vector3.right;
                j.useSpring = true;
                JointSpring js = j.spring;
                js.spring = spring;
                js.damper = damper;
                j.spring = js;
            }            
            previous = segment;
        }
    }

    public float torque = 100;
    
   
    private float offset = 0;
    public float speed = 1f;
    public int headtail = 2;
    public float current = 0;
    //int start = 2;
    public bool moving = false;

    public void Update()
    {
        if (moving || current != 0)
        {
            Animate();
        }
    }

    public void Animate()
    {
        float f = torque;
        Rigidbody rb = transform.GetChild((int) current).GetComponent<Rigidbody>();
        /*if (current >= transform.childCount - start)
        {
            f *= .05f;
        }*/
        rb.AddTorque(- rb.transform.right * f);
        current += speed * Time.deltaTime;


        if (current >= transform.childCount)
        {
            current = 0;
        }
    }
}
