using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistyka_1
{
    public class Activity
    {
        public int id;          //zmiń na private
        public float duration;
        // public int[] successors;
        public List<int> successors=new List<int>();




        /*  public int get_id()
          {
              return id;
          }
          public int get_duration()
          {
              return duration;
          }
          public int get_est()
          {
              return est;
          }
          public int get_1st()
          {
              return lst;
          }
          public int get_eet()
          {
              return eet;
          }
          public int get_let()
          {
              return let;
          }
          public Activity[] get_successors()
          {
              return successors;
          }
          public Activity[] get_predecessors()
          {
              return predecessors;
          }


          public void set_id( int id)
          {
              this.id = id;
          }
          public void set_duration(int duration)
          {
              this.duration = duration;
          }
          public void set_est(int est)
          {
              this.est = est;
          }
          public void set_lst(int lst)
          {
              this.lst = lst;
          }
          public void set_eet(int eet)
          {
              this.eet = eet;
          }
          public void set_let(int let)
          {
              this.let = let ;
          }
          public void set_successors(Activity successors)
          {
              this.successors = successors;
          }
          public void set_let(int let)
          {
              this.let = let;
          }*/

    }
}
