
#ifndef SHOPPINGCARTH
#define SHOPPINGCARTH

#include <iostream>
#include <string>
#include <vector>
#include "ItemToPurchase.h"
using namespace std;

class ShoppingCart {
public:

	//constructors
	ShoppingCart();
	ShoppingCart(string customer, string date);

	//accessors
	string GetCustomerName();
	string GetDate();

	void AddItem(ItemToPurchase newItem);
	void RemoveItem(string name);
	void ModifyItem(ItemToPurchase specificItem);
	int GetNumItemsInCart();
	float GetCostOfCart();

	string StringOfTotal();
	string StringOfDescriptions();
	
//private declarations
private:

	string customerName;
	string currentDate;
	vector<ItemToPurchase> cartItems;

};

#endif



