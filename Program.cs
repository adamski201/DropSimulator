using DropSimulator.Services;
using DropSimulator.Simulators;

var rngProvider = new RandomProvider();

var sim = new BossSimulator(new KingBlackDragonDropLogic(rngProvider));

var result = sim.RunSimulation(1);

var resul2t = result;