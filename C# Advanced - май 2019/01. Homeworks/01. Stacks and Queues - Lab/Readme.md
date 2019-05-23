# Lab: Stacks and Queues

Problems for exercises and homework for the "CSharp Advanced" course Software University. <br />
You can check your solutions here: (https://judge.softuni.bg/Contests/1445/Stacks-and-Queues-Lab)

## 1. Reverse Strings

Write program that: <br />
•	Reads an input string <br />
•	Reverses it using a Stack<T> <br />
•	Prints the result back at the terminal <br />

<p><b>Examples:</b></p>

| Input  | Output |
| ------------- | ------------- |
| I Love C#  | #C evoL I  |
| Stacks and Queues  | seueuQ dna skcatS  |

<p><b>Hints</b></p>

•	Use a Stack<string> <br />
•	Use the methods Push(), Pop() <br />

## 2. Stack Sum

Write program that: <br />
•	Reads an input of integer numbers and adds them to a stack <br />
•	Reads commands until "end" is received <br />
•	Prints the sum of the remaining elements of the stack <br />

<p><b>Input</p></b>
•	On the first line you will receive an array of integers <br />
•	On the next lines, until the "end" command is given, you will receive commands – a single command and one or two numbers after the command, depending on what command you are given <br />
•	If the command is "add", you will always receive exactly two numbers after the command which you need to add in the stack <br />
•	If the command is "remove", you will always receive exactly one number after the command which represents the count of the numbers you need to remove from the stack. If there are not enough elements skip the command. <br />

<p><b>Output</p></b>
•	When the command "end" is received, you need to print the sum of the remaining elements in the stack <br />

<p><b>Examples:</b></p>

| Input         | Output |
| ------------- | ------------- |
| 1 2 3 4       | Sum: 6        |
|adD 5 6        |               |
|REmove 3       |               |
|eNd            |               |