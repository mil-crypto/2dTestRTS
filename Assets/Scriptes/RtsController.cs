using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RtsController : MonoBehaviour
{
    private Vector3 startPosition, endPosition;
    private List<Units> unitsList;
    [SerializeField] private Transform selectedArea;
    public float speed;
    private bool isMove;

    private void Awake()
    {
        unitsList = new List<Units>();
        selectedArea.gameObject.SetActive(false);
        //isMove=false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedArea.gameObject.SetActive(true);

        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 lowerLeftAngle = new Vector3(Mathf.Min(startPosition.x, currentPosition.x),Mathf.Min(startPosition.y, currentPosition.y));
            Vector3 upperRightAngle = new Vector3(Mathf.Max(startPosition.x, currentPosition.x), Mathf.Max(startPosition.y, currentPosition.y));
            selectedArea.position = lowerLeftAngle;
            selectedArea.localScale = upperRightAngle - lowerLeftAngle;
        }
        if (Input.GetMouseButtonUp(0))
        {
            selectedArea.gameObject.SetActive(false);
            endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D[] collidersArray = Physics2D.OverlapAreaAll(startPosition, endPosition);

            foreach(Units units in unitsList)
            {
                units.setSelected(false);
            }

            unitsList.Clear();

            foreach (Collider2D collider in collidersArray)
            {
                Units unit = collider.GetComponent<Units>();
                if (unit != null)
                {
                    unit.setSelected(true);
                    unitsList.Add(unit);
                }
            }

        }

        
            if (Input.GetMouseButton(1))
            {
                isMove = true;
                Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPosition.z = 0;
                foreach (Units units in unitsList)
                {
                    if (isMove)
                    {
                    units.transform.position= Vector3.MoveTowards(units.transform.position, targetPosition, speed * Time.deltaTime);         
                    }
                    if (units.transform.position == targetPosition)
                    {
                        isMove = false;
                        Debug.Log(isMove + " inside move function");
                    }

                }
            }
        

    }

}
