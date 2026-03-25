using EvacuationSimulator.Data;

namespace EvacuationSimulator.UI;

public partial class ExampleScenarioPickerForm : Form
{
    private readonly List<ScenarioListItem> allScenarios;
    private ScenarioListItem? selectedScenario;
    private Panel? selectedCard;

    public string? SelectedScenarioPath => selectedScenario?.FilePath;
    
    public ExampleScenarioPickerForm(List<ScenarioListItem> scenarios)
    {
        InitializeComponent();
        
        allScenarios = scenarios;

        btnLoad.DialogResult = DialogResult.OK;
        btnLoad.Click += btnLoad_Click;

        btnCancel.DialogResult = DialogResult.Cancel;

        txtSearch.TextChanged += txtSearch_TextChanged;

        flpScenarioCards.AutoScroll = true;
        flpScenarioCards.FlowDirection = FlowDirection.TopDown;
        flpScenarioCards.WrapContents = false;
        flpScenarioCards.AutoSize = false;

        AcceptButton = btnLoad;
        CancelButton = btnCancel;

        RebuildScenarioCards(allScenarios);
    }

    private void txtSearch_TextChanged(object? sender, EventArgs e)
    {
        string search = txtSearch.Text.Trim();

        List<ScenarioListItem> filtered = allScenarios
            .Where(s => s.DisplayName.Contains(search, StringComparison.OrdinalIgnoreCase))
            .ToList();

        RebuildScenarioCards(filtered);
    }

    private void RebuildScenarioCards(List<ScenarioListItem> scenarios)
    {
        flpScenarioCards.SuspendLayout();
        flpScenarioCards.Controls.Clear();

        selectedScenario = null;
        selectedCard = null;
        btnLoad.Enabled = false;

        foreach (ScenarioListItem scenario in scenarios)
        {
            Panel card = BuildScenarioCard(scenario);
            
            flpScenarioCards.Controls.Add(card);
        }

        flpScenarioCards.ResumeLayout();
    }

    private Panel BuildScenarioCard(ScenarioListItem scenario)
    {
        int cWidth = flpScenarioCards.Width * 44 / 49;
        Panel card = new Panel
        {
            Width = cWidth,
            Height = 72,
            BackColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle,
            Margin = new Padding(0, 0, 0, 8),
            Tag = scenario,
            Cursor = Cursors.Hand
        };

        Label lblName = new Label
        {
            Text = scenario.DisplayName,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            AutoSize = false,
            Bounds = new Rectangle(12, 10, cWidth, 22),
            TextAlign = ContentAlignment.MiddleLeft,
            BackColor = Color.Transparent
        };

        Label lblFile = new Label
        {
            Text = Path.GetFileName(scenario.FilePath),
            Font = new Font("Segoe UI", 8.5F),
            ForeColor = Color.DimGray,
            AutoSize = false,
            Bounds = new Rectangle(12, 36, cWidth, 18),
            TextAlign = ContentAlignment.MiddleLeft,
            BackColor = Color.Transparent
        };

        card.Click += ScenarioCard_Click;
        lblName.Click += ScenarioCard_Click;
        lblFile.Click += ScenarioCard_Click;

        card.DoubleClick += ScenarioCard_DoubleClick;
        lblName.DoubleClick += ScenarioCard_DoubleClick;
        lblFile.DoubleClick += ScenarioCard_DoubleClick;
        
        card.Controls.Add(lblName);
        card.Controls.Add(lblFile);

        return card;
    }
    
    private void ScenarioCard_Click(object? sender, EventArgs e)
    {
        Panel card = GetOwningCard(sender);
        SelectCard(card);
    }
    
    private void ScenarioCard_DoubleClick(object? sender, EventArgs e)
    {
        Panel card = GetOwningCard(sender);
        SelectCard(card);

        if (selectedScenario is not null)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    private Panel GetOwningCard(object? sender)
    {
        if (sender is Panel panel)
            return panel;

        if (sender is Control control && control.Parent is Panel parentPanel)
            return parentPanel;

        throw new InvalidOperationException("Could not determine selected scenario card.");
    }

    private void SelectCard(Panel card)
    {
        if (selectedCard is not null)
            selectedCard.BackColor = Color.White;

        selectedCard = card;
        selectedCard.BackColor = Color.FromArgb(230, 240, 255);

        selectedScenario = (ScenarioListItem)card.Tag!;
        btnLoad.Enabled = true;
    }

    private void btnLoad_Click(object? sender, EventArgs e)
    {
        if (selectedScenario is null)
        {
            DialogResult = DialogResult.None;
            return;
        }

        DialogResult = DialogResult.OK;
        Close();
    }
}