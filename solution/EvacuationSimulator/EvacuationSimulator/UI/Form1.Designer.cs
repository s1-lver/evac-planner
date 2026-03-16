using System.ComponentModel;

namespace EvacuationSimulator.UI;

partial class Form1
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        pnlMain = new System.Windows.Forms.Panel();
        pnlBottom = new System.Windows.Forms.Panel();
        gbResults = new System.Windows.Forms.GroupBox();
        lblRuntime = new System.Windows.Forms.Label();
        lblNodes = new System.Windows.Forms.Label();
        lblRuntimeLabel = new System.Windows.Forms.Label();
        lblNodesLabel = new System.Windows.Forms.Label();
        lblAvgRisk = new System.Windows.Forms.Label();
        lblAvgRiskLabel = new System.Windows.Forms.Label();
        lblAvgWait = new System.Windows.Forms.Label();
        lblAvgWaitLabel = new System.Windows.Forms.Label();
        lblCompletion = new System.Windows.Forms.Label();
        lblCompletionLabel = new System.Windows.Forms.Label();
        lblEvacuated = new System.Windows.Forms.Label();
        lblEvacuatedLabel = new System.Windows.Forms.Label();
        lblEvacTime = new System.Windows.Forms.Label();
        lblEvacTimeLabel = new System.Windows.Forms.Label();
        gbSimulation = new System.Windows.Forms.GroupBox();
        gbVisualModes = new System.Windows.Forms.GroupBox();
        rbInstantMode = new System.Windows.Forms.RadioButton();
        rbStepMode = new System.Windows.Forms.RadioButton();
        tbSpeed = new System.Windows.Forms.TrackBar();
        lblSpeed = new System.Windows.Forms.Label();
        btnResetSim = new System.Windows.Forms.Button();
        btnStep = new System.Windows.Forms.Button();
        btnRun = new System.Windows.Forms.Button();
        nudRiskWeight = new System.Windows.Forms.NumericUpDown();
        lblRiskWeight = new System.Windows.Forms.Label();
        cboAlgorithm = new System.Windows.Forms.ComboBox();
        lblAlgorithm = new System.Windows.Forms.Label();
        pnlRight = new System.Windows.Forms.Panel();
        gbGridSettings = new System.Windows.Forms.GroupBox();
        btnResizeGrid = new System.Windows.Forms.Button();
        nudGridHeight = new System.Windows.Forms.NumericUpDown();
        lblGridHeight = new System.Windows.Forms.Label();
        nudGridWidth = new System.Windows.Forms.NumericUpDown();
        lblGridWidth = new System.Windows.Forms.Label();
        gbScenarioActions = new System.Windows.Forms.GroupBox();
        button1 = new System.Windows.Forms.Button();
        btnClearScenario = new System.Windows.Forms.Button();
        gbHazardModifier = new System.Windows.Forms.GroupBox();
        nudDecayRate = new System.Windows.Forms.NumericUpDown();
        lblDecayRate = new System.Windows.Forms.Label();
        nudSeverity = new System.Windows.Forms.NumericUpDown();
        lblSeverity = new System.Windows.Forms.Label();
        gbTools = new System.Windows.Forms.GroupBox();
        rbPan = new System.Windows.Forms.RadioButton();
        rbEraser = new System.Windows.Forms.RadioButton();
        rbExit = new System.Windows.Forms.RadioButton();
        rbSpawn = new System.Windows.Forms.RadioButton();
        rbHazard = new System.Windows.Forms.RadioButton();
        rbWall = new System.Windows.Forms.RadioButton();
        pnlLeft = new System.Windows.Forms.Panel();
        pnlGridHost = new System.Windows.Forms.Panel();
        pnlLegend = new System.Windows.Forms.Panel();
        pnlLegendBody = new System.Windows.Forms.Panel();
        flpLegendItems = new System.Windows.Forms.FlowLayoutPanel();
        pnlLegendHeader = new System.Windows.Forms.Panel();
        btnToggleLegend = new System.Windows.Forms.Button();
        lblLegendLabel = new System.Windows.Forms.Label();
        pnlGrid = new EvacuationSimulator.UI.DoubleBufferedPanel();
        pnlMain.SuspendLayout();
        pnlBottom.SuspendLayout();
        gbResults.SuspendLayout();
        gbSimulation.SuspendLayout();
        gbVisualModes.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)tbSpeed).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudRiskWeight).BeginInit();
        pnlRight.SuspendLayout();
        gbGridSettings.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudGridHeight).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudGridWidth).BeginInit();
        gbScenarioActions.SuspendLayout();
        gbHazardModifier.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudDecayRate).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudSeverity).BeginInit();
        gbTools.SuspendLayout();
        pnlLeft.SuspendLayout();
        pnlGridHost.SuspendLayout();
        pnlLegend.SuspendLayout();
        pnlLegendBody.SuspendLayout();
        pnlLegendHeader.SuspendLayout();
        SuspendLayout();
        // 
        // pnlMain
        // 
        pnlMain.Controls.Add(pnlBottom);
        pnlMain.Controls.Add(pnlRight);
        pnlMain.Controls.Add(pnlLeft);
        pnlMain.Location = new System.Drawing.Point(12, 12);
        pnlMain.Name = "pnlMain";
        pnlMain.Size = new System.Drawing.Size(760, 537);
        pnlMain.TabIndex = 0;
        // 
        // pnlBottom
        // 
        pnlBottom.Controls.Add(gbResults);
        pnlBottom.Location = new System.Drawing.Point(3, 389);
        pnlBottom.Name = "pnlBottom";
        pnlBottom.Size = new System.Drawing.Size(754, 145);
        pnlBottom.TabIndex = 3;
        // 
        // gbResults
        // 
        gbResults.Controls.Add(lblRuntime);
        gbResults.Controls.Add(lblNodes);
        gbResults.Controls.Add(lblRuntimeLabel);
        gbResults.Controls.Add(lblNodesLabel);
        gbResults.Controls.Add(lblAvgRisk);
        gbResults.Controls.Add(lblAvgRiskLabel);
        gbResults.Controls.Add(lblAvgWait);
        gbResults.Controls.Add(lblAvgWaitLabel);
        gbResults.Controls.Add(lblCompletion);
        gbResults.Controls.Add(lblCompletionLabel);
        gbResults.Controls.Add(lblEvacuated);
        gbResults.Controls.Add(lblEvacuatedLabel);
        gbResults.Controls.Add(lblEvacTime);
        gbResults.Controls.Add(lblEvacTimeLabel);
        gbResults.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        gbResults.Location = new System.Drawing.Point(0, 0);
        gbResults.Name = "gbResults";
        gbResults.Size = new System.Drawing.Size(380, 145);
        gbResults.TabIndex = 0;
        gbResults.TabStop = false;
        gbResults.Text = "Results";
        // 
        // lblRuntime
        // 
        lblRuntime.BackColor = System.Drawing.Color.Transparent;
        lblRuntime.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblRuntime.Location = new System.Drawing.Point(315, 46);
        lblRuntime.Name = "lblRuntime";
        lblRuntime.Size = new System.Drawing.Size(49, 23);
        lblRuntime.TabIndex = 19;
        lblRuntime.Text = "0";
        lblRuntime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblNodes
        // 
        lblNodes.BackColor = System.Drawing.Color.Transparent;
        lblNodes.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblNodes.Location = new System.Drawing.Point(315, 23);
        lblNodes.Name = "lblNodes";
        lblNodes.Size = new System.Drawing.Size(49, 23);
        lblNodes.TabIndex = 18;
        lblNodes.Text = "0";
        lblNodes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblRuntimeLabel
        // 
        lblRuntimeLabel.BackColor = System.Drawing.Color.Transparent;
        lblRuntimeLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblRuntimeLabel.Location = new System.Drawing.Point(190, 46);
        lblRuntimeLabel.Name = "lblRuntimeLabel";
        lblRuntimeLabel.Size = new System.Drawing.Size(119, 23);
        lblRuntimeLabel.TabIndex = 17;
        lblRuntimeLabel.Text = "Runtime:";
        lblRuntimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblNodesLabel
        // 
        lblNodesLabel.BackColor = System.Drawing.Color.Transparent;
        lblNodesLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblNodesLabel.Location = new System.Drawing.Point(190, 23);
        lblNodesLabel.Name = "lblNodesLabel";
        lblNodesLabel.Size = new System.Drawing.Size(119, 23);
        lblNodesLabel.TabIndex = 15;
        lblNodesLabel.Text = "Nodes Explored:";
        lblNodesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblAvgRisk
        // 
        lblAvgRisk.BackColor = System.Drawing.Color.Transparent;
        lblAvgRisk.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblAvgRisk.Location = new System.Drawing.Point(131, 115);
        lblAvgRisk.Name = "lblAvgRisk";
        lblAvgRisk.Size = new System.Drawing.Size(49, 23);
        lblAvgRisk.TabIndex = 14;
        lblAvgRisk.Text = "0";
        lblAvgRisk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblAvgRiskLabel
        // 
        lblAvgRiskLabel.BackColor = System.Drawing.Color.Transparent;
        lblAvgRiskLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblAvgRiskLabel.Location = new System.Drawing.Point(6, 115);
        lblAvgRiskLabel.Name = "lblAvgRiskLabel";
        lblAvgRiskLabel.Size = new System.Drawing.Size(119, 23);
        lblAvgRiskLabel.TabIndex = 13;
        lblAvgRiskLabel.Text = "Avg. Risk Exposure:";
        lblAvgRiskLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblAvgWait
        // 
        lblAvgWait.BackColor = System.Drawing.Color.Transparent;
        lblAvgWait.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblAvgWait.Location = new System.Drawing.Point(131, 92);
        lblAvgWait.Name = "lblAvgWait";
        lblAvgWait.Size = new System.Drawing.Size(49, 23);
        lblAvgWait.TabIndex = 12;
        lblAvgWait.Text = "0";
        lblAvgWait.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblAvgWaitLabel
        // 
        lblAvgWaitLabel.BackColor = System.Drawing.Color.Transparent;
        lblAvgWaitLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblAvgWaitLabel.Location = new System.Drawing.Point(6, 92);
        lblAvgWaitLabel.Name = "lblAvgWaitLabel";
        lblAvgWaitLabel.Size = new System.Drawing.Size(119, 23);
        lblAvgWaitLabel.TabIndex = 11;
        lblAvgWaitLabel.Text = "Avg. Wait Time:";
        lblAvgWaitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblCompletion
        // 
        lblCompletion.BackColor = System.Drawing.Color.Transparent;
        lblCompletion.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblCompletion.Location = new System.Drawing.Point(131, 69);
        lblCompletion.Name = "lblCompletion";
        lblCompletion.Size = new System.Drawing.Size(49, 23);
        lblCompletion.TabIndex = 10;
        lblCompletion.Text = "0";
        lblCompletion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblCompletionLabel
        // 
        lblCompletionLabel.BackColor = System.Drawing.Color.Transparent;
        lblCompletionLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblCompletionLabel.Location = new System.Drawing.Point(6, 69);
        lblCompletionLabel.Name = "lblCompletionLabel";
        lblCompletionLabel.Size = new System.Drawing.Size(119, 23);
        lblCompletionLabel.TabIndex = 9;
        lblCompletionLabel.Text = "Completion %:";
        lblCompletionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblEvacuated
        // 
        lblEvacuated.BackColor = System.Drawing.Color.Transparent;
        lblEvacuated.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblEvacuated.Location = new System.Drawing.Point(131, 46);
        lblEvacuated.Name = "lblEvacuated";
        lblEvacuated.Size = new System.Drawing.Size(49, 23);
        lblEvacuated.TabIndex = 8;
        lblEvacuated.Text = "0";
        lblEvacuated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblEvacuatedLabel
        // 
        lblEvacuatedLabel.BackColor = System.Drawing.Color.Transparent;
        lblEvacuatedLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblEvacuatedLabel.Location = new System.Drawing.Point(6, 46);
        lblEvacuatedLabel.Name = "lblEvacuatedLabel";
        lblEvacuatedLabel.Size = new System.Drawing.Size(119, 23);
        lblEvacuatedLabel.TabIndex = 7;
        lblEvacuatedLabel.Text = "Agents Evacuated:";
        lblEvacuatedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblEvacTime
        // 
        lblEvacTime.BackColor = System.Drawing.Color.Transparent;
        lblEvacTime.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblEvacTime.Location = new System.Drawing.Point(131, 23);
        lblEvacTime.Name = "lblEvacTime";
        lblEvacTime.Size = new System.Drawing.Size(49, 23);
        lblEvacTime.TabIndex = 6;
        lblEvacTime.Text = "0";
        lblEvacTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblEvacTimeLabel
        // 
        lblEvacTimeLabel.BackColor = System.Drawing.Color.Transparent;
        lblEvacTimeLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblEvacTimeLabel.Location = new System.Drawing.Point(6, 23);
        lblEvacTimeLabel.Name = "lblEvacTimeLabel";
        lblEvacTimeLabel.Size = new System.Drawing.Size(119, 23);
        lblEvacTimeLabel.TabIndex = 5;
        lblEvacTimeLabel.Text = "Evacuation Time:";
        lblEvacTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // gbSimulation
        // 
        gbSimulation.Controls.Add(gbVisualModes);
        gbSimulation.Controls.Add(tbSpeed);
        gbSimulation.Controls.Add(lblSpeed);
        gbSimulation.Controls.Add(btnResetSim);
        gbSimulation.Controls.Add(btnStep);
        gbSimulation.Controls.Add(btnRun);
        gbSimulation.Controls.Add(nudRiskWeight);
        gbSimulation.Controls.Add(lblRiskWeight);
        gbSimulation.Controls.Add(cboAlgorithm);
        gbSimulation.Controls.Add(lblAlgorithm);
        gbSimulation.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        gbSimulation.Location = new System.Drawing.Point(0, 120);
        gbSimulation.Name = "gbSimulation";
        gbSimulation.Size = new System.Drawing.Size(365, 130);
        gbSimulation.TabIndex = 2;
        gbSimulation.TabStop = false;
        gbSimulation.Text = "Simulation";
        // 
        // gbVisualModes
        // 
        gbVisualModes.Controls.Add(rbInstantMode);
        gbVisualModes.Controls.Add(rbStepMode);
        gbVisualModes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        gbVisualModes.Location = new System.Drawing.Point(176, 13);
        gbVisualModes.Name = "gbVisualModes";
        gbVisualModes.Size = new System.Drawing.Size(132, 79);
        gbVisualModes.TabIndex = 13;
        gbVisualModes.TabStop = false;
        gbVisualModes.Text = "Visual Modes";
        // 
        // rbInstantMode
        // 
        rbInstantMode.BackColor = System.Drawing.Color.Transparent;
        rbInstantMode.Font = new System.Drawing.Font("Segoe UI", 9F);
        rbInstantMode.Location = new System.Drawing.Point(6, 49);
        rbInstantMode.Name = "rbInstantMode";
        rbInstantMode.Size = new System.Drawing.Size(112, 21);
        rbInstantMode.TabIndex = 4;
        rbInstantMode.TabStop = true;
        rbInstantMode.Text = "Instant";
        rbInstantMode.UseVisualStyleBackColor = false;
        // 
        // rbStepMode
        // 
        rbStepMode.BackColor = System.Drawing.Color.Transparent;
        rbStepMode.Font = new System.Drawing.Font("Segoe UI", 9F);
        rbStepMode.Location = new System.Drawing.Point(6, 22);
        rbStepMode.Name = "rbStepMode";
        rbStepMode.Size = new System.Drawing.Size(112, 21);
        rbStepMode.TabIndex = 3;
        rbStepMode.TabStop = true;
        rbStepMode.Text = "Step-by-Step";
        rbStepMode.UseVisualStyleBackColor = false;
        // 
        // tbSpeed
        // 
        tbSpeed.Location = new System.Drawing.Point(314, 39);
        tbSpeed.Name = "tbSpeed";
        tbSpeed.Orientation = System.Windows.Forms.Orientation.Vertical;
        tbSpeed.Size = new System.Drawing.Size(45, 85);
        tbSpeed.TabIndex = 12;
        // 
        // lblSpeed
        // 
        lblSpeed.BackColor = System.Drawing.Color.Transparent;
        lblSpeed.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblSpeed.Location = new System.Drawing.Point(314, 13);
        lblSpeed.Name = "lblSpeed";
        lblSpeed.Size = new System.Drawing.Size(45, 23);
        lblSpeed.TabIndex = 11;
        lblSpeed.Text = "Speed";
        lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // btnResetSim
        // 
        btnResetSim.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        btnResetSim.Location = new System.Drawing.Point(154, 98);
        btnResetSim.Name = "btnResetSim";
        btnResetSim.Size = new System.Drawing.Size(68, 26);
        btnResetSim.TabIndex = 10;
        btnResetSim.Text = "Reset";
        btnResetSim.UseVisualStyleBackColor = true;
        btnResetSim.Click += btnResetSim_Click;
        // 
        // btnStep
        // 
        btnStep.Font = new System.Drawing.Font("Segoe UI", 9F);
        btnStep.Location = new System.Drawing.Point(80, 98);
        btnStep.Name = "btnStep";
        btnStep.Size = new System.Drawing.Size(68, 26);
        btnStep.TabIndex = 9;
        btnStep.Text = "Step";
        btnStep.UseVisualStyleBackColor = true;
        btnStep.Click += btnStep_Click;
        // 
        // btnRun
        // 
        btnRun.Font = new System.Drawing.Font("Segoe UI", 9F);
        btnRun.Location = new System.Drawing.Point(6, 98);
        btnRun.Name = "btnRun";
        btnRun.Size = new System.Drawing.Size(68, 26);
        btnRun.TabIndex = 8;
        btnRun.Text = "Run";
        btnRun.UseVisualStyleBackColor = true;
        btnRun.Click += btnRun_Click;
        // 
        // nudRiskWeight
        // 
        nudRiskWeight.Font = new System.Drawing.Font("Segoe UI", 9F);
        nudRiskWeight.Location = new System.Drawing.Point(88, 52);
        nudRiskWeight.Name = "nudRiskWeight";
        nudRiskWeight.Size = new System.Drawing.Size(77, 23);
        nudRiskWeight.TabIndex = 7;
        // 
        // lblRiskWeight
        // 
        lblRiskWeight.BackColor = System.Drawing.Color.Transparent;
        lblRiskWeight.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblRiskWeight.Location = new System.Drawing.Point(3, 52);
        lblRiskWeight.Name = "lblRiskWeight";
        lblRiskWeight.Size = new System.Drawing.Size(79, 23);
        lblRiskWeight.TabIndex = 6;
        lblRiskWeight.Text = "Risk Weight";
        lblRiskWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // cboAlgorithm
        // 
        cboAlgorithm.Font = new System.Drawing.Font("Segoe UI", 9F);
        cboAlgorithm.FormattingEnabled = true;
        cboAlgorithm.Location = new System.Drawing.Point(88, 23);
        cboAlgorithm.Name = "cboAlgorithm";
        cboAlgorithm.Size = new System.Drawing.Size(82, 23);
        cboAlgorithm.TabIndex = 5;
        // 
        // lblAlgorithm
        // 
        lblAlgorithm.BackColor = System.Drawing.Color.Transparent;
        lblAlgorithm.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblAlgorithm.Location = new System.Drawing.Point(3, 23);
        lblAlgorithm.Name = "lblAlgorithm";
        lblAlgorithm.Size = new System.Drawing.Size(79, 23);
        lblAlgorithm.TabIndex = 4;
        lblAlgorithm.Text = "Algorithm";
        lblAlgorithm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // pnlRight
        // 
        pnlRight.Controls.Add(gbGridSettings);
        pnlRight.Controls.Add(gbSimulation);
        pnlRight.Controls.Add(gbScenarioActions);
        pnlRight.Controls.Add(gbHazardModifier);
        pnlRight.Controls.Add(gbTools);
        pnlRight.Location = new System.Drawing.Point(389, 3);
        pnlRight.Name = "pnlRight";
        pnlRight.Size = new System.Drawing.Size(368, 380);
        pnlRight.TabIndex = 1;
        // 
        // gbGridSettings
        // 
        gbGridSettings.Controls.Add(btnResizeGrid);
        gbGridSettings.Controls.Add(nudGridHeight);
        gbGridSettings.Controls.Add(lblGridHeight);
        gbGridSettings.Controls.Add(nudGridWidth);
        gbGridSettings.Controls.Add(lblGridWidth);
        gbGridSettings.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        gbGridSettings.Location = new System.Drawing.Point(0, 254);
        gbGridSettings.Name = "gbGridSettings";
        gbGridSettings.Size = new System.Drawing.Size(191, 126);
        gbGridSettings.TabIndex = 2;
        gbGridSettings.TabStop = false;
        gbGridSettings.Text = "Grid Settings";
        // 
        // btnResizeGrid
        // 
        btnResizeGrid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        btnResizeGrid.Location = new System.Drawing.Point(3, 88);
        btnResizeGrid.Name = "btnResizeGrid";
        btnResizeGrid.Size = new System.Drawing.Size(182, 26);
        btnResizeGrid.TabIndex = 14;
        btnResizeGrid.Text = "Resize Grid";
        btnResizeGrid.UseVisualStyleBackColor = true;
        // 
        // nudGridHeight
        // 
        nudGridHeight.Font = new System.Drawing.Font("Segoe UI", 9F);
        nudGridHeight.Location = new System.Drawing.Point(88, 53);
        nudGridHeight.Name = "nudGridHeight";
        nudGridHeight.Size = new System.Drawing.Size(97, 23);
        nudGridHeight.TabIndex = 7;
        // 
        // lblGridHeight
        // 
        lblGridHeight.BackColor = System.Drawing.Color.Transparent;
        lblGridHeight.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblGridHeight.Location = new System.Drawing.Point(3, 52);
        lblGridHeight.Name = "lblGridHeight";
        lblGridHeight.Size = new System.Drawing.Size(79, 23);
        lblGridHeight.TabIndex = 6;
        lblGridHeight.Text = "Height";
        lblGridHeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // nudGridWidth
        // 
        nudGridWidth.Font = new System.Drawing.Font("Segoe UI", 9F);
        nudGridWidth.Location = new System.Drawing.Point(88, 26);
        nudGridWidth.Name = "nudGridWidth";
        nudGridWidth.Size = new System.Drawing.Size(97, 23);
        nudGridWidth.TabIndex = 5;
        // 
        // lblGridWidth
        // 
        lblGridWidth.BackColor = System.Drawing.Color.Transparent;
        lblGridWidth.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblGridWidth.Location = new System.Drawing.Point(3, 25);
        lblGridWidth.Name = "lblGridWidth";
        lblGridWidth.Size = new System.Drawing.Size(79, 23);
        lblGridWidth.TabIndex = 4;
        lblGridWidth.Text = "Width";
        lblGridWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // gbScenarioActions
        // 
        gbScenarioActions.Controls.Add(button1);
        gbScenarioActions.Controls.Add(btnClearScenario);
        gbScenarioActions.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        gbScenarioActions.Location = new System.Drawing.Point(197, 254);
        gbScenarioActions.Name = "gbScenarioActions";
        gbScenarioActions.Size = new System.Drawing.Size(168, 126);
        gbScenarioActions.TabIndex = 2;
        gbScenarioActions.TabStop = false;
        gbScenarioActions.Text = "Scenario Actions";
        // 
        // button1
        // 
        button1.Font = new System.Drawing.Font("Segoe UI", 9F);
        button1.Location = new System.Drawing.Point(6, 58);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(156, 26);
        button1.TabIndex = 16;
        button1.Text = "Load Example Scenario";
        button1.UseVisualStyleBackColor = true;
        // 
        // btnClearScenario
        // 
        btnClearScenario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        btnClearScenario.Location = new System.Drawing.Point(6, 26);
        btnClearScenario.Name = "btnClearScenario";
        btnClearScenario.Size = new System.Drawing.Size(156, 26);
        btnClearScenario.TabIndex = 15;
        btnClearScenario.Text = "Clear Scenario";
        btnClearScenario.UseVisualStyleBackColor = true;
        btnClearScenario.Click += btnClearScenario_Click;
        // 
        // gbHazardModifier
        // 
        gbHazardModifier.Controls.Add(nudDecayRate);
        gbHazardModifier.Controls.Add(lblDecayRate);
        gbHazardModifier.Controls.Add(nudSeverity);
        gbHazardModifier.Controls.Add(lblSeverity);
        gbHazardModifier.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        gbHazardModifier.Location = new System.Drawing.Point(197, 0);
        gbHazardModifier.Name = "gbHazardModifier";
        gbHazardModifier.Size = new System.Drawing.Size(168, 118);
        gbHazardModifier.TabIndex = 1;
        gbHazardModifier.TabStop = false;
        gbHazardModifier.Text = "Hazard Modifier";
        // 
        // nudDecayRate
        // 
        nudDecayRate.Font = new System.Drawing.Font("Segoe UI", 9F);
        nudDecayRate.Location = new System.Drawing.Point(85, 54);
        nudDecayRate.Name = "nudDecayRate";
        nudDecayRate.Size = new System.Drawing.Size(77, 23);
        nudDecayRate.TabIndex = 3;
        // 
        // lblDecayRate
        // 
        lblDecayRate.BackColor = System.Drawing.Color.Transparent;
        lblDecayRate.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblDecayRate.Location = new System.Drawing.Point(0, 53);
        lblDecayRate.Name = "lblDecayRate";
        lblDecayRate.Size = new System.Drawing.Size(79, 23);
        lblDecayRate.TabIndex = 2;
        lblDecayRate.Text = "Decay Rate";
        lblDecayRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // nudSeverity
        // 
        nudSeverity.Font = new System.Drawing.Font("Segoe UI", 9F);
        nudSeverity.Location = new System.Drawing.Point(85, 27);
        nudSeverity.Name = "nudSeverity";
        nudSeverity.Size = new System.Drawing.Size(77, 23);
        nudSeverity.TabIndex = 1;
        // 
        // lblSeverity
        // 
        lblSeverity.BackColor = System.Drawing.Color.Transparent;
        lblSeverity.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblSeverity.Location = new System.Drawing.Point(0, 26);
        lblSeverity.Name = "lblSeverity";
        lblSeverity.Size = new System.Drawing.Size(79, 23);
        lblSeverity.TabIndex = 0;
        lblSeverity.Text = "Severity";
        lblSeverity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // gbTools
        // 
        gbTools.Controls.Add(rbPan);
        gbTools.Controls.Add(rbEraser);
        gbTools.Controls.Add(rbExit);
        gbTools.Controls.Add(rbSpawn);
        gbTools.Controls.Add(rbHazard);
        gbTools.Controls.Add(rbWall);
        gbTools.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        gbTools.Location = new System.Drawing.Point(0, 0);
        gbTools.Name = "gbTools";
        gbTools.Size = new System.Drawing.Size(191, 118);
        gbTools.TabIndex = 0;
        gbTools.TabStop = false;
        gbTools.Text = "Tools";
        // 
        // rbPan
        // 
        rbPan.BackColor = System.Drawing.Color.Transparent;
        rbPan.Font = new System.Drawing.Font("Segoe UI", 9F);
        rbPan.Location = new System.Drawing.Point(80, 80);
        rbPan.Name = "rbPan";
        rbPan.Size = new System.Drawing.Size(68, 21);
        rbPan.TabIndex = 5;
        rbPan.TabStop = true;
        rbPan.Text = "Pan";
        rbPan.UseVisualStyleBackColor = false;
        rbPan.CheckedChanged += ToolRadioButton_CheckedChanged;
        // 
        // rbEraser
        // 
        rbEraser.BackColor = System.Drawing.Color.Transparent;
        rbEraser.Font = new System.Drawing.Font("Segoe UI", 9F);
        rbEraser.Location = new System.Drawing.Point(6, 80);
        rbEraser.Name = "rbEraser";
        rbEraser.Size = new System.Drawing.Size(68, 21);
        rbEraser.TabIndex = 4;
        rbEraser.TabStop = true;
        rbEraser.Text = "Eraser";
        rbEraser.UseVisualStyleBackColor = false;
        rbEraser.CheckedChanged += ToolRadioButton_CheckedChanged;
        // 
        // rbExit
        // 
        rbExit.BackColor = System.Drawing.Color.Transparent;
        rbExit.Font = new System.Drawing.Font("Segoe UI", 9F);
        rbExit.Location = new System.Drawing.Point(80, 53);
        rbExit.Name = "rbExit";
        rbExit.Size = new System.Drawing.Size(68, 21);
        rbExit.TabIndex = 3;
        rbExit.TabStop = true;
        rbExit.Text = "Exit";
        rbExit.UseVisualStyleBackColor = false;
        rbExit.CheckedChanged += ToolRadioButton_CheckedChanged;
        // 
        // rbSpawn
        // 
        rbSpawn.BackColor = System.Drawing.Color.Transparent;
        rbSpawn.Font = new System.Drawing.Font("Segoe UI", 9F);
        rbSpawn.Location = new System.Drawing.Point(80, 26);
        rbSpawn.Name = "rbSpawn";
        rbSpawn.Size = new System.Drawing.Size(68, 21);
        rbSpawn.TabIndex = 2;
        rbSpawn.TabStop = true;
        rbSpawn.Text = "Spawn";
        rbSpawn.UseVisualStyleBackColor = false;
        rbSpawn.CheckedChanged += ToolRadioButton_CheckedChanged;
        // 
        // rbHazard
        // 
        rbHazard.BackColor = System.Drawing.Color.Transparent;
        rbHazard.Font = new System.Drawing.Font("Segoe UI", 9F);
        rbHazard.Location = new System.Drawing.Point(6, 53);
        rbHazard.Name = "rbHazard";
        rbHazard.Size = new System.Drawing.Size(68, 21);
        rbHazard.TabIndex = 1;
        rbHazard.TabStop = true;
        rbHazard.Text = "Hazard";
        rbHazard.UseVisualStyleBackColor = false;
        rbHazard.CheckedChanged += ToolRadioButton_CheckedChanged;
        // 
        // rbWall
        // 
        rbWall.BackColor = System.Drawing.Color.Transparent;
        rbWall.Font = new System.Drawing.Font("Segoe UI", 9F);
        rbWall.Location = new System.Drawing.Point(6, 26);
        rbWall.Name = "rbWall";
        rbWall.Size = new System.Drawing.Size(68, 21);
        rbWall.TabIndex = 0;
        rbWall.TabStop = true;
        rbWall.Text = "Wall";
        rbWall.UseVisualStyleBackColor = false;
        rbWall.CheckedChanged += ToolRadioButton_CheckedChanged;
        // 
        // pnlLeft
        // 
        pnlLeft.Controls.Add(pnlGridHost);
        pnlLeft.Location = new System.Drawing.Point(3, 3);
        pnlLeft.Name = "pnlLeft";
        pnlLeft.Size = new System.Drawing.Size(380, 380);
        pnlLeft.TabIndex = 0;
        // 
        // pnlGridHost
        // 
        pnlGridHost.Controls.Add(pnlLegend);
        pnlGridHost.Controls.Add(pnlGrid);
        pnlGridHost.Location = new System.Drawing.Point(0, 0);
        pnlGridHost.Name = "pnlGridHost";
        pnlGridHost.Size = new System.Drawing.Size(380, 380);
        pnlGridHost.TabIndex = 1;
        pnlGridHost.Resize += pnlGridHost_Resize;
        // 
        // pnlLegend
        // 
        pnlLegend.Controls.Add(pnlLegendBody);
        pnlLegend.Controls.Add(pnlLegendHeader);
        pnlLegend.Location = new System.Drawing.Point(0, 244);
        pnlLegend.Name = "pnlLegend";
        pnlLegend.Size = new System.Drawing.Size(380, 136);
        pnlLegend.TabIndex = 0;
        // 
        // pnlLegendBody
        // 
        pnlLegendBody.Controls.Add(flpLegendItems);
        pnlLegendBody.Location = new System.Drawing.Point(0, 36);
        pnlLegendBody.Name = "pnlLegendBody";
        pnlLegendBody.Size = new System.Drawing.Size(380, 100);
        pnlLegendBody.TabIndex = 1;
        // 
        // flpLegendItems
        // 
        flpLegendItems.Location = new System.Drawing.Point(3, 283);
        flpLegendItems.Name = "flpLegendItems";
        flpLegendItems.Size = new System.Drawing.Size(380, 100);
        flpLegendItems.TabIndex = 0;
        // 
        // pnlLegendHeader
        // 
        pnlLegendHeader.BackColor = System.Drawing.Color.Gainsboro;
        pnlLegendHeader.Controls.Add(btnToggleLegend);
        pnlLegendHeader.Controls.Add(lblLegendLabel);
        pnlLegendHeader.Location = new System.Drawing.Point(0, 0);
        pnlLegendHeader.Name = "pnlLegendHeader";
        pnlLegendHeader.Size = new System.Drawing.Size(380, 37);
        pnlLegendHeader.TabIndex = 0;
        // 
        // btnToggleLegend
        // 
        btnToggleLegend.BackColor = System.Drawing.Color.Transparent;
        btnToggleLegend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnToggleLegend.Location = new System.Drawing.Point(343, 0);
        btnToggleLegend.Name = "btnToggleLegend";
        btnToggleLegend.Size = new System.Drawing.Size(37, 37);
        btnToggleLegend.TabIndex = 1;
        btnToggleLegend.Text = "▼";
        btnToggleLegend.UseVisualStyleBackColor = false;
        btnToggleLegend.Click += btnToggleLegend_Click;
        // 
        // lblLegendLabel
        // 
        lblLegendLabel.BackColor = System.Drawing.Color.Transparent;
        lblLegendLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        lblLegendLabel.Location = new System.Drawing.Point(0, 0);
        lblLegendLabel.Name = "lblLegendLabel";
        lblLegendLabel.Size = new System.Drawing.Size(121, 37);
        lblLegendLabel.TabIndex = 0;
        lblLegendLabel.Text = "Legend";
        lblLegendLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // pnlGrid
        // 
        pnlGrid.Location = new System.Drawing.Point(0, 0);
        pnlGrid.Name = "pnlGrid";
        pnlGrid.Size = new System.Drawing.Size(380, 380);
        pnlGrid.TabIndex = 1;
        pnlGrid.Paint += pnlGrid_Paint;
        pnlGrid.MouseEnter += pnlGrid_MouseEnter;
        pnlGrid.MouseDown += pnlGrid_MouseDown;
        pnlGrid.MouseLeave += pnlGrid_MouseLeave;
        pnlGrid.MouseUp += pnlGrid_MouseUp;
        pnlGrid.MouseMove += pnlGrid_MouseMove;
        pnlGrid.MouseWheel += pnlGrid_MouseWheel;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(784, 561);
        Controls.Add(pnlMain);
        DoubleBuffered = true;
        Location = new System.Drawing.Point(15, 15);
        pnlMain.ResumeLayout(false);
        pnlBottom.ResumeLayout(false);
        gbResults.ResumeLayout(false);
        gbSimulation.ResumeLayout(false);
        gbSimulation.PerformLayout();
        gbVisualModes.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)tbSpeed).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudRiskWeight).EndInit();
        pnlRight.ResumeLayout(false);
        gbGridSettings.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)nudGridHeight).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudGridWidth).EndInit();
        gbScenarioActions.ResumeLayout(false);
        gbHazardModifier.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)nudDecayRate).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudSeverity).EndInit();
        gbTools.ResumeLayout(false);
        pnlLeft.ResumeLayout(false);
        pnlGridHost.ResumeLayout(false);
        pnlLegend.ResumeLayout(false);
        pnlLegendBody.ResumeLayout(false);
        pnlLegendHeader.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label lblNodesLabel;
    private System.Windows.Forms.Label lblEvacuated;
    private System.Windows.Forms.Label lblEvacTime;
    private System.Windows.Forms.Label lblCompletion;
    private System.Windows.Forms.Label lblAvgWait;
    private System.Windows.Forms.Label lblAvgRisk;

    private System.Windows.Forms.Label lblNodes;

    private System.Windows.Forms.Label lblRuntimeLabel;

    private System.Windows.Forms.Label lblEvacTimeLabel;
    private System.Windows.Forms.Label lblEvacuatedLabel;
    private System.Windows.Forms.Label lblAvgWaitLabel;
    private System.Windows.Forms.Label lblAvgRiskLabel;
    private System.Windows.Forms.Label lblCompletionLabel;

    private System.Windows.Forms.Panel pnlBottom;
    private System.Windows.Forms.GroupBox gbResults;
    private System.Windows.Forms.Label lblRuntime;

    private System.Windows.Forms.Button btnClearScenario;
    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.GroupBox gbGridSettings;
    private System.Windows.Forms.NumericUpDown nudGridHeight;
    private System.Windows.Forms.Label lblGridHeight;
    private System.Windows.Forms.NumericUpDown nudGridWidth;
    private System.Windows.Forms.Label lblGridWidth;
    private System.Windows.Forms.Button btnResizeGrid;
    private System.Windows.Forms.GroupBox gbScenarioActions;

    private System.Windows.Forms.GroupBox gbVisualModes;
    private System.Windows.Forms.RadioButton rbStepMode;
    private System.Windows.Forms.RadioButton rbInstantMode;

    private System.Windows.Forms.TrackBar tbSpeed;

    private System.Windows.Forms.ComboBox cboAlgorithm;
    private System.Windows.Forms.Label lblRiskWeight;
    private System.Windows.Forms.NumericUpDown nudRiskWeight;
    private System.Windows.Forms.Button btnRun;
    private System.Windows.Forms.Button btnStep;
    private System.Windows.Forms.Button btnResetSim;
    private System.Windows.Forms.Label lblSpeed;

    private System.Windows.Forms.Label lblDecayRate;

    private System.Windows.Forms.GroupBox gbSimulation;

    private System.Windows.Forms.NumericUpDown nudSeverity;
    private System.Windows.Forms.NumericUpDown nudDecayRate;
    private System.Windows.Forms.Label lblAlgorithm;

    private System.Windows.Forms.GroupBox gbTools;
    private System.Windows.Forms.RadioButton rbWall;
    private System.Windows.Forms.RadioButton rbHazard;
    private System.Windows.Forms.RadioButton rbExit;
    private System.Windows.Forms.RadioButton rbSpawn;
    private System.Windows.Forms.RadioButton rbPan;
    private System.Windows.Forms.RadioButton rbEraser;
    private System.Windows.Forms.GroupBox gbHazardModifier;
    private System.Windows.Forms.Label lblSeverity;

    private System.Windows.Forms.FlowLayoutPanel flpLegendItems;
    private System.Windows.Forms.Panel pnlRight;

    private System.Windows.Forms.Panel pnlLegendBody;

    private System.Windows.Forms.Button btnToggleLegend;

    private System.Windows.Forms.Panel pnlLegendHeader;
    private System.Windows.Forms.Label lblLegendLabel;

    private System.Windows.Forms.Panel pnlLegend;

    private EvacuationSimulator.UI.DoubleBufferedPanel pnlGrid;

    private System.Windows.Forms.Panel pnlMain;
    private System.Windows.Forms.Panel pnlGridHost;
    private System.Windows.Forms.Panel pnlLeft;

    #endregion
}