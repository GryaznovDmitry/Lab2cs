using System;
using System.Collections.Generic;
using System.Numerics;

namespace GryaznovLab2
{
    public abstract class V5Data
    {
        public string InfoData { get; set; }
        public DateTime Time { get; set; }
       // public abstract List<DataItem> DataItems { get; set; }
        public V5Data(string id = "Empty Data", DateTime t = default)
        {
            InfoData = id;
            Time = t;
            //DataItems = new List<DataItem>();
        }
        public abstract Vector2[] NearEqual(float eps);
        public abstract string ToLongString();
        public override string ToString()
        {
            return InfoData + ", " + Time.ToString() + "\n\n";
        }
        public abstract string ToLongString(string format);
    }
}
