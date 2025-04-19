using UnityEngine;  
using System.Collections;  
using UnityEngine.UI;  

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> list = new List<GameObject>();
    [SerializeField] private Slider lifeBar;

    private void Start()
    {
        lifeBar = GameObject.Find("Slider").GetComponent<Slider>();

       
    }

    private void Update()
    {

    }

    IEnumerator lifeUpdate()
    {
        while (true) 
        {
          
            lifeBar.value -= 0.01f; 

            if (lifeBar.value <= 0)
            {
                lifeBar.value = 0; 
            }

            yield return new WaitForSeconds();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }

}
