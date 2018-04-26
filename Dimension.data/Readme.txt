Prject Dimension Module #2
==========================

Dependencies:
(None)

Data is a module that handles all transactions between modules, keeping them in a unified format

-It operates with correspondence to the API, creating shapes and composite shapes as requested

-It hosts the shape & Composite structure (Optional)

-it hosts Bounds with both types lines and morphs

-And it hosts the point 

-Angles are stored with functions that can produce their trignometric identites

Note: The reason we resort to such "encapsulations" is to handle possible failures that may
result from either using floating points or matrix multiplication itself, these passthrough functions
will provide a vital degree of result editing (if required).


This class structure will act as a massenger between program modules