QBATCH Programming Guide (For version 1.1.1.1)
(C) Michael Wang, developed for QBATCH

INTRODUCTION
QBATCH is a method-oriented language. That means all peices of code are organized into methods. The entry point of a QBATCH application is the main function. The first 4 lines are properties describing the program. QBATCH has the basic condition checkers, supports basic data structures and basic commands.


THE FIRST FOUR LINES
The first four lines describe application properties, and are interpreted in the following way. It's also shown when the program crashes.

PROGRAMNAME[Fig. 1]
AUTHOR[Fig. 2]
COPYRIGHT[Fig. 3]
DIRECTORY[Fig. 4]

Figure 1.
This could be any string. This describes the name of the program.

Figure 2.
This could be any string. This describes the name of the person who wrote the program.

Figure 3..
This could be any string. This describes the name of the copyright of the program.
Examples
(C) Michael Wang 2019
(C) Jackie Chan 1995

Figure 4.
This has to be a valid file path. Though the following keywords included will be replaced by certain Environment filepath constants
Constant Name		Replaced With
[username]		The username of the current user.
[documents]		The path of the documents folder of the current user.
[desktop]		The path of the desktop folder of the current user.
[programs]		The path of the system's default program files directory.


METHODS
Methods are lines of code within a certain region. All lines within will be executed. If a method is not "linked" (or is dead code), QBATCH will not interpret and therfore not detect any errors in that method.
Example
#method METHODNAME[Fig. 1]
CODE[Fig. 2]
#endmethod METHODNAME

Figure 1.
The name of the method. This has to be a unique name reletivley to the names of all other methods in your program

Figure 2.
Code that's inside your method. This code is executed when the method is run.


CONDITION CHECKS AND STRUCTURES
Here is an example of a condition check with a structure:
STRUCTURE var1 CHECK var2
ONELINEOFEXECUTION

Here is an example of a simple if statement. You may notice that the variable refrencing looks funny. We'll get to that in the next bit. In this case, if the variable name is micahael then it will execute the function, sayhellotomichael
if var:name:None == raw:Michael
sayhellotomichael

QBATCH supports the following types of checks
Check			Function
==			Returns true if the condition is true
!=			Returns true if the condition is false

QBATCH supports the following types of structures.
Condition		Function											Depends On Condition
IF			Executes the method of the name bellow it's line if the condition is true.			YES
WHILE			Executes the method of the name bellow it's line while the condition is true.			YES
REPEAT			Executes the method of the name bellow it's line for a certain amount of times.			NO


DECLARING(MAKING) VARIABLES
Here is an example for declaring a variable. Variables do not need to be deleted or disposed because it is automatic.
#declarevar TYPE[Fig. 1] NAME[Fig. 2]

Figure 1.
This is the variable type. Currently, QBATCH only supports var (which could be a string or integer) and arr (which is an array of var).

Figure 2.
This has to be a unique name relativley to the rest of the variable names.


REFERENCING (Except for assigning)
Here is an example for referencing an item, except in assigning , because only variables can be assigned to.
TYPE [Fig. 1]:NAME/DATA[Fig. 2]:ARGUMENTS[Fig. 3]

Figure 1.
This is a type. It can be "var" (this tells the variable manager to get the variable value of the variable called NAME/DATA). It can also be "raw" which uses the NAME/DATA as its own value.

Figure 2.
This is the name of a variable or some data like a string, int, or array.

Figure 3.
These are argument(s) for fetching the variable. In this case, it is only used when refrencing an item from an array. 

Note: No variable arguments support another refrence.


SETTING VARIABLES
Here is an example of setting a variable
NAME[Fig 1.]:ARGUMENTS[Fig 2.] = REFRENCE[Fig 3.]

Figure 1.
This is the name of a variable or some data like a string, int, or array.

Figure 2.
These are argument(s) for fetching the variable. In this case, it is only used when refrencing an item from an array. 

Figure 3.
This is a refrence as described in REFRENCING.

