using EvacuationSimulator.Data;
using EvacuationSimulator.Core;
using WinPoint = System.Drawing.Point;
using GridPoint = EvacuationSimulator.Data.Point;

namespace EvacuationSimulator.UI;

public class GridRenderer
{
     public int CellSize { get; private set; }
     public int OffsetX { get; private set; }
     public int OffsetY { get; private set; }

     public void Draw(
         Graphics graphics,
         Rectangle bounds,
         Grid grid,
         IReadOnlyCollection<Agent>? agents)
     {
         graphics.Clear(Color.White);
         
         CellSize = Math.Min(bounds.Width / grid.Width, bounds.Height / grid.Height);
         if (CellSize <= 0)
             CellSize = 1;

         int gridPixelWidth = grid.Width * CellSize;
         int gridPixelHeight = grid.Height * CellSize;
         
         OffsetX = bounds.X + (bounds.Width - gridPixelWidth) / 2;
         OffsetY = bounds.Y + (bounds.Height - gridPixelHeight) / 2;
         
         using Pen gridPen = new Pen(Color.Black, 1);

         for (int y = 0; y < grid.Height; y++)
         {
             for (int x = 0; x < grid.Width; x++)
             {
                 Rectangle cellRect = new Rectangle(
                     OffsetX + x * CellSize,
                     OffsetY + y * CellSize,
                     CellSize,
                     CellSize);
                 
                 using Brush cellBrush = new SolidBrush(GetCellColour(grid.GetCell(x, y)));
                 graphics.FillRectangle(cellBrush, cellRect);
                 graphics.DrawRectangle(gridPen, cellRect);
             }
         }

         if (agents is not null)
         {
             foreach (Agent agent in agents)
             {
                 Rectangle agentRect = new Rectangle(
                     OffsetX + agent.Position.X * CellSize + CellSize / 6,
                     OffsetY + agent.Position.Y * CellSize + CellSize / 6,
                     CellSize * 2 / 3,
                     CellSize * 2 / 3);

                 using Brush agentBrush = new SolidBrush(Color.DodgerBlue);
                 
                 graphics.FillEllipse(agentBrush, agentRect);
                 graphics.DrawEllipse(Pens.Black, agentRect);
             }
         }
     }

     public bool TryGetCellFromPixel(
         WinPoint pixel,
         Grid grid,
         out GridPoint cell)
     {
         int x = (pixel.X - OffsetX) / CellSize;
         int y = (pixel.Y - OffsetY) / CellSize;

         if (CellSize <= 0 || x < 0 || y < 0 || x >= grid.Width || y >= grid.Height)
         {
             cell = default;
             return false;
         }
         
         cell = new GridPoint(x, y);
         return true;
     }

     private Color GetCellColour(CellType cellType)
     {
         return cellType switch
         {
             CellType.Empty => Color.White,
             CellType.Wall => Color.Black,
             CellType.Exit => Color.LimeGreen,
             CellType.Hazard => Color.IndianRed,
             CellType.Spawn => Color.Gold,
             _ => Color.White
         };
     }
}