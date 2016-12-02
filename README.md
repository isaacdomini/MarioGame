Code analysis warnings
- all of CA 1002 are irrelevant - we are intentionally using List instead of Collection because List has the cool FindAll methods that you can pass lambdas into
- the CA2227's present are irrelevant - it is saying to get rid of the setters for many of our variables. The setters are necessary for the json library to work, and some of the methods set the values it told us to change.
- all of the CA1811's are irrelevant - those constructors are called - dynamically via the json file and level loader
- The CA1822 warnings telling us to change the variables to static were no changed because by the time we did the code review, we would not have neough time to change these all. Changing these would cause us to change a lot of other methods and variables throughout the rest of the program, and we do not have time to change this much of our code. 
- CA1008 was suppressed because we want the frame to be called the name that it does so that we know specifically which frame is being used. If we changed it to "Zero" then it wouldn't be as easy to know what the koopa actually looks like.
- CA1823 should be suppressed because it is actually used. When deleted, we are given errors later in the code because the variable it used later.
- CA1006: we purposefully created the FramSets and RowSets liek this so that we can easily switch frames and animate the sprites by cycling through the collections within the dictionary.
