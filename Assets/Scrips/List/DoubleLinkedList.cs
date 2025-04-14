using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleLinkedList<T>
{
    public Node<T> head = null;
    public Node<T> last = null;
    public int count = 0;

    public virtual void Add(T value)
    {
        Node<T> newNode = new Node<T>(value);
        count++;

        if (head == null)
        {
            head = newNode;
            last = newNode;

            return;
        }
        last.SetNext(newNode);
        newNode.SetPrev(last);

        last = newNode;
    }

    public Node<T> Seek(T objective, Node<T> _head = null, int deep = 0)
    {
        if (head == null || deep >= count)
        {
            Debug.Log("No hay elementos en la lista o No se encontro elemento");
            return null;
        }
        if (_head == null)
            _head = head;

        if (_head.Value.Equals(objective))
        {
            Debug.Log("Elemento encontrado: " + _head.Value.ToString());
            Debug.Log("Se encontro en la posicion: " + deep);
            return _head;
        }
        else
            return Seek(objective, _head.Next, deep + 1);

    }
    public Node<T> SeekPrev(T objective)
    {

        return Seek(objective).Prev;
    }
    public Node<T> SeekNext(T objective)
    {

        return Seek(objective).Next;
    }

    public virtual void ReadFromStart(Node<T> _head = null, int deep = 0)
    {
        if (head == null || deep >= count) return;

        if (_head == null)
        {
            _head = head;
        }
        Debug.Log("" + _head.Value.ToString());
        Debug.Log(" ↓ ");

        ReadFromStart(_head.Next, deep + 1);
    }
    public virtual void ReadFromEnd(Node<T> _last = null, int deep = 0)
    {
        if (last == null || deep >= count) return;

        if (_last == null)
        {
            _last = last;
        }
        Debug.Log("" + _last.Value.ToString());
        Debug.Log(" ↓ ");

        ReadFromEnd(_last.Prev, deep + 1);
    }

    public virtual void Remove(T objective)
    {
        Node<T> node = Seek(objective);

        if (node == null)
        {
            Debug.Log("No existe elemento");
            return;
        }
        #region NodoEsElPrimero
        if (node == head && count >= 1)//El Nodo es el primero de la lista
        {
            head = node.Next;
            count--;
            return;
        }
        else if (node == head && count == 1)//El Nodo es el primero y el unico de la lista
        {
            RemoveAll();
            return;
        }
        #endregion
        #region NodoEnElMedio
        if (SeekPrev(objective) != null && node.Next != null)//El nodo esta en el medio y apunta a siguientes
        {
            SeekPrev(objective).SetNext(node.Next);
            count--;
            return;
        }
        #endregion
        #region NodoEsElUltimo
        if (SeekPrev(objective) != null && node.Next == null)//El nodo es el ultimo de la lista
        {
            SeekPrev(objective).SetNext(null);
            last = SeekPrev(objective);
            count--;
            return;
        }
        #endregion
    }
    public virtual void RemoveAll()
    {
        head = null;
        last = null;
        count = 0;
    }
}

