# Define the encryption dictionary
codes = {
    'A': '1', 'B': '2', 'C': '3', 'D': '4', 'E': '5', 'F': '6', 'G': '7', 'H': '8', 'I': '9', 'J': '0',
    'K': '!', 'L': '@', 'M': '#', 'N': '$', 'O': '%', 'P': '^', 'Q': '&', 'R': '*', 'S': '(', 'T': ')',
    'U': '-', 'V': '=', 'W': '_', 'X': '+', 'Y': '[', 'Z': ']',
    'a': '{', 'b': '}', 'c': '|', 'd': ';', 'e': ':', 'f': ',', 'g': '<', 'h': '.', 'i': '>', 'j': '/',
    'k': '?', 'l': 'A', 'm': 'B', 'n': 'C', 'o': 'D', 'p': 'E', 'q': 'F', 'r': 'G', 's': 'H', 't': 'I',
    'u': 'J', 'v': 'K', 'w': 'L', 'x': 'M', 'y': 'N', 'z': 'O'
}

# Function to encrypt a file
def encrypt_file(input_file, output_file):

    # Make sure the file opens
    try:
        # Open file in read mode
        input_file_obj = open(input_file, 'r')
        # Read file contents
        contents = input_file_obj.read()
        # Close the file
        input_file_obj.close()

        # Declare string to hold the encrypted version of the file's contents
        encrypted_contents = ''

        # Check all characters in the file's content
        for char in contents:
            # If the character is in the dictionary, encrypt it; otherwise, keep it the same
            if char in codes:
                encrypted_contents += codes[char]
            else:
                encrypted_contents += char

        # Open the new file specified by the user
        output_file_obj = open(output_file, 'w')
        # Write the encrypted contents to the file
        output_file_obj.write(encrypted_contents)
        # Close the file
        output_file_obj.close()

        print("Encryption completed successfully.")

    except FileNotFoundError:
        print("Input file not found.")

# Main function
def main():
    # Get the file names from the user
    input_file = input("Please enter the name of the file to encrypt: ")
    output_file = input("Please enter the name of the output file: ")

    # Call the encrypt_file function to encrypt the content of the file
    encrypt_file(input_file, output_file)

# Call the main function
main()
