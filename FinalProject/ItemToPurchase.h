
#ifndef ITEMTOPURCHASEH
#define ITEMTOPURCHASEH

#include <iostream>
using namespace std;

class ItemToPurchase {
public:

	//constructors
	ItemToPurchase();
	ItemToPurchase(string name, string description, float price, int quantity);

	//accessors
	string GetName();
	float GetPrice();
	int GetQuantity();
	string GetDescription();

	//mutators
	void SetName(string name);
	void SetPrice(float price);
	void SetQuantity(int quantity);
	void SetDescription(string description);
	string StringOfItemCost();
	string StringOfItemDescription();

//private declarations
private:

	string itemDescription;
	string itemName;
	float itemPrice;
	int itemQuantity;

};

#endif

