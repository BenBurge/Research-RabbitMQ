# RabbitMQ Example Project

This project contains examples for using RabbitMQ and MassTransit.

# Requirements

+ Docker

# Setting Up Infrastructure
- Turn on Docker, if it isn't already on.
- Run the SetupInfrastructure PS1 script in Powershell or the Windows Terminal
	- If you get an error about running scripts run the following first then try again.
	Set-ExecutionPolicy Unrestricted -Scope CurrentUser

# Running RabbitMQ Consumer and Producer

1. Run the publisher project
2. Visit http://localhost:15672/ with username and password as guest
3. Confirm 5 ready messages
4. Run the consumer project
5. Confirm 0 ready messages
6. Press Ctrl+C in the Powershell or Windows Terminal to turn off RabbitMQ

# Running MassTransit Example

This project is both a consumer and a publisher. Using Background Services we run two
publishers based on MassTransit. Then we have one consumer that performs a single task
before acknowling the request is done.