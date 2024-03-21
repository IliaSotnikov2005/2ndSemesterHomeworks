// <copyright file="UniqueList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UniqueListSpace
{
    /// <summary>
    /// Unique list class.
    /// </summary>
    /// <typeparam name="T">Type of elements in list.</typeparam>
    public class UniqueList<T> : SingleLinkedList<T>
    {
        /// <summary>
        /// Gives element of list by index.
        /// </summary>
        /// <param name="index">Index of the element.</param>
        public new T this[int index]
        {
            get { return this.GetNode(index).Value; }
            set { this.TrySet(this.GetNode(index), value); }
        }

        /// <summary>
        /// Adds element to the list.
        /// </summary>
        /// <param name="element">Element to be added.</param>
        public new void Add(T element)
        {
            if (this.Contains(element))
            {
                throw new ElementIsAlreadyInsideException();
            }

            base.Add(element);
        }

        private void TrySet(Node element, T value)
        {
            if (this.Contains(element.Value))
            {
                throw new ElementIsAlreadyInsideException();
            }

            element.Value = value;
        }

        private bool Contains(T element)
        {
            Node? current = this.Head;
            while (current != null)
            {
                if (current.Value!.Equals(element))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }
    }
}