using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuiltManager builtManager;
    public TurretBlueprint standartTurret;
    public TurretBlueprint anotherTurret;

    void Start()
    {
        builtManager = BuiltManager.instance;
    }
    public void SelectStandartTurret()
    {
        builtManager.SelectTurretToBuilt(standartTurret);
        print("kupi turel blin!");
    }

    public void SelectAnotherTurret()
    {
        print("kupi druguyu turel blin!");
        builtManager.SelectTurretToBuilt(standartTurret);
    }
}
