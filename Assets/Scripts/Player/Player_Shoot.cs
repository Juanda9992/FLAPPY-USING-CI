using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    public delegate void OnAmmOut();
    public delegate void OnAmmoIncreased();
    public static event OnAmmOut onAmmoOut;
    public static event OnAmmoIncreased onAmmoIncreased;
    [SerializeField] private GameObject bulletPrefab;
    public int ammo = 0;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Shoot();
        }       
    }

    private void ResetAmmo()
    {
        ammo = 0;
        onAmmoOut?.Invoke();
    }

    public void Shoot()
    {
        if(ammo > 0)
        {
            Audio_Manager.instance.PlaySound("Bomb");
            Instantiate(bulletPrefab,new Vector2(transform.position.x +1, transform.position.y),Quaternion.identity);
            SaveDataHolder.instance.data.bombsShoot++;
            CheckForAmmo();
        }
        
    }

    private void CheckForAmmo()
    {
        if(ammo > 0)
        {
            ammo--;
        }
        if(ammo <= 0)
        {
            onAmmoOut?.Invoke();
        }
    }
    public void IncreaseAmmo()
    {
        onAmmoIncreased?.Invoke();
        ammo++;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<IPickable>(out IPickable pickable))
        {   
            pickable.OnPicked();
            Destroy(other.gameObject);
        }
    }   

    void OnEnable()
    {
        Player_Jump.onPlayerDeath += ResetAmmo;
    }

    void OnDisable()
    {
        Player_Jump.onPlayerDeath -= ResetAmmo;
    }
}
