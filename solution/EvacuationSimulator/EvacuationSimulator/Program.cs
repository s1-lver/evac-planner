using EvacuationSimulator.UnitTests;

namespace EvacuationSimulator;

static class Program
{
    [STAThread]
    static void Main()
    {
        // ApplicationConfiguration.Initialize();
        // Application.Run(new Form1());
        CoreTests.GridTests.TestGrid();
        CoreTests.HazardTests.TestHazard();
    }
}