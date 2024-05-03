# Define the decryption dictionary
codes = {
    '1': 'A', '2': 'B', '3': 'C', '4': 'D', '5': 'E', '6': 'F', '7': 'G', '8': 'H', '9': 'I', '0': 'J',
    '!': 'K', '@': 'L', '#': 'M', '$': 'N', '%': 'O', '^': 'P', '&': 'Q', '*': 'R', '(': 'S', ')': 'T',
    '-': 'U', '=': 'V', '_': 'W', '+': 'X', '[': 'Y', ']': 'Z',
    '{': 'a', '}': 'b', '|': 'c', ';': 'd', ':': 'e', ',': 'f', '<': 'g', '.': 'h', '>': 'i', '/': 'j',
    '?': 'k', 'A': 'l', 'B': 'm', 'C': 'n', 'D': 'o', 'E': 'p', 'F': 'q', 'G': 'r', 'H': 's', 'I': 't',
    'J': 'u', 'K': 'v', 'L': 'w', 'M': 'x', 'N': 'y', 'O': 'z'
}


# Function to decrypt a file
def decrypt_file(input_file):

    # Make Sure the file opens
    try:
        # Open file in read mode, read from the file, then close
        input_file_obj = open(input_file, 'r')
        contents = input_file_obj.read()
        input_file_obj.close()

        # Declare a string to hold the decrypted contents of the file
        decrypted_contents = ''

        # For loop that checks every string character
        for char in contents:
            # If-Else structure that decrypts all characters present in the dictionary and leaves those that aren't the same
            if char in codes:
                decrypted_contents += codes[char]
            else:
                decrypted_contents += char

        # Display the decrypted contents to the user
        print("Decrypted contents:")
        print(decrypted_contents)

    except FileNotFoundError:
        print("Input file not found.")


# Main function
def main():
    # Get the file name from the user
    input_file = input("Enter the name of the file to decrypt: ")

    # Call the decrypt_file function
    decrypt_file(input_file)


# Call the main function
main()