
#include "ItemToPurchase.h"
#include "ShoppingCart.h"
#include <string>
#include <vector>
#include <sstream>
#include <iomanip>
#include <iostream>

//constructors
ShoppingCart::ShoppingCart() {
	customerName = "none";
	currentDate = "January 1, 2016";
}

ShoppingCart::ShoppingCart(string customer, string date) {
	customerName = customer;
	currentDate = date;
}

//accessors
string ShoppingCart::GetCustomerName() {
	return customerName;
}

string ShoppingCart::GetDate() {
	return currentDate;
}

//Add an item to the cart
void ShoppingCart::AddItem(ItemToPurchase newItem) {
	cartItems.push_back(newItem);
}

//Remove an item from the cart
void ShoppingCart::RemoveItem(string name) {

	//Declare for loop counters
	int j;
	int i;

	// declare boolean to determine if the name is found or not
	bool found = false;

	//For loop to find the specified item by name
	for (i = 0; i < cartItems.size(); ++i) {
		if (cartItems.at(i).GetName() == name) {
			found = true;

			//For loop that shifts all cart items inorder to delete the specified item
			for (i = i; i < (cartItems.size() - 1); ++i) {
				j = i + 1;
				cartItems.at(i) = cartItems.at(j);
			}

			// get ridd of unnecessary end value
			cartItems.pop_back();
			break;
		}
	}

	if (found == false) {
		cout << "Item not found in cart. Nothing removed." << endl;
	}
}

void ShoppingCart::ModifyItem(ItemToPurchase specificItem) {
	
	//declare integer for the loop
	int i;

	//declare boolean to determine if the item was found
	bool found = false;


	//for loop that finds the specified item and exchanges its information with the one in the parameter
	for (i = 0; i < cartItems.size(); ++i) {
		if (cartItems.at(i).GetName() == specificItem.GetName()) {
			if (specificItem.GetDescription() != "none") {
				cartItems.at(i).SetDescription(specificItem.GetDescription());
			}
			if (specificItem.GetPrice() != 0) {
				cartItems.at(i).SetPrice(specificItem.GetPrice());
			}
			if (specificItem.GetQuantity() != 0) {
				cartItems.at(i).SetQuantity(specificItem.GetQuantity());
			}
			found = true;
			break;
		}
	}

	if (found == false) {
		cout << "Item not found in cart. Nothing modified." << endl;
	}
}

//Function returns the number of items in the vector
int ShoppingCart::GetNumItemsInCart() {
	
	// counter for total items
	int numItems = 0;

	//Integer for the loop
	int i;

	//Loop that computes the total price
	for (i = 0; i < cartItems.size(); ++i) {
		numItems = numItems + cartItems.at(i).GetQuantity();
	}

	return numItems;
}


float ShoppingCart::GetCostOfCart() {

	//float variable for the total cost
	float total = 0;
	
	//Integer for the loop
	int i;

	//Loop that computes the total price
	for (i = 0; i < cartItems.size(); ++i) {
		total = total + cartItems.at(i).GetPrice();
	}

	return total;
}

//Returns a string with a list of all items in the cart
string ShoppingCart::StringOfTotal() {

	//get correct format for string
	ostringstream returnString;

	//declare variables to hold items from functions that will later be used in the string
	float total = GetCostOfCart();
	int numItems = GetNumItemsInCart();

	//if statement to determine if the car has items
	if (numItems == 0) {
		returnString << "SHOPPING CART IS EMPTY" << endl;
	}
	else {

		returnString << customerName << "'s Shopping Cart - " << currentDate << endl;
		returnString << "Number Of Items: " << numItems << endl << endl;
		for (int i = 0; i < cartItems.size(); ++i) {
			returnString << cartItems.at(i).StringOfItemCost();
		}
		returnString << endl;
		returnString << "Total: $" << fixed << setprecision(2) << total << endl;
	}

	string finalString = returnString.str();
	return finalString;
}

string ShoppingCart::StringOfDescriptions() {

	//get correct format for string
	ostringstream returnString;

	returnString << customerName << "'s Shopping Cart - " << currentDate << endl << endl;
	returnString << "Item Descriptions" << endl;
	for (int i = 0; i < cartItems.size(); ++i) {
		returnString << cartItems.at(i).StringOfItemDescription();
	}

	string finalString = returnString.str();
	return finalString;
}
