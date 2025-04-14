using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    CustomDoubleLinkedList TurnsHistory = new CustomDoubleLinkedList();
    List<Entity> player = new List<Entity> ();
    List<Entity> enemy = new List<Entity>();
    int currentEntityCount = 0;
    private void Awake()
    {
        TurnsHistory = new CustomDoubleLinkedList();
        player.Add(new Entity("Player", Vector3.zero));
        enemy.Add(new Entity("Player", Vector3.zero));
    }
    #region Entity position update
    [Button]
    public void SetPlayerNewPosition(float x, float y, float z)
    {
        Vector3 positon = new Vector3(x, y, z);
        player[currentEntityCount] = new Entity("Player", positon);
    }
    [Button]
    public void SetEnemyNewPosition(float x, float y, float z)
    {
        Vector3 positon = new Vector3(x, y, z);
        enemy[currentEntityCount] = new Entity("Enemy", positon);
    }
    #endregion

    #region Turns modificators
    [Button]
    public void AddNewTurn(string turnName)
    {
        List<Entity> list = new List<Entity>();
        list.Add(player[currentEntityCount]);
        list.Add(enemy[currentEntityCount]);
        CustomNode NewTurn = new CustomNode(TurnsHistory.count +1, list, turnName);
        TurnsHistory.Add(NewTurn);
        currentEntityCount++;
        player.Add(new Entity("Player", Vector3.zero));
        enemy.Add(new Entity("Player", Vector3.zero));
    }
    [Button]
    public void ReadTurnsList()
    {
        TurnsHistory.ReadTurnListFromEnd();
    }
    #endregion

    #region Peak modificators
    [Button]
    public void ReadPeak()
    {
        Debug.Log("Peak:");
        TurnsHistory.peak.GetCustomNodeInformation();
    }
    [Button]
    public void SetPeakNext()
    {
        TurnsHistory.MovePeakToNextTurn();
    }
    [Button]
    public void SetPeakPrev()
    {
        TurnsHistory.MovePeakToPrevTurn();
    }
    #endregion

}
