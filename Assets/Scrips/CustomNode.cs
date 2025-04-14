using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomNode : Node<CustomNode>
{
    #region Properties
    int currentTurn;
    List<Entity> entityList;
    string turnName;
    #endregion

    #region Getters
    public int CurrentTurn => currentTurn;
    public List<Entity> EntityList => entityList;

    public void GetCustomNodeInformation()
    {
        Debug.Log(turnName);
        for (int i = 0; i < entityList.Count; i++)
        {
            entityList[i].GetEntityInformation(i);
        }
    }
    #endregion

    #region Constructors
    public CustomNode(int currentTrun, List<Entity> entityList, string turnName) : base(null) // <= Para evitar el error: no se a dado ningún argumento que corresponda al parámetro "value" de Node<CustomNode>
    {
        this.currentTurn = currentTrun;
        this.entityList = entityList;
        this.turnName = turnName;
    }
    #endregion
}
