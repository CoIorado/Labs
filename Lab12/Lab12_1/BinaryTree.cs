using System;
using System.Collections;
using System.Collections.Generic;
using Human;

namespace Lab12
{
    public enum TreeType
    {
        Search,
        Balanced
    }
    public class BinaryTree : IEnumerable<IHuman>
    {
        public Node Root { get; private set; }

        public int Count
        {
            get => Preorder().Count;
        }

        public int MaxLevel
        {
            get
            {
                if (Root == null)
                    return 0;

                List<int> levels = LevelList(Root);
                levels.Sort();
                return levels[levels.Count - 1];
            }
        }

        public TreeType TreeType { get; private set; }

        public BinaryTree(TreeType treeType)
        {
            Initialize(null);
            this.TreeType = treeType;
        }

        public void Add(IHuman data)
        {
            if (Root == null)
            {
                Initialize(new Node(data));
                return;
            }

            if (Contains(data.Age))
            {
                throw new SameDataException($"В коллекции уже существует элемент с заданным значением Age ({data.Age})");
            }

            Node newNode = new Node(data);
            if (TreeType == TreeType.Balanced)
            {
                List<IHuman> elements = Preorder();
                elements.Add(data);
                IHuman[] dataArray = elements.ToArray();
                Clear();

                Node.index = 0;
                Root = Node.BalancedTree(dataArray.Length, dataArray, 0);
            }
            else
            {
                Root.AddSorted(newNode);
            }
        }

        public IHuman Find(IHuman data)
        {
            List<IHuman> list = Inorder();

            foreach (IHuman human in list)
            {
                if (human == data)
                    return human;
            }

            return null;
        }

        public IHuman Find(string name)
        {
            List<IHuman> list = Inorder();

            foreach (IHuman human in list)
            {
                if (human.Name.ToLower() == name.ToLower())
                    return human;
            }

            return null;
        }

        public IHuman Find(int age)
        {
            List<IHuman> list = Inorder();

            foreach (IHuman human in list)
            {
                if (human.Age == age)
                    return human;
            }

            return null;
        }

        public IHuman Find(Gender gender)
        {
            List<IHuman> list = Inorder();

            foreach (IHuman human in list)
            {
                if (human.Gender == gender)
                    return human;
            }

            return null;
        }

        public List<IHuman> FindAll(IHuman data)
        {
            List<IHuman> list = Inorder();
            List<IHuman> result = new List<IHuman>();

            foreach (IHuman human in list)
            {
                if (human == data)
                    result.Add(human);
            }

            return result;
        }

        public List<IHuman> FindAll(string name)
        {
            List<IHuman> list = Inorder();
            List<IHuman> result = new List<IHuman>();

            foreach (IHuman human in list)
            {
                if (human.Name.ToLower() == name.ToLower())
                    result.Add(human);
            }

            return result;
        }

        public List<IHuman> FindAll(Gender gender)
        {
            List<IHuman> list = Inorder();
            List<IHuman> result = new List<IHuman>();

            foreach (IHuman human in list)
            {
                if (human.Gender == gender)
                    result.Add(human);
            }

            return result;
        }

        public bool Contains(IHuman data)
        {
            List<IHuman> list = Inorder();

            foreach (IHuman human in list)
            {
                if (human == data)
                    return true;
            }

            return false;
        }

        public bool Contains(string name)
        {
            List<IHuman> list = Inorder();

            foreach (IHuman human in list)
            {
                if (human.Name.ToLower() == name.ToLower())
                    return true;
            }

            return false;
        }

        public bool Contains(int age)
        {
            List<IHuman> list = Inorder();

            foreach (IHuman human in list)
            {
                if (human.Age == age)
                    return true;
            }

            return false;
        }

        public bool Contains(Gender gender)
        {
            List<IHuman> list = Inorder();

            foreach (IHuman human in list)
            {
                if (human.Gender == gender)
                    return true;
            }

            return false;
        }

