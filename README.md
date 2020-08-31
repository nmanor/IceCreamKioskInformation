# Ice Cream Information Kiosk
**Developed by Michael Goldmeier and Natan Manor**

**At Jerusalem Collage of Technolegy, Campus Lev**

A video explaining the software and its use can be found [here](https://youtu.be/UI-k_IfrF8Q) and 
System entity UML sketching can be found [here](https://github.com/nmanor/IceCreamKioskInformation/blob/master/UML.pdf).
## Introduction
This software is intended to serve as an information kiosk for selling ice cream and similar products. The purpose of the software is to be on a screen in a central location in the city and allows the typical user who wants to buy a product to search. The software returns a list of stores selling this product. When choosing a particular store, you will find details and a list of recommendations for the specific product in question.
## Search
The search allows you to find an ice cream type based on parameters:
- Some of the description, name or taste of the product (a word from the description is sufficient, and you can write words with up to 2 misspellings and the software will still recognize the word)
- The lowest score obtained
- The highest score obtained
- Nutritional properties: energy, calories, fats, proteins, etc.
- And more...

The result is a list of ice creams that meet the parameters, including the ice cream shop details and an arrival map. 
Product selection focuses the view on the store and displays its details including a map, as well as a list of all recommendations. 
In addition, the user can select a product and fill in reviews about it.
## Admin operations
Fills in data on stores that provide products, as well as the list of products they provide
The manager enters ice cream shop information including:
- Address
- Store image (sent to the software via email and undergoing testing by AI)
- Phone
- Website
- Facebook link
- And more...

The manager also certifies products sold, for each product the following information is entered:
- Type of product
- Product Name
- Description
- Initial opinion that includes an initial grade from one to five, an image taken by the administrator, etc.
- and more...

The manager can also view the store list, edit it, and change information inside. The same goes for the product list itself.
## Architectures and Structure
The general modulation is based on the classical 3-tier architecture, while the code organization in the PL layer is based on the MVVM pattern: for each defined triad matching process.
Data storage and retrieval is based on Microsoft's ADO.NET Entity Framework for database handling.
