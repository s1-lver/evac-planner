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
        lblScenarioEditor = new System.Windows.Forms.Label();
        rbWall = new System.Windows.Forms.RadioButton();
        rbExit = new System.Windows.Forms.RadioButton();
        rbHazard = new System.Windows.Forms.RadioButton();
        rbSpawn = new System.Windows.Forms.RadioButton();
        rbEraser = new System.Windows.Forms.RadioButton();
        lblTools = new System.Windows.Forms.Label();
        lblHazardModifier = new System.Windows.Forms.Label();
        nudSeverity = new System.Windows.Forms.NumericUpDown();
        lblSeverity = new System.Windows.Forms.Label();
        lblDecayRate = new System.Windows.Forms.Label();
        nudDecayRate = new System.Windows.Forms.NumericUpDown();
        lblAlgorithm = new System.Windows.Forms.Label();
        cboAlgorithm = new System.Windows.Forms.ComboBox();
        lblSimulationControls = new System.Windows.Forms.Label();
        rbStepMode = new System.Windows.Forms.RadioButton();
        rbInstantMode = new System.Windows.Forms.RadioButton();
        tbSpeed = new System.Windows.Forms.TrackBar();
        lblSpeed = new System.Windows.Forms.Label();
        btnRun = new System.Windows.Forms.Button();
        btnStep = new System.Windows.Forms.Button();
        btnClearScenario = new System.Windows.Forms.Button();
        btnResetSim = new System.Windows.Forms.Button();
        lblEvacTimeLabel = new System.Windows.Forms.Label();
        lblResultsPanel = new System.Windows.Forms.Label();
        lblSimMetrics = new System.Windows.Forms.Label();
        lblAlgMetrics = new System.Windows.Forms.Label();
        lblEvacuatedLabel = new System.Windows.Forms.Label();
        lblCompletionLabel = new System.Windows.Forms.Label();
        lblAvgWaitLabel = new System.Windows.Forms.Label();
        lblAvgRiskLabel = new System.Windows.Forms.Label();
        lblEvacTime = new System.Windows.Forms.Label();
        lblEvacuated = new System.Windows.Forms.Label();
        lblCompletion = new System.Windows.Forms.Label();
        lblAvgWait = new System.Windows.Forms.Label();
        lblAvgRisk = new System.Windows.Forms.Label();
        lblRuntime = new System.Windows.Forms.Label();
        lblNodes = new System.Windows.Forms.Label();
        lblRuntimeLabel = new System.Windows.Forms.Label();
        lblNodesLabel = new System.Windows.Forms.Label();
        lblRiskWeight = new System.Windows.Forms.Label();
        nudRiskWeight = new System.Windows.Forms.NumericUpDown();
        pnlGridHost = new System.Windows.Forms.Panel();
        pnlGrid = new EvacuationSimulator.UI.DoubleBufferedPanel();
        pnlLegend = new System.Windows.Forms.Panel();
        ((System.ComponentModel.ISupportInitialize)nudSeverity).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudDecayRate).BeginInit();
        ((System.ComponentModel.ISupportInitialize)tbSpeed).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudRiskWeight).BeginInit();
        pnlGridHost.SuspendLayout();
        SuspendLayout();
        // 
        // lblScenarioEditor
        // 
        lblScenarioEditor.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        lblScenarioEditor.Location = new System.Drawing.Point(430, 9);
        lblScenarioEditor.Name = "lblScenarioEditor";
        lblScenarioEditor.Size = new System.Drawing.Size(188, 32);
        lblScenarioEditor.TabIndex = 1;
        lblScenarioEditor.Text = "Scenario Editor";
        lblScenarioEditor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // rbWall
        // 
        rbWall.Location = new System.Drawing.Point(353, 65);
        rbWall.Name = "rbWall";
        rbWall.Size = new System.Drawing.Size(49, 26);
        rbWall.TabIndex = 2;
        rbWall.TabStop = true;
        rbWall.Text = "Wall";
        rbWall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        rbWall.UseVisualStyleBackColor = true;
        rbWall.CheckedChanged += ToolRadioButton_CheckedChanged;
        // 
        // rbExit
        // 
        rbExit.Location = new System.Drawing.Point(408, 65);
        rbExit.Name = "rbExit";
        rbExit.Size = new System.Drawing.Size(49, 26);
        rbExit.TabIndex = 3;
        rbExit.TabStop = true;
        rbExit.Text = "Exit";
        rbExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        rbExit.UseVisualStyleBackColor = true;
        rbExit.CheckedChanged += ToolRadioButton_CheckedChanged;
        // 
        // rbHazard
        // 
        rbHazard.Location = new System.Drawing.Point(463, 65);
        rbHazard.Name = "rbHazard";
        rbHazard.Size = new System.Drawing.Size(64, 26);
        rbHazard.TabIndex = 4;
        rbHazard.TabStop = true;
        rbHazard.Text = "Hazard";
        rbHazard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        rbHazard.UseVisualStyleBackColor = true;
        rbHazard.CheckedChanged += ToolRadioButton_CheckedChanged;
        // 
        // rbSpawn
        // 
        rbSpawn.Location = new System.Drawing.Point(533, 65);
        rbSpawn.Name = "rbSpawn";
        rbSpawn.Size = new System.Drawing.Size(64, 26);
        rbSpawn.TabIndex = 5;
        rbSpawn.TabStop = true;
        rbSpawn.Text = "Spawn";
        rbSpawn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        rbSpawn.UseVisualStyleBackColor = true;
        rbSpawn.CheckedChanged += ToolRadioButton_CheckedChanged;
        // 
        // rbEraser
        // 
        rbEraser.Location = new System.Drawing.Point(624, 65);
        rbEraser.Name = "rbEraser";
        rbEraser.Size = new System.Drawing.Size(60, 26);
        rbEraser.TabIndex = 6;
        rbEraser.TabStop = true;
        rbEraser.Text = "Eraser";
        rbEraser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        rbEraser.UseVisualStyleBackColor = true;
        rbEraser.CheckedChanged += ToolRadioButton_CheckedChanged;
        // 
        // lblTools
        // 
        lblTools.Font = new System.Drawing.Font("Segoe UI", 12F);
        lblTools.Location = new System.Drawing.Point(428, 40);
        lblTools.Name = "lblTools";
        lblTools.Size = new System.Drawing.Size(189, 23);
        lblTools.TabIndex = 7;
        lblTools.Text = "Tools";
        lblTools.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblHazardModifier
        // 
        lblHazardModifier.Font = new System.Drawing.Font("Segoe UI", 12F);
        lblHazardModifier.Location = new System.Drawing.Point(430, 94);
        lblHazardModifier.Name = "lblHazardModifier";
        lblHazardModifier.Size = new System.Drawing.Size(189, 23);
        lblHazardModifier.TabIndex = 8;
        lblHazardModifier.Text = "Hazard Modifier";
        lblHazardModifier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // nudSeverity
        // 
        nudSeverity.BorderStyle = System.Windows.Forms.BorderStyle.None;
        nudSeverity.DecimalPlaces = 1;
        nudSeverity.Location = new System.Drawing.Point(432, 120);
        nudSeverity.Name = "nudSeverity";
        nudSeverity.Size = new System.Drawing.Size(60, 19);
        nudSeverity.TabIndex = 9;
        // 
        // lblSeverity
        // 
        lblSeverity.Location = new System.Drawing.Point(346, 120);
        lblSeverity.Name = "lblSeverity";
        lblSeverity.Size = new System.Drawing.Size(80, 18);
        lblSeverity.TabIndex = 10;
        lblSeverity.Text = "Severity";
        lblSeverity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblDecayRate
        // 
        lblDecayRate.Location = new System.Drawing.Point(538, 120);
        lblDecayRate.Name = "lblDecayRate";
        lblDecayRate.Size = new System.Drawing.Size(80, 18);
        lblDecayRate.TabIndex = 11;
        lblDecayRate.Text = "Decay Rate";
        lblDecayRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // nudDecayRate
        // 
        nudDecayRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
        nudDecayRate.DecimalPlaces = 1;
        nudDecayRate.Location = new System.Drawing.Point(624, 119);
        nudDecayRate.Name = "nudDecayRate";
        nudDecayRate.Size = new System.Drawing.Size(60, 19);
        nudDecayRate.TabIndex = 12;
        // 
        // lblAlgorithm
        // 
        lblAlgorithm.Font = new System.Drawing.Font("Segoe UI", 12F);
        lblAlgorithm.Location = new System.Drawing.Point(430, 162);
        lblAlgorithm.Name = "lblAlgorithm";
        lblAlgorithm.Size = new System.Drawing.Size(189, 23);
        lblAlgorithm.TabIndex = 13;
        lblAlgorithm.Text = "Algorithm";
        lblAlgorithm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // cboAlgorithm
        // 
        cboAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboAlgorithm.FormattingEnabled = true;
        cboAlgorithm.Items.AddRange(new object[] { "Dijkstra", "A*", "Breadth-First Search", "Greedy Best-First" });
        cboAlgorithm.Location = new System.Drawing.Point(404, 188);
        cboAlgorithm.Name = "cboAlgorithm";
        cboAlgorithm.Size = new System.Drawing.Size(244, 23);
        cboAlgorithm.TabIndex = 14;
        // 
        // lblSimulationControls
        // 
        lblSimulationControls.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        lblSimulationControls.Location = new System.Drawing.Point(402, 243);
        lblSimulationControls.Name = "lblSimulationControls";
        lblSimulationControls.Size = new System.Drawing.Size(241, 32);
        lblSimulationControls.TabIndex = 15;
        lblSimulationControls.Text = "Simulation Controls";
        lblSimulationControls.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // rbStepMode
        // 
        rbStepMode.Location = new System.Drawing.Point(341, 285);
        rbStepMode.Name = "rbStepMode";
        rbStepMode.Size = new System.Drawing.Size(85, 26);
        rbStepMode.TabIndex = 16;
        rbStepMode.TabStop = true;
        rbStepMode.Text = "Step Mode";
        rbStepMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        rbStepMode.UseVisualStyleBackColor = true;
        // 
        // rbInstantMode
        // 
        rbInstantMode.Location = new System.Drawing.Point(341, 315);
        rbInstantMode.Name = "rbInstantMode";
        rbInstantMode.Size = new System.Drawing.Size(96, 26);
        rbInstantMode.TabIndex = 17;
        rbInstantMode.TabStop = true;
        rbInstantMode.Text = "Instant Mode";
        rbInstantMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        rbInstantMode.UseVisualStyleBackColor = true;
        // 
        // tbSpeed
        // 
        tbSpeed.Location = new System.Drawing.Point(443, 304);
        tbSpeed.Minimum = 1;
        tbSpeed.Name = "tbSpeed";
        tbSpeed.Size = new System.Drawing.Size(111, 45);
        tbSpeed.TabIndex = 18;
        tbSpeed.Value = 1;
        tbSpeed.ValueChanged += tbSpeed_ValueChanged;
        // 
        // lblSpeed
        // 
        lblSpeed.Location = new System.Drawing.Point(459, 283);
        lblSpeed.Name = "lblSpeed";
        lblSpeed.Size = new System.Drawing.Size(80, 18);
        lblSpeed.TabIndex = 19;
        lblSpeed.Text = "Speed";
        lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // btnRun
        // 
        btnRun.Location = new System.Drawing.Point(553, 278);
        btnRun.Name = "btnRun";
        btnRun.Size = new System.Drawing.Size(65, 29);
        btnRun.TabIndex = 20;
        btnRun.Text = "Run";
        btnRun.UseVisualStyleBackColor = true;
        btnRun.Click += btnRun_Click;
        // 
        // btnStep
        // 
        btnStep.Location = new System.Drawing.Point(624, 278);
        btnStep.Name = "btnStep";
        btnStep.Size = new System.Drawing.Size(65, 29);
        btnStep.TabIndex = 21;
        btnStep.Text = "Step";
        btnStep.UseVisualStyleBackColor = true;
        btnStep.Click += btnStep_Click;
        // 
        // btnClearScenario
        // 
        btnClearScenario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        btnClearScenario.Location = new System.Drawing.Point(459, 217);
        btnClearScenario.Name = "btnClearScenario";
        btnClearScenario.Size = new System.Drawing.Size(129, 29);
        btnClearScenario.TabIndex = 22;
        btnClearScenario.Text = "Clear Scenario";
        btnClearScenario.UseVisualStyleBackColor = true;
        btnClearScenario.Click += btnClearScenario_Click;
        // 
        // btnResetSim
        // 
        btnResetSim.Location = new System.Drawing.Point(573, 312);
        btnResetSim.Name = "btnResetSim";
        btnResetSim.Size = new System.Drawing.Size(97, 29);
        btnResetSim.TabIndex = 23;
        btnResetSim.Text = "Reset";
        btnResetSim.UseVisualStyleBackColor = true;
        btnResetSim.Click += btnResetSim_Click;
        // 
        // lblEvacTimeLabel
        // 
        lblEvacTimeLabel.Location = new System.Drawing.Point(4, 399);
        lblEvacTimeLabel.Name = "lblEvacTimeLabel";
        lblEvacTimeLabel.Size = new System.Drawing.Size(124, 21);
        lblEvacTimeLabel.TabIndex = 24;
        lblEvacTimeLabel.Text = "Evacuation Time:";
        lblEvacTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblResultsPanel
        // 
        lblResultsPanel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        lblResultsPanel.Location = new System.Drawing.Point(4, 341);
        lblResultsPanel.Name = "lblResultsPanel";
        lblResultsPanel.Size = new System.Drawing.Size(389, 32);
        lblResultsPanel.TabIndex = 25;
        lblResultsPanel.Text = "Results";
        lblResultsPanel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // lblSimMetrics
        // 
        lblSimMetrics.Font = new System.Drawing.Font("Segoe UI", 12F);
        lblSimMetrics.Location = new System.Drawing.Point(4, 373);
        lblSimMetrics.Name = "lblSimMetrics";
        lblSimMetrics.Size = new System.Drawing.Size(196, 23);
        lblSimMetrics.TabIndex = 26;
        lblSimMetrics.Text = "Simulation Metrics";
        lblSimMetrics.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblAlgMetrics
        // 
        lblAlgMetrics.Font = new System.Drawing.Font("Segoe UI", 12F);
        lblAlgMetrics.Location = new System.Drawing.Point(206, 373);
        lblAlgMetrics.Name = "lblAlgMetrics";
        lblAlgMetrics.Size = new System.Drawing.Size(196, 23);
        lblAlgMetrics.TabIndex = 27;
        lblAlgMetrics.Text = "Algorithm Metrics";
        lblAlgMetrics.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblEvacuatedLabel
        // 
        lblEvacuatedLabel.Location = new System.Drawing.Point(4, 420);
        lblEvacuatedLabel.Name = "lblEvacuatedLabel";
        lblEvacuatedLabel.Size = new System.Drawing.Size(124, 21);
        lblEvacuatedLabel.TabIndex = 28;
        lblEvacuatedLabel.Text = "Agents Evacuated:";
        lblEvacuatedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblCompletionLabel
        // 
        lblCompletionLabel.Location = new System.Drawing.Point(4, 441);
        lblCompletionLabel.Name = "lblCompletionLabel";
        lblCompletionLabel.Size = new System.Drawing.Size(124, 21);
        lblCompletionLabel.TabIndex = 29;
        lblCompletionLabel.Text = "Evac. Completion %:";
        lblCompletionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblAvgWaitLabel
        // 
        lblAvgWaitLabel.Location = new System.Drawing.Point(4, 462);
        lblAvgWaitLabel.Name = "lblAvgWaitLabel";
        lblAvgWaitLabel.Size = new System.Drawing.Size(124, 21);
        lblAvgWaitLabel.TabIndex = 30;
        lblAvgWaitLabel.Text = "Avg. Waiting Time:";
        lblAvgWaitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblAvgRiskLabel
        // 
        lblAvgRiskLabel.Location = new System.Drawing.Point(4, 483);
        lblAvgRiskLabel.Name = "lblAvgRiskLabel";
        lblAvgRiskLabel.Size = new System.Drawing.Size(124, 21);
        lblAvgRiskLabel.TabIndex = 31;
        lblAvgRiskLabel.Text = "Avg. Risk Exposure:";
        lblAvgRiskLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblEvacTime
        // 
        lblEvacTime.Location = new System.Drawing.Point(134, 399);
        lblEvacTime.Name = "lblEvacTime";
        lblEvacTime.Size = new System.Drawing.Size(66, 21);
        lblEvacTime.TabIndex = 32;
        lblEvacTime.Text = "0";
        lblEvacTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblEvacuated
        // 
        lblEvacuated.Location = new System.Drawing.Point(134, 420);
        lblEvacuated.Name = "lblEvacuated";
        lblEvacuated.Size = new System.Drawing.Size(66, 21);
        lblEvacuated.TabIndex = 33;
        lblEvacuated.Text = "0";
        lblEvacuated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblCompletion
        // 
        lblCompletion.Location = new System.Drawing.Point(134, 441);
        lblCompletion.Name = "lblCompletion";
        lblCompletion.Size = new System.Drawing.Size(66, 21);
        lblCompletion.TabIndex = 34;
        lblCompletion.Text = "0";
        lblCompletion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblAvgWait
        // 
        lblAvgWait.Location = new System.Drawing.Point(134, 462);
        lblAvgWait.Name = "lblAvgWait";
        lblAvgWait.Size = new System.Drawing.Size(66, 21);
        lblAvgWait.TabIndex = 35;
        lblAvgWait.Text = "0";
        lblAvgWait.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblAvgRisk
        // 
        lblAvgRisk.Location = new System.Drawing.Point(134, 483);
        lblAvgRisk.Name = "lblAvgRisk";
        lblAvgRisk.Size = new System.Drawing.Size(57, 21);
        lblAvgRisk.TabIndex = 36;
        lblAvgRisk.Text = "0";
        lblAvgRisk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblRuntime
        // 
        lblRuntime.Location = new System.Drawing.Point(336, 417);
        lblRuntime.Name = "lblRuntime";
        lblRuntime.Size = new System.Drawing.Size(57, 21);
        lblRuntime.TabIndex = 40;
        lblRuntime.Text = "0";
        lblRuntime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblNodes
        // 
        lblNodes.Location = new System.Drawing.Point(336, 396);
        lblNodes.Name = "lblNodes";
        lblNodes.Size = new System.Drawing.Size(57, 21);
        lblNodes.TabIndex = 39;
        lblNodes.Text = "0";
        lblNodes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblRuntimeLabel
        // 
        lblRuntimeLabel.Location = new System.Drawing.Point(206, 417);
        lblRuntimeLabel.Name = "lblRuntimeLabel";
        lblRuntimeLabel.Size = new System.Drawing.Size(124, 21);
        lblRuntimeLabel.TabIndex = 38;
        lblRuntimeLabel.Text = "Runtime:";
        lblRuntimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblNodesLabel
        // 
        lblNodesLabel.Location = new System.Drawing.Point(206, 396);
        lblNodesLabel.Name = "lblNodesLabel";
        lblNodesLabel.Size = new System.Drawing.Size(124, 21);
        lblNodesLabel.TabIndex = 37;
        lblNodesLabel.Text = "Nodes Explored:";
        lblNodesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblRiskWeight
        // 
        lblRiskWeight.Location = new System.Drawing.Point(346, 147);
        lblRiskWeight.Name = "lblRiskWeight";
        lblRiskWeight.Size = new System.Drawing.Size(80, 18);
        lblRiskWeight.TabIndex = 41;
        lblRiskWeight.Text = "Risk Weight";
        lblRiskWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // nudRiskWeight
        // 
        nudRiskWeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
        nudRiskWeight.DecimalPlaces = 1;
        nudRiskWeight.Location = new System.Drawing.Point(432, 147);
        nudRiskWeight.Name = "nudRiskWeight";
        nudRiskWeight.Size = new System.Drawing.Size(60, 19);
        nudRiskWeight.TabIndex = 42;
        // 
        // pnlGridHost
        // 
        pnlGridHost.Controls.Add(pnlGrid);
        pnlGridHost.Controls.Add(pnlLegend);
        pnlGridHost.Location = new System.Drawing.Point(4, 7);
        pnlGridHost.Name = "pnlGridHost";
        pnlGridHost.Size = new System.Drawing.Size(331, 331);
        pnlGridHost.TabIndex = 43;
        // 
        // pnlGrid
        // 
        pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlGrid.Location = new System.Drawing.Point(0, 0);
        pnlGrid.Name = "pnlGrid";
        pnlGrid.Size = new System.Drawing.Size(331, 331);
        pnlGrid.TabIndex = 1;
        pnlGrid.Paint += pnlGrid_Paint;
        pnlGrid.MouseDown += pnlGrid_MouseDown;
        // 
        // pnlLegend
        // 
        pnlLegend.Location = new System.Drawing.Point(4, 260);
        pnlLegend.Name = "pnlLegend";
        pnlLegend.Size = new System.Drawing.Size(331, 78);
        pnlLegend.TabIndex = 44;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(701, 523);
        Controls.Add(pnlGridHost);
        Controls.Add(nudRiskWeight);
        Controls.Add(lblRiskWeight);
        Controls.Add(lblRuntime);
        Controls.Add(lblNodes);
        Controls.Add(lblRuntimeLabel);
        Controls.Add(lblNodesLabel);
        Controls.Add(lblAvgRisk);
        Controls.Add(lblAvgWait);
        Controls.Add(lblCompletion);
        Controls.Add(lblEvacuated);
        Controls.Add(lblEvacTime);
        Controls.Add(lblAvgRiskLabel);
        Controls.Add(lblAvgWaitLabel);
        Controls.Add(lblCompletionLabel);
        Controls.Add(lblEvacuatedLabel);
        Controls.Add(lblAlgMetrics);
        Controls.Add(lblSimMetrics);
        Controls.Add(lblResultsPanel);
        Controls.Add(lblEvacTimeLabel);
        Controls.Add(btnResetSim);
        Controls.Add(btnClearScenario);
        Controls.Add(btnStep);
        Controls.Add(btnRun);
        Controls.Add(lblSpeed);
        Controls.Add(tbSpeed);
        Controls.Add(rbInstantMode);
        Controls.Add(rbStepMode);
        Controls.Add(lblSimulationControls);
        Controls.Add(cboAlgorithm);
        Controls.Add(lblAlgorithm);
        Controls.Add(nudDecayRate);
        Controls.Add(lblDecayRate);
        Controls.Add(lblSeverity);
        Controls.Add(nudSeverity);
        Controls.Add(lblHazardModifier);
        Controls.Add(lblTools);
        Controls.Add(rbEraser);
        Controls.Add(rbSpawn);
        Controls.Add(rbHazard);
        Controls.Add(rbExit);
        Controls.Add(rbWall);
        Controls.Add(lblScenarioEditor);
        DoubleBuffered = true;
        Location = new System.Drawing.Point(15, 15);
        ((System.ComponentModel.ISupportInitialize)nudSeverity).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudDecayRate).EndInit();
        ((System.ComponentModel.ISupportInitialize)tbSpeed).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudRiskWeight).EndInit();
        pnlGridHost.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Panel pnlLegend;

    private System.Windows.Forms.Panel pnlGridHost;

    private System.Windows.Forms.Label lblRiskWeight;
    private System.Windows.Forms.NumericUpDown nudRiskWeight;

    private System.Windows.Forms.Label lblRuntime;
    private System.Windows.Forms.Label lblNodes;
    private System.Windows.Forms.Label lblRuntimeLabel;
    private System.Windows.Forms.Label lblNodesLabel;

    private System.Windows.Forms.Label lblEvacuated;
    private System.Windows.Forms.Label lblCompletion;
    private System.Windows.Forms.Label lblAvgWait;
    private System.Windows.Forms.Label lblAvgRisk;

    private System.Windows.Forms.Label lblAvgWaitLabel;
    private System.Windows.Forms.Label lblAvgRiskLabel;
    private System.Windows.Forms.Label lblEvacTime;

    private System.Windows.Forms.Label lblResultsPanel;
    private System.Windows.Forms.Label lblSimMetrics;
    private System.Windows.Forms.Label lblAlgMetrics;
    private System.Windows.Forms.Label lblCompletionLabel;

    private System.Windows.Forms.Label lblEvacTimeLabel;
    private System.Windows.Forms.Label lblEvacuatedLabel;

    private System.Windows.Forms.Button btnClearScenario;
    private System.Windows.Forms.Button btnResetSim;

    private System.Windows.Forms.Button btnRun;

    private System.Windows.Forms.Label lblSimulationControls;
    private System.Windows.Forms.RadioButton rbStepMode;
    private System.Windows.Forms.RadioButton rbInstantMode;
    private System.Windows.Forms.TrackBar tbSpeed;
    private System.Windows.Forms.Button btnStep;

    private System.Windows.Forms.Label lblSpeed;

    private System.Windows.Forms.Label lblDecayRate;
    private System.Windows.Forms.Label lblAlgorithm;
    private System.Windows.Forms.NumericUpDown nudDecayRate;
    private System.Windows.Forms.ComboBox cboAlgorithm;

    private System.Windows.Forms.Label lblSeverity;

    private System.Windows.Forms.Label lblHazardModifier;
    private System.Windows.Forms.NumericUpDown nudSeverity;

    private System.Windows.Forms.RadioButton rbWall;
    private System.Windows.Forms.RadioButton rbExit;
    private System.Windows.Forms.RadioButton rbHazard;
    private System.Windows.Forms.RadioButton rbSpawn;
    private System.Windows.Forms.RadioButton rbEraser;
    private System.Windows.Forms.Label lblTools;

    private System.Windows.Forms.Label lblScenarioEditor;

    private EvacuationSimulator.UI.DoubleBufferedPanel pnlGrid;

    #endregion
}