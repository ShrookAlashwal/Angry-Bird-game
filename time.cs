using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class time : MonoBehaviour
{
    [SerializeField] GameObject lose;


    public int timee;
    public Text timer;

    // Start is called before the first frame update
    void Start()
    {
        lose.SetActive(false);

        StartCoroutine(countdown());
    }
    IEnumerator countdown()
    {
        while (timee > 0)
        {
            yield return new WaitForSeconds(1);

            timer.text = timee.ToString();
            timee -= 1;
        }



        if (timee == 0)
        {
            Time.timeScale = 0f;
            OpenPanal();
        }

    }
    void OpenPanal()
    {

        timer.text = "";

        lose.SetActive(true);


    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
