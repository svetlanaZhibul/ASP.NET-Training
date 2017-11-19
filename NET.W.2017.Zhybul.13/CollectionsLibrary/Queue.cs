using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsLibrary
{
    public class Queue<T> : IEnumerator<T>
    {
        private T[] array;
        private int head;
        private int tail;
        private int capacity;
        private int pointer = -1;

        public Queue(int capacity)
        {
            array = new T[capacity];
            head = 0;
            tail = 0;
            this.capacity = capacity;
        }

        public Queue(IEnumerable<T> array)
        {
            this.capacity = array.Count() * 3 / 2;
            this.array = new T[capacity];
            int i = 0;
            foreach (T elem in array)
            {
                this.array[i] = elem;
                i++;
            }

            head = 0;
            tail = array.Count();
        }

        public int Count { get; set; }

        public T Current
        {
            get
            {
                if (pointer == -1)
                {
                    throw new InvalidOperationException();
                }
                
                return array[pointer];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return (object)Current;
            }
        }

        /// <summary>
        /// Dispose array.
        /// </summary>
        /// Not implemented yet.
        public void Dispose()
        {
        }

        /// <summary>
        /// Moves pointer one position forwards.
        /// </summary>
        /// <returns>Value representing possibility of moving pointer.</returns>
        public bool MoveNext()
        {
            if (pointer < Count - 1)
            {
                pointer++;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Rewrite current value of pointer to default.
        /// </summary>
        public void Reset()
        {
            pointer = -1;
        }

        /// <summary>
        /// Popping element out of queue.
        /// </summary>
        /// <returns>Popped element.</returns>
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            T local = array[head];
            array[head] = default(T);
            head = (head + 1) % array.Length;
            Count--;
            return local;
        }

        /// <summary>
        /// Add element to queue.
        /// </summary>
        /// <param name="item">Element to be added.</param>
        public void Enqueue(T item)
        {
            if (Count == array.Length)
            {
                var capacity = array.Length * 3 / 2;
                if (capacity < (array.Length + 4))
                {
                    capacity = array.Length + 4;
                }

                Array.Resize(ref array, capacity);
            }

            array[tail] = item;
            tail = (tail + 1) % array.Length;
            Count++;
        }

        /// <summary>
        /// Show first element of queue.
        /// </summary>
        /// <returns>First element.</returns>
        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return array[head];
        }
    }
}
