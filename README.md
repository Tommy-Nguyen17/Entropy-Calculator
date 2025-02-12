Entropy Calculator!

Password entropy is one way of determining how difficult a password is to guess with a brute force attack. The formula to calculate entropy is: E = L * [Equation] or E = L * log(R) / log(2) 
where: 

L = Length of the password 
R = The number of different possible characters in the password pool 

We will only be dealing with passwords that could be typed on a US English keyboard, so the possible character pools are: 

Digits: 0-1                                           Pool Size: 10
Lowercase Letters: a-z                                Pool Size: 26
Uppercase Letters: A-Z                                Pool Size: 26
Special Characters: `~!@#$%^&*()-_=+[{}]\;:’”<>/?     Pool Size: 32

For example, for the password StrongPass123! we would calculate the pool size as 94 (10 + 26 + 26 + 32, because it has at least 1 element from all 4 rows) and the password is 14 characters long. 

E = 14 * log(94) / log(2) 
	E = 91.76 bits of entropy 

To estimate the number of guesses it will take to find a password we use 2^(n-1), where n is the number of bits of entropy. 


This program is an interactive program that accepts a password and number of guesses per second, calculates the entropy of the provided password, and outputs the entropy and approximate time to brute force the password.
