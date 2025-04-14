using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    #region Properties
    string entityName;
    Vector3 vector3;
    #endregion

    #region Getters
    public Vector3 _Vector3 => vector3;
    public string EntityName;
    public void GetEntityInformation(int entityID)
    {
        Debug.Log("Entidad N° " + (entityID + 1) + ": Nombre - " + entityName + " / Posicion: " + vector3);
    }
    #endregion

    #region Constructors
    public Entity(string entityName, Vector3 vector3)
    {
        this.entityName = entityName;
        this.vector3 = vector3;
    }
    public void SetPosition(Vector3 newPosition)
    {
        vector3 = newPosition;
    }
    #endregion
}
