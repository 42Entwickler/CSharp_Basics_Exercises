# OOP Testdriven Sample
In this repository you find a .net 5 solution with unit tests for a priority queue.
This tests allows you to implement a class named `MyPriorityQueue` in the **PriorityQueueMA**. Add the missing properties and methods so that the code compiles successfully.
Also add an enum type `PersonTypes` with the values `Vip` and `Normal`, so that the code compiles.
After that you should implement the Push- and Pop-Methods and the required properties. The tests will show you if your implementation is correct.

## Step 1:
Implement the local state of the class with an array for the name and an array for the priority for each person. This internal state must be secret (=private).

We know that the internal state of a class mustn't be public to be able to control the access to the state and ensure a valid state if there are multiple variables depending on each other.
But also a reason to have a secret state is that we can change or optimize the internal state of the class and everything still is working fine.

## Step 2:
Create a private class `PersonInfo` containing the name and the `PersonTypes`-information. This private class is just a helper class for the representation of the internal state.
So in this step to show how cool a private internal state is: Remove the two arrays from Step 1 and just use one single array of type `PersonInfo`. But don't change any method signature.
That means all unit tests still work. Just the internal state is changed.
