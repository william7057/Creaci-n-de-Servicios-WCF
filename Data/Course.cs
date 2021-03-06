using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Data
{
    [Serializable]
    [DataContract]
    public class Course
    {
        [DataMember]
        public int CourseId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Duration { get; set; }
        [DataMember]
        public string InstrctorName { get; set; }
    }
}
