using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuiltManager : MonoBehaviour
{
    public static BuiltManager instance;
    void Awake()
    {
        if(instance != null)
        {
            print("Not one manager!");
            return;
        }
        instance = this;
    }
    public GameObject standartTurretPrefab;
    public GameObject anotherTurretPrefab;
    private TurretBlueprint turretToBuilt;
    public bool CanBuild {get {return turretToBuilt != null; } }
    public void SelectTurretToBuilt(TurretBlueprint turret)
    {
        turretToBuilt = turret;
    }
    public void BuiltTurretOn(Cell cell)
    {
        if(PlayerStats.Gold < turretToBuilt.cost)
        {
            print("NADO BOLSHE ZOLOTA!");
            return;
        }
        PlayerStats.Gold -= turretToBuilt.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuilt.prefab, cell.GetBuiltPosition(), Quaternion.identity);
        cell.turret = turret;
        print("TURRET KUPLENO! OSTALOS " + PlayerStats.Gold + "GOLDI");
    }
}