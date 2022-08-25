using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelayRace : MonoBehaviour
{
    [SerializeField] Transform[] droids;
    [SerializeField] Transform box;
    [SerializeField] Transform cam;
    [SerializeField] Text nextTargetText;
    private bool vector;
    public float speed;
    public Vector3 offSet;
    private int idRunner;
    private Transform target;
    private float passDistanse;
    
    private void Start()
    {
        nextTargetText.text = "Current droid " + idRunner;
        vector = true;
        Debug.Log(vector);
        box.transform.SetParent(droids[0]);
        box.transform.localPosition = new Vector3(0, 0, 0.084f);
       
        idRunner = 0;
        target = droids[idRunner+1];
       
    }

    private void Update()
    {
        
        CheckDistanse();
        MoveTheDorid();
        CameraTreking();





    }
    private void CheckDistanse()
    {
        if(passDistanse <= 5)
        {
            SmoothRotete();
        }

        if (vector)
        {
            passDistanse = Vector3.Distance(droids[idRunner].position, target.position);
            if (passDistanse <= 2)
            {
                box.transform.SetParent(target);
                box.transform.localPosition = new Vector3(0, 0, 0.084f);
                box.transform.localRotation = Quaternion.Euler(0, 0, 0);
                idRunner++;
                
                if(idRunner +1 >= droids.Length)
                {
                    vector = false;
                    Debug.Log(vector);
                    idRunner--;
                    target = droids[idRunner - 1];
                    box.transform.SetParent(droids[idRunner]);
                    box.transform.localPosition = new Vector3(0, 0, 0.084f);
                    Debug.Log(idRunner);
                }
                else
                target = droids[idRunner + 1];
                nextTargetText.text = "Current droid " + idRunner;
            }
        }else if (!vector)
        {
            passDistanse = Vector3.Distance(droids[idRunner].position, target.position);
            if (passDistanse <= 2)
            {
                
                idRunner--;
                box.transform.SetParent(target);
                box.transform.localPosition = new Vector3(0, 0, 0.084f);
                box.transform.localRotation = Quaternion.Euler(0, 0, 0);

                if (idRunner - 1 < 0)
                {
                    vector = true;
                    Debug.Log(vector);
                    idRunner++;
                    target = droids[idRunner + 1];
                    box.transform.SetParent(droids[idRunner]);
                    box.transform.localPosition = new Vector3(0, 0, 0.084f);
                    Debug.Log(idRunner);
                }
                else
                target = droids[idRunner - 1];
                nextTargetText.text = "Current droid " + idRunner;
            }

        }
       
    }
    private void MoveTheDorid()
    {
        
        droids[idRunner].position = Vector3.MoveTowards(droids[idRunner].transform.position, target.position, speed * Time.deltaTime);
        Vector3 direction = target.transform.position - droids[idRunner].position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        droids[idRunner].rotation = Quaternion.Lerp(droids[idRunner].rotation, rotation, (speed *3) * Time.deltaTime);

    }
    private void SmoothRotete()
    {
       
            Vector3 direction = box.transform.position - target.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            target.rotation = Quaternion.Lerp(target.rotation, rotation, (speed * 3) * Time.deltaTime);
        
    }
    private void CameraTreking()
    {
        cam.transform.position = droids[idRunner].position + offSet;
    }
   
}
