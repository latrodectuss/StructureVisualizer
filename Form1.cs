using Raylib_cs;
using System.Numerics;

namespace StructureVisualizer
{
	public partial class Form1 : Form {

		static int[,] structure;
		static int[,,] structure3D;
		static int sizeX, sizeY, sizeZ;
		static int cellSize = 1;
		string selectedFilePath = "c:\\";
		int scale = 1;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			textBoxSize.Text = "3";
		}

		private void buttonGetFile_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				//openFileDialog.InitialDirectory = "c:\\";
				openFileDialog.RestoreDirectory = true;

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					selectedFilePath = openFileDialog.FileName;

					using (StreamReader fstream = new StreamReader(selectedFilePath))
					{
						string line;
						int lineNumber = 1;

						while ((line = fstream.ReadLine()) != null)
						{
							if (lineNumber == 2)
							{
								string[] dimentions = line.Remove(0, 5).Split(';');
								sizeX = Convert.ToInt32(dimentions[0]);
								sizeY = Convert.ToInt32(dimentions[1]);
								sizeZ = Convert.ToInt32(dimentions[2]);
								structure = new int[sizeX, sizeY];
								structure3D = new int[sizeX, sizeY, sizeZ];
							}
							else if (lineNumber >= 11)
							{
								string[] layer = line.Split('\t');
								structure[Convert.ToInt32(layer[0]), Convert.ToInt32(layer[1])] = Convert.ToInt32(layer[3]);
								structure3D[Convert.ToInt32(layer[0]), Convert.ToInt32(layer[1]), Convert.ToInt32(layer[2])] = Convert.ToInt32(layer[3]);
							}
							lineNumber++;
						}
					}
				}
			}

		}

		private void button2D_Click(object sender, EventArgs e)
		{
			cellSize = Convert.ToInt32(textBoxSize.Text);
			Raylib.InitWindow(sizeX * cellSize * scale, sizeY * cellSize * scale, "Структура");

			while (!Raylib.WindowShouldClose())
			{
				Raylib.BeginDrawing();
				Raylib.ClearBackground(Raylib_cs.Color.White);

				for (int y = 0; y < sizeY; y++)
				{
					for (int x = 0; x < sizeX; x++)
					{
						if (structure[x, y] == 1)
							Raylib.DrawRectangle(x * cellSize * scale, y * cellSize * scale, cellSize * scale, cellSize * scale, Raylib_cs.Color.Black);
						else
							Raylib.DrawRectangleLines(x * cellSize * scale, y * cellSize * scale, cellSize * scale, cellSize * scale, Raylib_cs.Color.LightGray);
					}
				}

				float wheelMove = Raylib.GetMouseWheelMove();
				if (wheelMove != 0)
				{
					scale += Convert.ToInt32(wheelMove);
					scale = Math.Clamp(scale, 1, 10);
				}
				Raylib.EndDrawing();
			}

			Raylib.CloseWindow();
		}

		private void button3D_Click(object sender, EventArgs e)
		{
			cellSize = Convert.ToInt32(textBoxSize.Text);
			float movementSpeed = 20f;
			float rotationSpeed = 20f;
			//Raylib.InitWindow(sizeX * cellSize * cellSize * scale, sizeY * cellSize * cellSize * scale, "Структура в 3D");
			Raylib.InitWindow(1800, 1300, "Структура в 3D");
			Raylib.SetTargetFPS(60);

			Camera3D camera = new Camera3D();
			camera.Position = new Vector3(sizeX * cellSize * scale / 2f, sizeY * cellSize * scale / 2f, -sizeX);
			camera.Target = new Vector3(sizeX * cellSize / 2f, sizeY * cellSize / 2f, sizeZ * cellSize / 2f);
			camera.Up = new Vector3(0.0f, 1.0f, 0.0f);
			camera.FovY = 90.0f;
			camera.Projection = CameraProjection.Perspective;

			while (!Raylib.WindowShouldClose())
			{
				Raylib.UpdateCamera(ref camera, CameraMode.Free);

				if (Raylib.IsKeyDown(KeyboardKey.W)) camera.Position.Z += movementSpeed;
				if (Raylib.IsKeyDown(KeyboardKey.S)) camera.Position.Z -= movementSpeed;
				if (Raylib.IsKeyDown(KeyboardKey.A)) camera.Position.X += movementSpeed/2;
				if (Raylib.IsKeyDown(KeyboardKey.D)) camera.Position.X -= movementSpeed/2;

				if (Raylib.IsKeyDown(KeyboardKey.Left)) camera.Target.X -= rotationSpeed;
				if (Raylib.IsKeyDown(KeyboardKey.Right)) camera.Target.X += rotationSpeed;
				if (Raylib.IsKeyDown(KeyboardKey.Up)) camera.Target.Y += rotationSpeed;
				if (Raylib.IsKeyDown(KeyboardKey.Down)) camera.Target.Y -= rotationSpeed;

				Raylib.BeginDrawing();
				Raylib.ClearBackground(Raylib_cs.Color.RayWhite);
				Raylib.BeginMode3D(camera);

				for (int z = 0; z < sizeZ; z++)
					for (int y = 0; y < sizeY; y++)
						for (int x = 0; x < sizeX; x++)
						{
							Vector3 coord = new Vector3(x * cellSize * scale, y * cellSize * scale, z * cellSize * scale);
							if (structure3D[x, y, z] == 1)
							{
								Raylib.DrawCube(coord, cellSize * scale, cellSize * scale, cellSize * scale, Raylib_cs.Color.DarkBlue);
								Raylib.DrawCubeWires(coord, cellSize * scale, cellSize * scale, cellSize * scale, Raylib_cs.Color.Black);
							}
						}

				Raylib.EndMode3D();
				Raylib.DrawText($"FPS: {Raylib.GetFPS()}", 10, 10, 20, Raylib_cs.Color.Black);
				Raylib.EndDrawing();
			}

			Raylib.CloseWindow();
		}
	}
}
