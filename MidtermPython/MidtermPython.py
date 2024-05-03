# Declare main
def main():

    # Declare option operator to hold the user's choice
    option = 0

    # Declare while loop that  runs the calculator program until the user specifies not to
    while option != 5:

        # Print statement that display to the user all of there options every loop
        print('Calculator Controls: ')
        print('To add, press 1')
        print('To subtract, press 2')
        print('To multiply, press 3')
        print('To divide, press 4')
        print('To quit the program, press 5\n')

        # Get the option from the user
        option = int(input('Please choose an option: '))

        # If statement that checks if the user picked the first option
        if option == 1:
            operand_1 = float(input('Please enter your first operand: ')) # Get the first operand from the user
            operand_2 = float(input('Please enter your second operand: ')) # Get the second operand from the user
            result = add(operand_1, operand_2) # Get the rsults by calling the add function
            print(f'{operand_1} + {operand_2} is equal to {result:.4f}.\n') # Display results to the user
        elif option == 2: # Elif statement that checks if the user picked the second option
            operand_1 = float(input('Please enter your first operand: ')) # Get the first operand from the user
            operand_2 = float(input('Please enter your second operand: ')) # Get the second operand from the user
            result = subtract(operand_1, operand_2) # Get the rsults by calling the subtract function
            print(f'{operand_1} - {operand_2} is equal to {result:.4f}.\n') # Display results to the user
        elif option == 3: # Elif statement that checks if the user picked the third option
            operand_1 = float(input('Please enter your first operand: ')) # Get the first operand from the user
            operand_2 = float(input('Please enter your second operand: ')) # Get the second operand from the user
            result = multiply(operand_1, operand_2) # Get the rsults by calling the multiply function
            print(f'{operand_1} * {operand_2} is equal to {result:.4f}.\n') # Display results to the user
        elif option == 4: # Elif statement that checks if the user picked the fourth option
            operand_1 = float(input('Please enter your first operand: ')) # Get the first operand from the user
            operand_2 = float(input('Please enter your second operand: ')) # Get the second operand from the user
            while operand_2 == 0: # While loop that makes sure that the user doesn't divide by zero and cause an error
                operand_2 = float(input('Divide by zero error, please enter a new second operand.')) # Get the new second operand from the user
            result = divide(operand_1, operand_2) # Get the rsults by calling the divide function
            print(f'{operand_1} / {operand_2} is equal to {result:.4f}.\n') # Display results to the user
        elif option == 5: # Elif statement that checks if the user picked the fifthe option
            print('Goodbye, the program is closing...') # Tell the user that the program is closing
        else: # Else statement that catches all invaled options
            print('You entered an invalid option, please try again.\n') # Tell the user that their previous option was invalid

# Add function declaration
def add(num_1, num_2):
    return num_1 + num_2 # Return sum to main function call


# Subtract function declaration
def subtract(num_1, num_2):
    return num_1 - num_2 # Return difference to main function call

# Multiply function declaration
def multiply(num_1, num_2):
    return num_1 * num_2 # Return product to main function call

# Divide function declaration
def divide(num_1, num_2):
    return num_1 / num_2 # Return quotient to main function call

# Call main so that the program runs
main()
