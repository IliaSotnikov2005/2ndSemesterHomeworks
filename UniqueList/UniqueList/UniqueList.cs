namespace UniqueListSpace
{
    class UniqueList<T> : SingleLinkedList<T>
    {
        public new void Add(T element)
        {
            if (this.Contains(element))
            {
                throw new ElementIsAlreadyInsideException();
            }

            base.Add(element);
        }

        public new T this[int index]
        {
            get { return GetNode(index).value; }
            set { TrySet(GetNode(index), value); }
        }

        private void TrySet(Node element, T value)
        {
            if (this.Contains(element.value))
            {
                throw new ElementIsAlreadyInsideException();
            }

            element.value = value;
        }

        private bool Contains(T element)
        {
            Node current = head;
            for (int i = 0; i < Size; ++i)
            {
                if (current.value.Equals(element))
                {
                    return true;
                }
                current = current.next;
            }

            return false;
        }
    }
}

class ElementIsAlreadyInsideException : Exception
{
}