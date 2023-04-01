using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private GameObject weaponLogic;
    private void Start(){
        weaponLogic.SetActive(false);
    }
    private void EnableWeapon()
    {
        weaponLogic.SetActive(true);
    }

    private void DisableWeapon()
    {
        weaponLogic.SetActive(false);
    }
}