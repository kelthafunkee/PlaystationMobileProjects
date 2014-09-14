using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace SpriteTest
{
	public class AppMain
	{
		private static GraphicsContext graphics;
		
		public static void Main (string[] args)
		{
			Director.Initialize();
			Director.Instance.GL.Context.SetClearColor( Colors.Grey20 );
			//Director.Instance.DebugFlags |= DebugFlags.Navigate; 
			
			Vector2 position = new Vector2(300,300);
			Vector2i sprIndex1 = new Vector2i(0,0);
			int step = 0;
			
			var scene = new Scene();
			
			var texture_info = new TextureInfo( new Texture2D("/Application/Dude1.png", false ),
			                                   new Vector2i(2,1));
			
			var sprite = new SpriteTile(texture_info, sprIndex1);
			scene.Camera.SetViewFromViewport();
			sprite.Quad.S = texture_info.TextureSizef; 
			scene.AddChild( sprite );
			
			var sprite2 = new SpriteUV() { TextureInfo = texture_info};
			sprite2.Quad.S = texture_info.TextureSizef; 
			scene.AddChild( sprite2 );
			//sprite2.Position = scene.Camera.CalcBounds().Center;
			sprite2.Position = position;
			
			Director.Instance.RunWithScene( scene );
			Initialize ();
			
			sprite.TileIndex2D = new Vector2i(1,0);
			
			while (true) {
				GamePadData presses = GamePad.GetData(0);
				//step++;
				//if (step == 20)
				if ((presses.Buttons & GamePadButtons.Down) != 0){
					sprite.TileIndex2D.X = 0;
					position.X++;
				}
					//sprIndex1.X = 0;
				//if (step > 40){
				//	step = 0;
				else
					sprite.TileIndex2D.X = 1;
					//sprIndex1.X = 1;
				//}
				
				//sprite.TileIndex2D = sprIndex1;
				
				SystemEvents.CheckEvents ();
				Update ();
				Render ();
			}
		}

		public static void Initialize ()
		{
			
			// Set up the graphics system
			graphics = new GraphicsContext ();
		}

		public static void Update ()
		{
			// Query gamepad for current state
			var gamePadData = GamePad.GetData (0);
		}

		public static void Render ()
		{
			// Clear the screen
			graphics.SetClearColor (0.0f, 0.0f, 0.0f, 0.0f);
			graphics.Clear ();
			
			

			// Present the screen
			graphics.SwapBuffers ();
		}
	}
}
