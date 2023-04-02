﻿Feature: ContactUs
	As a user
	I want to be able to work with Contact Us section
	So i can message customer support

@mytag
Scenario: User can send message via contact us form
	Given user opens contact us page
	When user enters all required fields
		And submits contact us form
		And confirms the prompt message
	Then user will recieve 'Success! Your details have been submitted successfully.' message