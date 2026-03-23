using System.ComponentModel;

namespace EvacuationSimulator.UI;

partial class ExampleScenarioPickerForm
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
        lblTitle = new System.Windows.Forms.Label();
        txtSearch = new System.Windows.Forms.TextBox();
        flpScenarioCards = new System.Windows.Forms.FlowLayoutPanel();
        btnLoad = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        lblTitle.Location = new System.Drawing.Point(2, 4);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new System.Drawing.Size(299, 23);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Example Scenarios";
        // 
        // txtSearch
        // 
        txtSearch.Location = new System.Drawing.Point(12, 30);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new System.Drawing.Size(280, 23);
        txtSearch.TabIndex = 1;
        // 
        // flpScenarioCards
        // 
        flpScenarioCards.Location = new System.Drawing.Point(12, 59);
        flpScenarioCards.Name = "flpScenarioCards";
        flpScenarioCards.Size = new System.Drawing.Size(279, 379);
        flpScenarioCards.TabIndex = 2;
        // 
        // btnLoad
        // 
        btnLoad.Location = new System.Drawing.Point(216, 444);
        btnLoad.Name = "btnLoad";
        btnLoad.Size = new System.Drawing.Size(75, 28);
        btnLoad.TabIndex = 3;
        btnLoad.Text = "Load";
        btnLoad.UseVisualStyleBackColor = true;
        // 
        // btnCancel
        // 
        btnCancel.Location = new System.Drawing.Point(135, 444);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new System.Drawing.Size(75, 28);
        btnCancel.TabIndex = 4;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        // 
        // ExampleScenarioPickerForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(304, 481);
        Controls.Add(btnCancel);
        Controls.Add(btnLoad);
        Controls.Add(flpScenarioCards);
        Controls.Add(txtSearch);
        Controls.Add(lblTitle);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Load Example Scenario";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.FlowLayoutPanel flpScenarioCards;
    private System.Windows.Forms.Button btnLoad;
    private System.Windows.Forms.Button btnCancel;

    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.TextBox txtSearch;

    #endregion
}