        public bool Remove(IHuman data)
        {
            if (Root == null)
            {
                return false;
            }

            List<IHuman> elements = Preorder();

            bool isRemoved = elements.Remove(data);
            if (!isRemoved)
            {
                return false;
            }

            Clear();

            if (TreeType == TreeType.Balanced)
            {
                IHuman[] dataArray = elements.ToArray();
                Clear();

                Node.index = 0;
                Root = Node.BalancedTree(dataArray.Length, dataArray, 0);
            }
            else
            {
                foreach (IHuman element in elements)
                {
                    Add(element);
                }
            }

            return true;
        }

        public bool Remove(string name)
        {
            if (Root == null)
            {
                return false;
            }

            List<IHuman> elements = Preorder();

            bool isRemoved = false;
            foreach (IHuman element in elements)
            {
                if (element.Name.ToLower() == name.ToLower())
                {
                    isRemoved = elements.Remove(element);
                    break;
                }
            }

            if (!isRemoved)
            {
                return false;
            }

            Clear();

            if (TreeType == TreeType.Balanced)
            {
                IHuman[] dataArray = elements.ToArray();
                Clear();

                Node.index = 0;
                Root = Node.BalancedTree(dataArray.Length, dataArray, 0);
            }
            else
            {
                foreach (IHuman element in elements)
                {
                    Add(element);
                }
            }

            return true;
        }

        public bool Remove(int age)
        {
            if (Root == null)
            {
                return false;
            }

            List<IHuman> elements = Preorder();

            bool isRemoved = false;
            foreach (IHuman element in elements)
            {
                if (element.Age == age)
                {
                    isRemoved = elements.Remove(element);
                    break;
                }
            }

            if (!isRemoved)
            {
                return false;
            }

            Clear();

            if (TreeType == TreeType.Balanced)
            {
                IHuman[] dataArray = elements.ToArray();
                Clear();

                Node.index = 0;
                Root = Node.BalancedTree(dataArray.Length, dataArray, 0);
            }
            else
            {
                foreach (IHuman element in elements)
                {
                    Add(element);
                }
            }

            return true;
        }

        public bool Remove(Gender gender)
        {
            if (Root == null)
            {
                return false;
            }

            List<IHuman> elements = Preorder();

            bool isRemoved = false;
            foreach (IHuman element in elements)
            {
                if (element.Gender == gender)
                {
                    isRemoved = elements.Remove(element);
                    break;
                }
            }

            if (!isRemoved)
            {
                return false;
            }

            Clear();

            if (TreeType == TreeType.Balanced)
            {
                IHuman[] dataArray = elements.ToArray();
                Clear();

                Node.index = 0;
                Root = Node.BalancedTree(dataArray.Length, dataArray, 0);
            }
            else
            {
                foreach (IHuman element in elements)
                {
                    Add(element);
                }
            }

            return true;
        }

