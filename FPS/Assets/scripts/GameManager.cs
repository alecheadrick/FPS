using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {


    public static int shots = 0;
    public static int hits = 0;
    public static int maxAmmo = 30;
    public static int shotCount = 0;
    public static float ammoCount = 0;
    public static float totalHealth = 10f;

    public GameObject scoresText;
    public Text scoreText;
    public Text ammoText;



    void Update () {
        ammoText.text = ammoCount + " Shots Left";

        if (shots > 0)
        {
            scoresText.SetActive(true);
            float hitPct = hits / (float)shots * 100;
            hitPct = Mathf.RoundToInt(hitPct);
            scoreText.text = hits + " / " + shots + " : " + hitPct + "%";
        }else { scoresText.SetActive(false); }
	}
}
