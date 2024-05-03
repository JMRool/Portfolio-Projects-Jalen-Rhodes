
#include "ShoppingCart.h"
#include "ItemToPurchase.h"
#include <string>
#include <vector>
#include <sstream>
#include <iomanip>
#include <iostream>

//print the menu
void PrintMenu() {
	cout << "MENU" << endl;
	cout << "a - Add item to cart" << endl;
	cout << "d - Remove item from cart" << endl;
	cout << "c - Change item quantity" << endl;
	cout << "i - Output items' descriptions" << endl;
	cout << "o - Output shopping cart" << endl;
	cout << "q - Quit" << endl << endl;
	cout << "Choose an option:" << endl;
}


//add item to the shopping cart
void AddItemToCart(ShoppingCart newCustomer) {
	
	// object that holds item values
	ItemToPurchase newItem;

	//declare variables to hold user input for the object
	string name;
	string description;
	float price;
	int quantity;
	
	cout << "ADD ITEM TO CART" << endl;

	cin.ignore();
	cout << "Enter the item name:" << endl;
	getline(cin, name);

	cout << "Enter the item description:" << endl;
	getline(cin, description);

	cout << "Enter the item price:" << endl;
	cin >> price;

	cout << "Enter the item quantity:" << endl;
	cin >> quantity;

	newItem = ItemToPurchase(name, description, price, quantity);
	newCustomer.AddItem(newItem);

}

//remove item specified from the cart
void RemoveItemFromCart(ShoppingCart newCustomer) {
	string itemToRemove;

	cout << "REMOVE ITEM FROM CART" << endl;
	cout << "Enter name of item to remove :" << endl;
	cin.ignore();
	getline(cin, itemToRemove);
	newCustomer.RemoveItem(itemToRemove);
}

void ModifyCartItem(ShoppingCart newCustomer) {

	string name;
	ItemToPurchase specificItem;
	int newQuantity;

	cout << "CHANGE ITEM QUANTITY" << endl;
	cout << "Enter the item name:" << endl;
	cin.ignore();
	getline(cin, name);
	cout << "Enter the new quantity:" << endl;
	cin >> newQuantity;

	specificItem = ItemToPurchase(name, "none", 0, newQuantity);
	newCustomer.ModifyItem(specificItem);
}

void OutputDescriptions(ShoppingCart newCustomer) {
	string outputString;
	cout << "OUTPUT SHOPPING CART" << endl;
	outputString = newCustomer.StringOfTotal();
	cout << outputString;
}

void OutputCart(ShoppingCart newCustomer) {
	string outputString;
	cout << "OUTPUT ITEMS' DESCRIPTIONS" << endl;
	outputString = newCustomer.StringOfDescriptions();
	cout << outputString;
}

void ExecuteMenu(char menuOption, ShoppingCart newCustomer) {
	if (menuOption == 'a') {
		AddItemToCart(newCustomer);
	}
	else if (menuOption == 'd') {
		RemoveItemFromCart(newCustomer);
	}
	else if (menuOption == 'c') {
		ModifyCartItem(newCustomer);
	}
	else if (menuOption == 'i') {
		OutputDescriptions(newCustomer);
	}
	else if (menuOption == 'o') {
		OutputCart(newCustomer);
	}
}