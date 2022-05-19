using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units : MonoBehaviour
{
    [SerializeField] private GameObject selectedObject;

    private void Awake()
    {
        setSelected(false);
    }
    public void setSelected(bool selected)
    {
        selectedObject.SetActive(selected);
    }
}
