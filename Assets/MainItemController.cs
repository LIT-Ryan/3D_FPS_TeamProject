using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainItemController : MonoBehaviour
{
    public MouseLook mouseLookScript;
    public float Range = 10f;
    public LayerMask whatIslayer;
    public bool layerInRange;
    public GameObject questPanelUI;
   public bool isInRange = false;
    public GameObject shield;
    public GameObject block;
    public GameObject sealedMask;
    public GameObject mask;
    public GameObject levelCompletedPanel;
    void Update()
    {
        layerInRange = Physics.CheckSphere(transform.position, Range, whatIslayer);

        if (layerInRange)
        {
            questPanelUI.SetActive(true);
            isInRange = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && (isInRange = true) && (layerInRange))
        {
            
            Destroy(questPanelUI);
            Destroy(shield,0.6f);
            Destroy(block, 0.3f);
            Destroy(mask, .9f);
            sealedMask.SetActive(true);
            StartCoroutine(StopSound());
            StartCoroutine(LevelCompleted());
          
        }


    }
    
    private IEnumerator LevelCompleted()
    {

        yield return new WaitForSeconds(1.2f);
        levelCompletedPanel.SetActive(true);
        SoundManager.instance.levelCompleteSound.Play();

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        mouseLookScript.enabled = false;
        Time.timeScale = 0f;



    }
    private IEnumerator StopSound()
    {

        yield return new WaitForSeconds(1.1f);
        SoundManager.instance.levelCompleteSound.Play();
        SoundManager.instance.gamePlaySound.Stop();
        


    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);

    }
}
