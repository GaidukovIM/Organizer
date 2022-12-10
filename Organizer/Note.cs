using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Organizer
{
    public enum prioritylevel {First,High,Mid,Low }
    public class Note:IComparable
    {
        internal string name;
        internal prioritylevel priority;
        public string text;
        internal DateTime time;
        public Note(string n,prioritylevel p, string t, DateTime time)
        {
            name = n;
            priority = p;
            text = t;
            this.time = time;
        }

        public int CompareTo(Object n)
        {
            return ((int)this.priority).CompareTo((int)(((Note)n).priority));
        }
        public Note() { name = null; text = null; }

        public override string ToString()
        {
            return time.ToString()+"    "+name +"  "+ priority.ToString();
        }
        public static explicit operator Note(NoteSerializer ns)
        {
            return new Note(ns.NameS, ns.PriorityS, ns.TextS,ns.TimeS);
        }
    }
}
