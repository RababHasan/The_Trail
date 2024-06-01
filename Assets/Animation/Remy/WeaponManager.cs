using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject weaponPrefab;  // Drag your weapon prefab to this field in the Unity Editor

    public Transform weaponAttachPoint;  // Assign the attachment point in the Unity Editor

    void Start()
    {
        EquipWeapon();
    }

    void EquipWeapon()
    {
        if (weaponPrefab != null && weaponAttachPoint != null)
        {
            GameObject weaponInstance = Instantiate(weaponPrefab, weaponAttachPoint);
            weaponInstance.transform.localPosition = Vector3.zero;
            weaponInstance.transform.localRotation = Quaternion.identity;
        }
    }
}
