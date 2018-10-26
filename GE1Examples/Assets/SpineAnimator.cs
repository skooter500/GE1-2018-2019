using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineAnimator : MonoBehaviour {
    List<Vector3> offsets = new List<Vector3>();
    List<Transform> children = new List<Transform>();
    public float damping = 10.0f;
    // Use this for initialization
    void Start() {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            Transform current = transform.parent.GetChild(i);
            if (i > 0)
            {
                Transform prev = transform.parent.GetChild(i - 1);                
                offsets.Add((current.transform.position - prev.transform.position));
            }
            children.Add(current);
        }
    }

    // Update is called once per frame
    void Update () {
        for (int i = 1; i < children.Count; i++)
        {
            Transform prev = children[i - 1];
            Transform current = children[i];
            Vector3 wantedPosition = prev.TransformPointUnscaled(offsets[i - 1]);
            Quaternion wantedRotation = prev.rotation;
            current.position = Vector3.Lerp(current.position, wantedPosition, Time.deltaTime * damping);
            current.rotation = Quaternion.Slerp(current.rotation, wantedRotation, Time.deltaTime * damping);
        }
    }
}
