
#ifndef UTILITYH
#define UTILITYH
using namespace std;

#include "ShoppingCart.h"
#include <string>
#include <vector>
#include <sstream>
#include <iomanip>
#include <iostream>

void PrintMenu();
void ExecuteMenu(char menuOption, ShoppingCart newCustomer);
void AddItemToCart(ShoppingCart newCustomer);
void RemoveItemFromCart(ShoppingCart newCustomer);
void ModifyCartItem(ShoppingCart newCustomer);
void OutputDescriptions(ShoppingCart newCustomer);
void OutputCart(ShoppingCart newCustomer);

#endif
