#include "ItemToPurchase.h"
#include <string>
#include <sstream>
#include <iomanip>
#include <iostream>

//default constructor
ItemToPurchase::ItemToPurchase() {
	itemName = "none";
	itemDescription = "none";
	itemPrice = 0;
	itemQuantity = 0;

}

//parameterized constructor
ItemToPurchase::ItemToPurchase(string name, string description, float price, int quantity) {
	itemName = name;
	itemDescription = description;
	itemPrice = price;
	itemQuantity = quantity;
}

//accessors
string ItemToPurchase::GetName() {
	return itemName;
}

string ItemToPurchase::GetDescription() {
	return itemDescription;
}

float ItemToPurchase::GetPrice() {
	return itemPrice;
}

int ItemToPurchase::GetQuantity() {
	return itemQuantity;
}

//mutators
void ItemToPurchase::SetName(string name) {
	itemName = name;
}

void ItemToPurchase::SetDescription(string description) {
	itemDescription = description;
}

void ItemToPurchase::SetPrice(float price) {
	itemPrice = price;
}

void ItemToPurchase::SetQuantity(int quantity) {
	itemQuantity = quantity;
}


string ItemToPurchase::StringOfItemCost() {

	float subtotal = itemPrice * itemQuantity;

	//get specific print for testing
	ostringstream returnString;
	returnString << itemName << " " << itemQuantity << " @ $" << fixed << setprecision(2) << itemPrice << " = $" << setprecision(2) << subtotal;
	
	string finalString;
	finalString = returnString.str();
	return finalString;

}

string ItemToPurchase::StringOfItemDescription() {

	//get specific print for testing
	ostringstream returnString;
	returnString << itemName << ": " << itemDescription;

	string finalString;
	finalString = returnString.str();
	return finalString;

}