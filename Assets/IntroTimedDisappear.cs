using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntroTimedDisappear : MonoBehaviour
{
    public Image tg;
    public GameObject subImage;
    public TextMeshProUGUI timer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delayedDisappearance());
    }

    IEnumerator delayedDisappearance()
    {

        for (int i = 8; i > 0; i--)
        {
            timer.text = i.ToString();
            yield return new WaitForSecondsRealtime(1f);

        }
        yield return new WaitForSecondsRealtime(1f);
        subImage.SetActive(false);

        for (int i = 0; i < 100; i++)
        {
            tg.fillAmount -= 0.01f;
            yield return new WaitForSecondsRealtime(0.01f);
        }

        tg.gameObject.SetActive(false);
    }

}
