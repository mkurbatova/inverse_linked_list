using System;
using System.Collections;
using System.Collections.Generic;

namespace TaskResolve
{
    public class CustomLinkedList: IEnumerable<LinkedNode>
    {
        #region Private Fields
        private LinkedNode head;
        private LinkedNode tail;
        #endregion

        #region Properties
        public int Length
        {
            get
            {
                LinkedNode ptr = head;
                int i = 0;
                for (i = 0; ptr != null; i++, ptr = ptr.Next) ;
                return i;
            }
        }
        #endregion

        #region Constructor
        public CustomLinkedList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("capacity", "capacity must be positive");
            }

            for (int i = 1; i <= capacity; i++)
            {
                this.Add(i);
            }
        }
        #endregion

        #region Public Methods
        public void Add(int value)
        {
            LinkedNode newNode = new LinkedNode(value, null);
            if (head == null)
            {
                head = tail = newNode;
            }               
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
        }

        public void Inverse()
        {
            LinkedNode tempPtr = null;
            for (LinkedNode ptr = head, nextPtr; ptr != null; ptr = nextPtr)
            {
                nextPtr = ptr.Next;
                ptr.Next = tempPtr;
                tempPtr = ptr;                
            }
            tail = head;
            head = tempPtr;
        }
        #endregion

        #region IEnumerable Implementation
        public IEnumerator<LinkedNode> GetEnumerator()
        {
            for (LinkedNode ptr = head; ptr != null; ptr = ptr.Next)
                yield return ptr;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }

    public class LinkedNode
    {
        #region Private Fields
        private LinkedNode next;
        private int value;
        #endregion

        #region Properties
        public int Value
        {
            get
            {
                return value;
            }
        }
        public LinkedNode Next
        {
            get
            {
                return next;
            }
            set
            {
                if (value == this)
                {
                    throw new ArgumentException("Selflinked nodes are not allowed");
                }
                else
                {
                    next = value;
                }
            }
        }
        #endregion

        #region Constructors
        public LinkedNode(int value)
        {
            this.value = value;
        }

        public LinkedNode(int value, LinkedNode next): this(value)
        {
            Next = next;
        }
        #endregion
    }
}
