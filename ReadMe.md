# RabbitMQ Example Project

This project shows a very simple, direct RabbitMQ Client, example.

# Requirements

+ Docker

# Running this example

1. Turn on Docker, if it isn't already on.
2. Run the SetupInfrastructure PS1 script in Powershell or the Windows Terminal
	2a. If you get an error about running scripts run the following first then try again.
	Set-ExecutionPolicy Unrestricted -Scope CurrentUser

3. Run the publisher project
4. Visit http://localhost:15672/ with username and password as guest
5. Confirm 5 ready messages
6. Run the consumer project
7. Confirm 0 ready messages
8. Press Ctrl+C in the Powershell or Windows Terminal to turn off RabbitMQ