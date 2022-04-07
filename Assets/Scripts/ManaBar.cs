using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManaBar : MonoBehaviour
{
    public Slider manaBar;

    public int maxStamina = 100;
   public int currentStamina;
    public int usedMana = 15 ;
    private WaitForSeconds regenTick = new WaitForSeconds(0.5f);

    public static ManaBar instance;


    private void Awake()
    {

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        manaBar.maxValue = maxStamina;
        manaBar.value = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
     
    }


    public void SetMaxMana(int Mana)

    {
        manaBar.maxValue = Mana;
        manaBar.value = Mana;

    }

    public void SetMaxStamina(int stamina)
    {
        manaBar.maxValue = stamina;
        manaBar.value = stamina;
    }

    public void SetStamina(int stamina)
    {
        manaBar.value = stamina;
    }

    public void UseStamina(int amount)
    {
        if( (currentStamina - amount >= 0) && (currentStamina >= usedMana))
        {
            currentStamina -= amount;
            manaBar.value = currentStamina;

            StartCoroutine(RegenStamina());
        }

        else { Debug.Log(" Not Enough"); }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(3);
        while (currentStamina < maxStamina)
        {
            currentStamina += maxStamina / maxStamina;
            manaBar.value = currentStamina;
            yield return regenTick;
           
        }

    }
}
