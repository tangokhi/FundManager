# FundManager
Introduction:-
The application is a layered application which allows the user to add Equity or Bond stocks to a Fund. The application is developed using WPF and .Net framework 4.6.1. It uses prism for MVVM and Unity for dependency injections. 
It consists of just one project but different layers are separated in their own folders and namespaces. 

The project has following layers:-

Model   (Contains domain model classes)

Repository (Contains data access repository)

Service (Contains service layer)

UI :-

ViewModels

Views

Converters

Tests:-

Tests projects consists of all the tests which are used to provide the coverage and development. 

Improvements:-

1)	Business logic, model and data access can be moved to back-end service so that multiple UI clients can connect to the same service. WCF or Web-Api or any other appropriate technology can be used for this purpose. 

2)	Currently the application does not persist data. A database can be used to persist data. 

3)	Pre-condition can be checked in the application. 

4)	Translations can be implemented if required.
