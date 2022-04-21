using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;

    private int maxStamina = 50;
    private int currentStamina;
    public bool stamianaRegen = false;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);

    public static StaminaBar instance;

    public Animator StaminaUIAnim;


    private void Awake()
    {

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentStamina >= 50)
        {
            StaminaUIAnim.SetBool("IsReady", true);
            stamianaRegen = false;
        }
        else
        {
            StaminaUIAnim.SetBool("IsReady", false);
        }
    }

    public void SetMaxStamina(int stamina)
    {
        staminaBar.maxValue = stamina;
        staminaBar.value = stamina;
    }

    public void SetStamina(int stamina)
    {
        staminaBar.value = stamina;
    }

    public void UseStamina(int amount)
    {
        if (currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;

            StartCoroutine(RegenStamina());
        }

        else { Debug.Log(" Not Enough"); }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(3);
        while (currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 50;
            staminaBar.value = currentStamina;
            yield return regenTick;
            stamianaRegen = true;
        }

    }
}
