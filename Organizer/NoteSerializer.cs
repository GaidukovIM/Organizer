using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
namespace Organizer
{
    public class NoteSerializer
    {
        [JsonPropertyName("name")]
        public string NameS { get; set; }
        [JsonPropertyName("priority")]
        public prioritylevel PriorityS { get; set; }
        [JsonPropertyName("text")]
        public string TextS { get; set; }
        [JsonPropertyName("time")]
        public DateTime TimeS { get; set; }
        public NoteSerializer(string nameS, prioritylevel priorityS, string textS, DateTime timeS)
        {
            NameS = nameS;
            PriorityS = priorityS;
            TextS = textS;
            TimeS = timeS;
        }
        public static explicit operator NoteSerializer(Note n)
        {
            return new NoteSerializer(n.name, n.priority, n.text,n.time);
        }
        
    }
}
