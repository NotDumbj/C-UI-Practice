using System;
using System.Formats.Asn1;
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

        uint WIDTH = 1920;
        uint HEIGHT= 1028;
        string TITLE = "Escape The Eye Wrath";
        //-----------------------------  SETTINGS  -------------------------------------//
        //----------------------------  INTIALIZE  ------------------------------------//
        RenderWindow renderWindow = new(new(WIDTH, HEIGHT), TITLE, Styles.Default, settings);
        
        VertexArray eyeL = new VertexArray(PrimitiveType.Triangles, 3);
        VertexArray eyeR = new VertexArray(PrimitiveType.Triangles, 3);

        CircleShape eyelidR = new CircleShape(5.0f);
        CircleShape eyelidL = new CircleShape(5.0f);

        Sprite player = new Sprite(new Texture("assets\\textures\\player\\player.png"));
        int Xsprite = 0;
        int Ysprite = 0;
        player.TextureRect = new IntRect(Xsprite * 64, Ysprite * 64, 64, 64);
        //events
        renderWindow.Closed += (sender, e) => renderWindow.Close();
        renderWindow.KeyPressed += (sender, e) =>
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape)) {
                renderWindow.Close();
            }
        };

        

        // load
        eyeL[0] = new Vertex(new Vector2f(WIDTH / 2 + 150, 200 - 60), Color.Yellow);
        eyeL[1] = new Vertex(new Vector2f(WIDTH / 2 + 150 - 60, 200 + 30), Color.Yellow);
        eyeL[2] = new Vertex(new Vector2f(WIDTH / 2 + 150 + 60, 200 + 30), Color.Yellow);

        eyeR[0] = new Vertex(new Vector2f(WIDTH / 2 - 150, 200 - 60), Color.Yellow);
        eyeR[1] = new Vertex(new Vector2f(WIDTH / 2 - 150 - 60, 200 + 30), Color.Yellow);
        eyeR[2] = new Vertex(new Vector2f(WIDTH / 2 - 150 + 60, 200 + 30), Color.Yellow);

        eyelidR.OutlineThickness = 1;
        eyelidR.FillColor = Color.Yellow;
        eyelidR.Origin = new Vector2f(eyelidR.Radius, eyelidR.Radius);

        eyelidL.OutlineThickness = 1;
        eyelidL.FillColor = Color.Yellow;
        eyelidL.Origin = new Vector2f(eyelidL.Radius, eyelidL.Radius);

        //----------------------------  INTIALIZE  ------------------------------------//


        while (renderWindow.IsOpen){
            renderWindow.DispatchEvents();
            //----------------------------  UPDATE  ------------------------------------//
            Vector2f centerE = new Vector2f(200f, 600f);
            eyelidR.Position = centerE;


            //Blink
            if (Keyboard.IsKeyPressed(Keyboard.Key.B))
            {
                int animationCounter = 50;
                for (int i = 0; i < animationCounter; i++)
                {
                    Vector2f pos = eyeL[0].Position;
                    pos.Y += (90f / animationCounter);
                    eyeL[0] = new Vertex(pos, Color.Yellow);
                    Vector2f pos2 = eyeR[0].Position;
                    pos2.Y += (90f / animationCounter);
                    eyeR[0] = new Vertex(pos2, Color.Yellow);

                    renderWindow.Clear(new Color(0, 0, 0));

                    renderWindow.Draw(eyeL);
                    renderWindow.Draw(eyeR);

                    renderWindow.Display();
                }

                for (int i = 0; i < animationCounter; i++)
                {
                    Vector2f pos = eyeL[0].Position;
                    pos.Y -= (90f / animationCounter);
                    eyeL[0] = new Vertex(pos, Color.Yellow);
                    Vector2f pos2 = eyeR[0].Position;
                    pos2.Y -= (90f / animationCounter);
                    eyeR[0] = new Vertex(pos2, Color.Yellow);
                    renderWindow.Clear(new Color(0, 0, 0));

                    renderWindow.Draw(eyeL);
                    renderWindow.Draw(eyeR);

                    renderWindow.Display();
                }
            }

            //----------------------------  UPDATE  ------------------------------------//
            //----------------------------  DRAW  ------------------------------------//
            renderWindow.Clear(new Color(0, 0, 0));

            renderWindow.Draw(eyeL);
            renderWindow.Draw(eyeR);
            renderWindow.Draw(eyelidR);
            renderWindow.Draw(player);

            renderWindow.Display();
            //----------------------------  DRAW  ------------------------------------//
        }
    }
}