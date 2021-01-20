using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public GameObject ui;

    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ui.GetComponent<Level_UI_Handler>().LevelWon = true;
            ui.GetComponent<Level_UI_Handler>().WinLoseScreen();
        }
    }
}
