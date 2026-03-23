using EvacuationSimulator.UI;
using EvacuationSimulator.UnitTests;

namespace EvacuationSimulator;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new ProgramForm());
        //CoreTests.GridTests.TestGrid();
        //CoreTests.HazardTests.TestHazard();
        //CoreTests.SimulationTests.TestSimulation();
    }
}