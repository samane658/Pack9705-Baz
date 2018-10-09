using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RandomExamQuestion
{
    class Exam : IEnumerable
    {
        public string Name { get; set; }
        public Question[] Questions { get; set; }

        public Question[] QSelect10 = new Question[10];

        public void select10q(Question[] _question)
        {
            Question[] allTempQ = _question;
            Random r = new Random();
            int counter;
           // Console.WriteLine($"numberofQuestionAll : {Questions.Length}");
            for (int i = 1; i <= QSelect10.Length; i++)
            {
                counter = r.Next(0, allTempQ.Length);
                
                    QSelect10[i-1] = allTempQ[counter];
                    allTempQ[counter] = allTempQ[(allTempQ.Length) - i];


            }
        }
        public IEnumerator GetEnumerator()
        {

            select10q(this.Questions);

            return new pointer( this.QSelect10);
        }
    }

    class pointer : IEnumerator
    {
       private Question[] questions;
        
        int counter=-1;
        public pointer(Question[] question )
        {
            questions = question;
           
        }

        public bool MoveNext()
        {
            counter++;
            return (counter < questions.Length);
        }
        public object Current
        {
            get
            {
                return questions[counter];
            }
        }

        public void Reset()
        {
            counter = -1;
        }
    }
}
