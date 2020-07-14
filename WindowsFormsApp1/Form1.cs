using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e){}

        Circle[] krug;
        Square kvadrat;
        MainMenu MainMenu;
        MenuItem knopka1, knopka2, info;

        public Form1()
        {
            //инициализация компонентов
            InitializeComponent();

            //создание меню
            knopka1 = new MenuItem("Запуск", new EventHandler(timer1_Tick), Shortcut.CtrlE);
         
            knopka2 = new MenuItem("Стоп", new EventHandler(Stop), Shortcut.CtrlT);
            info = new MenuItem("Информация о разработчике", new EventHandler(InfoORazrabotchik), Shortcut.CtrlY);
            MainMenu = new MainMenu(new MenuItem[] { knopka1, knopka2, info });
            Menu = MainMenu;

            //создание объектов
            krug = new Circle[3];
            krug[0] = new Circle(Brushes.Bisque, new Point(0, 100), false);
            krug[1] = new Circle(Brushes.Black, new Point(0, 240), false);
            krug[2] = new Circle(Brushes.LightGray, new Point(0, 310), false);

            kvadrat = new Square(Brushes.Green, new Point(0, 170), true);

            //подписка всех кругов на событие
            kvadrat.EventMoveDelegate += krug[0].StartMove; 
            kvadrat.EventMoveDelegate += krug[1].StartMove;
            kvadrat.EventMoveDelegate += krug[2].StartMove;
            kvadrat.EventMoveDelegate1 += krug[0].StartMove1;
            kvadrat.EventMoveDelegate1 += krug[1].StartMove1;
            kvadrat.EventMoveDelegate1 += krug[2].StartMove1;
        }

        //Кнопки:

        //Запуск
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;

                kvadrat.Move();
                krug[0].Move();
                krug[1].Move();
                krug[2].Move();
           

            Invalidate();
        }

      

        //Стоп
        private void Stop(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        //Информация о разработчике
        private void InfoORazrabotchik(object sender, EventArgs e)
        {
            MessageBox.Show("Выполнил: студент группы 4207\nАлтынбаев С.Т.\nВариант работы: 2", "Информация о разработчике");
        }
        //Рисовние всех объектов
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
          
            kvadrat.Draw(e.Graphics);
            krug[0].Draw(e.Graphics);
            krug[1].Draw(e.Graphics);
            krug[2].Draw(e.Graphics);

        }
    }
    
    //Класс кругов
    class Circle
    {
        Point moving;
        Brush color;
        Size size;
        bool way = true;
        bool stop;

        public Circle(Brush owncolor, Point ownmoving, bool ownmove)
        {
            color = owncolor;
            size = new Size(50, 50);
            moving = ownmoving;
            stop = ownmove;
        }

        public void Draw(Graphics context)
        {
            context.FillEllipse(color, new Rectangle(moving, size));
        }

        public void StartMove()
        {
            stop = true;
        }
        public void StartMove1()
        {
            way = false;
        }
        public void Move()
        {
            {
                if (stop == true)
                {
                    if (moving.X < 450)
                    {
                        moving.X += 10;
                    }
                    else
                    {
                        if (moving.X == 450) {  }                                              
                        
                    }

                    
                }
                if (way == false)
                {
                    stop = false;
                    if (moving.X > 0)
                    {
                        moving.X -= 10;
                    }
                    else
                    {
                        if (moving.X <= 0) { stop = false; way = true; }
                    }
                }
            }
        }
    }

    //Класс прямоугольников
    class Square
    {
        Point moving;
        Brush color;
        Size size;

        bool stop;
        int F, S;
        
        public delegate void MoveDelegate();//создаём делегат MoveDelegate()
        public event MoveDelegate EventMoveDelegate;//создаём событие EventMoveDelegate
        public event MoveDelegate EventMoveDelegate1;
        public Square(Brush owncolor, Point ownmoving, bool ownmove)
        {
        
            EventMoveDelegate += StopMove; //подписка обработчика события на событие
            color = owncolor;
            size = new Size(70, 50);
            moving = ownmoving;
            stop = ownmove;
            
        }

        public void Draw(Graphics context)
        {
            context.FillRectangle(color, new Rectangle(moving, size));
        }
        
        public void Move()
        {
            

 
            {  if (moving.X>=910)
            { F = -10; S = 1; EventMoveDelegate1(); }

                if (moving.X== 0&&S==0)
            { F = 10; S = 0; }
       

                if (moving.X == 450&&S==0)
                {
                    EventMoveDelegate(); //вызов обработчика события
                }
                 moving.X += F;

               
       
                if (moving.X == 0){ S = 0; }
            }
            
        
        }
       
        public void StopMove()
        {
            stop = false;
        }
       
    }
}


