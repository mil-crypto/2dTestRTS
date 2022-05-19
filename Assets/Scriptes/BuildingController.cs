using UnityEngine;
using UnityEngine.UI;

public class BuildingController : MonoBehaviour
{
    public Text moneyText,alertText;
    public float money;
    public GameObject hospitalPrefab;
    private float costOfBuilding,timeLeft;
 



    private void Start()
    {
        costOfBuilding = 50;
        alertText.gameObject.SetActive(false);
        timeLeft = 1;

    }
    private void Update()
    {
        moneyText.text = money.ToString();
        if (Input.GetMouseButtonDown(2))
        {
            if (money >= costOfBuilding)
            {
                Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                position.z = 0;
                Instantiate(hospitalPrefab, position, Quaternion.identity);
                money -= costOfBuilding;
       
            }
            else
            {
                alertText.gameObject.SetActive(true);
                timeLeft -= Time.deltaTime*100;
                Debug.Log(timeLeft+" "+Time.deltaTime);
                if (timeLeft <= 0)
                {
                    alertText.gameObject.SetActive(false);
                    timeLeft = 1;
                }


            }
        }
    }
}