Note: No variable arguments support another refrence.


COMMANDS THAT DON'T RETURN A VALUE
Commands may or may not take in a argument. If the command does, that argument is the second item in the list (which is obtained by spliting the input with a space character) and is a refrence, as described in REFRENCING. Also note, the only valid colors are "red", "yellow", "green", "blue", "black", and "white".

COMMAND NAME		FUNCTION					ARGUMENT(S)			EXAMPLE(RAWVALUE)		EXAMPLE(VARIABLE)
writeline		Writes text on a new line.			towrite				writeline raw:Hello_World	writeline var:towrite:None
write			Writes text.					towrite				write raw:Hello_World		writeline var:towrite:None
title			Sets the window title. 				newtitle			title raw:Hello_World		title var:newtitle
forecolor		Sets the console forecolor (textcolor).		color				forecolor raw:blue		forecolor var:newcolor:None
backcolor		Sets the consoles background color.		color				backcolor raw:blue		backcolor var:newcolor:None
call			Runs another method.				methodname			call mymethod			N/A
mkfile			Makes a file.					filepath			mkfile raw:test.txt		mkfile var:fileinput:None
delfile			Deletes a file					filepath			delfile raw:test.txt		delfile var:fileinput:None
writefile		Writes content to a file			filepath,contents		writefile raw:t var:cont:None   writefile var:fileinput:None raw:Random_Content
filecopy		Copys a file					source,destination		filecopy raw:src var:dest:None	filecopy var:src:None raw:destination
movedir			Moves a directory				source,destination		movedir	raw:src var:dest:None	movedir var:src:None raw:dest:None
mkdir			Make directory					directorypath			mkdir raw:test			mkdir var:name:None
readkey			Waits for the user to press any key.		N/A				readkey				readkey
consoleclear		Clears the terminal.				N/A				consoleclear			consoleclear
pass			Skips the current line.				N/A				pass				pass

COMMANDS THAT RETURN A VALUE AND OPERATORS
Variables may be set to a raw value, another variable value, or a value returned from a command

COMMANDNAME		FUNCTION					ARGUMENT(S)			RETURNS				EXAMPLE
input			Gets raw input from the user.			N/A				Raw value			ans:None = input
readfile		Reads the text from a file.			filepath			Text in a file			contents:None = readfile raw:test.txt\
confirm			Asks the user "are you sure".			N/A				yes,no,?			ok:None = confirm
+			Adds 2 REFRENCES.				ref1,ref2			sum of ref1 and ref2		sum:None = var:a:None + raw:1
-			Subtracts 2 REFRENCES.				ref1,ref2			sum of ref1 and ref2		sum:None = var:a:None - raw:1
*			Multiplys 2 REFRENCES.				ref1,ref2			sum of ref1 and ref2		prod:None = var:a:None * raw:1
/			Divides 2 REFRENCES				ref1,ref2			quotient of ref 1 and ref2	quo:None = var:a:None / raw:10
%			Divides 2 REFRENCES then returns the remainder	ref1,ref2			remainder of ref1 and ref2	rem:None = var:a:None % raw:3
cnstr			Combines the raw value				ref1,ref2			literally ref1+ref2		str:None = raw:Name_ cnstr var:name


IMPORTING A LIBRARY
QBATCH searches the entire code (whether if it's outside a method or not) for any #import. This copy and pastes some code from another file into your program. Note, be carful to not name any of your methods the same as any of the library's (the code from another file) methods.

EXAMPLE:
#import math_constants

where math_constants is the name of the library

MORE ON ARRAYS
Back to arrays, here is an list of all the functions you can to do an array.

FUNCTION				EXAMPLE				NOTES:
Set an item based on an index.		people:0 = raw:Michael		Sets the first element of people to Michael.
Deletes an item based on an index.	people:0 = raw:deleteat		Deletes the first element of people.
Adds an item to the array.		people:add = raw:Michael	Adds Michael to people
Gets the length of an array.		count:None = people:length	Sets the value of count to the length of people.