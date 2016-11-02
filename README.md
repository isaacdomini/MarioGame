Code analysis warnings
- all 10 of CA 1002 are irrelevant - we are intentionally using List instead of Collection because List has the cool FindAll methods that you can pass lambdas into
- the 6 CA2227's present in LevelLoader.cs are irrelevant - it is saying to get rid of the setters for our LevelLoader. The setters are necessary for the newtsonsoft json library to work
- all 6 of the CA1811's are irrelevant - those constructors are called - dynamically via the json file and level loader
- 41 warnings - 10 - 6 - 6 = 19 real warnings.
