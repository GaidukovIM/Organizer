using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Text.Json;
using System.IO;
using System.Threading;

namespace Organizer
{
    public partial class Form1 : Form
    {
        public  Hashtable notes;
        public DateTime currentDate;
        public Thread checkTime;
        List<DateTime> Done=new List<DateTime>();

        public Form1()
        {
            InitializeComponent();
            notes = new Hashtable();
            currentDate = new DateTime();
            currentDate = monthCalendar1.TodayDate;
           //notes.Add(currentDate,new List<Note>());
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;
            this.GetNotesFromFile();
            Thread t = new Thread(new ParameterizedThreadStart(ThreadCheckingTime));
            t.IsBackground = true;
            t.Start(notes);
        }
        private void ThreadCheckingTime(object obj)
        {
            while (true)
            {
                checkCurTime((Hashtable)notes);
                Thread.Sleep(1000);
            }
        }
        private void checkCurTime(Hashtable notes)
        {
            DateTime now = DateTime.Now;
            foreach (var l in notes.Values)
            {
                foreach (var n in (List<Note>)l)
                    if (!Done.Contains(((Note)n).time) && ((Note)n).time.DayOfYear == now.DayOfYear && ((Note)n).time <= now)
                    {
                        Done.Add(((Note)n).time);
                        Console.Beep();
                        MessageBox.Show(((Note)n).ToString());
                    }
            }
        }
        private void buttonAddNote_Click(object sender, EventArgs e)
        {
            var dialog = new WindowAddNote();
            if(dialog.ShowDialog()==DialogResult.OK)
            {
            if (notes[dialog.chosenTime.Date.ToString()] == null) notes.Add(dialog.chosenTime.Date.ToString(), new List<Note>());
                ((List<Note>)notes[dialog.chosenTime.Date.ToString()]).Add(dialog.Notenew);
                listBoxNotes.Items.Clear();
                ((List<Note>)notes[dialog.chosenTime.Date.ToString()]).Sort();
                if (notes[currentDate.ToString()]==null)
                notes.Add(currentDate.ToString(), new List<Note>());
                if (((List<Note>)notes[currentDate.ToString()]).Count!=0)
                foreach (var x in ((List<Note>)notes[currentDate.ToString()]))
                {
                    listBoxNotes.Items.Add(x.ToString());
                }
            }
        }

        private void buttonCheckNote_Click(object sender, EventArgs e)
        {
            if (listBoxNotes.SelectedIndex == -1) return;
            MessageBox.Show(((List<Note>)notes[currentDate.ToString()])[listBoxNotes.SelectedIndex].text);
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
           currentDate= e.Start.Date;
            if (notes[currentDate.ToString()] == null) notes.Add(currentDate.ToString(), new List<Note>());
            listBoxNotes.Items.Clear();
            foreach (var x in ((List<Note>)notes[currentDate.ToString()]))
            {
                listBoxNotes.Items.Add(x.ToString());
            }
        }

        internal void SaveNotesToFile()
        {
            Hashtable tmp=new Hashtable();
            foreach(var key in notes.Keys)
            {
                tmp.Add(key, new List<NoteSerializer>());
                foreach(var n in (List<Note>)notes[key])
                {
                    ((List<NoteSerializer>)tmp[key]).Add((NoteSerializer)n);
                }
            }
            using(StreamWriter file =new StreamWriter("Notes.txt"))
            {
                file.Write(JsonSerializer.Serialize<Hashtable>(tmp));
            }

        }
        private void GetNotesFromFile()
        {
            Hashtable tmp = new Hashtable();
            string s;
            using (var file = new StreamReader("Notes.txt"))
            {
                s=file.ReadToEnd();
                if (s == "" || s=="{}") return;
            }
                tmp = JsonSerializer.Deserialize<Hashtable>(s);
            if(tmp!=null)
            {
                notes.Clear();
                foreach(var key in tmp.Keys)
                {
                    notes.Add(key, new List<Note>());
                   
                    foreach(var ns in ((JsonElement)tmp[key]).EnumerateArray())
                    {
                        prioritylevel b = (prioritylevel)Convert.ToInt32((ns.GetProperty("priority")).ToString());
                        DateTime d = DateTime.Parse(ns.GetProperty("time").ToString());
                        ((List<Note>)notes[key]).Add(new Note((ns.GetProperty("name")).ToString(),
                           b,ns.GetProperty("text").ToString(),d));
                    }
                }
                listBoxNotes.Items.Clear();
                if ((List<Note>)notes[currentDate.ToString()] == null)
                    notes.Add(currentDate.ToString(), new List<Note>());
                foreach (var x in ((List<Note>)notes[currentDate.ToString()]))
                {
                    listBoxNotes.Items.Add(x.ToString());
                }
            }
        }

        private void Form1_Closing(object sender,System.ComponentModel.CancelEventArgs e)
        {
            this.SaveNotesToFile();
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxNotes.SelectedIndex == -1) return;
            ((List<Note>)notes[currentDate.ToString()]).RemoveAt(listBoxNotes.SelectedIndex);
            this.SaveNotesToFile();
            listBoxNotes.Items.Clear();
            foreach (var x in ((List<Note>)notes[currentDate.ToString()]))
            {
                listBoxNotes.Items.Add(x.ToString());
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            notes.Clear();
            this.SaveNotesToFile();
            listBoxNotes.Items.Clear();
        }
    }
}
