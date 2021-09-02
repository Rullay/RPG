using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    public List<GameObject> TECH_TriggerWorldObjectList = new List<GameObject>();
    private GameObject TECH_TargetObject;
    [SerializeField] private GameObject marker;

    void Update()
    {
        TECH_TargetObject = null;

        foreach (GameObject ActivateObject in TECH_TriggerWorldObjectList)
        {
            if (!TECH_TargetObject)
            {
                TECH_TargetObject = ActivateObject;
            }
            else if ((TECH_TargetObject.transform.position - transform.position).magnitude > (ActivateObject.transform.position - transform.position).magnitude)
            {
                TECH_TargetObject = ActivateObject;
            }
        }
        if(TECH_TargetObject)
        {
            marker.transform.position = new Vector3(TECH_TargetObject.transform.position.x, TECH_TargetObject.transform.position.y + 2f, TECH_TargetObject.transform.position.z);
            marker.SetActive(true);
            marker.transform.LookAt(GameManager.Instance.Camera.transform.position);
        }
        else
        {
            marker.SetActive(false);
        }
    }

    public void ActivateTargetObject()
    {
        if (TECH_TargetObject)
        {
            TECH_TargetObject.GetComponent<WorldObject>().Activate();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other!.GetComponent<WorldObject>())
        {
            TECH_TriggerWorldObjectList.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other!.GetComponent<WorldObject>())
        {
            TECH_TriggerWorldObjectList.Remove(other.gameObject);
        }
    }
}
