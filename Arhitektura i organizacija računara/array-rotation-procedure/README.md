# Array Rotation Using Assembly Procedures

## Overview

This project focuses on implementing array manipulation algorithms in Assembly language, with an emphasis on procedure calls, stack-based parameter passing, register usage, and memory addressing.

The main task is to implement a procedure that rotates the elements of a 16-bit array to the left or right by a specified number of positions. The procedure receives the array address, rotation count, and rotation direction through the stack, while the array size is passed through a register.

The main program applies this procedure to a matrix, rotating each row according to its index:
- **Even-indexed rows:** rotate left.
- **Odd-indexed rows:** rotate right.
- **Rotation count:** determined by the row index.

## Key Concepts

- **Assembly procedures:** Defining and calling reusable routines.
- **Stack-based parameter passing:** Passing arguments to procedures through the stack.
- **Register usage:** Passing array size and managing intermediate values.
- **Memory addressing:** Accessing and modifying 16-bit array elements.
- **Array manipulation:** Implementing left and right cyclic rotations.
- **Matrix processing:** Applying different transformations to individual rows.
- **Stack analysis:** Examining the stack layout during a procedure call.

## Algorithm

1. Receive the array address, rotation count, and direction as procedure arguments.
2. Obtain the array size from the designated register.
3. Normalize the rotation count to avoid unnecessary rotations.
4. Perform the requested cyclic rotation while preserving the original order of elements.
5. Return control to the calling program.
6. Process each matrix row, selecting the rotation direction and count according to its index.
7. Verify the result using sample input data and the expected output.

## Learning Objectives

The goal is to understand how higher-level algorithmic operations can be implemented using low-level instructions, explicit memory access, registers, and stack management.

The project also demonstrates the relationship between procedure calling conventions, parameter passing, and program execution at the processor level.

## Technologies

- Assembly language
- Computer architecture
- Stack and register operations
- Memory addressing
