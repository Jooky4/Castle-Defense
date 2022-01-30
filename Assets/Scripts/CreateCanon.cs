using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCanon : MonoBehaviour
{
    [Header(" Массив префабов пушек")]
    [SerializeField]
    private Transform[] prefabCanon;

    //[SerializeField]
    private int indexIDWeapon;

    private ChargeGun chargeGun;
    private ShotGun shotGun;
    private PlatformGun platformGun;


    // Start is called before the first frame update
    void Start()
    {
        chargeGun = GetComponent<ChargeGun>();
        chargeGun.enabled = true;
        shotGun = GetComponent<ShotGun>();
        shotGun.enabled = true;
        platformGun = GetComponent<PlatformGun>();
        platformGun.enabled = true;
        SetCanon();
    }
    
    private void SetCanon()
    {
        indexIDWeapon = GameController.Instance.currentIDWeapon;

        for (int index = 0; index < prefabCanon.Length; index++)
        {
            if (index == indexIDWeapon)
            {
                prefabCanon[index].gameObject.SetActive(true);
            }
            else
            {
                prefabCanon[index].gameObject.SetActive(false);
            }
        }
    }
  
}
