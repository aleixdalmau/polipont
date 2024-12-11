using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class CompletedLevel : MonoBehaviour
{
    public GameObject panelcl;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player")) 
        {

            if (panelcl != null)
            {
                panelcl.SetActive(true);
            }
            Time.timeScale = 0;
        }
    }
}