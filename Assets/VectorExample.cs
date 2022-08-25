using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VectorExample : MonoBehaviour
{
    
    [SerializeField]  Vector3[] points;
    [SerializeField] Transform cam;
    [SerializeField] Transform droid;
    [SerializeField] Text targetText;
    private int droidId;
    private int speedRotate;
    public bool forward;
    public float speed;
    [SerializeField] Vector3 offSet;

    void Start()
    {
        speedRotate = 5;
        droidId = 0;
       offSet = new Vector3(4.3f, 0.48f, 0.65f);
        
    }

    
    void Update()
    {
        MoveToLine();
        LookTarget();
        CameraTreking();




    }
    private void MoveToLine()
    {
        if (forward) 
        {
            if (droid.position == points[droidId])
            {
                droidId++;
                Debug.Log(droidId);
                if(droidId >= points.Length)
                {
                    forward = false;
                    droidId --;
                    Debug.Log(droidId);
                }
            }
            targetText.text = "Go to point " + droidId;
        }
        else 
        if (!forward)
         {
            if (droid.position == points[droidId])
            {
                droidId--;
                Debug.Log(droidId);
                if (droidId <= 0)
                {
                    forward = true;
                }
            }
            targetText.text = "Go to point " + droidId;
        }
        droid.transform.position = Vector3.MoveTowards(droid.position, points[droidId], speed * Time.deltaTime);
        
    }
    private void LookTarget()
    {
        Vector3 direction = points[droidId] - droid.transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        droid.rotation = Quaternion.Lerp(droid.rotation, rotation, speedRotate * Time.deltaTime);
    }
    private void CameraTreking()
    {
        cam.transform.position = droid.position + offSet;
    }

}
