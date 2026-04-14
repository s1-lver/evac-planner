# Hazard-Aware Evacuation Simulator
![Main editor](media/images/screenshots/main_program_interface.png)

A C# WinForms evacuation simulation system that allows users to design custom scenarios, run multi-agent evacuations, compare different pathfinding algorithms under hazard constraints, and generate an algorithm recommendation based on specified training scenario cases.

The quality of routes during an evacuation directly affects safety and efficiency. Different layouts, hazards, obstacles, and congestion patterns in the area can change which routing strategy might be most suitable. This project was built to explore how classical pathfinding algorithms behave under these conditions and constraints, and to provide a way to simulate, compare, and then analyse their performance in a controlled environment

## Key Features

- Create and edit 2D evacuation scenarios
- Place walls, exits, agents, and hazards on a grid
- Simulate multi-agent evacuations over time
- Compare multiple pathfinding algorithms:
  - Breadth-First Search (BFS)
  - Dijkstra’s Algorithm
  - A* Search
  - Greedy Best-First Search
- Apply hazard-aware path costs to model unsafe areas
- Benchmark algorithm performance using simulation metrics
- Recommend a suitable algorithm using a K-Nearest Neighbours (KNN) model
- Load example scenarios for classroom use

## System Overview

The project is structured around several key parts:

### User Interface
The WinForms UI allows users to:
- create, edit, and load scenario layouts
- configure scenarios
- run simulations
- view metrics and algorithm results

### Simulation Engine
The simulation engine manages:
- agent movement
- tick-based updates
- same-cell movement conflicts
- evacuation progress

### Pathfinding Layer
The pathfinding layer contains each implemented algorithm, allowing them to be used and compared under the same scenario.

### Recommendation Subsystem
The recommendation subsystem extracts scenario features and uses a KNN classifier to suggest a suitable algorithm based on previously benchmarked scenario cases.

## Hazard-Aware Routing
A major aspect of the project is the use of hazard-aware traversal cost. The simulator considers cells closer to a hazard (or risk source) as more "costly", allowing the system to model situations where the shortest geometric route does not translate to the safest route.

## Recommendation Engine
The system includes a simple recommendation feature, using the K-Nearest Neighbours algorithm (KNN) to suggest a suitable algorithm for a given scenario. 

The recommendation given by the engine is based on certain scenario features such as:
- grid dimensions
- number of agents
- number of exits
- number of hazards
- average hazard severity
- obstacle/wall density
- minimum spawn to hazard distance
- minimum exit to hazard distance

This subsystem was implemented as a secondary feature to explore how benchmarked scenario data could be used to support algorithm selection. It is intentionally lightweight, and should be treated as a supporting decision rather than a guranteed optimal algorithm.

## Screenshots / Demo
The main editor interface is presented at the top of this page.
![Scenario picker](media/images/screenshots/scenario_picker_interface.png)

https://github.com/user-attachments/assets/b513da2e-aff4-48b9-8713-3ab6c87cadfc

## Tech Stack
- C#
- .NET / WinForms
- JetBrains Rider
- Custom pathfinding and simulation logic
- KNN-based recommendation logic

## Start-Up Instructions
The project targets [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) and is intended for Windows platforms only due to the use of WinForms.

1. Clone this repository
2. Open `solution/EvacuationSimulator/EvacuationSimulator.sln` in your preferred IDE
3. Restore dependencies and build the solution
4. Run the WinForms application

## Project Structure
```text
solution/
└── EvacuationSimulator/
    ├── EvacuationSimulator.sln
    └── EvacuationSimulator/
        ├── Algorithms/
        ├── Core/
        ├── Data/
        ├── UI/
        ├── TrainingData/
        └── ExampleScenarios/
```

## Example Workflow
1. Create/load an evacuation scenario
2. Place exits, walls, agents, and hazards
3. Select a pathfinding algorithm
4. Run the simulation
5. Compare metrics such as evacuation performance and algorithm behaviour
6. Use the recommendation feature to identify the potential best algorithm for similar scenarios

## Project Limitations
* The project simplifies a space by using a 2D grid representation
* Hazard behaviour is modelled, not physically simulated
* Recommendation quality is dependant on the benchmark data and selected features
* The application is desktop-based only
* The recommendation subsystem is intended as decision support, it does not guarantee an optimal algorithm

## Potential Improvements
* Add more realistic crowd behaviour
* Support larger, more complex maps
* Improve hazard modelling
* Expand the recommendation system using more data or a more advanced ML algorithm
* Add more insightful metrics and visual analytics

## Documentation
Further detail can be found in the full [project report](docs/Project%20Report.docx).

Note: the report is provided as a `.docx` file to preserve embedded demonstration videos.
