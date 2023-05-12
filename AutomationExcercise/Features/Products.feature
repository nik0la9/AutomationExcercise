Feature: Products
	As a user
	I want to be able to work with Products section
	So i can search for products
@mytag
Scenario: User can search products from search box
	Given user opened products page
	When user click on search box
		And type in it "t-shirt"
		And click on search button
	Then searched items will be listed and message "Searched Products" will appear

Scenario: User can add product to cart
	Given user opens products page
		And searches for 'Top' products
		And opens first search result
	When user clicks on Add to Cart button
		And proceeds to the cart
	Then shopping cart will be displayed with expected product inside