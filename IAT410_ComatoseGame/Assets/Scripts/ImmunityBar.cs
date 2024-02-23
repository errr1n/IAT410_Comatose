using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ImmunityBar : MonoBehaviour
{
    // public Text counterText;
    public int kills;

    public float curImmunity;
    public float maxImmunity;
    public Slider immunityBar;


    void Awake()
    {
        // curImmunity = maxImmunity;
        // curImmunity = kills;
        // immunityBar.value = kills;
        // immunityBar.maxValue = maxImmunity;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ShowKils();
    }

    private void ShowKils()
    {
        // counterText.text = kills.ToString();
        // Debug.Log("kills " + kills);
    }

    public void AddKill()
    {
        kills++;
        curImmunity = kills;
    }
}
