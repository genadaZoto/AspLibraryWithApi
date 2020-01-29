using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSampleConsume.Tools.Models
{
    public class bookModel
    {
        public List<Publisher> publishers { get; set; }
        public string pagination { get; set; }
        public Identifiers identifiers { get; set; }
        public Classifications classifications { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string notes { get; set; }
        public int number_of_pages { get; set; }
        public Cover cover { get; set; }
        public List<SubjectPlace> subject_places { get; set; }
        public List<Subject> subjects { get; set; }
        public List<SubjectPeople> subject_people { get; set; }
        public string key { get; set; }
        public List<Author> authors { get; set; }
        public string publish_date { get; set; }
        public string by_statement { get; set; }
        public List<PublishPlace> publish_places { get; set; }
        public List<SubjectTime> subject_times { get; set; }
    }
}
