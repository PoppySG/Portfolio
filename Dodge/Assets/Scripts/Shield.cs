using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public GameObject effect;
    public GameObject shieldText;

    public bool isActive;
    private float activeTime;
    private float coolTime;

    // Start is called before the first frame update
    void Start()
    {
        coolTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coolTime += Time.deltaTime;
        if (coolTime >= 5 && !isActive)
        {
            shieldText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                shieldText.SetActive(false);
                Unbeatable();

                Invoke("Unbeatable", 3);
            }
        }
    }

    void Unbeatable()
    {
        isActive = !isActive;

        if(isActive)
        {
            effect.SetActive(true);
        }
        else
        {
            effect.SetActive(false);
            coolTime = 0;
        }
    }
}
