using System;
using SFML.Graphics;
using SFML.System;

class Game
{
    public static void Main()
    {
        //----------------------------  INTIALIZE  ------------------------------------//
        RenderWindow renderWindow = new(new(800, 600), "Nigga");
        renderWindow.Closed += (sender, e) => renderWindow.Close();

        CircleShape circle = new CircleShape(60.0f);
        circle.OutlineThickness = 1;
        circle.FillColor = Color.Yellow;
        circle.Position = new Vector2f(800/2 + 150, 200);
        circle.Origin = new Vector2f(60, 60);
        Console.WriteLine(circle.GetType());

        CircleShape circle2 = new CircleShape(60.0f);
        circle2.OutlineThickness = 1;
        circle2.FillColor = Color.Yellow;
        circle2.Position = new Vector2f(800/2 - 150, 200);
        circle2.Origin = new Vector2f(60, 60);
        Console.WriteLine(circle.GetType());
        //----------------------------  INTIALIZE  ------------------------------------//


        while (renderWindow.IsOpen){
            //----------------------------  UPDATE  ------------------------------------//
            renderWindow.DispatchEvents();

            //----------------------------  UPDATE  ------------------------------------//
            //----------------------------  DRAW  ------------------------------------//
            renderWindow.Clear(new Color(0, 0, 0));

            renderWindow.Draw(circle);
            renderWindow.Draw(circle2);

            renderWindow.Display();
            //----------------------------  DRAW  ------------------------------------//
        }
    }
}