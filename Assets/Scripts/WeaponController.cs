using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Weapon weapon;
    public GameObject heldWeaponModel;

    public void Equip(Weapon weapon)
    {
        Destroy(heldWeaponModel);
        heldWeaponModel = Instantiate(weapon.model, transform.position, Quaternion.identity);
    }

}
