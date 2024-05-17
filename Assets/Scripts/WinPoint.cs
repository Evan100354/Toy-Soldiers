using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPoint : MonoBehaviour
{
    public GameObject winAudio;
    public string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<FlagUnit>())
        {
            col.gameObject.GetComponent<FlagUnit>().Win();
            StartCoroutine(NextLevel());
            //Debug.Log("YIPPEEEEEEEEEEE");
        }
    }

    IEnumerator NextLevel()
    {
        winAudio.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneToLoad);
    }
}
