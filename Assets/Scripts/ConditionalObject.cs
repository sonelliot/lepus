using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ConditionalObject : MonoBehaviour
{
    //temp
    public bool IsGood = true;

    private GameObject Good;
    private GameObject Bad;

    // Use this for initialization
    void Start()
    {
        Good = transform.FindChild("Good").gameObject;
        Bad = transform.FindChild("Bad").gameObject;
        ActivateConditionalObject();
    }

    void ActivateConditionalObject()
    {
        Good.SetActive(IsGood);
        Bad.SetActive(!IsGood);
    }

#if UNITY_EDITOR
    void Update()
    {
        ActivateConditionalObject();
    }
#endif
}
