using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IControlState controlState;
  public WeaponBase currentWeapon;
  public List<WeaponBase> weapons;
  public int currentWeaponIndex = 0;
  public float moveStep = 2f; 
  public float minX = -8f;  
  public float maxX = 8f;  
    void Start() {
#if UNITY_EDITOR
        SetControlState(new KeyboardControlState());
        #elif UNITY_ANDROID
          SetControlState(new TouchControlState());
#endif
        EquipWeapon(0);
    }
    void Update()
    {
        controlState?.HandleInput(this);
        if (currentWeapon is WeaponType2 w2)
        {
            UIManager.Instance. weapon3CooldownSlider.gameObject.SetActive(false);
           UIManager.Instance.weapon2CooldownSlider.gameObject.SetActive(true);
            UIManager.Instance. weapon2CooldownSlider.value = w2.GetCooldownPercent();
        }
        else if (currentWeapon is WeaponType3 w3)
        {
            UIManager.Instance. weapon2CooldownSlider.gameObject.SetActive(false);
            UIManager.Instance. weapon3CooldownSlider.gameObject.SetActive(true);
            UIManager.Instance. weapon3CooldownSlider.value = w3.GetCooldownPercent();
        }
        else
        {
            UIManager.Instance. weapon2CooldownSlider.gameObject.SetActive(false);
            UIManager.Instance.  weapon3CooldownSlider.gameObject.SetActive(false);
        }
    }

    public void SetControlState(IControlState newState)
    {
        controlState = newState;
    }

    public void Shoot()
    {
        currentWeapon?.Fire();
        UIManager.Instance.UpdateAmmo(currentWeapon.currentAmmo, currentWeapon.maxAmmo);
    }
    public void Move(float direction)
    {
        Vector3 pos = transform.position;
        pos.x += direction * moveStep;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;
    }
    public void SwitchWeapon()
    {
        currentWeaponIndex++;
        if (currentWeaponIndex >= weapons.Count) currentWeaponIndex = 0;
        EquipWeapon(currentWeaponIndex);
    }
    private void EquipWeapon(int index)
    {
        foreach (var weapon in weapons)
            weapon.gameObject.SetActive(false);
        currentWeapon = weapons[index];
        currentWeapon.gameObject.SetActive(true);
        UIManager.Instance.UpdateAmmo(currentWeapon.currentAmmo, currentWeapon.maxAmmo);
    }
}