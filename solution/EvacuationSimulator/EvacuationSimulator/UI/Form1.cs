using EvacuationSimulator.Algorithms;
using EvacuationSimulator.Data;
using Point = EvacuationSimulator.Data.Point;
using EvacuationSimulator.Core;
using Timer = System.Windows.Forms.Timer;


namespace EvacuationSimulator.UI;

public partial class Form1 : Form
{
    private readonly ScenarioManager scenarioManager;
    private readonly GridRenderer gridRenderer;
    private readonly Timer simulationTimer;
    
    private Simulation? simulation;
    private bool simulationInitialised;
    
    public Form1()
    {
        InitializeComponent();

        scenarioManager = new ScenarioManager(20, 12);
        gridRenderer  = new GridRenderer();
        
        simulationTimer = new Timer();
        simulationTimer.Tick += SimulationTimer_Tick;

        SetupUi();
        UpdateSelectedTool();
        UpdateMetricLabels();
    }

    private void SetupUi()
    {
        cboAlgorithm.DataSource = Enum.GetValues<RoutingAlgorithm>();
        cboAlgorithm.DropDownStyle = ComboBoxStyle.DropDownList;
        cboAlgorithm.SelectedItem = RoutingAlgorithm.AStar;

        rbWall.Checked = true;
        rbStepMode.Checked = true;

        nudSeverity.Minimum = 0;
        nudSeverity.Maximum = 1000;
        nudSeverity.DecimalPlaces = 1;
        nudSeverity.Increment = 0.5M;
        nudSeverity.Value = 10;

        nudDecayRate.Minimum = 0;
        nudDecayRate.Maximum = 10;
        nudDecayRate.DecimalPlaces = 1;
        nudDecayRate.Increment = 0.1M;
        nudDecayRate.Value = 2;

        nudRiskWeight.Minimum = 0;
        nudRiskWeight.Maximum = 1000;
        nudRiskWeight.DecimalPlaces = 1;
        nudRiskWeight.Increment = 1;
        nudRiskWeight.Value = 100;

        tbSpeed.Minimum = 1;
        tbSpeed.Maximum = 10;
        tbSpeed.Value = 5;

        UpdateTimerInterval();
    }

    private void CreateFreshSimulation()
    {
        simulationTimer.Stop();

        simulation = new Simulation(
            scenarioManager.CurrentGrid,
            new List<Hazard>(scenarioManager.Hazards),
            (RoutingAlgorithm)cboAlgorithm.SelectedItem!,
            (double)nudRiskWeight.Value);
        
        simulation.InitialiseScenario();
        simulationInitialised = true;

        UpdateMetricLabels();
        pnlGrid.Invalidate();
    }

    private void InvalidateSimulationState()
    {
        simulationTimer.Stop();
        simulation = null;
        simulationInitialised = false;
        UpdateMetricLabels();
        pnlGrid.Invalidate();
    }

    private void UpdateSelectedTool()
    {
        if (rbWall.Checked)
        {
            scenarioManager.SelectedTool = EditorToolType.WallTool;
        } else if (rbExit.Checked)
        {
            scenarioManager.SelectedTool = EditorToolType.ExitTool;
        } else if (rbHazard.Checked)
        {
            scenarioManager.SelectedTool = EditorToolType.HazardTool;
        } else if (rbSpawn.Checked)
        {
            scenarioManager.SelectedTool = EditorToolType.SpawnTool;
        } else if (rbEraser.Checked)
        {
            scenarioManager.SelectedTool = EditorToolType.EraserTool;
        }
    }

    private void UpdateMetricLabels()
    {
        if (simulation is null)
        {
            lblEvacTime.Text = "- ticks";
            lblEvacuated.Text = "-";
            lblCompletion.Text = "--.-%";
            lblAvgWait.Text = "- ticks";
            lblAvgRisk.Text = "-";
            lblNodes.Text = "-";
            lblRuntime.Text = "--.-- ms";
            return;
        }

        SimulationMetrics metrics = simulation.Metrics;

        lblEvacTime.Text = $"{metrics.TotalEvacuationTime} ticks";
        lblEvacuated.Text = $"{metrics.AgentsEvacuated}";
        lblCompletion.Text = $"{metrics.CompletionPercentage:P1}";
        lblAvgWait.Text = $"{metrics.AverageWaitingTime} ticks";
        lblAvgRisk.Text = $"{metrics.AverageRiskExposure}";
        lblNodes.Text = $"{metrics.NodesExplored}";
        lblRuntime.Text = $"{metrics.AlgorithmRuntime.TotalMilliseconds:F2} ms";
    }

    private void UpdateTimerInterval()
    {
        simulationTimer.Interval = 1100 - tbSpeed.Value * 100;
    }

    private void pnlGrid_Paint(object sender, PaintEventArgs e)
    {
        gridRenderer.Draw(
            e.Graphics,
            pnlGrid.ClientRectangle,
            scenarioManager.CurrentGrid,
            simulation?.Agents);
    }

    private void pnlGrid_MouseDown(object sender, MouseEventArgs e)
    {
        if (!gridRenderer.TryGetCellFromPixel(e.Location, scenarioManager.CurrentGrid, out Point cell))
            return;

        switch (scenarioManager.SelectedTool)
        {
            case EditorToolType.WallTool:
                scenarioManager.PlaceWall(cell.X, cell.Y);
                break;
            case EditorToolType.ExitTool:
                scenarioManager.PlaceExit(cell.X, cell.Y);
                break;
            case EditorToolType.HazardTool:
                scenarioManager.PlaceHazard(
                    cell.X, 
                    cell.Y,
                    (double)nudSeverity.Value,
                    (double)nudDecayRate.Value);
                break;
            case EditorToolType.SpawnTool:
                scenarioManager.PlaceSpawn(cell.X, cell.Y);
                break;
            case EditorToolType.EraserTool:
                scenarioManager.RemoveEntity(cell.X, cell.Y);
                break;
        }
        
        InvalidateSimulationState();
    }

    private void btnRun_Click(object sender, EventArgs e)
    {
        CreateFreshSimulation();

        if (rbInstantMode.Checked)
        {
            simulation!.RunSimulation();
            UpdateMetricLabels();
            pnlGrid.Invalidate();
        }
        else
        {
            simulationTimer.Start();
        }
    }

    private void btnStep_Click(object sender, EventArgs e)
    {
        if (!simulationInitialised)
            CreateFreshSimulation();

        if (simulation is null || simulation.CheckEndCondition())
        {
            simulationTimer.Stop();
            UpdateMetricLabels();
            pnlGrid.Invalidate();
            return;
        }

        simulation.RunTick();
        UpdateMetricLabels();
        pnlGrid.Invalidate();
    }

    private void btnResetSim_Click(object sender, EventArgs e)
    {
        CreateFreshSimulation();
    }

    private void btnClearScenario_Click(object sender, EventArgs e)
    {
        scenarioManager.ClearScenario();
        InvalidateSimulationState();
    }

    private void SimulationTimer_Tick(object? sender, EventArgs e)
    {
        if (simulation is null || simulation.CheckEndCondition())
        {
            simulationTimer.Stop();
            UpdateMetricLabels();
            pnlGrid.Invalidate();
            return;
        }
        
        simulation.RunTick();
        UpdateMetricLabels();
        pnlGrid.Invalidate();
    }

    private void ToolRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        UpdateSelectedTool();
    }

    private void tbSpeed_ValueChanged(object sender, EventArgs e)
    {
        UpdateTimerInterval();
    }
}