using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Weapon weapon;
    public GameObject heldWeaponModel;

    public void Equip(Weapon weapon)
    {
        this.weapon = weapon;
        Destroy(heldWeaponModel);
        heldWeaponModel = Instantiate(weapon.model, transform.position, Quaternion.identity);
        heldWeaponModel.transform.SetParent(transform);
        heldWeaponModel.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

}
