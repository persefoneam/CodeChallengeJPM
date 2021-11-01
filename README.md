# CodeChallengeJPM
This is a .Net Senior developer code challenge for a very famous finance and bank company. 
The code challenge passed the assestment, the technical interview was successfull, I rejected the final offer. 

This was the challenge: 

-------------------------------------------------------------------------------------------------------------------------------------------------------------

Some rules to follow:

* Avoid the use of any Frameworks beyond the standard language features (Spring, etc).  Their use is not needed for the exercise and can mean we will not assess it.  Please use standard Object oriented programming features for this exercise.

------------------------------------------------------------

A Bank is interested in implementing a system that can value an investment portfolio.

Their portfolios can be made up of stocks, bonds and cash in US Dollars and Euros.

The prices for each of these instruments is determined by a separate pricing system which you will need to interact with (no need to implement this system, you can assume a valid price is always available).

Please use an object oriented language of your choice to implement a system that allows the Bank to:

1) Build up the portfolio from their transaction history (buy and sell transactions where a certain number of each instrument can be bought or sold on a given date)

2) Calculate the current value of the portfolio either in US Dollars or in Euros.  The value of each instrument held is simply the amount currently held multiplied by the current price.

3) Calculate the profit and loss of each of the investments in the portfolio assuming it can be calculated simply by:
	PnL = current holding * (current price - purchase price)

4) No "short" positions are to be allowed in the system


Notes:
* You DO NOT need to implement a UI for this system.
* You can assume that the transaction history data is already given to you (you do not need to write code to load it from a file, database or similar source).
* All the rules the company requires are given above.  There are no other rules to apply.

------------------------------------------------------------------------------------------------------------------------------------------------
I created a fake DAL layer with some harcoded data. 
I created a fake "communications" layer to consume in an async way a fake external service
