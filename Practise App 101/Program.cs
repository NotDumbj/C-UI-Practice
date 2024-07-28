using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Game
{
    public static void Main()
    {
        //-----------------------------  SETTINGS  -------------------------------------//
        ContextSettings settings = new ContextSettings();
        settings.AntialiasingLevel = 8;
        //-----------------------------  SETTINGS  -------------------------------------//
        //----------------------------  INTIALIZE  ------------------------------------//
        RenderWindow renderWindow = new(new(800, 600), "Nigga", Styles.Default, settings);
        renderWindow.Closed += (sender, e) => renderWindow.Close();
        renderWindow.KeyPressed += (sender, e) =>
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape)) {
                renderWindow.Close();
            }
        };
        // Define a triangle using VertexArray
        VertexArray triangle = new VertexArray(PrimitiveType.Triangles, 3);

        // Set the positions and colors of the triangle vertices
        triangle[0] = new Vertex(new Vector2f(800 / 2 + 150, 200 - 60), Color.Yellow);
        triangle[1] = new Vertex(new Vector2f(800 / 2 + 150 - 60, 200 + 30), Color.Yellow);
        triangle[2] = new Vertex(new Vector2f(800 / 2 + 150 + 60, 200 + 30), Color.Yellow);

        // Define a triangle using VertexArray
        VertexArray triangle2 = new VertexArray(PrimitiveType.Triangles, 3);

        // Set the positions and colors of the triangle vertices
        triangle2[0] = new Vertex(new Vector2f(800 / 2 - 150, 200 - 60), Color.Yellow);
        triangle2[1] = new Vertex(new Vector2f(800 / 2 - 150 - 60, 200 + 30), Color.Yellow);
        triangle2[2] = new Vertex(new Vector2f(800 / 2 - 150 + 60, 200 + 30), Color.Yellow);

        CircleShape circle = new CircleShape(60.0f, 3);
        circle.OutlineThickness = 1;
        circle.FillColor = Color.Yellow;
        circle.Position = new Vector2f(800/2 + 150, 200);
        circle.Origin = new Vector2f(60, 60);
        Console.WriteLine(circle.GetType());

        CircleShape circle2 = new CircleShape(60.0f, 3);
        circle2.OutlineThickness = 1;
        circle2.FillColor = Color.Yellow;
        circle2.Position = new Vector2f(800/2 - 150, 200);
        circle2.Origin = new Vector2f(60, 60);
        Console.WriteLine(circle.GetType());
        //----------------------------  INTIALIZE  ------------------------------------//


        while (renderWindow.IsOpen){
            //----------------------------  UPDATE  ------------------------------------//
            renderWindow.DispatchEvents();
            if (Keyboard.IsKeyPressed(Keyboard.Key.B))
            {
                int animationCounter = 100;
                for (int i = 0; i < animationCounter; i++)
                {
                    Vector2f pos = triangle[0].Position;
                    pos.Y += (90f / animationCounter);
                    triangle[0] = new Vertex(pos, Color.Yellow);
                    Vector2f pos2 = triangle2[0].Position;
                    pos2.Y += (90f / animationCounter);
                    triangle2[0] = new Vertex(pos2, Color.Yellow);

                    renderWindow.Clear(new Color(0, 0, 0));

                    renderWindow.Draw(triangle);
                    renderWindow.Draw(triangle2);

                    renderWindow.Display();
                }

                for (int i = 0; i < animationCounter; i++)
                {
                    Vector2f pos = triangle[0].Position;
                    pos.Y -= (90f / animationCounter);
                    triangle[0] = new Vertex(pos, Color.Yellow);
                    Vector2f pos2 = triangle2[0].Position;
                    pos2.Y -= (90f / animationCounter);
                    triangle2[0] = new Vertex(pos2, Color.Yellow);
                    renderWindow.Clear(new Color(0, 0, 0));

                    renderWindow.Draw(triangle);
                    renderWindow.Draw(triangle2);

                    renderWindow.Display();
                }
            }
            //----------------------------  UPDATE  ------------------------------------//
            //----------------------------  DRAW  ------------------------------------//
            renderWindow.Clear(new Color(0, 0, 0));

            //renderWindow.Draw(circle);
            //renderWindow.Draw(circle2);
            renderWindow.Draw(triangle);
            renderWindow.Draw(triangle2);

            renderWindow.Display();
            //----------------------------  DRAW  ------------------------------------//
        }
    }
}