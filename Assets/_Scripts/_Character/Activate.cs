using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    private List<GameObject> TECH_TriggerList = new List<GameObject>();
    private GameObject TECH_TargetObject;
    [SerializeField] private GameObject Marker;
    [SerializeField] private GameObject ActivateTrigger;

    private TECH_ActivateTrigger TECH_ActivateTrigger;

    void Start()
    {
        TECH_ActivateTrigger = ActivateTrigger.GetComponent<TECH_ActivateTrigger>();
    }

    void Update()
    {
        TECH_TargetObject = null;
        TECH_TriggerList = TECH_ActivateTrigger.TECH_TriggerList;
        foreach (GameObject ActivateObject in TECH_TriggerList)
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
            Marker.transform.position = new Vector3(TECH_TargetObject.transform.position.x, TECH_TargetObject.transform.position.y + 2f, TECH_TargetObject.transform.position.z);
            Marker.SetActive(true);
            Marker.transform.LookAt(GameManager.Instance.Camera.transform.position);
        }
        else
        {
            Marker.SetActive(false);
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
            TECH_TriggerList.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other!.GetComponent<WorldObject>())
        {
            TECH_TriggerList.Remove(other.gameObject);
        }
    }
}
