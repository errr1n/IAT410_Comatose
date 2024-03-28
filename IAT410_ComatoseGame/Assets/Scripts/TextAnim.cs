using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnim : MonoBehaviour
{
    // Start is called before the first frame up
    
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] float timeBtwChars;
     [SerializeField] float timeBtwWords;
    public string[] stringArray;

    int i =0;
    void Start()
    {
        EndCheck();
    }

    void EndCheck()
    {
        if(i<= stringArray.Length - 1)
        {
            textMeshPro.text = stringArray[i];
            StartCoroutine(TextVisible());
        }
    }

    private IEnumerator TextVisible()
    {
        textMeshPro.ForceMeshUpdate();
        int totalVisibleCharacters = textMeshPro.textInfo.characterCount;
        int counter =0;

        while (true)
        {
            int visibleCount = counter % (totalVisibleCharacters + 1);
            textMeshPro.maxVisibleCharacters = visibleCount;

            if(visibleCount >= totalVisibleCharacters)
            {
                i +=1;
                Invoke("EndCheck", timeBtwWords);
                break;
            }

            counter += 1;
            yield return new WaitForSeconds(timeBtwChars);
        }

    }
}
