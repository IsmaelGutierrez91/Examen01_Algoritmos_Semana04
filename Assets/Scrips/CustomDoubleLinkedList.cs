using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CustomDoubleLinkedList : DoubleLinkedList<CustomNode>
{
    #region Properties
    public CustomNode peak;
    #endregion
    public override void Add(CustomNode value)
    {
        CustomNode newNode = value;
        count++;

        if (head == null)
        {
            head = newNode;
            last = newNode;
            peak = newNode;

            return;
        }
        last.SetNext(newNode);
        newNode.SetPrev(last);
        last = newNode;
        /*//Si peak es un nodo intermedio creara un nodo y eliminara todos los posteriores al nodo donde estaba originalmente
        if (peak != last)
        {
            CustomNode tem = (CustomNode)peak.Prev;
            Seek(tem).SetNext(newNode);
        }*/
        peak = newNode;
    }

    public void MovePeakToPrevTurn()
    {
        if (peak != null && peak.Prev != null)
        {
            peak = (CustomNode)peak.Prev;
            Debug.Log($"El peak se ha movido al turno {peak.CurrentTurn}");
            return;
        }
        Debug.Log("No hay turnos anteriores.");
    }
    public void MovePeakToNextTurn()
    {
        if (peak != null && peak.Next != null)
        {
            peak = (CustomNode)peak.Next;
            Debug.Log($"El peak se ha movido al turno {peak.CurrentTurn}");
            return;
        }
        Debug.Log("No hay turnos siguientes.");
    }
    public void ReadTurnListFromEnd(CustomNode _last = null, int deep = 0) //no use override porque me daba un error
    {
        if (last == null || deep >= count)
        {
            return;
        }
        if (_last == null)
        {
            _last = (CustomNode)last;
        }
        Debug.Log("Turno N° " + (count - deep));
        _last.GetCustomNodeInformation();
        Debug.Log(" ↓ ");

        ReadTurnListFromEnd((CustomNode)_last.Prev, deep + 1);
    }
}
