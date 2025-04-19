using Raylib_cs;

namespace StructureVisualizer
{
	public partial class Form1 : Form {

		static int[,] structure;
		static int sizeX, sizeY, sizeZ;
		static int cellSize = 1;
		string selectedFilePath = "c:\\";

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = "c:\\";
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
							}
							else if (lineNumber >= 11)
							{
								string[] layer = line.Split('\t');
								structure[Convert.ToInt32(layer[0]), Convert.ToInt32(layer[1])] = Convert.ToInt32(layer[3]);
							}
							lineNumber++;
						}
					}
				}
			}

		}

		private void button2_Click(object sender, EventArgs e)
		{
			cellSize = Convert.ToInt32(textBoxSize.Text);
			Raylib.InitWindow(sizeX * cellSize, sizeY * cellSize, "Структура");

			while (!Raylib.WindowShouldClose())
			{
				Raylib.BeginDrawing();
				Raylib.ClearBackground(Raylib_cs.Color.White);

				for (int y = 0; y < sizeY; y++)
				{
					for (int x = 0; x < sizeX; x++)
					{
						if (structure[x, y] == 1)
							Raylib.DrawRectangle(x * cellSize, y * cellSize, cellSize, cellSize, Raylib_cs.Color.Black);
						else
							Raylib.DrawRectangleLines(x * cellSize, y * cellSize, cellSize, cellSize, Raylib_cs.Color.LightGray);
					}
				}

				Raylib.EndDrawing();
			}

			Raylib.CloseWindow();
		}
	}
}