        public bool RemoveAll(IHuman data)
        {
            if (Root == null)
            {
                return false;
            }

            List<IHuman> elements = Preorder();

            bool isRemoved = false;
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i] == data)
                {
                    elements.RemoveAt(i--);
                    isRemoved = true;
                }
            }

            if (!isRemoved)
            {
                return false;
            }

            Clear();

            if (TreeType == TreeType.Balanced)
            {
                IHuman[] dataArray = elements.ToArray();
                Clear();

                Node.index = 0;
                Root = Node.BalancedTree(dataArray.Length, dataArray, 0);
            }
            else
            {
                foreach (IHuman element in elements)
                {
                    Add(element);
                }
            }

            return true;
        }

        public bool RemoveAll(string name)
        {
            if (Root == null)
            {
                return false;
            }

            List<IHuman> elements = Preorder();

            bool isRemoved = false;
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].Name.ToLower() == name.ToLower())
                {
                    elements.RemoveAt(i--);
                    isRemoved = true;
                }
            }

            if (!isRemoved)
            {
                return false;
            }

            Clear();

            if (TreeType == TreeType.Balanced)
            {
                IHuman[] dataArray = elements.ToArray();
                Clear();

                Node.index = 0;
                Root = Node.BalancedTree(dataArray.Length, dataArray, 0);
            }
            else
            {
                foreach (IHuman element in elements)
                {
                    Add(element);
                }
            }

            return true;
        }

        public bool RemoveAll(Gender gender)
        {
            if (Root == null)
            {
                return false;
            }

            List<IHuman> elements = Preorder();

            bool isRemoved = false;
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].Gender == gender)
                {
                    elements.RemoveAt(i--);
                    isRemoved = true;
                }
            }

            if (!isRemoved)
            {
                return false;
            }

            Clear();

            if (TreeType == TreeType.Balanced)
            {
                IHuman[] dataArray = elements.ToArray();
                Clear();

                Node.index = 0;
                Root = Node.BalancedTree(dataArray.Length, dataArray, 0);
            }
            else
            {
                foreach (IHuman element in elements)
                {
                    Add(element);
                }
            }

            return true;
        }

        public void IntoSearch()
        {
            if (TreeType == TreeType.Search)
            {
                return;
            }

            TreeType = TreeType.Search;

            List<IHuman> elements = Preorder();
            Clear();

            foreach (IHuman data in elements)
            {
                Add(data);
            }
        }

        public void IntoBalanced()
        {
            if (TreeType == TreeType.Balanced)
            {
                return;
            }

            TreeType = TreeType.Balanced;

            List<IHuman> elements = Preorder();
            IHuman[] dataArray = elements.ToArray();
            Clear();

            Node.index = 0;
            Root = Node.BalancedTree(dataArray.Length, dataArray, 0);
        }

        public void Clear()
        {
            Initialize(null);
        }

        public void Print()
        {
            if (Root == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("> BINARY TREE IS EMPTY <");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i < MaxLevel; i++)
                Console.Write("-------");
            Console.WriteLine();
            Console.ResetColor();

            Root.Print();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i < MaxLevel; i++)
                Console.Write("-------");
            Console.WriteLine();
            Console.ResetColor();
        }

        //Префиксный обход дерева:
        //1. Элемент
        //2. Правое
        //3. Левое
        public List<IHuman> Preorder()
        {
            if (Root == null)
            {
                return new List<IHuman>();
            }

            return Preorder(Root);
        }

        private List<IHuman> Preorder(Node node)
        {
            List<IHuman> list = new List<IHuman>();

            if (node != null)
            {
                list.Add(node.Data);

                if (node.Left != null)
                {
                    list.AddRange(Preorder(node.Left));
                }

                if (node.Right != null)
                {
                    list.AddRange(Preorder(node.Right));
                }
            }

            return list;
        }

        //Постфиксный обход дерева:
        //1. Левое
        //2. Правое
        //3. Элемент
        public List<IHuman> Postorder()
        {
            if (Root == null)
            {
                return new List<IHuman>();
            }

            return Postorder(Root);
        }

        private List<IHuman> Postorder(Node node)
        {
            List<IHuman> list = new List<IHuman>();

            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(Postorder(node.Left));
                }

                if (node.Right != null)
                {
                    list.AddRange(Postorder(node.Right));
                }

                list.Add(node.Data);
            }

            return list;
        }

        //Инфиксный обход дерева:
        //1. Левое
        //2. Элемент
        //3. Правое
        public List<IHuman> Inorder()
        {
            if (Root == null)
            {
                return new List<IHuman>();
            }

            return Inorder(Root);
        }

        private List<IHuman> Inorder(Node node)
        {
            List<IHuman> list = new List<IHuman>();

            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(Inorder(node.Left));
                }

                list.Add(node.Data);

                if (node.Right != null)
                {
                    list.AddRange(Inorder(node.Right));
                }
            }

            return list;
        }

        private List<int> LevelList(Node node)
        {
            if (node == null)
                return null;

            List<int> levels = new List<int>();

            if (node != null)
            {
                levels.Add(node.Level);

                if (node.Left != null)
                {
                    levels.AddRange(LevelList(node.Left));
                }

                if (node.Right != null)
                {
                    levels.AddRange(LevelList(node.Right));
                }
            }

            levels.Sort();
            return levels;
        }

        public void Initialize(Node node)
        {
            Root = node;
        }

        public IEnumerator<IHuman> GetEnumerator()
        {
            List<IHuman> list = Inorder();

            foreach (IHuman data in list)
            {
                yield return data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}