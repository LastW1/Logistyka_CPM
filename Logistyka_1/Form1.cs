using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logistyka_1



{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          

        }

        List<float> duration_of_crit = new List<float>();
        List<int> act_draw = new List<int>();
        List<Path> suma = new List<Path>();
        List<Activity> list = new List<Activity>();
        List<Label> wyniki = new List<Label>();
        int path_count = 0;
        float critical_path;
        int critical_id;

        void search(int where,int prev, int prev_path)
        {
            if (list[where].successors.Count == 0)
            {
              //  return;
               
            }

            if (where == 0)
            {
               
                    suma.Add(new Path());
                    suma[path_count].suma.Add(0);

                
            }


            int i = 0;
            foreach (int j in list[where].successors)
            {
                if (i == 0)
                {
                    suma[path_count].suma.Add(j);
                    search(j,j,path_count);
                    i++;
                }
                else
                {
                    path_count++;
                    suma.Add(new Path());


                    int x = 0;
                    while (true)
                    {
                     //   System.Console.Write(suma[prev_path].suma[x] + " " + prev);
                     //   System.Console.WriteLine();
                      suma[path_count].suma.Add(suma[prev_path].suma[x]);       
                        if (suma[prev_path].suma[x] == prev)
                        {
                            break;
                        }
                        x++;
                    }
              //      foreach (int x in suma[prev_path].suma)   //nadpisywanie 
               //     {   
                  //      suma[path_count].suma.Add(x);
               //     }
                    
                    suma[path_count].suma.Add(j);
                    search(j,j,path_count);
                  
                }
            }

         

        }

        void show_max()
        {
            float max = 0;
            int max_id=0;
            for(int i=0; i<suma.Count; i++)
            {
                if (suma[i].total_time > max)
                {
                    max = suma[i].total_time;
                    max_id = i;
                }
            }

            wyniki[max_id].ForeColor = System.Drawing.Color.Red;
            label5.Text = ("czas ścieżki krytycznej to: " + max);
            critical_path = max;
            critical_id = max_id;


        }

        TextBox[] data_activity = new TextBox[17];
        TextBox[] data_time = new TextBox[17];
        TextBox[] data_neighbour = new TextBox[17];


        static int text_counter = 1;



        private void Button1_Click(object sender, EventArgs e)  //dodanie nowego
        {
            list.Add(new Activity());

          
    
            
                TextBox multi1 = new TextBox();
                multi1.Text = text_counter.ToString();
                list[text_counter - 1].id = text_counter;  //id liczone od 1
                data_activity[text_counter - 1] = multi1;
                Point text_point1 = new Point(25, 20 * text_counter + 20);
                multi1.Location = text_point1;
                multi1.Width = 150;

                flowLayoutPanel1.Controls.Add(multi1);

                TextBox multi2 = new TextBox();
                multi2.Text = 0.ToString();
                data_time[text_counter - 1] = multi2;
                Point text_point2 = new Point(140, 20 * text_counter + 20);
                multi2.Location = text_point2;
                multi2.Width = 150;
                flowLayoutPanel1.Controls.Add(multi2);


                TextBox multi3 = new TextBox();
                multi3.Text = 0.ToString();
                data_neighbour[text_counter - 1] = multi3;
                Point text_point3 = new Point(260, 20 * text_counter + 20);
                multi3.Location = text_point3;
                multi3.Width = 150;
                flowLayoutPanel1.Controls.Add(multi3);

                text_counter++;
                if (text_counter == 18)        //pilnowanie żeby nie wyjechać za zakres
                    Application.Exit();
                if (text_counter == 17)
                    MessageBox.Show("nie można przyjąć więcej argumentów");
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
           
        }

        private void button2_Click(object sender, EventArgs e)   //oblicz
        {
            int count = text_counter - 1;  //liczba elementów
            if (count < 2)        //zamykanie kiedy brakuje argumentów
                Application.Exit();
            else
            {

                //tworzenie tablicy z informacjami o czynnosciach poprzedzajacych
                int[,] previous = new int[count, count - 1];
                for (int i = 0; i < count; i++)
                    for (int j = 0; j < count - 1; j++)
                    {
                        previous[i, j] = 0;

                    }


                // MessageBox.Show(((data_neighbour[0]).Text).Length + " ");

              
                 for (int i = 0; i < count; i++)
                 {

                     int indeks = 0;
                     for (int j = 0; j < (((data_neighbour[i]).Text).Length); j++)
                     {
                        if ( (data_neighbour[i].Text)[j] == ',')
                             continue;
                        if (j != (((data_neighbour[i]).Text).Length) - 1 && (data_neighbour[i].Text)[j+1] != ',')
                        {

                            char[] tmp = { ((data_neighbour[i].Text)[j]), ((data_neighbour[i].Text)[j + 1]) };
                            previous[i, indeks] = int.Parse(new String(tmp));
                            j++;
                            indeks++;
                            continue;
                        }
                        previous[i,indeks] = ((data_neighbour[i].Text)[j]) - '0';
                         indeks++;
                     }
                 }

               
     
                int[,] matrix = new int[count, count];
                //i w tablicy odpowiada za czynność
                //j za jej sąsiadów

                //zerowanie tablicy
                for (int i = 0; i < count ; i++)
                    for (int j = 0; j < count ; j++)
                    {
                        matrix[i, j] = 0;

                    }

                //tablica sąsiedztwa
                for (int id = 0; id < count ; id++)
                    {
                       for(int i=0; i<count; i++)
                        for(int j=0; j<count-1; j++)
                        {
                            if (id+1 == previous[i,j] )
                                matrix[id, i] = 1;
                        }
                    }



              //zapisywanie sąsiadów
                for (int id = 0; id < count; id++)
                {
                    for (int i = 0; i < count; i++)
                        if (matrix[id, i] == 1)
                        {
                            list[id].successors.Add(i);
                        }
                    

                }




             search(0,0,0);
                int number = 0;
                          //wyświetlanie wyników
                           foreach (Path i in suma)                 
                                 {

                            Label result = new Label();

                                 foreach (int xD in i.suma)
                                     {
                                      result.Text+=((xD+1).ToString()+ " ");
                                     }
                                      flowLayoutPanel2.Controls.Add(result);
                                      wyniki.Add(result);
                                  }

                           
                           //zapisywanie czasu trwania czynności
             for(int i = 0; i<count; i++)
                {
                     list[i].duration = float.Parse(data_time[i].Text, System.Globalization.CultureInfo.InvariantCulture);
                  //  System.Console.WriteLine(float.Parse(data_time[i].Text, System.Globalization.CultureInfo.InvariantCulture));
                }
                System.Console.WriteLine();

                //sumowanie ścieżek w suma[i].total_time
                foreach (Path i in suma)
                {
                    i.total_time = 0;
                    foreach (int xD in i.suma)
                    {
                        i.total_time += list[xD].duration;
                    }
                   
                }

                show_max();

            }
            foreach (Activity test in list)
            {
                System.Console.WriteLine(test.successors.Count);
            }
            System.Console.WriteLine();
        }




        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            foreach (int xD in suma[critical_id].suma)
            {
                duration_of_crit.Add(list[xD].duration);
                act_draw.Add(xD);
            }

            //this.Hide();
            Form2 draw = new Form2(duration_of_crit,act_draw);
            draw.ShowDialog();
         



        }
    }
}
