using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Vector2 direction;
    Vector2 target;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPos;
    void Update()
    {
        GunDirection();
        if (Input.GetMouseButton(0))
        {
            BulletSpawn();
        }
    }

    void GunDirection()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            target = player.transform.position;
            direction = target - (Vector2)transform.position;
            transform.right = -direction;
        }
    }

    void BulletSpawn()
    {
        Instantiate(bulletPrefab, bulletSpawnPos.position, transform.rotation);
    }
}
/*
    
    elma | muz | armut -> elma 
                          muz 
                          armut olarak döndür.

foreach(var item in maturityLevelVehicleInfoCurrent.M1Description)
{
    maturityLevelVehicleInfo.M1Description = item.ToString();
    maturityLevelVehicleInfo.M1Description.Split("|");
}
----------------------

maturityLevelVehicleInfo[] array = new maturityLevelVehicleInfo[maturityLevelVehicleInfoCurrent.M1Description.Length];
for (int i = 0; i < maturityLevelVehicleInfoCurrent.M1Description.Length; i++)
{
    array[i] = new maturityLevelVehicleInfo();
    array[i].M1Description = maturityLevelVehicleInfoCurrent.M1Description[i].ToString();
    array[i].M1DescriptionParts = array[i].M1Description.Split("|");
}
-------------------------

foreach (var item in maturityLevelVehicleInfoCurrent.M4Description)
{
    var desc4 = item.ToString();
    var currentdesc4 = desc4.Split('|');
    List<string> VehicleInfoM4Desc = new List<string>(currentdesc4);
}
---------------------------

foreach (var item in maturityLevelVehicleInfoCurrent.M4Description)
{
	List<string> M4Desc = new List<string>();
        M4Desc.Add(item.ToString());
        foreach (var item1 in M4Desc)
        {
		List<string> newM4Desc = new List<string>(item1.Split('|'));
                for(int i = 0; i < newM4Desc.Count; i++)
                {
                 maturityLevelVehicleInfo.M4Description = newM4Desc[i];
                 }
        }
}
--------------------------

foreach(var item in maturityLevelVehicleInfoCurrent.M4Description)
{
    var data = item.toString();
    var piecedData = data.Split("|");
    List<maturit>
}
*/
