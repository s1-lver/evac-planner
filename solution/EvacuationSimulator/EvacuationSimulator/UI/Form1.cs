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

    private bool legendCollapsed = false;

    private const int LegendExpandedHeight = 145;
    private const int LegendCollapsedHeight = 42;
    private const int LegendMargin = 8;

    private bool isPaintingGrid = false;
    private MouseButtons activePaintButton = MouseButtons.None;
    private Point? lastPaintedCell = null;

    private const int DefaultEditCellSize = 28;
    private const int ZoomStep = 4;
    
    private GridInteractionMode gridInteractionMode = GridInteractionMode.Paint;

    private int viewportOffsetX = 0;
    private int viewportOffsetY = 0;
    
    private int viewportLeftPadding = 40;
    private int viewportRightPadding = 40;
    private int viewportTopPadding = 40;
    private int viewportBottomPaddong = 40;
    
    private bool isPanningGrid = false;
    private System.Drawing.Point panStartMouseScreen;
    private int panStartOffsetX;
    private int panStartOffsetY;
    
    private string? hoverTooltipText = null;
    private System.Drawing.Point hoverMouseLocation;
    private bool showHoverTooltip = false;

    private bool uiInitialised = false;
    public Form1()
    {
        InitializeComponent();

        scenarioManager = new ScenarioManager(30, 20);
        gridRenderer  = new GridRenderer();
        
        simulationTimer = new Timer();
        simulationTimer.Tick += SimulationTimer_Tick;

        SetupUi();
        SetupGridViewport();
        SetupLegend();
        UpdateSelectedTool();
        UpdateMetricLabels();

        uiInitialised = true;
    }

    private bool CanShowSimulationTooltip() 
    {
        return simulation is not null
        && simulationInitialised
        && !isPaintingGrid
        && !isPanningGrid;
    }

    private string? GetTooltipTextForCell(Point cell)
    {
        if (simulation is null)
            return null;
        
        Agent? agent = simulation.Agents.FirstOrDefault(a => a.Position == cell && !a.HasEvacuated);
        if (agent is not null) 
        {
            string evacString = agent.HasEvacuated ? "Yes" : "No";
            return $"Agent #{agent.Id}\n" + 
                $"Position: ({agent.Position.X}, {agent.Position.Y})\n" +
                $"Waiting Time: {agent.WaitingTime} ticks\n" +
                $"Risk Exposure: {agent.RiskExposure:F2}\n" +
                $"Evacuated: {evacString}";
        }
        
        Hazard? hazard = scenarioManager.HAzards.FirstOrDefault(h => h.Position == cell);
        if (hazard is not null)
        {
            
        }
    }
    
    private void SetupGridViewport()
    {
        pnlGrid.Parent = pnlGridHost;
        pnlGrid.Dock = DockStyle.Fill;
        pnlGrid.Location = new System.Drawing.Point(0, 0);
        
        gridRenderer.SetCellSize(DefaultEditCellSize);
        UpdateGridCanvasSize();
    }

    private void UpdateGridCanvasSize()
    {
        Size canvasSize = gridRenderer.GetCanvasSize(scenarioManager.CurrentGrid);
        pnlGrid.Size = canvasSize; 
            
        pnlGrid.Invalidate();
        PositionLegendOverlay();
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

    private void SetupLegend()
    {
        pnlLegend.BorderStyle = BorderStyle.FixedSingle;
        pnlLegend.BackColor = Color.WhiteSmoke;

        pnlLegendHeader.BackColor = Color.Gainsboro;
        pnlLegendHeader.Dock = DockStyle.Top;
        pnlLegendHeader.Height = 32;
        pnlLegendHeader.Padding = new Padding(4);
        
        pnlLegendBody.BackColor = Color.WhiteSmoke;
        pnlLegendBody.Dock = DockStyle.Fill;
        pnlLegendBody.Padding = Padding.Empty;
        pnlLegendBody.Margin = Padding.Empty;

        flpLegendItems.Dock = DockStyle.Fill;
        flpLegendItems.Margin = Padding.Empty;
        flpLegendItems.Padding = new Padding(8, 6, 8, 6);

        lblLegendLabel.Dock = DockStyle.Left;
        lblLegendLabel.AutoSize = false;
        lblLegendLabel.Width = 120;
        lblLegendLabel.TextAlign = ContentAlignment.MiddleLeft;

        btnToggleLegend.Dock = DockStyle.Right;

        flpLegendItems.Controls.Clear();
        
        AddLegendItem(Color.White, "Empty", "Open walkable space.");
        AddLegendItem(Color.Black, "Wall", "Blocked cell / wall.");
        AddLegendItem(Color.LimeGreen, "Exit", "Agents evacuate here.");
        AddLegendItem(Color.IndianRed, "Hazard", "Danger source. Not walkable.");
        AddLegendItem(Color.Gold, "Spawn", "Starting location for an agent.");
        AddLegendItem(Color.DodgerBlue, "Agent", "An evacuee/agent.");
    }

    private void AddLegendItem(Color colour, string name, string contents)
    {
        FlowLayoutPanel row = new FlowLayoutPanel
        {
            AutoSize = true,
            WrapContents = false,
            Margin = new Padding(0, 4, 0, 6)
        };

        Panel swatch = new Panel
        {
            BackColor = colour,
            Width = 18,
            Height = 18,
            BorderStyle = BorderStyle.FixedSingle,
            Margin = new Padding(0, 0, 10, 0)
        };

        Label label = new Label
        {
            AutoSize = true,
            Text = name,
            Padding = new Padding(0, 2, 0, 0)
        };

        ToolTip toolTip = new ToolTip();
        toolTip.SetToolTip(swatch, contents);
        toolTip.SetToolTip(label, contents);
        
        row.Controls.Add(swatch);
        row.Controls.Add(label);
        
        flpLegendItems.Controls.Add(row);
    }

    private void PositionLegendOverlay()
    {
        int height = legendCollapsed ? LegendCollapsedHeight : LegendExpandedHeight;
        
        pnlLegend.SetBounds(
            LegendMargin,
            pnlGridHost.Height - height - LegendMargin,
            pnlGridHost.Width - (LegendMargin * 2),
            height);

        pnlLegendBody.Visible = !legendCollapsed;
        btnToggleLegend.Text = legendCollapsed ? "▲" : "▼";
        
        pnlLegend.BringToFront();
    }

    private void btnToggleLegend_Click(object? sender, EventArgs e)
    {
        legendCollapsed = !legendCollapsed;
        PositionLegendOverlay();
        ClampViewport();
        pnlGrid.Invalidate();
    }

    private void pnlGridHost_Resize(object? sender, EventArgs e)
    {
        PositionLegendOverlay();
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

    private void UpdateGridInteractionMode()
    {
        gridInteractionMode = rbPan.Checked ? GridInteractionMode.Pan : GridInteractionMode.Paint;

        pnlGrid.Cursor = gridInteractionMode == GridInteractionMode.Pan ? Cursors.Hand : Cursors.Default;
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
            simulation?.Agents,
            viewportOffsetX,
            viewportOffsetY);
    }

    private void ApplyToolAtCell(Point cell)
    {
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

    private void pnlGrid_MouseDown(object sender, MouseEventArgs e)
    {
        if (gridInteractionMode == GridInteractionMode.Pan)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPanningGrid = true;
                panStartMouseScreen = Control.MousePosition;

                panStartOffsetX = viewportOffsetX;
                panStartOffsetY = viewportOffsetY;

                pnlGrid.Cursor = Cursors.SizeAll;
            }

            return;
        }
        
        if (!gridRenderer.TryGetCellFromPixel(e.Location, scenarioManager.CurrentGrid, out Point cell))
            return;

        isPaintingGrid = true;
        activePaintButton = e.Button;
        
        ApplyToolAtCell(cell);
        lastPaintedCell = cell;
        
        pnlGrid.Invalidate();
    }

    private void pnlGrid_MouseMove(object sender, MouseEventArgs e)
    {
        if (gridInteractionMode == GridInteractionMode.Pan)
        {
            if (!isPanningGrid)
                return;

            System.Drawing.Point currentMouseScreen = Control.MousePosition;

            int dx = currentMouseScreen.X - panStartMouseScreen.X;
            int dy = currentMouseScreen.Y - panStartMouseScreen.Y;

            viewportOffsetX = panStartOffsetX + dx;
            viewportOffsetY = panStartOffsetY + dy;

            ClampViewport();
            pnlGrid.Invalidate();

            return;
        }
        
        if (!isPaintingGrid || activePaintButton != MouseButtons.Left)
            return;
        
        if (!gridRenderer.TryGetCellFromPixel(e.Location, scenarioManager.CurrentGrid, out Point cell))
            return;

        if (lastPaintedCell.HasValue && lastPaintedCell.Value == cell)
            return;
        
        ApplyToolAtCell(cell);
        lastPaintedCell = cell;

        pnlGrid.Invalidate();
    }

    private void pnlGrid_MouseUp(object sender, MouseEventArgs e)
    {
        if (gridInteractionMode == GridInteractionMode.Pan)
        {
            isPanningGrid = false;
            pnlGrid.Cursor = rbPan.Checked ? Cursors.Hand : Cursors.Default;
            return;
        }
        
        isPaintingGrid = false;
        activePaintButton = MouseButtons.None;
        lastPaintedCell = null;
    }

    private void pnlGrid_MouseLeave(object sender, EventArgs e)
    {
        isPaintingGrid = false;
        activePaintButton = MouseButtons.None;
        lastPaintedCell = null;

        isPanningGrid = false;
        pnlGrid.Cursor = rbPan.Checked ? Cursors.Hand : Cursors.Default;
    }
    
    private void pnlGrid_MouseWheel(object sender, MouseEventArgs e)
    {
        if ((ModifierKeys & Keys.Control) == 0)
            return;
        
        if (e.Delta > 0)
            gridRenderer.SetCellSize(gridRenderer.CellSize + ZoomStep);
        else if (e.Delta < 0)
            gridRenderer.SetCellSize(gridRenderer.CellSize - ZoomStep);
        
        UpdateGridCanvasSize();
    }

    private void pnlGrid_MouseEnter(object? sender, EventArgs e)
    {
        pnlGrid.Focus();
    }

    private void ClampViewport()
    {
        int gridPixelWidth = scenarioManager.CurrentGrid.Width * gridRenderer.CellSize;
        int gridPixelHeight = scenarioManager.CurrentGrid.Height * gridRenderer.CellSize;
        
        int xA = viewportLeftPadding;
        int xB = pnlGrid.Width - gridPixelWidth - viewportRightPadding;
        int minX = Math.Min(xA, xB);
        int maxX = Math.Max(xA, xB);
        
        int yA = viewportTopPadding;
        int yB = pnlGrid.Height - gridPixelHeight - viewportBottomPaddong;
        int minY = Math.Min(xA, xB);
        int maxY = Math.Max(xA, xB);
        
        viewportOffsetX = Math.Max(minX, Math.Min(viewportOffsetX, maxX));
        viewportOffsetY = Math.Max(minY, Math.Min(viewportOffsetY, maxY));
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
        UpdateGridInteractionMode();
    }

    private void tbSpeed_ValueChanged(object sender, EventArgs e)
    {
        UpdateTimerInterval();
    }
}