# WordLadder
Technical Assessment for Potential Employer

This repository contains a solution to the word ladder problem put simply:
given a set of input words W, 
find the shortest path between any 2 words in W 
such that each word is separate from the last in the sequence by a change of only 1 letter

The solution as provided is rudimentary and inefficient in that it suffers from O(N^2) problems
and thus for a input set of reasonable size it becomes unmanagably slow. 

ALthough it does do some filtering, this doesn;t address the problem, only allows input sets that contain entries to be 
reduced. Currently it checks that they are valid words formats of 4 letters in length. 

The main purpose was to demonstrate good use of OOP principles in design etc, rather than
to provide a practical solution in terms of performance. 

here are many improvements that would be made were this to be taken further.
