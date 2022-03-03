using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSwitching : MonoBehaviour
{
    public int selectedBullet = 0;
    // Start is called before the first frame update
    void Start()
    {
        SelectBullet();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedBullet = selectedBullet;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedBullet = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedBullet = 1;
        }
        if (previousSelectedBullet != selectedBullet)
        {
            SelectBullet();
        }
    }

    void SelectBullet()
    {
        int i = 0;
        foreach (Transform bullet in transform)
        {
            if (i == selectedBullet)
                bullet.gameObject.SetActive(true);
            else
                bullet.gameObject.SetActive(false);
            i++;
        }

    }

}
