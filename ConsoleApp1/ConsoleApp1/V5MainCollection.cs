using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace GryaznovLab2
{
    public class V5MainCollection : IEnumerable<V5Data>
    {
        private List<V5Data> V5List { get; set; }
        public V5MainCollection()
        {
            V5List = new List<V5Data>();
        }
        public IEnumerator<V5Data> GetEnumerator()
        {
            return V5List.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return V5List.GetEnumerator();
        }
        public int Count() => V5List.Count;
        public void Add(V5Data item)
        {
            V5List.Add(item);
        }
        public bool Remove(string id, DateTime date)
        {
            bool flag = false;
            for (int i = 0; i < V5List.Count; i++)
            {
                if (Equals(V5List[i].InfoData, id) == true
                        && V5List[i].Time.CompareTo(date) == 0)
                {
                    V5List.RemoveAt(i);
                    i--;
                    flag = true;
                }
            }
            return flag;
        }
        public void AddDefaults()
        {
            Random rand = new Random();
            int NElem = rand.Next(3, 7), Rand1, Rand2;
            Grid2D Gr;
            V5DataCollection DataColl;
            V5DataOnGrid DataGrid;
            V5List = new List<V5Data>();
            for (int i = 0; i < NElem; i++)
            {
                Rand1 = rand.Next(0, 2);
                Gr = new Grid2D(10, 10, 3, 3);
                if (Rand1 == 0)
                {
                    DataGrid = new V5DataOnGrid("", DateTime.Now, Gr);
                    DataGrid.InitRandom(0, 10);
                    V5List.Add(DataGrid);
                }
                else
                {
                    Rand2 = rand.Next(1, 10);
                    DataColl = new V5DataCollection("", DateTime.Now);
                    DataColl.InitRandom(Rand2, 4, 5, 1, 4);
                    V5List.Add(DataColl);
                }
            }
        }
        public override string ToString()
        {
            string str = "";
            foreach (V5Data item in V5List)
            {
                str += item.ToString();
            }
            str += "\n\n";
            return str;
        }
        public string ToLongString(string format)
        {
            string str = "";
            foreach (V5Data item in V5List)
            {
                str += item.ToLongString(format);
            }
            str += "\n\n";
            return str;
        }
        public float MinVecLenDC
        {
            get
            {
                var query = from elem in (from data in V5List
                                          where data is V5DataCollection
                                          select (V5DataCollection)data)
                            from item in elem
                            select item.Value.Length();
                return query.Min();
            }
        }
        public float MinVecLenDG
        {
            get
            {
                var query = from elem in (from data in V5List
                                          where data is V5DataOnGrid
                                          select (V5DataOnGrid)data)
                            from item in elem
                            select item.Value.Length();
                return query.Min();
            }
        }
        public IEnumerable<DataItem> CollMinElems     
        {
            get
            {
                if (MinVecLenDC < MinVecLenDG)
                {
                    var query1 = //from data in V5List
                                 from elems in
                                (from dat in V5List
                                 where dat is V5DataCollection
                                 select (V5DataCollection)dat)
                                 from item in elems
                                 where item.Value.Length() == MinVecLenDC
                                 select item;
                    return query1;
                }
                else
                {
                    var query2 = //from data in V5List
                                 from elems in
                                (from dat in V5List
                                 where dat is V5DataOnGrid
                                 select (V5DataOnGrid)dat)
                                 from item in elems
                                 where item.Value.Length() == MinVecLenDG
                                 select item;
                    return query2;
                }
            }
        }
        public IEnumerable<Vector2> Points
        {
            get
            {
                IEnumerable<Vector2> query1 = from elem in 
                                                  (from data in V5List
                                                   where data is V5DataOnGrid
                                                   select (V5DataOnGrid)data)
                                                   from item in elem
                                                   select item.Coord;
                IEnumerable<Vector2> query2 = from elem in
                                                  (from data in V5List
                                                   where data is V5DataCollection
                                                   select (V5DataCollection)data)
                                                   from item in elem
                                                   select item.Coord;
                var query = from item in query1.Except(query2)
                            select item;
                return query;
            }
        }

    }
}
