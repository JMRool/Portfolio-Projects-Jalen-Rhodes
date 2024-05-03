#include "Utility.h"
#include "ShoppingCart.h"
#include <string>
#include <iostream>
using namespace std;

int main() {
	string customer;
	string date;
	char menuOption = 'a';
	ShoppingCart newCustomer;

	cout << "Enter customer's name:" << endl;
	getline(cin, customer);
	cout << "Enter today's date:" << endl;
	getline(cin, date);

	newCustomer = ShoppingCart(customer, date);
	cout << "Customer name: " << newCustomer.GetCustomerName() << endl;
	cout << "Today's date: " << newCustomer.GetDate() << endl;

	PrintMenu();
	cin >> menuOption;

	while (menuOption != 'q') {
		ExecuteMenu(menuOption, newCustomer);

		PrintMenu();
		cin >> menuOption;
	}

	return 0;
}