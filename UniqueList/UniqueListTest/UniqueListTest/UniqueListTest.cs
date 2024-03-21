namespace UniqueListTest;

using UniqueListSpace;

[TestFixture]
    public class UniqueListTests
    {
        [Test]
        public void Add_AddUniqueElements_ElementAddedSuccessfully()
        {
            UniqueList<int> uniqueList = new UniqueList<int>();

            uniqueList.Add(1);
            uniqueList.Add(2);
            uniqueList.Add(3);

            Assert.That(uniqueList[0], Is.EqualTo(3));
            Assert.That(uniqueList[1], Is.EqualTo(2));
            Assert.That(uniqueList[2], Is.EqualTo(1));
        }

        [Test]
        public void Add_AddDuplicateElement_ExceptionThrown()
        {
            UniqueList<int> uniqueList = new UniqueList<int>();

            uniqueList.Add(1);

            Assert.Throws<ElementIsAlreadyInsideException>(() => uniqueList.Add(1));
        }

        [Test]
        public void Indexer_GetElementByIndex_ReturnsCorrectElement()
        {
            UniqueList<string> uniqueList = new UniqueList<string>();
            uniqueList.Add("one");
            uniqueList.Add("two");

            Assert.That(uniqueList[0], Is.EqualTo("two"));
        }

        [Test]
        public void Accessing_EmptyList_ThrowsException()
        {
            UniqueList<int> uniqueList = new ();
            
            Assert.Throws<IndexOutOfRangeException>(() => uniqueList.RemoveAt(2));
        }

        [Test]
        public void IndexOutOfRange_ThrowsException()
        {
            UniqueList<int> uniqueList = new ();

            uniqueList.Add(1);
            uniqueList.Add(2);
            
            Assert.Throws<IndexOutOfRangeException>(() => uniqueList.RemoveAt(6));
        }

        [Test]
        public void Remove_Element_RemovedCorrectly()
        {
            UniqueList<int> uniqueList = new ();

            uniqueList.Add(1);
            uniqueList.Add(2);
            uniqueList.Add(3);

            uniqueList.RemoveAt(1);
            
            Assert.That(uniqueList[0], Is.EqualTo(3));
            Assert.That(uniqueList[1], Is.EqualTo(1));

            uniqueList.RemoveAt(0);

            Assert.That(uniqueList[0], Is.EqualTo(1));
            
        }
    }